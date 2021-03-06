﻿using Mastrosoft.CloudConvert.Models;
using Mastrosoft.CloudConvert.Models.Tasks;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Utf8Json;
using Utf8Json.Formatters;
using Utf8Json.Resolvers;

namespace Mastrosoft.CloudConvert
{
    public interface ICloudConvertClient
    {
        Task<JobDataResponse> CreateJob(CreateJob jobTask);
        Task<DataResponse<T>> CreateTask<T>(T input) where T : TaskBase;
        bool ValidateWebhook(string json, string signature, string signingSecret);
        bool ValidateWebhook(string json, string signature);
    }
    public class CloudConvertClient : ICloudConvertClient
    {
        public const string API_BASE = "https://api.cloudconvert.com/v2/";
        public const string API_SANDBOX_BASE = "https://api.sandbox.cloudconvert.com/v2/";
        private readonly CloudConvertSettings _settings;
        private readonly HttpClient _httpClient;
        private IJsonFormatterResolver _resolver;
        private IJsonFormatter<object> _dynamicResolver;

        public CloudConvertClient(IOptions<CloudConvertSettings> settings, HttpClient client)
        {
            _settings = settings.Value;
            _httpClient = client ?? new HttpClient();
            ConfigureHttpClient();
        }

        public CloudConvertClient(string apiKey, bool sandbox = false)
        {
            _settings = new CloudConvertSettings
            {
                ApiKey = apiKey,
                Sandbox = sandbox
            };
            _httpClient = new HttpClient();
            ConfigureHttpClient();
        }

        private void ConfigureHttpClient()
        {
            _httpClient.BaseAddress = new Uri(_settings.Sandbox ? API_SANDBOX_BASE : API_BASE);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + _settings.ApiKey);
            _resolver = StandardResolver.ExcludeNullSnakeCase;
            _dynamicResolver = new DynamicObjectTypeFallbackFormatter(new[] { _resolver });
            
        }

        public async Task<DataResponse<T>> CreateTask<T>(T input) where T : TaskBase
        {
            using (MemoryStream stream = new MemoryStream()) {
                await JsonSerializer.NonGeneric.SerializeAsync(stream, input, _resolver);

                stream.Position = 0;

                var method = new HttpMethod(input.Method);
                var requestMessage = new HttpRequestMessage(method, input.Operation)
                {

                    Content = new StreamContent(stream)
                };
                requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var result = await _httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead);
                var getStreamTask = result.Content.ReadAsStreamAsync();
                if (result.IsSuccessStatusCode)
                {
                    var responseStream = await getStreamTask;
                    return (await JsonSerializer.DeserializeAsync<Response<T>>(responseStream, _resolver))?.Data;
                }
                else
                {
                    var responseStream = await getStreamTask;
                    var error = (await JsonSerializer.DeserializeAsync<ErrorResponse>(responseStream, _resolver));
                    throw new CloudConvertException(error);
                }
            }
        }

        public async Task<JobDataResponse> CreateJob(CreateJob jobTask)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                await JsonSerializer.NonGeneric.SerializeAsync(stream, jobTask, _resolver);
                stream.Position = 0;
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, "jobs")
                {
                    Content = new StreamContent(stream),
                };
                requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = await _httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead);
                var getStreamTask = result.Content.ReadAsStreamAsync();
                if (result.IsSuccessStatusCode)
                {
                    var responseStream = await getStreamTask;
                    return (await JsonSerializer.DeserializeAsync<JobResponse>(responseStream, _resolver)).Data;
                }
                else
                {
                    var responseStream = await getStreamTask;
                    var error = (await JsonSerializer.DeserializeAsync<ErrorResponse>(responseStream, _resolver));
                    throw new CloudConvertException(error);
                }
            }
        }
        public bool ValidateWebhook(string json, string signature)
        {
            return ValidateWebhook(json, signature, _settings.SigningSecret);
        }
        public bool ValidateWebhook(string json, string signature, string signingSecret)
        {
            string hashHMAC = HashHMAC(signingSecret, json);

            return hashHMAC == signature;
        }

        private string HashHMAC(string key, string message)
        {
            byte[] hash = new HMACSHA256(Encoding.UTF8.GetBytes(key)).ComputeHash(new ASCIIEncoding().GetBytes(message));
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }
    }
}
