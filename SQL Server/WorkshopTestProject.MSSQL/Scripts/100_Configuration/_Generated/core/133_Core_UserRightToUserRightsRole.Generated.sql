/* Delete old generated rights */
DELETE FROM [core].[UserRightToUserRightsRole] WHERE Id >= 100000

/* core.UserRightToUserRightsRole hinzufügen */
SET IDENTITY_INSERT [core].[UserRightToUserRightsRole] ON;
MERGE INTO [core].[UserRightToUserRightsRole] AS Target
USING (VALUES
(100000, 1, [core].[GetRightIdFromUserRight]('Systemmonitor')),
(100001, 1, [core].[GetRightIdFromUserRight]('SeminarParticipantBookmarkGet')),
(100002, 1, [core].[GetRightIdFromUserRight]('SeminarParticipantBookmarkSave')),
(100003, 1, [core].[GetRightIdFromUserRight]('SeminarParticipantBookmarkDelete')),
(100004, 1, [core].[GetRightIdFromUserRight]('SeminarParticipantCourseRevGet')),
(100005, 1, [core].[GetRightIdFromUserRight]('SeminarTrainerCourseRevGet')),
(100006, 1, [core].[GetRightIdFromUserRight]('SeminarCoordinatorCourseRevGet')),
(100007, 1, [core].[GetRightIdFromUserRight]('CompanyCoordinatorCourseRevGet')),
(100008, 1, [core].[GetRightIdFromUserRight]('ProductGet')),
(100009, 1, [core].[GetRightIdFromUserRight]('TechnicalCertificatePartGet')),
(100010, 1, [core].[GetRightIdFromUserRight]('SeminarParticipantQuestionnaireGet')),
(100011, 1, [core].[GetRightIdFromUserRight]('SeminarParticipantAnswerSave')),
(100012, 1, [core].[GetRightIdFromUserRight]('SeminarParticipantCourseRevStatusGet')),
(100013, 1, [core].[GetRightIdFromUserRight]('EmployeeInvite')),
(100014, 1, [core].[GetRightIdFromUserRight]('UserGroupAssignmentGet')),
(100015, 1, [core].[GetRightIdFromUserRight]('UserGroupAssignmentSave')),
(100016, 1, [core].[GetRightIdFromUserRight]('UserGroupAssignmentDelete')),
(100017, 1, [core].[GetRightIdFromUserRight]('UserGroupAssignmentGetOwn')),
(100018, 1, [core].[GetRightIdFromUserRight]('UserGroupGet')),
(100019, 1, [core].[GetRightIdFromUserRight]('UserGroupSave')),
(100020, 1, [core].[GetRightIdFromUserRight]('UserGroupDelete')),
(100021, 1, [core].[GetRightIdFromUserRight]('UserRoleAssignmentsGet')),
(100022, 1, [core].[GetRightIdFromUserRight]('UserRoleAssignmentSave')),
(100023, 1, [core].[GetRightIdFromUserRight]('UserRoleAssignmentDelete')),
(100024, 1, [core].[GetRightIdFromUserRight]('UserRolesGet')),
(100025, 1, [core].[GetRightIdFromUserRight]('UserRoleSave')),
(100026, 1, [core].[GetRightIdFromUserRight]('UserRoleDelete')),
(100027, 1, [core].[GetRightIdFromUserRight]('UserRightAssignmentsGet')),
(100028, 1, [core].[GetRightIdFromUserRight]('UserRightAssignmentSave')),
(100029, 1, [core].[GetRightIdFromUserRight]('UserRightAssignmentDelete')),
(100030, 1, [core].[GetRightIdFromUserRight]('UserRightsGet')),
(100031, 1, [core].[GetRightIdFromUserRight]('UnblockUser')),
(100032, 1, [core].[GetRightIdFromUserRight]('UnblockOwnUser')),
(100033, 1, [core].[GetRightIdFromUserRight]('SeminarParticipantSeminarGet')),
(100034, 1, [core].[GetRightIdFromUserRight]('AssignableSeminarGet')),
(100035, 1, [core].[GetRightIdFromUserRight]('SeminarSave')),
(100036, 1, [core].[GetRightIdFromUserRight]('SeminarCoordinatorSeminarGet')),
(100037, 1, [core].[GetRightIdFromUserRight]('SeminarTrainerSeminarGet')),
(100038, 1, [core].[GetRightIdFromUserRight]('SeminarCompanyCoordinatorSeminarGet')),
(100039, 1, [core].[GetRightIdFromUserRight]('SeminarAssignmentGet')),
(100040, 1, [core].[GetRightIdFromUserRight]('SeminarAssignmentSave')),
(100041, 1, [core].[GetRightIdFromUserRight]('SeminarAssignmentDelete')),
(100042, 1, [core].[GetRightIdFromUserRight]('SeminarTrainerGet')),
(100043, 1, [core].[GetRightIdFromUserRight]('SeminarTrainerSave')),
(100044, 1, [core].[GetRightIdFromUserRight]('SeminarTrainerDelete')),
(100045, 1, [core].[GetRightIdFromUserRight]('SeminarRoomGet')),
(100046, 1, [core].[GetRightIdFromUserRight]('SeminarRoomSave')),
(100047, 1, [core].[GetRightIdFromUserRight]('SeminarRoomDelete')),
(100048, 1, [core].[GetRightIdFromUserRight]('SlideGet')),
(100049, 1, [core].[GetRightIdFromUserRight]('EmailChange')),
(100050, 1, [core].[GetRightIdFromUserRight]('PasswortChange')),
(100051, 1, [core].[GetRightIdFromUserRight]('SeminarParticipantCertificateGet')),
(100052, 1, [core].[GetRightIdFromUserRight]('SeminarParticipantPrintableCertificateGet')),
(100053, 1, [core].[GetRightIdFromUserRight]('ContentManagement')),
(100054, 1, [core].[GetRightIdFromUserRight]('TechnicalCertificateGet')),
(100055, 1, [core].[GetRightIdFromUserRight]('TechnicalCertificateToUserGet')),
(100056, 1, [core].[GetRightIdFromUserRight]('TechnicalCertificateToUserSave')),
(100057, 1, [core].[GetRightIdFromUserRight]('TechnicalCertificateToUserDelete')),
(100058, 1, [core].[GetRightIdFromUserRight]('BusinessPartnerGet')),
(100059, 1, [core].[GetRightIdFromUserRight]('SelfDisclosure')),
(100060, 1, [core].[GetRightIdFromUserRight]('ToBeForgotten')),
(100061, 1, [core].[GetRightIdFromUserRight]('OrganizationChart')),
(100062, 1, [core].[GetRightIdFromUserRight]('DashboardEmployee')),
(100063, 1, [core].[GetRightIdFromUserRight]('BusinessPartnerOwnerCertificateGet')),
(100064, 1, [core].[GetRightIdFromUserRight]('core_Country_Read')),
(100065, 1, [core].[GetRightIdFromUserRight]('core_Country_Write')),
(100066, 1, [core].[GetRightIdFromUserRight]('core_Country_Delete')),
(100067, 1, [core].[GetRightIdFromUserRight]('core_Country_Hist_Read')),
(100068, 1, [core].[GetRightIdFromUserRight]('core_Country_Hist_Delete')),
(100069, 1, [core].[GetRightIdFromUserRight]('core_Currency_Read')),
(100070, 1, [core].[GetRightIdFromUserRight]('core_Currency_Write')),
(100071, 1, [core].[GetRightIdFromUserRight]('core_Currency_Delete')),
(100072, 1, [core].[GetRightIdFromUserRight]('core_Currency_Hist_Read')),
(100073, 1, [core].[GetRightIdFromUserRight]('core_Currency_Hist_Delete')),
(100074, 1, [core].[GetRightIdFromUserRight]('core_DomainType_Read')),
(100075, 1, [core].[GetRightIdFromUserRight]('core_DomainType_Write')),
(100076, 1, [core].[GetRightIdFromUserRight]('core_DomainType_Delete')),
(100077, 1, [core].[GetRightIdFromUserRight]('core_DomainType_Hist_Read')),
(100078, 1, [core].[GetRightIdFromUserRight]('core_DomainType_Hist_Delete')),
(100079, 1, [core].[GetRightIdFromUserRight]('core_DomainValue_Read')),
(100080, 1, [core].[GetRightIdFromUserRight]('core_DomainValue_Write')),
(100081, 1, [core].[GetRightIdFromUserRight]('core_DomainValue_Delete')),
(100082, 1, [core].[GetRightIdFromUserRight]('core_DomainValue_Hist_Read')),
(100083, 1, [core].[GetRightIdFromUserRight]('core_DomainValue_Hist_Delete')),
(100084, 1, [core].[GetRightIdFromUserRight]('core_GetInsertUpdateDeleteInformation_Execute')),
(100085, 1, [core].[GetRightIdFromUserRight]('core_Product_Read')),
(100086, 1, [core].[GetRightIdFromUserRight]('core_Product_Write')),
(100087, 1, [core].[GetRightIdFromUserRight]('core_Product_Delete')),
(100088, 1, [core].[GetRightIdFromUserRight]('core_Product_Hist_Read')),
(100089, 1, [core].[GetRightIdFromUserRight]('core_Product_Hist_Delete')),
(100090, 1, [core].[GetRightIdFromUserRight]('core_ProductInStock_Read')),
(100091, 1, [core].[GetRightIdFromUserRight]('core_ProductsInStock_Read')),
(100092, 1, [core].[GetRightIdFromUserRight]('core_SpecialProducts_Read')),
(100093, 1, [core].[GetRightIdFromUserRight]('core_Stock_Read')),
(100094, 1, [core].[GetRightIdFromUserRight]('core_Stock_Write')),
(100095, 1, [core].[GetRightIdFromUserRight]('core_Stock_Delete')),
(100096, 1, [core].[GetRightIdFromUserRight]('core_Stock_Hist_Read')),
(100097, 1, [core].[GetRightIdFromUserRight]('core_Stock_Hist_Delete')),
(100098, 1, [core].[GetRightIdFromUserRight]('core_Tenant_Read')),
(100099, 1, [core].[GetRightIdFromUserRight]('core_Tenant_Write')),
(100100, 1, [core].[GetRightIdFromUserRight]('core_Tenant_Delete')),
(100101, 1, [core].[GetRightIdFromUserRight]('core_Tenant_Hist_Read')),
(100102, 1, [core].[GetRightIdFromUserRight]('core_Tenant_Hist_Delete')),
(100103, 1, [core].[GetRightIdFromUserRight]('core_User_Read')),
(100104, 1, [core].[GetRightIdFromUserRight]('core_User_Write')),
(100105, 1, [core].[GetRightIdFromUserRight]('core_User_Delete')),
(100106, 1, [core].[GetRightIdFromUserRight]('core_User_Hist_Read')),
(100107, 1, [core].[GetRightIdFromUserRight]('core_User_Hist_Delete')),
(100108, 1, [core].[GetRightIdFromUserRight]('core_UserGroup_Read')),
(100109, 1, [core].[GetRightIdFromUserRight]('core_UserGroup_Write')),
(100110, 1, [core].[GetRightIdFromUserRight]('core_UserGroup_Delete')),
(100111, 1, [core].[GetRightIdFromUserRight]('core_UserGroup_Hist_Read')),
(100112, 1, [core].[GetRightIdFromUserRight]('core_UserGroup_Hist_Delete')),
(100113, 1, [core].[GetRightIdFromUserRight]('core_UserRight_Read')),
(100114, 1, [core].[GetRightIdFromUserRight]('core_UserRight_Write')),
(100115, 1, [core].[GetRightIdFromUserRight]('core_UserRight_Delete')),
(100116, 1, [core].[GetRightIdFromUserRight]('core_UserRight_Hist_Read')),
(100117, 1, [core].[GetRightIdFromUserRight]('core_UserRight_Hist_Delete')),
(100118, 1, [core].[GetRightIdFromUserRight]('core_UserRightsRole_Read')),
(100119, 1, [core].[GetRightIdFromUserRight]('core_UserRightsRole_Write')),
(100120, 1, [core].[GetRightIdFromUserRight]('core_UserRightsRole_Delete')),
(100121, 1, [core].[GetRightIdFromUserRight]('core_UserRightsRole_Hist_Read')),
(100122, 1, [core].[GetRightIdFromUserRight]('core_UserRightsRole_Hist_Delete'))
)
        AS Source ([Id], [UserRightsRoleId], [UserRightId]) 
        ON Target.Id = Source.Id 
        WHEN NOT MATCHED BY TARGET THEN 
        INSERT ([Id]
               ,[ModifiedDate]
               ,[ModifiedUser]
               ,[UserRightId]
               ,[UserRightsRoleId])
        VALUES (Source.Id
                ,'2022-01-01 00:00:00.0000'
                ,1
                ,Source.[UserRightId]
                ,Source.[UserRightsRoleId])
        WHEN MATCHED THEN 
            UPDATE 
                SET [ModifiedDate] = '2017-01-01 00:00:00.0000'
                  ,[ModifiedUser] = 1
                  ,[UserRightId] = Source.[UserRightId]
                  ,[UserRightsRoleId] = Source.[UserRightsRoleId];
        SET IDENTITY_INSERT [core].[UserRightToUserRightsRole] OFF;
        
