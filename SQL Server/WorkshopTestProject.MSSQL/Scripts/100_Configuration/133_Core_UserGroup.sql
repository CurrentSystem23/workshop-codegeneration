/* core.UserGroup hinzufügen */
SET IDENTITY_INSERT [core].[UserGroup] ON;
MERGE INTO [core].[UserGroup] AS Target 
USING (VALUES 
(1, 'SystemAdministrator', 'enthält alle Rechte'),
(2, 'RightsManager', 'verwaltet Nutzerrollen- und Gruppen'),
(3, 'ContentManager', 'verwaltet Kursinhalte'),
(4, 'SeminarCoordinator', 'verwaltet Seminare'),
(5, 'SeminarTrainer', 'führt Teile von Seminaren durch'),
(6, 'CompanyCoordinator', 'verwaltet Mitarbeiter einer Firma'),
(7, 'SeminarParticipant', 'nimmt an Seminaren teil')
) 
AS Source ([Id], [Group], [Description]) 
ON Target.Id = Source.Id 
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Id]
       ,[ModifiedDate]
       ,[ModifiedUser]
       ,[Group]
       ,[Description])
VALUES (Source.Id
        ,'2021-11-19 00:00:00.0000'
        ,1
        ,Source.[Group]
        ,Source.[Description])
WHEN MATCHED THEN 
    UPDATE 
        SET [ModifiedDate] = '2021-11-19 00:00:00.0000'
          ,[ModifiedUser] = 1
          ,[Group] = Source.[Group]
          ,[Description] = Source.[Description];
SET IDENTITY_INSERT [core].[UserGroup] OFF;