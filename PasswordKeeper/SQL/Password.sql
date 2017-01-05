USE [PasswordKeeper]
GO

/****** Object:  Table [dbo].[Password]    Script Date: 05-01-17 12:19:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Password](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Url] [nvarchar](max) NULL,
	[Notes] [text] NULL,
	[DisplayName] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Password] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Password]  WITH CHECK ADD  CONSTRAINT [FK_Password_Password] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[Password] CHECK CONSTRAINT [FK_Password_Password]
GO

