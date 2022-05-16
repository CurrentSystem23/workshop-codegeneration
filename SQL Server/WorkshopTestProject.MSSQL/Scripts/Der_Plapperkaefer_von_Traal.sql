--Databases auslesen
SELECT * 
FROM master.dbo.sysdatabases

-- Schemas auslesen
select 'WorkshopTestProjectDb' as database_name,                  
s.name COLLATE DATABASE_DEFAULT as schema_name            
,s.*
from [WorkshopTestProjectDb].sys.schemas AS s
inner join sys.database_principals AS pr  ON pr.principal_id = s.principal_id
WHERE type = 'U'
order by database_name, schema_name

select s.name as schema_name, 
       s.schema_id,
       u.name as schema_owner
       --,s.*
       --,u.*
  from sys.schemas s
 inner join sys.sysusers u on u.uid = s.principal_id
order by s.name;

--Tabellen auslesen
SELECT s.name as schema_name, 
       o.name as table_name,
       o.xtype as typ,
       o.*,
       s.*
FROM SYS.SYSOBJECTS o
INNER JOIN SYS.SCHEMAS s ON o.UID = s.SCHEMA_ID
WHERE xtype = 'U';

--Tabellenspalten auslesen
SELECT *
FROM information_schema.columns;





--DB Objecte
SELECT *
 FROM SYSOBJECTS
WHERE xtype = 'U';
GO

/*
AF : Aggregate function (CLR)
C : CHECK Constraint
D : Default or DEFAULT Constraint
F : FOREIGN KEY Constraint
FN : Scalar Function
FS : Assembly (CLR) Scalar-Function
FT : Assembly (CLR) Table-Valued Function
IF : In-lined Table Function
IT : Internal Table
L : Log
P : Stored Procedure
PC : Assembly (CLR) Stored Procedure
PK : PRIMARY KEY Constraint (Type is K)
RF : Replication Filter Stored Procedure
S : System Table
SN : Synonym
SQ : Service Queue
TA : Assembly (CLR) DML Trigger
TF : Table Function
TR : SQL DML Trigger
TT : Table Type
U : User Table
UQ : UNIQUE Constraint
V : View
X : Extended Stored Procedure
*/

--Alle Spalten auslesen
SELECT *
FROM information_schema.columns;

SELECT table_catalog,
       table_schema,
       table_name,
       column_name,
       column_default,
       is_nullable,
       data_type,
       character_maximum_length,
       character_octet_length,
       numeric_precision,
       numeric_precision_radix,
       numeric_scale,
       datetime_precision
FROM information_schema.columns
ORDER BY table_catalog, table_schema, table_name, ordinal_position;


--Functions ausgeben
SELECT schema_name(obj.schema_id) as schema_name,
       obj.name as function_name,
       CASE type
            WHEN 'FN' THEN 'SQL scalar function'
            WHEN 'TF' THEN 'SQL inline table-valued function'
            WHEN 'IF' THEN 'SQL table-valued-function'
       END AS type,
       SUBSTRING(par.parameters, 0, LEN(par.parameters)) as parameters,
       TYPE_NAME(ret.user_type_id) as return_type,
       mod.definition
  FROM sys.objects obj
 INNER JOIN sys.sql_modules mod ON mod.object_id = obj.object_id
 CROSS APPLY (SELECT p.name + ' ' + TYPE_NAME(p.user_type_id) + ', ' 
                FROM sys.parameters p
               WHERE p.object_id = obj.object_id 
                 AND p.parameter_id != 0 
                 FOR XML PATH ('') ) AS par (parameters)
  LEFT JOIN sys.parameters ret ON obj.object_id = ret.object_id AND ret.parameter_id = 0
 WHERE obj.type in ('FN', 'TF', 'IF')
 ORDER BY schema_name,
          function_name;


--Returnfelder einer Funktion ermitteln
SELECT *
FROM sys.columns
WHERE object_id=object_id('core.ProductInStock');

SELECT s.name AS schema_name,
       o.name AS function_name,
       c.name AS column_name,
       c.column_id,
       t.name AS type,
       t.max_length,
       t.is_nullable
  FROM sys.columns AS c
 INNER JOIN sys.types AS t ON  t.system_type_id = c.system_type_id
 INNER JOIN sys.sysobjects o ON o.id = c.object_id
 INNER JOIN sys.schemas s ON o.UID = s.SCHEMA_ID
 WHERE s.name = 'core'
   AND o.name = 'ProductInStock'
ORDER BY o.name, c.column_id