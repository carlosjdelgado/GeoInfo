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

function Remove-PostBuildEvent ($project, $installPath) {
    $postBuildCmd = Get-PostBuildCommand $installPath
    
    try {
        # Get the current Post Build Event cmd
        $currentPostBuildCmd = $project.Properties.Item("PostBuildEvent").Value

        # Remove our post build command from it (if it's there)
        $project.Properties.Item("PostBuildEvent").Value = $currentPostBuildCmd.Replace($postBuildCmd, '')
    } catch {
        # Accessing $project.Properties might throw
    }
}

Export-ModuleMember -function Add-PostBuildEvent, Get-PostBuildCommand, Remove-PostBuildEvent