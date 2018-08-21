IF db_id('Internship2018') IS NULL
	CREATE DATABASE [Internship2018]
GO

USE [Internship2018]

IF OBJECT_ID('dbo.Sales','U') IS NOT NULL
	DROP TABLE [dbo].[Sales]

IF OBJECT_ID('dbo.Sales', 'U') IS NULL
BEGIN
	CREATE TABLE [dbo].[Sales](
		[SalesOrderID] [int] NOT NULL,
		[SalesOrderDetailID] [int] NOT NULL,
		[OrderQty] [smallint] NOT NULL,
		[ProductID] [int] NOT NULL,
		[UnitPrice] [money] NOT NULL,
		[UnitPriceDiscount] [money] NOT NULL,
		[LineTotal]  AS (isnull(([UnitPrice]*((1.0)-[UnitPriceDiscount]))*[OrderQty],(0.0))),
		[rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
		[ModifiedDate] [datetime] NOT NULL)
END

IF OBJECT_ID('dbo.SalesSummary','U') IS NOT NULL
	DROP TABLE [dbo].[SalesSummary]

CREATE TABLE [SalesSummary] (
[ProductId] INT NOT NULL,
[Quantity] INT NOT NULL,
[FirstOrder] DateTime NOT NULL,
[LastOrder] DateTime NOT NULL
)
GO

IF db_id('AdventureWorksLT2008R2') IS NOT NULL
	USE [AdventureWorksLT2008R2]
GO

IF EXISTS (SELECT * FROM sys.triggers WHERE [name] = 'trg_after' AND [type] = 'TR') AND db_id('AdventureWorksLT2008R2') IS NOT NULL
	DROP TRIGGER [SalesLT].[trg_after];
GO

CREATE TRIGGER [SalesLT].[trg_after]
	ON [SalesLT].[SalesOrderDetail]
	AFTER INSERT, UPDATE, DELETE
	AS
	/*After insert*/
	IF EXISTS (SELECT * FROM [inserted]) AND NOT EXISTS(SELECT * FROM [deleted])
	BEGIN
		INSERT INTO [Internship2018].[dbo].[Sales]
		([SalesOrderID], 
		[SalesOrderDetailID],
		[OrderQty],
		[ProductID],
		[UnitPrice],
		[UnitPriceDiscount],
		[rowguid],
		[ModifiedDate])
		SELECT 
		i.[SalesOrderID], 
		i.[SalesOrderDetailID],
		i.[OrderQty],
		i.[ProductID],
		i.[UnitPrice],
		i.[UnitPriceDiscount],
		i.[rowguid],
		i.[ModifiedDate]
		FROM [inserted] i
	END

	/*After update*/
	IF EXISTS(SELECT * FROM [inserted]) AND EXISTS (SELECT * FROM [deleted])
	BEGIN
		IF NOT EXISTS(SELECT * FROM [Internship2018].[dbo].[Sales] WHERE [rowguid] IN (SELECT [rowguid] FROM [inserted]))
		BEGIN
			INSERT INTO [Internship2018].[dbo].[Sales]
			([SalesOrderID], 
			[SalesOrderDetailID],
			[OrderQty],
			[ProductID],
			[UnitPrice],
			[UnitPriceDiscount],
			[rowguid],
			[ModifiedDate])
			SELECT 
			i.[SalesOrderID], 
			i.[SalesOrderDetailID],
			i.[OrderQty],
			i.[ProductID],
			i.[UnitPrice],
			i.[UnitPriceDiscount],
			i.[rowguid],
			i.[ModifiedDate]
			FROM [inserted] i
		END
	ELSE
		BEGIN
			UPDATE [Internship2018].[dbo].[Sales]
			SET [SalesOrderID] = i.[SalesOrderID], 
			[SalesOrderDetailID] = i.[SalesOrderDetailID],
			[OrderQty] = i.[OrderQty],
			[ProductID] = i.[ProductID],
			[UnitPrice] = i.[UnitPrice],
			[UnitPriceDiscount] = i.[UnitPriceDiscount],
			[rowguid] = i.[rowguid],
			[ModifiedDate] = i.[ModifiedDate]
			FROM [inserted] AS i
			WHERE [Internship2018].[dbo].[Sales].[rowguid] IN (SELECT [rowguid] FROM [inserted])
		END
	END

	/*After delete*/
	IF EXISTS (SELECT * FROM [deleted]) AND NOT EXISTS(SELECT * FROM [inserted])
	BEGIN
		DELETE FROM [Internship2018].[dbo].[Sales] 
		WHERE [rowguid] IN (SELECT [rowguid] FROM [deleted]);
	END
GO

USE [Internship2018]
GO

IF EXISTS ( SELECT  * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID(N'sp_SalesSummarization') AND TYPE IN ( N'P', N'PC' ))
	DROP PROCEDURE [sp_SalesSummarization]
GO

--CREATE PROCEDURE
CREATE PROCEDURE [sp_SalesSummarization]
	AS
	IF EXISTS (SELECT * FROM [SalesSummary] WHERE [ProductId] NOT IN(SELECT [ProductId] FROM [Sales]))
	BEGIN
		UPDATE [SalesSummary]
			SET
			[Quantity] = 0,
			[FirstOrder] = GETDATE(),
			[LastOrder] = GETDATE()
			FROM [SalesSummary]
			WHERE [ProductId] NOT IN(SELECT [ProductId] FROM [Sales])
	END

	UPDATE [SalesSummary]
		SET
		[Quantity] = s.[SumOrder],
		[FirstOrder] = s.[MinModDate],
		[LastOrder] = s.[MaxModDate]
		FROM [SalesSummary] AS ssum
		INNER JOIN (SELECT [ProductID], SUM(OrderQty) AS [SumOrder], MIN(ModifiedDate) AS [MinModDate], MAX(ModifiedDate) AS [MaxModDate] FROM [Sales] GROUP BY [ProductID]) AS s
		ON ssum.[ProductID] = s.[ProductID]	
GO

IF EXISTS (SELECT * FROM sys.triggers WHERE [name] = 'trg_after_sales' AND [type] = 'TR')
	DROP TRIGGER [dbo].[trg_after_sales];
GO

CREATE TRIGGER [dbo].[trg_after_sales]
	ON [dbo].[Sales]
	AFTER INSERT, UPDATE, DELETE
	AS
	/*After insert*/
	IF EXISTS (SELECT * FROM [inserted]) AND NOT EXISTS(SELECT * FROM [deleted]) AND NOT EXISTS(SELECT [ProductId] FROM [SalesSummary] WHERE [ProductId] IN(SELECT [ProductId] FROM [inserted]))
	BEGIN
		INSERT INTO [dbo].[SalesSummary]
		([ProductId],
		[Quantity],
		[FirstOrder],
		[LastOrder])
		SELECT 
		DISTINCT i.[ProductID],
		0,
		GETDATE(),
		GETDATE()
		FROM [inserted] i;
	END
	EXEC [sp_SalesSummarization]

	/*After update*/
	IF EXISTS(SELECT * FROM [inserted]) AND EXISTS (SELECT * FROM [deleted])
	BEGIN
		UPDATE [SalesSummary]
			SET 
			[LastOrder] = GETDATE()
			FROM [inserted] as i
			WHERE [dbo].[SalesSummary].[ProductId] IN (SELECT [ProductId] FROM [inserted])
			EXEC [sp_SalesSummarization]
	END

	/*After delete*/
	IF EXISTS (SELECT * FROM [deleted]) AND NOT EXISTS(SELECT * FROM [inserted])
	BEGIN
		EXEC [sp_SalesSummarization]
	END
GO