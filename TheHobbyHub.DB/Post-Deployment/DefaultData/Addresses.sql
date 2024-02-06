BEGIN
	INSERT INTO dbo.tblAddress(Id, Address, City, State, Zip )
	VALUES	(newid(), '123 Main ST ', 'Appleton', 'WI', '54914'),
			(newid(), 'tedt', 'test', 'wi', 'test'),
			(newid(), 'test', 'test', 'wi', 'test')
END