@ECHO OFF

SET PROJECTDIR="%~dp0\..\.."

..\..\EntityGenerator3\EntityGenerator.exe --connection="Server=(localdb)\MSSQLLocalDB; Database=WorkshopTestProjectDb; Trusted_Connection=True;" --rootdir=%PROJECTDIR% --project=WorkshopTestProject --frontend-dotnet-path="Frontend\DotNet\Client" --frontend-dotnet-projectname="Client" --generatedsuffix="Generated" --no-wipe --advanced --mssql --param-views --param-scalar --api-dotnet-sync

pause
EXIT