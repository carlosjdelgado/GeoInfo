param($installPath, $toolsPath, $package, $project)

$projectRoot = Get-ProjectRoot $project
if (!$projectRoot) {
    return;
}

$binDirectory = Join-Path $projectRoot "bin"
$resourcesDirectory = Join-Path $installPath "Resources"
$resourcesTargetDirectory = Join-Path $binDirectory "Resources"
New-Item -ItemType directory -Path $resourcesTargetDirectory

Add-FilesToDirectory $resourcesDirectory $resourcesTargetDirectory
