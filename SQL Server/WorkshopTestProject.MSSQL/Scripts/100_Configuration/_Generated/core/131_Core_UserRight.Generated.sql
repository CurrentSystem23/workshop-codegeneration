/* Delete old generated rights */
DELETE FROM [core].[UserRight] WHERE Id >= 100000

/* core.UserRight hinzufügen */
SET IDENTITY_INSERT [core].[UserRight] ON;
MERGE INTO [core].[UserRight] AS Target
USING (VALUES
(100000, 'core_Country_Read', 'Generiertes Leserecht für Tabelle [core].[Country]'),
(100001, 'core_Country_Write', 'Generiertes Schreibrecht für Tabelle [core].[Country]'),
(100002, 'core_Country_Delete', 'Generiertes Löschrecht für Tabelle [core].[Country]'),
(100003, 'core_Country_Hist_Read', 'Generiertes Leserecht für Tabelle [core].[Country_Hist]'),
(100004, 'core_Country_Hist_Delete', 'Generiertes Löschrecht für Tabelle [core].[Country_Hist]'),
(100005, 'core_Currency_Read', 'Generiertes Leserecht für Tabelle [core].[Currency]'),
(100006, 'core_Currency_Write', 'Generiertes Schreibrecht für Tabelle [core].[Currency]'),
(100007, 'core_Currency_Delete', 'Generiertes Löschrecht für Tabelle [core].[Currency]'),
(100008, 'core_Currency_Hist_Read', 'Generiertes Leserecht für Tabelle [core].[Currency_Hist]'),
(100009, 'core_Currency_Hist_Delete', 'Generiertes Löschrecht für Tabelle [core].[Currency_Hist]'),
(100010, 'core_DomainType_Read', 'Generiertes Leserecht für Tabelle [core].[DomainType]'),
(100011, 'core_DomainType_Write', 'Generiertes Schreibrecht für Tabelle [core].[DomainType]'),
(100012, 'core_DomainType_Delete', 'Generiertes Löschrecht für Tabelle [core].[DomainType]'),
(100013, 'core_DomainType_Hist_Read', 'Generiertes Leserecht für Tabelle [core].[DomainType_Hist]'),
(100014, 'core_DomainType_Hist_Delete', 'Generiertes Löschrecht für Tabelle [core].[DomainType_Hist]'),
(100015, 'core_DomainValue_Read', 'Generiertes Leserecht für Tabelle [core].[DomainValue]'),
(100016, 'core_DomainValue_Write', 'Generiertes Schreibrecht für Tabelle [core].[DomainValue]'),
(100017, 'core_DomainValue_Delete', 'Generiertes Löschrecht für Tabelle [core].[DomainValue]'),
(100018, 'core_DomainValue_Hist_Read', 'Generiertes Leserecht für Tabelle [core].[DomainValue_Hist]'),
(100019, 'core_DomainValue_Hist_Delete', 'Generiertes Löschrecht für Tabelle [core].[DomainValue_Hist]'),
(100020, 'core_GetInsertUpdateDeleteInformation_Execute', 'Generiertes Ausführungsrecht für Skalarwertfunktion [core].[GetInsertUpdateDeleteInformation]'),
(100021, 'core_Product_Read', 'Generiertes Leserecht für Tabelle [core].[Product]'),
(100022, 'core_Product_Write', 'Generiertes Schreibrecht für Tabelle [core].[Product]'),
(100023, 'core_Product_Delete', 'Generiertes Löschrecht für Tabelle [core].[Product]'),
(100024, 'core_Product_Hist_Read', 'Generiertes Leserecht für Tabelle [core].[Product_Hist]'),
(100025, 'core_Product_Hist_Delete', 'Generiertes Löschrecht für Tabelle [core].[Product_Hist]'),
(100026, 'core_ProductInStock_Read', 'Generiertes Leserecht für paramtrisierte Sicht [core].[ProductInStock]'),
(100027, 'core_ProductsInStock_Read', 'Generiertes Leserecht für Sicht [core].[ProductsInStock]'),
(100028, 'core_SpecialProducts_Read', 'Generiertes Leserecht für paramtrisierte Sicht [core].[SpecialProducts]'),
(100029, 'core_Stock_Read', 'Generiertes Leserecht für Tabelle [core].[Stock]'),
(100030, 'core_Stock_Write', 'Generiertes Schreibrecht für Tabelle [core].[Stock]'),
(100031, 'core_Stock_Delete', 'Generiertes Löschrecht für Tabelle [core].[Stock]'),
(100032, 'core_Stock_Hist_Read', 'Generiertes Leserecht für Tabelle [core].[Stock_Hist]'),
(100033, 'core_Stock_Hist_Delete', 'Generiertes Löschrecht für Tabelle [core].[Stock_Hist]'),
(100034, 'core_Tenant_Read', 'Generiertes Leserecht für Tabelle [core].[Tenant]'),
(100035, 'core_Tenant_Write', 'Generiertes Schreibrecht für Tabelle [core].[Tenant]'),
(100036, 'core_Tenant_Delete', 'Generiertes Löschrecht für Tabelle [core].[Tenant]'),
(100037, 'core_Tenant_Hist_Read', 'Generiertes Leserecht für Tabelle [core].[Tenant_Hist]'),
(100038, 'core_Tenant_Hist_Delete', 'Generiertes Löschrecht für Tabelle [core].[Tenant_Hist]'),
(100039, 'core_User_Read', 'Generiertes Leserecht für Tabelle [core].[User]'),
(100040, 'core_User_Write', 'Generiertes Schreibrecht für Tabelle [core].[User]'),
(100041, 'core_User_Delete', 'Generiertes Löschrecht für Tabelle [core].[User]'),
(100042, 'core_User_Hist_Read', 'Generiertes Leserecht für Tabelle [core].[User_Hist]'),
(100043, 'core_User_Hist_Delete', 'Generiertes Löschrecht für Tabelle [core].[User_Hist]'),
(100044, 'core_UserGroup_Read', 'Generiertes Leserecht für Tabelle [core].[UserGroup]'),
(100045, 'core_UserGroup_Write', 'Generiertes Schreibrecht für Tabelle [core].[UserGroup]'),
(100046, 'core_UserGroup_Delete', 'Generiertes Löschrecht für Tabelle [core].[UserGroup]'),
(100047, 'core_UserGroup_Hist_Read', 'Generiertes Leserecht für Tabelle [core].[UserGroup_Hist]'),
(100048, 'core_UserGroup_Hist_Delete', 'Generiertes Löschrecht für Tabelle [core].[UserGroup_Hist]'),
(100049, 'core_UserRight_Read', 'Generiertes Leserecht für Tabelle [core].[UserRight]'),
(100050, 'core_UserRight_Write', 'Generiertes Schreibrecht für Tabelle [core].[UserRight]'),
(100051, 'core_UserRight_Delete', 'Generiertes Löschrecht für Tabelle [core].[UserRight]'),
(100052, 'core_UserRight_Hist_Read', 'Generiertes Leserecht für Tabelle [core].[UserRight_Hist]'),
(100053, 'core_UserRight_Hist_Delete', 'Generiertes Löschrecht für Tabelle [core].[UserRight_Hist]'),
(100054, 'core_UserRightsRole_Read', 'Generiertes Leserecht für Tabelle [core].[UserRightsRole]'),
(100055, 'core_UserRightsRole_Write', 'Generiertes Schreibrecht für Tabelle [core].[UserRightsRole]'),
(100056, 'core_UserRightsRole_Delete', 'Generiertes Löschrecht für Tabelle [core].[UserRightsRole]'),
(100057, 'core_UserRightsRole_Hist_Read', 'Generiertes Leserecht für Tabelle [core].[UserRightsRole_Hist]'),
(100058, 'core_UserRightsRole_Hist_Delete', 'Generiertes Löschrecht für Tabelle [core].[UserRightsRole_Hist]')
)
AS Source ([Id], [Right], [Description])
ON Target.[Right] = Source.[Right]
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Id]
       ,[ModifiedDate]
       ,[ModifiedUser]
       ,[Right]
       ,[Description])
VALUES (Source.Id
        ,'2022-01-01 00:00:00.0000'
        ,1
        ,Source.[Right]
        ,Source.[Description])
WHEN MATCHED THEN
    UPDATE
        SET [ModifiedDate] = '2022-01-01 00:00:00.0000'
          ,[ModifiedUser] = 1
          ,[Right] = Source.[Right]
          ,[Description] = Source.[Description];
SET IDENTITY_INSERT [core].[UserRight] OFF;

