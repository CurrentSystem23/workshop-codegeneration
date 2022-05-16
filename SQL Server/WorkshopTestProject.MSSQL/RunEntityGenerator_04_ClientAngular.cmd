@ECHO OFF

SET PROJECTDIR="%~dp0\..\.."

..\..\EntityGenerator3\EntityGenerator.exe --connection="Server=(localdb)\MSSQLLocalDB; Database=WorkshopTestProjectDb; Trusted_Connection=True;" --rootdir=%PROJECTDIR% --project=WorkshopTestProject --frontend-angular-path="Frontend\Angular\Client\src" --generatedsuffix="Generated" --no-wipe --advanced --mssql --param-views --param-scalar --typescript --api-angular

pause
EXIT