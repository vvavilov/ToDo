$OutputPath = "../../../to-do-frontend/src/generated/client-api/WebApiClient.ts"
$NSwagConfiguration = "./src/ToDo.WebApi/specs/nswag.json"
$Configuration = "Debug"

& 'nswag' 'run' "$NSwagConfiguration" '/runtime:NetCore31' "/variables:Output=$OutputPath,Configuration=$Configuration"