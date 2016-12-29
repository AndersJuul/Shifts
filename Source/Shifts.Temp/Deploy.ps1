Write-Host "Parameter: #{Octopus.Environment.Name}"
$ExePath = "#{Octopus.Action[Shifts.Temp].WindowsService.ExecutablePath}"
Write-Host "ExePath : " $ExePath


$ServiceName = "#{Octopus.Environment.Name}-Shifts.Temp"
Write-Host "Service Name: $ServiceName"

if ($ExePath)
{
    Write-Host "Service executable: Shifts.Temp.exe"
    & .\#{Octopus.Action[Shifts.Temp].WindowsService.ExecutablePath} uninstall
    Write-Host "Service removed."
}
else
{
    Write-Host "Service not found: " $ServiceName
}

