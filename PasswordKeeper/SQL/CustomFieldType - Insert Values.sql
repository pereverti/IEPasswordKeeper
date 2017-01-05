USE [PasswordKeeper]
GO

INSERT INTO [dbo].[CustomFieldType]
           ([Name])
     VALUES
           ('Login') -- id must be 1 for C#   

INSERT INTO [dbo].[CustomFieldType]
           ([Name])
     VALUES
           ('Password') -- id must be 2 for C#
GO