USE [PasswordKeeper]
GO

/****** Object:  Table [dbo].[ConnectionTemp]    Script Date: 05-01-17 12:17:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ConnectionTemp](
	[IdUser] [int] NOT NULL,
	[ComputerName] [nvarchar](255) NOT NULL,
	[ComputerMacAddress] [nvarchar](255) NOT NULL,
	[ComputerUserName] [nvarchar](255) NOT NULL,
	[ConnexionDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ConnectionTemp] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ConnectionTemp]  WITH CHECK ADD  CONSTRAINT [FK_ConnectionTemp_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[ConnectionTemp] CHECK CONSTRAINT [FK_ConnectionTemp_User]
GO

