CREATE TABLE [dbo].[tblBillDestination]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [BusinessName] VARCHAR(50) NOT NULL, 
    [BusinessAddress] VARCHAR(50) NOT NULL
)
