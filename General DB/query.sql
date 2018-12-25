use ahead
go

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

SELECT * FROM Semantics WHERE ProductId = 1