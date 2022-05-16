CREATE TABLE [core].[Stock]
(
    [Id]                  BIGINT IDENTITY (1000000, 1)  NOT NULL CONSTRAINT [pk_CoreStock_Id] PRIMARY KEY CLUSTERED ([Id] DESC) WITH (ALLOW_PAGE_LOCKS = OFF),
    [ModifiedDate]        DATETIME2       NOT NULL, 
    [ModifiedUser]        BIGINT          NOT NULL CONSTRAINT [fk_CoreStock_CoreUser_ModifiedUser] FOREIGN KEY ([ModifiedUser]) REFERENCES [core].[User] ([Id]),

    [ProductId]           BIGINT          NOT NULL CONSTRAINT [fk_CoreStock_CoreProduct_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [core].[Product] ([Id]),
    [Quantity]            BIGINT          NOT NULL
)
