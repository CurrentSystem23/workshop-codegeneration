CREATE TRIGGER [core].[DomainValue_HistTrigger]
  ON [core].[DomainValue]
  FOR DELETE, INSERT, UPDATE
  AS
  BEGIN
    SET NOCOUNT ON
	  DECLARE @Action  NVARCHAR (50)

    --delete old temp table
    IF OBJECT_ID('tempdb..#tmpTbl') IS NOT NULL DROP TABLE #tmpTbl

	-- insert affected rows from inserted table
	select * into #tmpTbl from (SELECT * FROM (SELECT * FROM inserted) AS A
					  							      ) AS T

	SET IDENTITY_INSERT [core].[DomainValue] OFF
	SET IDENTITY_INSERT #tmpTbl ON

    --update
    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
    BEGIN
      SET @Action = 'U'
    END

    --insert
    IF EXISTS (SELECT * FROM inserted) AND NOT EXISTS(SELECT * FROM deleted)
    BEGIN
      SET @Action = 'I'
    END

    --delete
    IF EXISTS (SELECT * FROM deleted) AND NOT EXISTS(SELECT * FROM inserted)
    BEGIN
      SET @Action = 'D'
      -- insert affected rows from deleted table
	    INSERT INTO #tmpTbl (
             [Id]
            ,[ModifiedDate]
            ,[ModifiedUser]
            ,[TypeId]
            ,[ValueC]
            ,[ValueN]
            ,[ValueD]
            ,[ValueF]
            ,[DivId]
            ,[Description]
            ,[Unit]
            ,[TenantId]
              ) SELECT
             [Id]
            ,[ModifiedDate]
            ,[ModifiedUser]
            ,[TypeId]
            ,[ValueC]
            ,[ValueN]
            ,[ValueD]
            ,[ValueF]
            ,[DivId]
            ,[Description]
            ,[Unit]
            ,[TenantId]
        FROM deleted;
    END

    SET IDENTITY_INSERT #tmpTbl OFF
	SET IDENTITY_INSERT [core].[DomainValue] ON

    IF EXISTS(SELECT * FROM #tmpTbl)
      INSERT [core].[DomainValue_Hist](
             [Hist_Action]
             ,[Hist_Date]
            ,[Id]
            ,[ModifiedDate]
            ,[ModifiedUser]
            ,[TypeId]
            ,[ValueC]
            ,[ValueN]
            ,[ValueD]
            ,[ValueF]
            ,[DivId]
            ,[Description]
            ,[Unit]
            ,[TenantId]
             )
      SELECT  @Action
              ,SYSUTCDATETIME()
              ,[Id]
              ,[ModifiedDate]
              ,[ModifiedUser]
              ,[TypeId]
              ,[ValueC]
              ,[ValueN]
              ,[ValueD]
              ,[ValueF]
              ,[DivId]
              ,[Description]
              ,[Unit]
              ,[TenantId]
      FROM #tmpTbl

    --delete temp table
	IF OBJECT_ID('tempdb..#tmpTbl') IS NOT NULL DROP TABLE #tmpTbl
    SET NOCOUNT OFF
END


