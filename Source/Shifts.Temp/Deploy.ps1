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

$ServiceName = $OctopusParameters['MyServiceName']
$ExePath = Get-ServiceExePath $ServiceName

Write-Host "Removing service: " + $ServiceName
if ($ExePath)
{
    Write-Host "Service executable: " + $ExePath
    $ExePath uninstall
    Write-Host "Service removed."
}
else
{
    Write-Host "Service not found: " + $ServiceName
}




$InstPath

write-host "Installing service: " + $ServiceName
write-host "Executable: " + $InstPath
$InstPath install --autostart
Start-Service $ServiceName
write-host "Service installed: " + $ServiceName