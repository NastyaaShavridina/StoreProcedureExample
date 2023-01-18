CREATE PROCEDURE [dbo].[spProducts_Create] 
 @Price MONEY, 
 @Name NVARCHAR(30), 
 @Description NVARCHAR(100), 
 @Quantity INT 
AS 
begin 
  INSERT INTO dbo.Products (Price, [Name], [Description], Quantity) 
  VALUES(@Price, @Name, @Description, @Quantity) 
  SELECT CAST(scope_identity() AS INT); 
end