
USE [AracKiralama]
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 11.11.2024 07:19:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[StatusId] [tinyint] NOT NULL,
	[LastTransactionDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Model]    Script Date: 11.11.2024 07:19:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Model](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[BrandId] [smallint] NOT NULL,
	[StatusId] [tinyint] NOT NULL,
	[LastTransactionDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Model] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 11.11.2024 07:19:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[StatusId] [tinyint] NOT NULL,
	[LastTransactionDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 11.11.2024 07:19:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[EPosta] [nvarchar](150) NOT NULL,
	[Phone] [nvarchar](11) NOT NULL,
	[StatusId] [tinyint] NOT NULL,
	[LastTransactionDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicle]    Script Date: 11.11.2024 07:19:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicle](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Plate] [nvarchar](50) NOT NULL,
	[Color] [nvarchar](50) NOT NULL,
	[Year] [int] NOT NULL,
	[FuelType] [nvarchar](50) NOT NULL,
	[BrandId] [smallint] NOT NULL,
	[ModelId] [smallint] NOT NULL,
	[DailyPrice] [decimal](18, 2) NOT NULL,
	[StatusId] [tinyint] NOT NULL,
	[LastTransactionDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Brand] ON 

INSERT [dbo].[Brand] ([Id], [Name], [StatusId], [LastTransactionDate]) VALUES (1, N'Ford', 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Brand] ([Id], [Name], [StatusId], [LastTransactionDate]) VALUES (2, N'Honda', 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Brand] ([Id], [Name], [StatusId], [LastTransactionDate]) VALUES (3, N'Hundai', 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Brand] OFF
GO
SET IDENTITY_INSERT [dbo].[Model] ON 

INSERT [dbo].[Model] ([Id], [Name], [BrandId], [StatusId], [LastTransactionDate]) VALUES (1, N'CR-V', 2, 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Model] ([Id], [Name], [BrandId], [StatusId], [LastTransactionDate]) VALUES (3, N'ZR-V', 2, 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Model] ([Id], [Name], [BrandId], [StatusId], [LastTransactionDate]) VALUES (4, N'HR-V', 2, 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Model] ([Id], [Name], [BrandId], [StatusId], [LastTransactionDate]) VALUES (5, N'CIVIC', 2, 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Model] ([Id], [Name], [BrandId], [StatusId], [LastTransactionDate]) VALUES (6, N'JAZZ', 2, 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Model] ([Id], [Name], [BrandId], [StatusId], [LastTransactionDate]) VALUES (7, N'CITY', 2, 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Model] ([Id], [Name], [BrandId], [StatusId], [LastTransactionDate]) VALUES (8, N'Yeni Kuga', 1, 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Model] ([Id], [Name], [BrandId], [StatusId], [LastTransactionDate]) VALUES (10, N'Yeni Puma', 1, 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Model] ([Id], [Name], [BrandId], [StatusId], [LastTransactionDate]) VALUES (11, N'Focus', 1, 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Model] ([Id], [Name], [BrandId], [StatusId], [LastTransactionDate]) VALUES (12, N'Ford Mustang Mach E', 1, 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Model] ([Id], [Name], [BrandId], [StatusId], [LastTransactionDate]) VALUES (14, N'i10', 3, 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Model] ([Id], [Name], [BrandId], [StatusId], [LastTransactionDate]) VALUES (15, N'i20', 3, 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Model] ([Id], [Name], [BrandId], [StatusId], [LastTransactionDate]) VALUES (16, N'Elentra', 3, 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Model] ([Id], [Name], [BrandId], [StatusId], [LastTransactionDate]) VALUES (17, N'Yeni BAYON', 3, 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Model] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [Name], [StatusId], [LastTransactionDate]) VALUES (1, N'Admin', 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Role] ([Id], [Name], [StatusId], [LastTransactionDate]) VALUES (2, N'Kullanici', 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Vehicle] ON 

INSERT [dbo].[Vehicle] ([Id], [Plate], [Color], [Year], [FuelType], [BrandId], [ModelId], [DailyPrice], [StatusId], [LastTransactionDate]) VALUES (1, N'06YY67', N'Red', 2023, N'Dizel', 1, 8, CAST(2000.00 AS Decimal(18, 2)), 1, CAST(N'2024-11-10T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Vehicle] OFF
GO
ALTER TABLE [dbo].[Model]  WITH CHECK ADD  CONSTRAINT [FK_Model_Brand_BrandId] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brand] ([Id])
GO
ALTER TABLE [dbo].[Model] CHECK CONSTRAINT [FK_Model_Brand_BrandId]
GO
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Vehicle_Brand_BrandId] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brand] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Vehicle_Brand_BrandId]
GO
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Vehicle_Model_ModelId] FOREIGN KEY([ModelId])
REFERENCES [dbo].[Model] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Vehicle_Model_ModelId]
GO
USE [master]
GO
ALTER DATABASE [AracKiralama] SET  READ_WRITE 
GO
