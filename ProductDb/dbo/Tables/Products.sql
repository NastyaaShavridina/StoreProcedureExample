CREATE TABLE [dbo].[Products]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Price] MONEY NOT NULL, 
    [Name] NVARCHAR(30) NOT NULL, 
    [Description] NVARCHAR(100) NOT NULL, 
    [Quantity] INT NOT NULL
)
