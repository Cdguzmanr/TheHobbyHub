BEGIN
	INSERT INTO dbo.tblCompany(Id, CompanyName, Image, UserName, Password, AddressId)
	VALUES	(newid(), 'HobbyHub ', 'test', 'HobbyHub', 'test', newid()),
			(newid(), 'test', 'test', 'test', 'test', newid()),
			(newid(), 'test', 'test', 'test', 'test', newid())
END