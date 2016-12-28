$exe = $OctopusParameters['Octopus.Action.Package.CustomInstallationDirectory'] + '\' + $OctopusParameters['ExeName']
$serviceName = $OctopusParameters['Topshelf.ServiceName']

write-host "Installing service: " + $serviceName
write-host "Executable: " + $exe
& $exe install --autostart
Start-Service $serviceName
write-host "Service installed: " + $serviceName