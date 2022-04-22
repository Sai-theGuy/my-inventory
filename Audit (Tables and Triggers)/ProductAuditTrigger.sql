USE [LifelineMedical]
GO

CREATE TRIGGER TriggerProductInsert ON ProductListings
AFTER INSERT
AS
	INSERT ProductListingAudit
	SELECT 
		ListingID
		, GETDATE()
		, NULL
		, 'Insert'		
		, Price
		, Description
		, Type
		, StocksLeft
		, UnitMeasurement
	FROM inserted
GO

CREATE TRIGGER TriggerProductUpdate ON ProductListings
AFTER UPDATE
AS
	INSERT ProductListingAudit
	SELECT
		a.ListingID
		, NULL	
		, GETDATE()
		, 'Update'
		, b.Price
		, b.Description
		, b.Type
		, b.StocksLeft
		, b.UnitMeasurement			
	 FROM deleted a JOIN inserted b ON a.ListingID = b.ListingID
GO

CREATE TRIGGER TriggerProductDelete ON ProductListings
AFTER DELETE
AS
	INSERT ProductListingAudit
	SELECT 
		ListingID
		, NULL
		, GETDATE()
		, 'Delete'		
		, Price
		, Description
		, Type
		, StocksLeft
		, UnitMeasurement
	FROM deleted
GO