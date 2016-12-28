function Get-ServiceExePath ($name)
{
    $service = Get-WmiObject win32_service | ?{$_.Name -eq $name} 
    $path = $service | select @{Name="Path"; Expression={$_.PathName.split('"')[1]}} 
    $path.Path
}

$ServiceName = $OctopusParameters['MyServiceName']
$ExePath = Get-ServiceExePath $ServiceName

Write-Host "Removing service: " + $ServiceName
if ($ExePath)
{
    Write-Host "Service executable: " + $ExePath
    & $ExePath uninstall
    Write-Host "Service removed."
}
else
{
    Write-Host "Service not found: " + $ServiceName
}