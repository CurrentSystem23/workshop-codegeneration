@ECHO OFF

SET PROJECTDIR="%~dp0\..\.."

..\..\EntityGenerator3\EntityGenerator.exe --connection="Server=(localdb)\MSSQLLocalDB; Database=WorkshopTestProjectDb; Trusted_Connection=True;" --rootdir=%PROJECTDIR% --project=WorkshopTestProject --commonpath="Common\Common" --dataaccesspath="Data Access Layer\DataAccess" --sqlpath="SQL Server\WorkshopTestProject.MSSQL" --dataaccesstestmockpath="Test\Test.Unittests\Mocks" --apipath="Presentation Layer\API" --frontend-angular-path="Frontend\Angular\Client\src\app" --frontend-dotnet-path="Frontend\DotNet\Client" --generatedsuffix="Generated" --no-wipe --advanced --mssql --hist --trigger --const --mergeinsert --dtos --syncdaos --asyncdaos --const --param-views --param-scalar --interface-converters --nunitdataaccessmocks --logic --typescript --api-angular --api-dotnet-sync --frontend-dotnet-projectname="Client"
pause
EXIT