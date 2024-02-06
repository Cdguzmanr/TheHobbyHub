BEGIN
	INSERT INTO dbo.tblFriends(Id, UserId, CompanyId )
	VALUES	(newid(), newid(), newid()),
			(newid(), newid(), newid()),
			(newid(), newid(), newid())
END