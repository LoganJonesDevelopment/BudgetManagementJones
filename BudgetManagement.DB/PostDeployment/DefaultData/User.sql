BEGIN
	INSERT INTO dbo.tblUser (Id, FirstName, LastName, Address, BillingAddress, City, State, ZipCode, Email, Password)
	VALUES
	(NEWID(), 'Owen', 'Sprangers', '3412 N Gillett St', '1874 Oakview Dr', 'Appleton', 'Wisconsin', 54914, 'osprangs417@gmail.com', 'Password'),
	(NEWID(), 'Logan', 'Jones', '773 South Commercial Street', '773 South Commercial Steet', 'Neenah', 'Wisconsin', 54956, '700146346@fvtc.edu', 'Test')
END