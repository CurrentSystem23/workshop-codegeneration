@ECHO OFF

SET PROJECTDIR="%~dp0\..\.."

..\..\EntityGenerator3\EntityGenerator.exe --connection="Server=(localdb)\MSSQLLocalDB; Database=WorkshopTestProjectDb; Trusted_Connection=True;" --rootdir=%PROJECTDIR% --project=WorkshopTestProject --dataaccesstestmockpath="Test\Test.Unittests\Mocks" --generatedsuffix="Generated" --no-wipe --advanced --mssql --param-views --param-scalar --nunitdataaccessmocks

pause
EXIT