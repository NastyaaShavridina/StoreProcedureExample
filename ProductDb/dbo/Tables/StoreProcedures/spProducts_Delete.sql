CREATE PROCEDURE [dbo].[spProducts_Delete] 
 @Id INT 
AS 
begin 
    DELETE FROM dbo.[Products] 
 WHERE Id = @Id 
end