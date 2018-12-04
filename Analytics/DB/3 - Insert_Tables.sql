USE AHEAD
GO







/*INSERT INTO [Payments] ([Date], [OrderId], [SKU], [TransactionType], [PaymentType], [PaymentDetail], [Amount], [Quantity], [ProductTitle])
VALUES (CURRENT_TIMESTAMP, '112-7188472-0864253', 'E3-2RHF-EO7C', 'Order Payment', 'Amazon fees', 'FBA Pick & Pack Fee', -3.19, 0,'Professional Grade Lavalier Lapel Microphone � Omnidirectional Mic with Easy Clip On System � Perfect for Recording Youtube / Interview / Video Conf')
GO*/


INSERT INTO [Payments] ([Date], [OrderId], [SKU], [TransactionType], [PaymentType], [PaymentDetail], [Amount], [Quantity], [ProductTitle])
VALUES (CURRENT_TIMESTAMP,'112-7188472-0864253', 'E3-2RHF-EO7C', 'Order Payment', 'Amazon fees', 'FBA Pick & Pack Fee', -3.19, 0,'Professional Grade Lavalier Lapel Microphone � Omnidirectional Mic with Easy Clip On System � Perfect for Recording Youtube / Interview / Video Conf')
GO

INSERT INTO [Payments] ([Date], [OrderId], [SKU], [TransactionType], [PaymentType], [PaymentDetail], [Amount], [Quantity], [ProductTitle]) VALUES ('2018-11-19', '113-3314951-9904206', 'E3-2RHF-EO7C', 'Other', 'FBA Inventory Reimbursement - Customer Return', '', 17.2, 1, 'Professional Grade Lavalier Lapel Microphone � Omnidirectional Mic with Easy Clip On System � Perfect for Recording Youtube / Interview / Video Conference / Podcast / Voice Dictation / iPhone/ASMR')























/*
SET NOCOUNT ON

DELETE FROM [FieldsLength]
GO
DELETE FROM [SemCore]
GO
DELETE FROM [KeywordCategory]
GO
DELETE FROM [Semantics]
GO
DELETE FROM [Products]
GO
DELETE FROM [ProductTypes]
GO


USE AHEAD
GO

/*         -- [ProductTypes] --             */
INSERT INTO [ProductTypes] ([TypeName])
VALUES ('������������� ������')

INSERT INTO [ProductTypes] ([TypeName])
VALUES ('���������')

INSERT INTO [ProductTypes] ([TypeName])
VALUES ('�������')

INSERT INTO [ProductTypes] ([TypeName])
VALUES ('����')

INSERT INTO [ProductTypes] ([TypeName])
VALUES ('�������� �������')

INSERT INTO [ProductTypes] ([TypeName])
VALUES ('������� ��� �����')

INSERT INTO [ProductTypes] ([TypeName])
VALUES ('����������')



/*         -- [Products] --             */
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId])
VALUES ('����� �����������', '-', '-', 0)

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId])
VALUES ('PDW Main Mic', 'B01AG56HYQ', 'E3-2RHF-EO7C', 1)

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId])
VALUES ('Walnut Knife Holder', 'B07DW5X3LY', 'adhhldrwlnt', 2)

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId])
VALUES ('Acacia Knife Set', 'B07DWWMW8H', 'adhknfstlt', 3)

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId])
VALUES ('YouMic Main Mic', 'B01E3L1ESS', '8R-MO3B-ZV8H', 1)


/*         -- [Semantics] --             */
INSERT INTO [Semantics] ([ProductId], [Title], [Bullet1], [Bullet2], [Bullet3], [Bullet4], [Bullet5], [Backend], [Description], [UpdateDate], [Notes], [UsedKeywords])
VALUES (3, 'Title1 Big title', 'Bul1', 'Bul1', 'Bul1', 'Bul1', 'Bul1', 'Backend1', 'Descr11111111', '2018-02-02 11:11:00.000', 'Notes1', 'UsedKeywords1')

INSERT INTO [Semantics] ([ProductId], [Title], [Bullet1], [Bullet2], [Bullet3], [Bullet4], [Bullet5], [Backend], [Description], [UpdateDate], [Notes], [UsedKeywords])
VALUES (2, 'Title2 Small title', 'Bul2', 'Bul2', 'Bu2', 'Bul2', 'Bul2', 'Backend2', 'Descr22222222', '2018-03-03 12:12:00.000', 'Notes2', 'UsedKeywords2')

INSERT INTO [Semantics] ([ProductId], [Title], [Bullet1], [Bullet2], [Bullet3], [Bullet4], [Bullet5], [Backend], [Description], [UpdateDate], [Notes], [UsedKeywords])
VALUES (2, 'Title3 Not big title', 'Bul3', 'Bul3', 'Bul3', 'Bul3', 'Bul3', 'Backend3', 'Descr3333333', '2018-04-04 13:13:00.000', 'Notes3', 'UsedKeywords3')

INSERT INTO [Semantics] ([ProductId], [Title], [Bullet1], [Bullet2], [Bullet3], [Bullet4], [Bullet5], [Backend], [Description], [UpdateDate], [Notes], [UsedKeywords])
VALUES (2, 'Title4 not smaLL title', 'Bul4', 'Bul4', 'Bul4', 'Bul4', 'Bul4', 'Backend4', 'Descr444444', '2018-05-05 14:14:00.000', 'Notes4', 'UsedKeywords4')

INSERT INTO [Semantics] ([ProductId], [Title], [Bullet1], [Bullet2], [Bullet3], [Bullet4], [Bullet5], [Backend], [Description], [UpdateDate], [Notes], [UsedKeywords])
VALUES (1, 'Title4 not smaLL title', 'Bul4', 'Bul4', 'Bul4', 'Bul4', 'Bul4', 'Backend4', 'Descr444444', '2018-05-05 14:14:00.000', 'Notes4', 'lapel microphone|2|lavalier microphone|0|')


/*         -- [KeywordCategory] --             */
INSERT INTO [KeywordCategory] ([CategoryName], [ProductTypeId])
VALUES ('������ ���������', 0)

INSERT INTO [KeywordCategory] ([CategoryName], [ProductTypeId])
VALUES ('Lavalier Mic', 1)

INSERT INTO [KeywordCategory] ([CategoryName], [ProductTypeId])
VALUES ('Lapel Mic', 1)

INSERT INTO [KeywordCategory] ([CategoryName], [ProductTypeId])
VALUES ('Magnetic Strip', 2)

INSERT INTO [KeywordCategory] ([CategoryName], [ProductTypeId])
VALUES ('5 Knife Set', 3)

INSERT INTO [KeywordCategory] ([CategoryName], [ProductTypeId])
VALUES ('iPhone Mic', 1)


/*         -- [SemCore] --             */
INSERT INTO [SemCore] ([ProductTypeId], [CategoryId], [Keyword], [Value], [LastUpdated])
VALUES (1, 1, 'lavalier microphone', 652053, CURRENT_TIMESTAMP)

INSERT INTO [SemCore] ([ProductTypeId], [CategoryId], [Keyword], [Value], [LastUpdated])
VALUES (1, 2, 'lapel microphone', 391053, CURRENT_TIMESTAMP)

INSERT INTO [SemCore] ([ProductTypeId], [CategoryId], [Keyword], [Value], [LastUpdated])
VALUES (2, 3, 'knife magnetic strip', 652053, CURRENT_TIMESTAMP)

INSERT INTO [SemCore] ([ProductTypeId], [CategoryId], [Keyword], [Value], [LastUpdated])
VALUES (3, 4, '5 piece knife set', 652053, CURRENT_TIMESTAMP)

INSERT INTO [SemCore] ([ProductTypeId], [CategoryId], [Keyword], [Value], [LastUpdated])
VALUES (1, 5, 'iphone 8 microphone', 652053, CURRENT_TIMESTAMP)

INSERT INTO [SemCore] ([ProductTypeId], [CategoryId], [Keyword], [Value], [LastUpdated])
VALUES (1, 2, 'iphone 18 microphone', 456, CURRENT_TIMESTAMP)
INSERT INTO [SemCore] ([ProductTypeId], [CategoryId], [Keyword], [Value], [LastUpdated])
VALUES (1, 2, 'iphone 288 microphone', 123, CURRENT_TIMESTAMP)

INSERT INTO [SemCore] ([ProductTypeId], [CategoryId], [Keyword], [Value], [LastUpdated])
VALUES (1, 2, 'iphone 388 microphone', 123, '2018-10-15 12:50:00')


/*         -- [FieldsLength] --             */
INSERT INTO [FieldsLength] ([TitleLength], [BulletsLength], [BackendLength], [SubjectMatterLength], [OtherAttributesLength], [IntendedUseLength], [DescriptionLength], [ProductId])
VALUES (200, 100, 250, 50, 100, 100, 2000, 1)

INSERT INTO [FieldsLength] ([TitleLength], [BulletsLength], [BackendLength], [SubjectMatterLength], [OtherAttributesLength], [IntendedUseLength], [DescriptionLength], [ProductId])
VALUES (200, 100, 250, 150, 150, 150, 2000, 2)



















-- [Course] inserts

INSERT INTO [Course] ([CourseId], [Code], [Title], [Description], [Amount], [Status])
VALUES (100, 'SQ100', '������ SQL', '�������� � ���� ������ � SQL. ���� ��� ����������', 3045.50, 'A')

INSERT INTO [Course] ([CourseId], [Code], [Title], [Description], [Amount],[Status])
VALUES (200, 'NT200', '������ ������������ ����� (Networks)', '������� �������� ���������� ������������ �����. ���� �������� ��������� ������������ ������������ �����', 3999.89, 'A')

INSERT INTO [Course] ([CourseId], [Code], [Title], [Description], [Amount],[Status])
VALUES (300, 'UX300', '������ Unix', '������ ������ � ������������� ��������� Unix', 2500.79, 'D')

INSERT INTO [Course] ([CourseId], [Code], [Title], [Description], [Amount],[Status])
VALUES (400, 'TS400', '������������ ������������ ����������� (QA Testing)', '�������� �������� ������������ ������������ ����������� �� ���������, ����������� ������������ � �������� ������ � �������� ��������', 5501.99, 'D')

INSERT INTO [Course] ([CourseId], [Code], [Title], [Description], [Amount],[Status])
VALUES (401, 'TS401', '������������������ ������������ (Selenium + Python)', '������������� �������� ������������. �������� � ����������� �����������', 5000, 'D')

GO

-- [CourseContent] inserts

INSERT INTO [CourseContent] ([CourseId], [CourseContentId], [ParentId], [Code], [ContentType], [Title], [Description])
VALUES (100, 1, 1, '1', 'UN', '�������� � ��������� �����', '')

INSERT INTO [CourseContent] ([CourseId], [CourseContentId], [ParentId], [Code], [ContentType], [Title], [Description])
VALUES (100, 2, 1, 'A', 'CH', '�������� � �������������� ������� � ���� �� � ���', '')

INSERT INTO [CourseContent] ([CourseId], [CourseContentId], [ParentId], [Code], [ContentType], [Title], [Description])
VALUES (100, 3, 1, 'B', 'CH', '�������� � ������ ��. ���� ��', '')

INSERT INTO [CourseContent] ([CourseId], [CourseContentId], [ParentId], [Code], [ContentType], [Title], [Description])
VALUES (100, 4, 1, 'C', 'CH', '�������� ������� � �������. ������� ��. ����������� ���������', '')

INSERT INTO [CourseContent] ([CourseId], [CourseContentId], [ParentId], [Code], [ContentType], [Title], [Description])
VALUES (100, 5, 1, 'D', 'CH', 'Structured Query Language � �������� ������ ���������������� ��� ������', '')

INSERT INTO [CourseContent] ([CourseId], [CourseContentId], [ParentId], [Code], [ContentType], [Title], [Description])
VALUES (100, 6, 1, 'E', 'CH', '�������� � T-SQL. ���� ������', '')

INSERT INTO [CourseContent] ([CourseId], [CourseContentId], [ParentId], [Code], [ContentType], [Title], [Description])
VALUES (100, 7, 1, 'F', 'CH', '���������� �� ������ SQL Server Management Studio (SSMS)', '')

INSERT INTO [CourseContent] ([CourseId], [CourseContentId], [ParentId], [Code], [ContentType], [Title], [Description])
VALUES (100, 8, 1, 'G', 'CH', '���������� � ������� ����� ������ �����', '')

INSERT INTO [CourseContent] ([CourseId], [CourseContentId], [ParentId], [Code], [ContentType], [Title], [Description])
VALUES (100, 9, 9, '2', 'UN', '������� � ����������� ������', '')

INSERT INTO [CourseContent] ([CourseId], [CourseContentId], [ParentId], [Code], [ContentType], [Title], [Description])
VALUES (100, 10, 9, 'A', 'CH', 'Data Modification Language (DML) ��� ����� T-SQL', '')

INSERT INTO [CourseContent] ([CourseId], [CourseContentId], [ParentId], [Code], [ContentType], [Title], [Description])
VALUES (100, 11, 9, 'B', 'CH', '�������� ������� DML', '')

INSERT INTO [CourseContent] ([CourseId], [CourseContentId], [ParentId], [Code], [ContentType], [Title], [Description])
VALUES (100, 12, 11, 'I', 'CH', '����� ��������� ��������� ������� SELECT', '')

INSERT INTO [CourseContent] ([CourseId], [CourseContentId], [ParentId], [Code], [ContentType], [Title], [Description])
VALUES (100, 13, 11, 'II', 'CH', '�������� ������� �� ������� ������', '')

INSERT INTO [CourseContent] ([CourseId], [CourseContentId], [ParentId], [Code], [ContentType], [Title], [Description])
VALUES (100, 14, 11, 'III', 'CH', '����������� ������ � ������� ��������� UPDATE', '')

INSERT INTO [CourseContent] ([CourseId], [CourseContentId], [ParentId], [Code], [ContentType], [Title], [Description])
VALUES (100, 15, 11, 'IV', 'CH', '�������� � ���������� ����� ������ � ������� ���������� DELETE � INSERT', '')

GO

-- [UserData] inserts

INSERT INTO [UserRole] ([UserRoleId], [Code], [Name], [Description])
VALUES (1, 'RES', 'Reserved', '')

INSERT INTO [UserRole] ([UserRoleId], [Code], [Name], [Description])
VALUES (2, 'ADM', '�������������', '')

INSERT INTO [UserRole] ([UserRoleId], [Code], [Name], [Description])
VALUES (3, 'INS', '�������������', '�������������/���������� ������')

INSERT INTO [UserRole] ([UserRoleId], [Code], [Name], [Description])
VALUES (4, 'STD', '�������', '�������� ������')

GO

-- [UserRole] inserts

DECLARE @CurrentDate DATETIME
SELECT @CurrentDate = CURRENT_TIMESTAMP

INSERT INTO [UserData] ([UserName], [Password], [FirstName], [MiddleName], [LastName], [CreateDate], [UpdateDate], [Status])
SELECT  'admin', '9fbf0de4', '�������', '�����������', '�������', '20131001 17:44', '20140102 14:05', 'A'
UNION ALL
SELECT  'smart', 'cb055ed7', '������', '������������', '����������', '20140101 17:44', '20140102 14:05', 'A'
UNION ALL
SELECT  'shaman', '4df20a20', '���������', '�����������', '�������', '20141212 12:12', '20141212 15:01', 'A'
UNION ALL
SELECT  'test', '', '����', NULL, '��������', @CurrentDate, @CurrentDate, 'A'
UNION ALL
SELECT  'isidor', 'c7a63824', '����', '��������', '��������', @CurrentDate, @CurrentDate, 'A'
UNION ALL
SELECT  'elza', '417e314d', '�����', '��������', '��������', @CurrentDate, @CurrentDate, 'A'
UNION ALL
SELECT  'vpupkin', '48ffb373', '�������', '����������', '������', @CurrentDate, @CurrentDate, 'A'
UNION ALL
SELECT  'akrasov', 'b151c83c', '����', '����������', '����������', @CurrentDate, @CurrentDate, 'A'
GO

-- [UserRoleLink] inserts

INSERT INTO [UserRoleLink] ([UserDataId], [UserRoleId])
SELECT (SELECT * FROM [getUserId] ('admin')), (select * from [getRoleId] ('ADM')) -- ������� ������� � ������� 2 ������� (getUserId � getRoleId).
UNION ALL
SELECT (SELECT * FROM [getUserId] ('shaman')), 2 -- ������� ������� � ������� 1 ������� (getUserId � ������������� ����).
UNION ALL
SELECT (SELECT * FROM [getUserId] ('test')), 2 -- ������� ������� � ������� 1 ������� (getUserId � ������������� ����).
UNION ALL
SELECT [UserDataId], 3  FROM [UserData] WHERE [UserDataId] IN (2, 3) -- ������� ������� ��� ������� (�������������� ������������� + ����).
UNION ALL
SELECT [UserDataId], 4  FROM [UserData] WHERE [UserDataId] IN (2, 4, 5, 6, 7, 8) -- ������� ������� ��� ������� (�������������� ������������� + ����).
GO

-- [UserGroup] inserts

INSERT INTO [UserGroup] ([CourseId], [Name], [CreateDate], [UpdateDate], [Status])
SELECT 100, '������ �1 (SQL)', '20141209 12:05:34', '20141210 16:40:12', 'A'
UNION ALL
SELECT 200, '������ �2 (Networks)', '20141210 09:00:00', '20141210 09:00:00', 'D'
UNION ALL
SELECT 300, '������ �3 (Unix)', '20141211 09:30:44', '20141211 09:35:00', 'D'
GO

-- [UserGroupLink] inserts

INSERT INTO [UserGroupLink] ([UserGroupId], [UserDataId])
SELECT (SELECT [UserGroupId] FROM [UserGroup] WHERE [CourseId] = 100),
       [UserDataId]
FROM   [UserData] WHERE UserDataId > 1
UNION ALL
SELECT (SELECT [UserGroupId] FROM [UserGroup] WHERE [CourseId] = 200),
       [UserDataId]
FROM   [UserData] WHERE UserDataId IN (1, 2, 4, 5, 6)
GO

---------------------------------------------------------------------------------------
SELECT * FROM Course
SELECT * FROM CourseContent
SELECT * FROM UserRole
SELECT * FROM UserRoleLink
SELECT * FROM UserData
SELECT * FROM UserGroup
SELECT * FROM UserGroupLink

*/