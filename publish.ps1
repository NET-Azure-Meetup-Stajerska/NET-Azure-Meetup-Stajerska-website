$repoPath = "..\NET-Azure-Meetup-Stajerska.github.io"
$tempPath = ".\bin\publish-temp"

# Publish to a temp folder
dotnet publish -c Release -o $tempPath

# Clear the repo (keep .git and .nojekyll)
Get-ChildItem -Path $repoPath -Force | Where-Object {
    $_.Name -notmatch '\.git|\.nojekyll'
} | Remove-Item -Recurse -Force

# Copy only the contents of wwwroot into the repo root
Copy-Item -Path "$tempPath\wwwroot\*" -Destination $repoPath -Recurse -Force

# Clean up temp folder
Remove-Item -Path $tempPath -Recurse -Force

Write-Host "Published to $repoPath"
Write-Host "Now go to that folder, git commit and git push to publish online."
