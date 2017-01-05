USE [PasswordKeeper]
GO

/****** Object:  Table [dbo].[CustomField]    Script Date: 05-01-17 12:17:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CustomField](
	[IdPassword] [int] NOT NULL,
	[IdCustomFieldType] [int] NOT NULL,
	[ControlId] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_CustomField] PRIMARY KEY CLUSTERED 
(
	[IdPassword] ASC,
	[IdCustomFieldType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[CustomField]  WITH CHECK ADD  CONSTRAINT [FK_CustomField_CustomFieldType] FOREIGN KEY([IdCustomFieldType])
REFERENCES [dbo].[CustomFieldType] ([Id])
GO

ALTER TABLE [dbo].[CustomField] CHECK CONSTRAINT [FK_CustomField_CustomFieldType]
GO

ALTER TABLE [dbo].[CustomField]  WITH CHECK ADD  CONSTRAINT [FK_CustomField_Password] FOREIGN KEY([IdPassword])
REFERENCES [dbo].[Password] ([Id])
GO

ALTER TABLE [dbo].[CustomField] CHECK CONSTRAINT [FK_CustomField_Password]
GO

