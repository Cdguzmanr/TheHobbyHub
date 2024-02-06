/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
DROP TABLE IF EXISTS dbo.tblAddress
DROP TABLE IF EXISTS dbo.tblCompany
DROP TABLE IF EXISTS dbo.tblEvent
DROP TABLE IF EXISTS dbo.tblFriends
DROP TABLE IF EXISTS dbo.tblHobby
DROP TABLE IF EXISTS dbo.tblUser
DROP TABLE IF EXISTS dbo.tblUserHobby