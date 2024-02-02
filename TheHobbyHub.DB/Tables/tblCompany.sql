CREATE TABLE [dbo].[tblCompany]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[CompanyName] Varchar(50) NOT NULL, 
    [Image] VARCHAR(MAX) NOT NULL, 
    [UserName] Varchar(50) NOT NULL, 
    [Password] Varchar(50) NOT NULL, 
    [AddressId] UNIQUEIDENTIFIER NOT NULL,
)
