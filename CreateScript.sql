USE [master]
GO
/****** Object:  Database [InsightConsultingDB]    Script Date: 2019/08/25 12:31:40 PM ******/
CREATE DATABASE [InsightConsultingDB]
GO

ALTER DATABASE [InsightConsultingDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [InsightConsultingDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [InsightConsultingDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [InsightConsultingDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [InsightConsultingDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [InsightConsultingDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [InsightConsultingDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [InsightConsultingDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [InsightConsultingDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [InsightConsultingDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [InsightConsultingDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [InsightConsultingDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [InsightConsultingDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [InsightConsultingDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [InsightConsultingDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [InsightConsultingDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [InsightConsultingDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [InsightConsultingDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [InsightConsultingDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [InsightConsultingDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [InsightConsultingDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [InsightConsultingDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [InsightConsultingDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [InsightConsultingDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [InsightConsultingDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [InsightConsultingDB] SET  MULTI_USER 
GO
ALTER DATABASE [InsightConsultingDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [InsightConsultingDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [InsightConsultingDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [InsightConsultingDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [InsightConsultingDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [InsightConsultingDB]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2019/08/25 12:31:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [nvarchar](100) NOT NULL,
	[lastName] [nvarchar](100) NOT NULL,
	[age] [int] NULL,
	[email] [nvarchar](100) NOT NULL,
	[dateOfBirth] [date] NOT NULL,
	[identityNumber] [int] NOT NULL,
	[address] [nvarchar](250) NULL,
	[lineOne] [nvarchar](250) NULL,
	[lineTwo] [nvarchar](250) NULL,
	[city] [nvarchar](50) NULL,
	[country] [nvarchar](50) NULL,
	[postalCode] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Users] ON 

GO
INSERT [dbo].[Users] ([Id], [firstName], [lastName], [age], [email], [dateOfBirth], [identityNumber], [address], [lineOne], [lineTwo], [city], [country], [postalCode]) VALUES (2, N'gtgt', N'grtgrt', 23, N'ferfr@ff.com', CAST(N'2019-07-31' AS Date), 35353, N'fgrtgrtg 53 25t5 ', N'g rtrtg rtg', N'iyfyu', N'grt rgrtg r', N'gtrtg', 4234)
GO
INSERT [dbo].[Users] ([Id], [firstName], [lastName], [age], [email], [dateOfBirth], [identityNumber], [address], [lineOne], [lineTwo], [city], [country], [postalCode]) VALUES (3, N'tgtrg', N'grtgrtg', 43, N'ggdsg@fsd.com', CAST(N'2018-02-01' AS Date), 3453434, N'2343 gtt', N'gtrgt', N'ggrtgt', N'grtgrtg', N'htyhty', 1356)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 2019/08/25 12:31:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Zain Goolam Hoosen
-- Create date: 23 August 2019
-- Description:	Get All the Users
-- =============================================
CREATE PROCEDURE [dbo].[GetAllUsers]

AS
BEGIN

	select u.*
	from Users u
	order by u.firstName desc


END

GO
USE [master]
GO
ALTER DATABASE [InsightConsultingDB] SET  READ_WRITE 
GO
