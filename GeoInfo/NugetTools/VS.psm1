function Get-ProjectRoot($project) {
    try {
        $project.Properties.Item("FullPath").Value
    } catch {

    }
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

Export-ModuleMember -function Get-ProjectRoot, Add-FilesToDirectory