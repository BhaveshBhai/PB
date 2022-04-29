USE [master]
GO
/****** Object:  Database [PBSA]    Script Date: 29/04/2022 10:46:14 PM ******/
CREATE DATABASE [PBSA]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PBSA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\PBSA.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PBSA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\PBSA_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PBSA] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PBSA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PBSA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PBSA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PBSA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PBSA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PBSA] SET ARITHABORT OFF 
GO
ALTER DATABASE [PBSA] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PBSA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PBSA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PBSA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PBSA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PBSA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PBSA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PBSA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PBSA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PBSA] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PBSA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PBSA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PBSA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PBSA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PBSA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PBSA] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PBSA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PBSA] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PBSA] SET  MULTI_USER 
GO
ALTER DATABASE [PBSA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PBSA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PBSA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PBSA] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PBSA] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PBSA] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PBSA] SET QUERY_STORE = OFF
GO
USE [PBSA]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 29/04/2022 10:46:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[AddressTypeId] [int] NOT NULL,
	[Street] [nvarchar](500) NOT NULL,
	[PostCode] [nvarchar](4) NOT NULL,
	[CustomerId] [int] NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AddressType]    Script Date: 29/04/2022 10:46:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AddressType](
	[AddressTypeId] [int] IDENTITY(1,1) NOT NULL,
	[AddresType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AddressType] PRIMARY KEY CLUSTERED 
(
	[AddressTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 29/04/2022 10:46:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](12) NOT NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_Customer_1] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 29/04/2022 10:46:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Weight] [numeric](18, 0) NOT NULL,
	[PriceAmount] [decimal](18, 2) NOT NULL,
	[PriceTax] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sale]    Script Date: 29/04/2022 10:46:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sale](
	[SaleId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
	[TotalTax] [decimal](18, 2) NOT NULL,
	[SaleLineIds] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Sale] PRIMARY KEY CLUSTERED 
(
	[SaleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SaleLine]    Script Date: 29/04/2022 10:46:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SaleLine](
	[SaleLineId] [int] IDENTITY(1,1) NOT NULL,
	[Quantity] [int] NOT NULL,
	[SubTotalAmount] [decimal](18, 2) NOT NULL,
	[SubTotalTax] [decimal](18, 2) NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_SaleLine] PRIMARY KEY CLUSTERED 
(
	[SaleLineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 29/04/2022 10:46:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Address] ON 
GO
INSERT [dbo].[Address] ([AddressId], [AddressTypeId], [Street], [PostCode], [CustomerId]) VALUES (1, 1, N'Sorrel avenue', N'3352', 1)
GO
INSERT [dbo].[Address] ([AddressId], [AddressTypeId], [Street], [PostCode], [CustomerId]) VALUES (2, 2, N'Sorrel avenue', N'3352', 1)
GO
SET IDENTITY_INSERT [dbo].[Address] OFF
GO
SET IDENTITY_INSERT [dbo].[AddressType] ON 
GO
INSERT [dbo].[AddressType] ([AddressTypeId], [AddresType]) VALUES (1, N'Shipping')
GO
INSERT [dbo].[AddressType] ([AddressTypeId], [AddresType]) VALUES (2, N'Billing')
GO
SET IDENTITY_INSERT [dbo].[AddressType] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 
GO
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Email], [Phone], [UserId]) VALUES (1, N'Bhavesh', N'Narola', N'bhavesh@gmail.com', N'0475785218', 1)
GO
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 
GO
INSERT [dbo].[Product] ([ProductId], [Title], [Code], [Weight], [PriceAmount], [PriceTax]) VALUES (1, N'test', N'test001', CAST(2 AS Numeric(18, 0)), CAST(5.00 AS Decimal(18, 2)), CAST(0.50 AS Decimal(18, 2)))
GO
INSERT [dbo].[Product] ([ProductId], [Title], [Code], [Weight], [PriceAmount], [PriceTax]) VALUES (2, N'test-2', N'test002', CAST(2 AS Numeric(18, 0)), CAST(10.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Sale] ON 
GO
INSERT [dbo].[Sale] ([SaleId], [CustomerId], [TotalAmount], [TotalTax], [SaleLineIds]) VALUES (1, 1, CAST(75.00 AS Decimal(18, 2)), CAST(7.50 AS Decimal(18, 2)), N'1,2')
GO
INSERT [dbo].[Sale] ([SaleId], [CustomerId], [TotalAmount], [TotalTax], [SaleLineIds]) VALUES (2, 1, CAST(75.00 AS Decimal(18, 2)), CAST(7.50 AS Decimal(18, 2)), N'3,4')
GO
SET IDENTITY_INSERT [dbo].[Sale] OFF
GO
SET IDENTITY_INSERT [dbo].[SaleLine] ON 
GO
INSERT [dbo].[SaleLine] ([SaleLineId], [Quantity], [SubTotalAmount], [SubTotalTax], [ProductId]) VALUES (1, 5, CAST(25.00 AS Decimal(18, 2)), CAST(2.50 AS Decimal(18, 2)), 1)
GO
INSERT [dbo].[SaleLine] ([SaleLineId], [Quantity], [SubTotalAmount], [SubTotalTax], [ProductId]) VALUES (2, 5, CAST(50.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), 2)
GO
INSERT [dbo].[SaleLine] ([SaleLineId], [Quantity], [SubTotalAmount], [SubTotalTax], [ProductId]) VALUES (3, 5, CAST(25.00 AS Decimal(18, 2)), CAST(2.50 AS Decimal(18, 2)), 1)
GO
INSERT [dbo].[SaleLine] ([SaleLineId], [Quantity], [SubTotalAmount], [SubTotalTax], [ProductId]) VALUES (4, 5, CAST(50.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), 2)
GO
SET IDENTITY_INSERT [dbo].[SaleLine] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([UserId], [UserName], [Password]) VALUES (1, N'Bhavesh', N'Bhavesh@143')
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Address] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Address] ([AddressId])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Address]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_AddressType] FOREIGN KEY([AddressTypeId])
REFERENCES [dbo].[AddressType] ([AddressTypeId])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_AddressType]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Customer]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_User]
GO
ALTER TABLE [dbo].[Sale]  WITH CHECK ADD  CONSTRAINT [FK_Sale_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[Sale] CHECK CONSTRAINT [FK_Sale_Customer]
GO
ALTER TABLE [dbo].[Sale]  WITH CHECK ADD  CONSTRAINT [FK_Sale_Sale] FOREIGN KEY([SaleId])
REFERENCES [dbo].[Sale] ([SaleId])
GO
ALTER TABLE [dbo].[Sale] CHECK CONSTRAINT [FK_Sale_Sale]
GO
ALTER TABLE [dbo].[SaleLine]  WITH CHECK ADD  CONSTRAINT [FK_SaleLine_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[SaleLine] CHECK CONSTRAINT [FK_SaleLine_Product]
GO
USE [master]
GO
ALTER DATABASE [PBSA] SET  READ_WRITE 
GO
