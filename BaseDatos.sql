USE [master]
GO
/****** Object:  Database [BaseDatos]    Script Date: 23/9/2022 22:57:05 ******/
CREATE DATABASE [BaseDatos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BaseDatos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\BaseDatos.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BaseDatos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\BaseDatos_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BaseDatos] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BaseDatos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BaseDatos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BaseDatos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BaseDatos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BaseDatos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BaseDatos] SET ARITHABORT OFF 
GO
ALTER DATABASE [BaseDatos] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BaseDatos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BaseDatos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BaseDatos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BaseDatos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BaseDatos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BaseDatos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BaseDatos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BaseDatos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BaseDatos] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BaseDatos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BaseDatos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BaseDatos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BaseDatos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BaseDatos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BaseDatos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BaseDatos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BaseDatos] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BaseDatos] SET  MULTI_USER 
GO
ALTER DATABASE [BaseDatos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BaseDatos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BaseDatos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BaseDatos] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BaseDatos] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BaseDatos] SET QUERY_STORE = OFF
GO
USE [BaseDatos]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 23/9/2022 22:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[identificacion] [varchar](30) NOT NULL,
	[contrasenia] [varchar](30) NOT NULL,
	[estado] [bit] NOT NULL,
	[nombre] [varchar](30) NOT NULL,
	[genero] [varchar](30) NOT NULL,
	[edad] [int] NOT NULL,
	[direccion] [varchar](50) NULL,
	[telefono] [varchar](20) NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cuenta]    Script Date: 23/9/2022 22:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cuenta](
	[numero] [varchar](30) NOT NULL,
	[id] [int] NOT NULL,
	[tipo] [varchar](30) NOT NULL,
	[estado] [bit] NOT NULL,
	[saldo] [money] NOT NULL,
 CONSTRAINT [PK__cuenta__5138EEC71FAE4CF6] PRIMARY KEY CLUSTERED 
(
	[numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[movimiento]    Script Date: 23/9/2022 22:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[movimiento](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[numero] [varchar](30) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[tipo] [varchar](30) NOT NULL,
	[saldo_inicial] [money] NOT NULL,
	[movimiento_valor] [money] NOT NULL,
	[saldo_actual] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[cliente] ON 

INSERT [dbo].[cliente] ([id], [identificacion], [contrasenia], [estado], [nombre], [genero], [edad], [direccion], [telefono]) VALUES (2, N'12123123', N'dsdasdasd', 1, N'dasdasd', N'mas', 20, N'asdasdasd', N'1212212')
INSERT [dbo].[cliente] ([id], [identificacion], [contrasenia], [estado], [nombre], [genero], [edad], [direccion], [telefono]) VALUES (3, N'12123123', N'dsdasdasd', 1, N'dasdasd', N'mas', 20, N'asdasdasd', N'1212212')
INSERT [dbo].[cliente] ([id], [identificacion], [contrasenia], [estado], [nombre], [genero], [edad], [direccion], [telefono]) VALUES (4, N'12123123', N'dsdasdasd', 1, N'dasdasd', N'mas', 20, N'asdasdasd', N'1212212')
INSERT [dbo].[cliente] ([id], [identificacion], [contrasenia], [estado], [nombre], [genero], [edad], [direccion], [telefono]) VALUES (5, N'12123123', N'dsdasdasd', 1, N'dasdasd', N'mas', 20, N'asdasdasd', N'1212212')
INSERT [dbo].[cliente] ([id], [identificacion], [contrasenia], [estado], [nombre], [genero], [edad], [direccion], [telefono]) VALUES (6, N'12345', N'fdre43', 1, N'Juan Padre', N'Ma', 10, N'lo pinos', N'133434545')
SET IDENTITY_INSERT [dbo].[cliente] OFF
GO
ALTER TABLE [dbo].[cuenta]  WITH CHECK ADD  CONSTRAINT [FK_cuenta_cuenta] FOREIGN KEY([id])
REFERENCES [dbo].[cliente] ([id])
GO
ALTER TABLE [dbo].[cuenta] CHECK CONSTRAINT [FK_cuenta_cuenta]
GO
ALTER TABLE [dbo].[movimiento]  WITH CHECK ADD  CONSTRAINT [FK_movimiento_cuenta] FOREIGN KEY([numero])
REFERENCES [dbo].[cuenta] ([numero])
GO
ALTER TABLE [dbo].[movimiento] CHECK CONSTRAINT [FK_movimiento_cuenta]
GO
USE [master]
GO
ALTER DATABASE [BaseDatos] SET  READ_WRITE 
GO
