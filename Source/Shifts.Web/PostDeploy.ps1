"$workingdir"
copy server.basehref.html basehref.html
npm install
start-job -filepath ./npm-start.ps1 -ArgumentList Get-Location