BEGIN
	DECLARE @UserOne uniqueidentifier;
	SELECT @UserOne = Id FROM tblUser WHERE FirstName = 'Owen';

	DECLARE @UserTwo uniqueidentifier;
	SELECT @UserTwo = Id FROM tblUser WHERE FirstName = 'Logan'

	DECLARE @DestinationOne uniqueidentifier;
	SELECT @DestinationOne = Id FROM tblBillDestination WHERE BusinessName = 'Spectrum'
	
	DECLARE @DestinationTwo uniqueidentifier;
	SELECT @DestinationTwo = Id FROM tblBillDestination WHERE BusinessName = 'WE Energies'

	INSERT INTO dbo.tblBill (Id, UserId, DueDate, BillAmount, BillDestinationId, PaidOnTime)
	VALUES
	(NEWID(), @UserOne, '4/22/2019', 45, @DestinationOne, 1),
	(NEWID(), @UserTwo, '5/22/2019', 75, @DestinationTwo, 1)
END