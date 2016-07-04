function Get-ProjectRoot($project) {
    try {
        $project.Properties.Item("FullPath").Value
    } catch {

    }
}

function Add-PostBuildEvent ($project, $installPath) {
    $currentPostBuildCmd = $project.Properties.Item("PostBuildEvent").Value
    $postBuildCmd = Get-PostBuildCommand $installPath
    # Append our post build command if it's not already there
    if (!$currentPostBuildCmd.Contains($postBuildCmd)) {
        $project.Properties.Item("PostBuildEvent").Value += $postBuildCmd
    }
}

function Get-PostBuildCommand ($installPath) {
    Write-Host $dte.Solution.FullName $installPath
    $solutionDir = [IO.Path]::GetDirectoryName($dte.Solution.FullName) + "\"
    $path = $installPath.Replace($solutionDir, "`$(SolutionDir)")

    $ResourcesDir = Join-Path $path "Resources"
    $resources = $(Join-Path $ResourcesDir "*.*")

    return "
    if not exist `"`$(TargetDir)Resources`" md `"`$(TargetDir)Resources`"
    xcopy /s /y `"$resources`" `"`$(TargetDir)Resources`""
}

function Add-FilesToDirectory ($srcDirectory, $destDirectory) {
    ls $srcDirectory -Recurse -Filter *.dll  | %{
        $srcPath = $_.FullName

        $relativePath = $srcPath.Substring($srcDirectory.Length + 1)
        $destPath = Join-Path $destDirectory $relativePath
        
        $fileSystem = Get-VsFileSystem
        if (!(Test-Path $destPath)) {
            $fileStream = $null
            try {
                $fileStream = [System.IO.File]::OpenRead($_.FullName)
                $fileSystem.AddFile($destPath, $fileStream)
            } catch {
                # We don't want an exception to surface if we can't add the file for some reason
            } finally {
                if ($fileStream -ne $null) {
                    $fileStream.Dispose()
                }
            }
        }
    }
}

Export-ModuleMember -function Get-ProjectRoot, Add-FilesToDirectory, Add-PostBuildEvent, Get-PostBuildCommand