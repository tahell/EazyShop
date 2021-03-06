USE [master]
GO
/****** Object:  Database [EazyShop]    Script Date: 14/06/2022 10:19:13 ******/
CREATE DATABASE [EazyShop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EazyShop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\EazyShop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EazyShop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\EazyShop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EazyShop] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EazyShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EazyShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EazyShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EazyShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EazyShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EazyShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [EazyShop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EazyShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EazyShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EazyShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EazyShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EazyShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EazyShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EazyShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EazyShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EazyShop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EazyShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EazyShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EazyShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EazyShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EazyShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EazyShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EazyShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EazyShop] SET RECOVERY FULL 
GO
ALTER DATABASE [EazyShop] SET  MULTI_USER 
GO
ALTER DATABASE [EazyShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EazyShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EazyShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EazyShop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EazyShop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EazyShop] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'EazyShop', N'ON'
GO
ALTER DATABASE [EazyShop] SET QUERY_STORE = OFF
GO
USE [EazyShop]
GO
/****** Object:  Table [dbo].[Columns]    Script Date: 14/06/2022 10:19:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Columns](
	[Kod_Column] [int] IDENTITY(1,1) NOT NULL,
	[Kod_Transition] [int] NULL,
	[Number_shelves] [int] NULL,
	[Start] [int] NULL,
 CONSTRAINT [PK_Columns] PRIMARY KEY CLUSTERED 
(
	[Kod_Column] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 14/06/2022 10:19:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[Class_Code] [int] IDENTITY(1,1) NOT NULL,
	[Class_Name] [nchar](10) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Class_Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 14/06/2022 10:19:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[Location_Kod] [int] IDENTITY(1,1) NOT NULL,
	[Value_X] [float] NULL,
	[Value_Y] [float] NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[Location_Kod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Neighboring_Nodes]    Script Date: 14/06/2022 10:19:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Neighboring_Nodes](
	[Source_Node] [int] NOT NULL,
	[Destination_Node] [int] NOT NULL,
 CONSTRAINT [PK_Neighboring_Nodes] PRIMARY KEY CLUSTERED 
(
	[Destination_Node] ASC,
	[Source_Node] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nodes]    Script Date: 14/06/2022 10:19:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nodes](
	[Node_Kod] [int] IDENTITY(1,1) NOT NULL,
	[Name_Node] [nchar](10) NULL,
	[Value_X] [int] NULL,
	[Value_Y] [int] NULL,
 CONSTRAINT [PK_Nodes] PRIMARY KEY CLUSTERED 
(
	[Node_Kod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 14/06/2022 10:19:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Product_Code] [int] IDENTITY(1,1) NOT NULL,
	[product_name] [nvarchar](50) NULL,
	[Kod_Category] [int] NULL,
	[Location_Code] [int] NULL,
	[Price] [float] NULL,
	[Kod_Column] [int] NULL,
	[Shelf_number] [int] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Product_Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products_for_lists]    Script Date: 14/06/2022 10:19:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products_for_lists](
	[Product_Code] [int] NOT NULL,
	[Product_code_for_the_list_] [int] IDENTITY(1,1) NOT NULL,
	[Kod_List] [int] NULL,
 CONSTRAINT [PK_Products_for_lists] PRIMARY KEY CLUSTERED 
(
	[Product_Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reserved_lists]    Script Date: 14/06/2022 10:19:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reserved_lists](
	[List_code] [int] IDENTITY(1,1) NOT NULL,
	[User_Kod] [int] NULL,
	[Date] [datetime] NULL,
	[Name_List] [nchar](10) NULL,
 CONSTRAINT [PK_Reserved_lists] PRIMARY KEY CLUSTERED 
(
	[List_code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transition]    Script Date: 14/06/2022 10:19:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transition](
	[Kod_Transition] [int] NOT NULL,
	[Class_Code] [int] NULL,
	[Start_Kod] [int] NULL,
	[End_Kod] [int] NULL,
 CONSTRAINT [PK_Transition] PRIMARY KEY CLUSTERED 
(
	[Kod_Transition] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 14/06/2022 10:19:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[User_Code] [int] IDENTITY(1,1) NOT NULL,
	[User_Name] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[User_Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Columns] ON 

INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (1, 1, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (2, 1, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (3, 1, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (4, 1, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (5, 1, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (6, 1, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (7, 2, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (8, 2, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (9, 2, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (10, 2, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (11, 2, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (12, 2, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (13, 3, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (14, 3, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (15, 3, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (16, 3, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (17, 3, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (18, 3, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (19, 4, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (20, 4, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (21, 4, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (22, 4, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (23, 4, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (24, 4, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (25, 5, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (26, 5, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (27, 5, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (28, 5, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (29, 5, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (30, 5, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (31, 6, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (32, 6, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (33, 6, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (34, 6, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (35, 6, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (36, 6, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (37, 7, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (38, 7, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (39, 7, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (40, 7, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (41, 7, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (42, 7, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (43, 8, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (44, 8, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (45, 8, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (46, 8, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (47, 8, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (48, 8, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (49, 9, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (50, 9, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (51, 9, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (52, 9, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (53, 9, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (54, 9, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (55, 10, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (56, 10, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (57, 10, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (58, 10, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (59, 10, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (60, 10, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (61, 11, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (62, 11, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (63, 11, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (64, 11, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (65, 11, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (66, 11, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (67, 12, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (68, 12, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (69, 12, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (70, 12, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (71, 12, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (72, 12, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (73, 13, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (74, 13, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (75, 13, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (76, 13, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (77, 13, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (78, 13, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (79, 14, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (80, 14, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (81, 14, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (82, 14, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (83, 14, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (84, 14, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (85, 15, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (86, 15, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (87, 15, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (88, 15, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (89, 15, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (90, 15, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (91, 16, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (92, 16, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (93, 16, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (94, 16, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (95, 16, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (96, 16, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (97, 17, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (98, 17, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (99, 17, 3, 1)
GO
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (100, 17, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (101, 17, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (102, 17, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (103, 18, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (104, 18, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (105, 18, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (106, 18, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (107, 18, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (108, 18, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (109, 18, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (110, 19, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (111, 19, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (112, 19, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (113, 19, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (114, 19, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (115, 19, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (116, 20, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (117, 20, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (118, 20, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (119, 20, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (120, 20, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (121, 20, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (122, 21, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (123, 21, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (124, 21, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (125, 21, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (126, 21, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (127, 21, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (129, 22, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (130, 22, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (131, 22, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (132, 22, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (133, 22, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (134, 22, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (135, 23, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (136, 23, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (137, 23, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (138, 23, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (139, 23, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (140, 23, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (141, 24, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (142, 24, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (143, 24, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (144, 24, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (145, 24, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (146, 24, 3, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (147, 25, 0, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (148, 25, 0, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (149, 26, 0, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (150, 26, 0, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (151, 27, 0, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (152, 27, 0, 2)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (153, 28, 0, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (154, 28, 0, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (155, 29, 4, 0)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (156, 29, 4, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (157, 29, 4, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (158, 30, 4, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (159, 30, 4, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (160, 30, 4, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (161, 30, 4, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (162, 30, 4, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (163, 30, 4, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (164, 31, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (165, 31, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (166, 31, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (167, 31, 3, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (168, 31, 3, 0)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (169, 31, 3, 0)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (170, 32, 5, 0)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (171, 32, 5, 0)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (172, 33, 0, 0)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (173, 33, 0, 0)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (174, 33, 0, 0)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (175, 37, 0, 0)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (176, 34, 0, 0)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (177, 34, 0, 0)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (178, 36, 0, 0)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (179, 35, 0, 0)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (180, 35, 0, 0)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (181, 38, 4, 0)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (182, 39, 5, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (183, 39, 5, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (187, 40, 1, 1)
INSERT [dbo].[Columns] ([Kod_Column], [Kod_Transition], [Number_shelves], [Start]) VALUES (188, 41, 2, 1)
SET IDENTITY_INSERT [dbo].[Columns] OFF
GO
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([Class_Code], [Class_Name]) VALUES (22, N'שמפו      ')
INSERT [dbo].[Department] ([Class_Code], [Class_Name]) VALUES (23, N'אבקת כביסה')
INSERT [dbo].[Department] ([Class_Code], [Class_Name]) VALUES (24, N'מרכך כביסה')
INSERT [dbo].[Department] ([Class_Code], [Class_Name]) VALUES (25, N'ניקיון    ')
INSERT [dbo].[Department] ([Class_Code], [Class_Name]) VALUES (26, N'נוזל רצפות')
INSERT [dbo].[Department] ([Class_Code], [Class_Name]) VALUES (27, N'משלימים   ')
INSERT [dbo].[Department] ([Class_Code], [Class_Name]) VALUES (28, N'נייר      ')
INSERT [dbo].[Department] ([Class_Code], [Class_Name]) VALUES (29, N'היגיינה   ')
INSERT [dbo].[Department] ([Class_Code], [Class_Name]) VALUES (31, N'חד פעמי   ')
INSERT [dbo].[Department] ([Class_Code], [Class_Name]) VALUES (34, N'לתינוק    ')
INSERT [dbo].[Department] ([Class_Code], [Class_Name]) VALUES (35, N'חטיפים    ')
INSERT [dbo].[Department] ([Class_Code], [Class_Name]) VALUES (37, N'שתיה      ')
INSERT [dbo].[Department] ([Class_Code], [Class_Name]) VALUES (38, N'ממרחים    ')
INSERT [dbo].[Department] ([Class_Code], [Class_Name]) VALUES (39, N'פרכיות    ')
INSERT [dbo].[Department] ([Class_Code], [Class_Name]) VALUES (40, N'עוגות     ')
INSERT [dbo].[Department] ([Class_Code], [Class_Name]) VALUES (41, N'עוגיות    ')
INSERT [dbo].[Department] ([Class_Code], [Class_Name]) VALUES (42, N'מתוקים    ')
INSERT [dbo].[Department] ([Class_Code], [Class_Name]) VALUES (43, N'מתוקים    ')
INSERT [dbo].[Department] ([Class_Code], [Class_Name]) VALUES (44, N'מרקים     ')
INSERT [dbo].[Department] ([Class_Code], [Class_Name]) VALUES (45, N'פסטות     ')
INSERT [dbo].[Department] ([Class_Code], [Class_Name]) VALUES (46, N'אפייה     ')
INSERT [dbo].[Department] ([Class_Code], [Class_Name]) VALUES (47, N'בשר       ')
INSERT [dbo].[Department] ([Class_Code], [Class_Name]) VALUES (48, N'עופות     ')
INSERT [dbo].[Department] ([Class_Code], [Class_Name]) VALUES (49, N'דגים      ')
INSERT [dbo].[Department] ([Class_Code], [Class_Name]) VALUES (50, N'פירות     ')
INSERT [dbo].[Department] ([Class_Code], [Class_Name]) VALUES (51, N'ירקות     ')
INSERT [dbo].[Department] ([Class_Code], [Class_Name]) VALUES (52, N'מוצרי חלב ')
INSERT [dbo].[Department] ([Class_Code], [Class_Name]) VALUES (53, N'שימורים   ')
INSERT [dbo].[Department] ([Class_Code], [Class_Name]) VALUES (54, N'דגני בוקר ')
INSERT [dbo].[Department] ([Class_Code], [Class_Name]) VALUES (55, N'לחמים     ')
INSERT [dbo].[Department] ([Class_Code], [Class_Name]) VALUES (56, N'קפואים    ')
SET IDENTITY_INSERT [dbo].[Department] OFF
GO
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (1, 2)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (2, 3)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (3, 4)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (8, 5)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (5, 6)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (6, 7)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (4, 8)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (7, 9)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (1, 10)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (10, 11)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (11, 12)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (12, 13)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (13, 14)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (14, 15)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (15, 16)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (9, 17)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (16, 17)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (10, 18)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (18, 19)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (19, 20)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (20, 21)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (21, 22)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (22, 23)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (23, 24)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (17, 25)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (24, 25)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (18, 26)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (26, 27)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (27, 28)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (28, 29)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (29, 30)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (30, 31)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (31, 32)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (25, 33)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (32, 33)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (26, 34)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (34, 35)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (35, 36)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (36, 37)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (37, 38)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (38, 39)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (39, 40)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (33, 41)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (40, 41)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (42, 43)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (43, 44)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (44, 45)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (45, 46)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (46, 47)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (47, 48)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (41, 49)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (48, 49)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (42, 50)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (54, 53)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (59, 53)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (66, 53)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (53, 54)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (58, 54)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (65, 54)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (50, 55)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (58, 55)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (54, 58)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (55, 58)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (64, 58)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (60, 59)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (67, 59)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (59, 60)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (58, 64)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (68, 64)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (54, 65)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (69, 65)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (70, 66)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (59, 67)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (71, 67)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (64, 68)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (65, 69)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (66, 70)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (67, 71)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (71, 72)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (72, 73)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (74, 73)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (73, 74)
INSERT [dbo].[Neighboring_Nodes] ([Source_Node], [Destination_Node]) VALUES (72, 75)
GO
SET IDENTITY_INSERT [dbo].[Nodes] ON 

INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (1, N'כניסה     ', 10, 1)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (2, N'כניסה 1   ', 11, 1)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (3, N'התחלה 1   ', 12, 1)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (4, N'אמצע 1    ', 16, 1)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (5, N'כניסה 2   ', 21, 1)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (6, N'התחלה 2   ', 24, 1)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (7, N'אמצע 2    ', 27, 1)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (8, N'יציאה 1   ', 20, 1)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (9, N'יציאה 2   ', 30, 1)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (10, N'כניסה 3   ', 11, 2)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (11, N'התחלה 3   ', 12, 2)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (12, N'אמצע 3    ', 16, 2)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (13, N'יציאה 3   ', 20, 2)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (14, N'כניסה 4   ', 21, 2)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (15, N'התחלה 4   ', 24, 2)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (16, N'אמצע 4    ', 27, 2)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (17, N'יציאה 4   ', 30, 2)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (18, N'כניסה 5   ', 11, 4)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (19, N'התחלה 5   ', 12, 4)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (20, N'אמצע 5    ', 16, 4)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (21, N'יציאה 5   ', 20, 4)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (22, N'כניסה 6   ', 21, 4)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (23, N'התחלה 6   ', 24, 4)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (24, N'אמצע 6    ', 27, 4)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (25, N'יציאה 6   ', 30, 4)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (26, N'כניסה 7   ', 11, 5)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (27, N'התחלה 7   ', 12, 5)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (28, N'אמצע 7    ', 16, 5)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (29, N'יציאה 7   ', 20, 5)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (30, N'כניסה 8   ', 21, 5)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (31, N'התחלה 8   ', 24, 5)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (32, N'אמצע 8    ', 27, 5)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (33, N'יציאה 8   ', 30, 5)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (34, N'כניסה 9   ', 11, 7)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (35, N'התחלה 9   ', 12, 7)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (36, N'אמצע 9    ', 16, 7)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (37, N'יציאה 9   ', 20, 7)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (38, N'כניסה 10  ', 21, 7)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (39, N'התחלה 10  ', 24, 7)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (40, N'אמצע 10   ', 27, 7)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (41, N'יציאה 10  ', 30, 7)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (42, N'כניסה 11  ', 11, 8)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (43, N'התחלה 11  ', 12, 8)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (44, N'אמצע 11   ', 16, 8)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (45, N'יציאה 11  ', 20, 8)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (46, N'כניסה 12  ', 21, 8)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (47, N'התחלה 12  ', 24, 8)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (48, N'אמצע 12   ', 27, 8)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (49, N'יציאה 12  ', 30, 8)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (50, N'סוף יבשים ', 11, 9)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (53, N'מעבר קפוא3', 21, 10)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (54, N'מעבר קפוא2', 18, 10)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (55, N'סוף טורים ', 12, 9)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (58, N'מעבר קפוא1', 15, 10)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (59, N'מעבר      ', 24, 10)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (60, N'מעבר אפיה ', 27, 10)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (61, N'מעבר אפיה ', 30, 10)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (63, N'כניסה לחם ', 13, 13)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (64, N'אמצע ק1   ', 15, 12)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (65, N'אמצע ק 2  ', 18, 12)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (66, N'אמצע ק3   ', 21, 12)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (67, NULL, 24, 12)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (68, N'יצ קפוא1  ', 15, 14)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (69, N'יצ קפוא 2 ', 18, 14)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (70, N'יצ קפוא 3 ', 21, 14)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (71, N'סוף קפוא  ', 24, 14)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (72, N'אמצע חלבי ', 25, 15)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (73, N'כניסה דגני', 27, 16)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (74, NULL, 28, 16)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (75, N' אמצע חלבי', 31, 15)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (76, N'חלבי התחלה', 27, 17)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (77, NULL, 26, 18)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (78, N'ש התחלה   ', 20, 18)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (79, N'ש אמצע    ', 17, 16)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (80, NULL, 15, 16)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (81, N'ש סוף     ', 12, 16)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (82, N'כניסה ירק ', 8, 16)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (83, N'אמצע ירק  ', 4, 16)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (84, N'סוף       ', 2, 16)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (85, NULL, 7, 14)
INSERT [dbo].[Nodes] ([Node_Kod], [Name_Node], [Value_X], [Value_Y]) VALUES (86, NULL, 11, 13)
SET IDENTITY_INSERT [dbo].[Nodes] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (5, N'חלב', 52, NULL, 5, 155, 2)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (6, N'קוטג', 52, NULL, 6, 156, 1)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (7, N'גבינה צהובה', 52, NULL, 14, 157, 2)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (8, N'שמפו פינוק', 22, NULL, 10, 1, 2)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (9, N'מרכך פינוק', 22, NULL, 10, 1, 1)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (10, N'תירס', 53, NULL, 6, 170, 3)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (11, N'מלפפון חמוץ', 53, NULL, 6, 171, 2)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (12, N'פטריות', 53, NULL, 7, 170, 1)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (13, N'חזה עוף עטרה', 48, NULL, 23, 151, 0)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (14, N'פרגיות עטרה', 48, NULL, 25, 152, 0)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (15, N'בשר טחון עטרה', 47, NULL, 20, 147, 0)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (16, N'בשר טחון מחפוד', 47, NULL, 22, 148, 0)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (17, N'מלוואח', 56, NULL, 16, 182, 2)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (18, N'קרונפלקס תלמה', 54, NULL, 20, 164, 2)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (19, N'כריות תלמה', 54, NULL, 23, 165, 3)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (20, N'עגבניה', 51, NULL, 3, 172, 1)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (21, N'מלפפון', 51, NULL, 3, 173, 0)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (22, N'גזר', 51, NULL, 4, 174, 0)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (23, N'תפוח אדמה', 51, NULL, 3, 180, 0)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (24, N'תפוח אדום', 50, NULL, 6, 178, 0)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (25, N'לימון', 50, NULL, 4, 175, 0)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (26, N'אבוקדו', 51, NULL, 8, 176, 0)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (27, N'חציל', 51, NULL, 7, 174, 0)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (28, N'בטטה', 51, NULL, 3, 177, 0)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (29, N'בצל', 51, NULL, 4, 180, 0)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (30, N'גמבה', 51, NULL, 4, 179, 0)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (31, N'מעדן מילקי', 52, NULL, 4, 158, 0)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (32, N'יוגורט', 52, NULL, 15, 159, 1)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (33, N'חמאה', 52, NULL, 10, 159, 2)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (34, N'מחמאה', 52, NULL, 8, 159, 2)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (35, N'גבינה בולגרית', 52, NULL, 16, 160, 3)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (36, N'פסטה', 45, NULL, 8, 129, 2)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (37, N'אורז', 45, NULL, 10, 130, 2)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (38, N'פתיתים', 45, NULL, 10, 131, 1)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (39, N'בורגול', 45, NULL, 10, 132, 3)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (40, N'גרגירי חומוס', 45, NULL, 12, 133, 2)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (41, N'ממרח שוקולד', 38, NULL, 16, 141, 1)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (42, N'מרכך כביסה', 24, NULL, 22, 13, 3)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (43, N'צלחות חדפ', 31, NULL, 30, 49, 2)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (44, N'כוסות חדפ', 31, NULL, 15, 50, 1)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (45, N'מזלגות חדפ', 31, NULL, 15, 51, 2)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (46, N'סכינים חדפ', 31, NULL, 15, 52, 3)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (47, N'צלחות לסלטים חדפ', 31, NULL, 9, 53, 2)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (48, N'מטרנה', 34, NULL, 50, 61, 3)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (49, N'טיטולים', 34, NULL, 90, 62, 1)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (50, N'סימילאק', 34, NULL, 95, 63, 2)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (51, N'פרכיות אורז', 39, NULL, 20, 91, 3)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (52, N'פרכיות שוקולד', 39, NULL, 22, 91, 1)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (53, N'עד חצות', 41, NULL, 16, 105, 2)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (54, N'רבע לשבע', 41, NULL, 16, 106, 3)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (55, N'פינוקיות', 41, NULL, 16, 107, 1)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (56, N'עוגיות מלוחות', 41, NULL, 20, 108, 2)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (57, N'ערגליות תות', 41, NULL, 20, 105, 3)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (58, N'ערגליות שוקולד', 41, NULL, 20, 109, 1)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (59, N'קרמבו', 42, NULL, 25, 110, 2)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (60, N'עוגת שמרים', 40, NULL, 24, 97, 3)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (61, N'עוגת שוקולד', 40, NULL, 24, 98, 1)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (62, N'עוגת ריבה', 40, NULL, 24, 99, 2)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (63, N'נייר אפייה', 46, NULL, 9, 187, 3)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (64, N'איסטנט פודיניק', 46, NULL, 20, 187, 1)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (65, N'דובדבנים', 46, NULL, 15, 188, 2)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (66, N'סוכר וניל', 46, NULL, 10, 188, 3)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (67, N'קוקה קולה', 37, NULL, 9, 73, 1)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (68, N'קולה זירו', 37, NULL, 9, 74, 2)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (69, N'ארסי קולה', 37, NULL, 6, 75, 3)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (70, N'פנטה', 37, NULL, 8, 76, 1)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (71, N'פיוז טי', 37, NULL, 8, 77, 2)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (72, N'סודה', 37, NULL, 8, 78, 3)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (73, N'מים מינרלים', 37, NULL, 8, 79, 1)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (74, N'קריסטל תות', 37, NULL, 8, 80, 2)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (75, N'קריסטלר קולה', 37, NULL, 8, 81, 3)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (76, N'שוואפס פירות יער', 37, NULL, 8, 82, 1)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (77, N'שוואפס ענבים', 37, NULL, 8, 83, 2)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (78, N'שוואפס תפוח', 37, NULL, 8, 84, 3)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (79, N'שוקולד תות', 43, NULL, 6, 116, 1)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (80, N'שוקולד עדשים', 43, NULL, 6, 117, 2)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (81, N'שוקולד אגוזים', 43, NULL, 6, 118, 3)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (82, N'שוקולוד נוגט', 43, NULL, 6, 119, 1)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (83, N'שוקולד לבן', 43, NULL, 6, 120, 2)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (84, N'סוכריות צבעוניות', 43, NULL, 15, 117, 3)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (85, N'אבקת מרק עוף', 44, NULL, 22, 122, 1)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (86, N'אבקת מרק פטריות', 44, NULL, 14, 123, 2)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (87, N'מנה חמה אוסם עוף', 44, NULL, 7, 124, 3)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (88, N'מנה חמה אוסם תאילנדי', 44, NULL, 7, 125, 1)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (89, N'מנה חמה אוסם בקר', 44, NULL, 7, 126, 2)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (90, N'מנה חמה אוסם פירה', 44, NULL, 7, 127, 3)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (91, N'מנה חמה אוסם קוסקוס', 44, NULL, 7, 122, 1)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (92, N'לחם לבן', 55, NULL, 7, 181, 2)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (93, N'לחם כוסמין', 55, NULL, 14, 181, 3)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (94, N'לחם מלא', 55, NULL, 15, 181, 4)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (95, N'נייר טואלאט סנו', 28, NULL, 49, 37, 1)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (96, N'נייר לניקוי', 28, NULL, 15, 38, 2)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (97, N'נייר חתוך', 28, NULL, 30, 39, 3)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (98, N'גלידה וניל', 56, NULL, 30, 183, 1)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (99, N'גחנון', 56, NULL, 20, 182, 2)
INSERT [dbo].[Products] ([Product_Code], [product_name], [Kod_Category], [Location_Code], [Price], [Kod_Column], [Shelf_number]) VALUES (100, N'גלידה שוקולד', 56, NULL, 25, 183, 3)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (1, 22, 2, 8)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (2, 23, 10, 13)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (3, 24, 10, 13)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (4, 25, 18, 21)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (5, 26, 18, 21)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (6, 27, 26, 29)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (7, 28, 26, 29)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (8, 29, 34, 37)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (9, 31, 34, 37)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (10, 31, 42, 45)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (11, 34, 42, 45)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (12, 35, 5, 9)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (13, 37, 14, 17)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (14, 37, 14, 17)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (15, 38, 22, 25)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (16, 39, 22, 25)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (17, 40, 30, 33)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (18, 41, 30, 33)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (19, 42, 38, 41)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (20, 43, 38, 41)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (21, 44, 46, 49)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (22, 45, 46, 49)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (23, 45, 46, 49)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (24, 38, 46, 49)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (25, 47, 58, 68)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (26, 47, 58, 68)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (27, 48, 54, 69)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (28, 49, 53, 70)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (29, 52, 76, 75)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (30, 52, 72, 78)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (31, 54, 73, 78)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (32, 53, 78, 81)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (33, 51, 82, 84)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (34, 51, 82, 84)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (35, 51, 82, 84)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (36, 50, 83, 84)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (37, 50, 83, 84)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (38, 55, 63, 86)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (39, 56, 67, 71)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (40, 46, 60, 61)
INSERT [dbo].[Transition] ([Kod_Transition], [Class_Code], [Start_Kod], [End_Kod]) VALUES (41, 46, 60, 61)
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([User_Code], [User_Name], [Password]) VALUES (1, N'משה', N'1234')
INSERT [dbo].[Users] ([User_Code], [User_Name], [Password]) VALUES (2, N'חיים', N'5678')
INSERT [dbo].[Users] ([User_Code], [User_Name], [Password]) VALUES (3, N'מיכל', N'8722')
INSERT [dbo].[Users] ([User_Code], [User_Name], [Password]) VALUES (18, N'1323435', N'קופיפיייי')
INSERT [dbo].[Users] ([User_Code], [User_Name], [Password]) VALUES (19, N'1323435', N'CVF')
INSERT [dbo].[Users] ([User_Code], [User_Name], [Password]) VALUES (20, N'אבנר', N'1252')
INSERT [dbo].[Users] ([User_Code], [User_Name], [Password]) VALUES (2023, N'תהל', N'123')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Columns]  WITH CHECK ADD  CONSTRAINT [FK_Columns_Transition] FOREIGN KEY([Kod_Transition])
REFERENCES [dbo].[Transition] ([Kod_Transition])
GO
ALTER TABLE [dbo].[Columns] CHECK CONSTRAINT [FK_Columns_Transition]
GO
ALTER TABLE [dbo].[Neighboring_Nodes]  WITH CHECK ADD  CONSTRAINT [FK_Neighboring_Nodes_Nodes] FOREIGN KEY([Source_Node])
REFERENCES [dbo].[Nodes] ([Node_Kod])
GO
ALTER TABLE [dbo].[Neighboring_Nodes] CHECK CONSTRAINT [FK_Neighboring_Nodes_Nodes]
GO
ALTER TABLE [dbo].[Neighboring_Nodes]  WITH CHECK ADD  CONSTRAINT [FK_Neighboring_Nodes_Nodes1] FOREIGN KEY([Destination_Node])
REFERENCES [dbo].[Nodes] ([Node_Kod])
GO
ALTER TABLE [dbo].[Neighboring_Nodes] CHECK CONSTRAINT [FK_Neighboring_Nodes_Nodes1]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Columns] FOREIGN KEY([Kod_Column])
REFERENCES [dbo].[Columns] ([Kod_Column])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Columns]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Department] FOREIGN KEY([Kod_Category])
REFERENCES [dbo].[Department] ([Class_Code])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Department]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Location] FOREIGN KEY([Location_Code])
REFERENCES [dbo].[Location] ([Location_Kod])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Location]
GO
ALTER TABLE [dbo].[Products_for_lists]  WITH CHECK ADD  CONSTRAINT [FK_Products_for_lists_Products] FOREIGN KEY([Product_Code])
REFERENCES [dbo].[Products] ([Product_Code])
GO
ALTER TABLE [dbo].[Products_for_lists] CHECK CONSTRAINT [FK_Products_for_lists_Products]
GO
ALTER TABLE [dbo].[Products_for_lists]  WITH CHECK ADD  CONSTRAINT [FK_Products_for_lists_Reserved_lists] FOREIGN KEY([Product_code_for_the_list_])
REFERENCES [dbo].[Reserved_lists] ([List_code])
GO
ALTER TABLE [dbo].[Products_for_lists] CHECK CONSTRAINT [FK_Products_for_lists_Reserved_lists]
GO
ALTER TABLE [dbo].[Reserved_lists]  WITH CHECK ADD  CONSTRAINT [FK_Reserved_lists_Users] FOREIGN KEY([List_code])
REFERENCES [dbo].[Users] ([User_Code])
GO
ALTER TABLE [dbo].[Reserved_lists] CHECK CONSTRAINT [FK_Reserved_lists_Users]
GO
ALTER TABLE [dbo].[Transition]  WITH CHECK ADD  CONSTRAINT [FK_Transition_Department] FOREIGN KEY([Class_Code])
REFERENCES [dbo].[Department] ([Class_Code])
GO
ALTER TABLE [dbo].[Transition] CHECK CONSTRAINT [FK_Transition_Department]
GO
ALTER TABLE [dbo].[Transition]  WITH CHECK ADD  CONSTRAINT [FK_Transition_Nodes] FOREIGN KEY([Start_Kod])
REFERENCES [dbo].[Nodes] ([Node_Kod])
GO
ALTER TABLE [dbo].[Transition] CHECK CONSTRAINT [FK_Transition_Nodes]
GO
ALTER TABLE [dbo].[Transition]  WITH CHECK ADD  CONSTRAINT [FK_Transition_Nodes1] FOREIGN KEY([End_Kod])
REFERENCES [dbo].[Nodes] ([Node_Kod])
GO
ALTER TABLE [dbo].[Transition] CHECK CONSTRAINT [FK_Transition_Nodes1]
GO
USE [master]
GO
ALTER DATABASE [EazyShop] SET  READ_WRITE 
GO
