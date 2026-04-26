# Run this script from the CookBook root folder
# Right-click → "Run with PowerShell" or run in terminal:
# cd CookBook && .\create-sln.ps1

Write-Host "Creating CookBook solution..." -ForegroundColor Cyan

# Remove old sln if exists
if (Test-Path "CookBook.sln") {
    Remove-Item "CookBook.sln"
    Write-Host "Removed old CookBook.sln" -ForegroundColor Yellow
}

# Create new solution
dotnet new sln -n CookBook
Write-Host "Solution created" -ForegroundColor Green

# Add all projects
dotnet sln add src/CookBook.Domain/CookBook.Domain.csproj
dotnet sln add src/CookBook.ValueObjects/CookBook.ValueObjects.csproj
dotnet sln add src/CookBook.Domain.Repositories.Abstractions/CookBook.Domain.Repositories.Abstractions.csproj

Write-Host ""
Write-Host "Done! Open CookBook.sln in Visual Studio." -ForegroundColor Green
