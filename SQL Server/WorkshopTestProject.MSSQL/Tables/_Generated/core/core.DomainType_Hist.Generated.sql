CREATE TABLE [core].[DomainType_Hist]
(
     [Hist_Id]   BIGINT IDENTITY (1, 1) NOT NULL CONSTRAINT [pkDomainType_Hist_Id] PRIMARY KEY CLUSTERED ([Hist_Id] DESC) WITH (ALLOW_PAGE_LOCKS = OFF)
    ,[Hist_Action]   CHAR(1)         NOT NULL
    ,[Hist_Date]     DATETIME2       NOT NULL
    ,[Id]   bigint   NULL
    ,[ModifiedDate]   datetime2   NULL
    ,[ModifiedUser]   bigint   NULL
    ,[Type]   nvarchar(50)   NULL
    ,[Description]   nvarchar(MAX)   NULL
    ,[Mode]   char(1)   NULL
    ,[StandardId]   bigint   NULL
    ,[Editable]   bigint   NULL
)
GO
CREATE NONCLUSTERED INDEX [ndx_core_DomainType_Hist_DomainTypeId] ON [core].[DomainType_Hist]
(
	[Id] ASC
)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


