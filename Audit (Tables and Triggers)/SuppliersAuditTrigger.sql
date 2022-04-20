USE [LifelineMedical(Actual)]
GO

CREATE TRIGGER TriggerInsertSuppliers ON Suppliers
AFTER INSERT
AS
	INSERT SupplierAudit
	SELECT 
		SupplierID
		, GETDATE()
		, NULL
		, 'Insert'
		, ContactPerson
		, Address
		, Type
	FROM inserted
GO

CREATE TRIGGER TriggerUpdateSuppliers ON Suppliers
AFTER UPDATE
AS
	INSERT SupplierAudit
	SELECT 
		a.SupplierID
		, NULL
		, GETDATE()
		, 'Update'
		, b.ContactPerson
		, b.Address
		, b.Type
	FROM deleted a JOIN inserted b ON a.SupplierID = b.SupplierID
GO

CREATE TRIGGER TriggerDeleteSuppliers ON Suppliers
AFTER DELETE
AS
	INSERT SupplierAudit
	SELECT 
		SupplierID
		, NULL
		, GETDATE()
		, 'Delete'
		, ContactPerson
		, Address
		, Type
	FROM deleted
GO