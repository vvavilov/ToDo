$OutputPath = "../../../Frontend/to-do/src/generated/client-api/WebApiClient.ts"
$NSwagConfiguration = "./src/ToDo.WebApi/specs/nswag.json"
$Configuration = "Debug"

# & "$NswagExe run specs/nswag.json /runtime:NetCore31 /variables:Output=$OutputPath,Configuration=$Configuration"

& 'nswag' 'run' "$NSwagConfiguration" '/runtime:NetCore31' "/variables:Output=$OutputPath,Configuration=$Configuration"