USE [master]
GO
/****** Object:  Database [NewBidersGoDB]    Script Date: 20.02.2022 21:50:29 ******/
CREATE DATABASE [NewBidersGoDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NewBidersGoDB', FILENAME = N'C:\Users\hkpln\NewBidersGoDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NewBidersGoDB_log', FILENAME = N'C:\Users\hkpln\NewBidersGoDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NewBidersGoDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NewBidersGoDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NewBidersGoDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NewBidersGoDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NewBidersGoDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NewBidersGoDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [NewBidersGoDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [NewBidersGoDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NewBidersGoDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NewBidersGoDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NewBidersGoDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NewBidersGoDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NewBidersGoDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NewBidersGoDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NewBidersGoDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NewBidersGoDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [NewBidersGoDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NewBidersGoDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NewBidersGoDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NewBidersGoDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NewBidersGoDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NewBidersGoDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [NewBidersGoDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NewBidersGoDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [NewBidersGoDB] SET  MULTI_USER 
GO
ALTER DATABASE [NewBidersGoDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NewBidersGoDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NewBidersGoDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NewBidersGoDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NewBidersGoDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [NewBidersGoDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 20.02.2022 21:50:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 20.02.2022 21:50:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[Id] [uniqueidentifier] NOT NULL,
	[ZipCode] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[State] [nvarchar](max) NULL,
	[BuildName] [nvarchar](max) NULL,
	[Street] [nvarchar](max) NULL,
	[BuildNo] [nvarchar](max) NULL,
	[AddressType] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Admins]    Script Date: 20.02.2022 21:50:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Surname] [nvarchar](max) NULL,
	[NickName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Admins] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LessonDetails]    Script Date: 20.02.2022 21:50:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LessonDetails](
	[Id] [uniqueidentifier] NOT NULL,
	[LessonId] [uniqueidentifier] NOT NULL,
	[SoruSayisi] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NULL,
 CONSTRAINT [PK_LessonDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lessons]    Script Date: 20.02.2022 21:50:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lessons](
	[Id] [uniqueidentifier] NOT NULL,
	[LessonName] [nvarchar](256) NOT NULL,
	[IsOnline] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Lessons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Meets]    Script Date: 20.02.2022 21:50:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meets](
	[Id] [uniqueidentifier] NOT NULL,
	[StudentId] [uniqueidentifier] NOT NULL,
	[TeacherId] [uniqueidentifier] NOT NULL,
	[LessonTime] [datetime2](7) NOT NULL,
	[LessonFinishTime] [datetime2](7) NULL,
	[AddressId] [uniqueidentifier] NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[IsApproved] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Meets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Moderators]    Script Date: 20.02.2022 21:50:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Moderators](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Surname] [nvarchar](max) NULL,
	[NickName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[TcKimlik] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Moderators] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Students]    Script Date: 20.02.2022 21:50:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Surname] [nvarchar](max) NULL,
	[TcKimlik] [int] NOT NULL,
	[AddressId] [uniqueidentifier] NULL,
	[NickName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[IsSearchLesson] [bit] NOT NULL,
	[SubscriptionId] [uniqueidentifier] NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Subscription]    Script Date: 20.02.2022 21:50:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subscription](
	[Id] [uniqueidentifier] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[PaidAmunt] [decimal](18, 2) NOT NULL,
	[EndTime] [datetime2](7) NOT NULL,
	[StartTime] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Subscription] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubscriptionType]    Script Date: 20.02.2022 21:50:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubscriptionType](
	[Id] [uniqueidentifier] NOT NULL,
	[SubscriptionId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Month] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NULL,
 CONSTRAINT [PK_SubscriptionType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 20.02.2022 21:50:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Surname] [nvarchar](max) NULL,
	[Branch] [nvarchar](max) NULL,
	[TcKimlik] [nvarchar](max) NULL,
	[NickName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[AddressId] [uniqueidentifier] NULL,
	[IsWorking] [bit] NOT NULL,
	[LessonId] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NULL,
	[IsApproved] [bit] NOT NULL DEFAULT (CONVERT([bit],(0))),
 CONSTRAINT [PK_Teachers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[workingForOneHours]    Script Date: 20.02.2022 21:50:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[workingForOneHours](
	[Id] [uniqueidentifier] NOT NULL,
	[weekID] [uniqueidentifier] NOT NULL,
	[WorkingHourTotalTime] [float] NOT NULL,
	[WorkingStart] [datetime2](7) NOT NULL,
	[WorkingStop] [datetime2](7) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NULL,
 CONSTRAINT [PK_workingForOneHours] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WorkingHoursOfWeeks]    Script Date: 20.02.2022 21:50:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkingHoursOfWeeks](
	[Id] [uniqueidentifier] NOT NULL,
	[TeacherId] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NULL,
 CONSTRAINT [PK_WorkingHoursOfWeeks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220218211017_last', N'5.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220220120845_lastChange', N'5.0.4')
INSERT [dbo].[Addresses] ([Id], [ZipCode], [City], [State], [BuildName], [Street], [BuildNo], [AddressType], [CreatedDate], [UpdateDate]) VALUES (N'2b9513de-cba8-4a23-a55c-0482c86ea0fc', NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'2022-02-20 17:50:51.3193986' AS DateTime2), NULL)
INSERT [dbo].[Addresses] ([Id], [ZipCode], [City], [State], [BuildName], [Street], [BuildNo], [AddressType], [CreatedDate], [UpdateDate]) VALUES (N'a58c2550-e57d-4abe-8d0e-44eeb8f53ea7', NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Addresses] ([Id], [ZipCode], [City], [State], [BuildName], [Street], [BuildNo], [AddressType], [CreatedDate], [UpdateDate]) VALUES (N'bcb19ef5-e8de-47f4-9789-cf92fa5b0ba8', NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Addresses] ([Id], [ZipCode], [City], [State], [BuildName], [Street], [BuildNo], [AddressType], [CreatedDate], [UpdateDate]) VALUES (N'6bd2fbdc-310a-45b7-84fb-f87ac7ae144a', NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'2022-02-20 17:46:45.1436195' AS DateTime2), NULL)
INSERT [dbo].[Lessons] ([Id], [LessonName], [IsOnline], [CreatedDate], [UpdateDate]) VALUES (N'61982040-a417-4d2c-b862-6ebb3daed97c', N'Edebiyat', 1, CAST(N'2022-02-20 12:11:34.4803622' AS DateTime2), NULL)
INSERT [dbo].[Lessons] ([Id], [LessonName], [IsOnline], [CreatedDate], [UpdateDate]) VALUES (N'2a33d522-0032-416f-a187-a3a23db1e859', N'matematik', 0, CAST(N'2022-02-19 00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Lessons] ([Id], [LessonName], [IsOnline], [CreatedDate], [UpdateDate]) VALUES (N'2a33d522-0032-416f-a187-a3a23db1e85d', N'fizik', 0, CAST(N'2022-02-19 00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Lessons] ([Id], [LessonName], [IsOnline], [CreatedDate], [UpdateDate]) VALUES (N'09bd59ab-06ec-4996-a7b5-bd0f96db8e6a', N'Biyoloji', 1, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Moderators] ([Id], [Name], [Surname], [NickName], [Email], [Password], [TcKimlik], [CreatedDate], [UpdateDate]) VALUES (N'cae4e640-53a3-4a23-8c90-474cabfa1cb1', N'y', N'g', N'yg', N'yns@gmail.com', N'yg123', 0, CAST(N'2022-02-20 16:21:26.5779675' AS DateTime2), NULL)
INSERT [dbo].[Moderators] ([Id], [Name], [Surname], [NickName], [Email], [Password], [TcKimlik], [CreatedDate], [UpdateDate]) VALUES (N'8f426854-99ee-4e3b-86bf-4e467e42aa80', N'Hasan', N'k ', N'hk', N'mod@gmail.com', N'hk123', 145, CAST(N'2022-02-20 16:19:01.3561391' AS DateTime2), NULL)
INSERT [dbo].[Moderators] ([Id], [Name], [Surname], [NickName], [Email], [Password], [TcKimlik], [CreatedDate], [UpdateDate]) VALUES (N'ed86ca09-30d8-4c63-b930-542a558fa45b', N'moderator', N'msoyad', N'mod', N'm@gmail.com', N'mod123', 0, CAST(N'2022-02-20 16:15:08.6588870' AS DateTime2), NULL)
INSERT [dbo].[Moderators] ([Id], [Name], [Surname], [NickName], [Email], [Password], [TcKimlik], [CreatedDate], [UpdateDate]) VALUES (N'9b555012-9534-409b-9336-9c1774647866', N's', N'a', N'sa', N'slc', N'sa123', 111114, CAST(N'2022-02-20 16:26:47.8296294' AS DateTime2), NULL)
INSERT [dbo].[Students] ([Id], [Name], [Surname], [TcKimlik], [AddressId], [NickName], [Email], [Password], [IsSearchLesson], [SubscriptionId], [CreatedDate], [UpdateDate]) VALUES (N'ec52a163-793d-441b-a27c-2a9465797e80', N'y', N'g', 141, N'6bd2fbdc-310a-45b7-84fb-f87ac7ae144a', N'yg', N'y@gmail.com', N'yg123', 1, NULL, CAST(N'2022-02-20 17:46:45.1428039' AS DateTime2), NULL)
INSERT [dbo].[Students] ([Id], [Name], [Surname], [TcKimlik], [AddressId], [NickName], [Email], [Password], [IsSearchLesson], [SubscriptionId], [CreatedDate], [UpdateDate]) VALUES (N'bfa6eaa8-3817-4123-9981-e93df39e6069', N'h', N'k', 1452, N'2b9513de-cba8-4a23-a55c-0482c86ea0fc', N'hk', N'h@gmail.com', N'hk123', 1, NULL, CAST(N'2022-02-20 17:50:51.3186629' AS DateTime2), NULL)
INSERT [dbo].[Teachers] ([Id], [Name], [Surname], [Branch], [TcKimlik], [NickName], [Email], [Password], [AddressId], [IsWorking], [LessonId], [CreatedDate], [UpdateDate], [IsApproved]) VALUES (N'da257a74-f25d-4f7f-98d2-220faf527627', N'hocam', N'hocaninsoyadi', N'matematik', NULL, NULL, N'denemsen@gmail.com', N'123456', N'bcb19ef5-e8de-47f4-9789-cf92fa5b0ba8', 0, N'2a33d522-0032-416f-a187-a3a23db1e859', CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Teachers] ([Id], [Name], [Surname], [Branch], [TcKimlik], [NickName], [Email], [Password], [AddressId], [IsWorking], [LessonId], [CreatedDate], [UpdateDate], [IsApproved]) VALUES (N'dce996e7-4c0c-46ea-b7fc-2e9bb4a111c3', N'deneme', N'deneme', N'mat', NULL, NULL, N'deneme@gmail.com', N'123456', N'a58c2550-e57d-4abe-8d0e-44eeb8f53ea7', 0, N'2a33d522-0032-416f-a187-a3a23db1e859', CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), NULL, 0)
/****** Object:  Index [IX_LessonDetails_LessonId]    Script Date: 20.02.2022 21:50:29 ******/
CREATE NONCLUSTERED INDEX [IX_LessonDetails_LessonId] ON [dbo].[LessonDetails]
(
	[LessonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Meets_AddressId]    Script Date: 20.02.2022 21:50:29 ******/
CREATE NONCLUSTERED INDEX [IX_Meets_AddressId] ON [dbo].[Meets]
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Meets_StudentId]    Script Date: 20.02.2022 21:50:29 ******/
CREATE NONCLUSTERED INDEX [IX_Meets_StudentId] ON [dbo].[Meets]
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Meets_TeacherId]    Script Date: 20.02.2022 21:50:29 ******/
CREATE NONCLUSTERED INDEX [IX_Meets_TeacherId] ON [dbo].[Meets]
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Students_AddressId]    Script Date: 20.02.2022 21:50:29 ******/
CREATE NONCLUSTERED INDEX [IX_Students_AddressId] ON [dbo].[Students]
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Students_SubscriptionId]    Script Date: 20.02.2022 21:50:29 ******/
CREATE NONCLUSTERED INDEX [IX_Students_SubscriptionId] ON [dbo].[Students]
(
	[SubscriptionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SubscriptionType_SubscriptionId]    Script Date: 20.02.2022 21:50:29 ******/
CREATE NONCLUSTERED INDEX [IX_SubscriptionType_SubscriptionId] ON [dbo].[SubscriptionType]
(
	[SubscriptionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Teachers_AddressId]    Script Date: 20.02.2022 21:50:29 ******/
CREATE NONCLUSTERED INDEX [IX_Teachers_AddressId] ON [dbo].[Teachers]
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Teachers_LessonId]    Script Date: 20.02.2022 21:50:29 ******/
CREATE NONCLUSTERED INDEX [IX_Teachers_LessonId] ON [dbo].[Teachers]
(
	[LessonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_workingForOneHours_weekID]    Script Date: 20.02.2022 21:50:29 ******/
CREATE NONCLUSTERED INDEX [IX_workingForOneHours_weekID] ON [dbo].[workingForOneHours]
(
	[weekID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_WorkingHoursOfWeeks_TeacherId]    Script Date: 20.02.2022 21:50:29 ******/
CREATE NONCLUSTERED INDEX [IX_WorkingHoursOfWeeks_TeacherId] ON [dbo].[WorkingHoursOfWeeks]
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[LessonDetails]  WITH CHECK ADD  CONSTRAINT [FK_LessonDetails_Lessons_LessonId] FOREIGN KEY([LessonId])
REFERENCES [dbo].[Lessons] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LessonDetails] CHECK CONSTRAINT [FK_LessonDetails_Lessons_LessonId]
GO
ALTER TABLE [dbo].[Meets]  WITH CHECK ADD  CONSTRAINT [FK_Meets_Addresses_AddressId] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Addresses] ([Id])
GO
ALTER TABLE [dbo].[Meets] CHECK CONSTRAINT [FK_Meets_Addresses_AddressId]
GO
ALTER TABLE [dbo].[Meets]  WITH CHECK ADD  CONSTRAINT [FK_Meets_Students_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Meets] CHECK CONSTRAINT [FK_Meets_Students_StudentId]
GO
ALTER TABLE [dbo].[Meets]  WITH CHECK ADD  CONSTRAINT [FK_Meets_Teachers_TeacherId] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teachers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Meets] CHECK CONSTRAINT [FK_Meets_Teachers_TeacherId]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Addresses_AddressId] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Addresses] ([Id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Addresses_AddressId]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Subscription_SubscriptionId] FOREIGN KEY([SubscriptionId])
REFERENCES [dbo].[Subscription] ([Id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Subscription_SubscriptionId]
GO
ALTER TABLE [dbo].[SubscriptionType]  WITH CHECK ADD  CONSTRAINT [FK_SubscriptionType_Subscription_SubscriptionId] FOREIGN KEY([SubscriptionId])
REFERENCES [dbo].[Subscription] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubscriptionType] CHECK CONSTRAINT [FK_SubscriptionType_Subscription_SubscriptionId]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_Addresses_AddressId] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Addresses] ([Id])
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_Teachers_Addresses_AddressId]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_Lessons_LessonId] FOREIGN KEY([LessonId])
REFERENCES [dbo].[Lessons] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_Teachers_Lessons_LessonId]
GO
ALTER TABLE [dbo].[workingForOneHours]  WITH CHECK ADD  CONSTRAINT [FK_workingForOneHours_WorkingHoursOfWeeks_weekID] FOREIGN KEY([weekID])
REFERENCES [dbo].[WorkingHoursOfWeeks] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[workingForOneHours] CHECK CONSTRAINT [FK_workingForOneHours_WorkingHoursOfWeeks_weekID]
GO
ALTER TABLE [dbo].[WorkingHoursOfWeeks]  WITH CHECK ADD  CONSTRAINT [FK_WorkingHoursOfWeeks_Teachers_TeacherId] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teachers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[WorkingHoursOfWeeks] CHECK CONSTRAINT [FK_WorkingHoursOfWeeks_Teachers_TeacherId]
GO
USE [master]
GO
ALTER DATABASE [NewBidersGoDB] SET  READ_WRITE 
GO
