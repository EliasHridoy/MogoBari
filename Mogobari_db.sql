USE [master]
GO
/****** Object:  Database [Mogobari_db]    Script Date: 11/28/2020 9:29:47 PM ******/
CREATE DATABASE [Mogobari_db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Mogobari_db', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Mogobari_db.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Mogobari_db_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Mogobari_db_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Mogobari_db] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Mogobari_db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Mogobari_db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Mogobari_db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Mogobari_db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Mogobari_db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Mogobari_db] SET ARITHABORT OFF 
GO
ALTER DATABASE [Mogobari_db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Mogobari_db] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Mogobari_db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Mogobari_db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Mogobari_db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Mogobari_db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Mogobari_db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Mogobari_db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Mogobari_db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Mogobari_db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Mogobari_db] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Mogobari_db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Mogobari_db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Mogobari_db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Mogobari_db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Mogobari_db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Mogobari_db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Mogobari_db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Mogobari_db] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Mogobari_db] SET  MULTI_USER 
GO
ALTER DATABASE [Mogobari_db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Mogobari_db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Mogobari_db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Mogobari_db] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Mogobari_db]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 11/28/2020 9:29:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Address](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](50) NOT NULL,
	[Company] [varchar](50) NULL,
	[Country] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[PostalCode] [varchar](50) NULL,
	[PhoneNumber] [nvarchar](50) NOT NULL,
	[CreateOnUtc] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_AddressF] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Category]    Script Date: 11/28/2020 9:29:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[PriceRanges] [nvarchar](400) NULL,
	[Description] [nvarchar](max) NULL,
	[ParentCategoryId] [int] NULL,
	[PictureId] [int] NULL,
	[ShowOnHomepage] [bit] NULL,
	[IncludeInTopMenu] [bit] NULL,
	[LimitedToStores] [bit] NULL,
	[Published] [bit] NULL,
	[Deleted] [bit] NULL,
	[DisplayOrder] [int] NULL,
	[CreatedOnUtc] [datetime2](7) NOT NULL,
	[UpdatedOnUtc] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 11/28/2020 9:29:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[MobileNumber] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](1000) NULL,
	[EmailToRevalidate] [nvarchar](1000) NULL,
	[SystemName] [nvarchar](50) NULL,
	[BillingAddress_Id] [int] NULL,
	[PhotoPath] [varchar](50) NULL,
	[Address_Id] [int] NULL,
	[ShippingAddress_Id] [int] NULL,
	[HasShoppingCartItems] [bit] NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[IsSystemAccount] [bit] NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[LastLogin] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CustomerPassword]    Script Date: 11/28/2020 9:29:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerPassword](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Password] [nvarchar](max) NULL,
	[PasswordFormatId] [int] NULL,
	[PasswordSalt] [nvarchar](max) NULL,
	[CreatedOnUtc] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_CustomerPassword] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CustomerRole]    Script Date: 11/28/2020 9:29:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[SystemName] [nvarchar](255) NULL,
	[FreeShipping] [bit] NOT NULL,
	[Active] [bit] NOT NULL,
	[IsSystemRole] [bit] NOT NULL,
 CONSTRAINT [PK_CustomerRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DeliveryDate]    Script Date: 11/28/2020 9:29:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeliveryDate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_DeliveryDate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order]    Script Date: 11/28/2020 9:29:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomOrderNumber] [nvarchar](max) NULL,
	[BillingAddressId] [int] NULL,
	[CustomerId] [int] NOT NULL,
	[PickupAddressId] [int] NULL,
	[ShippingAddressId] [int] NULL,
	[OrderGuid] [uniqueidentifier] NULL,
	[StoreId] [int] NULL,
	[PickupInStore] [bit] NULL,
	[OrderStatusId] [int] NULL,
	[ShippingStatusId] [int] NULL,
	[PaymentStatusId] [int] NULL,
	[PaymentMethodSystemName] [nvarchar](max) NULL,
	[CustomerCurrencyCode] [nvarchar](max) NULL,
	[CurrencyRate] [decimal](18, 4) NULL,
	[CustomerTaxDisplayTypeId] [int] NULL,
	[VatNumber] [nvarchar](max) NULL,
	[OrderSubtotalInclTax] [decimal](18, 4) NULL,
	[OrderSubtotalExclTax] [decimal](18, 4) NULL,
	[OrderSubTotalDiscountInclTax] [decimal](18, 4) NULL,
	[OrderSubTotalDiscountExclTax] [decimal](18, 4) NULL,
	[OrderShippingInclTax] [decimal](18, 4) NULL,
	[OrderShippingExclTax] [decimal](18, 4) NULL,
	[PaymentMethodAdditionalFeeInclTax] [decimal](18, 4) NULL,
	[PaymentMethodAdditionalFeeExclTax] [decimal](18, 4) NULL,
	[TaxRates] [nvarchar](max) NULL,
	[OrderTax] [decimal](18, 4) NULL,
	[OrderDiscount] [decimal](18, 4) NULL,
	[OrderTotal] [decimal](18, 4) NOT NULL,
	[RefundedAmount] [decimal](18, 4) NULL,
	[RewardPointsHistoryEntryId] [int] NULL,
	[CheckoutAttributeDescription] [nvarchar](max) NULL,
	[CheckoutAttributesXml] [nvarchar](max) NULL,
	[CustomerLanguageId] [int] NULL,
	[AffiliateId] [int] NULL,
	[CustomerIp] [nvarchar](max) NULL,
	[AllowStoringCreditCardNumber] [bit] NULL,
	[CardType] [nvarchar](max) NULL,
	[CardName] [nvarchar](max) NULL,
	[CardNumber] [nvarchar](max) NULL,
	[MaskedCreditCardNumber] [nvarchar](max) NULL,
	[CardCvv2] [nvarchar](max) NULL,
	[CardExpirationMonth] [nvarchar](max) NULL,
	[CardExpirationYear] [nvarchar](max) NULL,
	[AuthorizationTransactionId] [nvarchar](max) NULL,
	[AuthorizationTransactionCode] [nvarchar](max) NULL,
	[AuthorizationTransactionResult] [nvarchar](max) NULL,
	[CaptureTransactionId] [nvarchar](max) NULL,
	[CaptureTransactionResult] [nvarchar](max) NULL,
	[SubscriptionTransactionId] [nvarchar](max) NULL,
	[PaidDateUtc] [datetime2](7) NULL,
	[ShippingMethod] [nvarchar](max) NULL,
	[ShippingRateComputationMethodSystemName] [nvarchar](max) NULL,
	[CustomValuesXml] [nvarchar](max) NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedOnUtc] [datetime2](7) NOT NULL,
	[RedeemedRewardPointsEntryId] [int] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderItem]    Script Date: 11/28/2020 9:29:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[OrderItemGuid] [uniqueidentifier] NULL,
	[Quantity] [int] NOT NULL,
	[UnitPriceInclTax] [decimal](18, 4) NULL,
	[UnitPriceExclTax] [decimal](18, 4) NULL,
	[PriceInclTax] [decimal](18, 4) NULL,
	[PriceExclTax] [decimal](18, 4) NULL,
	[DiscountAmountInclTax] [decimal](18, 4) NULL,
	[DiscountAmountExclTax] [decimal](18, 4) NULL,
	[OriginalProductCost] [decimal](18, 4) NULL,
	[AttributeDescription] [nvarchar](max) NULL,
	[AttributesXml] [nvarchar](max) NULL,
	[DownloadCount] [int] NULL,
	[IsDownloadActivated] [bit] NULL,
	[LicenseDownloadId] [int] NULL,
	[ItemWeight] [decimal](18, 4) NULL,
	[RentalStartDateUtc] [datetime2](7) NULL,
	[RentalEndDateUtc] [datetime2](7) NULL,
 CONSTRAINT [PK_OrderItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Picture]    Script Date: 11/28/2020 9:29:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Picture](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Filename] [nvarchar](300) NULL,
	[AltAttribute] [nvarchar](max) NULL,
	[TitleAttribute] [nvarchar](max) NULL,
	[VirtualPath] [nvarchar](max) NULL,
 CONSTRAINT [PK_Picture] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 11/28/2020 9:29:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[ManufacturerPartNumber] [nvarchar](400) NULL,
	[AllowedQuantities] [nvarchar](1000) NULL,
	[CategoryId] [int] NOT NULL,
	[ShortDescription] [nvarchar](max) NULL,
	[FullDescription] [nvarchar](max) NULL,
	[VendorId] [int] NOT NULL,
	[ShowOnHomepage] [bit] NULL,
	[AllowCustomerReviews] [bit] NULL,
	[IsGiftCard] [bit] NULL,
	[GiftCardTypeId] [int] NULL,
	[HasUserAgreement] [bit] NULL,
	[IsShipEnabled] [bit] NULL,
	[IsFreeShipping] [bit] NULL,
	[ShipSeparately] [bit] NULL,
	[AdditionalShippingCharge] [decimal](18, 4) NULL,
	[DeliveryDateId] [int] NULL,
	[IsTaxExempt] [bit] NULL,
	[TaxCategoryId] [int] NULL,
	[IsTelecommunicationsOrBroadcastingOrElectronicServices] [bit] NULL,
	[ProductAvailabilityRangeId] [int] NULL,
	[StockQuantity] [int] NULL,
	[DisplayStockAvailability] [bit] NULL,
	[DisplayStockQuantity] [bit] NULL,
	[MinStockQuantity] [int] NULL,
	[LowStockActivityId] [int] NULL,
	[NotifyAdminForQuantityBelow] [int] NULL,
	[BackorderModeId] [int] NULL,
	[OrderMinimumQuantity] [int] NULL,
	[OrderMaximumQuantity] [int] NULL,
	[NotReturnable] [bit] NULL,
	[DisableBuyButton] [bit] NULL,
	[DisableWishlistButton] [bit] NULL,
	[AvailableForPreOrder] [bit] NULL,
	[PreOrderAvailabilityStartDateTimeUtc] [datetime2](7) NULL,
	[Price] [decimal](18, 4) NULL,
	[OldPrice] [decimal](18, 4) NULL,
	[CustomerEntersPrice] [bit] NULL,
	[MinimumCustomerEnteredPrice] [decimal](18, 4) NULL,
	[MaximumCustomerEnteredPrice] [decimal](18, 4) NULL,
	[BasepriceEnabled] [bit] NULL,
	[BasepriceAmount] [decimal](18, 4) NULL,
	[BasepriceUnitId] [int] NULL,
	[BasepriceBaseAmount] [decimal](18, 4) NULL,
	[BasepriceBaseUnitId] [int] NULL,
	[MarkAsNew] [bit] NULL,
	[MarkAsNewStartDateTimeUtc] [datetime2](7) NULL,
	[MarkAsNewEndDateTimeUtc] [datetime2](7) NULL,
	[HasTierPrices] [bit] NULL,
	[HasDiscountsApplied] [bit] NULL,
	[Weight] [decimal](18, 4) NULL,
	[Length] [decimal](18, 4) NULL,
	[Width] [decimal](18, 4) NULL,
	[Height] [decimal](18, 4) NULL,
	[AvailableStartDateTimeUtc] [datetime2](7) NULL,
	[AvailableEndDateTimeUtc] [datetime2](7) NULL,
	[DisplayOrder] [int] NULL,
	[Published] [bit] NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedOnUtc] [datetime2](7) NOT NULL,
	[UpdatedOnUtc] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product_Picture_Mapping]    Script Date: 11/28/2020 9:29:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Picture_Mapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PictureId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_Product_Picture_Mapping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Store]    Script Date: 11/28/2020 9:29:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Store](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[VendorId] [int] NULL,
	[CompanyName] [nvarchar](1000) NULL,
	[AddressId] [int] NULL,
	[CompanyPhoneNumber] [nvarchar](1000) NULL,
	[CompanyVat] [nvarchar](1000) NULL,
	[SslEnabled] [bit] NULL,
	[DisplayOrder] [int] NULL,
	[Active] [bit] NOT NULL,
	[CreatedUtc] [datetime2](7) NULL,
 CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Vendor]    Script Date: 11/28/2020 9:29:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Vendor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[Email] [nvarchar](400) NOT NULL,
	[MetaKeywords] [nvarchar](400) NULL,
	[MetaTitle] [nvarchar](400) NULL,
	[Description] [nvarchar](max) NULL,
	[PictureId] [int] NULL,
	[AddressId] [int] NULL,
	[AdminComment] [nvarchar](max) NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[MetaDescription] [nvarchar](max) NULL,
	[MobileNumber] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Vendor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Address] ON 

INSERT [dbo].[Address] ([Id], [FirstName], [LastName], [Email], [Company], [Country], [City], [Address], [PostalCode], [PhoneNumber], [CreateOnUtc]) VALUES (1, N'test change', N'asd', N'ad', N'ad', N'ad', N'ad', N'address changed', N'1815529563', N'158764', CAST(0x070000000000B1410B AS DateTime2))
INSERT [dbo].[Address] ([Id], [FirstName], [LastName], [Email], [Company], [Country], [City], [Address], [PostalCode], [PhoneNumber], [CreateOnUtc]) VALUES (6, N'ade', N'kiik', N'kdfdjfkf', NULL, NULL, NULL, NULL, N'258', N'22258', CAST(0x070000000000C0410B AS DateTime2))
INSERT [dbo].[Address] ([Id], [FirstName], [LastName], [Email], [Company], [Country], [City], [Address], [PostalCode], [PhoneNumber], [CreateOnUtc]) VALUES (9, N'First name', N'last name', N'email.com', NULL, NULL, NULL, NULL, NULL, N'0111111111', CAST(0x07AA9C5D854DC1410B AS DateTime2))
INSERT [dbo].[Address] ([Id], [FirstName], [LastName], [Email], [Company], [Country], [City], [Address], [PostalCode], [PhoneNumber], [CreateOnUtc]) VALUES (15, NULL, NULL, N'adsfasf', NULL, NULL, NULL, NULL, NULL, N'56465646', CAST(0x07C1AF404050C1410B AS DateTime2))
INSERT [dbo].[Address] ([Id], [FirstName], [LastName], [Email], [Company], [Country], [City], [Address], [PostalCode], [PhoneNumber], [CreateOnUtc]) VALUES (19, N'test', N'last name updated', N'hotmail.com', N'ad', N'ad', N'ad', N'adfaafada', N'335544', N'1815222529563', CAST(0x070000000000C1410B AS DateTime2))
SET IDENTITY_INSERT [dbo].[Address] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name], [PriceRanges], [Description], [ParentCategoryId], [PictureId], [ShowOnHomepage], [IncludeInTopMenu], [LimitedToStores], [Published], [Deleted], [DisplayOrder], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (1, N'Electronics', NULL, NULL, 0, NULL, 1, 1, 0, 1, 0, 1, CAST(0x070000000000C4410B AS DateTime2), CAST(0x070000000000C4410B AS DateTime2))
INSERT [dbo].[Category] ([Id], [Name], [PriceRanges], [Description], [ParentCategoryId], [PictureId], [ShowOnHomepage], [IncludeInTopMenu], [LimitedToStores], [Published], [Deleted], [DisplayOrder], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (2, N'Mobile', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x070000000000C4410B AS DateTime2), CAST(0x070000000000C5410B AS DateTime2))
INSERT [dbo].[Category] ([Id], [Name], [PriceRanges], [Description], [ParentCategoryId], [PictureId], [ShowOnHomepage], [IncludeInTopMenu], [LimitedToStores], [Published], [Deleted], [DisplayOrder], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (3, N'Laptop', NULL, NULL, 1, NULL, NULL, NULL, NULL, 1, 0, 1, CAST(0x070000000000C1410B AS DateTime2), CAST(0x070000000000C1410B AS DateTime2))
INSERT [dbo].[Category] ([Id], [Name], [PriceRanges], [Description], [ParentCategoryId], [PictureId], [ShowOnHomepage], [IncludeInTopMenu], [LimitedToStores], [Published], [Deleted], [DisplayOrder], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (6, N'Books', NULL, NULL, 0, NULL, NULL, NULL, NULL, 1, 0, NULL, CAST(0x070000000000C1410B AS DateTime2), CAST(0x070000000000C1410B AS DateTime2))
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [UserName], [MobileNumber], [Email], [EmailToRevalidate], [SystemName], [BillingAddress_Id], [PhotoPath], [Address_Id], [ShippingAddress_Id], [HasShoppingCartItems], [Active], [Deleted], [IsSystemAccount], [CreatedOn], [LastLogin]) VALUES (0, N'test1', N'1815529563', N'test1@mail.com', NULL, N'test', NULL, NULL, 1, NULL, NULL, 1, 0, 0, CAST(0x070000000000B1410B AS DateTime2), CAST(0x070000000000B1410B AS DateTime2))
INSERT [dbo].[Customer] ([Id], [UserName], [MobileNumber], [Email], [EmailToRevalidate], [SystemName], [BillingAddress_Id], [PhotoPath], [Address_Id], [ShippingAddress_Id], [HasShoppingCartItems], [Active], [Deleted], [IsSystemAccount], [CreatedOn], [LastLogin]) VALUES (1, N'test', N'1815529583', N'test@mail.com', NULL, N'test', NULL, NULL, 15, NULL, NULL, 1, 0, 0, CAST(0x070000000000B1410B AS DateTime2), CAST(0x070000000000B1410B AS DateTime2))
INSERT [dbo].[Customer] ([Id], [UserName], [MobileNumber], [Email], [EmailToRevalidate], [SystemName], [BillingAddress_Id], [PhotoPath], [Address_Id], [ShippingAddress_Id], [HasShoppingCartItems], [Active], [Deleted], [IsSystemAccount], [CreatedOn], [LastLogin]) VALUES (3, N'test2', N'1815222529563', N'updated1@mail.com', NULL, N'test2', NULL, NULL, 19, NULL, NULL, 0, 0, 0, CAST(0x070000000000000000 AS DateTime2), CAST(0x070000000000000000 AS DateTime2))
INSERT [dbo].[Customer] ([Id], [UserName], [MobileNumber], [Email], [EmailToRevalidate], [SystemName], [BillingAddress_Id], [PhotoPath], [Address_Id], [ShippingAddress_Id], [HasShoppingCartItems], [Active], [Deleted], [IsSystemAccount], [CreatedOn], [LastLogin]) VALUES (4, N'new', N'234124124', N'adsfda@mail.com', NULL, N'new', NULL, NULL, 9, NULL, NULL, 1, 0, 0, CAST(0x070000000000B3410B AS DateTime2), CAST(0x07EA9035ACAAB3410B AS DateTime2))
INSERT [dbo].[Customer] ([Id], [UserName], [MobileNumber], [Email], [EmailToRevalidate], [SystemName], [BillingAddress_Id], [PhotoPath], [Address_Id], [ShippingAddress_Id], [HasShoppingCartItems], [Active], [Deleted], [IsSystemAccount], [CreatedOn], [LastLogin]) VALUES (5, N'Name updated', N'1815529777', N'newmail@mail.com', NULL, N'test', NULL, NULL, NULL, NULL, NULL, 1, 0, 0, CAST(0x072C15C36F9CC0410B AS DateTime2), CAST(0x07271ECA6F9CC0410B AS DateTime2))
INSERT [dbo].[Customer] ([Id], [UserName], [MobileNumber], [Email], [EmailToRevalidate], [SystemName], [BillingAddress_Id], [PhotoPath], [Address_Id], [ShippingAddress_Id], [HasShoppingCartItems], [Active], [Deleted], [IsSystemAccount], [CreatedOn], [LastLogin]) VALUES (6, N'new cus', N'1815888777', N'mail@mail.com', NULL, N'test', NULL, NULL, NULL, NULL, NULL, 1, 0, 0, CAST(0x07AA765CC59CC0410B AS DateTime2), CAST(0x07BE765CC59CC0410B AS DateTime2))
INSERT [dbo].[Customer] ([Id], [UserName], [MobileNumber], [Email], [EmailToRevalidate], [SystemName], [BillingAddress_Id], [PhotoPath], [Address_Id], [ShippingAddress_Id], [HasShoppingCartItems], [Active], [Deleted], [IsSystemAccount], [CreatedOn], [LastLogin]) VALUES (7, N'mizbah200', N'1815200200', N'mijbah200@mail.com', NULL, N'test', NULL, NULL, NULL, NULL, NULL, 1, 0, 0, CAST(0x07CA86743342C1410B AS DateTime2), CAST(0x07A7467C3342C1410B AS DateTime2))
INSERT [dbo].[Customer] ([Id], [UserName], [MobileNumber], [Email], [EmailToRevalidate], [SystemName], [BillingAddress_Id], [PhotoPath], [Address_Id], [ShippingAddress_Id], [HasShoppingCartItems], [Active], [Deleted], [IsSystemAccount], [CreatedOn], [LastLogin]) VALUES (8, N'mizbah00', N'1815100100', N'mijbah100@mail.com', NULL, N'test', NULL, NULL, NULL, NULL, NULL, 1, 0, 0, CAST(0x07476D0B5343C1410B AS DateTime2), CAST(0x079B8F0B5343C1410B AS DateTime2))
INSERT [dbo].[Customer] ([Id], [UserName], [MobileNumber], [Email], [EmailToRevalidate], [SystemName], [BillingAddress_Id], [PhotoPath], [Address_Id], [ShippingAddress_Id], [HasShoppingCartItems], [Active], [Deleted], [IsSystemAccount], [CreatedOn], [LastLogin]) VALUES (9, N'mizbah300', N'18153100100', N'mijbah3100@mail.com', NULL, N'test', NULL, NULL, NULL, NULL, NULL, 1, 0, 0, CAST(0x07F416877543C1410B AS DateTime2), CAST(0x072B40877543C1410B AS DateTime2))
INSERT [dbo].[Customer] ([Id], [UserName], [MobileNumber], [Email], [EmailToRevalidate], [SystemName], [BillingAddress_Id], [PhotoPath], [Address_Id], [ShippingAddress_Id], [HasShoppingCartItems], [Active], [Deleted], [IsSystemAccount], [CreatedOn], [LastLogin]) VALUES (10, N'mizbah400', N'1815314440100', N'mijbah4440@mail.com', NULL, N'test', NULL, NULL, NULL, NULL, NULL, 1, 0, 0, CAST(0x074E4DD00744C1410B AS DateTime2), CAST(0x072AE3EE0744C1410B AS DateTime2))
INSERT [dbo].[Customer] ([Id], [UserName], [MobileNumber], [Email], [EmailToRevalidate], [SystemName], [BillingAddress_Id], [PhotoPath], [Address_Id], [ShippingAddress_Id], [HasShoppingCartItems], [Active], [Deleted], [IsSystemAccount], [CreatedOn], [LastLogin]) VALUES (11, N'mizbah500', N'181531550100', N'mijbah5454@mail.com', NULL, N'test', NULL, NULL, NULL, NULL, NULL, 1, 0, 0, CAST(0x070000000000C0410B AS DateTime2), CAST(0x070000000000C0410B AS DateTime2))
INSERT [dbo].[Customer] ([Id], [UserName], [MobileNumber], [Email], [EmailToRevalidate], [SystemName], [BillingAddress_Id], [PhotoPath], [Address_Id], [ShippingAddress_Id], [HasShoppingCartItems], [Active], [Deleted], [IsSystemAccount], [CreatedOn], [LastLogin]) VALUES (12, N'mizbah600', N'181531660100', N'mijbah6565@mail.com', NULL, N'test', NULL, NULL, NULL, NULL, NULL, 1, 0, 0, CAST(0x070000000000C0410B AS DateTime2), CAST(0x070000000000C0410B AS DateTime2))
INSERT [dbo].[Customer] ([Id], [UserName], [MobileNumber], [Email], [EmailToRevalidate], [SystemName], [BillingAddress_Id], [PhotoPath], [Address_Id], [ShippingAddress_Id], [HasShoppingCartItems], [Active], [Deleted], [IsSystemAccount], [CreatedOn], [LastLogin]) VALUES (13, N'Froman vai', N'01815848565', N'asffas@mail.com', NULL, N'test', NULL, NULL, NULL, NULL, NULL, 1, 0, 0, CAST(0x074199895BA1DB410B AS DateTime2), CAST(0x07F3EE8E5BA1DB410B AS DateTime2))
INSERT [dbo].[Customer] ([Id], [UserName], [MobileNumber], [Email], [EmailToRevalidate], [SystemName], [BillingAddress_Id], [PhotoPath], [Address_Id], [ShippingAddress_Id], [HasShoppingCartItems], [Active], [Deleted], [IsSystemAccount], [CreatedOn], [LastLogin]) VALUES (14, N'Froman vai 2', N'0188654522', N'asdfasfasfs@mail.com', NULL, N'test', NULL, NULL, NULL, NULL, NULL, 1, 0, 0, CAST(0x0758DC0577A1DB410B AS DateTime2), CAST(0x0769DC0577A1DB410B AS DateTime2))
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [CustomOrderNumber], [BillingAddressId], [CustomerId], [PickupAddressId], [ShippingAddressId], [OrderGuid], [StoreId], [PickupInStore], [OrderStatusId], [ShippingStatusId], [PaymentStatusId], [PaymentMethodSystemName], [CustomerCurrencyCode], [CurrencyRate], [CustomerTaxDisplayTypeId], [VatNumber], [OrderSubtotalInclTax], [OrderSubtotalExclTax], [OrderSubTotalDiscountInclTax], [OrderSubTotalDiscountExclTax], [OrderShippingInclTax], [OrderShippingExclTax], [PaymentMethodAdditionalFeeInclTax], [PaymentMethodAdditionalFeeExclTax], [TaxRates], [OrderTax], [OrderDiscount], [OrderTotal], [RefundedAmount], [RewardPointsHistoryEntryId], [CheckoutAttributeDescription], [CheckoutAttributesXml], [CustomerLanguageId], [AffiliateId], [CustomerIp], [AllowStoringCreditCardNumber], [CardType], [CardName], [CardNumber], [MaskedCreditCardNumber], [CardCvv2], [CardExpirationMonth], [CardExpirationYear], [AuthorizationTransactionId], [AuthorizationTransactionCode], [AuthorizationTransactionResult], [CaptureTransactionId], [CaptureTransactionResult], [SubscriptionTransactionId], [PaidDateUtc], [ShippingMethod], [ShippingRateComputationMethodSystemName], [CustomValuesXml], [Deleted], [CreatedOnUtc], [RedeemedRewardPointsEntryId]) VALUES (2, N'23123', NULL, 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(20000.0000 AS Decimal(18, 4)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(0x070000000000C4410B AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[Order] OFF
SET IDENTITY_INSERT [dbo].[OrderItem] ON 

INSERT [dbo].[OrderItem] ([Id], [OrderId], [ProductId], [OrderItemGuid], [Quantity], [UnitPriceInclTax], [UnitPriceExclTax], [PriceInclTax], [PriceExclTax], [DiscountAmountInclTax], [DiscountAmountExclTax], [OriginalProductCost], [AttributeDescription], [AttributesXml], [DownloadCount], [IsDownloadActivated], [LicenseDownloadId], [ItemWeight], [RentalStartDateUtc], [RentalEndDateUtc]) VALUES (1, 2, 1, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[OrderItem] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Name], [ManufacturerPartNumber], [AllowedQuantities], [CategoryId], [ShortDescription], [FullDescription], [VendorId], [ShowOnHomepage], [AllowCustomerReviews], [IsGiftCard], [GiftCardTypeId], [HasUserAgreement], [IsShipEnabled], [IsFreeShipping], [ShipSeparately], [AdditionalShippingCharge], [DeliveryDateId], [IsTaxExempt], [TaxCategoryId], [IsTelecommunicationsOrBroadcastingOrElectronicServices], [ProductAvailabilityRangeId], [StockQuantity], [DisplayStockAvailability], [DisplayStockQuantity], [MinStockQuantity], [LowStockActivityId], [NotifyAdminForQuantityBelow], [BackorderModeId], [OrderMinimumQuantity], [OrderMaximumQuantity], [NotReturnable], [DisableBuyButton], [DisableWishlistButton], [AvailableForPreOrder], [PreOrderAvailabilityStartDateTimeUtc], [Price], [OldPrice], [CustomerEntersPrice], [MinimumCustomerEnteredPrice], [MaximumCustomerEnteredPrice], [BasepriceEnabled], [BasepriceAmount], [BasepriceUnitId], [BasepriceBaseAmount], [BasepriceBaseUnitId], [MarkAsNew], [MarkAsNewStartDateTimeUtc], [MarkAsNewEndDateTimeUtc], [HasTierPrices], [HasDiscountsApplied], [Weight], [Length], [Width], [Height], [AvailableStartDateTimeUtc], [AvailableEndDateTimeUtc], [DisplayOrder], [Published], [Deleted], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (1, N'Redmi Note 7', NULL, NULL, 2, NULL, NULL, 6, 1, 1, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(18000.0000 AS Decimal(18, 4)), CAST(20000.0000 AS Decimal(18, 4)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(0x070000000000C1410B AS DateTime2), CAST(0x070000000000C1410B AS DateTime2))
INSERT [dbo].[Product] ([Id], [Name], [ManufacturerPartNumber], [AllowedQuantities], [CategoryId], [ShortDescription], [FullDescription], [VendorId], [ShowOnHomepage], [AllowCustomerReviews], [IsGiftCard], [GiftCardTypeId], [HasUserAgreement], [IsShipEnabled], [IsFreeShipping], [ShipSeparately], [AdditionalShippingCharge], [DeliveryDateId], [IsTaxExempt], [TaxCategoryId], [IsTelecommunicationsOrBroadcastingOrElectronicServices], [ProductAvailabilityRangeId], [StockQuantity], [DisplayStockAvailability], [DisplayStockQuantity], [MinStockQuantity], [LowStockActivityId], [NotifyAdminForQuantityBelow], [BackorderModeId], [OrderMinimumQuantity], [OrderMaximumQuantity], [NotReturnable], [DisableBuyButton], [DisableWishlistButton], [AvailableForPreOrder], [PreOrderAvailabilityStartDateTimeUtc], [Price], [OldPrice], [CustomerEntersPrice], [MinimumCustomerEnteredPrice], [MaximumCustomerEnteredPrice], [BasepriceEnabled], [BasepriceAmount], [BasepriceUnitId], [BasepriceBaseAmount], [BasepriceBaseUnitId], [MarkAsNew], [MarkAsNewStartDateTimeUtc], [MarkAsNewEndDateTimeUtc], [HasTierPrices], [HasDiscountsApplied], [Weight], [Length], [Width], [Height], [AvailableStartDateTimeUtc], [AvailableEndDateTimeUtc], [DisplayOrder], [Published], [Deleted], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (2, N'Mi Note 9', NULL, NULL, 2, NULL, NULL, 8, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(22000.0000 AS Decimal(18, 4)), CAST(36000.0000 AS Decimal(18, 4)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(0x070000000000C4410B AS DateTime2), CAST(0x070000000000C4410B AS DateTime2))
INSERT [dbo].[Product] ([Id], [Name], [ManufacturerPartNumber], [AllowedQuantities], [CategoryId], [ShortDescription], [FullDescription], [VendorId], [ShowOnHomepage], [AllowCustomerReviews], [IsGiftCard], [GiftCardTypeId], [HasUserAgreement], [IsShipEnabled], [IsFreeShipping], [ShipSeparately], [AdditionalShippingCharge], [DeliveryDateId], [IsTaxExempt], [TaxCategoryId], [IsTelecommunicationsOrBroadcastingOrElectronicServices], [ProductAvailabilityRangeId], [StockQuantity], [DisplayStockAvailability], [DisplayStockQuantity], [MinStockQuantity], [LowStockActivityId], [NotifyAdminForQuantityBelow], [BackorderModeId], [OrderMinimumQuantity], [OrderMaximumQuantity], [NotReturnable], [DisableBuyButton], [DisableWishlistButton], [AvailableForPreOrder], [PreOrderAvailabilityStartDateTimeUtc], [Price], [OldPrice], [CustomerEntersPrice], [MinimumCustomerEnteredPrice], [MaximumCustomerEnteredPrice], [BasepriceEnabled], [BasepriceAmount], [BasepriceUnitId], [BasepriceBaseAmount], [BasepriceBaseUnitId], [MarkAsNew], [MarkAsNewStartDateTimeUtc], [MarkAsNewEndDateTimeUtc], [HasTierPrices], [HasDiscountsApplied], [Weight], [Length], [Width], [Height], [AvailableStartDateTimeUtc], [AvailableEndDateTimeUtc], [DisplayOrder], [Published], [Deleted], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (3, N'Mi Note 8', NULL, NULL, 2, NULL, NULL, 8, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(19999.0000 AS Decimal(18, 4)), CAST(20000.0000 AS Decimal(18, 4)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(0x070000000000C4410B AS DateTime2), CAST(0x070000000000C4410B AS DateTime2))
INSERT [dbo].[Product] ([Id], [Name], [ManufacturerPartNumber], [AllowedQuantities], [CategoryId], [ShortDescription], [FullDescription], [VendorId], [ShowOnHomepage], [AllowCustomerReviews], [IsGiftCard], [GiftCardTypeId], [HasUserAgreement], [IsShipEnabled], [IsFreeShipping], [ShipSeparately], [AdditionalShippingCharge], [DeliveryDateId], [IsTaxExempt], [TaxCategoryId], [IsTelecommunicationsOrBroadcastingOrElectronicServices], [ProductAvailabilityRangeId], [StockQuantity], [DisplayStockAvailability], [DisplayStockQuantity], [MinStockQuantity], [LowStockActivityId], [NotifyAdminForQuantityBelow], [BackorderModeId], [OrderMinimumQuantity], [OrderMaximumQuantity], [NotReturnable], [DisableBuyButton], [DisableWishlistButton], [AvailableForPreOrder], [PreOrderAvailabilityStartDateTimeUtc], [Price], [OldPrice], [CustomerEntersPrice], [MinimumCustomerEnteredPrice], [MaximumCustomerEnteredPrice], [BasepriceEnabled], [BasepriceAmount], [BasepriceUnitId], [BasepriceBaseAmount], [BasepriceBaseUnitId], [MarkAsNew], [MarkAsNewStartDateTimeUtc], [MarkAsNewEndDateTimeUtc], [HasTierPrices], [HasDiscountsApplied], [Weight], [Length], [Width], [Height], [AvailableStartDateTimeUtc], [AvailableEndDateTimeUtc], [DisplayOrder], [Published], [Deleted], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (4, N'Redmi Note 8', NULL, NULL, 2, NULL, NULL, 6, 1, 1, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(15000.0000 AS Decimal(18, 4)), CAST(20000.0000 AS Decimal(18, 4)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(0x070000000000C1410B AS DateTime2), CAST(0x070000000000C1410B AS DateTime2))
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[Store] ON 

INSERT [dbo].[Store] ([Id], [Name], [VendorId], [CompanyName], [AddressId], [CompanyPhoneNumber], [CompanyVat], [SslEnabled], [DisplayOrder], [Active], [CreatedUtc]) VALUES (1, N'Super Shop', 6, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(0x070000000000CF410B AS DateTime2))
SET IDENTITY_INSERT [dbo].[Store] OFF
SET IDENTITY_INSERT [dbo].[Vendor] ON 

INSERT [dbo].[Vendor] ([Id], [Name], [Email], [MetaKeywords], [MetaTitle], [Description], [PictureId], [AddressId], [AdminComment], [Active], [Deleted], [MetaDescription], [MobileNumber]) VALUES (6, N'vendor', N'vendor@mail.com', NULL, NULL, NULL, 1, 1, NULL, 1, 0, NULL, N'1815585')
INSERT [dbo].[Vendor] ([Id], [Name], [Email], [MetaKeywords], [MetaTitle], [Description], [PictureId], [AddressId], [AdminComment], [Active], [Deleted], [MetaDescription], [MobileNumber]) VALUES (8, N'vendor1', N'vendor200@mail.com', NULL, NULL, NULL, 2, 1, NULL, 1, 0, NULL, N'2815585')
SET IDENTITY_INSERT [dbo].[Vendor] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AddressF]    Script Date: 11/28/2020 9:29:47 PM ******/
ALTER TABLE [dbo].[Address] ADD  CONSTRAINT [IX_AddressF] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AddressF_1]    Script Date: 11/28/2020 9:29:47 PM ******/
ALTER TABLE [dbo].[Address] ADD  CONSTRAINT [IX_AddressF_1] UNIQUE NONCLUSTERED 
(
	[PhoneNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Category]    Script Date: 11/28/2020 9:29:47 PM ******/
CREATE NONCLUSTERED INDEX [IX_Category] ON [dbo].[Category]
(
	[ParentCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Vendor]    Script Date: 11/28/2020 9:29:47 PM ******/
ALTER TABLE [dbo].[Vendor] ADD  CONSTRAINT [IX_Vendor] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Address] FOREIGN KEY([Address_Id])
REFERENCES [dbo].[Address] ([Id])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Address]
GO
ALTER TABLE [dbo].[CustomerPassword]  WITH CHECK ADD  CONSTRAINT [FK_CustomerPassword_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[CustomerPassword] CHECK CONSTRAINT [FK_CustomerPassword_Customer]
GO
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD  CONSTRAINT [FK_OrderItem_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[OrderItem] CHECK CONSTRAINT [FK_OrderItem_Order]
GO
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD  CONSTRAINT [FK_OrderItem_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[OrderItem] CHECK CONSTRAINT [FK_OrderItem_Product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_VendorId] FOREIGN KEY([VendorId])
REFERENCES [dbo].[Vendor] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_VendorId]
GO
ALTER TABLE [dbo].[Product_Picture_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Product_Picture_Mapping_PictureId_Picture_Id] FOREIGN KEY([PictureId])
REFERENCES [dbo].[Picture] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product_Picture_Mapping] CHECK CONSTRAINT [FK_Product_Picture_Mapping_PictureId_Picture_Id]
GO
ALTER TABLE [dbo].[Product_Picture_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Product_Picture_Mapping_ProductId_Product_Id] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product_Picture_Mapping] CHECK CONSTRAINT [FK_Product_Picture_Mapping_ProductId_Product_Id]
GO
ALTER TABLE [dbo].[Store]  WITH CHECK ADD  CONSTRAINT [FK_Store_Address] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Address] ([Id])
GO
ALTER TABLE [dbo].[Store] CHECK CONSTRAINT [FK_Store_Address]
GO
ALTER TABLE [dbo].[Store]  WITH CHECK ADD  CONSTRAINT [FK_Store_Vendor] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Address] ([Id])
GO
ALTER TABLE [dbo].[Store] CHECK CONSTRAINT [FK_Store_Vendor]
GO
ALTER TABLE [dbo].[Vendor]  WITH CHECK ADD  CONSTRAINT [FK_Vendor_Address] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Address] ([Id])
GO
ALTER TABLE [dbo].[Vendor] CHECK CONSTRAINT [FK_Vendor_Address]
GO
USE [master]
GO
ALTER DATABASE [Mogobari_db] SET  READ_WRITE 
GO
