USE [master]
GO
/****** Object:  Database [AgvWarehoueDb]    Script Date: 12/05/2016 17:11:45 ******/
CREATE DATABASE [AgvWarehoueDb] ON  PRIMARY 
( NAME = N'AgvWarehoueDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER2008R\MSSQL\DATA\AgvWarehoueDb.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AgvWarehoueDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER2008R\MSSQL\DATA\AgvWarehoueDb_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [AgvWarehoueDb] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AgvWarehoueDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AgvWarehoueDb] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [AgvWarehoueDb] SET ANSI_NULLS OFF
GO
ALTER DATABASE [AgvWarehoueDb] SET ANSI_PADDING OFF
GO
ALTER DATABASE [AgvWarehoueDb] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [AgvWarehoueDb] SET ARITHABORT OFF
GO
ALTER DATABASE [AgvWarehoueDb] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [AgvWarehoueDb] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [AgvWarehoueDb] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [AgvWarehoueDb] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [AgvWarehoueDb] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [AgvWarehoueDb] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [AgvWarehoueDb] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [AgvWarehoueDb] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [AgvWarehoueDb] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [AgvWarehoueDb] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [AgvWarehoueDb] SET  DISABLE_BROKER
GO
ALTER DATABASE [AgvWarehoueDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [AgvWarehoueDb] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [AgvWarehoueDb] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [AgvWarehoueDb] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [AgvWarehoueDb] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [AgvWarehoueDb] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [AgvWarehoueDb] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [AgvWarehoueDb] SET  READ_WRITE
GO
ALTER DATABASE [AgvWarehoueDb] SET RECOVERY SIMPLE
GO
ALTER DATABASE [AgvWarehoueDb] SET  MULTI_USER
GO
ALTER DATABASE [AgvWarehoueDb] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [AgvWarehoueDb] SET DB_CHAINING OFF
GO
USE [AgvWarehoueDb]
GO
/****** Object:  Table [dbo].[Warehouse]    Script Date: 12/05/2016 17:11:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Warehouse](
	[Nr] [varchar](50) NOT NULL,
	[AgvId] [int] NOT NULL,
 CONSTRAINT [PK_WareHouse] PRIMARY KEY CLUSTERED 
(
	[Nr] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_WareHouse] UNIQUE NONCLUSTERED 
(
	[AgvId] ASC,
	[Nr] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Part]    Script Date: 12/05/2016 17:11:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Part](
	[Nr] [varchar](50) NOT NULL,
	[BoxType] [int] NULL,
 CONSTRAINT [PK_Part] PRIMARY KEY CLUSTERED 
(
	[Nr] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BoxType]    Script Date: 12/05/2016 17:11:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BoxType](
	[Id] [int] NOT NULL,
	[TrayQty] [int] NULL,
	[Type] [int] NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_BoxType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StockTask]    Script Date: 12/05/2016 17:11:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StockTask](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[RoadMachineIndex] [int] NULL,
	[BoxType] [int] NULL,
	[PositionFloor] [int] NULL,
	[PositionColumn] [int] NULL,
	[PositionRow] [int] NULL,
	[AgvPassFlag] [int] NULL,
	[RestPositionFlag] [int] NULL,
	[BarCode] [varchar](50) NULL,
	[State] [int] NULL,
	[Type] [int] NULL,
	[CreatedAt] [datetime] NULL,
 CONSTRAINT [PK_StockTask] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StockMovement]    Script Date: 12/05/2016 17:11:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StockMovement](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SourcePosition] [varchar](50) NOT NULL,
	[AimedPosition] [varchar](50) NOT NULL,
	[OperationType] [int] NOT NULL,
	[Operator] [varchar](50) NOT NULL,
	[Time] [datetime] NOT NULL,
	[CreatedAt] [datetime] NULL,
 CONSTRAINT [PK_Movement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Position]    Script Date: 12/05/2016 17:11:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Position](
	[Nr] [varchar](50) NOT NULL,
	[WarehouseNr] [varchar](50) NOT NULL,
	[Floor] [int] NOT NULL,
	[Column] [int] NOT NULL,
	[Row] [int] NOT NULL,
	[State] [int] NULL,
	[RoadMachineIndex] [int] NULL,
 CONSTRAINT [PK_Posation] PRIMARY KEY CLUSTERED 
(
	[Nr] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UniqueItem]    Script Date: 12/05/2016 17:11:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UniqueItem](
	[Nr] [varchar](50) NOT NULL,
	[PartNr] [varchar](50) NULL,
	[KNr] [varchar](50) NULL,
	[KNrWithYear] [varchar](50) NULL,
	[CheckCode] [varchar](50) NULL,
	[KskNr] [varchar](50) NULL,
	[QR] [varchar](50) NULL,
	[State] [int] NULL,
	[CreatedAt] [datetime] NULL,
	[BoxTypeId] [int] NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[Nr] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Storage]    Script Date: 12/05/2016 17:11:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Storage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PositionNr] [varchar](50) NOT NULL,
	[PartNr] [varchar](50) NOT NULL,
	[FIFO] [datetime] NOT NULL,
	[UniqItemNr] [varchar](50) NULL,
	[CreatedAt] [datetime] NULL,
 CONSTRAINT [PK_Storage_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_Posation_WareHouse]    Script Date: 12/05/2016 17:11:46 ******/
ALTER TABLE [dbo].[Position]  WITH CHECK ADD  CONSTRAINT [FK_Posation_WareHouse] FOREIGN KEY([WarehouseNr])
REFERENCES [dbo].[Warehouse] ([Nr])
GO
ALTER TABLE [dbo].[Position] CHECK CONSTRAINT [FK_Posation_WareHouse]
GO
/****** Object:  ForeignKey [FK_Item_Part]    Script Date: 12/05/2016 17:11:46 ******/
ALTER TABLE [dbo].[UniqueItem]  WITH CHECK ADD  CONSTRAINT [FK_Item_Part] FOREIGN KEY([PartNr])
REFERENCES [dbo].[Part] ([Nr])
GO
ALTER TABLE [dbo].[UniqueItem] CHECK CONSTRAINT [FK_Item_Part]
GO
/****** Object:  ForeignKey [FK_UniqueItem_BoxType]    Script Date: 12/05/2016 17:11:46 ******/
ALTER TABLE [dbo].[UniqueItem]  WITH CHECK ADD  CONSTRAINT [FK_UniqueItem_BoxType] FOREIGN KEY([BoxTypeId])
REFERENCES [dbo].[BoxType] ([Id])
GO
ALTER TABLE [dbo].[UniqueItem] CHECK CONSTRAINT [FK_UniqueItem_BoxType]
GO
/****** Object:  ForeignKey [FK_Storage_Part]    Script Date: 12/05/2016 17:11:46 ******/
ALTER TABLE [dbo].[Storage]  WITH CHECK ADD  CONSTRAINT [FK_Storage_Part] FOREIGN KEY([PartNr])
REFERENCES [dbo].[Part] ([Nr])
GO
ALTER TABLE [dbo].[Storage] CHECK CONSTRAINT [FK_Storage_Part]
GO
/****** Object:  ForeignKey [FK_Storage_Posation]    Script Date: 12/05/2016 17:11:46 ******/
ALTER TABLE [dbo].[Storage]  WITH CHECK ADD  CONSTRAINT [FK_Storage_Posation] FOREIGN KEY([PositionNr])
REFERENCES [dbo].[Position] ([Nr])
GO
ALTER TABLE [dbo].[Storage] CHECK CONSTRAINT [FK_Storage_Posation]
GO
/****** Object:  ForeignKey [FK_Storage_UniqueItem]    Script Date: 12/05/2016 17:11:46 ******/
ALTER TABLE [dbo].[Storage]  WITH CHECK ADD  CONSTRAINT [FK_Storage_UniqueItem] FOREIGN KEY([UniqItemNr])
REFERENCES [dbo].[UniqueItem] ([Nr])
GO
ALTER TABLE [dbo].[Storage] CHECK CONSTRAINT [FK_Storage_UniqueItem]
GO
