  /* Include core.User */
  SET IDENTITY_INSERT [core].[User] ON;
  MERGE INTO [core].[User] AS Target
  USING (VALUES
  (@Id, @ModifiedDate, @ModifiedUser, @TenantId, @Login, @Password, @PasswordSalt, @Email, @State, @FailedLoginCount, @LastLogin, @LastPasswordChange, @DomainLogin, @BusinessPartnerId, @ConditionsId, @ConditionsFixed, @PrivacyPolicyId, @PrivacyPolicyFixed, @PasswordLinkExtension, @PasswordDateOfExpiry, @NewEmail, @EmailLinkExtension, @EmailDateOfExpiry)
  )
  AS Source ( [Id],[ModifiedDate],[ModifiedUser],[TenantId],[Login],[Password],[PasswordSalt],[Email],[State],[FailedLoginCount],[LastLogin],[LastPasswordChange],[DomainLogin],[BusinessPartnerId],[ConditionsId],[ConditionsFixed],[PrivacyPolicyId],[PrivacyPolicyFixed],[PasswordLinkExtension],[PasswordDateOfExpiry],[NewEmail],[EmailLinkExtension],[EmailDateOfExpiry])
  ON Target.Id = Source.Id
  WHEN NOT MATCHED BY TARGET THEN
  INSERT (
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
         )
  VALUES (
          Source.[Id]
         ,Source.[ModifiedDate]
         ,Source.[ModifiedUser]
         ,Source.[TenantId]
         ,Source.[Login]
         ,Source.[Password]
         ,Source.[PasswordSalt]
         ,Source.[Email]
         ,Source.[State]
         ,Source.[FailedLoginCount]
         ,Source.[LastLogin]
         ,Source.[LastPasswordChange]
         ,Source.[DomainLogin]
         ,Source.[BusinessPartnerId]
         ,Source.[ConditionsId]
         ,Source.[ConditionsFixed]
         ,Source.[PrivacyPolicyId]
         ,Source.[PrivacyPolicyFixed]
         ,Source.[PasswordLinkExtension]
         ,Source.[PasswordDateOfExpiry]
         ,Source.[NewEmail]
         ,Source.[EmailLinkExtension]
         ,Source.[EmailDateOfExpiry]
         )
  WHEN MATCHED THEN
  UPDATE
     SET [ModifiedDate] = Source.[ModifiedDate]
        ,[ModifiedUser] = Source.[ModifiedUser]
        ,[TenantId] = Source.[TenantId]
        ,[Login] = Source.[Login]
        ,[Password] = Source.[Password]
        ,[PasswordSalt] = Source.[PasswordSalt]
        ,[Email] = Source.[Email]
        ,[State] = Source.[State]
        ,[FailedLoginCount] = Source.[FailedLoginCount]
        ,[LastLogin] = Source.[LastLogin]
        ,[LastPasswordChange] = Source.[LastPasswordChange]
        ,[DomainLogin] = Source.[DomainLogin]
        ,[BusinessPartnerId] = Source.[BusinessPartnerId]
        ,[ConditionsId] = Source.[ConditionsId]
        ,[ConditionsFixed] = Source.[ConditionsFixed]
        ,[PrivacyPolicyId] = Source.[PrivacyPolicyId]
        ,[PrivacyPolicyFixed] = Source.[PrivacyPolicyFixed]
        ,[PasswordLinkExtension] = Source.[PasswordLinkExtension]
        ,[PasswordDateOfExpiry] = Source.[PasswordDateOfExpiry]
        ,[NewEmail] = Source.[NewEmail]
        ,[EmailLinkExtension] = Source.[EmailLinkExtension]
        ,[EmailDateOfExpiry] = Source.[EmailDateOfExpiry]
  ;
  SET IDENTITY_INSERT [core].[User] OFF;

