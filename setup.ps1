# Sets up the development environment

if (Test-Path -Path "./db") {
	Write-Output "Database folder already exists."
	Exit
}

Write-Output "Setting up Database folder."
New-Item -Path "./" -Name "db" -ItemType "directory" 