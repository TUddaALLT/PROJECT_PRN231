USE [master]
GO
/****** Object:  Database [ExamSystem]    Script Date: 3/13/2024 10:31:22 PM ******/
CREATE DATABASE [ExamSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ExamSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ExamSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ExamSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ExamSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ExamSystem] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ExamSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ExamSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ExamSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ExamSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ExamSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ExamSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [ExamSystem] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ExamSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ExamSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ExamSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ExamSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ExamSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ExamSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ExamSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ExamSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ExamSystem] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ExamSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ExamSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ExamSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ExamSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ExamSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ExamSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ExamSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ExamSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ExamSystem] SET  MULTI_USER 
GO
ALTER DATABASE [ExamSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ExamSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ExamSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ExamSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ExamSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ExamSystem] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ExamSystem] SET QUERY_STORE = OFF
GO
USE [ExamSystem]
GO
/****** Object:  Table [dbo].[Answer]    Script Date: 3/13/2024 10:31:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answer](
	[answer_id] [int] IDENTITY(1,1) NOT NULL,
	[question_id] [int] NOT NULL,
	[value] [nvarchar](max) NULL,
	[is_correct] [bit] NULL,
 CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED 
(
	[answer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Exam]    Script Date: 3/13/2024 10:31:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exam](
	[exam_id] [int] IDENTITY(1,1) NOT NULL,
	[exam_name] [nvarchar](255) NULL,
	[duration] [int] NULL,
 CONSTRAINT [PK__Exam__9C8C7BE93EBC444F] PRIMARY KEY CLUSTERED 
(
	[exam_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExamQuestion]    Script Date: 3/13/2024 10:31:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamQuestion](
	[exam_question_id] [int] IDENTITY(1,1) NOT NULL,
	[exam_id] [int] NULL,
	[question_id] [int] NULL,
	[question_order] [int] NULL,
 CONSTRAINT [PK__ExamQues__27F8BFF8E32449A9] PRIMARY KEY CLUSTERED 
(
	[exam_question_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 3/13/2024 10:31:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[question_id] [int] IDENTITY(1,1) NOT NULL,
	[question_text] [nvarchar](max) NULL,
	[difficulty_level] [int] NULL,
 CONSTRAINT [PK__Question__2EC21549BD0AA421] PRIMARY KEY CLUSTERED 
(
	[question_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserExamQuestionAnswer]    Script Date: 3/13/2024 10:31:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserExamQuestionAnswer](
	[user_id] [int] NULL,
	[exam_id] [int] NULL,
	[question_id] [int] NULL,
	[answer_id] [int] NULL,
	[is_correct] [bit] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_UserExamQuestionAnswer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserExamResult]    Script Date: 3/13/2024 10:31:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserExamResult](
	[result_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[exam_id] [int] NULL,
	[score] [float] NULL,
	[start_time] [datetime] NULL,
	[end_time] [datetime] NULL,
 CONSTRAINT [PK__UserExam__AFB3C3169FDD9DCF] PRIMARY KEY CLUSTERED 
(
	[result_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/13/2024 10:31:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[passwordSalt] [varbinary](500) NOT NULL,
	[passwordHash] [varbinary](500) NOT NULL,
	[email] [nvarchar](100) NULL,
	[role] [nvarchar](100) NULL,
	[otpCode] [varchar](5) NULL,
	[verified] [bit] NOT NULL,
 CONSTRAINT [PK__Users__B9BE370FFD1BDDC3] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((0)) FOR [verified]
GO
ALTER TABLE [dbo].[Answer]  WITH CHECK ADD  CONSTRAINT [FK_Answer_Question] FOREIGN KEY([question_id])
REFERENCES [dbo].[Question] ([question_id])
GO
ALTER TABLE [dbo].[Answer] CHECK CONSTRAINT [FK_Answer_Question]
GO
ALTER TABLE [dbo].[ExamQuestion]  WITH CHECK ADD  CONSTRAINT [FK_ExamQuestion_Exam] FOREIGN KEY([exam_id])
REFERENCES [dbo].[Exam] ([exam_id])
GO
ALTER TABLE [dbo].[ExamQuestion] CHECK CONSTRAINT [FK_ExamQuestion_Exam]
GO
ALTER TABLE [dbo].[ExamQuestion]  WITH CHECK ADD  CONSTRAINT [FK_ExamQuestion_Question] FOREIGN KEY([question_id])
REFERENCES [dbo].[Question] ([question_id])
GO
ALTER TABLE [dbo].[ExamQuestion] CHECK CONSTRAINT [FK_ExamQuestion_Question]
GO
ALTER TABLE [dbo].[UserExamQuestionAnswer]  WITH CHECK ADD  CONSTRAINT [FK_UserExamQuestionAnswer_Answer] FOREIGN KEY([answer_id])
REFERENCES [dbo].[Answer] ([answer_id])
GO
ALTER TABLE [dbo].[UserExamQuestionAnswer] CHECK CONSTRAINT [FK_UserExamQuestionAnswer_Answer]
GO
ALTER TABLE [dbo].[UserExamQuestionAnswer]  WITH CHECK ADD  CONSTRAINT [FK_UserExamQuestionAnswer_Exam] FOREIGN KEY([exam_id])
REFERENCES [dbo].[Exam] ([exam_id])
GO
ALTER TABLE [dbo].[UserExamQuestionAnswer] CHECK CONSTRAINT [FK_UserExamQuestionAnswer_Exam]
GO
ALTER TABLE [dbo].[UserExamQuestionAnswer]  WITH CHECK ADD  CONSTRAINT [FK_UserExamQuestionAnswer_Question] FOREIGN KEY([question_id])
REFERENCES [dbo].[Question] ([question_id])
GO
ALTER TABLE [dbo].[UserExamQuestionAnswer] CHECK CONSTRAINT [FK_UserExamQuestionAnswer_Question]
GO
ALTER TABLE [dbo].[UserExamQuestionAnswer]  WITH CHECK ADD  CONSTRAINT [FK_UserExamQuestionAnswer_Users] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([user_id])
GO
ALTER TABLE [dbo].[UserExamQuestionAnswer] CHECK CONSTRAINT [FK_UserExamQuestionAnswer_Users]
GO
ALTER TABLE [dbo].[UserExamResult]  WITH CHECK ADD  CONSTRAINT [FK_UserExamResult_Exam] FOREIGN KEY([exam_id])
REFERENCES [dbo].[Exam] ([exam_id])
GO
ALTER TABLE [dbo].[UserExamResult] CHECK CONSTRAINT [FK_UserExamResult_Exam]
GO
ALTER TABLE [dbo].[UserExamResult]  WITH CHECK ADD  CONSTRAINT [FK_UserExamResult_Users] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([user_id])
GO
ALTER TABLE [dbo].[UserExamResult] CHECK CONSTRAINT [FK_UserExamResult_Users]
GO
USE [master]
GO
ALTER DATABASE [ExamSystem] SET  READ_WRITE 
GO
