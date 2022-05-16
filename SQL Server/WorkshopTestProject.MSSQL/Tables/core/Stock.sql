CREATE TABLE [core].[Product]
(
    [Id]                  BIGINT IDENTITY (1000000, 1)  NOT NULL CONSTRAINT [pk_CoreProduct_Id] PRIMARY KEY CLUSTERED ([Id] DESC) WITH (ALLOW_PAGE_LOCKS = OFF),
    [ModifiedDate]        DATETIME2       NOT NULL, 
    [ModifiedUser]        BIGINT          NOT NULL CONSTRAINT [fk_CoreProduct_CoreUser_ModifiedUser] FOREIGN KEY ([ModifiedUser]) REFERENCES [core].[User] ([Id]),

    [ProductName]         NVARCHAR(200)   NOT NULL,
    [Price]               FLOAT           NOT NULL
)
