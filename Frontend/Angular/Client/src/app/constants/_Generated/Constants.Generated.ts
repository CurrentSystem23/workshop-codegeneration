export module Constants{
  export class DomainTypen {
    public static Personentypen = 2;
    public static Anreden = 3;
    public static Titel = 4;
    public static UserstatusDerCoreUserTabelle = 63;
  }
  export class Personentypen {
    public static DomainTypId = 2;
    
    public static Person = 5;
    public static Firma = 6;
    public static System = 7;
  }
  export class Anreden {
    public static DomainTypId = 3;
    
    public static Herr = 8;
    public static Frau = 9;
    public static Familie = 10;
    public static Firma = 11;
    public static OhneAnrede = 12;
  }
  export class Titel {
    public static DomainTypId = 4;
    
    public static KeinAkademischerTitel = 13;
    public static Bachelor = 14;
    public static Master = 15;
    public static Dr = 22;
    public static DrDr = 23;
    public static DrHabil = 24;
    public static Privatdozent = 25;
    public static Prof = 26;
    public static ProfDr = 27;
  }
  export class UserstatusDerCoreUserTabelle {
    public static DomainTypId = 63;
    
    public static Systemuser = 374;
    public static Inaktiv = 375;
    public static Aktiv = 376;
    public static Gesperrt = 377;
  }
  export class Countries {
  }
  export class Currencies {
  }
  export class UserGroup {
    public static Systemadministrator = 1;
    public static Rightsmanager = 2;
    public static Contentmanager = 3;
    public static Seminarcoordinator = 4;
    public static Seminartrainer = 5;
    public static Companycoordinator = 6;
    public static Seminarparticipant = 7;
  }
  export class UserRight {
    public static Systemmonitor = "1";
    public static SeminarParticipantBookmarkGet = "101";
    public static SeminarParticipantBookmarkSave = "102";
    public static SeminarParticipantBookmarkDelete = "103";
    public static SeminarParticipantCourseRevGet = "201";
    public static SeminarTrainerCourseRevGet = "202";
    public static SeminarCoordinatorCourseRevGet = "203";
    public static CompanyCoordinatorCourseRevGet = "204";
    public static ProductGet = "301";
    public static TechnicalCertificatePartGet = "302";
    public static SeminarParticipantQuestionnaireGet = "401";
    public static SeminarParticipantAnswerSave = "402";
    public static SeminarParticipantCourseRevStatusGet = "403";
    public static EmployeeInvite = "501";
    public static UserGroupAssignmentGet = "601";
    public static UserGroupAssignmentSave = "602";
    public static UserGroupAssignmentDelete = "603";
    public static UserGroupAssignmentGetOwn = "604";
    public static UserGroupGet = "621";
    public static UserGroupSave = "622";
    public static UserGroupDelete = "623";
    public static UserRoleAssignmentsGet = "631";
    public static UserRoleAssignmentSave = "632";
    public static UserRoleAssignmentDelete = "633";
    public static UserRolesGet = "641";
    public static UserRoleSave = "642";
    public static UserRoleDelete = "643";
    public static UserRightAssignmentsGet = "651";
    public static UserRightAssignmentSave = "652";
    public static UserRightAssignmentDelete = "653";
    public static UserRightsGet = "661";
    public static UnblockUser = "671";
    public static UnblockOwnUser = "672";
    public static SeminarParticipantSeminarGet = "701";
    public static AssignableSeminarGet = "702";
    public static SeminarSave = "703";
    public static SeminarCoordinatorSeminarGet = "704";
    public static SeminarTrainerSeminarGet = "705";
    public static SeminarCompanyCoordinatorSeminarGet = "706";
    public static SeminarAssignmentGet = "711";
    public static SeminarAssignmentSave = "712";
    public static SeminarAssignmentDelete = "713";
    public static SeminarTrainerGet = "721";
    public static SeminarTrainerSave = "722";
    public static SeminarTrainerDelete = "723";
    public static SeminarRoomGet = "731";
    public static SeminarRoomSave = "732";
    public static SeminarRoomDelete = "733";
    public static SlideGet = "801";
    public static EmailChange = "901";
    public static PasswortChange = "902";
    public static SeminarParticipantCertificateGet = "1001";
    public static SeminarParticipantPrintableCertificateGet = "1002";
    public static ContentManagement = "1101";
    public static TechnicalCertificateGet = "1201";
    public static TechnicalCertificateToUserGet = "1301";
    public static TechnicalCertificateToUserSave = "1302";
    public static TechnicalCertificateToUserDelete = "1303";
    public static BusinessPartnerGet = "1401";
    public static SelfDisclosure = "1501";
    public static ToBeForgotten = "1502";
    public static OrganizationChart = "1601";
    public static DashboardEmployee = "1650";
    public static BusinessPartnerOwnerCertificateGet = "1701";
  }
  export class UserRightsRole {
    public static Systemadministrator = 1;
    public static Rightsmanager = 2;
    public static Contentmanager = 3;
    public static Seminarcoordinator = 4;
    public static Seminartrainer = 5;
    public static Companycoordinator = 6;
    public static Seminarparticipant = 7;
  }
}


