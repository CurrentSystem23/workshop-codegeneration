/* core.Mandanten hinzufügen */
SET IDENTITY_INSERT [core].[Tenant] ON;
MERGE INTO [core].[Tenant] AS Target 
USING (VALUES 
(1, 'CurrentSystem 23 GmbH')
) 
AS Source (Id, TenantName) 
ON Target.Id = Source.Id 
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Id]
        ,[ModifiedDate]
        ,[ModifiedUser]
        ,[TenantName])
      VALUES
        (Id
        ,'2021-11-19 00:00:00.0000'
        ,1
        ,Source.TenantName)
WHEN MATCHED THEN 
    UPDATE 
        SET [ModifiedDate] = '2021-11-19 00:00:00.0000'
           ,[ModifiedUser] = 1
           ,[TenantName] = Source.TenantName;
SET IDENTITY_INSERT [core].[Tenant] OFF;
GO