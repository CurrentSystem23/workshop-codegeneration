CREATE FUNCTION [core].[SpecialProducts]
(
  @productIds [core].[BigintArray] READONLY
)
RETURNS TABLE AS RETURN
(
  SELECT prod.Id
        ,prod.ProductName
        ,prod.Price
    FROM [core].[Product] AS prod
    WHERE ((NOT EXISTS(SELECT 1 FROM @productIds) OR prod.[Id] IN (SELECT [val] FROM @productIds)))
)
