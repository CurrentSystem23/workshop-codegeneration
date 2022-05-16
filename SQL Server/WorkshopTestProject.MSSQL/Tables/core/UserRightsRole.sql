CREATE TABLE [core].[UserRightsRole]
(
	  [Id]                  BIGINT IDENTITY (1000000, 1) NOT NULL CONSTRAINT [pk_CoreUserRightsRole_Id] PRIMARY KEY CLUSTERED ([Id] DESC) WITH (ALLOW_PAGE_LOCKS = OFF),
    [ModifiedDate]        DATETIME2      NOT NULL, 
    [ModifiedUser]        BIGINT         NOT NULL CONSTRAINT [fk_CoreUserRightsRole_CoreUser_ModifiedUser] FOREIGN KEY ([ModifiedUser]) REFERENCES [core].[User] ([Id]),
                                        
    [Role]                NVARCHAR(1000) NOT NULL CONSTRAINT [ucUserRightsRoleRole] UNIQUE([Role]),
    [Description]         NVARCHAR(4000) NOT NULL CONSTRAINT [dv_CoreUserRightsRole_Description] DEFAULT ''
);
GO

CREATE INDEX [ix_coreUserRightsRole_ModifiedUser] ON [core].[UserRightsRole] ([ModifiedUser]);
GO