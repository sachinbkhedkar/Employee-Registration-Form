USE [master]
GO
/****** Object:  Database [Employee Registration]    Script Date: 30-11-2024 16:16:05 ******/
CREATE DATABASE [Employee Registration]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Employee Registration', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Employee Registration.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Employee Registration_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Employee Registration_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Employee Registration] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Employee Registration].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Employee Registration] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Employee Registration] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Employee Registration] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Employee Registration] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Employee Registration] SET ARITHABORT OFF 
GO
ALTER DATABASE [Employee Registration] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Employee Registration] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Employee Registration] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Employee Registration] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Employee Registration] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Employee Registration] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Employee Registration] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Employee Registration] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Employee Registration] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Employee Registration] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Employee Registration] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Employee Registration] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Employee Registration] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Employee Registration] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Employee Registration] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Employee Registration] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Employee Registration] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Employee Registration] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Employee Registration] SET  MULTI_USER 
GO
ALTER DATABASE [Employee Registration] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Employee Registration] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Employee Registration] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Employee Registration] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Employee Registration] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Employee Registration] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Employee Registration] SET QUERY_STORE = OFF
GO
USE [Employee Registration]
GO
/****** Object:  Table [dbo].[Country_Mst]    Script Date: 30-11-2024 16:16:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country_Mst](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Country_Name] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee_Mst]    Script Date: 30-11-2024 16:16:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee_Mst](
	[Employee_Id] [int] IDENTITY(1,1) NOT NULL,
	[Employee_Name] [varchar](100) NOT NULL,
	[Age] [int] NOT NULL,
	[Mobile_Num] [varchar](10) NOT NULL,
	[Pincode] [varchar](6) NOT NULL,
	[DOB] [datetime] NULL,
	[AddressLine1] [varchar](250) NULL,
	[AddressLine2] [varchar](250) NULL,
	[State_Id] [int] NULL,
	[Country_Id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Employee_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State_Mst]    Script Date: 30-11-2024 16:16:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State_Mst](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[State_Name] [varchar](50) NOT NULL,
	[Country_Id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Country_Mst] ON 

INSERT [dbo].[Country_Mst] ([Id], [Country_Name]) VALUES (1, N'India')
INSERT [dbo].[Country_Mst] ([Id], [Country_Name]) VALUES (2, N'USA')
SET IDENTITY_INSERT [dbo].[Country_Mst] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee_Mst] ON 

INSERT [dbo].[Employee_Mst] ([Employee_Id], [Employee_Name], [Age], [Mobile_Num], [Pincode], [DOB], [AddressLine1], [AddressLine2], [State_Id], [Country_Id]) VALUES (2, N'Sachin Khedkar', 3, N'1234567891', N'123456', CAST(N'2021-06-07T00:00:00.000' AS DateTime), N'Pune', N'pune', 1, 1)
INSERT [dbo].[Employee_Mst] ([Employee_Id], [Employee_Name], [Age], [Mobile_Num], [Pincode], [DOB], [AddressLine1], [AddressLine2], [State_Id], [Country_Id]) VALUES (3, N'Emp One', 3, N'1234567892', N'123456', CAST(N'2021-08-18T00:00:00.000' AS DateTime), N'Mumbai', N'Mumbai', 2, 2)
INSERT [dbo].[Employee_Mst] ([Employee_Id], [Employee_Name], [Age], [Mobile_Num], [Pincode], [DOB], [AddressLine1], [AddressLine2], [State_Id], [Country_Id]) VALUES (4, N'Emp Two', 10, N'1234567893', N'456123', CAST(N'2014-02-14T00:00:00.000' AS DateTime), N'Thane', N'Thane', 3, 1)
INSERT [dbo].[Employee_Mst] ([Employee_Id], [Employee_Name], [Age], [Mobile_Num], [Pincode], [DOB], [AddressLine1], [AddressLine2], [State_Id], [Country_Id]) VALUES (5, N'Emp Three', 18, N'7894561230', N'123654', CAST(N'2006-02-09T00:00:00.000' AS DateTime), N'Nagpur', N'Nagpur', 3, 1)
INSERT [dbo].[Employee_Mst] ([Employee_Id], [Employee_Name], [Age], [Mobile_Num], [Pincode], [DOB], [AddressLine1], [AddressLine2], [State_Id], [Country_Id]) VALUES (6, N'Emp Four', 6, N'9874563218', N'145932', CAST(N'2018-02-24T00:00:00.000' AS DateTime), N'Pune', N'Nagpur', 2, 2)
INSERT [dbo].[Employee_Mst] ([Employee_Id], [Employee_Name], [Age], [Mobile_Num], [Pincode], [DOB], [AddressLine1], [AddressLine2], [State_Id], [Country_Id]) VALUES (7, N'Emp Five', 2, N'9876543217', N'145865', CAST(N'2022-06-23T00:00:00.000' AS DateTime), N'Thane', N'Delhi', 1, 1)
SET IDENTITY_INSERT [dbo].[Employee_Mst] OFF
GO
SET IDENTITY_INSERT [dbo].[State_Mst] ON 

INSERT [dbo].[State_Mst] ([Id], [State_Name], [Country_Id]) VALUES (1, N'Maharshtra', 1)
INSERT [dbo].[State_Mst] ([Id], [State_Name], [Country_Id]) VALUES (2, N'Canada', 2)
INSERT [dbo].[State_Mst] ([Id], [State_Name], [Country_Id]) VALUES (3, N'Goa', 1)
SET IDENTITY_INSERT [dbo].[State_Mst] OFF
GO
ALTER TABLE [dbo].[Employee_Mst]  WITH CHECK ADD FOREIGN KEY([Country_Id])
REFERENCES [dbo].[Country_Mst] ([Id])
GO
ALTER TABLE [dbo].[Employee_Mst]  WITH CHECK ADD FOREIGN KEY([State_Id])
REFERENCES [dbo].[State_Mst] ([Id])
GO
ALTER TABLE [dbo].[State_Mst]  WITH CHECK ADD FOREIGN KEY([Country_Id])
REFERENCES [dbo].[Country_Mst] ([Id])
GO
USE [master]
GO
ALTER DATABASE [Employee Registration] SET  READ_WRITE 
GO
