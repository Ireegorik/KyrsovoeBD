USE [master]
GO
/****** Object:  Database [AirPort]    Script Date: 18.05.2020 10:06:16 ******/
CREATE DATABASE [AirPort]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AirPort', FILENAME = N'D:\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\AirPort.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AirPort_log', FILENAME = N'D:\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\AirPort_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [AirPort] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AirPort].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AirPort] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AirPort] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AirPort] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AirPort] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AirPort] SET ARITHABORT OFF 
GO
ALTER DATABASE [AirPort] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AirPort] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AirPort] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AirPort] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AirPort] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AirPort] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AirPort] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AirPort] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AirPort] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AirPort] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AirPort] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AirPort] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AirPort] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AirPort] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AirPort] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AirPort] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AirPort] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AirPort] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AirPort] SET  MULTI_USER 
GO
ALTER DATABASE [AirPort] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AirPort] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AirPort] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AirPort] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AirPort] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AirPort] SET QUERY_STORE = OFF
GO
USE [AirPort]
GO
/****** Object:  Table [dbo].[Admins]    Script Date: 18.05.2020 10:06:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins](
	[Admin_Id] [int] NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[Surname] [varchar](30) NOT NULL,
	[Middle_Name] [varchar](30) NOT NULL,
	[Phone_Number] [varchar](30) NULL,
	[Adress] [varchar](30) NULL,
	[Login] [varchar](30) NOT NULL,
	[Password] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Admins] PRIMARY KEY CLUSTERED 
(
	[Admin_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AirPlanes]    Script Date: 18.05.2020 10:06:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AirPlanes](
	[AirPlane_Num] [int] NOT NULL,
	[Count_Chairs] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Type] [varchar](30) NOT NULL,
	[Location] [varchar](100) NOT NULL,
	[AirPort_Num] [int] NOT NULL,
 CONSTRAINT [PK_AirPlanes] PRIMARY KEY CLUSTERED 
(
	[AirPlane_Num] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AirPlaneTypes]    Script Date: 18.05.2020 10:06:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AirPlaneTypes](
	[Types] [varchar](30) NOT NULL,
	[All_Rows] [int] NOT NULL,
	[Bussnes_Rows] [int] NOT NULL,
 CONSTRAINT [PK_AirPlaneTypes] PRIMARY KEY CLUSTERED 
(
	[Types] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AirPort]    Script Date: 18.05.2020 10:06:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AirPort](
	[AirPort_Num] [int] NOT NULL,
	[City] [varchar](50) NOT NULL,
	[Adress] [varchar](60) NOT NULL,
	[Runway] [int] NOT NULL,
	[Name] [varchar](30) NOT NULL,
 CONSTRAINT [PK_AirPort] PRIMARY KEY CLUSTERED 
(
	[AirPort_Num] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Flights]    Script Date: 18.05.2020 10:06:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flights](
	[Flight_Num] [int] NOT NULL,
	[Filight_Date] [datetime] NOT NULL,
	[Point_Of_Departure] [varchar](100) NOT NULL,
	[Destination] [varchar](100) NOT NULL,
	[Duration] [time](7) NULL,
	[AirPlane_Num] [int] NOT NULL,
	[Pilot_Num] [int] NOT NULL,
	[AirPortTO_Num] [int] NOT NULL,
	[AirPortFrom_Num] [int] NOT NULL,
 CONSTRAINT [PK_Flights] PRIMARY KEY CLUSTERED 
(
	[Flight_Num] ASC,
	[Filight_Date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login_Password]    Script Date: 18.05.2020 10:06:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login_Password](
	[Login] [varchar](30) NOT NULL,
	[Password] [varchar](30) NOT NULL,
	[Role] [int] NOT NULL,
	[Id] [int] NOT NULL,
	[Password_Number] [int] NULL,
	[Password_Sires] [int] NULL,
 CONSTRAINT [PK_Login_Password] PRIMARY KEY CLUSTERED 
(
	[Login] ASC,
	[Password] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Passengers]    Script Date: 18.05.2020 10:06:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Passengers](
	[Passport_Number] [int] NOT NULL,
	[Passport_Series] [int] NOT NULL,
	[Citizenship] [varchar](50) NOT NULL,
	[Gender] [varchar](50) NOT NULL,
	[Surname] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Middle_Name] [varchar](50) NULL,
	[login] [varchar](30) NOT NULL,
	[password] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Passengers_1] PRIMARY KEY CLUSTERED 
(
	[Passport_Number] ASC,
	[Passport_Series] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pilots]    Script Date: 18.05.2020 10:06:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pilots](
	[Pilot_Num] [int] NOT NULL,
	[Hire_Date] [date] NOT NULL,
	[Gender] [varchar](3) NOT NULL,
	[Adress] [varchar](100) NOT NULL,
	[Phone_Number] [varchar](50) NULL,
	[Surname] [varchar](50) NOT NULL,
	[Middle_Name] [varchar](50) NULL,
	[Name] [varchar](50) NOT NULL,
	[Login] [varchar](30) NOT NULL,
	[Password] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Pilots] PRIMARY KEY CLUSTERED 
(
	[Pilot_Num] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seets_On_The_Plane]    Script Date: 18.05.2020 10:06:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seets_On_The_Plane](
	[AirPlane_Num] [int] NOT NULL,
	[Place_Num] [int] NOT NULL,
	[Row_Num] [int] NOT NULL,
 CONSTRAINT [PK_Seets_On_The_Plane] PRIMARY KEY CLUSTERED 
(
	[AirPlane_Num] ASC,
	[Place_Num] ASC,
	[Row_Num] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tickets_Sold]    Script Date: 18.05.2020 10:06:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tickets_Sold](
	[Ticket_Num] [int] NOT NULL,
	[Flight_Num] [int] NOT NULL,
	[Passport_Num] [int] NOT NULL,
	[Passport_Series] [int] NOT NULL,
	[Flight_Date] [datetime] NOT NULL,
	[Place_Num] [int] NOT NULL,
	[Row_Num] [int] NOT NULL,
	[AirPlane_Num] [int] NOT NULL,
 CONSTRAINT [PK_Tickets_Sold] PRIMARY KEY CLUSTERED 
(
	[Ticket_Num] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Admins] ([Admin_Id], [Name], [Surname], [Middle_Name], [Phone_Number], [Adress], [Login], [Password]) VALUES (0, N'Admin', N'Admin', N'Admin', N'0000', N'-', N'Admin', N'Admin')
GO
INSERT [dbo].[Admins] ([Admin_Id], [Name], [Surname], [Middle_Name], [Phone_Number], [Adress], [Login], [Password]) VALUES (1, N'Admin1', N'Admin1', N'Admin1', N'-', N'-', N'Admin1', N'Admin1')
GO
INSERT [dbo].[AirPlanes] ([AirPlane_Num], [Count_Chairs], [Name], [Type], [Location], [AirPort_Num]) VALUES (1, 0, N'Gerkules', N'Airbus A310', N'Moscow Moscow region.', 0)
GO
INSERT [dbo].[AirPlanes] ([AirPlane_Num], [Count_Chairs], [Name], [Type], [Location], [AirPort_Num]) VALUES (2, 0, N'Vdova', N'Airbus A320', N'Moscow Moscow region.', 1)
GO
INSERT [dbo].[AirPlanes] ([AirPlane_Num], [Count_Chairs], [Name], [Type], [Location], [AirPort_Num]) VALUES (3, 0, N'Irs', N'Airbus A330', N'Moscow Moscow region.', 2)
GO
INSERT [dbo].[AirPlanes] ([AirPlane_Num], [Count_Chairs], [Name], [Type], [Location], [AirPort_Num]) VALUES (4, 0, N'Detra', N'IL-62', N'Agzy Agzy region.', 5)
GO
INSERT [dbo].[AirPlanes] ([AirPlane_Num], [Count_Chairs], [Name], [Type], [Location], [AirPort_Num]) VALUES (5, 0, N'Inga', N'IL-96', N'Anabar Anabar region.', 10)
GO
INSERT [dbo].[AirPlanes] ([AirPlane_Num], [Count_Chairs], [Name], [Type], [Location], [AirPort_Num]) VALUES (6, 0, N'Super', N'Sukhoi SuperJet-100', N'Saint-Peterburg Peterburg region.', 3)
GO
INSERT [dbo].[AirPlanes] ([AirPlane_Num], [Count_Chairs], [Name], [Type], [Location], [AirPort_Num]) VALUES (7, 0, N'Aleksia', N'Ty-134', N'Moscow Moscow region.', 2)
GO
INSERT [dbo].[AirPlanes] ([AirPlane_Num], [Count_Chairs], [Name], [Type], [Location], [AirPort_Num]) VALUES (8, 0, N'Vihan', N'Ty-154', N'Achinsk Achinsk region.', 14)
GO
INSERT [dbo].[AirPlanes] ([AirPlane_Num], [Count_Chairs], [Name], [Type], [Location], [AirPort_Num]) VALUES (9, 0, N'Pigas', N'Boeing-747', N'Arhangelsk Arhangelsk region.', 12)
GO
INSERT [dbo].[AirPlanes] ([AirPlane_Num], [Count_Chairs], [Name], [Type], [Location], [AirPort_Num]) VALUES (10, 0, N'Kek', N'Airbus A310', N'Moscow Moscow region.', 2)
GO
INSERT [dbo].[AirPlanes] ([AirPlane_Num], [Count_Chairs], [Name], [Type], [Location], [AirPort_Num]) VALUES (11, 0, N'1', N'111', N'Abakan Abakan region.', 4)
GO
INSERT [dbo].[AirPlanes] ([AirPlane_Num], [Count_Chairs], [Name], [Type], [Location], [AirPort_Num]) VALUES (12, 0, N'1', N'Airbus A310', N'Abakan Abakan region.', 4)
GO
INSERT [dbo].[AirPlaneTypes] ([Types], [All_Rows], [Bussnes_Rows]) VALUES (N'111', 12, 1)
GO
INSERT [dbo].[AirPlaneTypes] ([Types], [All_Rows], [Bussnes_Rows]) VALUES (N'12', 12, 1)
GO
INSERT [dbo].[AirPlaneTypes] ([Types], [All_Rows], [Bussnes_Rows]) VALUES (N'Airbus A310', 43, 2)
GO
INSERT [dbo].[AirPlaneTypes] ([Types], [All_Rows], [Bussnes_Rows]) VALUES (N'Airbus A320', 26, 1)
GO
INSERT [dbo].[AirPlaneTypes] ([Types], [All_Rows], [Bussnes_Rows]) VALUES (N'Airbus A330', 76, 7)
GO
INSERT [dbo].[AirPlaneTypes] ([Types], [All_Rows], [Bussnes_Rows]) VALUES (N'Boeing-737', 34, 1)
GO
INSERT [dbo].[AirPlaneTypes] ([Types], [All_Rows], [Bussnes_Rows]) VALUES (N'Boeing-747', 62, 9)
GO
INSERT [dbo].[AirPlaneTypes] ([Types], [All_Rows], [Bussnes_Rows]) VALUES (N'Boeing-767', 37, 5)
GO
INSERT [dbo].[AirPlaneTypes] ([Types], [All_Rows], [Bussnes_Rows]) VALUES (N'Boeing-777', 48, 9)
GO
INSERT [dbo].[AirPlaneTypes] ([Types], [All_Rows], [Bussnes_Rows]) VALUES (N'IL-62', 23, 6)
GO
INSERT [dbo].[AirPlaneTypes] ([Types], [All_Rows], [Bussnes_Rows]) VALUES (N'IL-86', 45, 2)
GO
INSERT [dbo].[AirPlaneTypes] ([Types], [All_Rows], [Bussnes_Rows]) VALUES (N'IL-96', 31, 4)
GO
INSERT [dbo].[AirPlaneTypes] ([Types], [All_Rows], [Bussnes_Rows]) VALUES (N'Sukhoi SuperJet-100', 18, 2)
GO
INSERT [dbo].[AirPlaneTypes] ([Types], [All_Rows], [Bussnes_Rows]) VALUES (N'Ty-134', 18, 2)
GO
INSERT [dbo].[AirPlaneTypes] ([Types], [All_Rows], [Bussnes_Rows]) VALUES (N'Ty-154', 22, 6)
GO
INSERT [dbo].[AirPlaneTypes] ([Types], [All_Rows], [Bussnes_Rows]) VALUES (N'Ty-204', 27, 6)
GO
INSERT [dbo].[AirPlaneTypes] ([Types], [All_Rows], [Bussnes_Rows]) VALUES (N'Wwww', 12, 1)
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (0, N'Moscow', N'Moscow region.', 2, N'Sheremetyevo')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (1, N'Moscow', N'Moscow region.', 2, N'Domodedovo')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (2, N'Moscow', N'Moscow region.', 2, N'Vnukovo')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (3, N'Saint-Peterburg', N'Peterburg region.', 2, N'Pulcovo')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (4, N'Abakan', N'Abakan region.', 2, N'Abakan')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (5, N'Agzy', N'Agzy region.', 2, N'Agzy')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (6, N'Adamovka', N'Adamovka region.', 2, N'Adamovka')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (7, N'Ahal', N'Ahal region.', 2, N'Ahal')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (8, N'Aldan', N'Aldan region.', 2, N'Aldan')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (9, N'Amgy', N'Amgy region.', 2, N'Amgy')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (10, N'Anabar', N'Anabar region.', 2, N'Anabar')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (11, N'Anadir''', N'Anadir'' region.', 2, N'Anadir''')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (12, N'Arhangelsk', N'Arhangelsk region.', 2, N'Arhangelsk')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (13, N'Astrachan''', N'Astrachan'' region.', 2, N'Astrachan''')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (14, N'Achinsk', N'Achinsk region.', 2, N'Achinsk')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (15, N'Ayan', N'Ayan region.', 2, N'Ayan')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (16, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (17, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (18, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (19, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (20, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (21, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (22, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (23, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (24, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (25, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (26, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (27, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (28, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (29, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (30, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (31, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (32, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (33, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (34, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (35, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (36, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (37, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (38, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (39, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (40, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (41, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (42, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (43, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (44, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (45, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (46, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (47, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (48, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (49, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (50, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (51, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (52, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (53, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (54, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (55, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (56, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (57, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (58, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (59, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (60, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (61, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (62, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (63, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[AirPort] ([AirPort_Num], [City], [Adress], [Runway], [Name]) VALUES (64, N'1', N'1', 1, N'1')
GO
INSERT [dbo].[Flights] ([Flight_Num], [Filight_Date], [Point_Of_Departure], [Destination], [Duration], [AirPlane_Num], [Pilot_Num], [AirPortTO_Num], [AirPortFrom_Num]) VALUES (0, CAST(N'2020-05-10T00:00:00.000' AS DateTime), N'Sheremetyevo', N'Abakan', CAST(N'02:00:00' AS Time), 1, 0, 4, 0)
GO
INSERT [dbo].[Flights] ([Flight_Num], [Filight_Date], [Point_Of_Departure], [Destination], [Duration], [AirPlane_Num], [Pilot_Num], [AirPortTO_Num], [AirPortFrom_Num]) VALUES (1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), N'Sheremetyevo', N'Abakan', CAST(N'02:00:00' AS Time), 1, 0, 4, 0)
GO
INSERT [dbo].[Flights] ([Flight_Num], [Filight_Date], [Point_Of_Departure], [Destination], [Duration], [AirPlane_Num], [Pilot_Num], [AirPortTO_Num], [AirPortFrom_Num]) VALUES (2, CAST(N'2020-05-10T00:00:00.000' AS DateTime), N'Sheremetyevo', N'Abakan', CAST(N'02:00:00' AS Time), 1, 0, 4, 0)
GO
INSERT [dbo].[Flights] ([Flight_Num], [Filight_Date], [Point_Of_Departure], [Destination], [Duration], [AirPlane_Num], [Pilot_Num], [AirPortTO_Num], [AirPortFrom_Num]) VALUES (3, CAST(N'2020-05-10T00:00:00.000' AS DateTime), N'Sheremetyevo', N'Abakan', CAST(N'02:00:00' AS Time), 1, 0, 4, 0)
GO
INSERT [dbo].[Flights] ([Flight_Num], [Filight_Date], [Point_Of_Departure], [Destination], [Duration], [AirPlane_Num], [Pilot_Num], [AirPortTO_Num], [AirPortFrom_Num]) VALUES (4, CAST(N'2020-05-10T00:00:00.000' AS DateTime), N'Sheremetyevo', N'Abakan', CAST(N'02:00:00' AS Time), 1, 0, 4, 0)
GO
INSERT [dbo].[Flights] ([Flight_Num], [Filight_Date], [Point_Of_Departure], [Destination], [Duration], [AirPlane_Num], [Pilot_Num], [AirPortTO_Num], [AirPortFrom_Num]) VALUES (5, CAST(N'2020-05-10T00:00:00.000' AS DateTime), N'Sheremetyevo', N'Abakan', CAST(N'02:00:00' AS Time), 1, 0, 4, 0)
GO
INSERT [dbo].[Flights] ([Flight_Num], [Filight_Date], [Point_Of_Departure], [Destination], [Duration], [AirPlane_Num], [Pilot_Num], [AirPortTO_Num], [AirPortFrom_Num]) VALUES (6, CAST(N'2020-05-10T00:00:00.000' AS DateTime), N'Sheremetyevo', N'Abakan', CAST(N'02:00:00' AS Time), 1, 0, 4, 0)
GO
INSERT [dbo].[Flights] ([Flight_Num], [Filight_Date], [Point_Of_Departure], [Destination], [Duration], [AirPlane_Num], [Pilot_Num], [AirPortTO_Num], [AirPortFrom_Num]) VALUES (7, CAST(N'2020-05-10T00:00:00.000' AS DateTime), N'Sheremetyevo', N'Abakan', CAST(N'02:00:00' AS Time), 1, 0, 4, 0)
GO
INSERT [dbo].[Flights] ([Flight_Num], [Filight_Date], [Point_Of_Departure], [Destination], [Duration], [AirPlane_Num], [Pilot_Num], [AirPortTO_Num], [AirPortFrom_Num]) VALUES (8, CAST(N'2020-05-10T00:00:00.000' AS DateTime), N'Sheremetyevo', N'Abakan', CAST(N'02:00:00' AS Time), 1, 0, 4, 0)
GO
INSERT [dbo].[Flights] ([Flight_Num], [Filight_Date], [Point_Of_Departure], [Destination], [Duration], [AirPlane_Num], [Pilot_Num], [AirPortTO_Num], [AirPortFrom_Num]) VALUES (9, CAST(N'2020-05-17T00:00:00.000' AS DateTime), N'Sheremetyevo', N'Abakan', CAST(N'02:00:00' AS Time), 1, 0, 4, 0)
GO
INSERT [dbo].[Login_Password] ([Login], [Password], [Role], [Id], [Password_Number], [Password_Sires]) VALUES (N'2', N'2', 0, 0, 2, 2)
GO
INSERT [dbo].[Login_Password] ([Login], [Password], [Role], [Id], [Password_Number], [Password_Sires]) VALUES (N'Admin', N'Admin', 2, 0, NULL, NULL)
GO
INSERT [dbo].[Login_Password] ([Login], [Password], [Role], [Id], [Password_Number], [Password_Sires]) VALUES (N'Admin1', N'Admin1', 2, 0, NULL, NULL)
GO
INSERT [dbo].[Login_Password] ([Login], [Password], [Role], [Id], [Password_Number], [Password_Sires]) VALUES (N'Pas', N'Pas', 0, 0, 1, 1)
GO
INSERT [dbo].[Login_Password] ([Login], [Password], [Role], [Id], [Password_Number], [Password_Sires]) VALUES (N'Pilot', N'Pilot', 1, 0, NULL, NULL)
GO
INSERT [dbo].[Passengers] ([Passport_Number], [Passport_Series], [Citizenship], [Gender], [Surname], [Name], [Middle_Name], [login], [password]) VALUES (1, 1, N'Pas', N'M', N'Pas', N'Pas', N'Pas', N'Pas', N'Pas')
GO
INSERT [dbo].[Passengers] ([Passport_Number], [Passport_Series], [Citizenship], [Gender], [Surname], [Name], [Middle_Name], [login], [password]) VALUES (2, 2, N'2', N'M', N'2', N'2', N'2', N'2', N'2')
GO
INSERT [dbo].[Pilots] ([Pilot_Num], [Hire_Date], [Gender], [Adress], [Phone_Number], [Surname], [Middle_Name], [Name], [Login], [Password]) VALUES (0, CAST(N'2002-12-05' AS Date), N'M', N'-', N'-', N'Wow', N'-', N'Pilot', N'Pilot', N'Pilot')
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 26)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 27)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 28)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 29)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 30)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 31)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 32)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 33)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 34)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 35)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 36)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 37)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 38)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 39)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 40)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 41)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 1, 42)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 26)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 27)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 28)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 29)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 30)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 31)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 32)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 33)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 34)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 35)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 36)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 37)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 38)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 39)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 40)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 41)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 2, 42)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 26)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 27)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 28)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 29)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 30)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 31)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 32)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 33)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 34)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 35)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 36)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 37)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 38)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 39)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 40)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 41)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 3, 42)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 26)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 27)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 28)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 29)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 30)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 31)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 32)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 33)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 34)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 35)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 36)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 37)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 38)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 39)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 40)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 41)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 4, 42)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 26)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 27)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 28)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 29)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 30)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 31)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 32)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 33)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 34)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 35)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 36)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 37)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 38)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 39)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 40)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 41)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 5, 42)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 26)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 27)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 28)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 29)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 30)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 31)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 32)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 33)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 34)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 35)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 36)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 37)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 38)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 39)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 40)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 41)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (1, 6, 42)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 1, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 1, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 1, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 1, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 1, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 1, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 1, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 1, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 1, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 1, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 1, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 1, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 1, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 1, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 1, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 1, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 1, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 1, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 1, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 1, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 1, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 1, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 1, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 1, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 1, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 1, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 2, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 2, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 2, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 2, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 2, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 2, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 2, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 2, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 2, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 2, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 2, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 2, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 2, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 2, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 2, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 2, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 2, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 2, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 2, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 2, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 2, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 2, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 2, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 2, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 2, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 2, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 3, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 3, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 3, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 3, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 3, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 3, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 3, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 3, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 3, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 3, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 3, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 3, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 3, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 3, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 3, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 3, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 3, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 3, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 3, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 3, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 3, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 3, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 3, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 3, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 3, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 3, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 4, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 4, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 4, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 4, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 4, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 4, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 4, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 4, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 4, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 4, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 4, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 4, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 4, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 4, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 4, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 4, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 4, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 4, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 4, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 4, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 4, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 4, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 4, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 4, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 4, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 4, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 5, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 5, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 5, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 5, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 5, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 5, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 5, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 5, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 5, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 5, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 5, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 5, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 5, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 5, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 5, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 5, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 5, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 5, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 5, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 5, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 5, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 5, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 5, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 5, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 5, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 6, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 6, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 6, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 6, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 6, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 6, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 6, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 6, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 6, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 6, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 6, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 6, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 6, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 6, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 6, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 6, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 6, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 6, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 6, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 6, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 6, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 6, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 6, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 6, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (2, 6, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 26)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 27)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 28)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 29)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 30)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 31)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 32)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 33)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 34)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 35)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 36)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 37)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 38)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 39)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 40)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 41)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 42)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 43)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 44)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 45)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 46)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 47)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 48)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 49)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 50)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 51)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 52)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 53)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 54)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 55)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 56)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 57)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 58)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 59)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 60)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 61)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 62)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 63)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 64)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 65)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 66)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 67)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 68)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 69)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 70)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 71)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 72)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 73)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 74)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 1, 75)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 26)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 27)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 28)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 29)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 30)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 31)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 32)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 33)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 34)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 35)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 36)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 37)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 38)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 39)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 40)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 41)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 42)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 43)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 44)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 45)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 46)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 47)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 48)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 49)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 50)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 51)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 52)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 53)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 54)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 55)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 56)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 57)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 58)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 59)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 60)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 61)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 62)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 63)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 64)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 65)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 66)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 67)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 68)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 69)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 70)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 71)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 72)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 73)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 74)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 2, 75)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 26)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 27)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 28)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 29)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 30)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 31)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 32)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 33)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 34)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 35)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 36)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 37)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 38)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 39)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 40)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 41)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 42)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 43)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 44)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 45)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 46)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 47)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 48)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 49)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 50)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 51)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 52)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 53)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 54)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 55)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 56)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 57)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 58)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 59)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 60)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 61)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 62)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 63)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 64)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 65)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 66)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 67)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 68)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 69)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 70)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 71)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 72)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 73)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 74)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 3, 75)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 26)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 27)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 28)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 29)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 30)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 31)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 32)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 33)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 34)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 35)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 36)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 37)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 38)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 39)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 40)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 41)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 42)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 43)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 44)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 45)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 46)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 47)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 48)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 49)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 50)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 51)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 52)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 53)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 54)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 55)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 56)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 57)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 58)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 59)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 60)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 61)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 62)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 63)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 64)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 65)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 66)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 67)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 68)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 69)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 70)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 71)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 72)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 73)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 74)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 4, 75)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 26)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 27)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 28)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 29)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 30)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 31)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 32)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 33)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 34)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 35)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 36)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 37)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 38)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 39)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 40)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 41)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 42)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 43)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 44)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 45)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 46)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 47)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 48)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 49)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 50)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 51)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 52)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 53)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 54)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 55)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 56)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 57)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 58)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 59)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 60)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 61)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 62)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 63)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 64)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 65)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 66)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 67)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 68)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 69)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 70)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 71)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 72)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 73)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 74)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 5, 75)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 26)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 27)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 28)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 29)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 30)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 31)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 32)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 33)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 34)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 35)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 36)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 37)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 38)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 39)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 40)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 41)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 42)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 43)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 44)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 45)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 46)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 47)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 48)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 49)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 50)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 51)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 52)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 53)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 54)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 55)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 56)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 57)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 58)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 59)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 60)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 61)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 62)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 63)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 64)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 65)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 66)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 67)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 68)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 69)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 70)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 71)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 72)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 73)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 74)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (3, 6, 75)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 1, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 1, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 1, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 1, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 1, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 1, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 1, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 1, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 1, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 1, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 1, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 1, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 1, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 1, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 1, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 1, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 1, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 1, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 1, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 1, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 1, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 1, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 1, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 2, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 2, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 2, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 2, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 2, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 2, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 2, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 2, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 2, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 2, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 2, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 2, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 2, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 2, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 2, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 2, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 2, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 2, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 2, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 2, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 2, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 2, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 2, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 3, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 3, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 3, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 3, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 3, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 3, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 3, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 3, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 3, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 3, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 3, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 3, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 3, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 3, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 3, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 3, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 3, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 3, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 3, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 3, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 3, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 3, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 3, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 4, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 4, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 4, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 4, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 4, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 4, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 4, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 4, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 4, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 4, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 4, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 4, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 4, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 4, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 4, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 4, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 4, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 4, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 4, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 4, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 4, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 4, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 4, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 5, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 5, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 5, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 5, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 5, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 5, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 5, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 5, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 5, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 5, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 5, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 5, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 5, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 5, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 5, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 5, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 5, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 6, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 6, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 6, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 6, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 6, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 6, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 6, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 6, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 6, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 6, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 6, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 6, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 6, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 6, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 6, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 6, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (4, 6, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 1, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 1, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 1, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 1, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 1, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 1, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 1, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 1, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 1, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 1, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 1, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 1, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 1, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 1, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 1, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 1, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 1, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 1, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 1, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 1, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 1, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 1, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 1, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 1, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 1, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 1, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 1, 26)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 1, 27)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 1, 28)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 1, 29)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 1, 30)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 2, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 2, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 2, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 2, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 2, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 2, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 2, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 2, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 2, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 2, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 2, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 2, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 2, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 2, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 2, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 2, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 2, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 2, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 2, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 2, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 2, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 2, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 2, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 2, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 2, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 2, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 2, 26)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 2, 27)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 2, 28)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 2, 29)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 2, 30)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 3, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 3, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 3, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 3, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 3, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 3, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 3, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 3, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 3, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 3, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 3, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 3, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 3, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 3, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 3, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 3, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 3, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 3, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 3, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 3, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 3, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 3, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 3, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 3, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 3, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 3, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 3, 26)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 3, 27)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 3, 28)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 3, 29)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 3, 30)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 4, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 4, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 4, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 4, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 4, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 4, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 4, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 4, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 4, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 4, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 4, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 4, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 4, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 4, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 4, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 4, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 4, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 4, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 4, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 4, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 4, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 4, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 4, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 4, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 4, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 4, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 4, 26)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 4, 27)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 4, 28)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 4, 29)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 4, 30)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 5, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 5, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 5, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 5, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 5, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 5, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 5, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 5, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 5, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 5, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 5, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 5, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 5, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 5, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 5, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 5, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 5, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 5, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 5, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 5, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 5, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 5, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 5, 26)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 5, 27)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 5, 28)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 5, 29)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 5, 30)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 6, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 6, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 6, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 6, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 6, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 6, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 6, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 6, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 6, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 6, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 6, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 6, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 6, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 6, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 6, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 6, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 6, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 6, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 6, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 6, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 6, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 6, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 6, 26)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 6, 27)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 6, 28)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 6, 29)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (5, 6, 30)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 1, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 1, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 1, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 1, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 1, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 1, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 1, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 1, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 1, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 1, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 1, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 1, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 1, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 1, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 1, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 1, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 1, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 1, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 2, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 2, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 2, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 2, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 2, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 2, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 2, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 2, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 2, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 2, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 2, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 2, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 2, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 2, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 2, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 2, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 2, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 2, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 3, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 3, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 3, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 3, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 3, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 3, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 3, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 3, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 3, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 3, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 3, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 3, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 3, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 3, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 3, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 3, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 3, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 3, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 4, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 4, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 4, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 4, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 4, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 4, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 4, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 4, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 4, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 4, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 4, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 4, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 4, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 4, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 4, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 4, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 4, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 4, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 5, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 5, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 5, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 5, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 5, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 5, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 5, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 5, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 5, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 5, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 5, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 5, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 5, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 5, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 5, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 5, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 6, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 6, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 6, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 6, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 6, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 6, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 6, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 6, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 6, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 6, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 6, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 6, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 6, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 6, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 6, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (6, 6, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 1, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 1, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 1, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 1, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 1, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 1, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 1, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 1, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 1, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 1, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 1, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 1, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 1, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 1, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 1, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 1, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 1, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 1, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 2, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 2, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 2, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 2, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 2, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 2, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 2, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 2, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 2, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 2, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 2, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 2, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 2, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 2, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 2, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 2, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 2, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 2, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 3, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 3, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 3, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 3, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 3, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 3, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 3, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 3, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 3, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 3, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 3, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 3, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 3, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 3, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 3, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 3, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 3, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 3, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 4, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 4, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 4, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 4, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 4, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 4, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 4, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 4, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 4, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 4, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 4, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 4, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 4, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 4, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 4, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 4, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 4, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 4, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 5, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 5, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 5, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 5, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 5, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 5, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 5, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 5, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 5, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 5, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 5, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 5, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 5, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 5, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 5, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 5, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 6, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 6, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 6, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 6, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 6, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 6, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 6, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 6, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 6, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 6, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 6, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 6, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 6, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 6, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 6, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (7, 6, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 1, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 1, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 1, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 1, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 1, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 1, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 1, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 1, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 1, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 1, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 1, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 1, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 1, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 1, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 1, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 1, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 1, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 1, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 1, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 1, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 1, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 1, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 2, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 2, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 2, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 2, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 2, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 2, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 2, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 2, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 2, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 2, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 2, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 2, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 2, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 2, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 2, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 2, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 2, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 2, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 2, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 2, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 2, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 2, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 3, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 3, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 3, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 3, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 3, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 3, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 3, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 3, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 3, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 3, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 3, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 3, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 3, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 3, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 3, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 3, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 3, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 3, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 3, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 3, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 3, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 3, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 4, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 4, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 4, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 4, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 4, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 4, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 4, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 4, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 4, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 4, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 4, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 4, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 4, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 4, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 4, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 4, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 4, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 4, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 4, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 4, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 4, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 4, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 5, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 5, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 5, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 5, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 5, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 5, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 5, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 5, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 5, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 5, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 5, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 5, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 5, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 5, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 5, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 5, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 6, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 6, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 6, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 6, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 6, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 6, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 6, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 6, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 6, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 6, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 6, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 6, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 6, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 6, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 6, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (8, 6, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 26)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 27)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 28)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 29)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 30)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 31)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 32)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 33)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 34)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 35)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 36)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 37)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 38)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 39)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 40)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 41)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 42)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 43)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 44)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 45)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 46)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 47)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 48)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 49)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 50)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 51)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 52)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 53)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 54)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 55)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 56)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 57)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 58)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 59)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 60)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 1, 61)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 26)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 27)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 28)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 29)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 30)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 31)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 32)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 33)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 34)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 35)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 36)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 37)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 38)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 39)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 40)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 41)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 42)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 43)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 44)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 45)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 46)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 47)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 48)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 49)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 50)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 51)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 52)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 53)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 54)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 55)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 56)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 57)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 58)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 59)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 60)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 2, 61)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 26)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 27)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 28)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 29)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 30)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 31)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 32)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 33)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 34)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 35)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 36)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 37)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 38)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 39)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 40)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 41)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 42)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 43)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 44)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 45)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 46)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 47)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 48)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 49)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 50)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 51)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 52)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 53)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 54)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 55)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 56)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 57)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 58)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 59)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 60)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 3, 61)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 26)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 27)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 28)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 29)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 30)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 31)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 32)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 33)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 34)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 35)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 36)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 37)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 38)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 39)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 40)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 41)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 42)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 43)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 44)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 45)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 46)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 47)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 48)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 49)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 50)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 51)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 52)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 53)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 54)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 55)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 56)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 57)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 58)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 59)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 60)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 4, 61)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 26)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 27)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 28)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 29)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 30)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 31)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 32)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 33)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 34)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 35)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 36)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 37)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 38)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 39)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 40)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 41)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 42)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 43)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 44)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 45)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 46)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 47)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 48)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 49)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 50)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 51)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 52)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 53)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 54)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 55)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 56)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 57)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 58)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 59)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 60)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 5, 61)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 26)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 27)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 28)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 29)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 30)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 31)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 32)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 33)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 34)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 35)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 36)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 37)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 38)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 39)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 40)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 41)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 42)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 43)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 44)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 45)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 46)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 47)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 48)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 49)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 50)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 51)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 52)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 53)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 54)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 55)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 56)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 57)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 58)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 59)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 60)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (9, 6, 61)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 26)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 27)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 28)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 29)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 30)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 31)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 32)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 33)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 34)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 35)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 36)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 37)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 38)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 39)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 40)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 41)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 1, 42)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 26)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 27)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 28)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 29)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 30)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 31)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 32)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 33)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 34)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 35)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 36)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 37)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 38)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 39)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 40)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 41)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 2, 42)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 26)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 27)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 28)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 29)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 30)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 31)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 32)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 33)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 34)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 35)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 36)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 37)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 38)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 39)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 40)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 41)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 3, 42)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 26)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 27)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 28)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 29)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 30)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 31)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 32)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 33)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 34)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 35)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 36)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 37)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 38)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 39)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 40)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 41)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 4, 42)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 26)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 27)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 28)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 29)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 30)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 31)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 32)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 33)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 34)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 35)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 36)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 37)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 38)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 39)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 40)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 41)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 5, 42)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 26)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 27)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 28)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 29)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 30)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 31)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 32)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 33)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 34)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 35)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 36)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 37)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 38)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 39)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 40)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 41)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (10, 6, 42)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 1, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 1, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 1, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 1, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 1, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 1, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 1, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 1, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 1, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 1, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 1, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 1, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 2, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 2, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 2, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 2, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 2, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 2, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 2, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 2, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 2, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 2, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 2, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 2, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 3, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 3, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 3, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 3, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 3, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 3, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 3, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 3, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 3, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 3, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 3, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 3, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 4, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 4, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 4, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 4, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 4, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 4, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 4, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 4, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 4, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 4, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 4, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 4, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 5, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 5, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 5, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 5, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 5, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 5, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 5, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 5, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 5, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 5, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 5, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 6, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 6, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 6, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 6, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 6, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 6, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 6, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 6, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 6, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 6, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (11, 6, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 26)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 27)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 28)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 29)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 30)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 31)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 32)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 33)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 34)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 35)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 36)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 37)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 38)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 39)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 40)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 41)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 1, 42)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 26)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 27)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 28)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 29)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 30)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 31)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 32)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 33)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 34)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 35)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 36)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 37)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 38)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 39)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 40)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 41)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 2, 42)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 26)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 27)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 28)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 29)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 30)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 31)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 32)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 33)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 34)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 35)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 36)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 37)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 38)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 39)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 40)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 41)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 3, 42)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 0)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 1)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 26)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 27)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 28)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 29)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 30)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 31)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 32)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 33)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 34)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 35)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 36)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 37)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 38)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 39)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 40)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 41)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 4, 42)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 26)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 27)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 28)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 29)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 30)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 31)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 32)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 33)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 34)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 35)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 36)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 37)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 38)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 39)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 40)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 41)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 5, 42)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 2)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 3)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 4)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 5)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 6)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 7)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 8)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 9)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 10)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 11)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 12)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 13)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 14)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 15)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 16)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 17)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 18)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 19)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 20)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 21)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 22)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 23)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 24)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 25)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 26)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 27)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 28)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 29)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 30)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 31)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 32)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 33)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 34)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 35)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 36)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 37)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 38)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 39)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 40)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 41)
GO
INSERT [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num]) VALUES (12, 6, 42)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (0, 0, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 0, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (1, 2, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 0, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (2, 2, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 1, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (3, 2, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 2, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (4, 2, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 3, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (5, 2, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 4, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (6, 2, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 5, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (7, 2, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 6, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (8, 2, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 7, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (9, 0, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 1, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (10, 0, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 2, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (11, 0, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 3, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (12, 0, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 4, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (13, 0, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 5, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (14, 0, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 6, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (15, 0, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 7, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (16, 0, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 8, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (17, 5, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 0, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (18, 0, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 9, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (19, 0, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 10, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (20, 0, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 11, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (21, 0, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 12, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (22, 0, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 13, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (23, 0, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 14, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (24, 0, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 15, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (25, 0, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 16, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (26, 0, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 17, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (27, 0, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 18, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (28, 0, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 19, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (29, 0, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 20, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (30, 0, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 21, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (31, 0, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 22, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (32, 0, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 23, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (33, 0, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 24, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (34, 0, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 25, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (35, 0, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 26, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (36, 0, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 27, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (37, 0, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 28, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (38, 0, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 29, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (39, 0, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 30, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (40, 2, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 8, 1)
GO
INSERT [dbo].[Tickets_Sold] ([Ticket_Num], [Flight_Num], [Passport_Num], [Passport_Series], [Flight_Date], [Place_Num], [Row_Num], [AirPlane_Num]) VALUES (41, 2, 1, 1, CAST(N'2020-05-10T00:00:00.000' AS DateTime), 1, 9, 1)
GO
ALTER TABLE [dbo].[Admins]  WITH CHECK ADD  CONSTRAINT [FK_Admins_Login_Password] FOREIGN KEY([Login], [Password])
REFERENCES [dbo].[Login_Password] ([Login], [Password])
GO
ALTER TABLE [dbo].[Admins] CHECK CONSTRAINT [FK_Admins_Login_Password]
GO
ALTER TABLE [dbo].[AirPlanes]  WITH CHECK ADD  CONSTRAINT [FK_AirPlanes_AirPlaneTypes] FOREIGN KEY([Type])
REFERENCES [dbo].[AirPlaneTypes] ([Types])
GO
ALTER TABLE [dbo].[AirPlanes] CHECK CONSTRAINT [FK_AirPlanes_AirPlaneTypes]
GO
ALTER TABLE [dbo].[AirPlanes]  WITH CHECK ADD  CONSTRAINT [FK_AirPlanes_AirPort] FOREIGN KEY([AirPort_Num])
REFERENCES [dbo].[AirPort] ([AirPort_Num])
GO
ALTER TABLE [dbo].[AirPlanes] CHECK CONSTRAINT [FK_AirPlanes_AirPort]
GO
ALTER TABLE [dbo].[Flights]  WITH CHECK ADD  CONSTRAINT [FK_Flights_AirPlanes] FOREIGN KEY([AirPlane_Num])
REFERENCES [dbo].[AirPlanes] ([AirPlane_Num])
GO
ALTER TABLE [dbo].[Flights] CHECK CONSTRAINT [FK_Flights_AirPlanes]
GO
ALTER TABLE [dbo].[Flights]  WITH CHECK ADD  CONSTRAINT [FK_Flights_Pilots] FOREIGN KEY([Pilot_Num])
REFERENCES [dbo].[Pilots] ([Pilot_Num])
GO
ALTER TABLE [dbo].[Flights] CHECK CONSTRAINT [FK_Flights_Pilots]
GO
ALTER TABLE [dbo].[Passengers]  WITH CHECK ADD  CONSTRAINT [FK_Passengers_Login_Password] FOREIGN KEY([login], [password])
REFERENCES [dbo].[Login_Password] ([Login], [Password])
GO
ALTER TABLE [dbo].[Passengers] CHECK CONSTRAINT [FK_Passengers_Login_Password]
GO
ALTER TABLE [dbo].[Pilots]  WITH CHECK ADD  CONSTRAINT [FK_Pilots_Login_Password] FOREIGN KEY([Login], [Password])
REFERENCES [dbo].[Login_Password] ([Login], [Password])
GO
ALTER TABLE [dbo].[Pilots] CHECK CONSTRAINT [FK_Pilots_Login_Password]
GO
ALTER TABLE [dbo].[Seets_On_The_Plane]  WITH CHECK ADD  CONSTRAINT [FK_Seets_On_The_Plane_AirPlanes] FOREIGN KEY([AirPlane_Num])
REFERENCES [dbo].[AirPlanes] ([AirPlane_Num])
GO
ALTER TABLE [dbo].[Seets_On_The_Plane] CHECK CONSTRAINT [FK_Seets_On_The_Plane_AirPlanes]
GO
ALTER TABLE [dbo].[Tickets_Sold]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_Sold_Flights] FOREIGN KEY([Flight_Num], [Flight_Date])
REFERENCES [dbo].[Flights] ([Flight_Num], [Filight_Date])
GO
ALTER TABLE [dbo].[Tickets_Sold] CHECK CONSTRAINT [FK_Tickets_Sold_Flights]
GO
ALTER TABLE [dbo].[Tickets_Sold]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_Sold_Passengers1] FOREIGN KEY([Passport_Num], [Passport_Series])
REFERENCES [dbo].[Passengers] ([Passport_Number], [Passport_Series])
GO
ALTER TABLE [dbo].[Tickets_Sold] CHECK CONSTRAINT [FK_Tickets_Sold_Passengers1]
GO
ALTER TABLE [dbo].[Tickets_Sold]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_Sold_Seets_On_The_Plane] FOREIGN KEY([AirPlane_Num], [Place_Num], [Row_Num])
REFERENCES [dbo].[Seets_On_The_Plane] ([AirPlane_Num], [Place_Num], [Row_Num])
GO
ALTER TABLE [dbo].[Tickets_Sold] CHECK CONSTRAINT [FK_Tickets_Sold_Seets_On_The_Plane]
GO
USE [master]
GO
ALTER DATABASE [AirPort] SET  READ_WRITE 
GO
