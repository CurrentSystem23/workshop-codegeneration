  /* Include core.Country */
  SET IDENTITY_INSERT [core].[Country] ON;
  MERGE INTO [core].[Country] AS Target
  USING (VALUES
  (@Id, @ModifiedDate, @ModifiedUser, @Country, @CountryKey, @CurrencyId)
  )
  AS Source ( [Id],[ModifiedDate],[ModifiedUser],[Country],[CountryKey],[CurrencyId])
  ON Target.Id = Source.Id
  WHEN NOT MATCHED BY TARGET THEN
  INSERT (
           [Id]
          ,[ModifiedDate]
          ,[ModifiedUser]
          ,[Country]
          ,[CountryKey]
          ,[CurrencyId]
         )
  VALUES (
          Source.[Id]
         ,Source.[ModifiedDate]
         ,Source.[ModifiedUser]
         ,Source.[Country]
         ,Source.[CountryKey]
         ,Source.[CurrencyId]
         )
  WHEN MATCHED THEN
  UPDATE
     SET [ModifiedDate] = Source.[ModifiedDate]
        ,[ModifiedUser] = Source.[ModifiedUser]
        ,[Country] = Source.[Country]
        ,[CountryKey] = Source.[CountryKey]
        ,[CurrencyId] = Source.[CurrencyId]
  ;
  SET IDENTITY_INSERT [core].[Country] OFF;

