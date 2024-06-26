USE [master]
GO
/****** Object:  Database [SupermarketDB]    Script Date: 5/26/2024 2:00:52 PM ******/
CREATE DATABASE [SupermarketDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Supermarket', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Supermarket.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Supermarket_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Supermarket_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [SupermarketDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SupermarketDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SupermarketDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SupermarketDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SupermarketDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SupermarketDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SupermarketDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [SupermarketDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SupermarketDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SupermarketDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SupermarketDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SupermarketDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SupermarketDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SupermarketDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SupermarketDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SupermarketDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SupermarketDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SupermarketDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SupermarketDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SupermarketDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SupermarketDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SupermarketDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SupermarketDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SupermarketDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SupermarketDB] SET RECOVERY FULL 
GO
ALTER DATABASE [SupermarketDB] SET  MULTI_USER 
GO
ALTER DATABASE [SupermarketDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SupermarketDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SupermarketDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SupermarketDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SupermarketDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SupermarketDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'SupermarketDB', N'ON'
GO
ALTER DATABASE [SupermarketDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [SupermarketDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [SupermarketDB]
GO
USE [SupermarketDB]
GO
/****** Object:  Sequence [dbo].[ProductStocksSeq]    Script Date: 5/26/2024 2:00:52 PM ******/
CREATE SEQUENCE [dbo].[ProductStocksSeq] 
 AS [bigint]
 START WITH 1
 INCREMENT BY 1
 MINVALUE -9223372036854775808
 MAXVALUE 9223372036854775807
 CACHE 
GO
USE [SupermarketDB]
GO
/****** Object:  Sequence [dbo].[ReceiptIDSequence]    Script Date: 5/26/2024 2:00:52 PM ******/
CREATE SEQUENCE [dbo].[ReceiptIDSequence] 
 AS [bigint]
 START WITH 1
 INCREMENT BY 1
 MINVALUE -9223372036854775808
 MAXVALUE 9223372036854775807
 CACHE 
GO
/****** Object:  Table [dbo].[Category]    Script Date: 5/26/2024 2:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producer]    Script Date: 5/26/2024 2:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producer](
	[ID] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Country] [varchar](50) NOT NULL,
	[deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Producer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 5/26/2024 2:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[BarCode] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[ProducerID] [int] NOT NULL,
	[deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[BarCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductOnReceipt]    Script Date: 5/26/2024 2:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductOnReceipt](
	[ReceiptID] [int] NOT NULL,
	[BarCode] [varchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Subtotal] [decimal](10, 2) NOT NULL,
	[deleted] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductStocks]    Script Date: 5/26/2024 2:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductStocks](
	[ID] [int] NOT NULL,
	[BarCode] [varchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Unit] [varchar](50) NOT NULL,
	[SupplyDate] [date] NOT NULL,
	[ExpiryDate] [date] NOT NULL,
	[PurchasePrice] [decimal](10, 2) NOT NULL,
	[SellingPrice] [decimal](10, 2) NOT NULL,
	[deleted] [bit] NOT NULL,
 CONSTRAINT [PK_ProductStocks] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Receipt]    Script Date: 5/26/2024 2:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receipt](
	[ID] [int] NOT NULL,
	[ReleaseDate] [date] NOT NULL,
	[CasherID] [int] NOT NULL,
	[Total] [decimal](10, 2) NOT NULL,
	[deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Receipt] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/26/2024 2:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] NOT NULL,
	[password] [varchar](50) NOT NULL,
	[role] [varchar](50) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Category] ([id], [name], [deleted]) VALUES (1, N'drink', 0)
INSERT [dbo].[Category] ([id], [name], [deleted]) VALUES (2, N'foods', 1)
INSERT [dbo].[Category] ([id], [name], [deleted]) VALUES (3, N'consumables', 0)
INSERT [dbo].[Category] ([id], [name], [deleted]) VALUES (4, N'vegetables', 1)
GO
INSERT [dbo].[Producer] ([ID], [Name], [Country], [deleted]) VALUES (1, N'Cocacola', N'Abudabi', 0)
INSERT [dbo].[Producer] ([ID], [Name], [Country], [deleted]) VALUES (2, N'pepsi', N'America', 0)
INSERT [dbo].[Producer] ([ID], [Name], [Country], [deleted]) VALUES (3, N'Fanta', N'England', 1)
INSERT [dbo].[Producer] ([ID], [Name], [Country], [deleted]) VALUES (4, N'Jveps', N'Romania', 1)
INSERT [dbo].[Producer] ([ID], [Name], [Country], [deleted]) VALUES (5, N'Fantastix', N'England', 0)
GO
INSERT [dbo].[Product] ([BarCode], [Name], [CategoryID], [ProducerID], [deleted]) VALUES (N'123', N'cola', 1, 1, 0)
INSERT [dbo].[Product] ([BarCode], [Name], [CategoryID], [ProducerID], [deleted]) VALUES (N'124', N'dasa', 1, 2, 0)
INSERT [dbo].[Product] ([BarCode], [Name], [CategoryID], [ProducerID], [deleted]) VALUES (N'125', N'Fanta', 1, 3, 0)
INSERT [dbo].[Product] ([BarCode], [Name], [CategoryID], [ProducerID], [deleted]) VALUES (N'128', N'Schweppes', 1, 1, 0)
GO
INSERT [dbo].[ProductOnReceipt] ([ReceiptID], [BarCode], [Quantity], [Subtotal], [deleted]) VALUES (5, N'123', 4, CAST(32.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[ProductOnReceipt] ([ReceiptID], [BarCode], [Quantity], [Subtotal], [deleted]) VALUES (5, N'124', 3, CAST(30.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[ProductOnReceipt] ([ReceiptID], [BarCode], [Quantity], [Subtotal], [deleted]) VALUES (6, N'123', 2, CAST(16.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[ProductOnReceipt] ([ReceiptID], [BarCode], [Quantity], [Subtotal], [deleted]) VALUES (6, N'124', 3, CAST(30.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[ProductOnReceipt] ([ReceiptID], [BarCode], [Quantity], [Subtotal], [deleted]) VALUES (9, N'123', 10, CAST(80.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[ProductOnReceipt] ([ReceiptID], [BarCode], [Quantity], [Subtotal], [deleted]) VALUES (10, N'124', 17, CAST(170.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[ProductOnReceipt] ([ReceiptID], [BarCode], [Quantity], [Subtotal], [deleted]) VALUES (10, N'123', 1, CAST(8.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[ProductOnReceipt] ([ReceiptID], [BarCode], [Quantity], [Subtotal], [deleted]) VALUES (7, N'124', 3, CAST(30.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[ProductOnReceipt] ([ReceiptID], [BarCode], [Quantity], [Subtotal], [deleted]) VALUES (7, N'123', 6, CAST(48.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[ProductOnReceipt] ([ReceiptID], [BarCode], [Quantity], [Subtotal], [deleted]) VALUES (8, N'123', 3, CAST(24.00 AS Decimal(10, 2)), 0)
GO
INSERT [dbo].[ProductStocks] ([ID], [BarCode], [Quantity], [Unit], [SupplyDate], [ExpiryDate], [PurchasePrice], [SellingPrice], [deleted]) VALUES (2, N'123', 15, N'Litres', CAST(N'2024-10-10' AS Date), CAST(N'2024-12-12' AS Date), CAST(5.00 AS Decimal(10, 2)), CAST(10.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[ProductStocks] ([ID], [BarCode], [Quantity], [Unit], [SupplyDate], [ExpiryDate], [PurchasePrice], [SellingPrice], [deleted]) VALUES (3, N'124', 28, N'Litres', CAST(N'2024-05-24' AS Date), CAST(N'2024-05-31' AS Date), CAST(7.00 AS Decimal(10, 2)), CAST(15.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[ProductStocks] ([ID], [BarCode], [Quantity], [Unit], [SupplyDate], [ExpiryDate], [PurchasePrice], [SellingPrice], [deleted]) VALUES (4, N'125', 0, N'Litres', CAST(N'2022-02-07' AS Date), CAST(N'2023-01-01' AS Date), CAST(4.00 AS Decimal(10, 2)), CAST(7.50 AS Decimal(10, 2)), 1)
INSERT [dbo].[ProductStocks] ([ID], [BarCode], [Quantity], [Unit], [SupplyDate], [ExpiryDate], [PurchasePrice], [SellingPrice], [deleted]) VALUES (6, N'123', 50, N'Litres', CAST(N'2024-05-24' AS Date), CAST(N'2024-05-31' AS Date), CAST(5.00 AS Decimal(10, 2)), CAST(15.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[ProductStocks] ([ID], [BarCode], [Quantity], [Unit], [SupplyDate], [ExpiryDate], [PurchasePrice], [SellingPrice], [deleted]) VALUES (7, N'124', 28, N'Litres', CAST(N'2024-05-24' AS Date), CAST(N'2024-05-31' AS Date), CAST(7.00 AS Decimal(10, 2)), CAST(15.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[ProductStocks] ([ID], [BarCode], [Quantity], [Unit], [SupplyDate], [ExpiryDate], [PurchasePrice], [SellingPrice], [deleted]) VALUES (8, N'123', 0, N'Litres', CAST(N'2024-05-24' AS Date), CAST(N'2024-05-31' AS Date), CAST(5.00 AS Decimal(10, 2)), CAST(15.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[ProductStocks] ([ID], [BarCode], [Quantity], [Unit], [SupplyDate], [ExpiryDate], [PurchasePrice], [SellingPrice], [deleted]) VALUES (9, N'124', 28, N'Litres', CAST(N'2024-05-24' AS Date), CAST(N'2024-05-31' AS Date), CAST(7.00 AS Decimal(10, 2)), CAST(105.00 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[Receipt] ([ID], [ReleaseDate], [CasherID], [Total], [deleted]) VALUES (5, CAST(N'2024-05-23' AS Date), 2, CAST(62.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Receipt] ([ID], [ReleaseDate], [CasherID], [Total], [deleted]) VALUES (6, CAST(N'2024-05-23' AS Date), 2, CAST(46.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Receipt] ([ID], [ReleaseDate], [CasherID], [Total], [deleted]) VALUES (7, CAST(N'2024-05-23' AS Date), 2, CAST(78.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Receipt] ([ID], [ReleaseDate], [CasherID], [Total], [deleted]) VALUES (8, CAST(N'2024-05-23' AS Date), 2, CAST(24.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Receipt] ([ID], [ReleaseDate], [CasherID], [Total], [deleted]) VALUES (9, CAST(N'2024-05-23' AS Date), 2, CAST(80.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[Receipt] ([ID], [ReleaseDate], [CasherID], [Total], [deleted]) VALUES (10, CAST(N'2024-05-24' AS Date), 2, CAST(178.00 AS Decimal(10, 2)), 0)
GO
INSERT [dbo].[Users] ([ID], [password], [role], [username], [name], [deleted]) VALUES (1, N'admin', N'Administrator', N'admin', N'adminv1', 0)
INSERT [dbo].[Users] ([ID], [password], [role], [username], [name], [deleted]) VALUES (2, N'asd', N'Casier', N'asd', N'asd1', 0)
INSERT [dbo].[Users] ([ID], [password], [role], [username], [name], [deleted]) VALUES (3, N'asd', N'Casier', N'asd', N'PopaGeorge', 1)
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Producer] FOREIGN KEY([ProducerID])
REFERENCES [dbo].[Producer] ([ID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Producer]
GO
ALTER TABLE [dbo].[ProductOnReceipt]  WITH CHECK ADD  CONSTRAINT [Product_ReceiptProduct] FOREIGN KEY([BarCode])
REFERENCES [dbo].[Product] ([BarCode])
GO
ALTER TABLE [dbo].[ProductOnReceipt] CHECK CONSTRAINT [Product_ReceiptProduct]
GO
ALTER TABLE [dbo].[ProductOnReceipt]  WITH CHECK ADD  CONSTRAINT [Receipt_ProductOnReceipt] FOREIGN KEY([ReceiptID])
REFERENCES [dbo].[Receipt] ([ID])
GO
ALTER TABLE [dbo].[ProductOnReceipt] CHECK CONSTRAINT [Receipt_ProductOnReceipt]
GO
ALTER TABLE [dbo].[ProductStocks]  WITH CHECK ADD  CONSTRAINT [FK_ProductStocks_Product] FOREIGN KEY([BarCode])
REFERENCES [dbo].[Product] ([BarCode])
GO
ALTER TABLE [dbo].[ProductStocks] CHECK CONSTRAINT [FK_ProductStocks_Product]
GO
ALTER TABLE [dbo].[Receipt]  WITH CHECK ADD  CONSTRAINT [FK_Receipt_Users] FOREIGN KEY([CasherID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Receipt] CHECK CONSTRAINT [FK_Receipt_Users]
GO
/****** Object:  StoredProcedure [dbo].[AddCategory]    Script Date: 5/26/2024 2:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[AddCategory]
    @ID INT,
    @Name NVARCHAR(100),
    @Deleted BIT
AS
BEGIN
    INSERT INTO Category (ID, Name, deleted)
    VALUES (@ID, @Name, @Deleted);
END;
GO
/****** Object:  StoredProcedure [dbo].[AddProducer]    Script Date: 5/26/2024 2:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddProducer]
    @ID INT,
    @Name NVARCHAR(100),
    @Country NVARCHAR(100),
    @Deleted BIT
AS
BEGIN
    INSERT INTO Producer (ID, Name, Country, deleted)
    VALUES (@ID, @Name, @Country, @Deleted);
END;
GO
/****** Object:  StoredProcedure [dbo].[AddProduct]    Script Date: 5/26/2024 2:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddProduct]
    @Barcode NVARCHAR(50),
    @Name NVARCHAR(100),
    @CategoryID INT,
    @ProducerID INT,
    @Deleted BIT
AS
BEGIN
	INSERT INTO Product (Barcode, Name, CategoryID, ProducerID, Deleted)
	VALUES (@Barcode, @Name, @CategoryID, @ProducerID, @Deleted)
END
GO
/****** Object:  StoredProcedure [dbo].[AddProductsOnReceipt]    Script Date: 5/26/2024 2:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddProductsOnReceipt]
    @Barcode VARCHAR(50),
    @Quantity INT,
    @Subtotal DECIMAL(18, 2),
    @Deleted BIT
AS
BEGIN
    DECLARE @ReceiptID INT;

    -- Obținem ultimul ReceiptID
    SELECT @ReceiptID = MAX(ID) FROM Receipt;

    -- Inserăm în tabela ProductOnReceipt
    INSERT INTO ProductOnReceipt (ReceiptID, Barcode, Quantity, Subtotal, Deleted)
    VALUES (@ReceiptID, @Barcode, @Quantity, @Subtotal, @Deleted);
END
GO
/****** Object:  StoredProcedure [dbo].[AddReceipt]    Script Date: 5/26/2024 2:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddReceipt]
    @ReleaseDate DATETIME,
    @CasherID INT,
    @Total DECIMAL(10, 2),
    @Deleted BIT
AS
BEGIN
    DECLARE @NewReceiptID INT;
    SET @NewReceiptID = NEXT VALUE FOR ReceiptIDSequence;

    INSERT INTO Receipt (ID, ReleaseDate, CasherID, Total, Deleted)
    VALUES (@NewReceiptID, @ReleaseDate, @CasherID, @Total, @Deleted);
    
    SELECT @NewReceiptID AS NewReceiptID;
END
GO
/****** Object:  StoredProcedure [dbo].[AddStock]    Script Date: 5/26/2024 2:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddStock]
    @Barcode NVARCHAR(50),
    @Quantity INT,
    @Unit NVARCHAR(50),
    @SupplyDate DATETIME,
    @ExpiryDate DATETIME,
    @PurchasePrice DECIMAL(18, 2),
    @SellingPrice DECIMAL(18, 2)
AS
BEGIN
    DECLARE @Deleted BIT
    SET @Deleted = CASE WHEN @Quantity = 0 THEN 1 ELSE 0 END

    INSERT INTO ProductStocks (Barcode, Quantity, Unit, SupplyDate, ExpiryDate, PurchasePrice, SellingPrice, Deleted)
    VALUES (@Barcode, @Quantity, @Unit, @SupplyDate, @ExpiryDate, @PurchasePrice, @SellingPrice, @Deleted)
END
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 5/26/2024 2:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUser]
    @ID INT,
    @Name NVARCHAR(50),
    @Password NVARCHAR(50),
    @Username NVARCHAR(50),
    @Role NVARCHAR(50),
    @Deleted BIT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM users WHERE Username = @Username)
    BEGIN
        INSERT INTO users (id, Name, Password, Username, Role, Deleted)
        VALUES (@ID, @Name, @Password, @Username, @Role, @Deleted);
    END
    ELSE
    BEGIN
        RAISERROR('A user with the same username already exists.', 16, 1);
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[DeleteCategory]    Script Date: 5/26/2024 2:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteCategory]
    @ID INT
AS
BEGIN
    UPDATE Category
    SET deleted = 1
    WHERE ID = @ID;
END;
GO
/****** Object:  StoredProcedure [dbo].[DeleteProducer]    Script Date: 5/26/2024 2:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteProducer]
    @ID INT
AS
BEGIN
    UPDATE Producer
    SET deleted = 1
    WHERE ID = @ID;
END;
GO
/****** Object:  StoredProcedure [dbo].[DeleteProduct]    Script Date: 5/26/2024 2:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteProduct]
    @Barcode NVARCHAR(50)
AS
BEGIN
    -- Setăm Deleted la true pentru produsul cu codul de bare specificat
    UPDATE Product
    SET Deleted = 1
    WHERE Barcode = @Barcode;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteStock]    Script Date: 5/26/2024 2:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteStock]
    @Barcode NVARCHAR(100),
    @Deleted BIT
AS
BEGIN
    UPDATE ProductStocks
    SET deleted = @Deleted
    WHERE Barcode = @Barcode;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 5/26/2024 2:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteUser]
    @ID INT
AS
BEGIN
    -- Actualizează coloana `deleted` pentru rândul specificat de `ID`
    UPDATE users
    SET deleted = 1
    WHERE ID = @ID;
END;
GO
/****** Object:  StoredProcedure [dbo].[EditCategory]    Script Date: 5/26/2024 2:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditCategory]
    @ID INT,
    @Name NVARCHAR(100)
AS
BEGIN
    UPDATE Category
    SET Name = @Name
    WHERE ID = @ID;
END;
GO
/****** Object:  StoredProcedure [dbo].[EditProducer]    Script Date: 5/26/2024 2:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditProducer]
    @ID INT,
    @Name NVARCHAR(100),
    @Country NVARCHAR(100)
AS
BEGIN
    UPDATE Producer
    SET Name = @Name,
        Country = @Country
    WHERE ID = @ID;
END;
GO
/****** Object:  StoredProcedure [dbo].[EditProduct]    Script Date: 5/26/2024 2:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditProduct]
    @Barcode NVARCHAR(50),
    @Name NVARCHAR(100),
    @CategoryID INT,
    @ProducerID INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Product
    SET Name = @Name,
        CategoryID = @CategoryID,
        ProducerID = @ProducerID
    WHERE Barcode = @Barcode;
END
GO
/****** Object:  StoredProcedure [dbo].[EditStock]    Script Date: 5/26/2024 2:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditStock]
	@ID INT,
    @Barcode NVARCHAR(50),
    @PurchasePrice DECIMAL(18, 2),
    @Unit NVARCHAR(50),
    @Quantity INT,
    @SellingPrice DECIMAL(18, 2),
    @DateOfSupply DATE,
    @ExpirationDate DATE
	
AS
BEGIN
    UPDATE ProductStocks
    SET 
        PurchasePrice = @PurchasePrice,
        Unit = @Unit,
        Quantity = @Quantity,
        SellingPrice = @SellingPrice,
        SupplyDate = @DateOfSupply,
        ExpiryDate = @ExpirationDate
    WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[EditUser]    Script Date: 5/26/2024 2:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditUser]
    @ID INT,
    @Name NVARCHAR(50),
    @Password NVARCHAR(50),
    @Username NVARCHAR(50),
    @Role NVARCHAR(50)
AS
BEGIN
    UPDATE users
    SET
        Name = @Name,
        Password = @Password,
        Username = @Username,
        Role = @Role
    WHERE Id = @ID;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetAllAccounts]    Script Date: 5/26/2024 2:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllAccounts]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Username, [Password],[Role],ID,name,deleted
    FROM Users;
END
GO
/****** Object:  StoredProcedure [dbo].[GetCategoryDetails]    Script Date: 5/26/2024 2:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCategoryDetails]
AS
BEGIN
    SELECT ID,NAME,deleted
    FROM Category;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetProducerDetails]    Script Date: 5/26/2024 2:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetProducerDetails]
AS
BEGIN
    SELECT ID,NAME
    FROM Producer;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetProducers]    Script Date: 5/26/2024 2:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProducers]
AS
BEGIN
    SELECT Id, Name, Country, deleted
    FROM Producer
END;
GO
/****** Object:  StoredProcedure [dbo].[GetProductDetails]    Script Date: 5/26/2024 2:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductDetails]
AS
BEGIN
    SELECT Barcode, Name, CategoryID, ProducerID, Deleted
    FROM Product;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetProductsOnReceipt]    Script Date: 5/26/2024 2:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductsOnReceipt]
AS
BEGIN
    SELECT Barcode, Quantity, ReceiptId, Subtotal
    FROM ProductOnReceipt
END
GO
/****** Object:  StoredProcedure [dbo].[GetReceipts]    Script Date: 5/26/2024 2:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetReceipts]
AS
BEGIN
    SELECT Id, ReleaseDate, CasherID, Total
    FROM Receipt
END
GO
/****** Object:  StoredProcedure [dbo].[GetSearchProducts]    Script Date: 5/26/2024 2:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetSearchProducts]
AS
BEGIN
    select Product.name, Category.name,Producer.Name,Product.Barcode,Unit,SellingPrice,ExpiryDate,Quantity from Product inner join ProductStocks on Product.BarCode=ProductStocks.BarCode inner join Category on Category.id=Product.CategoryID inner join Producer on producer.ID=product.ProducerID;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetStockProducts]    Script Date: 5/26/2024 2:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetStockProducts]
AS
BEGIN
    SELECT 
        p.Name,
        ps.Barcode,
        ps.Quantity,
        ps.Unit,
        ps.ExpiryDate,
        ps.SellingPrice
    FROM 
        ProductStocks ps
    INNER JOIN 
        Product p ON ps.Barcode = p.Barcode
END;
GO
/****** Object:  StoredProcedure [dbo].[GetStocks]    Script Date: 5/26/2024 2:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetStocks]
AS
BEGIN
    SELECT 
		ps.ID,
        ps.Barcode,
        ps.Quantity,
        ps.Unit,
		ps.PurchasePrice,
        ps.ExpiryDate,
		ps.SupplyDate,
        ps.SellingPrice,
		ps.deleted
    FROM 
        ProductStocks ps
END;
GO
/****** Object:  StoredProcedure [dbo].[UpdateStock]    Script Date: 5/26/2024 2:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateStock]
    @Barcode VARCHAR(50),
    @QuantityChange INT
AS
BEGIN
    UPDATE ProductStocks
    SET Quantity = Quantity + @QuantityChange
    WHERE Barcode = @Barcode;
END
GO
USE [master]
GO
ALTER DATABASE [SupermarketDB] SET  READ_WRITE 
GO
