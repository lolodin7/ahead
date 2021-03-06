﻿USE AHEAD

--use ahead_stand

/*         -- [Telegram_Bot_Users] --             */
INSERT INTO [Telegram_Bot_Users] ([UserId], [Name])
VALUES (362340016, 'Dima seo')
INSERT INTO [Telegram_Bot_Users] ([UserId], [Name])
VALUES (368357461, 'Marina')
INSERT INTO [Telegram_Bot_Users] ([UserId], [Name])
VALUES (383296019, 'Vasiliy')
INSERT INTO [Telegram_Bot_Users] ([UserId], [Name])
VALUES (192207201, 'Sergey')




/*         -- [MarketPlace] --             */
INSERT INTO [Marketplace] ([MarketPlaceName])
VALUES ('Без маркетплейса')


/*         -- [ProductTypes] --             */
INSERT INTO [ProductTypes] ([TypeName])
VALUES ('Отсутствующие товары')


/*         -- [KeywordCategory] --             */
INSERT INTO [KeywordCategory] ([CategoryName], [ProductTypeId])
VALUES ('Пустая категория', 0)


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

INSERT INTO [Marketplace] ([MarketPlaceName])
VALUES ('PowerDeWise (JP)')

INSERT INTO [Marketplace] ([MarketPlaceName])
VALUES ('Others')


/*         -- [ProductTypes] --             */

INSERT INTO [ProductTypes] ([TypeName])
VALUES ('Микрофоны')

INSERT INTO [ProductTypes] ([TypeName])
VALUES ('Удлинители')

INSERT INTO [ProductTypes] ([TypeName])
VALUES ('Адаптеры')

INSERT INTO [ProductTypes] ([TypeName])
VALUES ('Триподы')

INSERT INTO [ProductTypes] ([TypeName])
VALUES ('Комплектующие к микрофонам')

INSERT INTO [ProductTypes] ([TypeName])
VALUES ('Подарки')

INSERT INTO [ProductTypes] ([TypeName])
VALUES ('Точилки')

INSERT INTO [ProductTypes] ([TypeName])
VALUES ('Держатели ножей')

INSERT INTO [ProductTypes] ([TypeName])
VALUES ('Ножи')

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
VALUES ('02.05.2020', 124, 'CAD', 1, 'Канадский доллар', 1.33)

INSERT INTO [Currency] ([UpdateDate], [NumCode], [CharCode], [Nominal], [Name], [Value])
VALUES ('02.05.2020', 036, 'AUD', 1, 'Австралийский доллар', 1.4559)

INSERT INTO [Currency] ([UpdateDate], [NumCode], [CharCode], [Nominal], [Name], [Value])
VALUES ('02.05.2020', 484, 'MXN', 1, 'Мексиканский песо', 18.71)

INSERT INTO [Currency] ([UpdateDate], [NumCode], [CharCode], [Nominal], [Name], [Value])
VALUES ('02.05.2020', 840, 'USD', 1, 'Доллар США', 1)


/*         -- [ReturnReason] --             */
INSERT INTO [ReturnReason] ([ReasonCode], [ReasonDescription])
VALUES ('UNWANTED_ITEM', '')
INSERT INTO [ReturnReason] ([ReasonCode], [ReasonDescription])
VALUES ('UNDELIVERABLE_UNKNOWN', '')
INSERT INTO [ReturnReason] ([ReasonCode], [ReasonDescription])
VALUES ('NOT_AS_DESCRIBED', '')
INSERT INTO [ReturnReason] ([ReasonCode], [ReasonDescription])
VALUES ('ORDERED_WRONG_ITEM', '')
INSERT INTO [ReturnReason] ([ReasonCode], [ReasonDescription])
VALUES ('DEFECTIVE', '')
INSERT INTO [ReturnReason] ([ReasonCode], [ReasonDescription])
VALUES ('UNAUTHORIZED_PURCHASE', '')
INSERT INTO [ReturnReason] ([ReasonCode], [ReasonDescription])
VALUES ('MISSING_PARTS', '')
INSERT INTO [ReturnReason] ([ReasonCode], [ReasonDescription])
VALUES ('QUALITY_UNACCEPTABLE', '')
INSERT INTO [ReturnReason] ([ReasonCode], [ReasonDescription])
VALUES ('FOUND_BETTER_PRICE', '')
INSERT INTO [ReturnReason] ([ReasonCode], [ReasonDescription])
VALUES ('SWITCHEROO', '')
INSERT INTO [ReturnReason] ([ReasonCode], [ReasonDescription])
VALUES ('DAMAGED_BY_CARRIER', '')
INSERT INTO [ReturnReason] ([ReasonCode], [ReasonDescription])
VALUES ('NOT_COMPATIBLE', '')
INSERT INTO [ReturnReason] ([ReasonCode], [ReasonDescription])
VALUES ('MISSED_ESTIMATED_DELIVERY', '')
INSERT INTO [ReturnReason] ([ReasonCode], [ReasonDescription])
VALUES ('UNDELIVERABLE_INSUFFICIENT_ADDRESS', '')
INSERT INTO [ReturnReason] ([ReasonCode], [ReasonDescription])
VALUES ('NO_REASON_GIVEN', '')
INSERT INTO [ReturnReason] ([ReasonCode], [ReasonDescription])
VALUES ('UNDELIVERABLE_REFUSED', '')
INSERT INTO [ReturnReason] ([ReasonCode], [ReasonDescription])
VALUES ('DAMAGED_BY_FC', '')
INSERT INTO [ReturnReason] ([ReasonCode], [ReasonDescription])
VALUES ('EXTRA_ITEM', '')
INSERT INTO [ReturnReason] ([ReasonCode], [ReasonDescription])
VALUES ('MISORDERED', '')
INSERT INTO [ReturnReason] ([ReasonCode], [ReasonDescription])
VALUES ('NEVER_ARRIVED', '')
INSERT INTO [ReturnReason] ([ReasonCode], [ReasonDescription])
VALUES ('UNDELIVERABLE_UNCLAIMED', '')
INSERT INTO [ReturnReason] ([ReasonCode], [ReasonDescription])
VALUES ('UNDELIVERABLE_FAILED_DELIVERY_ATTEMPTS', '')
INSERT INTO [ReturnReason] ([ReasonCode], [ReasonDescription])
VALUES ('UNDELIVERABLE_CARRIER_MISS_SORTED', '')


/*         -- [DetailedDisposition] --             */
INSERT INTO [DetailedDisposition] ([DispositionCode], [DispositionDescription])
VALUES ('CUSTOMER_DAMAGED', '')
INSERT INTO [DetailedDisposition] ([DispositionCode], [DispositionDescription])
VALUES ('SELLABLE', '')
INSERT INTO [DetailedDisposition] ([DispositionCode], [DispositionDescription])
VALUES ('DEFECTIVE', '')
INSERT INTO [DetailedDisposition] ([DispositionCode], [DispositionDescription])
VALUES ('CARRIER_DAMAGED', '')
INSERT INTO [DetailedDisposition] ([DispositionCode], [DispositionDescription])
VALUES ('DAMAGED', '')


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
INSERT INTO [User] ([Login], [PassHash], [Name], [Token1], [Token2], [UserRoleId], [SecretQuestion], [Answer], [LastMac])
VALUES ('raizz', 'ADAH/ZuvEVdABXe4AuzqwknkxSZzRbhdj21avq9UvFa5E2HiQwcJ2WfdI868yw9A9g==', 'Дима', 123, 321, 0, 'Номер офиса', 'AEBZF6htjJp6bJmhb7Of6vmRm2wu4vthhjEUZMivrOi6GHC+oIeiJXSlTqTTUlWgnA==', '00FFCD3F0DEB')

INSERT INTO [User] ([Login], [PassHash], [Name], [Token1], [Token2], [UserRoleId], [SecretQuestion], [Answer], [LastMac])
VALUES ('test1', 'ADAH/ZuvEVdABXe4AuzqwknkxSZzRbhdj21avq9UvFa5E2HiQwcJ2WfdI868yw9A9g==', 'boss', 123, 321, 1, 'Номер офиса', 'AEBZF6htjJp6bJmhb7Of6vmRm2wu4vthhjEUZMivrOi6GHC+oIeiJXSlTqTTUlWgnA==', '00FF60C1B9B4')

INSERT INTO [User] ([Login], [PassHash], [Name], [Token1], [Token2], [UserRoleId], [SecretQuestion], [Answer], [LastMac])
VALUES ('test2', 'ADAH/ZuvEVdABXe4AuzqwknkxSZzRbhdj21avq9UvFa5E2HiQwcJ2WfdI868yw9A9g==', 'user', 123, 321, 2, 'Номер офиса', 'AEBZF6htjJp6bJmhb7Of6vmRm2wu4vthhjEUZMivrOi6GHC+oIeiJXSlTqTTUlWgnA==', '00FF60C1B9B4')


/*         -- [Products] --             */
INSERT INTO [Products] ([Name])
VALUES ('Товары отсутствуют')



/*      ----     PDW - USA     ----        */

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('TRRS to TRS Aux Male to Female Adapter (old)', 'B01BMAA31C', '00-P9PR-IKGL', 3, 1, 0, 'Adapter 4-3 (old)')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Magnetic Knife Holder 12.5 inch (old)', 'B01DIU9FP4', 'ArtDeHomeLightWalnut12', 8, 1, 0, 'Knife Holder (old)')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Micro USB Cable (3ft)', 'B01MDV1NSW', 'ZD-DES3-1YXC', 2, 1, 1, 'Micro-usb-cord-3ft')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Flexible Tripod (old)', 'B01MG2BEVZ', 'P9-8LPU-DGDW', 4, 1, 0, 'Flexible tripod(old)')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('YouMic Mic Clip', 'B07BFWVJH1', 'N5-YBHW-NM5X', 5, 1, 0, 'YM Mic Clip')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Magnetic Knife Holder Walnut', 'B07DW5X3LY', 'adhhldrwlnt', 8, 1, 0, 'Knife Holder Walnut')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW (tech.)', 'B07FCJCDDM', 'pdwmcslvr2', 1, 1, 0, 'PDW1 (tech)')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Magnetic Knife Holder Acacia', 'B07FCNH5SL', 'adhhldacca', 8, 1, 0, 'Knife Holder Acacia')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Video Microphone with Lightning Adapter', 'B07FDYXBQZ', 'BS-2QKM-S6HA', 1, 1, 1, 'Video Mic Adapter')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Video Microphone with Lightning Adapter (fake)', 'B07FDYXBQZ', 'ymcchld4', 1, 1, 1, 'Video Mic Adapter')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Video Microphone with Lightning Adapter (fake)', 'B07FDYXBQZ', 'Z6-F3KH-F1LD', 1, 1, 0, 'Video Mic Adapter')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('YouMic Lav Mic (old)', 'B07FF1XHHT', 'ymcchld5', 1, 1, 1, 'YM1-Ch Lav Mic')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW iPhone Mic (old child)', 'B07GYB43P2', 'pdwmcslvr4', 1, 1, 0, 'PDW-Ch iPhone Mic')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Video Mic Holder Only', 'B07W67B9ND', '95-G8B1-D9NS', 5, 1, 0, 'Video Mic Holder - Parts')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Replacement Parts Video Mic (Clip)', 'B07WNQ6XDY', 'FP-SYMU-0U7C', 5, 1, 1, 'Video Mic Clip - Parts')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Replacement Parts Video Mic (Muff)', 'B07WR3RLQK', 'WD-5ZX5-VWPP', 5, 1, 1, 'Video Mic Muff - Parts')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Replacement Parts Video Mic (Cable DSLR)', 'B07XKSCVZL', '69-ZH9C-K0FM', 5, 1, 1, 'Video Mic Cable DSLRmarts - Parts')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Replacement Parts Video Mic (Mic)', 'B07XNX73CS', 'KU-XYPH-NJ6C', 5, 1, 1, 'Video Mic Mic - Parts')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Replacement Parts Video Mic (Cable Smart)', 'B07XP2CGPH', '5E-6VFE-6PID', 5, 1, 1, 'Video Mic Cable Smart - Parts')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Flexible Tripod', 'B07YQ1356W', 'P3-E9MG-2U03', 4, 1, 1, 'Flexible - Parts')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Video Mic Case Handle', 'B07YTVV1ZN', 'BF-7VXK-ARRO', 5, 1, 0, 'Video Mic Case - Parts')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW Mic with Lightning Connector', 'B07Z4SPKDD', 'EV-0CHK-U3N5', 1, 1, 1, 'PDW-Ch Lightning Connector')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW Main Mic', 'B01AG56HYQ', 'IG-5UO9-SCW1', 1, 1, 1, 'PDW1')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW Main Mic', 'B01AG56HYQ', 'LR-44G2-7Y1Y', 1, 1, 0, 'PDW1')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW Main Mic', 'B01AG56HYQ', 'E3-2RHF-EO7C', 1, 1, 1, 'PDW1')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Y-Connector 2 mics', 'B01BNGAHCA', 'KS-ZYQB-G549', 3, 1, 1, 'Y-Connector 2-M')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('YouMic Main Mic', 'B01E3L1ESS', '8R-MO3B-ZV8H', 1, 1, 1, 'YM1')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Knife Sharpener', 'B01FS5VJMY', 'GK-RHNH-11NI', 7, 1, 1, 'Knife Sharpener')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW Wind Muff', 'B01LL5U0NO', 'DL-LJ4D-RKZH', 5, 1, 1, 'PDW Wind Muff')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW Mic Clip', 'B01LZ6T9XO', '1N-NPIV-XHND', 5, 1, 1, 'PDW Mic Clip')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Extension cord 6ft', 'B01LZBEH3W', 'XZ-8LJT-BPX3', 2, 1, 1, 'Ext-cord-6')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('TRRS-TRS Headphone adapter', 'B01N5RG8EC', 'ZW-WW1I-PT7A', 3, 1, 1, 'Adapter 4-3 Headphone')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('USB adapter', 'B0713SJ2ZD', 'AB-KG1N-IPYL', 3, 1, 1, 'Adapter USB')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Furry Wind Muff', 'B075FS5Y7Z', 'O9-U3F0-WROB', 5, 1, 1, 'Furry Wind Muff')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Knife Sharpener', 'B079YP5L6J', 'FF-TB8V-VKY4', 7, 1, 1, 'Knife Sharpener')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('YouMic Wind Muff', 'B07BFXR55J', 'AV-ALS4-5BSO', 5, 1, 1, 'YM Wind Muff')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Extension cord 15ft', 'B07CHBGV5X', '3J-03VY-3VT0', 2, 1, 1, 'Ext-cord-15')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Extension cord 3ft', 'B07CHC94XT', 'PI-HW8D-6TTD', 2, 1, 1, 'Ext-cord-3')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW Dual Mic', 'B07CHCSLVC', 'HR-9KQ2-IPD9', 1, 1, 1, 'PDW-Ch Dual')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Extension cord 10ft', 'B07CHFG1FN', 'BQ-CK10-HCVV', 2, 1, 1, 'Ext-cord-10')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Tripod (silver old)', 'B07CJRB8YB', 'E3-1WM4-S3MY', 4, 1, 1, 'Tripod-Silver')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW Podcast Mic', 'B07FCN1K2N', 'pdwmcslvr6', 1, 1, 1, 'PDW-Ch Podcast')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW Android Mic', 'B07FCSQGPY', 'pdwmcslvr3', 1, 1, 1, 'PDW-Ch Android')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('YouMic iPhone Mic', 'B07FF15VYZ', 'ymcchld3', 1, 1, 1, 'YM-Ch iPhone')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('YouMic Dual Mic', 'B07G2C8D7H', 'XW-I4VB-F8W5', 1, 1, 1, 'YM-Ch Dual')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Y-Connector Mic+Headphone', 'B07G4DS728', 'GH-7TR8-5HPZ', 3, 1, 1, 'Y-Connector M-H')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('TRRS-TRS Mic adapter', 'B07KB11Y5B', 'OD-HA9N-UXNF', 3, 1, 1, 'Adapter 4-3 Mic')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('YouMic Android Mic', 'B07M9PBN5X', 'ymcchld2', 1, 1, 1, 'YM-Ch Android')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Video Mic', 'B07RG4J7WY', 'YW-WUH0-BXZW', 1, 1, 1, 'Video Microphone')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Video Mic (fake)', 'B07RG4J7WY', '2V-8VSV-C0AE', 1, 1, 0, 'Video Microphone')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Video Mic (fake)', 'B07RG4J7WY', '9S-4JMY-MS8X', 1, 1, 1, 'Video Microphone')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW Vlogger Kit', 'B07RLJHT5B', 'O5-HZWD-YO8M', 1, 1, 1, 'PDW-Ch Vlogger Kit')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW Mic with Type-C Adapter', 'B07RMXR4FB', 'HH-4FJF-QK02', 1, 1, 1, 'PDW-Ch Type-C')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Youmic Mic with Lightning Adapter', 'B07WS5DGCS', 'AM-X9B2-T6B1', 1, 1, 1, 'YM-Ch Lightning Adapter')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW Mic with Lightning Connector (old)', 'B07XJNN9B1', 'YA-AFP8-2UT7', 1, 1, 0, 'PDW-Ch Lightning Connector')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Lightning-3.5mm adapter', 'B07Y1QVPPP', '8Z-BHZ0-0X8Q', 3, 1, 1, 'Adapter Lightning')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW Mic with Lightning Adapter', 'B07Y1XBKC7', 'NT-HV0T-VR4C', 1, 1, 1, 'PDW-Ch Lightning Adapter')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW Main Mic', 'B01AG56HYQ', 'QU-V2H6-3KVF', 1, 1, 0, 'PDW1')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PowerDeWise Parent (Lightning)', 'B07GVMB7V3', 'NE-M9GA-VAR0', 1, 1, 0, 'Trash')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Knife set (Walnut)', 'B07FLYJTLB', 'adhknfstwlnt', 9, 1, 0, 'Trash')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('TEST Lav Mic PDW', 'B07D75NK1M', 'N2-7X7R-GO3P', 1, 1, 0, 'Trash')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Knife set (Acacia)', 'B07DWWMW8H', 'adhknfstlt', 9, 1, 0, 'Trash')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Empty', 'B07CVL3Z81', 'BM-DBA9-LO4L', 1, 1, 0, 'Trash')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Empty', 'B01MDV1TO4', '32-FM61-Q39H', 1, 1, 0, 'Trash')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Cork Yoga block', 'B072VJFQ6X', 'DW-L589-8Q78', 1, 1, 0, 'Trash')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Headphone Adapter 3.5mm', 'B077GX8RV3', 'R6-7GCS-ARC3', 3, 1, 0, 'Trash')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Empty', 'B01MR8635I', 'IE-Y8IQ-ZAXW', 1, 1, 0, 'Trash')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Magnetic Knife Holder Walnut', 'B07DW5X3LY', 'EB-6ZCI-VHDS', 8, 1, 0, 'Knife Holder Walnut')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Empty', 'B079JYP8R2', 'CR-88U3-PFTL', 1, 1, 0, 'Trash')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Knife set (Walnut)', 'B07FLYJTLB', 'P6-17F3-PN6B', 9, 1, 0, 'Trash')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Empty', 'B075712B8L', 'F1-DHWE-DPSL', 1, 1, 0, 'Trash')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Empty', 'B01CLQGBI0', 'ArtDeHomeDarkWalnut12', 1, 1, 0, 'Trash')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Empty', 'B0756WZTFR', 'WF-0PPY-KRDD', 1, 1, 0, 'Trash')


/*      ----     PDW - CA     ----        */

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW Mic with Type-C Adapter', 'B07RMXR4FB', 'HH-4FJF-QK02', 3, 2, 1, 'PDW-Ch Type-C')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('YM Dual Mic', 'B07G2C8D7H', 'XW-I4VB-F8W5', 1, 2, 1, 'YM-Ch Dual')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW Mic Clip', 'B01LZ6T9XO', 'pdwmicclip', 5, 2, 0, 'PDW Mic Clip')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW Main Mic', 'B01AG56HYQ', 'IG-5UO9-SCW1', 1, 2, 1, 'PDW1')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW (tech.)', 'B07D75NK1M', 'N2-7X7R-GO3P', 5, 2, 0, 'PDW (tech.)')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW Android Mic', 'B07FCSQGPY', 'pdwmcslvr3', 1, 2, 0, 'PDW-Ch Android')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW Podcast Mic', 'B07FCN1K2N', 'pdwmcslvr6', 1, 2, 0, 'PDW-Ch Podcast')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW Mini Mic', 'B07FCJCDDM', 'pdwmcslvr2', 1, 2, 0, 'PDW-Ch Mini')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW iPhone Mic', 'B07GYB43P2', 'pdwmcslvr4', 1, 2, 0, 'PDW-Ch iPhone')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('TRRS-TRS Mic adapter', 'B07KB11Y5B', 'OD-HA9N-UXNF', 3, 2, 1, 'Adapter 4-3 Mic')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Tripod (silver old)', 'B07CJRB8YB', 'E3-1WM4-S3MY', 4, 2, 1, 'Tripod-Silver')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW Dual Mic', 'B07CHCSLVC', 'HR-9KQ2-IPD9', 1, 2, 1, 'PDW-Ch Dual')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW Mic Clip', 'B01LZ6T9XO', '1N-NPIV-XHND', 5, 2, 1, 'PDW Mic Clip')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW Nikon', 'B07FDB9Z15', 'pdwchildcnd4', 1, 2, 0, 'PDW-Ch Nikon')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Extension cord 6ft', 'B01LZBEH3W', 'XZ-8LJT-BPX3', 2, 2, 1, 'Ext-cord-6')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Knife Sharpener', 'B01FS5VJMY', '2P-5QGL-927D', 7, 2, 0, 'Knife Sharpener')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW Wind Muff', 'B01LL5U0NO', 'DL-LJ4D-RKZH', 5, 2, 1, 'PDW Wind Muff')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('TRRS to TRS Aux Male to Female Adapter (old)', 'B01BMAA31C', 'O2-N29T-KEZL', 3, 2, 0, 'Adapter 4-3 (old)')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('TRRS toTRS Headphones Adapter … ', 'B077GX8RV3', '1D-7EAO-QAI4', 3, 2, 0, 'Adapter 4-3 (old)')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Y-Connector 2 mics', 'B01BNGAHCA', 'KS-ZYQB-G549', 3, 2, 1, 'Y-Connector 2-M')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('YM Main Mic', 'B01E3L1ESS', '8R-MO3B-ZV8H', 1, 2, 1, 'YM1')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW Main Mic', 'B01AG56HYQ', 'E3-2RHF-EO7C', 1, 2, 1, 'PDW1')




/*      ----     PDW - AU     ----        */

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Y-Connector 2 mics', 'B01BNGAHCA', 'T2-L2E5-98SO', 3, 3, 0, 'Y-Connector 2-M')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('YM Main Mic', 'B01E3L1ESS', '8R-MO3B-ZV8H', 1, 3, 1, 'YM1')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW Main Mic', 'B01AG56HYQ', 'E3-2RHF-EO7C', 1, 3, 1, 'PDW1')



/*      ----     PDW - MX     ----        */

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('YM Dual Mic', 'B07G2C8D7H', 'XW-I4VB-F8W5', 1, 4, 1, 'YM-Ch Dual')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW Mic Clip', 'B01LZ6T9XO', 'B2-ARED-FQVV', 5, 4, 0, 'PDW Mic Clip')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Y-Connector 2 mics', 'B01BNGAHCA', 'T2-L2E5-98SO', 3, 4, 0, 'Y-Connector 2-M')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('YM Main Mic', 'B01E3L1ESS', '8R-MO3B-ZV8H', 1, 4, 1, 'YM1')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW Main Mic', 'B01AG56HYQ', 'E3-2RHF-EO7C', 1, 4, 1, 'PDW1')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW Dual Mic', 'B07CHCSLVC', 'HR-9KQ2-IPD9', 1, 4, 1, 'PDW-Ch Dual')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW Wind Muff', 'B01LL5U0NO', 'DL-LJ4D-RKZH', 5, 4, 1, 'PDW Wind Muff')



/*      ----     LETIT.BEER - USA     ----        */

INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Bottle Holder', 'B07ZTMZ5KY', '2L-H8LF-KK2R', 6, 5, 0, 'Bottle Holder')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Beer Chiller 4pcs Set', 'B07W55V4J4', 'L4-8CD8-JB7X', 6, 5, 0, 'Beer Chiller - 4pcs')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Wall Bottle Opener', 'B07RS42JDL', 'AX-47JG-76NJ', 6, 5, 0, 'Wall Bottle Opener')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('YW test mic', 'B07NXZRZT3', '4I-UAU7-VMOM', 1, 5, 0, 'YW test mic')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Beer Chiller - Child', 'B07QTJSTY2', 'D3-LD5I-IJ3D', 6, 5, 0, 'Beer Chiller - Child')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Beer Chiller - Child', 'B07KGB2V7J', 'S9-6Z6V-EHNU', 6, 5, 0, 'Beer Chiller - Child')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Beer Chiller - Child', 'B07HJBVKCW', '8F-L6ZK-1C4V', 6, 5, 0, 'Beer Chiller - Child')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Beer Chiller - Child', 'B07KGCX718', 'MO-IZZJ-C4R9', 6, 5, 0, 'Beer Chiller - Child')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Beer Chiller - Child', 'B07FYMFJ66', 'AB-H4V8-9Y4L', 6, 5, 0, 'Beer Chiller - Child')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Retractable Cable', 'B07N8TNV19', 'FV-6NAJ-A3RR', 2, 5, 1, 'Retractable Cable')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Metal Bottle Opener', 'B07FDTG3RT', '3L-NQRO-HJSR', 6, 5, 0, 'Metal Bottle Opener')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW Main Mic', 'B01AG56HYQ', '6A-ICQP-MBHC', 1, 5, 0, 'PDW1')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PC Streaming Mic', 'B07NL57WPP', 'RJ-EAFY-N63K', 1, 5, 0, 'Streaming Mic')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Beard Template', 'B07DTL3XR5', '52-322Z-K8F2', 6, 5, 0, 'Beard Template')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('YW2 Mic', 'B06ZZ6NPRP', 'LD-YUMV-LDZV', 1, 5, 1, 'YW2')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('YW1 Mic', 'B01C2NDT0K', '54-DS59-U9N0', 1, 5, 1, 'YW1')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Beer Chiller', 'B01AI03U4Y', 'BC-GHGX-5M0O', 6, 5, 1, 'Beer Chiller')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('PDW Dual Mic', 'B07CHCSLVC', '6D-EU7F-YIW0', 1, 5, 0, 'PDW-Ch Dual')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Empty', 'B0771NGB9R', '7Z-OBHC-J1CJ', 1, 5, 0, 'Trash')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('Empty', 'B07519NGKN', '0O-Y1S8-VMOO', 1, 5, 0, 'Trash')
INSERT INTO [Products] ([Name], [ASIN], [SKU], [ProductTypeId], [MarketPlaceId], [ActiveStatus], [ProdShortName])
VALUES ('YW2 Mic', 'B06ZZ6NPRP', 'MV-Q3XJ-F262', 1, 5, 1, 'YW2')
































/*


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

*/


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