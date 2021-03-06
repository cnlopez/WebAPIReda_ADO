USE [master]
GO
/****** Object:  Database [Redarbor]    Script Date: 14/03/2022 5:41:29 p. m. ******/
CREATE DATABASE [Redarbor]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Redarbor', FILENAME = N'C:\Users\cnlop\Redarbor.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Redarbor_log', FILENAME = N'C:\Users\cnlop\Redarbor_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Redarbor] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Redarbor].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Redarbor] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Redarbor] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Redarbor] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Redarbor] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Redarbor] SET ARITHABORT OFF 
GO
ALTER DATABASE [Redarbor] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Redarbor] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Redarbor] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Redarbor] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Redarbor] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Redarbor] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Redarbor] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Redarbor] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Redarbor] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Redarbor] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Redarbor] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Redarbor] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Redarbor] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Redarbor] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Redarbor] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Redarbor] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Redarbor] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Redarbor] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Redarbor] SET  MULTI_USER 
GO
ALTER DATABASE [Redarbor] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Redarbor] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Redarbor] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Redarbor] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Redarbor] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Redarbor] SET QUERY_STORE = OFF
GO
USE [Redarbor]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Redarbor]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 14/03/2022 5:41:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[Email] [varchar](100) NULL,
	[Fax] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Lastlogin] [datetime] NULL,
	[Password] [varchar](50) NULL,
	[PortalId] [int] NULL,
	[RoleId] [int] NULL,
	[StatusId] [int] NULL,
	[Telephone] [varchar](50) NULL,
	[UpdatedOn] [datetime] NULL,
	[Username] [varchar](100) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertEmployee]    Script Date: 14/03/2022 5:41:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Nikolai López>
-- Create date: <2022-03-13>
-- Description:	<Insertar employees>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertEmployee]
@CompanyId INT
,@CreatedOn VARCHAR(50)
,@DeletedOn VARCHAR(50)
,@Email VARCHAR(100)
,@Fax VARCHAR(50)
,@Name VARCHAR(50)
,@Lastlogin VARCHAR(50)
,@Password VARCHAR(50)
,@PortalId INT
,@RoleId INT
,@StatusId INT
,@Telephone VARCHAR(50)
,@UpdatedOn VARCHAR(50)
,@Username VARCHAR(100)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO Employee(CompanyId
						,CreatedOn
						,DeletedOn
						,Email
						,Fax
						,Name
						,Lastlogin
						,Password
						,PortalId
						,RoleId
						,StatusId
						,Telephone
						,UpdatedOn
						,Username)
				  VALUES(@CompanyId
						,@CreatedOn
						,@DeletedOn
						,@Email
						,@Fax
						,@Name
						,@Lastlogin
						,@Password
						,@PortalId
						,@RoleId
						,@StatusId
						,@Telephone
						,@UpdatedOn
						,@Username)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateEmployee]    Script Date: 14/03/2022 5:41:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Nikolai López>
-- Create date: <2022-03-13>
-- Description:	<Actualizar employees>
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdateEmployee]
@EmployeeId INT
,@CompanyId INT = null
,@CreatedOn VARCHAR(50) = null
,@DeletedOn VARCHAR(50) = null
,@Email VARCHAR(100) = null
,@Fax VARCHAR(50) = null
,@Name VARCHAR(50) = null
,@Lastlogin VARCHAR(50) = null
,@Password VARCHAR(50) = null
,@PortalId INT = null
,@RoleId INT = null 
,@StatusId INT = null
,@Telephone VARCHAR(50) = null
,@UpdatedOn VARCHAR(50) = null
,@Username VARCHAR(100) = null
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE Employee SET CompanyId = CASE WHEN @CompanyId IS NULL THEN CompanyId ELSE @CompanyId END
					   ,CreatedOn = CASE WHEN @CreatedOn IS NULL THEN CreatedOn ELSE @CreatedOn END
					   ,DeletedOn = CASE WHEN @DeletedOn IS NULL THEN DeletedOn ELSE @DeletedOn END
					   ,Email = CASE WHEN @Email IS NULL THEN Email ELSE @Email END
					   ,Fax = CASE WHEN @Fax IS NULL THEN Fax ELSE @Fax END
					   ,Name = CASE WHEN @Name IS NULL THEN Name ELSE @Name END
					   ,Lastlogin = CASE WHEN @Lastlogin IS NULL THEN Lastlogin ELSE @Lastlogin END
					   ,Password = CASE WHEN @Password IS NULL THEN Password ELSE @Password END
					   ,PortalId = CASE WHEN @PortalId IS NULL THEN PortalId ELSE @PortalId END
					   ,RoleId = CASE WHEN @RoleId IS NULL THEN RoleId ELSE @RoleId END
					   ,StatusId = CASE WHEN @StatusId IS NULL THEN StatusId ELSE @StatusId END
					   ,Telephone = CASE WHEN @Telephone IS NULL THEN Telephone ELSE @Telephone END
					   ,UpdatedOn = CASE WHEN @UpdatedOn IS NULL THEN UpdatedOn ELSE @UpdatedOn END
					   ,Username = CASE WHEN @Username IS NULL THEN Username ELSE @Username END
	WHERE EmployeeId = @EmployeeId

END
GO
USE [master]
GO
ALTER DATABASE [Redarbor] SET  READ_WRITE 
GO
