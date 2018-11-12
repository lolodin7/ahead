USE master
GO

IF EXISTS (SELECT *
           FROM   master..sysdatabases
           WHERE  name = 'AHEAD')
BEGIN
  DROP DATABASE [AHEAD]
  PRINT 'Database [AHEAD] dropped'
END
GO

CREATE DATABASE [AHEAD] ON (
  NAME = N'tc_data',
  FILENAME = N'C:\MSSQL\Data\tc_data.mdf',
  SIZE = 10,
  -- MAXSIZE = 100MB,
  FILEGROWTH = 10%) 
LOG ON (
  NAME = N'tc_log',
  FILENAME = N'C:\MSSQL\Log\tc_log.ldf',
  SIZE = 20, 
  -- MAXSIZE = 200MB,
  FILEGROWTH = 20%)
COLLATE Cyrillic_General_CI_AS
GO

PRINT 'Database [AHEAD] created'
GO
