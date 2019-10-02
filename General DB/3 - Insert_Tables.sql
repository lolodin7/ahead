USE AHEAD
GO

/*         -- [MarketPlaceName] --             */
INSERT INTO [Marketplace] ([MarketPlaceName])
VALUES ('Без маркетплейса')


/*         -- [ProductTypes] --             */
INSERT INTO [ProductTypes] ([TypeName])
VALUES ('Отсутствующие товары')


/*         -- [KeywordCategory] --             */
INSERT INTO [KeywordCategory] ([CategoryName], [ProductTypeId])
VALUES ('Пустая категория', 0)

USE AHEAD
GO


/*         -- [MarketPlaceName] --             */

INSERT INTO [Marketplace] ([MarketPlaceName])
VALUES ('PowerDeWise (USA)')

INSERT INTO [Marketplace] ([MarketPlaceName])
VALUES ('PowerDeWise (CA)')

INSERT INTO [Marketplace] ([MarketPlaceName])
VALUES ('PowerDeWise (AU)')

INSERT INTO [Marketplace] ([MarketPlaceName])
VALUES ('PowerDeWise (MX)')

INSERT INTO [Marketplace] ([MarketPlaceName])
VALUES ('LetIt.Beer (USA)')

INSERT INTO [Marketplace] ([MarketPlaceName])
VALUES ('LetIt.Beer (CA)')


/*         -- [ProductTypes] --             */

INSERT INTO [ProductTypes] ([TypeName])
VALUES ('Микрофоны')

INSERT INTO [ProductTypes] ([TypeName])
VALUES ('Удлинители')

INSERT INTO [ProductTypes] ([TypeName])
VALUES ('Триподы')

INSERT INTO [ProductTypes] ([TypeName])
VALUES ('Клипсы для микрофонов')

INSERT INTO [ProductTypes] ([TypeName])
VALUES ('Ветрозащита для микрофонов')

INSERT INTO [ProductTypes] ([TypeName])
VALUES ('Beer Chiller')

INSERT INTO [ProductTypes] ([TypeName])
VALUES ('Аксессуары')

/*         -- [KeywordCategory] --             */

INSERT INTO [KeywordCategory] ([CategoryName], [ProductTypeId])
VALUES ('Lavalier Mic', 1)

INSERT INTO [KeywordCategory] ([CategoryName], [ProductTypeId])
VALUES ('Lapel Mic', 1)

INSERT INTO [KeywordCategory] ([CategoryName], [ProductTypeId])
VALUES ('Extension Cord', 2)

INSERT INTO [KeywordCategory] ([CategoryName], [ProductTypeId])
VALUES ('Windshield', 5)

INSERT INTO [KeywordCategory] ([CategoryName], [ProductTypeId])
VALUES ('iPhone Mic', 1)

/*         -- [CampaignType] --             */
INSERT INTO [CampaignType] ([CampaignName])
VALUES ('Sponsored Products')

INSERT INTO [CampaignType] ([CampaignName])
VALUES ('Sponsored Brands')


/*         -- [Currency] --             */
INSERT INTO [Currency] ([UpdateDate], [NumCode], [CharCode], [Nominal], [Name], [Value])
VALUES ('10.09.2019', 124, 'CAD', 1, 'Канадский доллар', 1.3197)

INSERT INTO [Currency] ([UpdateDate], [NumCode], [CharCode], [Nominal], [Name], [Value])
VALUES ('10.09.2019', 036, 'AUD', 1, 'Австралийский доллар', 1.4559)

INSERT INTO [Currency] ([UpdateDate], [NumCode], [CharCode], [Nominal], [Name], [Value])
VALUES ('10.09.2019', 484, 'MXN', 1, 'Мексиканский песо', 19.4413)

INSERT INTO [Currency] ([UpdateDate], [NumCode], [CharCode], [Nominal], [Name], [Value])
VALUES ('10.09.2019', 840, 'USD', 1, 'Доллар США', 1)


/*         -- [SemCore] --             */
INSERT INTO [SemCore] ([ProductTypeId], [CategoryId], [Keyword], [Value], [LastUpdated], [MarketPlaceId])
VALUES (1, 1, 'lavalier microphone', 200000, CURRENT_TIMESTAMP, 1)

INSERT INTO [SemCore] ([ProductTypeId], [CategoryId], [Keyword], [Value], [LastUpdated], [MarketPlaceId])
VALUES (1, 1, 'lavalier microphone', 100000, CURRENT_TIMESTAMP, 2)


/*         -- [UserRole] --             */
INSERT INTO [UserRole] ([Name])
VALUES ('Администратор')

INSERT INTO [UserRole] ([Name])
VALUES ('Руководитель')

INSERT INTO [UserRole] ([Name])
VALUES ('Пользователь')


/*         -- [User] --             */
INSERT INTO [User] ([Login], [PassHash], [Name], [Token1], [Token2], [UserRoleId], [SecretQuestion], [Answer], [MAC])
VALUES ('raizz', 'ADAH/ZuvEVdABXe4AuzqwknkxSZzRbhdj21avq9UvFa5E2HiQwcJ2WfdI868yw9A9g==', 'Дима', 123, 321, 0, 'Íîìåð îôèñà', 'AEBZF6htjJp6bJmhb7Of6vmRm2wu4vthhjEUZMivrOi6GHC+oIeiJXSlTqTTUlWgnA==', '00FFCD3F0DEB')

INSERT INTO [User] ([Login], [PassHash], [Name], [Token1], [Token2], [UserRoleId], [SecretQuestion], [Answer], [MAC])
VALUES ('test1', 'ADAH/ZuvEVdABXe4AuzqwknkxSZzRbhdj21avq9UvFa5E2HiQwcJ2WfdI868yw9A9g==', 'boss', 123, 321, 1, 'Íîìåð îôèñà', 'AEBZF6htjJp6bJmhb7Of6vmRm2wu4vthhjEUZMivrOi6GHC+oIeiJXSlTqTTUlWgnA==', '00FF60C1B9B4')

INSERT INTO [User] ([Login], [PassHash], [Name], [Token1], [Token2], [UserRoleId], [SecretQuestion], [Answer], [MAC])
VALUES ('test2', 'ADAH/ZuvEVdABXe4AuzqwknkxSZzRbhdj21avq9UvFa5E2HiQwcJ2WfdI868yw9A9g==', 'user', 123, 321, 2, 'Íîìåð îôèñà', 'AEBZF6htjJp6bJmhb7Of6vmRm2wu4vthhjEUZMivrOi6GHC+oIeiJXSlTqTTUlWgnA==', '00FF60C1B9B4')


/*         -- [Products] --             */
INSERT INTO [Products] ([Name])
VALUES ('Товары отсутствуют')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW - главный микрофон', 'B01AG56HYQ', 'E3-2RHF-EO7C', 1, 1, 1, 'PDW1')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW - главный микрофон', 'B01AG56HYQ', 'LR-44G2-7Y1Y', 1, 1, 1, 'PDW1')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW - главный микрофон', 'B01AG56HYQ', 'IG-5UO9-SCW1', 1, 1, 1, 'PDW1')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW - главный микрофон', 'B01AG56HYQ', '6A-ICQP-MBHC', 1, 5, 1, 'PDW1')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Dual PDW - двойной', 'B07CHCSLVC', 'HR-9KQ2-IPD9', 1, 1, 1, 'PDW-Ch Dual')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW Lightning Adapter', 'B07SCYJH64', 'NT-HV0T-VR4C', 1, 1, 1, 'PDW-Ch Lightning Adapter')

/*-----------------------*/
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Video Microphone', 'B07RG4J7WY', '2V-8VSV-C0AE', 1, 1, 1, 'Video Microphone')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW - vlogger kit', 'B07Y1XBKC7', 'O5-HZWD-YO8M', 1, 1, 1, 'PDW-Ch Vlogger Kit')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('YouMic - главный микрофон', 'B01E3L1ESS', '8R-MO3B-ZV8H', 1, 1, 1, 'YM1')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('YouMic - Lightning adapter', 'B07WS5DGCS', 'AM-X9B2-T6B1', 1, 1, 1, 'YM-Ch Lightning Adapter')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('YouMic Dual - двойной', 'B07G2C8D7H', 'XW-I4VB-F8W5 ', 1, 1, 1, 'YM-Ch Dual')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('YouMic - главный микрофон', 'B01E3L1ESS', '8R-MO3B-ZV8H', 1, 2, 1, 'YM1')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('YouMic Dual - двойной', 'B07G2C8D7H', 'XW-I4VB-F8W5 ', 1, 2, 1, 'YM-Ch Dual')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW - главный микрофон', 'B01AG56HYQ', 'E3-2RHF-EO7C', 1, 2, 1, 'PDW1')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Dual PDW - двойной', 'B07CHCSLVC', 'HR-9KQ2-IPD9', 1, 2, 1, 'PDW-Ch Dual')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Beer Chiller', 'B01AI03U4Y', 'BC-GHGX-5M0O', 6, 5, 1, 'Beer Chiller')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('YelloWay-2', 'B06ZZ6NPRP', 'LD-YUMV-LDZV', 1, 5, 1, 'YW2')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Y-Connector', 'B01BNGAHCA', 'KS-ZYQB-G549', 7, 1, 1, 'Y-Connector')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW Type-C Adapter', 'B07RMXR4FB', 'HH-4FJF-QK02', 7, 1, 1, 'PDW-Ch Type-C')

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW Android', 'B07FCSQGPY', 'pdwmcslvr3', 7, 1, 1, 'PDW-Ch Android')

/*-----------------------*/



INSERT INTO [Logger] ([CreationDate], [CreationUserId], [ProductId], [Text], [EditDate], [EditUserId], [ImageId], [SKU])
VALUES (CURRENT_TIMESTAMP, 1, 2, 'log record #2', CURRENT_TIMESTAMP, 1, '', '6A-ICQP-MBHC')



/*         -- [Logger] --             */
INSERT INTO [Logger] ([CreationDate], [CreationUserId], [ProductId], [Text], [EditDate], [EditUserId], [ImageId], [SKU])
VALUES (CURRENT_TIMESTAMP, 0, 1, 'log record #1', CURRENT_TIMESTAMP, 1, '1|2|3|4|5|6|7|8|9|10|', 'IG-5UO9-SCW1')

INSERT INTO [Logger] ([CreationDate], [CreationUserId], [ProductId], [Text], [EditDate], [EditUserId], [ImageId], [SKU])
VALUES (CURRENT_TIMESTAMP, 1, 1, 'log record #1', CURRENT_TIMESTAMP, 1, '1|2|', '6A-ICQP-MBHC')

INSERT INTO [Logger] ([CreationDate], [CreationUserId], [ProductId], [Text], [EditDate], [EditUserId], [ImageId], [SKU])
VALUES (CURRENT_TIMESTAMP, 1, 2, 'log record #2', CURRENT_TIMESTAMP, 1, '', '6A-ICQP-MBHC')

INSERT INTO [Logger] ([CreationDate], [CreationUserId], [ProductId], [Text], [EditDate], [EditUserId], [ImageId], [SKU])
VALUES ('08.05.2019', 2, 2, 'log record #3', '05.05.2019', 1, 0, 'LR-44G2-7Y1Y')

INSERT INTO [Logger] ([CreationDate], [CreationUserId], [ProductId], [Text], [EditDate], [EditUserId], [ImageId])
VALUES ('08.03.2019', 1, 3, 'log record #4', '05.05.2019', 1, 0)

INSERT INTO [Logger] ([CreationDate], [CreationUserId], [ProductId], [Text], [EditDate], [EditUserId], [ImageId], [SKU])
VALUES ('08.03.2019', 2, 5, 'log record #5', '05.05.2019', 1, 0, 'HR-9KQ2-IPD9')

















/*         -- [Currency] --             */
INSERT INTO [Currency] ([UpdateDate], [NumCode], [CharCode], [Nominal], [Name], [Value])
VALUES ('10.09.2019', 124, 'CAD', 1, 'Канадский доллар', 1.3197)

INSERT INTO [Currency] ([UpdateDate], [NumCode], [CharCode], [Nominal], [Name], [Value])
VALUES ('10.09.2019', 036, 'AUD', 1, 'Австралийский доллар', 1.4559)

INSERT INTO [Currency] ([UpdateDate], [NumCode], [CharCode], [Nominal], [Name], [Value])
VALUES ('10.09.2019', 484, 'MXN', 1, 'Мексиканский песо', 19.4413)

INSERT INTO [Currency] ([UpdateDate], [NumCode], [CharCode], [Nominal], [Name], [Value])
VALUES ('10.09.2019', 840, 'USD', 1, 'Доллар США', 1)


/*         -- [CampaignType] --             */
INSERT INTO [CampaignType] ([CampaignName])
VALUES ('Sponsored Products')

INSERT INTO [CampaignType] ([CampaignName])
VALUES ('Sponsored Brands')




























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