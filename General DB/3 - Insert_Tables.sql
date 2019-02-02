USE AHEAD
GO

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

/*         -- [MarketPlaceName] --             */
INSERT INTO [Marketplace] ([MarketPlaceName])
VALUES ('Без маркетплейса')


/*         -- [ProductTypes] --             */
INSERT INTO [ProductTypes] ([TypeName])
VALUES ('Отсутствующие товары')


/*         -- [Products] --             */
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus])
VALUES ('Товар отсутствует', '-', '-', 0, 0, 'false')


/*         -- [KeywordCategory] --             */
INSERT INTO [KeywordCategory] ([CategoryName], [ProductTypeId])
VALUES ('Пустая категория', 0)







USE AHEAD
GO


/*         -- [MarketPlaceName] --             */

INSERT INTO [Marketplace] ([MarketPlaceName])
VALUES ('PowerDeWise - USA')

INSERT INTO [Marketplace] ([MarketPlaceName])
VALUES ('PowerDeWise - CA')

INSERT INTO [Marketplace] ([MarketPlaceName])
VALUES ('LETIT.BEER - USA')

INSERT INTO [Marketplace] ([MarketPlaceName])
VALUES ('LETIT.BEER - CA')

INSERT INTO [Marketplace] ([MarketPlaceName])
VALUES ('LaFit - USA')

INSERT INTO [Marketplace] ([MarketPlaceName])
VALUES ('PowerDeWise - AU')


/*         -- [ProductTypes] --             */

INSERT INTO [ProductTypes] ([TypeName])
VALUES ('Микрофоны')

INSERT INTO [ProductTypes] ([TypeName])
VALUES ('Холдеры')

INSERT INTO [ProductTypes] ([TypeName])
VALUES ('Ножи')

INSERT INTO [ProductTypes] ([TypeName])
VALUES ('Адаптеры для микрофонов')

INSERT INTO [ProductTypes] ([TypeName])
VALUES ('Точилки для ножей')

INSERT INTO [ProductTypes] ([TypeName])
VALUES ('Удлинители')

INSERT INTO [ProductTypes] ([TypeName])
VALUES ('Триподы')

INSERT INTO [ProductTypes] ([TypeName])
VALUES ('Клипсы для микрофонов')

INSERT INTO [ProductTypes] ([TypeName])
VALUES ('Ветрозащита для микрофонов')


/*         -- [KeywordCategory] --             */

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



/*         -- [Products] --             */

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus])
VALUES ('YouMic Main Microphone', 'B01E3L1ESS', '8R-MO3B-ZV8H', 1, 1, 'false')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus])
VALUES ('Microphone Adapter 3.5mm (Old)', 'B01N5RG8EC', 'ZW-WW1I-PT7A', 1, 1, 'true')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus])
VALUES ('Micro USB Cable(3ft)', 'B01MDV1NSW', 'ZD-DES3-1YXC', 6, 1, 'false')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus])
VALUES ('Extension Cable 3.5 mm(6 ft)', 'B01LZBEH3W', 'XZ-8LJT-BPX3', 6, 1, 'true')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus])
VALUES ('YouMic Dual Lavalier Microphone', 'B07G2C8D7H', 'XW-I4VB-F8W5', 1, 1, 'true')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus])
VALUES ('Extension Cable 3.5 mm(3 ft)', 'B07CHC94XT', 'PI-HW8D-6TTD', 6, 1, 'true')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus])
VALUES ('PDW Podcast Microphone(Child)', 'B07FCN1K2N', 'pdwmcslvr6', 1, 1, 'true')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus])
VALUES ('PDW iPhone Microphone(Child)', 'B07GYB43P2', 'pdwmcslvr4', 1, 1, 'true')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus])
VALUES ('PDW Mini Microphone(Child)', 'B07FCSQGPY', 'pdwmcslvr3', 1, 1, 'true')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus])
VALUES ('PDW Android Microphone(Child)', 'B07FCJCDDM', 'pdwmcslvr2', 1, 1, 'true')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus])
VALUES ('Flexible Mini Tripod(Old)', 'B01MG2BEVZ', 'P9-8LPU-DGDW', 7, 1, 'true')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus])
VALUES ('Furry Wind Muff', 'B075FS5Y7Z', 'O9-U3F0-WROB', 9, 1, 'true')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus])
VALUES ('YouMic Microphone Clip', 'B07BFWVJH1', 'N5-YBHW-NM5X', 8, 1, 'true')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus])
VALUES ('PDW Main Microphone', 'B01AG56HYQ', 'LR-44G2-7Y1Y', 1, 1, 'true')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus])
VALUES ('PDW Y Splitter(Mic + Mic)', 'B01BNGAHCA', 'KS-ZYQB-G549', 4, 1, 'true')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus])
VALUES ('PDW Main Microphone', 'B01AG56HYQ', 'IG-5UO9-SCW1', 1, 1, 'true')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus])
VALUES ('PDW Dual Microphone', 'B07CHCSLVC', 'HR-9KQ2-IPD9', 1, 1, 'true')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus])
VALUES ('Kitchen Knife Sharpener(Child)', 'B01FS5VJMY', 'GK-RHNH-11NI', 5, 1, 'true')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus])
VALUES ('PDW Y Splitter New(Headphone + Mic)', 'B07G4DS728', 'GH-7TR8-5HPZ', 4, 1, 'true')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus])
VALUES ('Kitchen Knife Sharpener(Main)', 'B079YP5L6J', 'FF-TB8V-VKY4', 5, 1, 'true')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus])
VALUES ('PDW Main Microphone', 'B01AG56HYQ', 'E3-2RHF-EO7C', 1, 1, 'true')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus])
VALUES ('Phone Tripod New', 'B07CJRB8YB', 'E3-1WM4-S3MY', 7, 1, 'true')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus])
VALUES ('PDW Microphone Wind Muff', 'B01LL5U0NO', 'DL-LJ4D-RKZH', 9, 1, 'true')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus])
VALUES ('Extension Cable 3.5 mm(10 ft)', 'B07CHFG1FN', 'BQ-CK10-HCVV', 6, 1, 'true')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus])
VALUES ('YouMic Microphone Wind Muff', 'B07BFXR55J', 'AV-ALS4-5BSO', 9, 1, 'true')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus])
VALUES ('Knife Holder(Old)', 'B01DIU9FP4', 'ArtDeHomeLightWalnut12', 2, 1, 'true')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus])
VALUES ('Walnut Knife Set', 'B07FLYJTLB', 'adhknfstwlnt', 3, 1, 'true')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus])
VALUES ('Acacia Knife Set', 'B07DWWMW8H', 'adhknfstlt', 3, 1, 'true')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus])
VALUES ('Walnut Knife Holder', 'B07DW5X3LY', 'adhhldrwlnt', 2, 1, 'true')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus])
VALUES ('Acacia Knife Holder', 'B07FCNH5SL', 'adhhldacca', 2, 1, 'true')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus])
VALUES ('USB Audio Adapter', 'B0713SJ2ZD', 'AB-KG1N-IPYL', 4, 1, 'true')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus])
VALUES ('Extension Cable 3.5 mm(15 ft)', 'B07CHBGV5X', '3J-03VY-3VT0', 6, 1, 'true')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus])
VALUES ('Lightning Cable(3 ft)', 'B01MDV1TO4', '32-FM61-Q39H', 6, 1, 'true')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus])
VALUES ('PDW Microphone Clip', 'B01LZ6T9XO', '1N-NPIV-XHND', 8, 1, 'true')






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


/*         -- [Indexing] --             */

INSERT INTO [Indexing] ([ProductId], [ASIN], [Date], [Status] ,[Notes]) 
VALUES (1, 'B01E3L1ESS', '2018-12-27', 'Not Ok', 'не в индексе@проблема с 1м буллетом@@@проблема с 4м буллетом@@@')

INSERT INTO [Indexing] ([ProductId], [ASIN], [Date], [Status] ,[Notes]) 
VALUES (1, 'B01E3L1ESS', '2018-12-20', 'Ok', '')

INSERT INTO [Indexing] ([ProductId], [ASIN], [Date], [Status] ,[Notes]) 
VALUES (1, 'B01E3L1ESS', '2018-12-22', 'Ok', '')

INSERT INTO [Indexing] ([ProductId], [ASIN], [Date], [Status] ,[Notes]) 
VALUES (1, 'B01E3L1ESS', '2018-11-02', 'Ok', '')

INSERT INTO [Indexing] ([ProductId], [ASIN], [Date], [Status] ,[Notes]) 
VALUES (1, 'B01E3L1ESS', '2018-12-20', 'Ok', '')

INSERT INTO [Indexing] ([ProductId], [ASIN], [Date], [Status] ,[Notes]) 
VALUES (2, 'B01N5RG8EC', '2018-11-23', 'Ok', '')

INSERT INTO [Indexing] ([ProductId], [ASIN], [Date], [Status] ,[Notes]) 
VALUES (2, 'B01N5RG8EC', '2018-10-23', 'Ok', '')

INSERT INTO [Indexing] ([ProductId], [ASIN], [Date], [Status], [Notes]) 
VALUES (7, 'B07FCN1K2N', '2018-53-28', 'Closed', '')





select * from products



-------------------------------------Analytics----------------------------------












/*

-- [Course] inserts

INSERT INTO [Course] ([CourseId], [Code], [Title], [Description], [Amount], [Status])
VALUES (100, 'SQ100', 'Основы SQL', 'Введение в базы данных и SQL. Курс для начинающих', 3045.50, 'A')

INSERT INTO [Course] ([CourseId], [Code], [Title], [Description], [Amount],[Status])
VALUES (200, 'NT200', 'Основы компьютерных сетей (Networks)', 'Базовые принципы построения компьютерных сетей. Курс расширен изучением тестирования компьютерных сетей', 3999.89, 'A')

INSERT INTO [Course] ([CourseId], [Code], [Title], [Description], [Amount],[Status])
VALUES (300, 'UX300', 'Основы Unix', 'Основы работы с операционными системами Unix', 2500.79, 'D')

INSERT INTO [Course] ([CourseId], [Code], [Title], [Description], [Amount],[Status])
VALUES (400, 'TS400', 'Тестирование программного обеспечения (QA Testing)', 'Изучение процесса тестирования программного обеспечения по программе, максимально приближенной к условиям работы в реальных проектах', 5501.99, 'D')

INSERT INTO [Course] ([CourseId], [Code], [Title], [Description], [Amount],[Status])
VALUES (401, 'TS401', 'Автоматизированное тестирование (Selenium + Python)', 'Автоматизация процесса тестирования. Принципы и современные инструменты', 5000, 'D')

GO

-- [CourseContent] inserts

INSERT INTO [CourseContent] ([CourseId], [CourseContentId], [ParentId], [Code], [ContentType], [Title], [Description])
VALUES (100, 1, 1, '1', 'UN', 'Введение в программу курса', '')

INSERT INTO [CourseContent] ([CourseId], [CourseContentId], [ParentId], [Code], [ContentType], [Title], [Description])
VALUES (100, 2, 1, 'A', 'CH', 'Введение в информационные системы и роль БД в них', '')

INSERT INTO [CourseContent] ([CourseId], [CourseContentId], [ParentId], [Code], [ContentType], [Title], [Description])
VALUES (100, 3, 1, 'B', 'CH', 'Введение в теорию БД. Виды БД', '')

INSERT INTO [CourseContent] ([CourseId], [CourseContentId], [ParentId], [Code], [ContentType], [Title], [Description])
VALUES (100, 4, 1, 'C', 'CH', 'Основные понятия и термины. Объекты БД. Определение отношения', '')

INSERT INTO [CourseContent] ([CourseId], [CourseContentId], [ParentId], [Code], [ContentType], [Title], [Description])
VALUES (100, 5, 1, 'D', 'CH', 'Structured Query Language – стандарт языков программирования баз данных', '')

INSERT INTO [CourseContent] ([CourseId], [CourseContentId], [ParentId], [Code], [ContentType], [Title], [Description])
VALUES (100, 6, 1, 'E', 'CH', 'Введение в T-SQL. Типы данных', '')

INSERT INTO [CourseContent] ([CourseId], [CourseContentId], [ParentId], [Code], [ContentType], [Title], [Description])
VALUES (100, 7, 1, 'F', 'CH', 'Знакомство со средой SQL Server Management Studio (SSMS)', '')

INSERT INTO [CourseContent] ([CourseId], [CourseContentId], [ParentId], [Code], [ContentType], [Title], [Description])
VALUES (100, 8, 1, 'G', 'CH', 'Знакомство с учебной базой данных курса', '')

INSERT INTO [CourseContent] ([CourseId], [CourseContentId], [ParentId], [Code], [ContentType], [Title], [Description])
VALUES (100, 9, 9, '2', 'UN', 'Выборка и модификация данных', '')

INSERT INTO [CourseContent] ([CourseId], [CourseContentId], [ParentId], [Code], [ContentType], [Title], [Description])
VALUES (100, 10, 9, 'A', 'CH', 'Data Modification Language (DML) как часть T-SQL', '')

INSERT INTO [CourseContent] ([CourseId], [CourseContentId], [ParentId], [Code], [ContentType], [Title], [Description])
VALUES (100, 11, 9, 'B', 'CH', 'Основные команды DML', '')

INSERT INTO [CourseContent] ([CourseId], [CourseContentId], [ParentId], [Code], [ContentType], [Title], [Description])
VALUES (100, 12, 11, 'I', 'CH', 'Общая структура оператора выборки SELECT', '')

INSERT INTO [CourseContent] ([CourseId], [CourseContentId], [ParentId], [Code], [ContentType], [Title], [Description])
VALUES (100, 13, 11, 'II', 'CH', 'Создание запроса на выборку данных', '')

INSERT INTO [CourseContent] ([CourseId], [CourseContentId], [ParentId], [Code], [ContentType], [Title], [Description])
VALUES (100, 14, 11, 'III', 'CH', 'Модификация данных с помощью оператора UPDATE', '')

INSERT INTO [CourseContent] ([CourseId], [CourseContentId], [ParentId], [Code], [ContentType], [Title], [Description])
VALUES (100, 15, 11, 'IV', 'CH', 'Удаление и добавление новых данных с помощью операторов DELETE и INSERT', '')

GO

-- [UserData] inserts

INSERT INTO [UserRole] ([UserRoleId], [Code], [Name], [Description])
VALUES (1, 'RES', 'Reserved', '')

INSERT INTO [UserRole] ([UserRoleId], [Code], [Name], [Description])
VALUES (2, 'ADM', 'Администратор', '')

INSERT INTO [UserRole] ([UserRoleId], [Code], [Name], [Description])
VALUES (3, 'INS', 'Преподаватель', 'Преподаватель/инструктор курсов')

INSERT INTO [UserRole] ([UserRoleId], [Code], [Name], [Description])
VALUES (4, 'STD', 'Студент', 'Учащийся курсов')

GO

-- [UserRole] inserts

DECLARE @CurrentDate DATETIME
SELECT @CurrentDate = CURRENT_TIMESTAMP

INSERT INTO [UserData] ([UserName], [Password], [FirstName], [MiddleName], [LastName], [CreateDate], [UpdateDate], [Status])
SELECT  'admin', '9fbf0de4', 'Николай', 'Григорьевич', 'Админин', '20131001 17:44', '20140102 14:05', 'A'
UNION ALL
SELECT  'smart', 'cb055ed7', 'Сергей', 'Владимирович', 'Мартыненко', '20140101 17:44', '20140102 14:05', 'A'
UNION ALL
SELECT  'shaman', '4df20a20', 'Александр', 'Анатольевич', 'Шаменко', '20141212 12:12', '20141212 15:01', 'A'
UNION ALL
SELECT  'test', '', 'Тест', NULL, 'Тестовый', @CurrentDate, @CurrentDate, 'A'
UNION ALL
SELECT  'isidor', 'c7a63824', 'Иван', 'Петрович', 'Сидорчук', @CurrentDate, @CurrentDate, 'A'
UNION ALL
SELECT  'elza', '417e314d', 'Елена', 'Павловна', 'Захарчук', @CurrentDate, @CurrentDate, 'A'
UNION ALL
SELECT  'vpupkin', '48ffb373', 'Василий', 'Васильевич', 'Пупкин', @CurrentDate, @CurrentDate, 'A'
UNION ALL
SELECT  'akrasov', 'b151c83c', 'Анна', 'Леонидовна', 'Красовская', @CurrentDate, @CurrentDate, 'A'
GO

-- [UserRoleLink] inserts

INSERT INTO [UserRoleLink] ([UserDataId], [UserRoleId])
SELECT (SELECT * FROM [getUserId] ('admin')), (select * from [getRoleId] ('ADM')) -- Вариант вставки с помощью 2 функций (getUserId и getRoleId).
UNION ALL
SELECT (SELECT * FROM [getUserId] ('shaman')), 2 -- Вариант вставки с помощью 1 функции (getUserId и идентификатор роли).
UNION ALL
SELECT (SELECT * FROM [getUserId] ('test')), 2 -- Вариант вставки с помощью 1 функции (getUserId и идентификатор роли).
UNION ALL
SELECT [UserDataId], 3  FROM [UserData] WHERE [UserDataId] IN (2, 3) -- Вариант вставки без функций (идентификаторы пользователей + роли).
UNION ALL
SELECT [UserDataId], 4  FROM [UserData] WHERE [UserDataId] IN (2, 4, 5, 6, 7, 8) -- Вариант вставки без функций (идентификаторы пользователей + роли).
GO

-- [UserGroup] inserts

INSERT INTO [UserGroup] ([CourseId], [Name], [CreateDate], [UpdateDate], [Status])
SELECT 100, 'Группа №1 (SQL)', '20141209 12:05:34', '20141210 16:40:12', 'A'
UNION ALL
SELECT 200, 'Группа №2 (Networks)', '20141210 09:00:00', '20141210 09:00:00', 'D'
UNION ALL
SELECT 300, 'Группа №3 (Unix)', '20141211 09:30:44', '20141211 09:35:00', 'D'
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