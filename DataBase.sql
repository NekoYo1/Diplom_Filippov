USE [master]
GO
/****** Object:  Database [AgenstvNedvezj]    Script Date: 24.06.2023 19:37:03 ******/
CREATE DATABASE [AgenstvNedvezj]
GO
ALTER DATABASE [AgenstvNedvezj] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AgenstvNedvezj].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AgenstvNedvezj] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AgenstvNedvezj] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AgenstvNedvezj] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AgenstvNedvezj] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AgenstvNedvezj] SET ARITHABORT OFF 
GO
ALTER DATABASE [AgenstvNedvezj] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AgenstvNedvezj] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AgenstvNedvezj] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AgenstvNedvezj] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AgenstvNedvezj] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AgenstvNedvezj] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AgenstvNedvezj] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AgenstvNedvezj] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AgenstvNedvezj] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AgenstvNedvezj] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AgenstvNedvezj] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AgenstvNedvezj] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AgenstvNedvezj] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AgenstvNedvezj] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AgenstvNedvezj] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AgenstvNedvezj] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AgenstvNedvezj] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AgenstvNedvezj] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AgenstvNedvezj] SET  MULTI_USER 
GO
ALTER DATABASE [AgenstvNedvezj] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AgenstvNedvezj] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AgenstvNedvezj] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AgenstvNedvezj] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AgenstvNedvezj] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AgenstvNedvezj] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [AgenstvNedvezj] SET QUERY_STORE = OFF
GO
USE [AgenstvNedvezj]
GO
/****** Object:  Table [dbo].[Nedvezj]    Script Date: 24.06.2023 19:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nedvezj](
	[idNedvezj] [int] IDENTITY(1,1) NOT NULL,
	[idNedvezjType] [int] NOT NULL,
	[idRayon] [int] NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[Square] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[Opisanie] [nvarchar](max) NOT NULL,
	[idProdavec] [int] NOT NULL,
	[Image] [nvarchar](50) NULL,
	[Actual] [bit] NOT NULL,
 CONSTRAINT [PK_Nedvezj] PRIMARY KEY CLUSTERED 
(
	[idNedvezj] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NedvezjType]    Script Date: 24.06.2023 19:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NedvezjType](
	[idNedvezjType] [int] IDENTITY(1,1) NOT NULL,
	[NedvezjTypeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_NedvezjType] PRIMARY KEY CLUSTERED 
(
	[idNedvezjType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prodavec]    Script Date: 24.06.2023 19:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prodavec](
	[idProdavec] [int] IDENTITY(1,1) NOT NULL,
	[Familia] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Otchestvo] [nvarchar](50) NOT NULL,
	[Tel] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Prodavec] PRIMARY KEY CLUSTERED 
(
	[idProdavec] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rayon]    Script Date: 24.06.2023 19:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rayon](
	[idRayon] [int] IDENTITY(1,1) NOT NULL,
	[NameRayona] [nvarchar](50) NOT NULL,
	[NumRayon] [int] NOT NULL,
 CONSTRAINT [PK_Rayon] PRIMARY KEY CLUSTERED 
(
	[idRayon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sdelki]    Script Date: 24.06.2023 19:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sdelki](
	[idSdelki] [int] IDENTITY(1,1) NOT NULL,
	[idNedvezj] [int] NOT NULL,
	[idProdavec] [int] NOT NULL,
	[Komissia] [int] NOT NULL,
	[Data] [date] NOT NULL,
 CONSTRAINT [PK_Sdelki] PRIMARY KEY CLUSTERED 
(
	[idSdelki] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 24.06.2023 19:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[idUser] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[idProdavec] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[idUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Nedvezj] ON 

INSERT [dbo].[Nedvezj] ([idNedvezj], [idNedvezjType], [idRayon], [Address], [Square], [Price], [Opisanie], [idProdavec], [Image], [Actual]) VALUES (1, 1, 1, N'ул. Победы,14', 21, 2105, N'Квартира около центра, магазины в доступности', 4, N'P1', 1)
INSERT [dbo].[Nedvezj] ([idNedvezj], [idNedvezjType], [idRayon], [Address], [Square], [Price], [Opisanie], [idProdavec], [Image], [Actual]) VALUES (2, 2, 2, N'ул. Амурская, 10', 25, 42354, N'Евро ремонт, газовая плитка', 2, N'P2', 1)
INSERT [dbo].[Nedvezj] ([idNedvezj], [idNedvezjType], [idRayon], [Address], [Square], [Price], [Opisanie], [idProdavec], [Image], [Actual]) VALUES (3, 3, 3, N'ул. Победы, 25', 30, 5345345, N'Электро плитка, с мебелью', 3, N'P3', 1)
INSERT [dbo].[Nedvezj] ([idNedvezj], [idNedvezjType], [idRayon], [Address], [Square], [Price], [Opisanie], [idProdavec], [Image], [Actual]) VALUES (4, 4, 4, N'пр. Комсомольский, 50', 35, 3414124, N'Советский ремонт', 4, N'P4', 1)
INSERT [dbo].[Nedvezj] ([idNedvezj], [idNedvezjType], [idRayon], [Address], [Square], [Price], [Opisanie], [idProdavec], [Image], [Actual]) VALUES (5, 5, 5, N'пр. Октябарский, 15', 10, 4232223, N'Отопление, под одну машину', 5, N'P5', 0)
SET IDENTITY_INSERT [dbo].[Nedvezj] OFF
GO
SET IDENTITY_INSERT [dbo].[NedvezjType] ON 

INSERT [dbo].[NedvezjType] ([idNedvezjType], [NedvezjTypeName]) VALUES (1, N'Квартира 1-к')
INSERT [dbo].[NedvezjType] ([idNedvezjType], [NedvezjTypeName]) VALUES (2, N'Квартира 2-к')
INSERT [dbo].[NedvezjType] ([idNedvezjType], [NedvezjTypeName]) VALUES (3, N'Квартира 3-к')
INSERT [dbo].[NedvezjType] ([idNedvezjType], [NedvezjTypeName]) VALUES (4, N'Квартира 4-к')
INSERT [dbo].[NedvezjType] ([idNedvezjType], [NedvezjTypeName]) VALUES (5, N'Гараж')
SET IDENTITY_INSERT [dbo].[NedvezjType] OFF
GO
SET IDENTITY_INSERT [dbo].[Prodavec] ON 

INSERT [dbo].[Prodavec] ([idProdavec], [Familia], [Name], [Otchestvo], [Tel]) VALUES (1, N'Тихонов', N'Егор', N'Олегович', N'+79990724513')
INSERT [dbo].[Prodavec] ([idProdavec], [Familia], [Name], [Otchestvo], [Tel]) VALUES (2, N'Ушаков', N'Сергей', N'Александрович', N'+79943124420')
INSERT [dbo].[Prodavec] ([idProdavec], [Familia], [Name], [Otchestvo], [Tel]) VALUES (3, N'Филиппов', N'Константин', N'Павлович', N'+79147329021')
INSERT [dbo].[Prodavec] ([idProdavec], [Familia], [Name], [Otchestvo], [Tel]) VALUES (4, N'Иванов', N'Семен', N'Евгеньевич', N'+79947510088')
INSERT [dbo].[Prodavec] ([idProdavec], [Familia], [Name], [Otchestvo], [Tel]) VALUES (5, N'Копанев', N'Даниил', N'Олегович', N'+79140227271')
INSERT [dbo].[Prodavec] ([idProdavec], [Familia], [Name], [Otchestvo], [Tel]) VALUES (6, N'33', N'33', N'33', N'33')
INSERT [dbo].[Prodavec] ([idProdavec], [Familia], [Name], [Otchestvo], [Tel]) VALUES (7, N'123', N'123', N'123', N'123')
INSERT [dbo].[Prodavec] ([idProdavec], [Familia], [Name], [Otchestvo], [Tel]) VALUES (8, N'444', N'444', N'444', N'444')
SET IDENTITY_INSERT [dbo].[Prodavec] OFF
GO
SET IDENTITY_INSERT [dbo].[Rayon] ON 

INSERT [dbo].[Rayon] ([idRayon], [NameRayona], [NumRayon]) VALUES (1, N'Восьмой', 8)
INSERT [dbo].[Rayon] ([idRayon], [NameRayona], [NumRayon]) VALUES (2, N'Южный', 5)
INSERT [dbo].[Rayon] ([idRayon], [NameRayona], [NumRayon]) VALUES (3, N'Октябарьский', 1)
INSERT [dbo].[Rayon] ([idRayon], [NameRayona], [NumRayon]) VALUES (4, N'Центральный', 3)
INSERT [dbo].[Rayon] ([idRayon], [NameRayona], [NumRayon]) VALUES (5, N'Промышленный', 2)
SET IDENTITY_INSERT [dbo].[Rayon] OFF
GO
SET IDENTITY_INSERT [dbo].[Sdelki] ON 

INSERT [dbo].[Sdelki] ([idSdelki], [idNedvezj], [idProdavec], [Komissia], [Data]) VALUES (1, 1, 1, 10, CAST(N'2000-01-20' AS Date))
INSERT [dbo].[Sdelki] ([idSdelki], [idNedvezj], [idProdavec], [Komissia], [Data]) VALUES (2, 2, 2, 10, CAST(N'2000-02-20' AS Date))
INSERT [dbo].[Sdelki] ([idSdelki], [idNedvezj], [idProdavec], [Komissia], [Data]) VALUES (3, 3, 3, 5, CAST(N'2000-03-20' AS Date))
INSERT [dbo].[Sdelki] ([idSdelki], [idNedvezj], [idProdavec], [Komissia], [Data]) VALUES (4, 4, 4, 6, CAST(N'2000-04-20' AS Date))
INSERT [dbo].[Sdelki] ([idSdelki], [idNedvezj], [idProdavec], [Komissia], [Data]) VALUES (5, 5, 5, 3, CAST(N'2000-05-20' AS Date))
SET IDENTITY_INSERT [dbo].[Sdelki] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([idUser], [Login], [Password], [idProdavec]) VALUES (1, N'ss', N'111', 1)
INSERT [dbo].[Users] ([idUser], [Login], [Password], [idProdavec]) VALUES (2, N'gg', N'222', 2)
INSERT [dbo].[Users] ([idUser], [Login], [Password], [idProdavec]) VALUES (3, N'aa', N'333', 3)
INSERT [dbo].[Users] ([idUser], [Login], [Password], [idProdavec]) VALUES (4, N'tt', N'444', 4)
INSERT [dbo].[Users] ([idUser], [Login], [Password], [idProdavec]) VALUES (5, N'hh', N'555', 5)
INSERT [dbo].[Users] ([idUser], [Login], [Password], [idProdavec]) VALUES (6, N'test', N'1234', NULL)
INSERT [dbo].[Users] ([idUser], [Login], [Password], [idProdavec]) VALUES (7, N'test1', N'123', NULL)
INSERT [dbo].[Users] ([idUser], [Login], [Password], [idProdavec]) VALUES (8, N'test2', N'133', NULL)
INSERT [dbo].[Users] ([idUser], [Login], [Password], [idProdavec]) VALUES (9, N'test3', N'111', NULL)
INSERT [dbo].[Users] ([idUser], [Login], [Password], [idProdavec]) VALUES (10, N'33', N'33', 6)
INSERT [dbo].[Users] ([idUser], [Login], [Password], [idProdavec]) VALUES (11, N'admin', N'admin', NULL)
INSERT [dbo].[Users] ([idUser], [Login], [Password], [idProdavec]) VALUES (12, N'123', N'123', 7)
INSERT [dbo].[Users] ([idUser], [Login], [Password], [idProdavec]) VALUES (13, N'444', N'444', 8)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Nedvezj]  WITH CHECK ADD  CONSTRAINT [FK_Nedvezj_NedvezjType] FOREIGN KEY([idNedvezjType])
REFERENCES [dbo].[NedvezjType] ([idNedvezjType])
GO
ALTER TABLE [dbo].[Nedvezj] CHECK CONSTRAINT [FK_Nedvezj_NedvezjType]
GO
ALTER TABLE [dbo].[Nedvezj]  WITH CHECK ADD  CONSTRAINT [FK_Nedvezj_Prodavec] FOREIGN KEY([idProdavec])
REFERENCES [dbo].[Prodavec] ([idProdavec])
GO
ALTER TABLE [dbo].[Nedvezj] CHECK CONSTRAINT [FK_Nedvezj_Prodavec]
GO
ALTER TABLE [dbo].[Nedvezj]  WITH CHECK ADD  CONSTRAINT [FK_Nedvezj_Rayon] FOREIGN KEY([idRayon])
REFERENCES [dbo].[Rayon] ([idRayon])
GO
ALTER TABLE [dbo].[Nedvezj] CHECK CONSTRAINT [FK_Nedvezj_Rayon]
GO
ALTER TABLE [dbo].[Sdelki]  WITH CHECK ADD  CONSTRAINT [FK_Sdelki_Nedvezj] FOREIGN KEY([idNedvezj])
REFERENCES [dbo].[Nedvezj] ([idNedvezj])
GO
ALTER TABLE [dbo].[Sdelki] CHECK CONSTRAINT [FK_Sdelki_Nedvezj]
GO
ALTER TABLE [dbo].[Sdelki]  WITH CHECK ADD  CONSTRAINT [FK_Sdelki_Prodavec] FOREIGN KEY([idProdavec])
REFERENCES [dbo].[Prodavec] ([idProdavec])
GO
ALTER TABLE [dbo].[Sdelki] CHECK CONSTRAINT [FK_Sdelki_Prodavec]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Prodavec] FOREIGN KEY([idProdavec])
REFERENCES [dbo].[Prodavec] ([idProdavec])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Prodavec]
GO
USE [master]
GO
ALTER DATABASE [AgenstvNedvezj] SET  READ_WRITE 
GO
