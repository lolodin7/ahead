USE AHEAD

--use ahead_stand

--��� �������� ������� �� ������� ��������

IF NOT OBJECT_ID('Telegram_Bot_Users') IS NULL DROP TABLE [Telegram_Bot_Users]
GO

IF NOT OBJECT_ID('Stock') IS NULL DROP TABLE [Stock]
GO

IF NOT OBJECT_ID('ReturnsReport') IS NULL DROP TABLE [ReturnsReport]
GO

IF NOT OBJECT_ID('BusinessReport') IS NULL DROP TABLE [BusinessReport]
GO

IF NOT OBJECT_ID('AdvertisingProducts') IS NULL DROP TABLE [AdvertisingProducts]
GO

IF NOT OBJECT_ID('AdvertisingBrands') IS NULL DROP TABLE [AdvertisingBrands]
GO

IF NOT OBJECT_ID('Currency') IS NULL DROP TABLE [Currency]
GO

IF NOT OBJECT_ID('CampaignType') IS NULL DROP TABLE [CampaignType]
GO

IF NOT OBJECT_ID('AB_CampaignIds') IS NULL DROP TABLE [AB_CampaignIds]
GO

IF NOT OBJECT_ID('AP_CampaignIds') IS NULL DROP TABLE [AP_CampaignIds]
GO

IF NOT OBJECT_ID('DetailedDisposition') IS NULL DROP TABLE [DetailedDisposition]
GO

IF NOT OBJECT_ID('ReturnReason') IS NULL DROP TABLE [ReturnReason]
GO

IF NOT OBJECT_ID('Logger') IS NULL DROP TABLE [Logger]
GO

IF NOT OBJECT_ID('Images') IS NULL DROP TABLE [Images]
GO

IF NOT OBJECT_ID('SemCoreArchive') IS NULL DROP TABLE [SemCoreArchive]
GO

IF NOT OBJECT_ID('SemCore') IS NULL DROP TABLE [SemCore]
GO

IF NOT OBJECT_ID('KeywordCategory') IS NULL DROP TABLE [KeywordCategory]
GO

IF NOT OBJECT_ID('Products') IS NULL DROP TABLE [Products]
GO

IF NOT OBJECT_ID('ProductTypes') IS NULL DROP TABLE [ProductTypes]
GO

IF NOT OBJECT_ID('Marketplace') IS NULL DROP TABLE [Marketplace]
GO

IF NOT OBJECT_ID('User') IS NULL DROP TABLE [User]
GO

IF NOT OBJECT_ID('UserRole') IS NULL DROP TABLE [UserRole]
GO

IF NOT OBJECT_ID('Currency') IS NULL DROP TABLE [Currency]
GO

IF NOT OBJECT_ID('CampaignType') IS NULL DROP TABLE [CampaignType]
GO

IF NOT OBJECT_ID('Orders') IS NULL DROP TABLE [Orders]
GO
/*
    "�� �������� AHEAD"
*/
CREATE TABLE [Telegram_Bot_Users](
	[UserId]		BIGINT,
	[Name]			VARCHAR(50)
	CONSTRAINT PK_Telegram_Bot_Users PRIMARY KEY ([UserId])
)
GO


CREATE TABLE [Marketplace](
	[MarketPlaceId]		INT IDENTITY(0,1),
	[MarketPlaceName]	VARCHAR(20),
	CONSTRAINT PK_Marketplace_MarketPlaceId PRIMARY KEY ([MarketPlaceId])
)
GO

CREATE TABLE [ProductTypes](
	[ProductTypeId]		INT IDENTITY(0,1)	NOT NULL,
	[TypeName]			VARCHAR(100),
	CONSTRAINT PK_ProductTypes PRIMARY KEY ([ProductTypeId])
)
GO

CREATE TABLE [KeywordCategory](
	[CategoryId]		INT IDENTITY(0,1),
	[CategoryName]		VARCHAR(100),
	[ProductTypeId]		INT,
	CONSTRAINT UQ_KeywordCategory_CategoryName UNIQUE ([CategoryName]),
	CONSTRAINT PK_KeywordCategory PRIMARY KEY ([CategoryId]),
	CONSTRAINT FKKeywordsCategory_ProductTypeId FOREIGN KEY ([ProductTypeId]) REFERENCES ProductTypes ([ProductTypeId])
)
GO

CREATE TABLE [SemCore](
	[ProductTypeId]		INT					NOT NULL,
	[CategoryId]		INT					NOT NULL,
	[Keyword]			VARCHAR(100),
	[Value]				INT,
	[LastUpdated]		DATETIME,
	[MarketPlaceId]		INT					NOT NULL,
	[SemCoreId]			INT IDENTITY(0,1)	NOT NULL,
	CONSTRAINT PK_SemCoreId PRIMARY KEY ([SemCoreId]),
	CONSTRAINT UQ_SemCore_Keyword UNIQUE ([Keyword], [MarketPlaceId]),
	CONSTRAINT FK_SemCore_ProductTypes FOREIGN KEY ([ProductTypeId]) REFERENCES ProductTypes ([ProductTypeId]),
	CONSTRAINT FK_SemCore_CategoryId FOREIGN KEY ([CategoryId]) REFERENCES KeywordCategory ([CategoryId]),
	CONSTRAINT FK_SemCore_MarketPlaceId FOREIGN KEY ([MarketPlaceId]) REFERENCES MarketPlace ([MarketPlaceId])
)
GO

CREATE TABLE [SemCoreArchive](
	[ProductTypeId]		INT					NOT NULL,
	[CategoryId]		INT					NOT NULL,
	[Keyword]			VARCHAR(100)		NOT NULL,
	[SemCoreId]			INT					NOT NULL,
	[ValuesAndDates]	TEXT,	
	[MarketPlaceId]		INT					NOT NULL,
)
GO

CREATE TABLE [Products](
	[ProductId]			INT IDENTITY(0,1)	NOT NULL,
	[Name]				NVARCHAR(1000),
	[ASIN]				VARCHAR(20),
	[SKU]				VARCHAR(30),
	[ProductTypeId]		INT,
	[MarketPlaceId]		INT,
	[ActiveStatus]		BIT,
	[ProdShortName]		NVARCHAR(500),
	CONSTRAINT PK_Products PRIMARY KEY ([ProductId]),
	CONSTRAINT UQ_Products_SKU UNIQUE ([SKU], [MarketPlaceId]),
	CONSTRAINT FK_Products_ProductTypes FOREIGN KEY ([ProductTypeId]) REFERENCES ProductTypes ([ProductTypeId]),
	CONSTRAINT FK_Products_Marketplace FOREIGN KEY ([MarketPlaceId]) REFERENCES Marketplace ([MarketPlaceId])
)
GO

--IF NOT OBJECT_ID('Stock') IS NULL DROP TABLE [Stock]
CREATE TABLE [Stock](
	[UpdateDate]		DateTime,
	[ProductId]			INT,
	[Name]				NVARCHAR(1000),
	[ASIN]				VARCHAR(20),
	[SKU]				VARCHAR(30),
	[FNSKU]				VARCHAR(30),
	[MarketPlaceId]		INT,
	[FulfillableItems]	INT,
	[ReservedItems]		INT,
	[InboundShipped]	INT,
	[InboundWorking]	INT
)
GO

CREATE TABLE [UserRole](
	[UserRoleId]		INT IDENTITY(0,1),
	[Name]				VARCHAR(100),
	CONSTRAINT UQ_UserRole_UserRoleId UNIQUE ([UserRoleId])
)

CREATE TABLE [User](
	[UserId]			INT IDENTITY(0,1),
	[Login]				VARCHAR(20),
	[PassHash]			TEXT,
	[Name]				VARCHAR(50),
	[Token1]			INT,
	[Token2]			INT,
	[UserRoleId]		INT,
	[SecretQuestion]	VARCHAR(100),
	[Answer]			VARCHAR(100),
	[LastMac]				TEXT,
	CONSTRAINT PK_User PRIMARY KEY ([UserId]),
	CONSTRAINT UQ_User_Login UNIQUE ([Login]),
	CONSTRAINT FK_User_UserRoleId FOREIGN KEY ([UserRoleId]) REFERENCES UserRole ([UserRoleId])
)

CREATE TABLE [Images](
	[ImageId]			INT IDENTITY(0,1),
	[FileName]			NVARCHAR(100),
	[Title]				NVARCHAR(100),
	[ImageData]			VARBINARY(MAX),
	CONSTRAINT PK_Images PRIMARY KEY ([ImageId])
)

CREATE TABLE [Logger](
	[RecordId]			INT IDENTITY(0,1),
	[CreationDate]		DATETIME,
	[CreationUserId]	INT,
	[ProductId]			INT,
	[Text]				TEXT,
	[EditDate]			DATETIME,
	[EditUserId]		INT,
	[ImageId]			VARCHAR(1000),
	[SKU]				VARCHAR(30),
	CONSTRAINT PK_Logger PRIMARY KEY ([RecordId]),
	CONSTRAINT FK_Logger_ProductId FOREIGN KEY ([ProductId]) REFERENCES Products ([ProductId]),
	CONSTRAINT FK_Logger_CreationUserId FOREIGN KEY ([CreationUserId]) REFERENCES [User] ([UserId]),
	CONSTRAINT FK_Logger_EditUserId FOREIGN KEY ([EditUserId]) REFERENCES [User] ([UserId])
)

CREATE TABLE [ReturnReason](
	[ReasonId]						INT IDENTITY(0, 1),
	[ReasonCode]					VARCHAR(512),
	[ReasonDescription]				VARCHAR(512),
	CONSTRAINT PK_ReturnReason PRIMARY KEY ([ReasonId])	
)

CREATE TABLE [DetailedDisposition](
	[DispositionId]					INT IDENTITY(0, 1),
	[DispositionCode]				VARCHAR(512),
	[DispositionDescription]		VARCHAR(512),
	CONSTRAINT PK_DetailedDisposition PRIMARY KEY ([DispositionId])	
)

CREATE TABLE [Currency](
	[UpdateDate]		DATETIME,
	[NumCode]			INT,
	[CharCode]			VARCHAR(10),
	[Nominal]			INT,
	[Name]				VARCHAR(100),
	[Value]				FLOAT
)
GO

CREATE TABLE [CampaignType](
	[CampaignId]			INT IDENTITY(0,1),
	[CampaignName]			VARCHAR(255),
	CONSTRAINT PK_CampaignType PRIMARY KEY ([CampaignId])
)

CREATE TABLE [AP_CampaignIds](
	[CampaignId]		BIGINT,
	[CampaignName]		VARCHAR(255),
	CONSTRAINT PK_AP_CampaignIds PRIMARY KEY ([CampaignId])
)

CREATE TABLE [AB_CampaignIds](
	[CampaignId]		BIGINT,
	[CampaignName]		VARCHAR(255),
	CONSTRAINT PK_AB_CampaignIds PRIMARY KEY ([CampaignId])
)

CREATE TABLE [AdvertisingProducts](
	[UpdateDate]		DATETIME,
	[CurrencyCharCode]	VARCHAR(10),
	[CampaignName]		VARCHAR(255),
	[AdGroupName]		VARCHAR(255),
	[Targeting]			VARCHAR(100),
	[MatchType]			VARCHAR(32),
	[Impressions]		BIGINT,
	[Clicks]			BIGINT,
	[CTR]				FLOAT,
	[CPC]				FLOAT,
	[Spend]				FLOAT,
	[Sales]				FLOAT,
	[ACoS]				FLOAT,
	[RoAS]				FLOAT,
	[Orders]			BIGINT,
	[Units]				BIGINT,
	[ConversionRate]	FLOAT,
	[AdvSKUUnits]		BIGINT,
	[OtherSKUUnits]		BIGINT,
	[AdvSKUSales]		FLOAT,
	[OtherSKUSales]		FLOAT,
	[CampaignTypeId]	INT,
	[MarketPlaceId]		INT,
	[CampaignId]		BIGINT,
	[ProductId]			INT,
	CONSTRAINT PK_AdvertisingProducts PRIMARY KEY ([UpdateDate], [CampaignName], [AdGroupName], [Targeting], [MatchType], [ProductId]),
	CONSTRAINT FK_AdvertisingProducts_CampaignId FOREIGN KEY ([CampaignTypeId]) REFERENCES [CampaignType] ([CampaignId]),
	CONSTRAINT FK_AdvertisingProducts_MarketPlaceId FOREIGN KEY ([MarketPlaceId]) REFERENCES [MarketPlace] ([MarketPlaceId]),
	CONSTRAINT FK_AdvertisingProducts_ProductId FOREIGN KEY ([ProductId]) REFERENCES [Products] ([ProductId]),
	CONSTRAINT FK_AdvertisingProducts_AP_CampaignIds FOREIGN KEY ([CampaignId]) REFERENCES [AP_CampaignIds] ([CampaignId])
)

CREATE TABLE [AdvertisingBrands](
	[UpdateDate]			DATETIME,
	[CurrencyCharCode]		VARCHAR(10),
	[CampaignName]			VARCHAR(255),
	[Targeting]				VARCHAR(100),
	[MatchType]				VARCHAR(32),
	[Impressions]			BIGINT,
	[Clicks]				BIGINT,
	[CTR]					FLOAT,
	[CPC]					FLOAT,
	[Spend]					FLOAT,
	[ACoS]					FLOAT,
	[RoAS]					FLOAT,
	[Sales]					FLOAT,
	[Orders]				BIGINT,
	[Units]					BIGINT,
	[ConversionRate]		FLOAT,
	[NewToBrandOrders]		BIGINT,
	[NewToBrandSales]		FLOAT,
	[NewToBrandUnits]		BIGINT,
	[NewToBrandOrderRate]	FLOAT,
	[CampaignTypeId]		INT,
	[MarketPlaceId]			INT,
	[CampaignId]			BIGINT,	
	[ProductId1]			INT,
	[ProductId2]			INT,
	[ProductId3]			INT,
	CONSTRAINT FK_AdvertisingBrands_CampaignId FOREIGN KEY ([CampaignTypeId]) REFERENCES [CampaignType] ([CampaignId]),
	CONSTRAINT FK_AdvertisingBrands_MarketPlaceId FOREIGN KEY ([MarketPlaceId]) REFERENCES [MarketPlace] ([MarketPlaceId]),
	CONSTRAINT FK_AdvertisingBrands_ProductId1 FOREIGN KEY ([ProductId1]) REFERENCES [Products] ([ProductId]),
	CONSTRAINT FK_AdvertisingBrands_ProductId2 FOREIGN KEY ([ProductId2]) REFERENCES [Products] ([ProductId]),
	CONSTRAINT FK_AdvertisingBrands_ProductId3 FOREIGN KEY ([ProductId3]) REFERENCES [Products] ([ProductId]),
	CONSTRAINT FK_AdvertisingBrands_AB_CampaignIds FOREIGN KEY ([CampaignId]) REFERENCES [AB_CampaignIds] ([CampaignId])
)

CREATE TABLE [BusinessReport](
	[UpdateDate]				DATETIME,
	[MarketPlaceId]				INT,
	[SKU]						VARCHAR(30),
	[Sessions]					INT,
	[SessionPercentage]			FLOAT,
	[PageViews]					INT,
	[PageViewsPercentage]		FLOAT,
	[UnitsOrdered]				INT,
	[UnitsOrderedB2B]			INT,
	[UnitSessionPercentage]		FLOAT,
	[UnitSessionPercentageB2B]	FLOAT,
	[OrderedProductSales]		FLOAT,
	[OrderedProductSalesB2B]	FLOAT,
	[TotalOrderItems]			INT,
	[TotalOrderItemsB2B]		INT,
	[ProductId]					INT,
	CONSTRAINT BusinessReport_PK PRIMARY KEY ([UpdateDate], [Sku], [ProductId]),
	CONSTRAINT FK_BusinessReport_SKU_MP FOREIGN KEY ([ProductId]) REFERENCES [Products] ([ProductId])
)
/*  
Session Percentage = sessions/SUM(sessions)
Page Views Percentage = Page Views/SUM(Page Views)
Unit Session Percentage= Units Ordered/Sessions
Unit Session Percentage - B2B = Units Ordered - B2B/Sessions
*/

CREATE TABLE [ReturnsReport](
	[RecordId]					INT IDENTITY(0,1),
	[MarketplaceId]				INT,
	[ReturnDate]				DATETIME,
	[OrderId]					VARCHAR(100),
	[SKU]						VARCHAR(30),
	[ASIN]						VARCHAR(20),
	[FNSKU]						VARCHAR(30),
	[ProductName]				NVARCHAR(1000),
	[Quantity]					INT,
	[FulfillmentCenterId]		VARCHAR(20),
	[DetailedDisposition]		INT,
	[Reason]					INT,
	[Status]					VARCHAR(512),
	[LicensePlateNumber]		VARCHAR(30),
	[CustomerComments]			NVARCHAR(1000),
	[ProductId]					INT,
	CONSTRAINT PK_ReturnsReport PRIMARY KEY ([RecordId]),
	CONSTRAINT FK_ReturnsReport_MarketPlace FOREIGN KEY ([ProductId]) REFERENCES [Products] ([ProductId]),
	CONSTRAINT FK_ReturnsReport_Reason FOREIGN KEY ([Reason]) REFERENCES [ReturnReason] ([ReasonId]),
	CONSTRAINT FK_ReturnsReport_Dispositon FOREIGN KEY ([DetailedDisposition]) REFERENCES [DetailedDisposition] ([DispositionId])
)


CREATE TABLE [Orders](
	[AmazonOrderId]				VARCHAR(50),
	[MerchantOrderId]			VARCHAR(50),
	[PurchaseDate]				DATETIME,
	[LastUpdatedDate]			DATETIME,
	[OrderStatus]				VARCHAR(20),
	[FullfilmentChannel]		VARCHAR(20),
	[SalesChannel]				VARCHAR(50),
	[OrderChannel]				VARCHAR(50),
	[Url]						VARCHAR(50),
	[ShipServiceLevel]			VARCHAR(30),
	[ProductName]				VARCHAR(500),
	[Sku]						VARCHAR(50),
	[Asin]						VARCHAR(50),
	[ItemStatus]				VARCHAR(50),
	[Quantity]					INT,
	[Currency]					VARCHAR(20),
	[ItemPrice]					FLOAT,
	[ItemTax]					FLOAT,
	[ShippingPrice]				FLOAT,
	[ShippingTax]				FLOAT,
	[GiftWrapPrice]				FLOAT,
	[GiftWrapTax]				FLOAT,
	[ItemPromotionDiscount]		FLOAT,
	[ShipPromotionDiscount]		FLOAT,
	[ShipCity]					VARCHAR(200),
	[ShipState]					VARCHAR(150),
	[ShipPostalCode]			VARCHAR(25),
	[ShipCountry]				VARCHAR(50),
	[PromotionIds]				VARCHAR(100),
	[IsBusinessOrder]			VARCHAR(6),
	[PurchaseOrderNumber]		VARCHAR(50),
	[PriceDesignation]			VARCHAR(50),
	[MarketPlaceId]				INT,
	CONSTRAINT Orders_AmazonOrderId_Sku_PK PRIMARY KEY ([AmazonOrderId], [Sku])
)
GO

--IF NOT OBJECT_ID('Orders') IS NULL DROP TABLE [Orders]






















/* ------------------------------------------------------------------------------------------------------------------------------------------------------------------ 


IF NOT OBJECT_ID('CustomerReturns') IS NULL DROP TABLE [CustomerReturns]
GO
IF NOT OBJECT_ID('Payments') IS NULL DROP TABLE [Payments]
GO
IF NOT OBJECT_ID('Shipments') IS NULL DROP TABLE [Shipments]
GO
IF NOT OBJECT_ID('Orders') IS NULL DROP TABLE [Orders]
GO


CREATE TABLE [Orders](
	[AmazonOrderId]				VARCHAR(50),
	[MerchantOrderId]			VARCHAR(50),
	[PurchaseDate]				Date,
	[LastUpdatedDate]			Date,
	[OrderStatus]				VARCHAR(20),
	[FullfilmentChannel]		VARCHAR(20),
	[SalesChannel]				VARCHAR(50),
	[OrderChannel]				VARCHAR(50),
	[Url]						VARCHAR(50),
	[ShipServiceLevel]			VARCHAR(30),
	[ProductName]				VARCHAR(500),
	[Sku]						VARCHAR(50),
	[Asin]						VARCHAR(50),
	[ItemStatus]				VARCHAR(50),
	[Quantity]					INT,
	[Currency]					VARCHAR(20),
	[ItemPrice]					FLOAT,
	[ItemTax]					FLOAT,
	[ShippingPrice]				FLOAT,
	[ShippingTax]				FLOAT,
	[GiftWrapPrice]				FLOAT,
	[GiftWrapTax]				FLOAT,
	[ItemPromotionDiscount]		FLOAT,
	[ShipPromotionDiscount]		FLOAT,
	[ShipCity]					VARCHAR(200),
	[ShipState]					VARCHAR(150),
	[ShipPostalCode]			VARCHAR(25),
	[ShipCountry]				VARCHAR(50),
	[PromotionIds]				VARCHAR(100),
	[IsBusinessOrder]			VARCHAR(6),
	[PurchaseOrderNumber]		VARCHAR(50),
	[PriceDesignation]			VARCHAR(50),
	[ReturnDate]				Date,
	CONSTRAINT Orders_AmazonOrderId_PK PRIMARY KEY ([AmazonOrderId])
)
GO

CREATE TABLE [Payments](
	[Date]						DATE,
	[SettlementId]				VARCHAR(20),
	[Type]						VARCHAR(30),
	[OrderId]					VARCHAR(50),
	[Sku]						VARCHAR(50),
	[Description]				VARCHAR(500),
	[Quantity]					INT,
	[Marketplace]				VARCHAR(100),
	[Fullfilment]				VARCHAR(30),
	[OrderCity]					VARCHAR(100),
	[OrderState]				VARCHAR(70),
	[OrderPostal]				VARCHAR(50),
	[ProductSales]				FLOAT,
	[ShippingCredits]			FLOAT,
	[GiftWrapCredits]			FLOAT,
	[PromotionalRebates]		FLOAT,
	[SaleTaxCollected]			FLOAT,
	[MarketplaceFacilitatorTax]	FLOAT,
	[SellingFees]				FLOAT,
	[FBAFees]					FLOAT,
	[OtherTransactionFees]		FLOAT,
	[Other]						FLOAT,
	[Total]						FLOAT,
	--CONSTRAINT PK_Payments_OrderIdandSku PRIMARY KEY ([OrderId], [Sku])
)
GO

CREATE TABLE [Shipments](
	[AmazonOrderId]				VARCHAR(50),
	[MerchantOrderId]			VARCHAR(50),
	[ShipmentId]				VARCHAR(30),
	[ShipmentItemId]			VARCHAR(30),
	[AmazonOrderItemId]			VARCHAR(50),
	[MerchantOrderItemId]		VARCHAR(50),
	[PurchaseDate]				DATE,
	[PaymentsDate]				DATE,
	[ShipmentDate]				DATE,
	[ReportingDate]				DATE,
	[BuyerEmail]				VARCHAR(100),
	[BuyerName]					VARCHAR(200),
	[BuyerPhoneNumber]			VARCHAR(50),
	[Sku]						VARCHAR(50),
	[ProductName]				VARCHAR(500),
	[QuantityShipped]			INT,
	[Currency]					VARCHAR(20),
	[ItemPrice]					FLOAT,
	[ItemTax]					FLOAT,
	[ShippingPrice]				FLOAT,
	[ShippingTax]				FLOAT,	
	[GiftWrapPrice]				FLOAT,
	[GiftWrapTax]				FLOAT,
	[ShipServiceLevel]			VARCHAR(50),
	[RecipientName]				VARCHAR(200),
	[ShipAddress1]				VARCHAR(200),
	[ShipAddress2]				VARCHAR(200),
	[ShipAddress3]				VARCHAR(200),
	[ShipCity]					VARCHAR(200),
	[ShipState]					VARCHAR(150),
	[ShipPostalCode]			VARCHAR(25),
	[ShipCountry]				VARCHAR(100),
	[ShipPhoneNumber]			VARCHAR(50),
	[BillAddress1]				VARCHAR(200),
	[BillAddress2]				VARCHAR(200),
	[BillAddress3]				VARCHAR(200),
	[BillCity]					VARCHAR(200),
	[BillState]					VARCHAR(150),
	[BillPostalCode]			VARCHAR(25),
	[BillCountry]				VARCHAR(100),
	[ItemPromotionDiscount]		FLOAT,
	[ShipPromotionDiscount]		FLOAT,
	[Carrier]					VARCHAR(50),
	[TrackingNumber]			VARCHAR(100),
	[EstimatedArrivalDate]		DATE,
	[FullfilmentCenterId]		VARCHAR(100),
	[FullfilmentChannel]		VARCHAR(100),
	[SalesChannel]				VARCHAR(100),
	CONSTRAINT Shipments_AmazonOrderId_PK PRIMARY KEY ([AmazonOrderId])
)
GO

CREATE TABLE [CustomerReturns](
	[ReturnDate]				DATE,
	[OrderId]					VARCHAR(50),
	[SKU]						VARCHAR(50),
	[ASIN]						VARCHAR(50),
	[FNSKU]						VARCHAR(50),
	[ProductName]				VARCHAR(500),
	[Quantity]					INT,
	[FullfilmentCenterId]		VARCHAR(100),
	[DetailedDisposition]		VARCHAR(50),
	[Reason]					VARCHAR(100),
	[Status]					VARCHAR(50),
	[LicensePlateNumber]		VARCHAR(50),
	[CustomerComments]			VARCHAR(1000),
	CONSTRAINT PK_CustomerReturns_LicensePlateNumber PRIMARY KEY ([LicensePlateNumber])
	--CONSTRAINT FK_CustomerReturns_Orders FOREIGN KEY ([OrderId]) REFERENCES Orders ([AmazonOrderId])
)
GO


*/