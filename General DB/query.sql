USE AHEAD
GO

select COUNT(orderid) from payments where sku = ''

select * from getUserId ('114-8714911-9232219')
select * from payments where sku = 'HR-9KQ2-IPD9'
select SUM(Total) from payments where [Description] = 'Cost of advertising'


select sum(quantity), sum (total) from payments where [type] = 'adjustment' and sku = 'E3-2RHF-EO7C' and [Description] = 'FBA Inventory Reimbursement - Customer Return' and [date] between '2018-01-01' and '2018-12-07'
select sum(quantity), sum (total) from payments where [type] = 'adjustment' and sku = 'E3-2RHF-EO7C' and [Description] = 'FBA Inventory Reimbursement - Damaged:Warehouse' and [date] between '2018-01-01' and '2018-12-07'
select sum(quantity), sum (total) from payments where [type] = 'adjustment' and sku = 'E3-2RHF-EO7C' and [Description] = 'FBA Inventory Reimbursement - General Adjustment' and [date] between '2018-01-01' and '2018-12-07'

select sum(quantity), sum (total) from payments where [type] = 'chargeback refund' and sku = 'E3-2RHF-EO7C' and [date] between '2018-01-01' and '2018-12-07'

select sum(quantity), sum (total) from payments where [type] = 'order' and sku = 'E3-2RHF-EO7C' and [date] between '2018-01-01' and '2018-12-07'

select sum(quantity), sum (total) from payments where [type] = 'refund' and sku = 'E3-2RHF-EO7C' and [date] between '2018-01-01' and '2018-12-27'


/* for marketplace 
select sum (total) from payments where [type] = 'fba inventory fee' and [description] = 'FBA Inventory Storage Fee' and [date] between '2018-01-01' and '2018-11-27'
select sum (total) from payments where [type] = 'fba inventory fee' and [description] = 'FBA Long-Term Storage Fee' and [date] between '2018-01-01' and '2018-11-27'
select sum (total) from payments where [type] = 'fba inventory fee' and [description] = 'FBA Removal Order: Disposal Fee' and [date] between '2018-01-01' and '2018-11-27'
select sum (total) from payments where [type] = 'fba inventory fee' and [description] = 'FBA Removal Order: Return Fee' and [date] between '2018-01-01' and '2018-11-27'

select sum (total) from payments where [type] = 'Lightning Deal Fee' and [date] between '2018-01-01' and '2018-11-27'

select sum (total) from payments where [type] = 'Service Fee' and [description] = 'Cost of Advertising' and [date] between '2018-01-01' and '2018-11-27'
select sum (total) from payments where [type] = 'Service Fee' and [description] = 'SellerPayments_Report_Fee_Subscription' and [date] between '2018-01-01' and '2018-11-27'

select sum (total) from payments where [type] = 'transfer' and [date] between '2018-01-01' and '2018-11-27'

select sum (total) from payments where [type] = 'order retrocharge' and [description] = 'Base Tax' and [date] between '2018-01-01' and '2018-11-27'
select sum (total) from payments where [type] = 'order retrocharge' and [description] = 'Shipping Tax' and [date] between '2018-01-01' and '2018-11-27'

select * from payments where [type] = '' and [date] between '2018-01-01' and '2018-11-27'
*/
select sum(quantity), sum(total) from payments where [type] = '' and [date] between '2018-01-01' and '2018-11-27'


SELECT * FROM Marketplace WHERE [MarketplaceId] > 0

select * from Payments where Date = '2018-01-01' and sku = 'E3-2RHF-EO7C'


select sum(quantity), sum (total) from payments where [type] = 'order' and sku = 'E3-2RHF-EO7C' and [date] = '2018-11-03'

select sum(quantity), sum (total) from payments where [type] = 'refund' and sku = 'E3-2RHF-EO7C' and [date] between '2018-11-01' and '2018-11-07'

select * from keywordcategory

SELECT * FROM KeywordCategory WHERE ProductTypeId = 9

select * from producttypes

SELECT * FROM Products LEFT JOIN ProductTypes ON Products.ProductTypeId = ProductTypes.ProductTypeId LEFT JOIN Marketplace ON Products.MarketPlaceId = Marketplace.MarketPlaceId WHERE Products.ProductId > 0


SELECT * FROM KeywordCategory LEFT JOIN ProductTypes ON KeywordCategory.CategoryId = ProductTypes.ProductTypeId WHERE CategoryId > 0 

select * from semantics

SELECT * FROM KeywordCategory LEFT JOIN ProductTypes ON KeywordCategory.ProductTypeId = ProductTypes.ProductTypeId WHERE CategoryId > 0 AND KeywordCategory.ProductTypeId = 1

SELECT * FROM Products WHERE [ProductId] = 1

SELECT UpdateDate FROM Semantics WHERE ProductId = 1
select * from semcore where CategoryId = 2 or CategoryId = 6

SELECT * FROM SemCore WHERE ProductTypeId = 1 AND (CategoryId = 1 OR CategoryId = 2)


SELECT * FROM SemCore WHERE ProductTypeId = 1 AND (CategoryId = 1)

INSERT INTO [Semantics] ([ProductId], [Title], [Bullet1], [Bullet2], [Bullet3], [Bullet4], [Bullet5], [Backend], [Description], [OtherAttributes1], [OtherAttributes2], [OtherAttributes3], [OtherAttributes4], [OtherAttributes5], [IntendedUse1], [IntendedUse2], [IntendedUse3], [IntendedUse4], [IntendedUse5], [SubjectMatter1], [SubjectMatter2], [SubjectMatter3], [SubjectMatter4], [SubjectMatter5], [UpdateDate], [Notes], [UsedKeywords]) VALUES (1, 'Test semanticsAgain', 'Bul4', 'Bul4', 'Bul4', 'Bul4', 'Bul4', 'Backend4', 'Descr444444', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '27.12.2018 15:43:20', 'Notes4', 'lapel microphone|2|lavalier microphone|0|')


SELECT * FROM Products LEFT JOIN ProductTypes ON Products.ProductTypeId = ProductTypes.ProductTypeId LEFT JOIN Marketplace ON Products.MarketPlaceId = Marketplace.MarketPlaceId WHERE Products.ProductId > 0

SELECT * FROM Indexing

UPDATE Indexing set [Date] = '2019-02-10 00:00:00.000' WHERE [ASIN] = 'B01LZBEH3W'
UPDATE Indexing set [Date] = '2019-02-08 00:00:00.000' WHERE [ASIN] = 'B01BNGAHCA'
UPDATE Indexing set [Date] = '2019-02-09 00:00:00.000' WHERE [ASIN] = 'B01DIU9FP4'

SELECT [Notes] FROM [Indexing] WHERE ProductId = 1 AND [Date] = '2018-12-27'

INSERT INTO [Indexing] ([ProductId], [ASIN], [Date], [Status], [Notes]) VALUES (11, 'B01MG2BEVZ', '2019-40-02', 'Not Ok', '@something wrong@@@@@@')


SELECT * FROM Products WHERE [ProductId] = 1

SELECT COUNT(SemanticsId) FROM semantics WHERE ProductId = 6

SELECT COUNT(SemanticsId) FROM semantics WHERE [ProductId] = 1

select * from semantics where productid = 8
select * from FieldsLength where productid = 8

SELECT * FROM SemCore LEFT JOIN KeywordCategory ON SemCore.CategoryId = KeywordCategory.CategoryId LEFT JOIN ProductTypes ON SemCore.ProductTypeId = ProductTypes.ProductTypeId WHERE KeywordCategory.CategoryId > 0 AND SemCore.ProductTypeId > 0
select * from KeywordCategory




SELECT COUNT(SemanticsId) FROM semantics WHERE [ProductId] = 14

SELECT COUNT(SemanticsId) FROM semantics WHERE [ProductId] = getProductIdByASIN(1)

SELECT * FROM Semantics
SELECT * FROM [FieldsLength]  

INSERT INTO [FieldsLength] ([TitleLength], [BulletsLength], [BackendLength], [SubjectMatterLength], [OtherAttributesLength], [IntendedUseLength], [DescriptionLength], [ProductId], [CountBulSpaces]) 
VALUES (200, 500, 250, 50, 100, 100, 1999, 14, 'false')

UPDATE [FieldsLength] SET [CountBulSpaces] = 1
SELECT * FROM FieldsLength WHERE ProductId = 14

select * from semcore where keyword = 'miNi'



SELECT * FROM Products LEFT JOIN ProductTypes ON Products.ProductTypeId = ProductTypes.ProductTypeId LEFT JOIN Marketplace ON Products.MarketPlaceId = Marketplace.MarketPlaceId WHERE Products.ProductId > 0 and Products.ActiveStatus = 'false'

delete from 

select * from semcore where [semcoreid] = 93

SELECT * FROM SemCore WHERE [Keyword] = 'mini microphone'
SELECT * FROM SemCore WHERE [Keyword] = 'mic mini'
SELECT * FROM SemCore WHERE [Keyword] = 'mini mic'

select * from products




SELECT ProductId FROM Products Where [ASIN] = 'B01AG56HYQ'

select * from Marketplace

SELECT [SemCoreId] FROM [SemCore] WHERE [Keyword] = 'iphone microphone for video iphone 7'


INSERT INTO [SemCoreArchive] ([ProductTypeId], [CategoryId], [Keyword], [SemCoreId], [ValuesAndDates]) VALUES (1, 1, 'iphone microphone for video iphone 7', 0, '')

SELECT * FROM SemCoreArchive

SELECT * FROM SemCoreArchive LEFT JOIN KeywordCategory ON SemCoreArchive.CategoryId = KeywordCategory.CategoryId LEFT JOIN ProductTypes ON SemCoreArchive.ProductTypeId = ProductTypes.ProductTypeId WHERE KeywordCategory.CategoryId > 0 AND SemCoreArchive.ProductTypeId > 0

update SemCoreArchive set ValuesAndDates = '1254&02.02.2019 18:42:43@324&02.03.2019 19:42:43@5484&02.03.2019 17:42:43@' where SemCoreId = 0


UPDATE [SemCoreArchive] SET [ProductTypeId] = 1, [CategoryId] = 1, [Keyword] = 'lav',  [ValuesAndDates] = '1234&15.02.2019 12:41:52@1&13.02.2019 12:42:09@2222&14.02.2019 12:58:09@3333&17.02.2019 12:58:09@' WHERE [SemCoreId] = 0
UPDATE [SemCoreArchive] SET [ProductTypeId] = 1, [CategoryId] = 1, [Keyword] = ' lav',  [ValuesAndDates] = '1&16.02.2019 12:59:07@1234&17.02.2019 12:59:23@' WHERE [SemCoreId] = 4


SELECT * FROM [User]

UPDATE [User] Set [Hash] = , [Salt] = 