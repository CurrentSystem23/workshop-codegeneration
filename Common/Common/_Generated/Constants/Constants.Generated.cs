using System;

namespace WorkshopTestProject.Common.Constants
{
  public static partial class Constants
  {
    public static class DomainTypen
    {
      public const long Personentypen = 2;
      public const long Anreden = 3;
      public const long Titel = 4;
      public const long UserstatusDerCoreUserTabelle = 63;
    }
    public static class Personentypen
    {
      public const long DomainTypId = 2;
      
      public const long Person = 5;
      public const long Firma = 6;
      public const long System = 7;
    }
    public static class Anreden
    {
      public const long DomainTypId = 3;
      
      public const long Herr = 8;
      public const long Frau = 9;
      public const long Familie = 10;
      public const long Firma = 11;
      public const long OhneAnrede = 12;
    }
    public static class Titel
    {
      public const long DomainTypId = 4;
      
      public const long KeinAkademischerTitel = 13;
      public const long Bachelor = 14;
      public const long Master = 15;
      public const long Dr = 22;
      public const long DrDr = 23;
      public const long DrHabil = 24;
      public const long Privatdozent = 25;
      public const long Prof = 26;
      public const long ProfDr = 27;
    }
    public static class UserstatusDerCoreUserTabelle
    {
      public const long DomainTypId = 63;
      
      public const long Systemuser = 374;
      public const long Inaktiv = 375;
      public const long Aktiv = 376;
      public const long Gesperrt = 377;
    }
    public static class Countries
    {
    }
    public static class Currencies
    {
    }
    public static class UserGroup
    {
      public const long SystemAdministrator = 1;
      public const long RightsManager = 2;
      public const long ContentManager = 3;
      public const long SeminarCoordinator = 4;
      public const long SeminarTrainer = 5;
      public const long CompanyCoordinator = 6;
      public const long SeminarParticipant = 7;
    }
    public static class UserRight
    {
      public const string Systemmonitor = "1";
      public const string SeminarParticipantBookmarkGet = "101";
      public const string SeminarParticipantBookmarkSave = "102";
      public const string SeminarParticipantBookmarkDelete = "103";
      public const string SeminarParticipantCourseRevGet = "201";
      public const string SeminarTrainerCourseRevGet = "202";
      public const string SeminarCoordinatorCourseRevGet = "203";
      public const string CompanyCoordinatorCourseRevGet = "204";
      public const string ProductGet = "301";
      public const string TechnicalCertificatePartGet = "302";
      public const string SeminarParticipantQuestionnaireGet = "401";
      public const string SeminarParticipantAnswerSave = "402";
      public const string SeminarParticipantCourseRevStatusGet = "403";
      public const string EmployeeInvite = "501";
      public const string UserGroupAssignmentGet = "601";
      public const string UserGroupAssignmentSave = "602";
      public const string UserGroupAssignmentDelete = "603";
      public const string UserGroupAssignmentGetOwn = "604";
      public const string UserGroupGet = "621";
      public const string UserGroupSave = "622";
      public const string UserGroupDelete = "623";
      public const string UserRoleAssignmentsGet = "631";
      public const string UserRoleAssignmentSave = "632";
      public const string UserRoleAssignmentDelete = "633";
      public const string UserRolesGet = "641";
      public const string UserRoleSave = "642";
      public const string UserRoleDelete = "643";
      public const string UserRightAssignmentsGet = "651";
      public const string UserRightAssignmentSave = "652";
      public const string UserRightAssignmentDelete = "653";
      public const string UserRightsGet = "661";
      public const string UnblockUser = "671";
      public const string UnblockOwnUser = "672";
      public const string SeminarParticipantSeminarGet = "701";
      public const string AssignableSeminarGet = "702";
      public const string SeminarSave = "703";
      public const string SeminarCoordinatorSeminarGet = "704";
      public const string SeminarTrainerSeminarGet = "705";
      public const string SeminarCompanyCoordinatorSeminarGet = "706";
      public const string SeminarAssignmentGet = "711";
      public const string SeminarAssignmentSave = "712";
      public const string SeminarAssignmentDelete = "713";
      public const string SeminarTrainerGet = "721";
      public const string SeminarTrainerSave = "722";
      public const string SeminarTrainerDelete = "723";
      public const string SeminarRoomGet = "731";
      public const string SeminarRoomSave = "732";
      public const string SeminarRoomDelete = "733";
      public const string SlideGet = "801";
      public const string EmailChange = "901";
      public const string PasswortChange = "902";
      public const string SeminarParticipantCertificateGet = "1001";
      public const string SeminarParticipantPrintableCertificateGet = "1002";
      public const string ContentManagement = "1101";
      public const string TechnicalCertificateGet = "1201";
      public const string TechnicalCertificateToUserGet = "1301";
      public const string TechnicalCertificateToUserSave = "1302";
      public const string TechnicalCertificateToUserDelete = "1303";
      public const string BusinessPartnerGet = "1401";
      public const string SelfDisclosure = "1501";
      public const string ToBeForgotten = "1502";
      public const string OrganizationChart = "1601";
      public const string DashboardEmployee = "1650";
      public const string BusinessPartnerOwnerCertificateGet = "1701";
    }
    public static class UserRightsRole
    {
      public const long SystemAdministrator = 1;
      public const long RightsManager = 2;
      public const long ContentManager = 3;
      public const long SeminarCoordinator = 4;
      public const long SeminarTrainer = 5;
      public const long CompanyCoordinator = 6;
      public const long SeminarParticipant = 7;
    }
  }
}


