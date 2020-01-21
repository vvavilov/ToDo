$FrontendSource = "..\to-do-frontend";
$FrontendBuild = Join-Path $FrontendSource "build\*"
$FrontendBuildZip = Join-Path $FrontendSource "build\deploy.zip"

 & 'npm' '--prefix' $FrontendSource 'run' 'build:staging'

Compress-Archive -Path $FrontendBuild -DestinationPath $FrontendBuildZip

Connect-AzAccount

# Strange Bug
$BuildZipForAzure = $FrontendBuildZip.Replace("..", ".")

Publish-AzWebapp -ResourceGroupName to-do -Name to-do-frontend -ArchivePath $BuildZipForAzure -Force