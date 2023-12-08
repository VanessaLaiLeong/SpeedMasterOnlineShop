USE [master]
GO
/****** Object:  Database [SpeedMaster]    Script Date: 08/12/2023 03:30:11 ******/
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
/****** Object:  Table [dbo].[Accessories]    Script Date: 08/12/2023 03:30:11 ******/
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
	[Image] [varbinary](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 08/12/2023 03:30:11 ******/
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
/****** Object:  Table [dbo].[CartItems]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartItems](
	[ID_CartItem] [int] IDENTITY(1,1) NOT NULL,
	[ID_ShoppingCart] [int] NULL,
	[ID_GlobalproductID] [int] NULL,
	[Quantity] [int] NULL,
	[Price] [decimal](18, 2) NULL,
 CONSTRAINT [PK_CartItems] PRIMARY KEY CLUSTERED 
(
	[ID_CartItem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 08/12/2023 03:30:11 ******/
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
/****** Object:  Table [dbo].[Customers]    Script Date: 08/12/2023 03:30:11 ******/
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
/****** Object:  Table [dbo].[GlobalProductIds]    Script Date: 08/12/2023 03:30:11 ******/
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
/****** Object:  Table [dbo].[Motorcycles]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Motorcycles](
	[ID_Motorcycle] [int] NOT NULL,
	[ID_Brand] [int] NULL,
	[Model] [varchar](50) NULL,
	[ManufactoringYear] [int] NULL,
	[EngineType] [varchar](20) NULL,
	[EngineCapacity] [int] NULL,
	[Color] [varchar](30) NULL,
	[Price] [decimal](10, 2) NULL,
	[Condition] [varchar](10) NULL,
	[Description] [varchar](max) NULL,
	[MotorcycleImage] [varbinary](max) NULL,
	[MotorcycleImageType] [varchar](50) NULL,
	[Active] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[ID_Order] [int] IDENTITY(1,1) NOT NULL,
	[ID_ShoppingCart] [int] NULL,
	[OrderDate] [date] NULL,
	[ShippingDate] [date] NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[ID_OrderStatus] [int] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[ID_Order] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderStatus]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderStatus](
	[ID_OrderStatus] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [varchar](50) NULL,
 CONSTRAINT [PK_OrderStatus2] PRIMARY KEY CLUSTERED 
(
	[ID_OrderStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reviews](
	[ID_Review] [int] IDENTITY(1,1) NOT NULL,
	[ID_ShoppingCart] [int] NULL,
	[ID_Product] [int] NULL,
	[Rating] [int] NULL,
	[Description] [varchar](max) NULL,
 CONSTRAINT [PK_Reviews] PRIMARY KEY CLUSTERED 
(
	[ID_Review] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleTypes]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleTypes](
	[ID_RoleType] [int] IDENTITY(1,1) NOT NULL,
	[RoleType] [int] NULL,
	[RoleName] [varchar](50) NULL,
 CONSTRAINT [PK_RoleTypes] PRIMARY KEY CLUSTERED 
(
	[ID_RoleType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShoppingCarts]    Script Date: 08/12/2023 03:30:11 ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID_User] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[ID_RoleType] [int] NULL,
	[Password] [varchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID_User] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_Accessories]    Script Date: 08/12/2023 03:30:11 ******/
CREATE NONCLUSTERED INDEX [IX_Accessories] ON [dbo].[Accessories]
(
	[ID_Accessory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Accessories]  WITH CHECK ADD  CONSTRAINT [FK_Accessories_Categories] FOREIGN KEY([ID_Category])
REFERENCES [dbo].[Categories] ([ID_Category])
GO
ALTER TABLE [dbo].[Accessories] CHECK CONSTRAINT [FK_Accessories_Categories]
GO
ALTER TABLE [dbo].[Accessories]  WITH CHECK ADD  CONSTRAINT [FK_Accessories_GlobalProductIds] FOREIGN KEY([ID_Accessory])
REFERENCES [dbo].[GlobalProductIds] ([ID_Product])
GO
ALTER TABLE [dbo].[Accessories] CHECK CONSTRAINT [FK_Accessories_GlobalProductIds]
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD  CONSTRAINT [FK_CartItems_GlobalProductIds] FOREIGN KEY([ID_GlobalproductID])
REFERENCES [dbo].[GlobalProductIds] ([ID_Product])
GO
ALTER TABLE [dbo].[CartItems] CHECK CONSTRAINT [FK_CartItems_GlobalProductIds]
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD  CONSTRAINT [FK_CartItems_ShoppingCarts] FOREIGN KEY([ID_ShoppingCart])
REFERENCES [dbo].[ShoppingCarts] ([ID_ShoppingCart])
GO
ALTER TABLE [dbo].[CartItems] CHECK CONSTRAINT [FK_CartItems_ShoppingCarts]
GO
ALTER TABLE [dbo].[Motorcycles]  WITH CHECK ADD FOREIGN KEY([ID_Brand])
REFERENCES [dbo].[Brands] ([ID_Brand])
GO
ALTER TABLE [dbo].[Motorcycles]  WITH CHECK ADD  CONSTRAINT [FK_Motorcycles_GlobalProductIds] FOREIGN KEY([ID_Motorcycle])
REFERENCES [dbo].[GlobalProductIds] ([ID_Product])
GO
ALTER TABLE [dbo].[Motorcycles] CHECK CONSTRAINT [FK_Motorcycles_GlobalProductIds]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_OrderStatus] FOREIGN KEY([ID_OrderStatus])
REFERENCES [dbo].[OrderStatus] ([ID_OrderStatus])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_OrderStatus]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_ShoppingCarts] FOREIGN KEY([ID_ShoppingCart])
REFERENCES [dbo].[ShoppingCarts] ([ID_ShoppingCart])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_ShoppingCarts]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_GlobalProductIds] FOREIGN KEY([ID_Product])
REFERENCES [dbo].[GlobalProductIds] ([ID_Product])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_GlobalProductIds]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_ShoppingCarts] FOREIGN KEY([ID_ShoppingCart])
REFERENCES [dbo].[ShoppingCarts] ([ID_ShoppingCart])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_ShoppingCarts]
GO
ALTER TABLE [dbo].[ShoppingCarts]  WITH CHECK ADD  CONSTRAINT [FK_ShoppingCarts_ShoppingCarts] FOREIGN KEY([ID_ShoppingCart])
REFERENCES [dbo].[ShoppingCarts] ([ID_ShoppingCart])
GO
ALTER TABLE [dbo].[ShoppingCarts] CHECK CONSTRAINT [FK_ShoppingCarts_ShoppingCarts]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_RoleTypes] FOREIGN KEY([ID_User])
REFERENCES [dbo].[RoleTypes] ([ID_RoleType])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_RoleTypes]
GO
/****** Object:  StoredProcedure [dbo].[activate_account]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[activate_account]
	@email as varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    update Customers set active = 'true' where email = @email
END
GO
/****** Object:  StoredProcedure [dbo].[add_to_cart]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[add_to_cart]
	@email varchar(50),
	@ID_product int
AS
BEGIN
	declare @ID_Customer int
    select @ID_Customer = ID_Customer from Customers where Email = @email 

	declare @shoppingCartID int
	select @shoppingCartID = ID_ShoppingCart from ShoppingCarts where ID_Customer = @ID_Customer

	declare @productType varchar(50)
	select @productType = ProductType from GlobalProductIds where ID_product = @ID_product

	if @productType = 'motorcycle'
	begin
		declare @productPrice decimal
		select @productPrice = Price from Motorcycles where ID_Motorcycle = @ID_product
		insert into CartItems values (@shoppingCartID, @ID_product, 1, @productPrice)
	end
	else if @productType = 'accessory'
	begin
		declare @productPrice2 decimal
		select @productPrice2 = Price from Accessories where ID_Accessory = @ID_product
		insert into CartItems values (@shoppingCartID, @ID_product, 1, @productPrice2)
	end	
END
GO
/****** Object:  StoredProcedure [dbo].[delete_accessory]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Delete (DELETE) Stored Procedure: delete_accessory
CREATE PROCEDURE [dbo].[delete_accessory]
    @ID_Accessory INT
AS
BEGIN
    DELETE FROM [SpeedMaster].[dbo].[Accessories]
    WHERE [ID_Accessory] = @ID_Accessory;
	delete from GlobalProductIds
	where ID_Product = @ID_Accessory
END;
GO
/****** Object:  StoredProcedure [dbo].[delete_brand]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[delete_brand]
    @ID_Brand INT
AS
BEGIN
    DELETE FROM [SpeedMaster].[dbo].[Brands]
    WHERE [ID_Brand] = @ID_Brand;
END;
GO
/****** Object:  StoredProcedure [dbo].[delete_category]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Delete (DELETE) Stored Procedure: delete_category
CREATE PROCEDURE [dbo].[delete_category]
    @ID_Category INT
AS
BEGIN
    DELETE FROM [SpeedMaster].[dbo].[Categories]
    WHERE [ID_Category] = @ID_Category;
END;
GO
/****** Object:  StoredProcedure [dbo].[delete_customer]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Delete (DELETE) Stored Procedure: delete_customer
CREATE PROCEDURE [dbo].[delete_customer]
    @ID_Customer INT
AS
BEGIN
    DELETE FROM [SpeedMaster].[dbo].[Customers]
    WHERE [ID_Customer] = @ID_Customer;
END;
GO
/****** Object:  StoredProcedure [dbo].[delete_global_product_id]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Delete (DELETE) Stored Procedure: delete_global_product_id
CREATE PROCEDURE [dbo].[delete_global_product_id]
    @ID_Product INT
AS
BEGIN
    DELETE FROM [SpeedMaster].[dbo].[GlobalProductIds]
    WHERE [ID_Product] = @ID_Product;
END;
GO
/****** Object:  StoredProcedure [dbo].[delete_motorcycle]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Delete (DELETE) Stored Procedure: delete_motorcycle
CREATE PROCEDURE [dbo].[delete_motorcycle]
    @ID_Motorcycle INT
AS
BEGIN
    DELETE FROM [SpeedMaster].[dbo].[Motorcycles]
    WHERE [ID_Motorcycle] = @ID_Motorcycle;
	delete from GlobalProductIds
	where ID_Product = @ID_Motorcycle
END;
GO
/****** Object:  StoredProcedure [dbo].[delete_order]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE PROCEDURE [dbo].[delete_order]
    @ID_Order int
AS
BEGIN
    DELETE FROM Orders WHERE ID_Order = @ID_Order;
END;
GO
/****** Object:  StoredProcedure [dbo].[delete_review]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[delete_review]
    @ID_Review INT
AS
BEGIN
    DELETE FROM Reviews WHERE ID_Review = @ID_Review;
END;
GO
/****** Object:  StoredProcedure [dbo].[delete_role_type]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Delete (DELETE) Stored Procedure: delete_role_type
CREATE PROCEDURE [dbo].[delete_role_type]
    @ID_RoleType INT
AS
BEGIN
    DELETE FROM [SpeedMaster].[dbo].[RoleTypes]
    WHERE
        [ID_RoleType] = @ID_RoleType;
END;
GO
/****** Object:  StoredProcedure [dbo].[delete_shopping_cart]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Delete (DELETE) Stored Procedure: delete_shopping_cart
CREATE PROCEDURE [dbo].[delete_shopping_cart]
    @ID_ShoppingCart INT
AS
BEGIN
    DELETE FROM [SpeedMaster].[dbo].[ShoppingCarts]
    WHERE
        [ID_ShoppingCart] = @ID_ShoppingCart;
END;
GO
/****** Object:  StoredProcedure [dbo].[delete_user]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Delete (DELETE) Stored Procedure: delete_user
CREATE PROCEDURE [dbo].[delete_user]
    @ID_User INT
AS
BEGIN
    DELETE FROM [SpeedMaster].[dbo].[Users]
    WHERE
        [ID_User] = @ID_User;
END;
GO
/****** Object:  StoredProcedure [dbo].[get_productDetails]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[get_productDetails]
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @type varchar(50)
	select @type = ProductType from GlobalProductIds where ID_Product = @id

	if @type = 'motorcycle'
	begin
		select * from Motorcycles where ID_Motorcycle = @id
	end
	else if @type = 'accessory'
	begin
		select * from Accessories where ID_Accessory = @id
	end

END
GO
/****** Object:  StoredProcedure [dbo].[get_shoppingCart_items]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[get_shoppingCart_items] 
	@email varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @cartId int
	declare @itemTable table (productId int, price dec(18,2), quantity int,name varchar(50),image varbinary(MAX))
	declare @totalPrice decimal(18,2)
	declare @totalItems int

	select  @cartId = sc.ID_ShoppingCart from Customers as c
	inner join ShoppingCarts sc on sc.ID_Customer = c.ID_Customer
	where c.Email = @email	

	insert into @itemTable (productId,price,quantity,name,image) 
		(select m.ID_Motorcycle, 
				m.Price, 
				count(1),
				CONCAT(m.ManufactoringYear,' ',b.BrandName,' ', m.Model),
				m.MotorcycleImage
		from CartItems			as ci
		inner join Motorcycles	as m	on m.ID_Motorcycle = ci.ID_GlobalproductID 
		inner join Brands		as b	on b.ID_Brand = m.ID_Brand
		where ci.ID_ShoppingCart = @cartId
		group by m.ID_Motorcycle, m.Price,m.Model,m.MotorcycleImage,b.BrandName,m.ManufactoringYear)


		insert into @itemTable (productId,price,quantity,name,image) 
		(select a.ID_Accessory, 
				a.Price, 
				count(1),
				a.AccessoryName,
				a.Image
		from CartItems			as ci
		inner join Accessories	as a	on a.ID_Accessory = ci.ID_GlobalproductID 
		where ci.ID_ShoppingCart = @cartId
		group by a.ID_Accessory, a.Price,a.Image,a.AccessoryName)
	

	SELECT @totalPrice = SUM(CAST((it.price * it.quantity) AS DECIMAL(18, 2)))
	FROM @itemTable it
	INNER JOIN GlobalProductIds gp ON gp.ID_Product = it.productId;

	select @totalItems = count(ci.ID_GlobalproductID)
	from CartItems as ci
	where ci.ID_ShoppingCart = @cartId

	select it.quantity, it.price, it.image, it.name, it.productId, 
	@totalItems as 'totalItems',  CAST((it.price * it.quantity) AS 
	DEC(18, 2)) as 'ItemTotalPrice', @totalPrice as 'totalPrice' from @itemTable it

END
GO
/****** Object:  StoredProcedure [dbo].[insert_accessory]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insert_accessory]
    @ID_Accessory varchar(50),
    @AccessoryName varchar(50),
    @Description varchar(50),
    @Price decimal,
    @Stock int,
    @Active bit,
    @ID_Category int,
	@Image varbinary(max)
AS
BEGIN
    SET NOCOUNT ON;

    -- Insert statements for procedure here
    INSERT INTO Accessories (
        ID_Accessory, AccessoryName, Description, Price, Stock, Active, ID_Category, Image
    )
    VALUES (
        @ID_Accessory, @AccessoryName, @Description, @Price, @Stock, @Active, @ID_Category, @Image
    );
END
GO
/****** Object:  StoredProcedure [dbo].[insert_brand]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insert_brand]
    @BrandName VARCHAR(MAX),
    @CountryOfOrigin VARCHAR(MAX)
AS
BEGIN
    INSERT INTO [SpeedMaster].[dbo].[Brands] ([BrandName], [CountryOfOrigin])
    VALUES (@BrandName, @CountryOfOrigin);
END;
GO
/****** Object:  StoredProcedure [dbo].[insert_category]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Create (INSERT) Stored Procedure: insert_category
CREATE PROCEDURE [dbo].[insert_category]
    @CategoryName VARCHAR(50)
AS
BEGIN
    INSERT INTO [SpeedMaster].[dbo].[Categories] (
        [CategoryName]
    )
    VALUES (
        @CategoryName
    );
END;
GO
/****** Object:  StoredProcedure [dbo].[insert_customer]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[insert_customer]
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
/****** Object:  StoredProcedure [dbo].[insert_global_product]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[insert_global_product]
	@type varchar(50),
    @insertedId INT OUTPUT
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    INSERT INTO GlobalProductIds (ProductType)
    VALUES (@type);

    -- Get the last inserted ID and return it through the output parameter
    SET @insertedId = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[insert_global_product_id]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Create (INSERT) Stored Procedure: insert_global_product_id
CREATE PROCEDURE [dbo].[insert_global_product_id]
    @ProductType VARCHAR(MAX)
AS
BEGIN
    INSERT INTO [SpeedMaster].[dbo].[GlobalProductIds] (
        [ProductType]
    )
    VALUES (
        @ProductType
    );
END;
GO
/****** Object:  StoredProcedure [dbo].[insert_motorcycle]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[insert_motorcycle]
	@ID_Motorcycle as int,
	@ID_Brand as varchar(50),
	@Model as varchar(50),
	@ManufactoringYear as int,
	@EngineType as varchar(50),
	@EngineCapacity as int,
	@Color as varchar(50),
	@Price as decimal(10,2),
	@Condition as varchar(50),
	@Description as varchar(50),
	@MotorcycleImageType as varchar(50),
	@MotorcycleImage as varbinary(MAX),
	@Active as bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into Motorcycles values (
	@ID_Motorcycle,
	@ID_Brand,
	@Model,
	@ManufactoringYear,
	@EngineType,
	@EngineCapacity,
	@Color,
	@Price,
	@Condition,
	@Description,
	@MotorcycleImage,
	@MotorcycleImageType,	
	@Active
	)
END
GO
/****** Object:  StoredProcedure [dbo].[insert_order]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE PROCEDURE [dbo].[insert_order]
	@ID_ShoppingCart int,
    @OrderDate date,
    @ShippingDate date,
    @TotalAmount decimal,
    @ID_Status int
AS
BEGIN
    INSERT INTO Orders (ID_ShoppingCart,OrderDate, ShippingDate, TotalAmount, ID_OrderStatus)
    VALUES (@ID_ShoppingCart, @OrderDate, @ShippingDate, @TotalAmount, @ID_Status);
END;
GO
/****** Object:  StoredProcedure [dbo].[insert_order_status]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE PROCEDURE [dbo].[insert_order_status]
    @StatusName varchar(255)
AS
BEGIN
    INSERT INTO OrderStatus (StatusName)
    VALUES (@StatusName);
END;
GO
/****** Object:  StoredProcedure [dbo].[insert_product]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[insert_product] 
	@type as varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	insert into GlobalProductIds values (@type)
END
GO
/****** Object:  StoredProcedure [dbo].[insert_review]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE PROCEDURE [dbo].[insert_review]
    @ID_ShoppingCart INT,
    @ID_Product INT,
    @Rating INT,
    @Description VARCHAR(MAX)
AS
BEGIN
    INSERT INTO Reviews (ID_ShoppingCart, ID_Product, Rating, Description)
    VALUES (@ID_ShoppingCart, @ID_Product, @Rating, @Description);
END;
GO
/****** Object:  StoredProcedure [dbo].[insert_role_type]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Create (INSERT) Stored Procedure: insert_role_type
CREATE PROCEDURE [dbo].[insert_role_type]
    @RoleType INT,
    @RoleName VARCHAR(MAX)
AS
BEGIN
    INSERT INTO [SpeedMaster].[dbo].[RoleTypes] (
        [RoleType], [RoleName]
    )
    VALUES (
        @RoleType, @RoleName
    );
END;
GO
/****** Object:  StoredProcedure [dbo].[insert_shopping_cart]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[insert_shopping_cart]
	@email as varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @customerID int

	select @customerID = ID_Customer from Customers where email = @email 
	insert into ShoppingCarts values (@customerID, 'true', GETDATE())
END
GO
/****** Object:  StoredProcedure [dbo].[insert_shopping_cart_manager]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Create (INSERT) Stored Procedure: insert_shopping_cart
create PROCEDURE [dbo].[insert_shopping_cart_manager]
    @ID_Customer INT,
    @CartStatus VARCHAR(MAX),
    @CreatedDate DATETIME
AS
BEGIN
    INSERT INTO [SpeedMaster].[dbo].[ShoppingCarts] (
        [ID_Customer], [CartStatus], [CreatedDate]
    )
    VALUES (
        @ID_Customer, @CartStatus, @CreatedDate
    );
END;
GO
/****** Object:  StoredProcedure [dbo].[insert_user]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Create (INSERT) Stored Procedure: insert_user
CREATE PROCEDURE [dbo].[insert_user]
    @UserName VARCHAR(MAX),
    @ID_RoleType INT,
    @Password VARCHAR(MAX)
AS
BEGIN
    INSERT INTO [SpeedMaster].[dbo].[Users] (
        [UserName], [ID_RoleType], [Password]
    )
    VALUES (
        @UserName, @ID_RoleType, @Password
    );
END;
GO
/****** Object:  StoredProcedure [dbo].[login_customer]    Script Date: 08/12/2023 03:30:11 ******/
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
	declare @id int
	-- Insert statements for procedure here
	if exists (select * from Customers where email = @email and password = @password and Active='true')
		begin
			set @id = (select ID_customer from Customers where email = @email and password = @password)
			set @return = @id			
		end
	else if exists (select * from Customers where email = @email and password = @password and Active='false')
		begin
			set @return = -1; 
		end
	else 
		begin
			set @return = 0 
		end
END
GO
/****** Object:  StoredProcedure [dbo].[login_user]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[login_user]
	@userName as varchar(50),
	@password as varchar(50),
	@return int output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if exists (select * from UserName where userName = @userName and password = @password)
		begin			
			set @return = 1			
		end
	else 
		begin
			set @return = 0; 
		end
END
GO
/****** Object:  StoredProcedure [dbo].[reset_password]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[reset_password] 
	@email as varchar(50),
	@password as varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    update Customers set Password = @password where email = @email
END
GO
/****** Object:  StoredProcedure [dbo].[update_accessory]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[update_accessory]
    @ID_Accessory INT,
    @AccessoryName VARCHAR(MAX),
    @Description VARCHAR(MAX),
    @Price DECIMAL(18, 2),
    @Stock INT,
    @Active BIT,
    @ID_Category INT,
	@Image varbinary(max)
AS
BEGIN
    UPDATE [SpeedMaster].[dbo].[Accessories]
    SET
        [AccessoryName] = @AccessoryName,
        [Description] = @Description,
        [Price] = @Price,
        [Stock] = @Stock,
        [Active] = @Active,
        [ID_Category] = @ID_Category,
		[Image] = @Image
    WHERE [ID_Accessory] = @ID_Accessory;
END;
GO
/****** Object:  StoredProcedure [dbo].[update_brand]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[update_brand]
    @ID_Brand INT,
    @BrandName VARCHAR(MAX),
    @CountryOfOrigin VARCHAR(MAX)
AS
BEGIN
    UPDATE [SpeedMaster].[dbo].[Brands]
    SET [BrandName] = @BrandName, [CountryOfOrigin] = @CountryOfOrigin
    WHERE [ID_Brand] = @ID_Brand;
END;
GO
/****** Object:  StoredProcedure [dbo].[update_category]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Update (UPDATE) Stored Procedure: update_category
CREATE PROCEDURE [dbo].[update_category]
    @ID_Category INT,
    @CategoryName VARCHAR(MAX)
AS
BEGIN
    UPDATE [SpeedMaster].[dbo].[Categories]
    SET
        [CategoryName] = @CategoryName
    WHERE [ID_Category] = @ID_Category;
END;
GO
/****** Object:  StoredProcedure [dbo].[update_customer]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[update_customer]
    @ID_Customer INT,
    @Email VARCHAR(MAX),
    @FirstName VARCHAR(MAX),
    @LastName VARCHAR(MAX),
    @Password VARCHAR(MAX),
    @Address VARCHAR(MAX),
    @Phone VARCHAR(MAX),
    @Active BIT,
    @NIF VARCHAR(20)
AS
BEGIN
    -- Check if the new email is unique
    IF NOT EXISTS (SELECT 1 FROM [SpeedMaster].[dbo].[Customers] WHERE [Email] = @Email AND [ID_Customer] <> @ID_Customer)
    BEGIN
        UPDATE [SpeedMaster].[dbo].[Customers]
        SET
            [Email] = @Email,
            [FirstName] = @FirstName,
            [LastName] = @LastName,
            [Password] = @Password,
            [Address] = @Address,
            [Phone] = @Phone,
            [Active] = @Active,
            [NIF] = @NIF
        WHERE [ID_Customer] = @ID_Customer;
    END
    ELSE
    BEGIN
        -- Email is not unique, return an error (you can customize the error message)
        THROW 50001, 'Email already exists', 1;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[update_global_product_id]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Update (UPDATE) Stored Procedure: update_global_product_id
CREATE PROCEDURE [dbo].[update_global_product_id]
    @ID_Product INT,
    @ProductType VARCHAR(MAX)
AS
BEGIN
    UPDATE [SpeedMaster].[dbo].[GlobalProductIds]
    SET
        [ProductType] = @ProductType
    WHERE [ID_Product] = @ID_Product;
END;
GO
/****** Object:  StoredProcedure [dbo].[update_motorcycle]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Update (UPDATE) Stored Procedure: update_motorcycle
CREATE PROCEDURE [dbo].[update_motorcycle]
    @ID_Motorcycle INT,
    @ID_Brand INT,
    @Model VARCHAR(MAX),
    @ManufactoringYear int,
    @EngineType VARCHAR(MAX),
    @EngineCapacity int,
    @Color VARCHAR(MAX),
    @Price DECIMAL(18, 2),
    @Condition VARCHAR(MAX),
    @Description VARCHAR(MAX),
    @MotorcycleImage VARBINARY(MAX),
    @MotorcycleImageType VARCHAR(MAX),
    @Active BIT
AS
BEGIN
    UPDATE [SpeedMaster].[dbo].[Motorcycles]
    SET
        [ID_Brand] = @ID_Brand,
        [Model] = @Model,
        [ManufactoringYear] = @ManufactoringYear,
        [EngineType] = @EngineType,
        [EngineCapacity] = @EngineCapacity,
        [Color] = @Color,
        [Price] = @Price,
        [Condition] = @Condition,
        [Description] = @Description,
        [MotorcycleImage] = @MotorcycleImage,
        [MotorcycleImageType] = @MotorcycleImageType,
        [Active] = @Active
    WHERE [ID_Motorcycle] = @ID_Motorcycle;
END;
GO
/****** Object:  StoredProcedure [dbo].[update_order]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Update an existing order
  CREATE PROCEDURE [dbo].[update_order]
    @ID_Order int,
	@ID_ShoppingCart int,
    @OrderDate date,
    @ShippingDate date,
    @TotalAmount decimal,
    @ID_Status int
AS
BEGIN
    UPDATE Orders
    SET
		ID_ShoppingCart = @ID_ShoppingCart,
        OrderDate = @OrderDate,
        ShippingDate = @ShippingDate,
        TotalAmount = @TotalAmount,
        ID_OrderStatus = @ID_Status
    WHERE
        ID_Order = @ID_Order;
END;
GO
/****** Object:  StoredProcedure [dbo].[update_order_status]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[update_order_status]
    @ID_OrderStatus int,
    @StatusName varchar(255)
AS
BEGIN
    UPDATE OrderStatus
    SET StatusName = @StatusName
    WHERE ID_OrderStatus = @ID_OrderStatus;
END;
GO
/****** Object:  StoredProcedure [dbo].[update_review]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[update_review]
    @ID_Review INT,
    @ID_ShoppingCart INT,
    @ID_Product INT,
    @Rating INT,
    @Description VARCHAR(MAX)
AS
BEGIN
    UPDATE Reviews
    SET
        ID_ShoppingCart = @ID_ShoppingCart,
        ID_Product = @ID_Product,
        Rating = @Rating,
        Description = @Description
    WHERE ID_Review = @ID_Review;
END;
GO
/****** Object:  StoredProcedure [dbo].[update_role_type]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Update (UPDATE) Stored Procedure: update_role_type
CREATE PROCEDURE [dbo].[update_role_type]
    @ID_RoleType INT,
    @RoleType INT,
    @RoleName VARCHAR(MAX)
AS
BEGIN
    UPDATE [SpeedMaster].[dbo].[RoleTypes]
    SET
        [RoleType] = @RoleType,
        [RoleName] = @RoleName
    WHERE
        [ID_RoleType] = @ID_RoleType;
END;
GO
/****** Object:  StoredProcedure [dbo].[update_shopping_cart]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[update_shopping_cart]
    @ID_ShoppingCart INT,
    @ID_Customer INT,
    @CartStatus VARCHAR(MAX),
    @CreatedDate DATETIME
AS
BEGIN
    UPDATE ShoppingCarts
    SET
        ID_Customer = @ID_Customer,
        CartStatus = @CartStatus,
        CreatedDate = @CreatedDate
    WHERE ID_ShoppingCart = @ID_ShoppingCart;
END;
GO
/****** Object:  StoredProcedure [dbo].[update_user]    Script Date: 08/12/2023 03:30:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Update (UPDATE) Stored Procedure: update_user
CREATE PROCEDURE [dbo].[update_user]
    @ID_User INT,
    @UserName VARCHAR(MAX),
    @ID_RoleType INT,
    @Password VARCHAR(MAX)
AS
BEGIN
    UPDATE [SpeedMaster].[dbo].[Users]
    SET
        [UserName] = @UserName,
        [ID_RoleType] = @ID_RoleType,
        [Password] = @Password
    WHERE
        [ID_User] = @ID_User;
END;
GO
USE [master]
GO
ALTER DATABASE [SpeedMaster] SET  READ_WRITE 
GO
