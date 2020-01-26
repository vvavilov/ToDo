$OutputPath = "../to-do-frontend/src/generated/client-api/WebApiClient.ts"
$NSwagConfiguration = "./code-generation/settings.nswag"
$Configuration = "Debug"

& 'nswag' 'run' "$NSwagConfiguration" '/runtime:NetCore31' "/variables:Output=$OutputPath,Configuration=$Configuration"