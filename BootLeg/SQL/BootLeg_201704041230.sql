USE [master]
GO
/****** Object:  Database [BootLeg]    Script Date: 4/4/2017 11:40:19 AM ******/
CREATE DATABASE [BootLeg]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BootLeg', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\BootLeg.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BootLeg_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\BootLeg_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BootLeg] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BootLeg].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BootLeg] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BootLeg] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BootLeg] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BootLeg] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BootLeg] SET ARITHABORT OFF 
GO
ALTER DATABASE [BootLeg] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BootLeg] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BootLeg] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BootLeg] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BootLeg] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BootLeg] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BootLeg] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BootLeg] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BootLeg] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BootLeg] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BootLeg] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BootLeg] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BootLeg] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BootLeg] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BootLeg] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BootLeg] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BootLeg] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BootLeg] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BootLeg] SET  MULTI_USER 
GO
ALTER DATABASE [BootLeg] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BootLeg] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BootLeg] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BootLeg] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BootLeg] SET DELAYED_DURABILITY = DISABLED 
GO
USE [BootLeg]
GO
/****** Object:  Table [dbo].[Meal]    Script Date: 4/4/2017 11:40:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meal](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MealTypeId] [int] NOT NULL,
	[Name] [nchar](30) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Meal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order]    Script Date: 4/4/2017 11:40:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderTypeId] [int] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 4/4/2017 11:40:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[MealId] [int] NOT NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderType]    Script Date: 4/4/2017 11:40:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](20) NOT NULL,
 CONSTRAINT [PK_OrderType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Person]    Script Date: 4/4/2017 11:40:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](30) NOT NULL,
	[Address1] [nvarchar](30) NOT NULL,
	[Address2] [nvarchar](30) NULL,
	[PhoneNumber] [varchar](20) NULL,
	[MobileNumber] [varchar](20) NULL,
	[EmailAddress] [varchar](50) NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Product]    Script Date: 4/4/2017 11:40:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] NOT NULL,
	[Name] [nchar](20) NOT NULL,
	[Descripton] [nchar](50) NULL,
	[Cost] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reservation]    Script Date: 4/4/2017 11:40:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NOT NULL,
	[TableId] [int] NOT NULL,
	[SittingTime] [datetime] NOT NULL,
	[PartySize] [int] NOT NULL,
 CONSTRAINT [PK_Reservation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ReservationOrder]    Script Date: 4/4/2017 11:40:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservationOrder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ReservationId] [int] NOT NULL,
 CONSTRAINT [PK_ReservationOrder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Staff]    Script Date: 4/4/2017 11:40:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[Id] [int] NOT NULL,
	[HourlyRate] [decimal](18, 0) NOT NULL,
	[HireDate] [date] NOT NULL,
	[StaffPositionId] [int] NOT NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StaffPosition]    Script Date: 4/4/2017 11:40:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StaffPosition](
	[Id] [int] NOT NULL,
	[Position] [nchar](10) NOT NULL,
	[StaffTypeId] [int] NOT NULL,
 CONSTRAINT [PK_StaffPosition] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StaffType]    Script Date: 4/4/2017 11:40:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StaffType](
	[Id] [int] NOT NULL,
	[Type] [nchar](10) NOT NULL,
 CONSTRAINT [PK_StaffType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 4/4/2017 11:40:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nchar](30) NOT NULL,
	[SuppplierTypeId] [int] NOT NULL,
	[CreditLimit] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SupplierOrder]    Script Date: 4/4/2017 11:40:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplierOrder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [date] NOT NULL,
	[OrderNumber] [nchar](15) NULL,
	[SupplierId] [int] NOT NULL,
 CONSTRAINT [PK_SupplierOrder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SupplierOrderDetail]    Script Date: 4/4/2017 11:40:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplierOrderDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Cost] [decimal](18, 2) NOT NULL,
	[Qty] [int] NOT NULL,
	[SupplierOrderID] [int] NOT NULL,
 CONSTRAINT [PK_SupplierOrderDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SupplierType]    Script Date: 4/4/2017 11:40:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplierType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](30) NOT NULL,
 CONSTRAINT [PK_SupplierType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Table]    Script Date: 4/4/2017 11:40:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TableName] [nchar](20) NOT NULL,
	[Seats] [int] NOT NULL,
	[Description] [nchar](50) NULL,
 CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_OrderType] FOREIGN KEY([OrderTypeId])
REFERENCES [dbo].[OrderType] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_OrderType]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Meal] FOREIGN KEY([MealId])
REFERENCES [dbo].[Meal] ([Id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Meal]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([Id])
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_Person]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Table] FOREIGN KEY([TableId])
REFERENCES [dbo].[Table] ([Id])
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_Table]
GO
ALTER TABLE [dbo].[ReservationOrder]  WITH CHECK ADD  CONSTRAINT [FK_ReservationOrder_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[ReservationOrder] CHECK CONSTRAINT [FK_ReservationOrder_Order]
GO
ALTER TABLE [dbo].[ReservationOrder]  WITH CHECK ADD  CONSTRAINT [FK_ReservationOrder_Reservation] FOREIGN KEY([ReservationId])
REFERENCES [dbo].[Reservation] ([Id])
GO
ALTER TABLE [dbo].[ReservationOrder] CHECK CONSTRAINT [FK_ReservationOrder_Reservation]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_Person] FOREIGN KEY([Id])
REFERENCES [dbo].[Person] ([Id])
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_Person]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_StaffPosition] FOREIGN KEY([StaffPositionId])
REFERENCES [dbo].[StaffPosition] ([Id])
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_StaffPosition]
GO
ALTER TABLE [dbo].[StaffPosition]  WITH CHECK ADD  CONSTRAINT [FK_StaffPosition_StaffType] FOREIGN KEY([StaffTypeId])
REFERENCES [dbo].[StaffType] ([Id])
GO
ALTER TABLE [dbo].[StaffPosition] CHECK CONSTRAINT [FK_StaffPosition_StaffType]
GO
ALTER TABLE [dbo].[Supplier]  WITH CHECK ADD  CONSTRAINT [FK_Supplier_Person] FOREIGN KEY([Id])
REFERENCES [dbo].[Person] ([Id])
GO
ALTER TABLE [dbo].[Supplier] CHECK CONSTRAINT [FK_Supplier_Person]
GO
ALTER TABLE [dbo].[Supplier]  WITH CHECK ADD  CONSTRAINT [FK_Supplier_SupplierType] FOREIGN KEY([SuppplierTypeId])
REFERENCES [dbo].[SupplierType] ([Id])
GO
ALTER TABLE [dbo].[Supplier] CHECK CONSTRAINT [FK_Supplier_SupplierType]
GO
ALTER TABLE [dbo].[SupplierOrder]  WITH CHECK ADD  CONSTRAINT [FK_SupplierOrder_Supplier] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Supplier] ([Id])
GO
ALTER TABLE [dbo].[SupplierOrder] CHECK CONSTRAINT [FK_SupplierOrder_Supplier]
GO
ALTER TABLE [dbo].[SupplierOrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_SupplierOrderDetail_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[SupplierOrderDetail] CHECK CONSTRAINT [FK_SupplierOrderDetail_Product]
GO
ALTER TABLE [dbo].[SupplierOrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_SupplierOrderDetail_SupplierOrder] FOREIGN KEY([SupplierOrderID])
REFERENCES [dbo].[SupplierOrder] ([Id])
GO
ALTER TABLE [dbo].[SupplierOrderDetail] CHECK CONSTRAINT [FK_SupplierOrderDetail_SupplierOrder]
GO
USE [master]
GO
ALTER DATABASE [BootLeg] SET  READ_WRITE 
GO
