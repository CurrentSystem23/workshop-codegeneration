@ECHO OFF

SET PROJECTDIR="%~dp0\..\.."

..\..\EntityGenerator3\EntityGenerator.exe --connection="Server=(localdb)\MSSQLLocalDB; Database=WorkshopTestProjectDb; Trusted_Connection=True;" --rootdir=%PROJECTDIR% --project=WorkshopTestProject --commonpath="Common\Common" --dataaccesspath="Data Access Layer\DataAccess" --commonpath="Common\Common" --dataaccesspath="Data Access Layer\DataAccess" --sqlpath="SQL Server\WorkshopTestProject.MSSQL" --generatedsuffix="Generated" --no-wipe --advanced --mssql --dtos --const --param-views --param-scalar --asyncdaos --syncdaos

pause
EXIT