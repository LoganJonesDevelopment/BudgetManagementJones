BEGIN
	INSERT INTO dbo.tblPayment(Id, Description)
	VALUES
	(NEWID(), 'Cash'),
	(NEWID(), 'Credit/Debit Card'),
	(NEWID(), 'Check'),
	(NEWID(), 'Bank Transfer')
END