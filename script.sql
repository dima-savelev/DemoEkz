USE [master]
GO
/****** Object:  Database [user16]    Script Date: 17.02.2023 16:03:22 ******/
CREATE DATABASE [user16]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'user16', FILENAME = N'/var/opt/mssql/data/user16.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'user16_log', FILENAME = N'/var/opt/mssql/data/user16_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [user16] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [user16].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [user16] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [user16] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [user16] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [user16] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [user16] SET ARITHABORT OFF 
GO
ALTER DATABASE [user16] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [user16] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [user16] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [user16] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [user16] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [user16] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [user16] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [user16] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [user16] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [user16] SET  ENABLE_BROKER 
GO
ALTER DATABASE [user16] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [user16] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [user16] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [user16] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [user16] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [user16] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [user16] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [user16] SET RECOVERY FULL 
GO
ALTER DATABASE [user16] SET  MULTI_USER 
GO
ALTER DATABASE [user16] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [user16] SET DB_CHAINING OFF 
GO
ALTER DATABASE [user16] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [user16] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [user16] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [user16] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [user16] SET QUERY_STORE = OFF
GO
USE [user16]
GO
/****** Object:  Table [dbo].[Agent]    Script Date: 17.02.2023 16:03:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[DealShare] [int] NULL,
 CONSTRAINT [PK_Agent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 17.02.2023 16:03:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Deal]    Script Date: 17.02.2023 16:03:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deal](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Demand_Id] [int] NULL,
	[Supply_Id] [int] NULL,
 CONSTRAINT [PK_Deal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Demand]    Script Date: 17.02.2023 16:03:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Demand](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Address_City] [nvarchar](255) NULL,
	[Address_Street] [nvarchar](255) NULL,
	[Address_House] [nvarchar](255) NULL,
	[Address_Number] [nvarchar](255) NULL,
	[MinPrice] [int] NULL,
	[MaxPrice] [int] NULL,
	[AgentId] [int] NULL,
	[ClientId] [int] NULL,
	[MinArea] [float] NULL,
	[MaxArea] [float] NULL,
	[MinRooms] [int] NULL,
	[MaxRooms] [int] NULL,
	[MinFloor] [int] NULL,
	[MaxFloor] [int] NULL,
	[TypeId] [int] NULL,
 CONSTRAINT [PK_Demand] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RealEstate]    Script Date: 17.02.2023 16:03:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RealEstate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Address_City] [nvarchar](255) NULL,
	[Address_Street] [nvarchar](255) NULL,
	[Address_House] [nvarchar](255) NULL,
	[Address_Number] [nvarchar](255) NULL,
	[Coordinate_latitude] [float] NULL,
	[Coordinate_longitude] [float] NULL,
	[TotalArea] [float] NULL,
	[Rooms] [int] NULL,
	[Floor] [int] NULL,
	[TypeId] [int] NULL,
 CONSTRAINT [PK_RealEstate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supply]    Script Date: 17.02.2023 16:03:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supply](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Price] [int] NULL,
	[AgentId] [int] NULL,
	[ClientId] [int] NULL,
	[RealEstateId] [int] NULL,
 CONSTRAINT [PK_Supply] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Type]    Script Date: 17.02.2023 16:03:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
 CONSTRAINT [PK_Type] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Agent] ON 

INSERT [dbo].[Agent] ([Id], [FirstName], [MiddleName], [LastName], [DealShare]) VALUES (1, N'Фахрутдинов', N'Роман', N'Рубинович', 20)
INSERT [dbo].[Agent] ([Id], [FirstName], [MiddleName], [LastName], [DealShare]) VALUES (4, N'Устинов', N'Максим', N'Алексеевич', 40)
INSERT [dbo].[Agent] ([Id], [FirstName], [MiddleName], [LastName], [DealShare]) VALUES (7, N'Сысоева', N'Людмила', N'Валентиновна', 45)
INSERT [dbo].[Agent] ([Id], [FirstName], [MiddleName], [LastName], [DealShare]) VALUES (9, N'Додонов', N'Илья', N'Геннадьевич', 45)
INSERT [dbo].[Agent] ([Id], [FirstName], [MiddleName], [LastName], [DealShare]) VALUES (11, N'Мухтаруллин', N'Руслан', N'Расыхович', 45)
INSERT [dbo].[Agent] ([Id], [FirstName], [MiddleName], [LastName], [DealShare]) VALUES (13, N'Мосеева', N'Любовь', N'Александровна', 45)
INSERT [dbo].[Agent] ([Id], [FirstName], [MiddleName], [LastName], [DealShare]) VALUES (15, N'Киселев', N'Алексей', N'Геннадьевич', 45)
INSERT [dbo].[Agent] ([Id], [FirstName], [MiddleName], [LastName], [DealShare]) VALUES (19, N'Клюйков', N'Евгений', N'Николаевич', 50)
INSERT [dbo].[Agent] ([Id], [FirstName], [MiddleName], [LastName], [DealShare]) VALUES (24, N'Жданова', N'Галина', N'Николаевна', 45)
INSERT [dbo].[Agent] ([Id], [FirstName], [MiddleName], [LastName], [DealShare]) VALUES (34, N'Басырова', N'Елена', N'Азатовна', 45)
INSERT [dbo].[Agent] ([Id], [FirstName], [MiddleName], [LastName], [DealShare]) VALUES (37, N'Швецов', N'Виталий', N'Олегович', 45)
SET IDENTITY_INSERT [dbo].[Agent] OFF
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (2, N'Семенов', N'Евгений ', N'Николаевич', N'32-25-55', N'')
INSERT [dbo].[Client] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (3, N'Денисова', N'Олеся', N'Леонидовна', N'', N'dummy@email.ru')
INSERT [dbo].[Client] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (5, N'Сафронов', N'Алексей', N'Вячеславович', N'', N'client@esoft.tech')
INSERT [dbo].[Client] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (6, N'Кудряшов', N'Александр', N'Витальевич', N'551988', N'')
INSERT [dbo].[Client] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (8, N'Фёдоров', N'Алексей', N'Николаевич', N'', N'fedorov@mail.ru')
INSERT [dbo].[Client] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (10, N'Пелымская', N'Светлана', N'Александровна', N'83452112233', N'')
INSERT [dbo].[Client] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (12, N'Коновальчик', N'Татьяна', N'Геннадьевна', N'', N'dummy@email.ru')
INSERT [dbo].[Client] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (14, N'Молоковская', N'Светлана', N'Михайловна', N'898489848', N'')
INSERT [dbo].[Client] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (16, N'Моторина', N'Анастасия', N'Сергеевна', N'895159848', N'')
INSERT [dbo].[Client] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (17, N'Поспелова', N'Ольга', N'Александровна', N'', N'angel@mail.ru')
INSERT [dbo].[Client] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (18, N'Жиляков', N'Владимир', N'Владимирович', N'445588', N'445588@email.ru')
INSERT [dbo].[Client] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (20, N'Ефремов', N'Владислав', N'Николаевич', N'', N'parampampam@mail.ru')
INSERT [dbo].[Client] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (21, N'Баль', N'Валентина', N'Сергеевна', N'+7998888444', N'')
INSERT [dbo].[Client] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (22, N'Стрелков', N'Артем', N'Николаевич', N'', N'test@test.test')
INSERT [dbo].[Client] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (23, N'Луканин', N'Павел', N'Валерьевич', N'', N'foo@bar.ru')
INSERT [dbo].[Client] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (25, N'Шарипова', N'Эльвира', N'Закирчановна', N'12345678910', N'')
INSERT [dbo].[Client] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (26, N'Фомина', N'Маргарита', N'Николаевна', N'', N'fomina@email.ru')
INSERT [dbo].[Client] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (27, N'Кремлев', N'Владислав', N'Юрьевич', N'777', N'kremlevvu@gmail.ru')
INSERT [dbo].[Client] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (28, N'Пономарева', N'Елена', N'Сергеевна', N'', N'ponomareva@gmail.ru')
INSERT [dbo].[Client] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (29, N'Шелест', N'Тамара', N'Васильевна', N'112', N'')
INSERT [dbo].[Client] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (30, N'Шарипов', N'Рустам', N'Владимирович', N'', N'sharipov@yandex.ru')
INSERT [dbo].[Client] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (31, N'Романов', N'Сергей', N'Федорович', N'02', N'')
INSERT [dbo].[Client] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (32, N'Кручинин', N'Иван', N'Андреевич', N'', N'kruch@list.ru')
INSERT [dbo].[Client] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (33, N'Алферов', N'Алексей', N'Николаевич', N'+688899444', N'')
INSERT [dbo].[Client] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (35, N'Попов ', N'Алексей', N'Николаевич', N'+0489848565', N'popovan@bik.ru')
INSERT [dbo].[Client] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (36, N'Неезжала', N'Наталья', N'Леонидовна', N'', N'neez@mail.ru')
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[Deal] ON 

INSERT [dbo].[Deal] ([Id], [Demand_Id], [Supply_Id]) VALUES (1, 1, 1)
INSERT [dbo].[Deal] ([Id], [Demand_Id], [Supply_Id]) VALUES (2, 3, 2)
INSERT [dbo].[Deal] ([Id], [Demand_Id], [Supply_Id]) VALUES (3, 5, 3)
INSERT [dbo].[Deal] ([Id], [Demand_Id], [Supply_Id]) VALUES (4, 7, 4)
INSERT [dbo].[Deal] ([Id], [Demand_Id], [Supply_Id]) VALUES (10, 15, 16)
SET IDENTITY_INSERT [dbo].[Deal] OFF
GO
SET IDENTITY_INSERT [dbo].[Demand] ON 

INSERT [dbo].[Demand] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [MinPrice], [MaxPrice], [AgentId], [ClientId], [MinArea], [MaxArea], [MinRooms], [MaxRooms], [MinFloor], [MaxFloor], [TypeId]) VALUES (1, N'', N'', N'', N'', 0, NULL, 4, 23, NULL, 0, NULL, 0, NULL, NULL, 1)
INSERT [dbo].[Demand] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [MinPrice], [MaxPrice], [AgentId], [ClientId], [MinArea], [MaxArea], [MinRooms], [MaxRooms], [MinFloor], [MaxFloor], [TypeId]) VALUES (2, NULL, NULL, NULL, NULL, 0, NULL, 4, 16, NULL, 0, NULL, 0, NULL, NULL, 2)
INSERT [dbo].[Demand] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [MinPrice], [MaxPrice], [AgentId], [ClientId], [MinArea], [MaxArea], [MinRooms], [MaxRooms], [MinFloor], [MaxFloor], [TypeId]) VALUES (3, NULL, NULL, NULL, NULL, 0, NULL, 19, 10, NULL, 0, NULL, 0, NULL, NULL, 2)
INSERT [dbo].[Demand] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [MinPrice], [MaxPrice], [AgentId], [ClientId], [MinArea], [MaxArea], [MinRooms], [MaxRooms], [MinFloor], [MaxFloor], [TypeId]) VALUES (4, NULL, NULL, NULL, NULL, 0, NULL, 15, 12, NULL, 0, NULL, 0, NULL, NULL, 3)
INSERT [dbo].[Demand] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [MinPrice], [MaxPrice], [AgentId], [ClientId], [MinArea], [MaxArea], [MinRooms], [MaxRooms], [MinFloor], [MaxFloor], [TypeId]) VALUES (5, NULL, NULL, NULL, NULL, 0, NULL, 1, 14, NULL, 0, NULL, 0, NULL, NULL, 3)
INSERT [dbo].[Demand] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [MinPrice], [MaxPrice], [AgentId], [ClientId], [MinArea], [MaxArea], [MinRooms], [MaxRooms], [MinFloor], [MaxFloor], [TypeId]) VALUES (6, N'Тюмень', N'', N'', N'', 0, 3100000, 7, 5, 20, 0, NULL, 0, 4, NULL, 1)
INSERT [dbo].[Demand] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [MinPrice], [MaxPrice], [AgentId], [ClientId], [MinArea], [MaxArea], [MinRooms], [MaxRooms], [MinFloor], [MaxFloor], [TypeId]) VALUES (7, N'Тюмень', N'Широтная', N'', N'', 0, NULL, 24, 25, NULL, 0, NULL, 0, NULL, NULL, 1)
INSERT [dbo].[Demand] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [MinPrice], [MaxPrice], [AgentId], [ClientId], [MinArea], [MaxArea], [MinRooms], [MaxRooms], [MinFloor], [MaxFloor], [TypeId]) VALUES (8, N'Тюмень', N'Пролетарская', N'', N'', 0, NULL, 1, 26, NULL, 0, NULL, 0, NULL, NULL, 1)
INSERT [dbo].[Demand] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [MinPrice], [MaxPrice], [AgentId], [ClientId], [MinArea], [MaxArea], [MinRooms], [MaxRooms], [MinFloor], [MaxFloor], [TypeId]) VALUES (9, N'Тюмень', N'Тараскульская', N'', N'', 0, NULL, 15, 27, NULL, 0, NULL, 0, NULL, NULL, 1)
INSERT [dbo].[Demand] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [MinPrice], [MaxPrice], [AgentId], [ClientId], [MinArea], [MaxArea], [MinRooms], [MaxRooms], [MinFloor], [MaxFloor], [TypeId]) VALUES (10, N'Тюмень', N'', N'', N'', 0, NULL, 19, 28, 60, 0, NULL, 0, NULL, NULL, 1)
INSERT [dbo].[Demand] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [MinPrice], [MaxPrice], [AgentId], [ClientId], [MinArea], [MaxArea], [MinRooms], [MaxRooms], [MinFloor], [MaxFloor], [TypeId]) VALUES (11, N'Тюмень', N'', N'', N'', 0, NULL, 4, 29, NULL, 0, NULL, 0, 4, NULL, 1)
INSERT [dbo].[Demand] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [MinPrice], [MaxPrice], [AgentId], [ClientId], [MinArea], [MaxArea], [MinRooms], [MaxRooms], [MinFloor], [MaxFloor], [TypeId]) VALUES (12, N'Тюмень', N'', N'', N'', 0, NULL, 7, 30, NULL, 0, NULL, 0, NULL, 5, 1)
INSERT [dbo].[Demand] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [MinPrice], [MaxPrice], [AgentId], [ClientId], [MinArea], [MaxArea], [MinRooms], [MaxRooms], [MinFloor], [MaxFloor], [TypeId]) VALUES (13, N'Тюмень', N'', N'', N'', 0, NULL, 9, 31, NULL, 0, 2, 0, NULL, NULL, 1)
INSERT [dbo].[Demand] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [MinPrice], [MaxPrice], [AgentId], [ClientId], [MinArea], [MaxArea], [MinRooms], [MaxRooms], [MinFloor], [MaxFloor], [TypeId]) VALUES (14, N'Тюмень', N'', N'', N'', 0, NULL, 11, 32, NULL, 0, 3, 0, NULL, NULL, 1)
INSERT [dbo].[Demand] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [MinPrice], [MaxPrice], [AgentId], [ClientId], [MinArea], [MaxArea], [MinRooms], [MaxRooms], [MinFloor], [MaxFloor], [TypeId]) VALUES (15, N'Тюмень', N'', N'', N'', 0, NULL, 13, 33, 30, 0, NULL, 0, 4, NULL, 1)
INSERT [dbo].[Demand] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [MinPrice], [MaxPrice], [AgentId], [ClientId], [MinArea], [MaxArea], [MinRooms], [MaxRooms], [MinFloor], [MaxFloor], [TypeId]) VALUES (16, N'Тюмень', N'', N'', N'', 0, NULL, 34, 35, NULL, 0, NULL, 0, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Demand] OFF
GO
SET IDENTITY_INSERT [dbo].[RealEstate] ON 

INSERT [dbo].[RealEstate] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [Coordinate_latitude], [Coordinate_longitude], [TotalArea], [Rooms], [Floor], [TypeId]) VALUES (1, N'Тюмень', N'Энергостроителей', N'25', N'12', 0, 0, 41.7, 1, 3, 1)
INSERT [dbo].[RealEstate] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [Coordinate_latitude], [Coordinate_longitude], [TotalArea], [Rooms], [Floor], [TypeId]) VALUES (2, N'Тюмень', N'Елизарова', N'8', N'44', 0, 0, 105, 3, 5, 1)
INSERT [dbo].[RealEstate] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [Coordinate_latitude], [Coordinate_longitude], [TotalArea], [Rooms], [Floor], [TypeId]) VALUES (3, N'Тюмень', N'Московский тракт', N'139', N'6', 0, 0, 62, 3, 2, 1)
INSERT [dbo].[RealEstate] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [Coordinate_latitude], [Coordinate_longitude], [TotalArea], [Rooms], [Floor], [TypeId]) VALUES (4, N'Тюмень', N'Широтная', N'189', N'5', 0, 0, 50, 2, 7, 1)
INSERT [dbo].[RealEstate] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [Coordinate_latitude], [Coordinate_longitude], [TotalArea], [Rooms], [Floor], [TypeId]) VALUES (5, N'Тюмень', N'Пролетарская', N'110', N'99', 0, 0, 51.7, 2, 2, 1)
INSERT [dbo].[RealEstate] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [Coordinate_latitude], [Coordinate_longitude], [TotalArea], [Rooms], [Floor], [TypeId]) VALUES (6, N'Тюмень', N'Тараскульская', N'189', N'1', 0, 0, 44, 2, 1, 1)
INSERT [dbo].[RealEstate] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [Coordinate_latitude], [Coordinate_longitude], [TotalArea], [Rooms], [Floor], [TypeId]) VALUES (7, N'Тюмень', N'Парфенова', N'22', N'1', 0, 0, 43.1, 1, 5, 1)
INSERT [dbo].[RealEstate] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [Coordinate_latitude], [Coordinate_longitude], [TotalArea], [Rooms], [Floor], [TypeId]) VALUES (8, N'Тюмень', N'Республики', N'144', N'16', 0, 0, 92, 3, 1, 1)
INSERT [dbo].[RealEstate] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [Coordinate_latitude], [Coordinate_longitude], [TotalArea], [Rooms], [Floor], [TypeId]) VALUES (9, N'Тюмень', N'1-й Заречный', N'25', N'', 0, 0, 84.4, 0, 2, 2)
INSERT [dbo].[RealEstate] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [Coordinate_latitude], [Coordinate_longitude], [TotalArea], [Rooms], [Floor], [TypeId]) VALUES (10, N'Тюмень', N'Ялyтopoвcкий тpaкт', NULL, N'', 0, 0, 130, NULL, 3, 2)
INSERT [dbo].[RealEstate] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [Coordinate_latitude], [Coordinate_longitude], [TotalArea], [Rooms], [Floor], [TypeId]) VALUES (11, N'Тюмень', N'Березняковский п', NULL, N'', 0, 0, 120, NULL, 1, 2)
INSERT [dbo].[RealEstate] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [Coordinate_latitude], [Coordinate_longitude], [TotalArea], [Rooms], [Floor], [TypeId]) VALUES (12, N'Тюмень', N'Луговое', N'', N'', 0, 0, 20.3, NULL, NULL, 3)
INSERT [dbo].[RealEstate] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [Coordinate_latitude], [Coordinate_longitude], [TotalArea], [Rooms], [Floor], [TypeId]) VALUES (13, N'Тюмень', N'Алексеевский хутор', N'', N'', 0, 0, 12.45, NULL, NULL, 3)
INSERT [dbo].[RealEstate] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [Coordinate_latitude], [Coordinate_longitude], [TotalArea], [Rooms], [Floor], [TypeId]) VALUES (14, N'Тюмень', N'Суходольский мкр', N'', N'', 0, 0, 12, NULL, NULL, 3)
SET IDENTITY_INSERT [dbo].[RealEstate] OFF
GO
SET IDENTITY_INSERT [dbo].[Supply] ON 

INSERT [dbo].[Supply] ([Id], [Price], [AgentId], [ClientId], [RealEstateId]) VALUES (1, 2500000, 1, 2, 1)
INSERT [dbo].[Supply] ([Id], [Price], [AgentId], [ClientId], [RealEstateId]) VALUES (2, 5000000, 7, 8, 3)
INSERT [dbo].[Supply] ([Id], [Price], [AgentId], [ClientId], [RealEstateId]) VALUES (3, 1300000, 11, 12, 3)
INSERT [dbo].[Supply] ([Id], [Price], [AgentId], [ClientId], [RealEstateId]) VALUES (4, 5000000, 15, 16, 4)
INSERT [dbo].[Supply] ([Id], [Price], [AgentId], [ClientId], [RealEstateId]) VALUES (5, 4700000, 1, 3, 2)
INSERT [dbo].[Supply] ([Id], [Price], [AgentId], [ClientId], [RealEstateId]) VALUES (6, 3750000, 4, 5, 3)
INSERT [dbo].[Supply] ([Id], [Price], [AgentId], [ClientId], [RealEstateId]) VALUES (7, 1900000, 4, 6, 3)
INSERT [dbo].[Supply] ([Id], [Price], [AgentId], [ClientId], [RealEstateId]) VALUES (8, 4300000, 9, 10, 3)
INSERT [dbo].[Supply] ([Id], [Price], [AgentId], [ClientId], [RealEstateId]) VALUES (9, 1750000, 13, 14, 3)
INSERT [dbo].[Supply] ([Id], [Price], [AgentId], [ClientId], [RealEstateId]) VALUES (10, 5850000, 15, 17, 5)
INSERT [dbo].[Supply] ([Id], [Price], [AgentId], [ClientId], [RealEstateId]) VALUES (11, 6800000, 15, 18, 6)
INSERT [dbo].[Supply] ([Id], [Price], [AgentId], [ClientId], [RealEstateId]) VALUES (12, 950000, 19, 20, 7)
INSERT [dbo].[Supply] ([Id], [Price], [AgentId], [ClientId], [RealEstateId]) VALUES (13, 700000, 19, 21, 8)
INSERT [dbo].[Supply] ([Id], [Price], [AgentId], [ClientId], [RealEstateId]) VALUES (14, 600000, 19, 22, 9)
INSERT [dbo].[Supply] ([Id], [Price], [AgentId], [ClientId], [RealEstateId]) VALUES (16, 6, 4, 16, 4)
SET IDENTITY_INSERT [dbo].[Supply] OFF
GO
SET IDENTITY_INSERT [dbo].[Type] ON 

INSERT [dbo].[Type] ([Id], [Title]) VALUES (1, N'Квартира')
INSERT [dbo].[Type] ([Id], [Title]) VALUES (2, N'Дом')
INSERT [dbo].[Type] ([Id], [Title]) VALUES (3, N'Земля')
SET IDENTITY_INSERT [dbo].[Type] OFF
GO
ALTER TABLE [dbo].[Deal]  WITH CHECK ADD  CONSTRAINT [FK_Deal_Demand] FOREIGN KEY([Demand_Id])
REFERENCES [dbo].[Demand] ([Id])
GO
ALTER TABLE [dbo].[Deal] CHECK CONSTRAINT [FK_Deal_Demand]
GO
ALTER TABLE [dbo].[Deal]  WITH CHECK ADD  CONSTRAINT [FK_Deal_Supply] FOREIGN KEY([Supply_Id])
REFERENCES [dbo].[Supply] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Deal] CHECK CONSTRAINT [FK_Deal_Supply]
GO
ALTER TABLE [dbo].[Demand]  WITH CHECK ADD  CONSTRAINT [FK_Demand_Agent] FOREIGN KEY([AgentId])
REFERENCES [dbo].[Agent] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Demand] CHECK CONSTRAINT [FK_Demand_Agent]
GO
ALTER TABLE [dbo].[Demand]  WITH CHECK ADD  CONSTRAINT [FK_Demand_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Demand] CHECK CONSTRAINT [FK_Demand_Client]
GO
ALTER TABLE [dbo].[Demand]  WITH CHECK ADD  CONSTRAINT [FK_Demand_Type] FOREIGN KEY([TypeId])
REFERENCES [dbo].[Type] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Demand] CHECK CONSTRAINT [FK_Demand_Type]
GO
ALTER TABLE [dbo].[RealEstate]  WITH CHECK ADD  CONSTRAINT [FK_RealEstate_Type] FOREIGN KEY([TypeId])
REFERENCES [dbo].[Type] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RealEstate] CHECK CONSTRAINT [FK_RealEstate_Type]
GO
ALTER TABLE [dbo].[Supply]  WITH CHECK ADD  CONSTRAINT [FK_Supply_Agent] FOREIGN KEY([AgentId])
REFERENCES [dbo].[Agent] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Supply] CHECK CONSTRAINT [FK_Supply_Agent]
GO
ALTER TABLE [dbo].[Supply]  WITH CHECK ADD  CONSTRAINT [FK_Supply_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Supply] CHECK CONSTRAINT [FK_Supply_Client]
GO
ALTER TABLE [dbo].[Supply]  WITH CHECK ADD  CONSTRAINT [FK_Supply_RealEstate] FOREIGN KEY([RealEstateId])
REFERENCES [dbo].[RealEstate] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Supply] CHECK CONSTRAINT [FK_Supply_RealEstate]
GO
ALTER TABLE [dbo].[Agent]  WITH CHECK ADD  CONSTRAINT [CK_Agent] CHECK  (([DealShare]>=(0) AND [DealShare]<=(100)))
GO
ALTER TABLE [dbo].[Agent] CHECK CONSTRAINT [CK_Agent]
GO
USE [master]
GO
ALTER DATABASE [user16] SET  READ_WRITE 
GO
