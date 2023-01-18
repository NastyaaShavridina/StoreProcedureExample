CREATE PROCEDURE [dbo].[spProducts_GetOrderByPrice] 
   @IsDesc BIT 
AS 
begin 
 IF @IsDesc = 0 
 SELECT * FROM dbo.Products 
 ORDER BY Price 
 else 
    SELECT * FROM dbo.Products 
 ORDER BY Price DESC 
end