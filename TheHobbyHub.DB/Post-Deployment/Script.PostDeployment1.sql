/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
:r .\DefaultData\Addresses.sql
:r .\DefaultData\Companies.sql
:r .\DefaultData\Eventss.sql
:r .\DefaultData\Friends.sql
:r .\DefaultData\Hobbies.sql
:r .\DefaultData\Users.sql
:r .\DefaultData\UserHobbies.sql
