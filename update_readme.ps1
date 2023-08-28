function Start-Main {
    $readme = "README.md"
    Set-Content -Path $readme -Value '## Some of my [leetcode.com](https://leetcode.com) tasks solutions'
    
    $solutions = Get-Content -Raw "readme-data.json" | ConvertFrom-Json
    # $easy = $solutions | Where-Object -Property "complexity" -EQ 'Easy'
    # $medium = $solutions | Where-Object -Property "complexity" -EQ 'Medium'
    # $hard = $solutions | Where-Object -Property "complexity" -EQ 'Hard'

    Add-Content -Path $readme -Value "`n|Problem|Runtime(%)|Memory(%)|"
    Add-Content -Path $readme -Value "`|--|--|--|"
    $count = 0
    foreach($solution in $solutions | Sort-Object -Property "id") {
        $solution_path = ConvertToPath $solution.name $solution.complexity
        if (-not(Test-Path $solution_path)) {
            Write-Host -Foreground "Red" "Invalid solution path for task #$($solution.Id) $($solution_path)"
        }

        Add-Content -Path $readme -Value "|$($solution.Id). [$($solution.name)](/$($solution_path)) <sup>$($solution.complexity)<sup>| $($solution.performance.runtime) | $($solution.performance.memory) |"
    }

    Write-Host -Foreground "Green" "Results:"
    Write-Host -Foreground "Green" "#$(($solutions | Where-Object -Property "complexity" -EQ 'Easy').Count) easy problems processed"
    Write-Host -Foreground "Green" "#$(($solutions | Where-Object -Property "complexity" -EQ 'Medium').Count) medium problems processed"
    Write-Host -Foreground "Green" "#$(($solutions | Where-Object -Property "complexity" -EQ 'Hard').Count) hard problems processed"
    Write-Host -Foreground "Green" "______________________"
    Write-Host -Foreground "Green" "#$($solutions.Count) total"
}

function ConvertToPath {
    param(
        [Parameter (Mandatory = $true)] [String] $Name,
        [Parameter (Mandatory = $true)] [String] $Complexity
    )
    $Name = $Name.Replace(" ", "_")
    $Name = $Name.Substring(0,1).ToUpper() + $Name.Substring(1).ToLower()

    return "$($Complexity)/$($Name)/Solution.cs"
}

Start-Main