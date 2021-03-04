# Mastrosoft.CloudConvert
.NET wrapper for the cloudconvert.com service based on the v2 API.


> This an un-official .net SDK for the [CloudConvert](https://cloudconvert.com/api/v2) _API v2_.

## Installation

```
PM> Install-Package CloudConvert.API -Version 1.0.1
```
or
```
dotnet add package CloudConvert.API --version 1.0.1
```

This package uses the more performant UTF8Json Json library, and allows you to use IOptions to setup configuration.
It is not feature complete but i'm working on that.


## Creating Jobs

```c#
using Mastrosoft.CloudConvert;
using Mastrosoft.CloudConvert.Models.Tasks;
bool isSandbox = true;
var _cloudConvert = new CloudConvertClient("api_key", isSandbox);

var jobRequest = new CreateJob
  {
	Tag = "Test"
  }
jobRequest.Tasks.Add("import_file", new ImportUrlTask { Url = new Uri("{pdfurl}") });
jobRequest.Tasks.Add("convert_file", new ConvertTask
{
	Input = importResult.Id,
	InputFormat = "pdf",
	OptimizePrint = true,
	OutputFormat = "pdf",
	Pages = "1-2"
});
jobRequest.Tasks.Add("export_urlconvert", new ExportUrlTask { Input = "convert_file" });
var job = await _cloudConvert.CreateJob(jobRequest);
```
