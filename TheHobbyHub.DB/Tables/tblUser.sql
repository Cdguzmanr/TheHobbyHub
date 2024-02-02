CREATE TABLE [dbo].[tblUser]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [FirstName] Varchar(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [Email] Varchar(50) NOT NULL, 
    [UserName] Varchar(50) NOT NULL, 
    [Image] Varchar(MAX) NOT NULL, 
    [PhoneNumber] VARCHAR(50) NOT NULL, 
    [Password]  Varchar(50) Not null,

)
