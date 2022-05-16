/* core.User hinzufügen */
SET IDENTITY_INSERT [core].[User] ON;
MERGE INTO [core].[User] AS Target 
USING (VALUES 
(1, 'SYSTEM', '', '', '', '', 374, 0, NULL, NULL, '', 1, 0, 0, 0, 0, 1)
) 
AS Source (Id, Login, Password, PasswordSalt, PasswordPepper, Email, State, FailedLoginCount, LastLogin, LastPasswordChange, DomainLogin, BusinessPartnerId, ConditionsId, ConditionsFixed, PrivacyPolicyId, PrivacyPolicyFixed, TenantId) 
ON Target.Id = Source.Id 
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Id]
       ,[ModifiedDate]
       ,[ModifiedUser]
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
       ,[TenantId])
VALUES (Source.Id
        ,'2021-11-19 00:00:00.0000'
        ,1
        ,Source.Login
        ,Source.Password
        ,Source.PasswordSalt
        ,Source.Email
        ,Source.State
        ,Source.FailedLoginCount
        ,Source.LastLogin
        ,Source.LastPasswordChange
        ,Source.DomainLogin
        ,Source.BusinessPartnerId
        ,Source.ConditionsId
        ,Source.ConditionsFixed
        ,Source.PrivacyPolicyId
        ,Source.PrivacyPolicyFixed
        ,Source.TenantId        )
WHEN MATCHED THEN 
    UPDATE 
        SET [ModifiedDate] = '2021-11-19 00:00:00.0000'
          ,[ModifiedUser] = 1
          ,[Login] = Source.Login
          ,[Password] = Source.Password
          ,[PasswordSalt] = Source.PasswordSalt
          ,[Email] = Source.Email
          ,[State] = Source.State
          ,[FailedLoginCount] = Source.FailedLoginCount
          ,[LastLogin] = Source.LastLogin
          ,[LastPasswordChange] = Source.LastPasswordChange
          ,[DomainLogin] = Source.DomainLogin
          ,[BusinessPartnerId] = Source.BusinessPartnerId
          ,[ConditionsId] = Source.ConditionsId
          ,[ConditionsFixed] = Source.ConditionsFixed
          ,[PrivacyPolicyId] = Source.PrivacyPolicyId
          ,[PrivacyPolicyFixed] = Source.PrivacyPolicyFixed
          ,[TenantId] = Source.TenantId;
SET IDENTITY_INSERT [core].[User] OFF;