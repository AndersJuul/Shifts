Param (
    [Parameter(Mandatory=$True)]
    [string]$Environment,
    [Parameter(Mandatory=$True)]
    [string]$InstDir,
    [Parameter(Mandatory=$True)]
    [string]$InstPath
)

function Get-ServiceExePath ($name)
{
    $service = Get-WmiObject win32_service | ?{$_.Name -eq $name} 
    $path = $service | select @{Name="Path"; Expression={$_.PathName.split('"')[1]}} 
    $path.Path
}

Write-Host "Parameter: " + $Environment
Write-Host "Parameter: " + $InstDir
Write-Host "Parameter: " + $InstPath

