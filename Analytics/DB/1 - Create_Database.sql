USE master
GO

IF EXISTS (SELECT *
           FROM   master..sysdatabases
           WHERE  name = 'Analytics')
BEGIN
  DROP DATABASE [Analytics]
  PRINT 'Database [Analytics] dropped'
END
GO

CREATE DATABASE [Analytics] ON (
  NAME = N'tc_data',
  FILENAME = N'C:\MSSQL2\Data\tc_data.mdf',
  SIZE = 10,
  -- MAXSIZE = 100MB,
  FILEGROWTH = 10%) 
LOG ON (
  NAME = N'tc_log',
  FILENAME = N'C:\MSSQL2\Log\tc_log.ldf',
  SIZE = 20, 
  -- MAXSIZE = 200MB,
  FILEGROWTH = 20%)
COLLATE Cyrillic_General_CI_AS
GO

PRINT 'Database [Analytics] created'
GO
