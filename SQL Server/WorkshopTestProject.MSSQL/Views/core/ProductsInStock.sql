CREATE VIEW [core].[ProductsInStock]
  AS 
  SELECT prod.Id
        ,prod.ProductName
        ,prod.Price
        ,stock.Quantity
    FROM [core].[Product] AS prod
   INNER JOIN [core].[Stock] AS stock ON stock.[ProductId] = prod.[Id]

