$ProjectName = "RabbitHutch"
$Configuration = 'Debug'
$BuildRoot = resolve-path '.\'
$SrcFolder = "$BuildRoot\src"
$SolutionFile = "$SrcFolder\RabbitHutch.sln"
$NugetFolder = "$BuildRoot\tools"
$NuGetExe = "$NugetFolder\nuget.exe"
$FerdinandPackagesDirectory = "$SrcFolder\packages"

#=================================================================================================
# Synopsis: Start Rabbit Hutch Host
#=================================================================================================
Task Start-Host {
  $processActive = Get-Process "RabbitHutch.Host" -ErrorAction SilentlyContinue
  if(!$processActive)
  {
    Write-Host "src/RabbitHutch.Host/bin/$configuration/RabbitHutch.Host.exe"
    Start-Process -FilePath "$SrcFolder/RabbitHutch.Host/bin/$configuration/RabbitHutch.Host.exe"
  } else {
      Write-Host "$appName already running."
  }
}
