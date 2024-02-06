BEGIN
	INSERT INTO dbo.tblEvent(Id, AddressId, UserId, CompanyId, HobbyId, Description, Image, Date)
	VALUES	(newid(), newid(), newid(), newid(), newid() ,'test', 'test', '2022-05-08'),
			(newid(), newid(), newid(), newid(), newid(), 'test', 'test', '2022-05-08'),
			(newid(), newid(), newid(), newid(), newid(), 'test', 'test', '2022-05-08')
END