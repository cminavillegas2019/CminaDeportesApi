USE [master]
GO
/****** Object:  Database [DeportesApi]    Script Date: 02/16/2025 14:10:16 ******/
CREATE DATABASE [DeportesApi] ON  PRIMARY 
( NAME = N'DeportesApi', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\DeportesApi.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DeportesApi_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\DeportesApi_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DeportesApi] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DeportesApi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DeportesApi] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [DeportesApi] SET ANSI_NULLS OFF
GO
ALTER DATABASE [DeportesApi] SET ANSI_PADDING OFF
GO
ALTER DATABASE [DeportesApi] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [DeportesApi] SET ARITHABORT OFF
GO
ALTER DATABASE [DeportesApi] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [DeportesApi] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [DeportesApi] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [DeportesApi] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [DeportesApi] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [DeportesApi] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [DeportesApi] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [DeportesApi] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [DeportesApi] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [DeportesApi] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [DeportesApi] SET  DISABLE_BROKER
GO
ALTER DATABASE [DeportesApi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [DeportesApi] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [DeportesApi] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [DeportesApi] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [DeportesApi] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [DeportesApi] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [DeportesApi] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [DeportesApi] SET  READ_WRITE
GO
ALTER DATABASE [DeportesApi] SET RECOVERY FULL
GO
ALTER DATABASE [DeportesApi] SET  MULTI_USER
GO
ALTER DATABASE [DeportesApi] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [DeportesApi] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'DeportesApi', N'ON'
GO
USE [DeportesApi]
GO
/****** Object:  Table [dbo].[Deportistas]    Script Date: 02/16/2025 14:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deportistas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Pais] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Deportistas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Deportistas] ON
INSERT [dbo].[Deportistas] ([Id], [Nombre], [Pais]) VALUES (1, N'Anthony Boral', N'COL')
INSERT [dbo].[Deportistas] ([Id], [Nombre], [Pais]) VALUES (2, N'Marcela Lopez', N'CHN')
INSERT [dbo].[Deportistas] ([Id], [Nombre], [Pais]) VALUES (3, N'Alejandra Ortega', N'AUS')
INSERT [dbo].[Deportistas] ([Id], [Nombre], [Pais]) VALUES (4, N'Raul Mina', N'ECU')
INSERT [dbo].[Deportistas] ([Id], [Nombre], [Pais]) VALUES (5, N'Teresa Sanchez', N'MEX')
INSERT [dbo].[Deportistas] ([Id], [Nombre], [Pais]) VALUES (6, N'Yadira Cajape', N'ECU')
INSERT [dbo].[Deportistas] ([Id], [Nombre], [Pais]) VALUES (7, N'Carlos Lopez', N'MEX')
INSERT [dbo].[Deportistas] ([Id], [Nombre], [Pais]) VALUES (8, N'Ana Paula', N'ECU')
INSERT [dbo].[Deportistas] ([Id], [Nombre], [Pais]) VALUES (9, N'JOSE JOSE', N'MEX')
INSERT [dbo].[Deportistas] ([Id], [Nombre], [Pais]) VALUES (10, N'PEPE GRILLO', N'COL')
SET IDENTITY_INSERT [dbo].[Deportistas] OFF
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 02/16/2025 14:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250214043811_InitialCreate', N'8.0.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250214190928_LogTable', N'8.0.13')
/****** Object:  Table [dbo].[Logs]    Script Date: 02/16/2025 14:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[Timestamp] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Logs] ON
INSERT [dbo].[Logs] ([Id], [Message], [Timestamp]) VALUES (10, N'Nuevo intento registrado para Deportista 10: Envion - 950kg', CAST(0x07F65745819FE1470B AS DateTime2))
INSERT [dbo].[Logs] ([Id], [Message], [Timestamp]) VALUES (11, N'Nuevo intento registrado para Deportista 10: Arranque - 1000kg', CAST(0x07A28856989FE1470B AS DateTime2))
SET IDENTITY_INSERT [dbo].[Logs] OFF
/****** Object:  Table [dbo].[Intentos]    Script Date: 02/16/2025 14:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Intentos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DeportistaId] [int] NOT NULL,
	[Modalidad] [nvarchar](max) NOT NULL,
	[Peso] [int] NOT NULL,
 CONSTRAINT [PK_Intentos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Intentos_DeportistaId] ON [dbo].[Intentos] 
(
	[DeportistaId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Intentos] ON
INSERT [dbo].[Intentos] ([Id], [DeportistaId], [Modalidad], [Peso]) VALUES (1, 1, N'Envion', 177)
INSERT [dbo].[Intentos] ([Id], [DeportistaId], [Modalidad], [Peso]) VALUES (2, 1, N'Arranque', 134)
INSERT [dbo].[Intentos] ([Id], [DeportistaId], [Modalidad], [Peso]) VALUES (4, 2, N'Envion', 180)
INSERT [dbo].[Intentos] ([Id], [DeportistaId], [Modalidad], [Peso]) VALUES (5, 2, N'Arranque', 130)
INSERT [dbo].[Intentos] ([Id], [DeportistaId], [Modalidad], [Peso]) VALUES (6, 3, N'Envion', 150)
INSERT [dbo].[Intentos] ([Id], [DeportistaId], [Modalidad], [Peso]) VALUES (7, 3, N'Arranque', 0)
INSERT [dbo].[Intentos] ([Id], [DeportistaId], [Modalidad], [Peso]) VALUES (8, 4, N'Envion', 0)
INSERT [dbo].[Intentos] ([Id], [DeportistaId], [Modalidad], [Peso]) VALUES (9, 4, N'Arranque', 100)
INSERT [dbo].[Intentos] ([Id], [DeportistaId], [Modalidad], [Peso]) VALUES (10, 5, N'Envion', 120)
INSERT [dbo].[Intentos] ([Id], [DeportistaId], [Modalidad], [Peso]) VALUES (11, 5, N'Arranque', 160)
INSERT [dbo].[Intentos] ([Id], [DeportistaId], [Modalidad], [Peso]) VALUES (13, 1, N'Arranque', 300)
INSERT [dbo].[Intentos] ([Id], [DeportistaId], [Modalidad], [Peso]) VALUES (14, 1, N'Envion', 250)
INSERT [dbo].[Intentos] ([Id], [DeportistaId], [Modalidad], [Peso]) VALUES (15, 1, N'Envion', 900)
INSERT [dbo].[Intentos] ([Id], [DeportistaId], [Modalidad], [Peso]) VALUES (16, 5, N'Envion', 550)
INSERT [dbo].[Intentos] ([Id], [DeportistaId], [Modalidad], [Peso]) VALUES (17, 5, N'Envion', 550)
INSERT [dbo].[Intentos] ([Id], [DeportistaId], [Modalidad], [Peso]) VALUES (18, 8, N'Envion', 200)
INSERT [dbo].[Intentos] ([Id], [DeportistaId], [Modalidad], [Peso]) VALUES (19, 8, N'Arranque', 600)
INSERT [dbo].[Intentos] ([Id], [DeportistaId], [Modalidad], [Peso]) VALUES (20, 9, N'Arranque', 100)
INSERT [dbo].[Intentos] ([Id], [DeportistaId], [Modalidad], [Peso]) VALUES (21, 9, N'Envion', 50)
INSERT [dbo].[Intentos] ([Id], [DeportistaId], [Modalidad], [Peso]) VALUES (22, 9, N'Envion', 150)
INSERT [dbo].[Intentos] ([Id], [DeportistaId], [Modalidad], [Peso]) VALUES (23, 5, N'Envion', 550)
INSERT [dbo].[Intentos] ([Id], [DeportistaId], [Modalidad], [Peso]) VALUES (24, 10, N'Envion', 950)
INSERT [dbo].[Intentos] ([Id], [DeportistaId], [Modalidad], [Peso]) VALUES (25, 10, N'Arranque', 1000)
INSERT [dbo].[Intentos] ([Id], [DeportistaId], [Modalidad], [Peso]) VALUES (26, 10, N'Arranque', 1500)
INSERT [dbo].[Intentos] ([Id], [DeportistaId], [Modalidad], [Peso]) VALUES (27, 10, N'Arranque', 2000)
SET IDENTITY_INSERT [dbo].[Intentos] OFF
/****** Object:  ForeignKey [FK_Intentos_Deportistas_DeportistaId]    Script Date: 02/16/2025 14:10:17 ******/
ALTER TABLE [dbo].[Intentos]  WITH CHECK ADD  CONSTRAINT [FK_Intentos_Deportistas_DeportistaId] FOREIGN KEY([DeportistaId])
REFERENCES [dbo].[Deportistas] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Intentos] CHECK CONSTRAINT [FK_Intentos_Deportistas_DeportistaId]
GO
