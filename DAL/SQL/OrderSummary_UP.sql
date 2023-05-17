CREATE OR ALTER PROCEDURE OrderSummary
@id int
AS
BEGIN

	SELECT o.Id, o.CreatedDate, COUNT(p.Id) AS Count
	FROM [Order] as o
	JOIN Product as p ON o.Id = p.OrdersId
	WHERE o.Id = @id
	GROUP BY o.Id, o.[CreatedDate]	

END