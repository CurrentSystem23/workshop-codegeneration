/* core.UserRight hinzufügen */
SET IDENTITY_INSERT [core].[UserRight] ON;
MERGE INTO [core].[UserRight] AS Target 
USING (VALUES 
(1, 'Systemmonitor', 'Berechtigung für Systemmonitor'),
(101, 'SeminarParticipantBookmarkGet', 'Lesezeichen eines Seminarteilnehmers laden'),
(102, 'SeminarParticipantBookmarkSave', 'Lesezeichen eines Seminarteilnehmers speichern'),
(103, 'SeminarParticipantBookmarkDelete', 'Lesezeichen eines Seminarteilnehmers löschen'),
(201, 'SeminarParticipantCourseRevGet', 'Kursrevision eines Seminarteilnehmers laden'),
(202, 'SeminarTrainerCourseRevGet', 'Kursrevision eines Seminartrainers laden'),
(203, 'SeminarCoordinatorCourseRevGet', 'Kursrevision eines Seminarkoordinators laden'),
(204, 'CompanyCoordinatorCourseRevGet', 'Kursrevision eines Firmenadministrators laden'),
(301, 'ProductGet', 'Produkt laden'),
(302, 'TechnicalCertificatePartGet', 'Teilzertifikat laden'),
(401, 'SeminarParticipantQuestionnaireGet', 'Fragebogen eines Seminarteilnehmers laden'),
(402, 'SeminarParticipantAnswerSave', 'Antwort eines Seminarteilnehmers speichern'),
(403, 'SeminarParticipantCourseRevStatusGet', 'Status eine Seminarteilnehmers in einer Kursrevision laden'),
(501, 'EmployeeInvite', 'Registrierungseinladung an Mitarbeiter verschicken'),
(601, 'UserGroupAssignmentGet', 'Zuordnung aller Benutzer zu ihren Benutzergruppe laden'),
(602, 'UserGroupAssignmentSave', 'Zuordnung eines beliebigen Benutzers zu einer Benutzergruppe speichern'),
(603, 'UserGroupAssignmentDelete', 'Zuordnung eines beliebigen Benutzers zu einer Benutzergruppe löschen'),
(604, 'UserGroupAssignmentGetOwn', 'Zuordnung der eigenen Benutzer zu ihren Benutzergruppe laden'),
(621, 'UserGroupGet', 'Benutzergruppen laden'),
(622, 'UserGroupSave', 'Neue Benutzergruppe anlegen'),
(623, 'UserGroupDelete', 'Benutzergruppe entfernen'),
(631, 'UserRoleAssignmentsGet', 'Rollenzuweisungen laden'),
(632, 'UserRoleAssignmentSave', 'Rollenzuweisungen anlegen'),
(633, 'UserRoleAssignmentDelete', 'Rollenzuweisungen entfernen'),
(641, 'UserRolesGet', 'Benutzerrollen laden'),
(642, 'UserRoleSave', 'Benutzerrollen anlegen'),
(643, 'UserRoleDelete', 'Benutzerrollen entfernen'),
(651, 'UserRightAssignmentsGet', 'Rechtezuweisungen laden'),
(652, 'UserRightAssignmentSave', 'Rechtezuweisungen anlegen'),
(653, 'UserRightAssignmentDelete', 'Rechtezuweisungen entfernen'),
(661, 'UserRightsGet', 'Benutzerrechte laden'),
(671, 'UnblockUser', 'Konto eines beliebigen Benutzers entsperren'),
(672, 'UnblockOwnUser', 'Konto eines untergeordneten Benutzers entsperren'),
(701, 'SeminarParticipantSeminarGet', 'Seminar eines Seminarteilnehmers laden'),
(702, 'AssignableSeminarGet', 'Seminar dem noch Teilnehmer zugewiesen werden können laden'),
(703, 'SeminarSave', 'Seminar speichern'),
(704, 'SeminarCoordinatorSeminarGet', 'Seminar eines Seminarkoordinators laden'),
(705, 'SeminarTrainerSeminarGet', 'Seminar eines Seminartrainers laden'),
(706, 'SeminarCompanyCoordinatorSeminarGet', 'Seminar eines Firmenadministrators laden'),
(711, 'SeminarAssignmentGet', 'Zuordnung eines Seminarteilnehmers zu einem Seminar laden'),
(712, 'SeminarAssignmentSave', 'Zuordnung eines Seminarteilnehmers zu einem Seminar speichern'),
(713, 'SeminarAssignmentDelete', 'Zuordnung eines Seminarteilnehmers zu einem Seminar löschen'),
(721, 'SeminarTrainerGet', 'Seminartrainer laden'),
(722, 'SeminarTrainerSave', 'Seminartrainer speichern'),
(723, 'SeminarTrainerDelete', 'Seminartrainer löschen'),
(731, 'SeminarRoomGet', 'Seminarraum laden'),
(732, 'SeminarRoomSave', 'Seminarraum speichern'),
(733, 'SeminarRoomDelete', 'Seminarraum löschen'),
(801, 'SlideGet', 'Folie laden'),
(901, 'EmailChange', 'E-Mail-Adresse des eigenen Benutzers ändern'),
(902, 'PasswortChange', 'Passwort des eigenen Benutzers ändern'),
(1001, 'SeminarParticipantCertificateGet', 'Zertifikat eines Seminarteilnehmers laden'),
(1002, 'SeminarParticipantPrintableCertificateGet', 'Druckbares Zertifikat eines Seminarteilnehmers laden'),
(1101, 'ContentManagement', 'Kurse, Fragen und Folien erstellen, löschen und ändern'),
(1201, 'TechnicalCertificateGet', 'Zertifikate laden'),
(1301, 'TechnicalCertificateToUserGet', 'Zertifikate - Nutzer Zuordnung laden'),
(1302, 'TechnicalCertificateToUserSave', 'Zertifikate - Nutzer Zuordnung speichern'),
(1303, 'TechnicalCertificateToUserDelete', 'Zertifikate - Nutzer Zuordnung löschen'),
(1401, 'BusinessPartnerGet', 'Business Partner laden'),
(1501, 'SelfDisclosure', 'DSGVO - Recht auf Selbstauskunft'),
(1502, 'ToBeForgotten', 'DSGVO - Recht auf Vergessenwerden'),
(1601, 'OrganizationChart', 'Recht auf Organigramm'),
(1650, 'DashboardEmployee', 'Recht auf Mitarbeiterdashboard'),
(1701, 'BusinessPartnerOwnerCertificateGet', 'Zertifikate aller Mitarbeitenden der Firma laden')
) 
AS Source ([Id], [Right], [Description]) 
ON Target.Id = Source.Id 
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Id]
       ,[ModifiedDate]
       ,[ModifiedUser]
       ,[Right]
       ,[Description])
VALUES (Source.Id
        ,'2021-11-19 00:00:00.0000'
        ,1
        ,Source.[Right]
        ,Source.[Description])
WHEN MATCHED THEN 
    UPDATE 
        SET [ModifiedDate] = '2021-11-19 00:00:00.0000'
          ,[ModifiedUser] = 1
          ,[Right] = Source.[Right]
          ,[Description] = Source.[Description];
SET IDENTITY_INSERT [core].[UserRight] OFF;