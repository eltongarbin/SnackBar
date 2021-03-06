USE [SnackBar]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PedidosLanches_Pedidos_PedidoId]') AND parent_object_id = OBJECT_ID(N'[dbo].[PedidosLanches]'))
ALTER TABLE [dbo].[PedidosLanches] DROP CONSTRAINT [FK_PedidosLanches_Pedidos_PedidoId]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PedidosLanches_Lanches_LancheId]') AND parent_object_id = OBJECT_ID(N'[dbo].[PedidosLanches]'))
ALTER TABLE [dbo].[PedidosLanches] DROP CONSTRAINT [FK_PedidosLanches_Lanches_LancheId]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LanchesPredefinidos_Lanches_LancheId]') AND parent_object_id = OBJECT_ID(N'[dbo].[LanchesPredefinidos]'))
ALTER TABLE [dbo].[LanchesPredefinidos] DROP CONSTRAINT [FK_LanchesPredefinidos_Lanches_LancheId]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LanchesPredefinidos_Ingredientes_IngredienteId]') AND parent_object_id = OBJECT_ID(N'[dbo].[LanchesPredefinidos]'))
ALTER TABLE [dbo].[LanchesPredefinidos] DROP CONSTRAINT [FK_LanchesPredefinidos_Ingredientes_IngredienteId]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LanchesCustomizados_PedidosLanches_PedidoLancheId]') AND parent_object_id = OBJECT_ID(N'[dbo].[LanchesCustomizados]'))
ALTER TABLE [dbo].[LanchesCustomizados] DROP CONSTRAINT [FK_LanchesCustomizados_PedidosLanches_PedidoLancheId]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LanchesCustomizados_Ingredientes_IngredienteId]') AND parent_object_id = OBJECT_ID(N'[dbo].[LanchesCustomizados]'))
ALTER TABLE [dbo].[LanchesCustomizados] DROP CONSTRAINT [FK_LanchesCustomizados_Ingredientes_IngredienteId]
GO
/****** Object:  Index [IX_PedidosLanches_PedidoId]    Script Date: 08/08/2017 07:20:29 ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[PedidosLanches]') AND name = N'IX_PedidosLanches_PedidoId')
DROP INDEX [IX_PedidosLanches_PedidoId] ON [dbo].[PedidosLanches]
GO
/****** Object:  Index [IX_PedidosLanches_LancheId]    Script Date: 08/08/2017 07:20:29 ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[PedidosLanches]') AND name = N'IX_PedidosLanches_LancheId')
DROP INDEX [IX_PedidosLanches_LancheId] ON [dbo].[PedidosLanches]
GO
/****** Object:  Index [IX_LanchesPredefinidos_LancheId]    Script Date: 08/08/2017 07:20:29 ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[LanchesPredefinidos]') AND name = N'IX_LanchesPredefinidos_LancheId')
DROP INDEX [IX_LanchesPredefinidos_LancheId] ON [dbo].[LanchesPredefinidos]
GO
/****** Object:  Index [IX_LanchesPredefinidos_IngredienteId]    Script Date: 08/08/2017 07:20:29 ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[LanchesPredefinidos]') AND name = N'IX_LanchesPredefinidos_IngredienteId')
DROP INDEX [IX_LanchesPredefinidos_IngredienteId] ON [dbo].[LanchesPredefinidos]
GO
/****** Object:  Index [IX_LanchesCustomizados_PedidoLancheId]    Script Date: 08/08/2017 07:20:29 ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[LanchesCustomizados]') AND name = N'IX_LanchesCustomizados_PedidoLancheId')
DROP INDEX [IX_LanchesCustomizados_PedidoLancheId] ON [dbo].[LanchesCustomizados]
GO
/****** Object:  Index [IX_LanchesCustomizados_IngredienteId]    Script Date: 08/08/2017 07:20:29 ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[LanchesCustomizados]') AND name = N'IX_LanchesCustomizados_IngredienteId')
DROP INDEX [IX_LanchesCustomizados_IngredienteId] ON [dbo].[LanchesCustomizados]
GO
/****** Object:  Table [dbo].[PedidosLanches]    Script Date: 08/08/2017 07:20:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PedidosLanches]') AND type in (N'U'))
DROP TABLE [dbo].[PedidosLanches]
GO
/****** Object:  Table [dbo].[Pedidos]    Script Date: 08/08/2017 07:20:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Pedidos]') AND type in (N'U'))
DROP TABLE [dbo].[Pedidos]
GO
/****** Object:  Table [dbo].[LanchesPredefinidos]    Script Date: 08/08/2017 07:20:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LanchesPredefinidos]') AND type in (N'U'))
DROP TABLE [dbo].[LanchesPredefinidos]
GO
/****** Object:  Table [dbo].[LanchesCustomizados]    Script Date: 08/08/2017 07:20:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LanchesCustomizados]') AND type in (N'U'))
DROP TABLE [dbo].[LanchesCustomizados]
GO
/****** Object:  Table [dbo].[Lanches]    Script Date: 08/08/2017 07:20:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Lanches]') AND type in (N'U'))
DROP TABLE [dbo].[Lanches]
GO
/****** Object:  Table [dbo].[Ingredientes]    Script Date: 08/08/2017 07:20:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Ingredientes]') AND type in (N'U'))
DROP TABLE [dbo].[Ingredientes]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 08/08/2017 07:20:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[__EFMigrationsHistory]') AND type in (N'U'))
DROP TABLE [dbo].[__EFMigrationsHistory]
GO
USE [master]
GO
/****** Object:  Database [SnackBar]    Script Date: 08/08/2017 07:20:29 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'SnackBar')
DROP DATABASE [SnackBar]
GO
/****** Object:  Database [SnackBar]    Script Date: 08/08/2017 07:20:29 ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'SnackBar')
BEGIN
CREATE DATABASE [SnackBar]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SnackBar', FILENAME = N'C:\Users\elton\SnackBar.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SnackBar_log', FILENAME = N'C:\Users\elton\SnackBar_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
END

GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SnackBar].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SnackBar] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SnackBar] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SnackBar] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SnackBar] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SnackBar] SET ARITHABORT OFF 
GO
ALTER DATABASE [SnackBar] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [SnackBar] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SnackBar] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SnackBar] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SnackBar] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SnackBar] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SnackBar] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SnackBar] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SnackBar] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SnackBar] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SnackBar] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SnackBar] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SnackBar] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SnackBar] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SnackBar] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SnackBar] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [SnackBar] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SnackBar] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SnackBar] SET  MULTI_USER 
GO
ALTER DATABASE [SnackBar] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SnackBar] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SnackBar] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SnackBar] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
USE [SnackBar]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [SnackBar]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 08/08/2017 07:20:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[__EFMigrationsHistory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Ingredientes]    Script Date: 08/08/2017 07:20:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Ingredientes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Ingredientes](
	[Id] [uniqueidentifier] NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Valor] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Ingredientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Lanches]    Script Date: 08/08/2017 07:20:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Lanches]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Lanches](
	[Id] [uniqueidentifier] NOT NULL,
	[Nome] [nvarchar](20) NOT NULL,
	[Valor] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Lanches] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[LanchesCustomizados]    Script Date: 08/08/2017 07:20:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LanchesCustomizados]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LanchesCustomizados](
	[Id] [uniqueidentifier] NOT NULL,
	[IngredienteId] [uniqueidentifier] NOT NULL,
	[PedidoLancheId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_LanchesCustomizados] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[LanchesPredefinidos]    Script Date: 08/08/2017 07:20:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LanchesPredefinidos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LanchesPredefinidos](
	[Id] [uniqueidentifier] NOT NULL,
	[IngredienteId] [uniqueidentifier] NOT NULL,
	[LancheId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_LanchesPredefinidos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Pedidos]    Script Date: 08/08/2017 07:20:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Pedidos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Pedidos](
	[Id] [uniqueidentifier] NOT NULL,
	[Cliente] [nvarchar](150) NOT NULL,
	[DataCancelamento] [datetime2](7) NULL,
	[DataEntrega] [datetime2](7) NULL,
	[DataPedido] [datetime2](7) NOT NULL,
	[ValorTotal] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Pedidos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[PedidosLanches]    Script Date: 08/08/2017 07:20:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PedidosLanches]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PedidosLanches](
	[Id] [uniqueidentifier] NOT NULL,
	[Desconto] [decimal](18, 2) NOT NULL,
	[LancheId] [uniqueidentifier] NOT NULL,
	[PedidoId] [uniqueidentifier] NOT NULL,
	[Promocao] [nvarchar](20) NULL,
	[ValorTotal] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_PedidosLanches] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170808100943_Initial', N'1.1.2')
INSERT [dbo].[Ingredientes] ([Id], [Nome], [Valor]) VALUES (N'8e4bf5ac-6d24-4ca3-8a06-1dd444b2897b', N'Ovo', CAST(0.80 AS Decimal(18, 2)))
INSERT [dbo].[Ingredientes] ([Id], [Nome], [Valor]) VALUES (N'cd91ea55-3027-4188-bbed-4ec97d8ecae0', N'Hambúrguer de carne', CAST(3.00 AS Decimal(18, 2)))
INSERT [dbo].[Ingredientes] ([Id], [Nome], [Valor]) VALUES (N'6b2a4729-eb64-45ee-acb3-50baea44767d', N'Alface', CAST(0.40 AS Decimal(18, 2)))
INSERT [dbo].[Ingredientes] ([Id], [Nome], [Valor]) VALUES (N'bcbca956-7d39-4be5-8a48-91a2dc9dbeb4', N'Bacon', CAST(2.00 AS Decimal(18, 2)))
INSERT [dbo].[Ingredientes] ([Id], [Nome], [Valor]) VALUES (N'f993e8af-b3eb-40d5-aace-c79c5258bd6c', N'Queijo', CAST(1.50 AS Decimal(18, 2)))
INSERT [dbo].[Lanches] ([Id], [Nome], [Valor]) VALUES (N'da764df5-9ed4-46ac-9e2c-7aa9466c2db9', N'X-Egg', CAST(5.30 AS Decimal(18, 2)))
INSERT [dbo].[Lanches] ([Id], [Nome], [Valor]) VALUES (N'cbd4d7b6-edf0-4ab2-a0a3-973eeed90d8e', N'X-Bacon', CAST(6.50 AS Decimal(18, 2)))
INSERT [dbo].[Lanches] ([Id], [Nome], [Valor]) VALUES (N'8067fbf0-2864-463d-9f7f-c0054e40f4be', N'X-Egg Bacon', CAST(7.30 AS Decimal(18, 2)))
INSERT [dbo].[Lanches] ([Id], [Nome], [Valor]) VALUES (N'104b9889-fd89-4010-b300-f46ea0582889', N'X-Burger', CAST(4.50 AS Decimal(18, 2)))
INSERT [dbo].[LanchesCustomizados] ([Id], [IngredienteId], [PedidoLancheId]) VALUES (N'72a1c9a9-d630-4475-1fba-08d4de469b62', N'f993e8af-b3eb-40d5-aace-c79c5258bd6c', N'9d5aa8fc-f74f-4837-ba59-c223d3b4f9d5')
INSERT [dbo].[LanchesCustomizados] ([Id], [IngredienteId], [PedidoLancheId]) VALUES (N'acb0dadd-71be-4f7e-1fbb-08d4de469b62', N'cd91ea55-3027-4188-bbed-4ec97d8ecae0', N'9d5aa8fc-f74f-4837-ba59-c223d3b4f9d5')
INSERT [dbo].[LanchesCustomizados] ([Id], [IngredienteId], [PedidoLancheId]) VALUES (N'a153f0f2-ec9e-40ff-1fbc-08d4de469b62', N'cd91ea55-3027-4188-bbed-4ec97d8ecae0', N'9d5aa8fc-f74f-4837-ba59-c223d3b4f9d5')
INSERT [dbo].[LanchesCustomizados] ([Id], [IngredienteId], [PedidoLancheId]) VALUES (N'fa18294a-dff8-4bda-1fbd-08d4de469b62', N'cd91ea55-3027-4188-bbed-4ec97d8ecae0', N'9d5aa8fc-f74f-4837-ba59-c223d3b4f9d5')
INSERT [dbo].[LanchesCustomizados] ([Id], [IngredienteId], [PedidoLancheId]) VALUES (N'e9f69d63-c59a-4f95-1fbe-08d4de469b62', N'cd91ea55-3027-4188-bbed-4ec97d8ecae0', N'fabf3c54-ae99-4d2c-a31b-2b500acf11d7')
INSERT [dbo].[LanchesCustomizados] ([Id], [IngredienteId], [PedidoLancheId]) VALUES (N'7e5472cf-6742-4254-1fbf-08d4de469b62', N'f993e8af-b3eb-40d5-aace-c79c5258bd6c', N'fabf3c54-ae99-4d2c-a31b-2b500acf11d7')
INSERT [dbo].[LanchesCustomizados] ([Id], [IngredienteId], [PedidoLancheId]) VALUES (N'6857653f-5c52-47ed-1fc0-08d4de469b62', N'8e4bf5ac-6d24-4ca3-8a06-1dd444b2897b', N'fabf3c54-ae99-4d2c-a31b-2b500acf11d7')
INSERT [dbo].[LanchesCustomizados] ([Id], [IngredienteId], [PedidoLancheId]) VALUES (N'cd40c290-a8a6-4264-1fc1-08d4de469b62', N'f993e8af-b3eb-40d5-aace-c79c5258bd6c', N'68d3e702-75c4-4b24-9d64-da39549bb5f3')
INSERT [dbo].[LanchesCustomizados] ([Id], [IngredienteId], [PedidoLancheId]) VALUES (N'47848d71-1b09-4d04-1fc2-08d4de469b62', N'cd91ea55-3027-4188-bbed-4ec97d8ecae0', N'68d3e702-75c4-4b24-9d64-da39549bb5f3')
INSERT [dbo].[LanchesCustomizados] ([Id], [IngredienteId], [PedidoLancheId]) VALUES (N'061087e9-f9db-41cd-1fc3-08d4de469b62', N'6b2a4729-eb64-45ee-acb3-50baea44767d', N'68d3e702-75c4-4b24-9d64-da39549bb5f3')
INSERT [dbo].[LanchesPredefinidos] ([Id], [IngredienteId], [LancheId]) VALUES (N'a80346d8-bb8a-49e6-a2a9-0800d308d290', N'cd91ea55-3027-4188-bbed-4ec97d8ecae0', N'da764df5-9ed4-46ac-9e2c-7aa9466c2db9')
INSERT [dbo].[LanchesPredefinidos] ([Id], [IngredienteId], [LancheId]) VALUES (N'69986a10-1403-47ce-b577-2ac272feac51', N'bcbca956-7d39-4be5-8a48-91a2dc9dbeb4', N'8067fbf0-2864-463d-9f7f-c0054e40f4be')
INSERT [dbo].[LanchesPredefinidos] ([Id], [IngredienteId], [LancheId]) VALUES (N'4a4974f7-718a-42ef-9aee-373124c4853c', N'f993e8af-b3eb-40d5-aace-c79c5258bd6c', N'da764df5-9ed4-46ac-9e2c-7aa9466c2db9')
INSERT [dbo].[LanchesPredefinidos] ([Id], [IngredienteId], [LancheId]) VALUES (N'55ca3793-5eba-4811-8d6f-4809afe4e9b2', N'cd91ea55-3027-4188-bbed-4ec97d8ecae0', N'cbd4d7b6-edf0-4ab2-a0a3-973eeed90d8e')
INSERT [dbo].[LanchesPredefinidos] ([Id], [IngredienteId], [LancheId]) VALUES (N'92e100fc-94f2-40ad-83e2-513d43a6ecd0', N'8e4bf5ac-6d24-4ca3-8a06-1dd444b2897b', N'da764df5-9ed4-46ac-9e2c-7aa9466c2db9')
INSERT [dbo].[LanchesPredefinidos] ([Id], [IngredienteId], [LancheId]) VALUES (N'2d04eb69-aef5-4232-88f7-5b29adfae3d1', N'cd91ea55-3027-4188-bbed-4ec97d8ecae0', N'8067fbf0-2864-463d-9f7f-c0054e40f4be')
INSERT [dbo].[LanchesPredefinidos] ([Id], [IngredienteId], [LancheId]) VALUES (N'13d0926f-0661-4a68-92b2-6ea4ce193680', N'f993e8af-b3eb-40d5-aace-c79c5258bd6c', N'cbd4d7b6-edf0-4ab2-a0a3-973eeed90d8e')
INSERT [dbo].[LanchesPredefinidos] ([Id], [IngredienteId], [LancheId]) VALUES (N'35741ae8-e1ca-4597-8f5c-a15a43984041', N'f993e8af-b3eb-40d5-aace-c79c5258bd6c', N'104b9889-fd89-4010-b300-f46ea0582889')
INSERT [dbo].[LanchesPredefinidos] ([Id], [IngredienteId], [LancheId]) VALUES (N'479c8a6c-c37b-4c13-82ce-b4c0689ff3c6', N'cd91ea55-3027-4188-bbed-4ec97d8ecae0', N'104b9889-fd89-4010-b300-f46ea0582889')
INSERT [dbo].[LanchesPredefinidos] ([Id], [IngredienteId], [LancheId]) VALUES (N'bd76a3c1-79bc-4342-beae-cef8f71a53fc', N'bcbca956-7d39-4be5-8a48-91a2dc9dbeb4', N'cbd4d7b6-edf0-4ab2-a0a3-973eeed90d8e')
INSERT [dbo].[LanchesPredefinidos] ([Id], [IngredienteId], [LancheId]) VALUES (N'cc5f1321-b745-4320-970e-fe08141fb078', N'8e4bf5ac-6d24-4ca3-8a06-1dd444b2897b', N'8067fbf0-2864-463d-9f7f-c0054e40f4be')
INSERT [dbo].[LanchesPredefinidos] ([Id], [IngredienteId], [LancheId]) VALUES (N'7b3d7295-d69a-488a-b097-ffdb0b1ca948', N'f993e8af-b3eb-40d5-aace-c79c5258bd6c', N'8067fbf0-2864-463d-9f7f-c0054e40f4be')
INSERT [dbo].[Pedidos] ([Id], [Cliente], [DataCancelamento], [DataEntrega], [DataPedido], [ValorTotal]) VALUES (N'c78390b2-2cdc-43b2-82c2-0b3a468c9d47', N'Elton Garbin', NULL, NULL, CAST(N'2017-08-08T07:16:59.7058607' AS DateTime2), CAST(12.80 AS Decimal(18, 2)))
INSERT [dbo].[Pedidos] ([Id], [Cliente], [DataCancelamento], [DataEntrega], [DataPedido], [ValorTotal]) VALUES (N'941f1379-215d-485f-a91b-e4b39af0fc5d', N'Gabriel Wentland', NULL, NULL, CAST(N'2017-08-08T07:17:55.1245236' AS DateTime2), CAST(4.41 AS Decimal(18, 2)))
INSERT [dbo].[PedidosLanches] ([Id], [Desconto], [LancheId], [PedidoId], [Promocao], [ValorTotal]) VALUES (N'fabf3c54-ae99-4d2c-a31b-2b500acf11d7', CAST(0.00 AS Decimal(18, 2)), N'da764df5-9ed4-46ac-9e2c-7aa9466c2db9', N'c78390b2-2cdc-43b2-82c2-0b3a468c9d47', N'', CAST(5.30 AS Decimal(18, 2)))
INSERT [dbo].[PedidosLanches] ([Id], [Desconto], [LancheId], [PedidoId], [Promocao], [ValorTotal]) VALUES (N'9d5aa8fc-f74f-4837-ba59-c223d3b4f9d5', CAST(3.00 AS Decimal(18, 2)), N'104b9889-fd89-4010-b300-f46ea0582889', N'c78390b2-2cdc-43b2-82c2-0b3a468c9d47', N'Muita carne', CAST(7.50 AS Decimal(18, 2)))
INSERT [dbo].[PedidosLanches] ([Id], [Desconto], [LancheId], [PedidoId], [Promocao], [ValorTotal]) VALUES (N'68d3e702-75c4-4b24-9d64-da39549bb5f3', CAST(0.49 AS Decimal(18, 2)), N'104b9889-fd89-4010-b300-f46ea0582889', N'941f1379-215d-485f-a91b-e4b39af0fc5d', N'Light', CAST(4.41 AS Decimal(18, 2)))
/****** Object:  Index [IX_LanchesCustomizados_IngredienteId]    Script Date: 08/08/2017 07:20:29 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[LanchesCustomizados]') AND name = N'IX_LanchesCustomizados_IngredienteId')
CREATE NONCLUSTERED INDEX [IX_LanchesCustomizados_IngredienteId] ON [dbo].[LanchesCustomizados]
(
	[IngredienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_LanchesCustomizados_PedidoLancheId]    Script Date: 08/08/2017 07:20:29 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[LanchesCustomizados]') AND name = N'IX_LanchesCustomizados_PedidoLancheId')
CREATE NONCLUSTERED INDEX [IX_LanchesCustomizados_PedidoLancheId] ON [dbo].[LanchesCustomizados]
(
	[PedidoLancheId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_LanchesPredefinidos_IngredienteId]    Script Date: 08/08/2017 07:20:29 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[LanchesPredefinidos]') AND name = N'IX_LanchesPredefinidos_IngredienteId')
CREATE NONCLUSTERED INDEX [IX_LanchesPredefinidos_IngredienteId] ON [dbo].[LanchesPredefinidos]
(
	[IngredienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_LanchesPredefinidos_LancheId]    Script Date: 08/08/2017 07:20:29 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[LanchesPredefinidos]') AND name = N'IX_LanchesPredefinidos_LancheId')
CREATE NONCLUSTERED INDEX [IX_LanchesPredefinidos_LancheId] ON [dbo].[LanchesPredefinidos]
(
	[LancheId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PedidosLanches_LancheId]    Script Date: 08/08/2017 07:20:29 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[PedidosLanches]') AND name = N'IX_PedidosLanches_LancheId')
CREATE NONCLUSTERED INDEX [IX_PedidosLanches_LancheId] ON [dbo].[PedidosLanches]
(
	[LancheId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PedidosLanches_PedidoId]    Script Date: 08/08/2017 07:20:29 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[PedidosLanches]') AND name = N'IX_PedidosLanches_PedidoId')
CREATE NONCLUSTERED INDEX [IX_PedidosLanches_PedidoId] ON [dbo].[PedidosLanches]
(
	[PedidoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LanchesCustomizados_Ingredientes_IngredienteId]') AND parent_object_id = OBJECT_ID(N'[dbo].[LanchesCustomizados]'))
ALTER TABLE [dbo].[LanchesCustomizados]  WITH CHECK ADD  CONSTRAINT [FK_LanchesCustomizados_Ingredientes_IngredienteId] FOREIGN KEY([IngredienteId])
REFERENCES [dbo].[Ingredientes] ([Id])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LanchesCustomizados_Ingredientes_IngredienteId]') AND parent_object_id = OBJECT_ID(N'[dbo].[LanchesCustomizados]'))
ALTER TABLE [dbo].[LanchesCustomizados] CHECK CONSTRAINT [FK_LanchesCustomizados_Ingredientes_IngredienteId]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LanchesCustomizados_PedidosLanches_PedidoLancheId]') AND parent_object_id = OBJECT_ID(N'[dbo].[LanchesCustomizados]'))
ALTER TABLE [dbo].[LanchesCustomizados]  WITH CHECK ADD  CONSTRAINT [FK_LanchesCustomizados_PedidosLanches_PedidoLancheId] FOREIGN KEY([PedidoLancheId])
REFERENCES [dbo].[PedidosLanches] ([Id])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LanchesCustomizados_PedidosLanches_PedidoLancheId]') AND parent_object_id = OBJECT_ID(N'[dbo].[LanchesCustomizados]'))
ALTER TABLE [dbo].[LanchesCustomizados] CHECK CONSTRAINT [FK_LanchesCustomizados_PedidosLanches_PedidoLancheId]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LanchesPredefinidos_Ingredientes_IngredienteId]') AND parent_object_id = OBJECT_ID(N'[dbo].[LanchesPredefinidos]'))
ALTER TABLE [dbo].[LanchesPredefinidos]  WITH CHECK ADD  CONSTRAINT [FK_LanchesPredefinidos_Ingredientes_IngredienteId] FOREIGN KEY([IngredienteId])
REFERENCES [dbo].[Ingredientes] ([Id])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LanchesPredefinidos_Ingredientes_IngredienteId]') AND parent_object_id = OBJECT_ID(N'[dbo].[LanchesPredefinidos]'))
ALTER TABLE [dbo].[LanchesPredefinidos] CHECK CONSTRAINT [FK_LanchesPredefinidos_Ingredientes_IngredienteId]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LanchesPredefinidos_Lanches_LancheId]') AND parent_object_id = OBJECT_ID(N'[dbo].[LanchesPredefinidos]'))
ALTER TABLE [dbo].[LanchesPredefinidos]  WITH CHECK ADD  CONSTRAINT [FK_LanchesPredefinidos_Lanches_LancheId] FOREIGN KEY([LancheId])
REFERENCES [dbo].[Lanches] ([Id])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LanchesPredefinidos_Lanches_LancheId]') AND parent_object_id = OBJECT_ID(N'[dbo].[LanchesPredefinidos]'))
ALTER TABLE [dbo].[LanchesPredefinidos] CHECK CONSTRAINT [FK_LanchesPredefinidos_Lanches_LancheId]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PedidosLanches_Lanches_LancheId]') AND parent_object_id = OBJECT_ID(N'[dbo].[PedidosLanches]'))
ALTER TABLE [dbo].[PedidosLanches]  WITH CHECK ADD  CONSTRAINT [FK_PedidosLanches_Lanches_LancheId] FOREIGN KEY([LancheId])
REFERENCES [dbo].[Lanches] ([Id])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PedidosLanches_Lanches_LancheId]') AND parent_object_id = OBJECT_ID(N'[dbo].[PedidosLanches]'))
ALTER TABLE [dbo].[PedidosLanches] CHECK CONSTRAINT [FK_PedidosLanches_Lanches_LancheId]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PedidosLanches_Pedidos_PedidoId]') AND parent_object_id = OBJECT_ID(N'[dbo].[PedidosLanches]'))
ALTER TABLE [dbo].[PedidosLanches]  WITH CHECK ADD  CONSTRAINT [FK_PedidosLanches_Pedidos_PedidoId] FOREIGN KEY([PedidoId])
REFERENCES [dbo].[Pedidos] ([Id])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PedidosLanches_Pedidos_PedidoId]') AND parent_object_id = OBJECT_ID(N'[dbo].[PedidosLanches]'))
ALTER TABLE [dbo].[PedidosLanches] CHECK CONSTRAINT [FK_PedidosLanches_Pedidos_PedidoId]
GO
USE [master]
GO
ALTER DATABASE [SnackBar] SET  READ_WRITE 
GO
