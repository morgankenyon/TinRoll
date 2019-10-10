$migrationName = Read-Host -Prompt 'Migration Name:'
dotnet ef database update $migrationname -s ..\TinRoll.Api\ -v