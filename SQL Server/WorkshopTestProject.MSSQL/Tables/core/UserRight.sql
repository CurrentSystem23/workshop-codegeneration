CREATE TABLE [core].[UserRight]
(
	  [Id]                  BIGINT IDENTITY (1000000, 1) NOT NULL CONSTRAINT [pk_CoreUserRight_Id] PRIMARY KEY CLUSTERED ([Id] DESC) WITH (ALLOW_PAGE_LOCKS = OFF),
    [ModifiedDate]        DATETIME2      NOT NULL, 
    [ModifiedUser]        BIGINT         NOT NULL CONSTRAINT [fk_CoreUserRight_CoreUser_ModifiedUser] FOREIGN KEY ([ModifiedUser]) REFERENCES [core].[User] ([Id]),
                                        
    [Right]               NVARCHAR(1000) NOT NULL CONSTRAINT [ucUserRightRight] UNIQUE([Right]),
    [Description]         NVARCHAR(4000) NOT NULL CONSTRAINT [dv_CoreUserRight_Description] DEFAULT ''
);
GO

CREATE INDEX [ix_coreUserRight_ModifiedUser] ON [core].[UserRight] ([ModifiedUser]);
GO
