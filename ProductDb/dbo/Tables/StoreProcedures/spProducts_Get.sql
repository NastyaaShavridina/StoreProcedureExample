CREATE PROCEDURE [dbo].[spProducts_Get] 
  @Id int 
AS 
begin 
 SELECT * FROM dbo.[Products] 
 WHERE Id = @Id 
end