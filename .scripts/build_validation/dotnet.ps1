param (
    [string]$ProjectFilePath,
    [string]$BuildConfiguration
)

if (-not $ProjectFilePath -or -not $BuildConfiguration)
{
    Write-Host "`e[38;5;196mNo arguments.`e[0m"
    Write-Host "`e[38;5;196mUsage: .\dotnet-build.ps1 -ProjectFilePath <ProjectFilePath> -BuildConfiguration <BuildConfiguration> -ResultFile <ResultFile>`e[0m"
    exit 1
}

# Initialize variables
$isError = $false
$output = "`e[0mBuilding project: $ProjectFilePath with configuration: $BuildConfiguration os:Windows `e[0m `n"

# Execute build command and capture output
$buildOutput = & dotnet build $ProjectFilePath -c $BuildConfiguration 2>&1
$buildExitCode = $LASTEXITCODE

if ($buildExitCode -ne 0)
{
    # Handle build failure
    $output += "`e[38;5;196mBuild failed.`e[0m`n"
    $output += "`e[38;5;196mError Output:`e[0m`n"

    # Process each line in build output
    foreach ($line in $buildOutput -split "`n")
    {
        $output += "`e[38;5;245m - $line`e[0m`n"
    }

    $summary = "`e[38;5;196mBuild failed.`e[0m"
    $isError = $true
}
else
{
    # Handle build success
    $summary = "`e[38;5;46mBuild Test Completed Successfully.`e[0m"

    # Process each line in build output
    foreach ($line in $buildOutput -split "`n")
    {
        $output += "`e[38;5;245m - $line`e[0m`n"
    }
}

# Combine summary and output
$result = "$output`n$summary"
Write-Host $result

# Exit with error if build failed
if ($isError)
{
    exit 1
}
