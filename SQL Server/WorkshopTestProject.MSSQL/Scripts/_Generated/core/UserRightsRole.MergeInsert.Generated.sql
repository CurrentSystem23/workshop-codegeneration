  /* Include core.UserRightsRole */
  SET IDENTITY_INSERT [core].[UserRightsRole] ON;
  MERGE INTO [core].[UserRightsRole] AS Target
  USING (VALUES
  (@Id, @ModifiedDate, @ModifiedUser, @Role, @Description)
  )
  AS Source ( [Id],[ModifiedDate],[ModifiedUser],[Role],[Description])
  ON Target.Id = Source.Id
  WHEN NOT MATCHED BY TARGET THEN
  INSERT (
           [Id]
          ,[ModifiedDate]
          ,[ModifiedUser]
          ,[Role]
          ,[Description]
         )
  VALUES (
          Source.[Id]
         ,Source.[ModifiedDate]
         ,Source.[ModifiedUser]
         ,Source.[Role]
         ,Source.[Description]
         )
  WHEN MATCHED THEN
  UPDATE
     SET [ModifiedDate] = Source.[ModifiedDate]
        ,[ModifiedUser] = Source.[ModifiedUser]
        ,[Role] = Source.[Role]
        ,[Description] = Source.[Description]
  ;
  SET IDENTITY_INSERT [core].[UserRightsRole] OFF;

