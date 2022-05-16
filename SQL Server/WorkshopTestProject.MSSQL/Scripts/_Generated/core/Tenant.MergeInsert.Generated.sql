  /* Include core.Tenant */
  SET IDENTITY_INSERT [core].[Tenant] ON;
  MERGE INTO [core].[Tenant] AS Target
  USING (VALUES
  (@Id, @ModifiedDate, @ModifiedUser, @TenantName, @Description)
  )
  AS Source ( [Id],[ModifiedDate],[ModifiedUser],[TenantName],[Description])
  ON Target.Id = Source.Id
  WHEN NOT MATCHED BY TARGET THEN
  INSERT (
           [Id]
          ,[ModifiedDate]
          ,[ModifiedUser]
          ,[TenantName]
          ,[Description]
         )
  VALUES (
          Source.[Id]
         ,Source.[ModifiedDate]
         ,Source.[ModifiedUser]
         ,Source.[TenantName]
         ,Source.[Description]
         )
  WHEN MATCHED THEN
  UPDATE
     SET [ModifiedDate] = Source.[ModifiedDate]
        ,[ModifiedUser] = Source.[ModifiedUser]
        ,[TenantName] = Source.[TenantName]
        ,[Description] = Source.[Description]
  ;
  SET IDENTITY_INSERT [core].[Tenant] OFF;

