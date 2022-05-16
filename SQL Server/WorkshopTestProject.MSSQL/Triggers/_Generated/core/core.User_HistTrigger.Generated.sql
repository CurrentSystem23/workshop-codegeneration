CREATE TRIGGER [core].[User_HistTrigger]
  ON [core].[User]
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

	SET IDENTITY_INSERT [core].[User] OFF
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
            ,[TenantId]
            ,[Login]
            ,[Password]
            ,[PasswordSalt]
            ,[Email]
            ,[State]
            ,[FailedLoginCount]
            ,[LastLogin]
            ,[LastPasswordChange]
            ,[DomainLogin]
            ,[BusinessPartnerId]
            ,[ConditionsId]
            ,[ConditionsFixed]
            ,[PrivacyPolicyId]
            ,[PrivacyPolicyFixed]
            ,[PasswordLinkExtension]
            ,[PasswordDateOfExpiry]
            ,[NewEmail]
            ,[EmailLinkExtension]
            ,[EmailDateOfExpiry]
              ) SELECT
             [Id]
            ,[ModifiedDate]
            ,[ModifiedUser]
            ,[TenantId]
            ,[Login]
            ,[Password]
            ,[PasswordSalt]
            ,[Email]
            ,[State]
            ,[FailedLoginCount]
            ,[LastLogin]
            ,[LastPasswordChange]
            ,[DomainLogin]
            ,[BusinessPartnerId]
            ,[ConditionsId]
            ,[ConditionsFixed]
            ,[PrivacyPolicyId]
            ,[PrivacyPolicyFixed]
            ,[PasswordLinkExtension]
            ,[PasswordDateOfExpiry]
            ,[NewEmail]
            ,[EmailLinkExtension]
            ,[EmailDateOfExpiry]
        FROM deleted;
    END

    SET IDENTITY_INSERT #tmpTbl OFF
	SET IDENTITY_INSERT [core].[User] ON

    IF EXISTS(SELECT * FROM #tmpTbl)
      INSERT [core].[User_Hist](
             [Hist_Action]
             ,[Hist_Date]
            ,[Id]
            ,[ModifiedDate]
            ,[ModifiedUser]
            ,[TenantId]
            ,[Login]
            ,[Password]
            ,[PasswordSalt]
            ,[Email]
            ,[State]
            ,[FailedLoginCount]
            ,[LastLogin]
            ,[LastPasswordChange]
            ,[DomainLogin]
            ,[BusinessPartnerId]
            ,[ConditionsId]
            ,[ConditionsFixed]
            ,[PrivacyPolicyId]
            ,[PrivacyPolicyFixed]
            ,[PasswordLinkExtension]
            ,[PasswordDateOfExpiry]
            ,[NewEmail]
            ,[EmailLinkExtension]
            ,[EmailDateOfExpiry]
             )
      SELECT  @Action
              ,SYSUTCDATETIME()
              ,[Id]
              ,[ModifiedDate]
              ,[ModifiedUser]
              ,[TenantId]
              ,[Login]
              ,[Password]
              ,[PasswordSalt]
              ,[Email]
              ,[State]
              ,[FailedLoginCount]
              ,[LastLogin]
              ,[LastPasswordChange]
              ,[DomainLogin]
              ,[BusinessPartnerId]
              ,[ConditionsId]
              ,[ConditionsFixed]
              ,[PrivacyPolicyId]
              ,[PrivacyPolicyFixed]
              ,[PasswordLinkExtension]
              ,[PasswordDateOfExpiry]
              ,[NewEmail]
              ,[EmailLinkExtension]
              ,[EmailDateOfExpiry]
      FROM #tmpTbl

    --delete temp table
	IF OBJECT_ID('tempdb..#tmpTbl') IS NOT NULL DROP TABLE #tmpTbl
    SET NOCOUNT OFF
END


