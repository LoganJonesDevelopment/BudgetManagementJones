BEGIN
	INSERT INTO dbo.tblBillDestination(Id, BusinessName, BusinessAddress)
	VALUES
	(NEWID(), 'Spectrum', '133 N Mall Dr'),
	(NEWID(), 'WE Energies', '800 S Lynndale Dr')
END