@ECHO OFF

SET PROJECTDIR="%~dp0\..\.."

..\..\EntityGenerator3\EntityGenerator.exe --connection="Server=(localdb)\MSSQLLocalDB; Database=WorkshopTestProjectDb; Trusted_Connection=True;" --rootdir=%PROJECTDIR% --project=WorkshopTestProject --sqlpath="SQL Server\WorkshopTestProject.MSSQL" --apipath="Presentation Layer/API" --commonpath="Common\Common" --generatedsuffix="Generated" --no-wipe --advanced --mssql --param-views --param-scalar --asyncdaos --syncdaos --const --api-server --userrights

pause
EXIT