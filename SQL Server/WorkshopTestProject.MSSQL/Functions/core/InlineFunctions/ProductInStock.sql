CREATE FUNCTION [core].[ProductInStock]
(
  @productId BIGINT
)
RETURNS TABLE AS RETURN
(
  SELECT prod.Id
        ,prod.ProductName
        ,prod.Price
        ,stock.Quantity
    FROM [core].[Product] AS prod
   INNER JOIN [core].[Stock] AS stock ON stock.[ProductId] = prod.[Id]
   WHERE (@productId IS NULL OR prod.[Id] = @productId)
)
