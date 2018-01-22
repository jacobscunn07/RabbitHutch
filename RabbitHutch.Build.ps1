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
    Start-Process -FilePath "$SrcFolder/RabbitHutch.Host/bin/$configuration/RabbitHutch.Host.exe"
  } else {
      Write-Host "$appName already running."
  }
}

#=================================================================================================
# Synopsis: Start Rabbit Hutch Test Harness
#=================================================================================================
Task Start-TestHarness {
  $processActive = Get-Process "RabbitHutch.TestHarness.Console" -ErrorAction SilentlyContinue
  if(!$processActive)
  {
    exec { dotnet "$SrcFolder/RabbitHutch.TestHarness.Console/bin/$configuration/netcoreapp2.0/RabbitHutch.TestHarness.Console.dll" }
  } else {
      Write-Host "$appName already running."
  }
}

#=================================================================================================
# Synopsis: WIP: Install the Host project as a windows service
#=================================================================================================
Task Install-Host {
    Write-Host "Need to implement"
}

#=================================================================================================
# Synopsis: WIP: Create IIS website for web project to be hosted
#=================================================================================================
Task Install-WebApp {
    Write-Host "Need to implement"
}
