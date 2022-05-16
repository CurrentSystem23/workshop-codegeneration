CREATE FUNCTION [core].[GetInsertUpdateDeleteInformation]
(
  @UserID bigint,
  @TimeStamp datetime2
)
RETURNS varchar(max) WITH SCHEMABINDING
AS
BEGIN
  -- Declare the return variable here
  DECLARE @GPName varchar(max);
  DECLARE @RET varchar(max);
  DECLARE @DateTime varchar(max);

  IF (@TimeStamp IS NOT NULL) BEGIN
    SET @DateTime = CAST(DAY(@TimeStamp) AS VARCHAR(2)) + '.' + CAST(MONTH(@TimeStamp) AS VARCHAR(2)) + '.' + CAST(YEAR(@TimeStamp) AS VARCHAR(4)) + ' - ' + CAST(DATEPART(hour, @TimeStamp) AS VARCHAR(2)) + ':' + FORMAT(DATEPART(minute, @TimeStamp), '00') + ':' + FORMAT(DATEPART(second, @TimeStamp), '00');
  END

  -- Add the T-SQL statements to compute the return value here
  SELECT @GPName = usr.Email
  FROM [core].[User] AS usr
  WHERE usr.Id = @UserID;

  SET @RET = '';
  IF (@GPName IS NULL AND @TimeStamp IS NULL) BEGIN
    SET @RET = '';
  END  
  IF (@GPName IS NOT NULL AND @TimeStamp IS NULL) BEGIN
    SET @RET = @GPName;
  END
  IF (@GPName IS NULL AND @TimeStamp IS NOT NULL) BEGIN
    SET @RET = CAST(@DateTime AS VARCHAR);
  END
  IF (@GPName IS NOT NULL AND @TimeStamp IS NOT NULL) BEGIN
    SET @RET = CAST(@DateTime AS VARCHAR) + ' von: ' + @GPName;
  END

  RETURN @RET

END
GO