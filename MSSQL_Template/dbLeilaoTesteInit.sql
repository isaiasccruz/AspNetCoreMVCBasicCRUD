USE [master]
GO

CREATE DATABASE [dbLeilaoTeste]
 CONTAINMENT = NONE
GO

ALTER DATABASE [dbLeilaoTeste] SET COMPATIBILITY_LEVEL = 120
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbLeilaoTeste].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [dbLeilaoTeste] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [dbLeilaoTeste] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [dbLeilaoTeste] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [dbLeilaoTeste] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [dbLeilaoTeste] SET ARITHABORT OFF 
GO

ALTER DATABASE [dbLeilaoTeste] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [dbLeilaoTeste] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [dbLeilaoTeste] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [dbLeilaoTeste] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [dbLeilaoTeste] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [dbLeilaoTeste] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [dbLeilaoTeste] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [dbLeilaoTeste] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [dbLeilaoTeste] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [dbLeilaoTeste] SET  ENABLE_BROKER 
GO

ALTER DATABASE [dbLeilaoTeste] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [dbLeilaoTeste] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [dbLeilaoTeste] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [dbLeilaoTeste] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO

ALTER DATABASE [dbLeilaoTeste] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [dbLeilaoTeste] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [dbLeilaoTeste] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [dbLeilaoTeste] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [dbLeilaoTeste] SET  MULTI_USER 
GO

ALTER DATABASE [dbLeilaoTeste] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [dbLeilaoTeste] SET DB_CHAINING OFF 
GO

ALTER DATABASE [dbLeilaoTeste] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [dbLeilaoTeste] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO


ALTER DATABASE [dbLeilaoTeste] SET  READ_WRITE 
GO

CREATE TABLE [dbo].[tPerfil](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DescPerfil] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tPerfil] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = ON, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE [dbo].[tUsuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](300) NOT NULL,
	[Login] [varchar](50) NOT NULL,
	[Senha] [varchar](100) NOT NULL,
	[IdPerfil] [int] NOT NULL,	
	[Ativo] [bit] NOT NULL,
	[Logado] [bit] NOT NULL,
	[UltimaConexao] [datetime] NULL,
 CONSTRAINT [PK_tUsuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = on, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tUsuario] ADD  CONSTRAINT [DF_tUsuario_Logado]  DEFAULT ((0)) FOR [Logado]
GO


CREATE TABLE [dbo].[tLeilao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuarioResponsavel] [int] NOT NULL,
	[NomeLeilao] [varchar](300) NOT NULL,
	[ValorInicial] [varchar](100) NOT NULL,
	[ValorFinal] [varchar](100) NULL,
	[EstadoDoItem] [varchar](100) NULL,		
	[DataAbertura] [datetime] NOT NULL,
	[DataFechamento] [datetime] NULL,
 CONSTRAINT [PK_tLeilao] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = on, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

insert into tperfil values ('admin')
insert into tperfil values ('usuario')

insert into tusuario values ('Isa�as','isaias.cruz','UHL8B/Z2P0+Dmro4vf/W0A==',1,1,0,null)

insert into tleilao values (1,'Leilao1','22,50',null,'Ativo',GETDATE(),null)