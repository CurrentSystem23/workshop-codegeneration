-- AdHoc Abfrage "hard coded"

  SELECT pv.[Id]
        ,pv.[ProductName]
        ,pv.[Price]
        ,pv.[Quantity]
    FROM [core].[ProductInStock](4) pv

  SELECT pt.[Id]
        ,pt.[ProductName]
        ,pt.[Price]
  FROM core.product pt
  WHERE pt.[Id] = 4

-- AdHoc Abfrage paramtrisiert

  DECLARE @productId bigint
  SET @productId = 4

  SELECT 
          pv.[Id]
        ,pv.[ProductName]
        ,pv.[Price]
        ,pv.[Quantity]
    FROM [core].[ProductInStock](@productId) pv

  DECLARE @productId bigint
  SET @productId = 4

  SELECT pt.[Id]
        ,pt.[ProductName]
        ,pt.[Price]
  FROM core.product pt
  WHERE pt.[Id] = @productId

-- Abfrage um den Ausführungsplan anzusehen

 SELECT 
    cp.objtype   AS PlanType,
    cp.refcounts AS ReferenceCounts,
    cp.usecounts AS UseCounts,
    st.text      AS SQLBatch,
    cp.plan_handle
  FROM sys.dm_exec_cached_plans AS cp
  CROSS APPLY sys.dm_exec_query_plan (cp.plan_handle) AS qp
  CROSS APPLY sys.dm_exec_sql_text (cp.plan_handle) AS st;
