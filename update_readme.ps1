function Start-Main {
    $readme = "README.md"
    Set-Content -Path $readme -Value '## Some of my [leetcode.com](https://leetcode.com) tasks solutions'
    
    $solutions = Get-Content -Raw "readme-data.csv" | ConvertFrom-Csv
    $easy = $solutions | Where-Object -Property "complexity" -EQ 'Easy'
    $medium = $solutions | Where-Object -Property "complexity" -EQ 'Medium'
    $hard = $solutions | Where-Object -Property "complexity" -EQ 'Hard'

    RenderSection $readme "Easy" $easy
    RenderSection $readme "Medium" $medium
    RenderSection $readme "Hard" $hard

    Write-Host -Foreground "Green" "Results:"
    Write-Host -Foreground "Green" "#$(($solutions | Where-Object -Property "complexity" -EQ 'Easy').Count) easy problems processed"
    Write-Host -Foreground "Green" "#$(($solutions | Where-Object -Property "complexity" -EQ 'Medium').Count) medium problems processed"
    Write-Host -Foreground "Green" "#$(($solutions | Where-Object -Property "complexity" -EQ 'Hard').Count) hard problems processed"
    Write-Host -Foreground "Green" "______________________"
    Write-Host -Foreground "Green" "#$($solutions.Count) total"
}

function RenderSection {
     param(
        [Parameter (Mandatory = $true)] $readme,
        [Parameter (Mandatory = $true)] [String] $title,
        [Parameter (Mandatory = $true)] [array] $solutions
    )

    Add-Content -Path $readme -Value "`n<details>"
    Add-Content -Path $readme -Value "<summary><b>$($title)  #$($solutions.Count)</b></summary>"
    Add-Content -Path $readme -Value "`n|Problem|Runtime(%)|Memory(%)|"
    Add-Content -Path $readme -Value "`|--|--|--|"
    foreach($solution in $solutions | Sort-Object @{e={$_.Id -as [int]}}) {
        $solution_path = ConvertToPath $solution.name $solution.complexity
        if (-not(Test-Path $solution_path)) {
            Write-Host -Foreground "Red" "Invalid solution path for task #$($solution.Id) $($solution_path)"
        }

        Add-Content -Path $readme -Value "|$($solution.Id). [$($solution.name)](/$($solution_path))| $($solution.runtime) | $($solution.memory) |"
    }
    Add-Content -Path $readme -Value "`n</details>"
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