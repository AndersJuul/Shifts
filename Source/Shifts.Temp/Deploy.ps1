Write-Host "Parameter: #{Octopus.Environment.Name}"
Write-Host "ExePath : #{Octopus.Action[Shifts.Temp].WindowsService.ExecutablePath}"

$ServiceName = "#{Octopus.Environment.Name}-Shifts.Temp"
Write-Host "Service Name: $ServiceName"

if ($ExePath)
{
    Write-Host "Service executable: Shifts.Temp.exe"
    & #{Octopus.Action[Shifts.Temp].WindowsService.ExecutablePath} uninstall
    Write-Host "Service removed."
}
else
{
    Write-Host "Service not found: " $ServiceName
}

write-host "Installing service: " $ServiceName
& #{Octopus.Action[Shifts.Temp].WindowsService.ExecutablePath} install --autostart -servicename $ServiceName
Start-Service $ServiceName
write-host "Service installed: " + $ServiceName
