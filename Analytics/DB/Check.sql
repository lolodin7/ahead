use Analytics


select * from Payments

select * from Orders

select * from Shipments




delete from Orders

select * from Orders


SET ANSI_WARNINGS  OFF;
-- Your insert TSQL here.

INSERT INTO [Orders] ([AmazonOrderId], [MerchantOrderId], [PurchaseDate], [LastUpdatedDate], [OrderStatus], [FullfilmentChannel], [SalesChannel], [OrderChannel], [Url], [ShipServiceLevel], [ProductName], [Sku], [Asin], [ItemStatus], [Quantity], [Currency], [ItemPrice], [ItemTax], [ShippingPrice], [ShippingTax], [GiftWrapPrice], [GiftWrapTax], [ItemPromotionDiscount], [ShipPromotionDiscount], [ShipCity], [ShipState], [ShipPostalCode], [ShipCountry], [PromotionIds], [IsBusinessOrder], [PurchaseOrderNumber], [PriceDesignation]) VALUES ('111-3360865-1735402', '111-3360865-1735402', '2018-11-21', '2018-11-21', 'Pending', 'Amazon', 'Amazon.com', '', 'USAmazon', 'SecondDay', 'Professional Grade Lavalier Lapel Microphone ­ Omnidirectional Mic with Easy Clip On System ­ Perfect for Recording Youtube / Interview / Video Conf', 'E3-2RHF-EO7C', 'B01AG56HYQ', 'Unshipped', 4, 'USD', 88.44, 0, 0, 0, 0, 0, 0, 0, 'LAS VEGAS', 'NV', '89119', 'US', '', 'C10349265', 'Business Price', '')
SET ANSI_WARNINGS ON;



INSERT INTO[Shipments] ([AmazonOrderId], [MerchantOrderId], [ShipmentId], [ShipmentItemId], [AmazonOrderItemId], [MerchantOrderItemId], [PurchaseDate], [PaymentsDate], [ShipmentDate], [ReportingDate], [BuyerEmail], [BuyerName], [BuyerPhoneNumber], [Sku], [ProductName], [QuantityShipped], [Currency], [ItemPrice], [ItemTax], [ShippingPrice], [ShippingTax], [GiftWrapPrice], [GiftWrapTax], [ShipServiceLevel], [RecipientName], [ShipAddress1], [ShipAddress2], [ShipAddress3], [ShipCity], [ShipState], [ShipPostalCode], [ShipCountry], [ShipPhoneNumber], [BillAddress1], [BillAddress2], [BillAddress3], [BillCity], [BillState], [BillPostalCode], [BillCountry], [ItemPromotionDiscount], [ShipPromotionDiscount], [Carrier], [TrackingNumber], [EstimatedArrivalDate], [FullfilmentCenterId], [FullfilmentChannel], [SalesChannel]) VALUES ('" + shipmentsList[i].AmazonOrderId + "', '" + shipmentsList[i].MerchantOrderId + "','" + shipmentsList[i].ShipmentId + "', '" + shipmentsList[i].ShipmentItemId + "', '" + shipmentsList[i].AmazonOrderItemId + "', '" + shipmentsList[i].MerchantOrderItemId + "', '" + shipmentsList[i].PurchaseDate.ToString("yyyy-MM-dd") + "', '" + shipmentsList[i].PaymentsDate.ToString("yyyy-MM-dd") + "', '" + shipmentsList[i].ShipmentDate.ToString("yyyy-MM-dd") + "', '" + shipmentsList[i].ReportingDate.ToString("yyyy-MM-dd") + "', '" + shipmentsList[i].BuyerEmail + "', '" + shipmentsList[i].BuyerName + "', '" + shipmentsList[i].BuyerPhoneNumber + "', '" + shipmentsList[i].Sku + "', '" + shipmentsList[i].ProductName + "', " + shipmentsList[i].QuantityShipped + ", '" + shipmentsList[i].Currency + "', " + shipmentsList[i].ItemPrice.ToString(specifier, CultureInfo.InvariantCulture) + ", " + shipmentsList[i].ItemTax.ToString(specifier, CultureInfo.InvariantCulture) + ", " + shipmentsList[i].ShippingPrice.ToString(specifier, CultureInfo.InvariantCulture) + ", " + shipmentsList[i].ShippingTax.ToString(specifier, CultureInfo.InvariantCulture) + ", " + shipmentsList[i].GiftWrapPrice.ToString(specifier, CultureInfo.InvariantCulture) + ", " + shipmentsList[i].GiftWrapTax.ToString(specifier, CultureInfo.InvariantCulture) + ", '" + shipmentsList[i].ShipServiceLevel + "', '" + shipmentsList[i].RecipientName + "', '" + shipmentsList[i].ShipAddress1 + "', '" + shipmentsList[i].ShipAddress2 + "', '" + shipmentsList[i].ShipAddress3 + "', '" + shipmentsList[i].ShipCity + "', '" + shipmentsList[i].ShipState + "', '" + shipmentsList[i].ShipPostalCode + "', '" + shipmentsList[i].ShipCountry + "', '" + shipmentsList[i].ShipPhoneNumber + "', '" + shipmentsList[i].BillAddress1 + "', '" + shipmentsList[i].BillAddress2 + "', '" + shipmentsList[i].BillAddress3 + "', '" + shipmentsList[i].BillCity + "', '" + shipmentsList[i].BillState + "', '" + shipmentsList[i].BillPostalCode + "', '" + shipmentsList[i].BillCountry + "', " + shipmentsList[i].ItemPromotionDiscount.ToString(specifier, CultureInfo.InvariantCulture) + ", " + shipmentsList[i].ShipPromotionDiscount.ToString(specifier, CultureInfo.InvariantCulture) + ", '" + shipmentsList[i].Carrier + "', '" + shipmentsList[i].TrackingNumber + "', '" + shipmentsList[i].EstimatedArrivalDate.ToString("yyyy-MM-dd") + "', '" + shipmentsList[i].FullfilmentCenterId + "', '" + shipmentsList[i].FullfilmentChannel + "', '" + shipmentsList[i].SalesChannel + "')

















/*
select * from ProductTypes
select * from KeywordCategory
select * from Products

select * from Semantics

select * from KeywordCategory

select * from SemCore

select * from FieldsLength

SELECT Title FROM Semantics WHERE SemanticsId = 4

select * from Semantics

SELECT * FROM Semantics WHERE ProductId = 2
SELECT * FROM Semantics

SELECT* FROM Products WHERE ProductId = 2

UPDATE [FieldsLength]
SET column1 = value1, column2 = value2, ...
WHERE condition; 

TitleLength, BulletsLength, BackendLength, DescriptionLength, SubjectMatterLength, OtherAttributesLength, IntendedUseLength
UPDATE [FieldsLength] [TitleLength] = " + TitleLength + ", [BulletsLength] = BulletsLength, [BackendLength] = BackendLength, [SubjectMatterLength] = SubjectMatterLength, [OtherAttributesLength] = OtherAttributesLength, [IntendedUseLength] = IntendedUseLength, [DescriptionLength] = DescriptionLength WHERE [ProductId] = ProductId

UPDATE [SemCore] SET [ProductTypeId] = , [CategoryId] = , [Keyword] = , [Value] = , [LastUpdated] =  WHERE [SemCoreId] = 

SELECT * FROM SemCore WHERE ProductTypeId = 1

select * from KeywordCategory
select * from ProductTypes
select * from SemCore

SELECT * FROM SemCore WHERE ProductTypeId = 1

SELECT * FROM Products

select * from Products
LEFT JOIN ProductTypes ON Products.ProductTypeId = ProductTypes.ProductTypeId

DELETE FROM Products where ProductId = 3

SELECT * FROM ProductTypes WHERE [ProductTypeId] > 0
SELECT * FROM Products LEFT JOIN ProductTypes ON Products.ProductTypeId = ProductTypes.ProductTypeId
SELECT * FROM Products LEFT JOIN ProductTypes ON Products.ProductTypeId = ProductTypes.ProductTypeId WHERE Products.ProductId > 0

SELECT * FROM SemCore WHERE ProductTypeId = 2
AND CategoryId = 3

rode lavalier microphone

SELECT * FROM SemCore WHERE Keyword = 'rode lavalier microphone'

UPDATE SemCore
Set CategoryId = 12 
WHERE Keyword = 'lavalier microphone xlr'

SELECT * FROM SemCore 
LEFT JOIN KeywordCategory ON SemCore.CategoryId = KeywordCategory.CategoryId
LEFT JOIN ProductTypes ON SemCore.ProductTypeId = ProductTypes.ProductTypeId 
WHERE SemCore.ProductTypeId = 1
AND SemCore.CategoryId = 2

select * from semantics
SELECT * FROM SemCore WHERE ProductTypeId  = 1
SELECT * FROM SemCore WHERE CategoryId = 2

SELECT * FROM SemCore WHERE ProductTypeId = 1 AND CategoryId = 6

select * from KeywordCategory
INSERT INTO [KeywordCategory] ([CategoryName], [ProductTypeId])
VALUES ('мир', 1)

SELECT * FROM Products WHERE ProductId = 2


UPDATE SemCore Set [ProductTypeId] = 1, [CategoryId] = 1, [Keyword] = 'lavalier microphone', [Value] = 0, [LastUpdated] = '2000-10-15 12:50:00' where SemCoreId = 1


SELECT * FROM SemCore

*/