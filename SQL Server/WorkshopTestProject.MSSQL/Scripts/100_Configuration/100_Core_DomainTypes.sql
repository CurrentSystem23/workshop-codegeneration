/* core.DomainTypes hinzufügen */
SET IDENTITY_INSERT [core].[DomainType] ON;
MERGE INTO [core].[DomainType] AS Target 
USING (VALUES 
(2, 'Personentypen', 'Klassifikation von Geschäftspartnern (Person oder Firma)', 'C', NULL, 0),
(3, 'Anreden', 'Klassifikation von Anreden', 'C', 12, 0),
(4, 'Titel', 'Klassifikation von Titeln', 'C', 13, 0),
(63, 'Userstatus der Core.User Tabelle', '', 'N', 376, 0)
) 
AS Source (DovTypId, Type, Description, Mode, StandardId, Editable) 
ON Target.Id = Source.DovTypId 
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Id]
        ,[ModifiedDate]
        ,[ModifiedUser]
        ,[Type]
        ,[Description]
        ,[Mode]
        ,[StandardId]
        ,[Editable])
      VALUES
        (DovTypId
        ,'2021-11-19 00:00:00.0000'
        ,1
        ,Source.Type
        ,Source.Description
        ,Source.Mode
        ,Source.StandardId
        ,Source.Editable)
WHEN MATCHED THEN 
    UPDATE 
        SET [ModifiedDate] = '2021-11-19 00:00:00.0000'
          ,[ModifiedUser] = 1
          ,[Type] = Source.Type
          ,[Description] = Source.Description
          ,[Mode] = Source.Mode
          ,[StandardId] = Source.StandardId
          ,[Editable] = Source.Editable;
SET IDENTITY_INSERT [core].[DomainType] OFF;