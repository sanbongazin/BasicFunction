-- SELECT * FROM dbo.ProductDB 
-- WHERE Category1 IN (SELECT Category1=N'紅茶' WHERE ProdsName LIKE N'%放課後%')
-- SELECT * FROM dbo.ProductDB 
-- WHERE Category1 IN (SELECT Category1=N'ソフトドリンク' WHERE Category2 IN(SELECT Category2=N'%野菜ジュース%' WHERE ProdsName LIKE N'%スムージー%'))
-- INSERT INTO dbo.ProductDB (ProdsID,ProdsName,Category1) VALUES ('00:10:03',N'放課後ティータイム',N'紅茶');
SELECT * FROM dbo.ProductDB 
WHERE Category1 IN (SELECT Category1=N'ソフトドリンク' WHERE Category2 IN (SELECT Category2 = N'野菜ジュース' Where ProdsName LIKE N'%スムージー%'))
