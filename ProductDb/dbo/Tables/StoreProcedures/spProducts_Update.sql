CREATE PROCEDURE [dbo].[spProducts_Update] 
    @Id int, 
 @Price MONEY, 
 @Name NVARCHAR(30), 
 @Description NVARCHAR(100), 
 @Quantity INT 
AS 
BEGIN 
 UPDATE dbo.Products 
 SET Price = @Price, 
     [Name] = @Name, 
  [Description] = @Description, 
  Quantity = @Quantity 
   WHERE Id = @Id 
END