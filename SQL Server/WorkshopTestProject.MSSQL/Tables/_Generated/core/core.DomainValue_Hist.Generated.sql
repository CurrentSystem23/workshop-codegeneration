CREATE TABLE [core].[DomainValue_Hist]
(
     [Hist_Id]   BIGINT IDENTITY (1, 1) NOT NULL CONSTRAINT [pkDomainValue_Hist_Id] PRIMARY KEY CLUSTERED ([Hist_Id] DESC) WITH (ALLOW_PAGE_LOCKS = OFF)
    ,[Hist_Action]   CHAR(1)         NOT NULL
    ,[Hist_Date]     DATETIME2       NOT NULL
    ,[Id]   bigint   NULL
    ,[ModifiedDate]   datetime2   NULL
    ,[ModifiedUser]   bigint   NULL
    ,[TypeId]   bigint   NULL
    ,[ValueC]   nvarchar(400)   NULL
    ,[ValueN]   bigint   NULL
    ,[ValueD]   datetime2   NULL
    ,[ValueF]   float   NULL
    ,[DivId]   nvarchar(MAX)   NULL
    ,[Description]   nvarchar(4000)   NULL
    ,[Unit]   nvarchar(100)   NULL
    ,[TenantId]   bigint   NULL
)
GO
CREATE NONCLUSTERED INDEX [ndx_core_DomainValue_Hist_DomainValueId] ON [core].[DomainValue_Hist]
(
	[Id] ASC
)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


