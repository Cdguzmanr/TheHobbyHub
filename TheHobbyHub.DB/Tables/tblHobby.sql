CREATE TABLE [dbo].[tblHobby]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[HobbyName] Varchar(50) NOT NULL, 
    [Description] VARCHAR(MAX) NOT NULL, 
    [Type] Varchar(50) NOT NULL,
    [Image] Varchar(MAX) NOT NULL
    
)
