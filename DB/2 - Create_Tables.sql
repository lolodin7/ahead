USE AHEAD
GO


IF NOT OBJECT_ID('FieldsLength') IS NULL DROP TABLE [FieldsLength]
GO

IF NOT OBJECT_ID('SemCore') IS NULL DROP TABLE [SemCore]
GO

IF NOT OBJECT_ID('KeywordCategory') IS NULL DROP TABLE [KeywordCategory]
GO

IF NOT OBJECT_ID('Semantics') IS NULL DROP TABLE [Semantics]
GO

IF NOT OBJECT_ID('Products') IS NULL DROP TABLE [Products]
GO

IF NOT OBJECT_ID('ProductTypes') IS NULL DROP TABLE [ProductTypes]
GO


/*
    "БД компании AHEAD"
*/


CREATE TABLE [ProductTypes](
	[ProductTypeId]		INT IDENTITY(0,1)	NOT NULL,
	[TypeName]			VARCHAR(100),
	CONSTRAINT PK_ProductTypes PRIMARY KEY ([ProductTypeId])
)
GO


CREATE TABLE [Products](
	[ProductId]			INT IDENTITY(0,1)	NOT NULL,
	[Name]				NVARCHAR(500),
	[ASIN]				VARCHAR(10),
	[SKU]				VARCHAR(12),
	[ProductTypeId]		INT					NOT NULL,
	CONSTRAINT PK_Products PRIMARY KEY ([ProductId]),
	CONSTRAINT FK_Products_ProductTypes FOREIGN KEY ([ProductTypeId]) REFERENCES ProductTypes ([ProductTypeId])
)
GO


CREATE TABLE [Semantics](
	[SemanticsId]		INT IDENTITY(1,1)	NOT NULL,
	[ProductId]			INT					NOT NULL,
	[Title]				NVARCHAR(300),
	[Bullet1]			NVARCHAR(200),
	[Bullet2]			NVARCHAR(200),
	[Bullet3]			NVARCHAR(200),
	[Bullet4]			NVARCHAR(200),
	[Bullet5]			NVARCHAR(200),
	[Backend]			NVARCHAR(500),
	[Description]		NVARCHAR(4000),
	[OtherAttributes1]	NVARCHAR(200),
	[OtherAttributes2]	NVARCHAR(200),
	[OtherAttributes3]	NVARCHAR(200),
	[OtherAttributes4]	NVARCHAR(200),
	[OtherAttributes5]	NVARCHAR(200),
	[IntendedUse1]		NVARCHAR(200),
	[IntendedUse2]		NVARCHAR(200),
	[IntendedUse3]		NVARCHAR(200),
	[IntendedUse4]		NVARCHAR(200),
	[IntendedUse5]		NVARCHAR(200),
	[SubjectMatter1]	NVARCHAR(200),
	[SubjectMatter2]	NVARCHAR(200),
	[SubjectMatter3]	NVARCHAR(200),
	[SubjectMatter4]	NVARCHAR(200),
	[SubjectMatter5]	NVARCHAR(200),
	[UpdateDate]		DATETIME			NOT NULL,
	[Notes]				NVARCHAR(4000),
	[UsedKeywords]		NVARCHAR(4000),
	CONSTRAINT FK_Semantics_Products FOREIGN KEY ([ProductId]) REFERENCES Products ([ProductId])
)
GO

CREATE TABLE [KeywordCategory](
	[CategoryId]		INT IDENTITY(0,1),
	[CategoryName]		VARCHAR(100),
	CONSTRAINT PK_KeywordCategory PRIMARY KEY ([CategoryId])
)
GO


CREATE TABLE [SemCore](
	[ProductTypeId]		INT					NOT NULL,
	[CategoryId]		INT					NOT NULL,
	[Keyword]			VARCHAR(100),
	[Value]				INT,
	[LastUpdated]		DATETIME,
	[SemCoreId]			INT IDENTITY(1,1)	NOT NULL,
	CONSTRAINT PK_SemCoreId PRIMARY KEY ([SemCoreId]),
	CONSTRAINT UQ_SemCore_Keyword UNIQUE ([Keyword]),
	CONSTRAINT FK_SemCore_ProductTypes FOREIGN KEY ([ProductTypeId]) REFERENCES ProductTypes ([ProductTypeId]),
	CONSTRAINT FK_SemCore_CategoryId FOREIGN KEY ([CategoryId]) REFERENCES KeywordCategory ([CategoryId])
)
GO


CREATE TABLE [FieldsLength](
	[TitleLength]			INT,
	[BulletsLength]			INT,
	[BackendLength]			INT,
	[SubjectMatterLength]	INT,
	[OtherAttributesLength]	INT,
	[IntendedUseLength]		INT,
	[DescriptionLength]		INT,
	[ProductId]				INT,
	CONSTRAINT FK_FieldsLength_Products FOREIGN KEY ([ProductId]) REFERENCES Products ([ProductId])
)
GO


/*


--ENDDDDDDDDDDDDDDDDD

CREATE TABLE [Course] (
    [CourseId]      INT             NOT NULL,
    [Code]          VARCHAR(8)      NOT NULL,
    [Title]         NVARCHAR(100)   NOT NULL,
    [Description]   NVARCHAR(4000),
    [Amount]        MONEY,
    [Status]        CHAR(1)         NOT NULL
    CONSTRAINT PK_Course PRIMARY KEY ([CourseId]),
    CONSTRAINT UQ_Course_Code UNIQUE ([Code]),
    CONSTRAINT UQ_Course_Title UNIQUE ([Title]),
    CONSTRAINT CK_Course_Status CHECK ([Status] IN ('A', 'D', 'S')) -- A = Active, D = Disabled, S = Suspended
)
GO

/*
    "Программа курса" (содержание)
*/

CREATE TABLE [CourseContent] (
    [CourseId]          INT             NOT NULL,
    [CourseContentId]   INT             NOT NULL, -- IDENTITY(1, 1)
    [ParentId]          INT             NOT NULL,
    [Code]              VARCHAR(10),
    [ContentType]       CHAR(2),
    [Title]             NVARCHAR(100)   NOT NULL,
    [Description]       NVARCHAR(2000),
    CONSTRAINT PK_CourseContent PRIMARY KEY ([CourseId], [CourseContentId]),
    CONSTRAINT FK_CourseContent_Course FOREIGN KEY ([CourseId]) REFERENCES Course ([CourseId]),
    CONSTRAINT FK_CourseContent_CourseContent FOREIGN KEY ([CourseId], [ParentId]) REFERENCES CourseContent ([CourseId], [CourseContentId]),
    CONSTRAINT CK_CourseContent_ContentType CHECK ([ContentType] IN ('UN', 'CH', 'EX', 'HW')) -- UN = Unit, CH = Chapter, EX = Exercise, HW = Homework
)
GO


/*
    "Пользователи" (участники учебного центра)
*/

CREATE TABLE [UserData] (
    [UserDataId]        INT IDENTITY(1, 1)  NOT NULL,
    [UserName]          SYSNAME             NOT NULL, --тип данных, ограниченный 128 символами Unicode и не может быть NULL = nvarchar(128) NOT NULL. Используется для хранения имен объектов.
    [Password]          NVARCHAR(255),
    [FirstName]         NVARCHAR(20)        NOT NULL,
    [MiddleName]        NVARCHAR(20),
    [LastName]          NVARCHAR(20)        NOT NULL,
    [CreateDate]        DATETIME            NOT NULL,
    [UpdateDate]        DATETIME            NOT NULL,
    [Status]            CHAR(1)             NOT NULL
    CONSTRAINT PK_UserData PRIMARY KEY ([UserDataId]),
    CONSTRAINT UQ_UserData_UserName UNIQUE ([UserName]),
    CONSTRAINT CK_UserData_Status CHECK ([Status] IN ('A', 'D')), -- A = Active, D = Disabled
    CONSTRAINT CK_UserData_LastName CHECK (LEN([LastName]) > 1)
)
GO

/*
    "Роли пользователей"
*/

CREATE TABLE [UserRole] (
    [UserRoleId]      INT             NOT NULL,
    [Code]            VARCHAR(3)      NOT NULL,
    [Name]            NVARCHAR(20),
    [Description]     NVARCHAR(50)
    CONSTRAINT PK_UserRole PRIMARY KEY ([UserRoleId]),
	CONSTRAINT UQ_UserRole_Code UNIQUE (Code)
)
GO

/*
    Сопоставление "Пользователи - Роли" (развязочная таблица)
*/

CREATE TABLE [UserRoleLink] (
    [UserDataId]        INT NOT NULL,
    [UserRoleId]        INT NOT NULL
    CONSTRAINT PK_UserRoleLink PRIMARY KEY ([UserDataId], [UserRoleId]),
    CONSTRAINT FK_UserRoleLink_UserData FOREIGN KEY ([UserDataId]) REFERENCES [UserData] ([UserDataId]),
    CONSTRAINT FK_UserRoleLink_UserRole FOREIGN KEY ([UserRoleId]) REFERENCES [UserRole] ([UserRoleId])
)
GO

/*
    "Группы пользователей"
*/

CREATE TABLE [UserGroup] (
    [UserGroupId]       INT IDENTITY(1, 1)  NOT NULL,
    [CourseId]          INT                 NOT NULL,
    [Name]              NVARCHAR(50)        NOT NULL,
    [CreateDate]        DATETIME            NOT NULL,
    [UpdateDate]        DATETIME            NOT NULL,
    [Status]            CHAR(1)             NOT NULL
    CONSTRAINT PK_UserGroup PRIMARY KEY ([UserGroupId]),
    CONSTRAINT FK_UserGroup_Course FOREIGN KEY ([CourseId]) REFERENCES [Course] ([CourseId]),
    CONSTRAINT CK_UserGroup_Status CHECK ([Status] IN ('A', 'D', 'C')), -- A = Active, D = Disabled, C = Closed
	CONSTRAINT UQ_UserGroup_Name UNIQUE (Name)
)
GO

/*
    Сопоставление "Пользователи - Группы пользователей" (развязочная таблица)
*/

CREATE TABLE [UserGroupLink] (
    [UserGroupId]       INT NOT NULL,
    [UserDataId]        INT NOT NULL
    CONSTRAINT PK_UserGroupLink PRIMARY KEY ([UserGroupId], [UserDataId]),
    CONSTRAINT FK_UserGroupLink_UserGroup FOREIGN KEY ([UserGroupId]) REFERENCES [UserGroup] ([UserGroupId]),
    CONSTRAINT FK_UserGroupLink_UserData FOREIGN KEY ([UserDataId]) REFERENCES [UserData] ([UserDataId])
)
GO



----------------------------------Функции и процедуры----------------------------------------

/*
Функция возвращает идентификатор пользователя по передаваемом в функцию значению @UserName
*/

CREATE FUNCTION getUserId (@UserName SYSNAME)
RETURNS TABLE
	AS RETURN (SELECT u.UserDataId
				FROM UserData u
				WHERE u.UserName = @UserName)
GO


/*
Функция возвращает идентификатор роли по передаваемом в функцию значению @Code
*/

CREATE FUNCTION [dbo].[getRoleId] (@Code VARCHAR(3))
RETURNS TABLE
	AS RETURN (SELECT r.UserRoleId
				FROM UserRole r
				WHERE r.Code = @Code )
GO


/*
Процедура выполняет обновление суммы по коду курса
*/

CREATE PROCEDURE UpdSumCourse (@Code VARCHAR(8), @Amount money)
	AS UPDATE Course
	SET Amount = @Amount
	WHERE Code = @Code;
GO

*/