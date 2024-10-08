USE [master]
GO
/****** Object:  Database [Food Ordering System]    Script Date: 8/27/2024 1:31:25 PM ******/
CREATE DATABASE [Food Ordering System]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Food Ordering System', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Food Ordering System.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Food Ordering System_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Food Ordering System_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Food Ordering System] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Food Ordering System].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Food Ordering System] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Food Ordering System] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Food Ordering System] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Food Ordering System] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Food Ordering System] SET ARITHABORT OFF 
GO
ALTER DATABASE [Food Ordering System] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Food Ordering System] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Food Ordering System] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Food Ordering System] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Food Ordering System] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Food Ordering System] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Food Ordering System] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Food Ordering System] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Food Ordering System] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Food Ordering System] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Food Ordering System] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Food Ordering System] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Food Ordering System] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Food Ordering System] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Food Ordering System] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Food Ordering System] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Food Ordering System] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Food Ordering System] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Food Ordering System] SET  MULTI_USER 
GO
ALTER DATABASE [Food Ordering System] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Food Ordering System] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Food Ordering System] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Food Ordering System] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Food Ordering System] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Food Ordering System] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Food Ordering System] SET QUERY_STORE = ON
GO
ALTER DATABASE [Food Ordering System] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Food Ordering System]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 8/27/2024 1:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Cat_ID] [int] IDENTITY(1,1) NOT NULL,
	[Cat_Name] [nvarchar](50) NULL,
	[Cat_Desc] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 8/27/2024 1:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Customer_ID] [int] IDENTITY(1,1) NOT NULL,
	[Cust_Name] [nvarchar](50) NULL,
	[Cust_Email] [nvarchar](50) NULL,
	[Cust_Phone] [nvarchar](50) NULL,
	[Cust_Address] [nvarchar](50) NULL,
	[Cust_Password] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu_Items]    Script Date: 8/27/2024 1:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu_Items](
	[Item_ID] [int] IDENTITY(1,1) NOT NULL,
	[Item_Name] [nvarchar](50) NULL,
	[Item_Price] [float] NULL,
	[Item_Description] [nvarchar](50) NULL,
	[Restaurant_ID] [int] NULL,
	[Cat_ID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Item_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 8/27/2024 1:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Order_ID] [int] IDENTITY(1,1) NOT NULL,
	[Item_ID] [int] NULL,
	[Quantity] [int] NULL,
	[Status] [nvarchar](50) NULL,
	[Restaurant_ID] [int] NULL,
	[Cat_ID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Order_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 8/27/2024 1:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[Payment_ID] [int] IDENTITY(1,1) NOT NULL,
	[Order_ID] [int] NULL,
	[Method] [nvarchar](50) NULL,
	[Payment_Date] [date] NULL,
	[Payment_status] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Restaurant]    Script Date: 8/27/2024 1:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Restaurant](
	[Restaurant_ID] [int] IDENTITY(1,1) NOT NULL,
	[Restaurant_Name] [nvarchar](50) NULL,
	[Restaurant_Email] [nvarchar](50) NULL,
	[Restaurant_phone] [nvarchar](50) NULL,
	[Rating] [int] NULL
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [Food Ordering System] SET  READ_WRITE 
GO
