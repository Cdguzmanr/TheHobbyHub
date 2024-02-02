BEGIN
	INSERT INTO dbo.tblHobby(Id, HobbyName, Description, Type, Image )
	VALUES	(1, 'Soccer ', 'test', 'OutDoor', 'test'),
			(2, 'Gym', 'test', 'Indoor', 'test'),
			(3, 'Bike Riding', 'test', 'Outdoor', 'test')
END