  /* Include core.DomainValue */
  SET IDENTITY_INSERT [core].[DomainValue] ON;
  MERGE INTO [core].[DomainValue] AS Target
  USING (VALUES
  (@Id, @ModifiedDate, @ModifiedUser, @TypeId, @ValueC, @ValueN, @ValueD, @ValueF, @DivId, @Description, @Unit, @TenantId)
  )
  AS Source ( [Id],[ModifiedDate],[ModifiedUser],[TypeId],[ValueC],[ValueN],[ValueD],[ValueF],[DivId],[Description],[Unit],[TenantId])
  ON Target.Id = Source.Id
  WHEN NOT MATCHED BY TARGET THEN
  INSERT (
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
         )
  VALUES (
          Source.[Id]
         ,Source.[ModifiedDate]
         ,Source.[ModifiedUser]
         ,Source.[TypeId]
         ,Source.[ValueC]
         ,Source.[ValueN]
         ,Source.[ValueD]
         ,Source.[ValueF]
         ,Source.[DivId]
         ,Source.[Description]
         ,Source.[Unit]
         ,Source.[TenantId]
         )
  WHEN MATCHED THEN
  UPDATE
     SET [ModifiedDate] = Source.[ModifiedDate]
        ,[ModifiedUser] = Source.[ModifiedUser]
        ,[TypeId] = Source.[TypeId]
        ,[ValueC] = Source.[ValueC]
        ,[ValueN] = Source.[ValueN]
        ,[ValueD] = Source.[ValueD]
        ,[ValueF] = Source.[ValueF]
        ,[DivId] = Source.[DivId]
        ,[Description] = Source.[Description]
        ,[Unit] = Source.[Unit]
        ,[TenantId] = Source.[TenantId]
  ;
  SET IDENTITY_INSERT [core].[DomainValue] OFF;

