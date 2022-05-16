  /* Include core.Stock */
  SET IDENTITY_INSERT [core].[Stock] ON;
  MERGE INTO [core].[Stock] AS Target
  USING (VALUES
  (@Id, @ModifiedDate, @ModifiedUser, @ProductId, @Quantity)
  )
  AS Source ( [Id],[ModifiedDate],[ModifiedUser],[ProductId],[Quantity])
  ON Target.Id = Source.Id
  WHEN NOT MATCHED BY TARGET THEN
  INSERT (
           [Id]
          ,[ModifiedDate]
          ,[ModifiedUser]
          ,[ProductId]
          ,[Quantity]
         )
  VALUES (
          Source.[Id]
         ,Source.[ModifiedDate]
         ,Source.[ModifiedUser]
         ,Source.[ProductId]
         ,Source.[Quantity]
         )
  WHEN MATCHED THEN
  UPDATE
     SET [ModifiedDate] = Source.[ModifiedDate]
        ,[ModifiedUser] = Source.[ModifiedUser]
        ,[ProductId] = Source.[ProductId]
        ,[Quantity] = Source.[Quantity]
  ;
  SET IDENTITY_INSERT [core].[Stock] OFF;

