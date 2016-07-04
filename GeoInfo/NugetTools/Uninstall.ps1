param($installPath, $toolsPath, $package, $project)

Import-Module (Join-Path $toolsPath VS.psd1)

Remove-PostBuildEvent $project $installPath