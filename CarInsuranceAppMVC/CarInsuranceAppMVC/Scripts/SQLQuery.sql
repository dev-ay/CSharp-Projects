/****** Script for SelectTopNRows command from SSMS  ******/
USE CarInsurance

--DELETE FROM [CarInsurance].[dbo].[Quotes] WHERE Id > 11;


DBCC CHECKIDENT (Quotes, NORESEED)
--DBCC CHECKIDENT (Quotes, RESEED, 11)
