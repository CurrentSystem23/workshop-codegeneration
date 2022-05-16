CREATE TABLE [core].[User_Hist]
(
     [Hist_Id]   BIGINT IDENTITY (1, 1) NOT NULL CONSTRAINT [pkUser_Hist_Id] PRIMARY KEY CLUSTERED ([Hist_Id] DESC) WITH (ALLOW_PAGE_LOCKS = OFF)
    ,[Hist_Action]   CHAR(1)         NOT NULL
    ,[Hist_Date]     DATETIME2       NOT NULL
    ,[Id]   bigint   NULL
    ,[ModifiedDate]   datetime2   NULL
    ,[ModifiedUser]   bigint   NULL
    ,[TenantId]   bigint   NULL
    ,[Login]   nvarchar(255)   NULL
    ,[Password]   nvarchar(255)   NULL
    ,[PasswordSalt]   nvarchar(255)   NULL
    ,[Email]   nvarchar(800)   NULL
    ,[State]   bigint   NULL
    ,[FailedLoginCount]   bigint   NULL
    ,[LastLogin]   datetime2   NULL
    ,[LastPasswordChange]   datetime2   NULL
    ,[DomainLogin]   nvarchar(60)   NULL
    ,[BusinessPartnerId]   bigint   NULL
    ,[ConditionsId]   bigint   NULL
    ,[ConditionsFixed]   bigint   NULL
    ,[PrivacyPolicyId]   bigint   NULL
    ,[PrivacyPolicyFixed]   bigint   NULL
    ,[PasswordLinkExtension]   uniqueidentifier   NULL
    ,[PasswordDateOfExpiry]   datetime2   NULL
    ,[NewEmail]   nvarchar(800)   NULL
    ,[EmailLinkExtension]   uniqueidentifier   NULL
    ,[EmailDateOfExpiry]   datetime2   NULL
)
GO
CREATE NONCLUSTERED INDEX [ndx_core_User_Hist_UserId] ON [core].[User_Hist]
(
	[Id] ASC
)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


