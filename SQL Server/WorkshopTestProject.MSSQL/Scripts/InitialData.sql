/* Constraints ausschalten */
:r .\_Generated\CheckConstraintsOff.Generated.sql

:r .\100_Configuration\100_Core_DomainTypes.sql
:r .\100_Configuration\101_Core_DomainValues.sql
:r .\100_Configuration\120_Core_Tenants.sql
:r .\100_Configuration\130_Core_User.sql
:r .\100_Configuration\131_Core_UserRight.sql
:r .\100_Configuration\132_Core_UserRightsRole.sql
:r .\100_Configuration\133_Core_UserGroup.sql

:r .\100_Configuration\_Generated\core\131_Core_UserRight.Generated.sql
:r .\100_Configuration\_Generated\core\132_Core_UserRightsRole_SystemAdministrator.Generated.sql
--:r .\100_Configuration\_Generated\core\133_Core_UserRightToUserRightsRole.Generated.sql

--DISABLE TRIGGER [core].[Product_HistTrigger] ON [core].[Product]
--:r .\100_Configuration\190_Core_Products.sql
--:r .\100_Configuration\191_Core_Products.sql
--ENABLE TRIGGER [core].[Product_HistTrigger] ON [core].[Product]

/* Constraints einschalten */
:r .\_Generated\CheckConstraintsOn.Generated.sql