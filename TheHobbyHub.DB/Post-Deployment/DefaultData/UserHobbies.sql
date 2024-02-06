BEGIN
	INSERT INTO dbo.tblUserHobby(Id, UserId, HobbyId )
	VALUES	(newid(), newid(), newid()),
			(newid(), newid(), newid()),
			(newid(), newid(), newid())
END