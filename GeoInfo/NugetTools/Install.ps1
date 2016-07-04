param($installPath, $toolsPath, $package, $project)

Import-Module (Join-Path $toolsPath VS.psd1)

Add-PostBuildEvent $project $installPath

Remove-Module VS