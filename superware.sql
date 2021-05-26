USE [master]
GO
/****** Object:  Database [Superware]    Script Date: 5/26/2021 11:49:53 PM ******/
CREATE DATABASE [Superware]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Superware', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESSOR\MSSQL\DATA\Superware.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Superware_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESSOR\MSSQL\DATA\Superware_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Superware] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Superware].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Superware] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Superware] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Superware] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Superware] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Superware] SET ARITHABORT OFF 
GO
ALTER DATABASE [Superware] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Superware] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Superware] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Superware] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Superware] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Superware] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Superware] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Superware] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Superware] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Superware] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Superware] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Superware] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Superware] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Superware] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Superware] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Superware] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Superware] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Superware] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Superware] SET  MULTI_USER 
GO
ALTER DATABASE [Superware] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Superware] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Superware] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Superware] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Superware] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Superware]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 5/26/2021 11:49:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](100) NULL,
	[TimeCreated] [datetime] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 5/26/2021 11:49:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](200) NULL,
	[Address] [nvarchar](200) NULL,
	[Phone] [nchar](10) NULL,
	[Email] [nchar](100) NULL,
	[TimeCreated] [datetime] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Deverily]    Script Date: 5/26/2021 11:49:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deverily](
	[DeverilyID] [int] IDENTITY(1,1) NOT NULL,
	[DeverilyDate] [datetime] NULL,
	[QuanityDeverily] [int] NULL,
	[OderID] [nchar](100) NULL,
 CONSTRAINT [PK_Deverily] PRIMARY KEY CLUSTERED 
(
	[DeverilyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order]    Script Date: 5/26/2021 11:49:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [nchar](100) NOT NULL,
	[QuestionDate] [datetime] NULL,
	[ConfirmDate] [datetime] NULL,
	[OrderDate] [datetime] NULL,
	[RequestDate] [datetime] NULL,
	[FinishDate] [datetime] NULL,
	[OrderFrom] [nvarchar](100) NULL,
	[ProductID] [nchar](100) NULL,
	[CustomerID] [int] NULL,
	[SaleID] [int] NULL,
	[Status] [text] NULL,
	[QuantityReq] [int] NULL,
	[WarehouseID] [int] NULL,
	[PriorityID] [int] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pattern]    Script Date: 5/26/2021 11:49:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pattern](
	[PatternID] [int] IDENTITY(1,1) NOT NULL,
	[PatternName] [nvarchar](200) NULL,
	[TimeCreated] [datetime] NULL,
 CONSTRAINT [PK_Pattern] PRIMARY KEY CLUSTERED 
(
	[PatternID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 5/26/2021 11:49:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [nchar](100) NOT NULL,
	[Barcode] [nchar](100) NULL,
	[Quantity] [int] NULL,
	[Weight] [float] NULL,
	[Price] [money] NULL,
	[Note] [text] NULL,
	[NameEnglish] [varchar](200) NULL,
	[NameVietNamese] [nvarchar](200) NULL,
	[MOQ] [int] NULL,
	[QuanityOPackage] [int] NULL,
	[PatternID] [int] NULL,
	[CategoryID] [int] NULL,
	[Status] [bit] NULL,
	[ReqStockID] [int] NULL,
	[Detail] [ntext] NULL,
	[Image] [nvarchar](250) NULL,
	[TimeCreated] [datetime] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductPromotion]    Script Date: 5/26/2021 11:49:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductPromotion](
	[ProductID] [nchar](100) NOT NULL,
	[PromotionID] [int] NOT NULL,
 CONSTRAINT [PK_ProductPromotion] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC,
	[PromotionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Promotion]    Script Date: 5/26/2021 11:49:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promotion](
	[PromotionID] [int] IDENTITY(1,1) NOT NULL,
	[PromotionName] [nvarchar](100) NULL,
	[DiscountPercent] [real] NULL,
	[TimeCreated] [datetime] NULL,
 CONSTRAINT [PK_Promotion] PRIMARY KEY CLUSTERED 
(
	[PromotionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Prority]    Script Date: 5/26/2021 11:49:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prority](
	[ProrityID] [int] IDENTITY(1,1) NOT NULL,
	[ProrityContent] [nvarchar](100) NULL,
	[TimeCreated] [datetime] NULL,
 CONSTRAINT [PK_Prority] PRIMARY KEY CLUSTERED 
(
	[ProrityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ReqStock]    Script Date: 5/26/2021 11:49:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReqStock](
	[ReqStockID] [int] IDENTITY(1,1) NOT NULL,
	[ReqStockContent] [float] NULL,
	[TimeCreated] [datetime] NULL,
 CONSTRAINT [PK_ReqStock] PRIMARY KEY CLUSTERED 
(
	[ReqStockID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 5/26/2021 11:49:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](200) NULL,
	[TimeCreated] [datetime] NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 5/26/2021 11:49:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](200) NULL,
	[Password] [nchar](100) NULL,
	[TimeCreated] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 5/26/2021 11:49:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserID] [int] NOT NULL,
	[RoleID] [int] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Warehouse]    Script Date: 5/26/2021 11:49:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Warehouse](
	[WarehouseID] [int] IDENTITY(1,1) NOT NULL,
	[WarehouseName] [nvarchar](100) NULL,
	[Addresss] [nvarchar](100) NULL,
	[Priority] [nvarchar](50) NULL,
	[TimeCreated] [datetime] NULL,
 CONSTRAINT [PK_Warehouse] PRIMARY KEY CLUSTERED 
(
	[WarehouseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Deverily]  WITH CHECK ADD  CONSTRAINT [FK_Deverily_Order] FOREIGN KEY([OderID])
REFERENCES [dbo].[Order] ([OrderID])
GO
ALTER TABLE [dbo].[Deverily] CHECK CONSTRAINT [FK_Deverily_Order]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Customer]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Product]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Prority] FOREIGN KEY([PriorityID])
REFERENCES [dbo].[Prority] ([ProrityID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Prority]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_User] FOREIGN KEY([SaleID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_User]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Warehouse] FOREIGN KEY([WarehouseID])
REFERENCES [dbo].[Warehouse] ([WarehouseID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Warehouse]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Pattern] FOREIGN KEY([PatternID])
REFERENCES [dbo].[Pattern] ([PatternID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Pattern]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ReqStock] FOREIGN KEY([ReqStockID])
REFERENCES [dbo].[ReqStock] ([ReqStockID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ReqStock]
GO
ALTER TABLE [dbo].[ProductPromotion]  WITH CHECK ADD  CONSTRAINT [FK_ProductPromotion_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[ProductPromotion] CHECK CONSTRAINT [FK_ProductPromotion_Product]
GO
ALTER TABLE [dbo].[ProductPromotion]  WITH CHECK ADD  CONSTRAINT [FK_ProductPromotion_Promotion] FOREIGN KEY([PromotionID])
REFERENCES [dbo].[Promotion] ([PromotionID])
GO
ALTER TABLE [dbo].[ProductPromotion] CHECK CONSTRAINT [FK_ProductPromotion_Promotion]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_User]
GO
USE [master]
GO
ALTER DATABASE [Superware] SET  READ_WRITE 
GO
