  /* Include core.UserGroup */
  SET IDENTITY_INSERT [core].[UserGroup] ON;
  MERGE INTO [core].[UserGroup] AS Target
  USING (VALUES
  (@Id, @ModifiedDate, @ModifiedUser, @Group, @Description)
  )
  AS Source ( [Id],[ModifiedDate],[ModifiedUser],[Group],[Description])
  ON Target.Id = Source.Id
  WHEN NOT MATCHED BY TARGET THEN
  INSERT (
           [Id]
          ,[ModifiedDate]
          ,[ModifiedUser]
          ,[Group]
          ,[Description]
         )
  VALUES (
          Source.[Id]
         ,Source.[ModifiedDate]
         ,Source.[ModifiedUser]
         ,Source.[Group]
         ,Source.[Description]
         )
  WHEN MATCHED THEN
  UPDATE
     SET [ModifiedDate] = Source.[ModifiedDate]
        ,[ModifiedUser] = Source.[ModifiedUser]
        ,[Group] = Source.[Group]
        ,[Description] = Source.[Description]
  ;
  SET IDENTITY_INSERT [core].[UserGroup] OFF;

