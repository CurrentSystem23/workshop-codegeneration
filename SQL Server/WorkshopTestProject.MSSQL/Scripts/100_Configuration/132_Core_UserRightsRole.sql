/* core.UserRightsRole hinzufügen */
SET IDENTITY_INSERT [core].[UserRightsRole] ON;
MERGE INTO [core].[UserRightsRole] AS Target 
USING (VALUES 
(1, 'SystemAdministrator', 'enthält alle Rechte'),
(2, 'RightsManager', 'verwaltet Nutzerrollen- und Gruppen'),
(3, 'ContentManager', 'verwaltet Kursinhalte'),
(4, 'SeminarCoordinator', 'verwaltet Seminare'),
(5, 'SeminarTrainer', 'führt Teile von Seminaren durch'),
(6, 'CompanyCoordinator', 'verwaltet Mitarbeiter einer Firma'),
(7, 'SeminarParticipant', 'nimmt an Seminaren teil')
) 
AS Source ([Id], [Role], [Description]) 
ON Target.Id = Source.Id 
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Id]
       ,[ModifiedDate]
       ,[ModifiedUser]
       ,[Role]
       ,[Description])
VALUES (Source.Id
        ,'2021-11-19 00:00:00.0000'
        ,1
        ,Source.[Role]
        ,Source.[Description])
WHEN MATCHED THEN 
    UPDATE 
        SET [ModifiedDate] = '2021-11-19 00:00:00.0000'
          ,[ModifiedUser] = 1
          ,[Role] = Source.[Role]
          ,[Description] = Source.[Description];
SET IDENTITY_INSERT [core].[UserRightsRole] OFF;