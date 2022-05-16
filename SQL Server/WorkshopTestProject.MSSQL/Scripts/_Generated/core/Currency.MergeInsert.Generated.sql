  /* Include core.Currency */
  SET IDENTITY_INSERT [core].[Currency] ON;
  MERGE INTO [core].[Currency] AS Target
  USING (VALUES
  (@Id, @ModifiedDate, @ModifiedUser, @Iso, @Currency, @CurrencyParts, @Region)
  )
  AS Source ( [Id],[ModifiedDate],[ModifiedUser],[Iso],[Currency],[CurrencyParts],[Region])
  ON Target.Id = Source.Id
  WHEN NOT MATCHED BY TARGET THEN
  INSERT (
           [Id]
          ,[ModifiedDate]
          ,[ModifiedUser]
          ,[Iso]
          ,[Currency]
          ,[CurrencyParts]
          ,[Region]
         )
  VALUES (
          Source.[Id]
         ,Source.[ModifiedDate]
         ,Source.[ModifiedUser]
         ,Source.[Iso]
         ,Source.[Currency]
         ,Source.[CurrencyParts]
         ,Source.[Region]
         )
  WHEN MATCHED THEN
  UPDATE
     SET [ModifiedDate] = Source.[ModifiedDate]
        ,[ModifiedUser] = Source.[ModifiedUser]
        ,[Iso] = Source.[Iso]
        ,[Currency] = Source.[Currency]
        ,[CurrencyParts] = Source.[CurrencyParts]
        ,[Region] = Source.[Region]
  ;
  SET IDENTITY_INSERT [core].[Currency] OFF;

