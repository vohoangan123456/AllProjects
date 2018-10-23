USE [master]
GO
/****** Object:  Database [Ehandbok]    Script Date: 10/20/2016 11:39:14 ******/
CREATE DATABASE [LanguagesDB] ON  PRIMARY 
( NAME = N'LanguagesDB', FILENAME = N'E:\NewVersionQMS_Test\qms\Handbook\Database\LanguagesDB.mdf' , SIZE = 5671936KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'LanguagesDB_log', FILENAME = N'E:\NewVersionQMS_Test\qms\Handbook\Database\LanguagesDB.ldf' , SIZE = 1219712KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

USE [LanguagesDB]
GO
/****** Object:  Table [dbo].[tblCategories]    Script Date: 10/20/2018 4:58:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_tblCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblWords]    Script Date: 10/20/2018 4:58:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblWords](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Word] [nvarchar](100) NOT NULL,
	[Type] [nchar](20) NULL,
	[Pronunciation] [nvarchar](100) NULL,
	[Meaning] [nvarchar](1000) NOT NULL,
	[Example] [nvarchar](1000) NULL,
	[Translation] [nvarchar](1000) NULL,
	[Note] [nvarchar](1000) NULL,
	[CategoryId] [int] NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_tblWords] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[tblCategories] ADD  CONSTRAINT [DF_tblCategories_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[tblWords] ADD  CONSTRAINT [DF_tblWords_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
