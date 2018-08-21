USE AdventureWorksLT2008R2

SET IDENTITY_INSERT SalesLT.SalesOrderDetail ON; 

UPDATE SalesLT.SalesOrderDetail 
SET 
SalesOrderID = SalesOrderID,
OrderQty = 2,
ProductID = ProductID,
UnitPrice = UnitPrice,
UnitPriceDiscount = 0.00,
ModifiedDate = GETDATE()
WHERE SalesOrderDetailID IN(110564)

SET IDENTITY_INSERT SalesLT.SalesOrderDetail OFF; 