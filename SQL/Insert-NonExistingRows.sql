USE AdventureWorksLT2008R2

SET IDENTITY_INSERT SalesLT.SalesOrderDetail ON; 

INSERT INTO SalesLT.SalesOrderDetail 
(SalesOrderID, SalesOrderDetailID, OrderQty, ProductID, UnitPrice, UnitPriceDiscount, rowguid, ModifiedDate)
VALUES
(71774, 110564, 1, 836, 356.898, 0.00, NEWID(), GETDATE()),
(71774, 110565, 2, 836, 356.653, 0.50, NEWID(), GETDATE()),
(71774, 110566, 3, 907, 356.789, 0.00, NEWID(), GETDATE()),
(71774, 110567, 2, 907, 356.898, 0.30, NEWID(), GETDATE()),
(71774, 110568, 1, 905, 356.356, 0.10, NEWID(), GETDATE());

SET IDENTITY_INSERT SalesLT.SalesOrderDetail OFF; 
					