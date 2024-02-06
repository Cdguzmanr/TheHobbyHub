BEGIN
	INSERT INTO dbo.tblUser(Id, FirstName, LastName, Email, UserName, Image, PhoneNumber, Password )
	VALUES	(newid(), 'Alex', 'Rosas', 'arosas@gmail.com', 'Arosas', 'Test', '0000000000','Test'),
			(newid(), 'Test', 'test', 'Test', 'test', 'Test', 'Test','Test'),
			(newid(), 'Test', 'test', 'Test', 'test', 'Test', 'Test','Test')
END