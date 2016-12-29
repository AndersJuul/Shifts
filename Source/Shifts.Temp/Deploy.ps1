Write-Host "Parameter: " + #{Octopus.Environment.Name}

$ServiceName = "#{Octopus.Environment.Name}" + "-Shifts.Temp"

Write-Host "Removing service: " $ServiceName

if ($ExePath)
{
    Write-Host "Service executable: Shifts.Temp.exe"
    Shifts.Temp.exe uninstall
    Write-Host "Service removed."
}
else
{
    Write-Host "Service not found: " $ServiceName
}

write-host "Installing service: " $ServiceName
Shifts.Temp.exe install --autostart -servicename $ServiceName
Start-Service $ServiceName
write-host "Service installed: " + $ServiceName
