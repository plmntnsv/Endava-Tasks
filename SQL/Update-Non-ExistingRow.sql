USE AdventureWorksLT2008R2

SET IDENTITY_INSERT SalesLT.SalesOrderDetail ON; 

UPDATE SalesLT.SalesOrderDetail 
SET 
SalesOrderDetailID = SalesOrderDetailID,
OrderQty = OrderQty,
ProductID = ProductID,
UnitPrice = UnitPrice,
UnitPriceDiscount = 0.50,
ModifiedDate = GETDATE()
WHERE rowguid = '6A61199F-48C9-4DD1-8FC1-5825A1C8C7AE'

SET IDENTITY_INSERT SalesLT.SalesOrderDetail OFF; 