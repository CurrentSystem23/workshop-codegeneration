CREATE TABLE [core].[Currency]
(
    [Id]            BIGINT IDENTITY (1000000, 1) NOT NULL CONSTRAINT [pk_CoreCurrency_Id] PRIMARY KEY CLUSTERED ([Id] DESC) WITH (ALLOW_PAGE_LOCKS = OFF),
    [ModifiedDate]  DATETIME2     NOT NULL, 
    [ModifiedUser]  BIGINT        NOT NULL CONSTRAINT [fk_CoreCurrency_CoreUser_ModifiedUser] FOREIGN KEY ([ModifiedUser]) REFERENCES [core].[User] ([Id]),

  	[Iso]           NVARCHAR(3)   NOT NULL,
    [Currency]      NVARCHAR(200) NOT NULL,
    [CurrencyParts] NVARCHAR(200) NOT NULL CONSTRAINT [dv_CoreCurrency_CurrencyParts] DEFAULT '',
    [Region]        NVARCHAR(200) NOT NULL CONSTRAINT [dv_CoreCurrency_Region] DEFAULT ''
);
GO

CREATE INDEX [ix_coreCurrency_ModifiedUser] ON [core].[Currency] ([ModifiedUser]);
GO

