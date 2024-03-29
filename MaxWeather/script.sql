USE [master]
GO
/****** Object:  Database [WeatherBase]    Script Date: 11.03.2024 15:08:54 ******/
CREATE DATABASE [WeatherBase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WeatherBase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SERV1215\MSSQL\DATA\WeatherBase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'WeatherBase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SERV1215\MSSQL\DATA\WeatherBase_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [WeatherBase] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WeatherBase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WeatherBase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WeatherBase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WeatherBase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WeatherBase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WeatherBase] SET ARITHABORT OFF 
GO
ALTER DATABASE [WeatherBase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WeatherBase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WeatherBase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WeatherBase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WeatherBase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WeatherBase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WeatherBase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WeatherBase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WeatherBase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WeatherBase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WeatherBase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WeatherBase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WeatherBase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WeatherBase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WeatherBase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WeatherBase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WeatherBase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WeatherBase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [WeatherBase] SET  MULTI_USER 
GO
ALTER DATABASE [WeatherBase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WeatherBase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WeatherBase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WeatherBase] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [WeatherBase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [WeatherBase] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'WeatherBase', N'ON'
GO
ALTER DATABASE [WeatherBase] SET QUERY_STORE = OFF
GO
USE [WeatherBase]
GO
/****** Object:  User [user01]    Script Date: 11.03.2024 15:08:54 ******/
CREATE USER [user01] FOR LOGIN [user01] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 11.03.2024 15:08:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Conditions]    Script Date: 11.03.2024 15:08:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Conditions](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Conditions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Forecasts]    Script Date: 11.03.2024 15:08:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Forecasts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[time] [int] NOT NULL,
	[temperature] [int] NOT NULL,
	[condition] [int] NOT NULL,
 CONSTRAINT [PK_Forecasts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 11.03.2024 15:08:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Time]    Script Date: 11.03.2024 15:08:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Time](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[time] [time](7) NOT NULL,
	[is_night] [int] NOT NULL,
 CONSTRAINT [PK_Time] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11.03.2024 15:08:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[login] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[city] [int] NULL,
	[role] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Weather]    Script Date: 11.03.2024 15:08:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Weather](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[day] [date] NOT NULL,
	[city] [int] NOT NULL,
	[pressure] [int] NOT NULL,
	[humidity] [int] NOT NULL,
	[wind] [int] NOT NULL,
	[speed] [int] NOT NULL,
	[uv] [int] NOT NULL,
	[forecast] [int] NOT NULL,
 CONSTRAINT [PK_Weather] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Wind]    Script Date: 11.03.2024 15:08:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wind](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[direction] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Wind] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cities] ON 

INSERT [dbo].[Cities] ([id], [title]) VALUES (1, N'Казань')
INSERT [dbo].[Cities] ([id], [title]) VALUES (2, N'Москва')
INSERT [dbo].[Cities] ([id], [title]) VALUES (3, N'Саратов')
INSERT [dbo].[Cities] ([id], [title]) VALUES (4, N'Самара')
INSERT [dbo].[Cities] ([id], [title]) VALUES (5, N'Элиста')
SET IDENTITY_INSERT [dbo].[Cities] OFF
GO
SET IDENTITY_INSERT [dbo].[Conditions] ON 

INSERT [dbo].[Conditions] ([id], [title]) VALUES (1, N'Ясно')
INSERT [dbo].[Conditions] ([id], [title]) VALUES (2, N'Переменная облачность')
INSERT [dbo].[Conditions] ([id], [title]) VALUES (3, N'Облачно')
INSERT [dbo].[Conditions] ([id], [title]) VALUES (4, N'Пасмурно')
INSERT [dbo].[Conditions] ([id], [title]) VALUES (5, N'Гроза')
INSERT [dbo].[Conditions] ([id], [title]) VALUES (6, N'Осадки')
INSERT [dbo].[Conditions] ([id], [title]) VALUES (7, N'Сильные осадки')
INSERT [dbo].[Conditions] ([id], [title]) VALUES (8, N'Снег')
SET IDENTITY_INSERT [dbo].[Conditions] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([id], [title]) VALUES (1, N'User')
INSERT [dbo].[Roles] ([id], [title]) VALUES (2, N'Admin')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Time] ON 

INSERT [dbo].[Time] ([id], [time], [is_night]) VALUES (1, CAST(N'00:00:00' AS Time), 1)
INSERT [dbo].[Time] ([id], [time], [is_night]) VALUES (2, CAST(N'03:00:00' AS Time), 1)
INSERT [dbo].[Time] ([id], [time], [is_night]) VALUES (3, CAST(N'06:00:00' AS Time), 1)
INSERT [dbo].[Time] ([id], [time], [is_night]) VALUES (4, CAST(N'09:00:00' AS Time), 0)
INSERT [dbo].[Time] ([id], [time], [is_night]) VALUES (5, CAST(N'12:00:00' AS Time), 0)
INSERT [dbo].[Time] ([id], [time], [is_night]) VALUES (6, CAST(N'15:00:00' AS Time), 0)
INSERT [dbo].[Time] ([id], [time], [is_night]) VALUES (7, CAST(N'18:00:00' AS Time), 0)
INSERT [dbo].[Time] ([id], [time], [is_night]) VALUES (8, CAST(N'21:00:00' AS Time), 1)
INSERT [dbo].[Time] ([id], [time], [is_night]) VALUES (9, CAST(N'00:00:00' AS Time), 1)
SET IDENTITY_INSERT [dbo].[Time] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id], [login], [password], [city], [role]) VALUES (1, N'max', N'max', NULL, 2)
INSERT [dbo].[Users] ([id], [login], [password], [city], [role]) VALUES (2, N'admin', N'admin', NULL, 2)
INSERT [dbo].[Users] ([id], [login], [password], [city], [role]) VALUES (3, N'maxim', N'maxim', NULL, 1)
INSERT [dbo].[Users] ([id], [login], [password], [city], [role]) VALUES (4, N'user', N'user', NULL, 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Forecasts]  WITH CHECK ADD  CONSTRAINT [FK_Forecasts_Conditions] FOREIGN KEY([condition])
REFERENCES [dbo].[Conditions] ([id])
GO
ALTER TABLE [dbo].[Forecasts] CHECK CONSTRAINT [FK_Forecasts_Conditions]
GO
ALTER TABLE [dbo].[Forecasts]  WITH CHECK ADD  CONSTRAINT [FK_Forecasts_Time] FOREIGN KEY([time])
REFERENCES [dbo].[Time] ([id])
GO
ALTER TABLE [dbo].[Forecasts] CHECK CONSTRAINT [FK_Forecasts_Time]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Cities] FOREIGN KEY([city])
REFERENCES [dbo].[Cities] ([id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Cities]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([role])
REFERENCES [dbo].[Roles] ([id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
ALTER TABLE [dbo].[Weather]  WITH CHECK ADD  CONSTRAINT [FK_Weather_Cities] FOREIGN KEY([city])
REFERENCES [dbo].[Cities] ([id])
GO
ALTER TABLE [dbo].[Weather] CHECK CONSTRAINT [FK_Weather_Cities]
GO
ALTER TABLE [dbo].[Weather]  WITH CHECK ADD  CONSTRAINT [FK_Weather_Forecasts] FOREIGN KEY([forecast])
REFERENCES [dbo].[Forecasts] ([id])
GO
ALTER TABLE [dbo].[Weather] CHECK CONSTRAINT [FK_Weather_Forecasts]
GO
ALTER TABLE [dbo].[Weather]  WITH CHECK ADD  CONSTRAINT [FK_Weather_Wind] FOREIGN KEY([speed])
REFERENCES [dbo].[Wind] ([id])
GO
ALTER TABLE [dbo].[Weather] CHECK CONSTRAINT [FK_Weather_Wind]
GO
USE [master]
GO
ALTER DATABASE [WeatherBase] SET  READ_WRITE 
GO
