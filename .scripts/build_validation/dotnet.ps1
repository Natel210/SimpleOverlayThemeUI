param (
    [string]$ProjectFilePath,
    [string]$BuildConfiguration
)

if (-not $ProjectFilePath -or -not $BuildConfiguration)
{
    Write-Host "::Error::No arguments."
    Write-Host "Usage: .\dotnet-build.ps1 -ProjectFilePath <ProjectFilePath> -BuildConfiguration <BuildConfiguration> -ResultFile <ResultFile>"
    exit 1
}

# Initialize variables
$isError = $false
$output = "Building project: $ProjectFilePath with configuration: $BuildConfiguration os:Windows `n"

# Execute build command and capture output
$buildOutput = & dotnet build $ProjectFilePath -c $BuildConfiguration 2>&1
$buildExitCode = $LASTEXITCODE

if ($buildExitCode -ne 0)
{
    # Handle build failure
    $output += "Build failed.`n"
    $output += "Error Output:`n"

    # Process each line in build output
    foreach ($line in $buildOutput -split "`n")
    {
        $output += "  > $line`n"
    }

    $summary = "::Error::Build failed."
    $isError = $true
}
else
{
    # Handle build success
    $summary = "::Notice::Build Test Completed Successfully."

    # Process each line in build output
    foreach ($line in $buildOutput -split "`n")
    {
        $output += "  > $line`n"
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
