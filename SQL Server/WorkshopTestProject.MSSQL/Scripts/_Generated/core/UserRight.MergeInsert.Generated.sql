  /* Include core.UserRight */
  SET IDENTITY_INSERT [core].[UserRight] ON;
  MERGE INTO [core].[UserRight] AS Target
  USING (VALUES
  (@Id, @ModifiedDate, @ModifiedUser, @Right, @Description)
  )
  AS Source ( [Id],[ModifiedDate],[ModifiedUser],[Right],[Description])
  ON Target.Id = Source.Id
  WHEN NOT MATCHED BY TARGET THEN
  INSERT (
           [Id]
          ,[ModifiedDate]
          ,[ModifiedUser]
          ,[Right]
          ,[Description]
         )
  VALUES (
          Source.[Id]
         ,Source.[ModifiedDate]
         ,Source.[ModifiedUser]
         ,Source.[Right]
         ,Source.[Description]
         )
  WHEN MATCHED THEN
  UPDATE
     SET [ModifiedDate] = Source.[ModifiedDate]
        ,[ModifiedUser] = Source.[ModifiedUser]
        ,[Right] = Source.[Right]
        ,[Description] = Source.[Description]
  ;
  SET IDENTITY_INSERT [core].[UserRight] OFF;

