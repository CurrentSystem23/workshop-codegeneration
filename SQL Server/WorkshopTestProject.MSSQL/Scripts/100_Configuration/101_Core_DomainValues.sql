/* core.DomainValues hinzufügen */
SET IDENTITY_INSERT [core].[DomainValue] ON;
MERGE INTO [core].[DomainValue] AS Target 
USING (VALUES 
(5, 2, 'Person', NULL, NULL, 'Person', 'Es handelt sich um eine natürliche Person!', NULL, 1),
(6, 2, 'Firma', NULL, NULL, 'Firma', 'Es handelt sich um eine Firma (juristische Person)!', NULL, 1),
(7, 2, 'System', NULL, NULL, 'System', 'Es handelt sich um den Systemuser (SysAdmin)!', NULL, 1),
(8, 3, 'Herr', 1, NULL, 'Herr', 'Anrede Herr', NULL, 1),
(9, 3, 'Frau', 2, NULL, 'Frau', 'Anrede Frau', NULL, 1),
(10, 3, 'Familie', 3, NULL, 'Familie', 'Anrede Familie', NULL, 1),
(11, 3, 'Firma', 4, NULL, 'Firma', 'Anrede Firma', NULL, 1),
(12, 3, 'ohne Anrede', 5, NULL, '', 'ohne Anrede', NULL, 1),
(13, 4, 'kein akademischer Titel', 0, NULL, '', 'kein akademischer Titel', NULL, 1),
(14, 4, 'Bachelor', 1, NULL, 'Bachelor', 'akademischer Titel Bachelor', NULL, 1),
(15, 4, 'Master', 2, NULL, 'Master', 'akademischer Titel Master', NULL, 1),
(22, 4, 'Dr.', 9, NULL, 'Dr.', 'akademischer Titel Dr.', NULL, 1),
(23, 4, 'Dr. Dr.', 10, NULL, 'Dr. Dr.', 'akademischer Titel Dr. Dr.', NULL, 1),
(24, 4, 'Dr. habil.', 11, NULL, 'Dr. habil.', 'akademischer Titel Dr. habil.', NULL, 1),
(25, 4, 'Privatdozent', 12, NULL, 'Privatdozent', 'akademischer Titel Dr. PD (habilitiert)', NULL, 1),
(26, 4, 'Prof.', 13, NULL, 'Prof.', 'akademischer Titel Professor', NULL, 1),
(27, 4, 'Prof. Dr.', 14, NULL, 'Prof. Dr.', 'akademischer Titel Prof. Dr.', NULL, 1),
(374, 63, 'Systemuser', NULL, NULL, '', '', NULL, 1),
(375, 63, 'Inaktiv', NULL, NULL, '', '', NULL, 1),
(376, 63, 'Aktiv', NULL, NULL, '', '', NULL, 1),
(377, 63, 'Gesperrt', NULL, NULL, '', '', NULL, 1)
)
AS Source (DovId, TypeId, ValueC, ValueN, ValueF, DivId, Description, Unit, TenantId) 
ON Target.Id = Source.DovId 
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Id]
        ,[ModifiedDate]
        ,[ModifiedUser]
        ,[TypeId]
        ,[ValueC]
        ,[ValueN]
        ,[ValueF]
        ,[DivId]
        ,[Description]
        ,[Unit]
        ,[TenantId])
VALUES (DovId
        ,'2021-11-19 00:00:00.0000'
        ,1
        ,Source.TypeId
        ,Source.ValueC
        ,Source.ValueN
        ,Source.ValueF
        ,Source.DivId
        ,Source.Description
        ,Source.Unit
        ,Source.TenantId)
WHEN MATCHED THEN 
    UPDATE 
        SET [ModifiedDate] = '2021-11-19 00:00:00.0000'
          ,[ModifiedUser] = 1
          ,[TypeId] = Source.TypeId
          ,[ValueC] = Source.ValueC
          ,[ValueN] = Source.ValueN
          ,[ValueF] = Source.ValueF
          ,[DivId] = Source.DivId
          ,[Description] = Source.Description
          ,[Unit] = Source.Unit
          ,[TenantId] = Source.TenantId;
SET IDENTITY_INSERT [core].[DomainValue] OFF;
