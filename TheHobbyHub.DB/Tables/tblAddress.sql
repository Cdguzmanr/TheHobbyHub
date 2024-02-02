CREATE TABLE [dbo].[tblAddress]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[Address] Varchar(50) NOT NULL, 
    [City] VARCHAR(10) NOT NULL, 
    [State] Varchar(20) NOT NULL, 
    [Zip] Varchar(10) NOT NULL
)
