CREATE TABLE [core].[Country]
(
    [Id]            BIGINT IDENTITY (1000000, 1) NOT NULL CONSTRAINT [pk_CoreCountry_Id] PRIMARY KEY CLUSTERED ([Id] DESC) WITH (ALLOW_PAGE_LOCKS = OFF),
    [ModifiedDate]  DATETIME2     NOT NULL, 
    [ModifiedUser]  BIGINT        NOT NULL CONSTRAINT [fk_CoreCountry_CoreUser_ModifiedUser] FOREIGN KEY ([ModifiedUser]) REFERENCES [core].[User] ([Id]),

    [Country]       NVARCHAR(100) NOT NULL CONSTRAINT [dv_CoreCountry_Country] DEFAULT '',
    [CountryKey]    NVARCHAR(3)   NULL,
    [CurrencyId]    BIGINT        NULL     CONSTRAINT [fk_CoreCountry_CoreCurrency_CurrencyId] FOREIGN KEY ([CurrencyId]) REFERENCES [core].[Currency] ([Id])
);
GO

CREATE INDEX [ix_coreCountry_ModifiedUser] ON [core].[Country] ([ModifiedUser]);
GO

CREATE INDEX [ix_coreCountry_CurrencyId] ON [core].[Country] ([CurrencyId]);
GO

EXECUTE sp_addextendedproperty @level0name=N'core', @level1name=N'Country', @level2name=N'Id',                          @value=N'Id der Währung',     @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO                                                                                                                           
EXECUTE sp_addextendedproperty @level0name=N'core', @level1name=N'Country', @level2name=N'ModifiedDate',                @value=N'Datum der letzten Änderung',     @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO                                                                                                                           
EXECUTE sp_addextendedproperty @level0name=N'core', @level1name=N'Country', @level2name=N'ModifiedUser',                @value=N'Id des Benutzers der die letzte Änderung vorgenommen hat',     @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO                                                                                                                           

