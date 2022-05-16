@ECHO OFF

@RMDIR /S /Q .\Scripts\_Generated\
@RMDIR /S /Q .\Tables\_Generated\
@RMDIR /S /Q .\Triggers\_Generated\

@RMDIR /S /Q "..\..\Frontend\Angular\Lenny\src\app\constants\_Generated\"
@RMDIR /S /Q "..\..\Frontend\Angular\Lenny\src\app\viewmodels\_Generated\"

@RMDIR /S /Q "..\..\Data Access Layer\DataAccess\_Generated\"
@RMDIR /S /Q "..\..\Data Access Layer\DataAccess.SQL\_Generated\"

@RMDIR /S /Q "..\..\Common\Common\_Generated\"
@RMDIR /S /Q "..\..\Common\Common.DataAccess\Interfaces\Ado\_Generated\"
@RMDIR /S /Q "..\..\Common\Common.Presentation\_Generated\"

@RMDIR /S /Q "..\..\Business Logic Layer\BusinessLogic\_Generated\"

pause
EXIT