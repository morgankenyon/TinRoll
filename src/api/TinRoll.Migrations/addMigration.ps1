$migrationName = Read-Host -Prompt 'Migration Name:'
dotnet ef migrations add $migrationName -s ..\TinRoll.Api\ -c TinRollContext -v