use AHEAD

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