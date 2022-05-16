  /* Include core.DomainType */
  SET IDENTITY_INSERT [core].[DomainType] ON;
  MERGE INTO [core].[DomainType] AS Target
  USING (VALUES
  (@Id, @ModifiedDate, @ModifiedUser, @Type, @Description, @Mode, @StandardId, @Editable)
  )
  AS Source ( [Id],[ModifiedDate],[ModifiedUser],[Type],[Description],[Mode],[StandardId],[Editable])
  ON Target.Id = Source.Id
  WHEN NOT MATCHED BY TARGET THEN
  INSERT (
           [Id]
          ,[ModifiedDate]
          ,[ModifiedUser]
          ,[Type]
          ,[Description]
          ,[Mode]
          ,[StandardId]
          ,[Editable]
         )
  VALUES (
          Source.[Id]
         ,Source.[ModifiedDate]
         ,Source.[ModifiedUser]
         ,Source.[Type]
         ,Source.[Description]
         ,Source.[Mode]
         ,Source.[StandardId]
         ,Source.[Editable]
         )
  WHEN MATCHED THEN
  UPDATE
     SET [ModifiedDate] = Source.[ModifiedDate]
        ,[ModifiedUser] = Source.[ModifiedUser]
        ,[Type] = Source.[Type]
        ,[Description] = Source.[Description]
        ,[Mode] = Source.[Mode]
        ,[StandardId] = Source.[StandardId]
        ,[Editable] = Source.[Editable]
  ;
  SET IDENTITY_INSERT [core].[DomainType] OFF;

