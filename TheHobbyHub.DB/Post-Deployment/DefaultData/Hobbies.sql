BEGIN
	INSERT INTO dbo.tblHobby(Id, HobbyName, Description, Type, Image )
	VALUES	(newid(), 'Soccer ', 'test', 'OutDoor', 'test'),
			(newid(), 'Gym', 'test', 'Indoor', 'test'),
			(newid(), 'Bike Riding', 'test', 'Outdoor', 'test')
END