CREATE TABLE [core].[Tenant]
(
    [Id]                  BIGINT IDENTITY (1000000, 1)  NOT NULL CONSTRAINT [pk_CoreTenant_Id] PRIMARY KEY CLUSTERED ([Id] DESC) WITH (ALLOW_PAGE_LOCKS = OFF),
    [ModifiedDate]        DATETIME2       NOT NULL, 
    [ModifiedUser]        BIGINT          NOT NULL CONSTRAINT [fk_CoreTenant_CoreUser_ModifiedUser] FOREIGN KEY ([ModifiedUser]) REFERENCES [core].[User] ([Id]),

    [TenantName]          NVARCHAR(200)   NOT NULL,
    [Description]         NVARCHAR(4000)  NOT NULL CONSTRAINT [dv_CoreTenant_Description] DEFAULT ''
);
GO

CREATE INDEX [ix_coreTenant_ModifiedUser] ON [core].[Tenant] ([ModifiedUser]);
GO
