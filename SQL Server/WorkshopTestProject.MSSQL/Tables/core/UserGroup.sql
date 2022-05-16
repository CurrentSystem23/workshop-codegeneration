CREATE TABLE [core].[UserGroup]
(
	  [Id]                  BIGINT IDENTITY (1000000, 1) NOT NULL CONSTRAINT [pk_CoreUserGroup_Id] PRIMARY KEY CLUSTERED ([Id] DESC) WITH (ALLOW_PAGE_LOCKS = OFF),
    [ModifiedDate]        DATETIME2      NOT NULL, 
    [ModifiedUser]        BIGINT         NOT NULL CONSTRAINT [fk_CoreUserGroup_CoreUser_ModifiedUser] FOREIGN KEY ([ModifiedUser]) REFERENCES [core].[User] ([Id]),
                                        
    [Group]               NVARCHAR(1000) NOT NULL CONSTRAINT [ucUserGroupGroup] UNIQUE([Group]),
    [Description]         NVARCHAR(4000) NOT NULL CONSTRAINT [dv_CoreUserGroup_Description] DEFAULT ''
);
GO

CREATE INDEX [ix_coreUserGroup_ModifiedUser] ON [core].[UserGroup] ([ModifiedUser]);
GO

