Param (
    [Parameter(Mandatory=$True)]
    [string]$Environment,
    [Parameter(Mandatory=$True)]
    [string]$InstPath
)

Write-Host "Parameter: " + $Environment
Write-Host "Parameter: " + $InstPath

$ServiceName = $Environment"Shifts.Temp"
$ExePath = "Shifts.Temp.exe"

Write-Host "Removing service: " $ServiceName
if ($ExePath)
{
    Write-Host "Service executable: " $ExePath
    $ExePath uninstall
    Write-Host "Service removed."
}
else
{
    Write-Host "Service not found: " $ServiceName
}
