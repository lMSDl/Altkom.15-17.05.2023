CREATE VIEW View_OrderSummary AS
    SELECT o.Id, o.CreatedDate, COUNT(p.Id) AS Count
    FROM [Order] as o
    JOIN Product as p ON o.Id = p.OrdersId
    GROUP BY o.Id, o.[CreatedDate]    