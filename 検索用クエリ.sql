-- 単純語句検索
SELECT * FROM dbo.ProductDB 
WHERE ProdsName Like N'%放課後%';

-- カテゴリーをいれての検索
SELECT * FROM dbo.ProductDB 
WHERE Category1 IN (SELECT Category1=N'紅茶' WHERE ProdsName LIKE N'%放課後%')

-- データを新規に代入
-- INSERT INTO dbo.ProductDB (ProdsID,ProdsName,Category1) VALUES ('00:10:03',N'放課後ティータイム',N'紅茶');

-- カテゴリーを二つにしての検索
SELECT * FROM dbo.ProductDB WHERE Category1 
IN (SELECT Category1=N'ソフトドリンク' WHERE Category2 IN (SELECT Category2 = N'野菜ジュース' Where ProdsName LIKE N'%スムージー%'));

-- テーブルをASPで実装する場合。もしかすると色付けはできない可能性あり。（表ごとに色付けなら奇数番のみという設定を施すことは可能かもしれないが透明度までは難しい。）
-- https://www.ipentec.com/document/asp-net-csharp-table-add-row-col