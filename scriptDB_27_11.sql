USE [master]
GO
/****** Object:  Database [SpeedMaster]    Script Date: 27/11/2023 19:00:18 ******/
CREATE DATABASE [SpeedMaster]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SpeedMaster', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS01\MSSQL\DATA\SpeedMaster.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SpeedMaster_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS01\MSSQL\DATA\SpeedMaster_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [SpeedMaster] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SpeedMaster].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SpeedMaster] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SpeedMaster] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SpeedMaster] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SpeedMaster] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SpeedMaster] SET ARITHABORT OFF 
GO
ALTER DATABASE [SpeedMaster] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SpeedMaster] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SpeedMaster] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SpeedMaster] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SpeedMaster] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SpeedMaster] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SpeedMaster] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SpeedMaster] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SpeedMaster] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SpeedMaster] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SpeedMaster] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SpeedMaster] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SpeedMaster] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SpeedMaster] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SpeedMaster] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SpeedMaster] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SpeedMaster] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SpeedMaster] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SpeedMaster] SET  MULTI_USER 
GO
ALTER DATABASE [SpeedMaster] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SpeedMaster] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SpeedMaster] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SpeedMaster] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SpeedMaster] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SpeedMaster] SET QUERY_STORE = OFF
GO
USE [SpeedMaster]
GO
/****** Object:  Table [dbo].[Accessories]    Script Date: 27/11/2023 19:00:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accessories](
	[ID_Accessory] [int] NOT NULL,
	[AccessoryName] [varchar](50) NULL,
	[Description] [varchar](max) NULL,
	[Price] [decimal](10, 2) NULL,
	[Stock] [int] NULL,
	[Active] [bit] NULL,
	[ID_Category] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Accessory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 27/11/2023 19:00:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[ID_Brand] [int] IDENTITY(1,1) NOT NULL,
	[BrandName] [varchar](50) NULL,
	[CountryOfOrigin] [varchar](50) NULL,
 CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED 
(
	[ID_Brand] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 27/11/2023 19:00:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[ID_Category] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Category] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 27/11/2023 19:00:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[ID_Customer] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](50) NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[Active] [bit] NULL,
	[NIF] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Customer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GlobalProductIds]    Script Date: 27/11/2023 19:00:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GlobalProductIds](
	[ID_Product] [int] IDENTITY(1,1) NOT NULL,
	[ProductType] [varchar](50) NULL,
 CONSTRAINT [PK_GlobalProductIds] PRIMARY KEY CLUSTERED 
(
	[ID_Product] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Motorcycles]    Script Date: 27/11/2023 19:00:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Motorcycles](
	[ID_Motorcycle] [int] NOT NULL,
	[ID_Brand] [int] NULL,
	[Model] [varchar](50) NULL,
	[ManufacturingYear] [int] NULL,
	[EngineType] [varchar](20) NULL,
	[EngineCapacity] [int] NULL,
	[Color] [varchar](30) NULL,
	[Price] [decimal](10, 2) NULL,
	[Condition] [varchar](10) NULL,
	[Description] [varchar](max) NULL,
	[MotorcycleImage] [varbinary](max) NULL,
	[MotorcycleImageType] [varchar](50) NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Motorcycle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShoppingCarts]    Script Date: 27/11/2023 19:00:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShoppingCarts](
	[ID_ShoppingCart] [int] IDENTITY(1,1) NOT NULL,
	[ID_Customer] [int] NULL,
	[Cartstatus] [bit] NULL,
	[CreatedDate] [date] NULL,
 CONSTRAINT [PK_ShoppingCarts] PRIMARY KEY CLUSTERED 
(
	[ID_ShoppingCart] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Motorcycles]  WITH CHECK ADD FOREIGN KEY([ID_Brand])
REFERENCES [dbo].[Brands] ([ID_Brand])
GO
ALTER TABLE [dbo].[ShoppingCarts]  WITH CHECK ADD  CONSTRAINT [FK_ShoppingCarts_ShoppingCarts] FOREIGN KEY([ID_ShoppingCart])
REFERENCES [dbo].[ShoppingCarts] ([ID_ShoppingCart])
GO
ALTER TABLE [dbo].[ShoppingCarts] CHECK CONSTRAINT [FK_ShoppingCarts_ShoppingCarts]
GO
/****** Object:  StoredProcedure [dbo].[create_customer]    Script Date: 27/11/2023 19:00:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[create_customer]
	@email as varchar(50),
	@password as varchar(50),
	@firstName as varchar(50),
	@lastName as varchar(50),
	@phone as varchar(50),
	@address as varchar(50),
	@nif as varchar(50),
	@activationStatus int output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	IF EXISTS (SELECT * FROM Customers WHERE @email = email)
	BEGIN
		SET @activationStatus = 0 --'Email already exists!'
	END
	ELSE
	BEGIN
		INSERT INTO Customers 
		VALUES (@email, @firstName, @lastName, @password, @address, @phone, 'false', @nif)

		SET @activationStatus = 1 --'Check your email to activate the account'
	END
END
GO
/****** Object:  StoredProcedure [dbo].[login_customer]    Script Date: 27/11/2023 19:00:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[login_customer]
	@email as varchar(50),
	@password as varchar(50),
	@return int output	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	if exists (select * from Customers where email = @email and password = @password and Active='true')
		begin
			set @return = 1; --Account is active			
		end
	else if exists (select * from Customers where email = @email and password = @password and Active='false')
		begin
			set @return = 2; 
		end
	else 
		begin
			set @return = 0 
		end
END
GO
USE [master]
GO
ALTER DATABASE [SpeedMaster] SET  READ_WRITE 
GO
