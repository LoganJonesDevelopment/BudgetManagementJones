CREATE PROCEDURE [dbo].[sp_DataGrid]
AS
	SELECT u.Id, u.FirstName, u.LastName, u.BillingAddress, bd.BusinessName, bd.BusinessAddress, b.BillAmount, b.DueDate
	FROM tblUser u
	JOIN tblBill b on u.Id = b.UserId
	JOIN tblBillDestination bd on bd.Id = b.BillDestinationId
RETURN 0