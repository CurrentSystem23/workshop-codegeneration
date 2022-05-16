/* core.UserRightsRole hinzufügen */
        SET IDENTITY_INSERT [core].[UserRightsRole] ON;
        MERGE INTO [core].[UserRightsRole] AS Target 
        USING (VALUES 

        (1, 'SystemAdministrator', 'Grants all available rights.')
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
                ,'2017-01-01 00:00:00.0000'
                ,1
                ,Source.[Role]
                ,Source.[Description])
        WHEN MATCHED THEN 
            UPDATE 
                SET [ModifiedDate] = '2017-01-01 00:00:00.0000'
                  ,[ModifiedUser] = 1
                  ,[Role] = Source.[Role]
                  ,[Description] = Source.[Description];
        SET IDENTITY_INSERT [core].[UserRightsRole] OFF;
