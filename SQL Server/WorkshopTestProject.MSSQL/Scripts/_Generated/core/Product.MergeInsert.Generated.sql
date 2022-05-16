  /* Include core.Product */
  SET IDENTITY_INSERT [core].[Product] ON;
  MERGE INTO [core].[Product] AS Target
  USING (VALUES
  (@Id, @ModifiedDate, @ModifiedUser, @ProductName, @Price)
  )
  AS Source ( [Id],[ModifiedDate],[ModifiedUser],[ProductName],[Price])
  ON Target.Id = Source.Id
  WHEN NOT MATCHED BY TARGET THEN
  INSERT (
           [Id]
          ,[ModifiedDate]
          ,[ModifiedUser]
          ,[ProductName]
          ,[Price]
         )
  VALUES (
          Source.[Id]
         ,Source.[ModifiedDate]
         ,Source.[ModifiedUser]
         ,Source.[ProductName]
         ,Source.[Price]
         )
  WHEN MATCHED THEN
  UPDATE
     SET [ModifiedDate] = Source.[ModifiedDate]
        ,[ModifiedUser] = Source.[ModifiedUser]
        ,[ProductName] = Source.[ProductName]
        ,[Price] = Source.[Price]
  ;
  SET IDENTITY_INSERT [core].[Product] OFF;

