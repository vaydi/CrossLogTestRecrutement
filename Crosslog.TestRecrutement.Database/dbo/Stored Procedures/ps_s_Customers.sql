

CREATE PROCEDURE ps_s_Customers

AS
BEGIN

WITH ProductsOrder
AS
(SELECT	o.CustomerId
	   ,o.OrderNumber
	   ,SUM(ol.Quantity) AS OrderCount
	   ,SUM(p.Price * ol.Quantity) AS TotalAmount
	FROM Orders o (NOLOCK)
	INNER JOIN OrderLines ol (NOLOCK) ON ol.OrderId = o.OrderId
	INNER JOIN Products p (NOLOCK) ON p.ProductId = ol.ProductId
	GROUP BY o.CustomerId, o.OrderNumber)

SELECT
	c.CustomerId
   ,c.LastName
   ,c.FirstName
   ,c.Phone
   ,c.Address
   ,c.ZipCode
   ,c.City
   ,c.Email
   ,po.OrderNumber
   ,CASE
		WHEN po.OrderCount IS NULL THEN 0
		ELSE po.OrderCount
	END AS OrderCount
   ,CASE
		WHEN po.TotalAmount IS NULL THEN 0
		ELSE po.TotalAmount
	END AS TotalAmount
FROM Customers c (NOLOCK)
LEFT JOIN ProductsOrder po	ON c.CustomerId = po.CustomerId

END