
-- Cambiar [AppDB] por base de datos a usar
USE [AppDB]
GO

/****** Object:  Table [dbo].[Cliente]    Script Date: 29/10/2021 11:47:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cliente](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Telefono] [varchar](50) NOT NULL,
	[Pais] [varchar](50) NOT NULL,
	[Nacimiento] [date] NOT NULL,
	[DNI] [varchar](50) NOT NULL,
	[Activar] [tinyint] NOT NULL,
	[Empresa] [varchar](50) NULL,
	[Twitter] [varchar](50) NULL,
	[Intereses] [varchar](50) NULL,
	[Genero] [varchar](5) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Establecer valores por defecto
ALTER TABLE [dbo].[Cliente] ADD  CONSTRAINT [DF_Cliente_Nombre]  DEFAULT ('Test') FOR [Nombre]
GO

ALTER TABLE [dbo].[Cliente] ADD  CONSTRAINT [DF_Cliente_Apellido]  DEFAULT ('Test') FOR [Apellido]
GO

ALTER TABLE [dbo].[Cliente] ADD  CONSTRAINT [DF_Cliente_Email]  DEFAULT ('Test') FOR [Email]
GO

ALTER TABLE [dbo].[Cliente] ADD  CONSTRAINT [DF_Cliente_Telefono]  DEFAULT ('Test') FOR [Telefono]
GO

ALTER TABLE [dbo].[Cliente] ADD  CONSTRAINT [DF_Cliente_Pais]  DEFAULT ('Test') FOR [Pais]
GO

ALTER TABLE [dbo].[Cliente] ADD  CONSTRAINT [DF_Cliente_Nacimiento]  DEFAULT (getdate()) FOR [Nacimiento]
GO

ALTER TABLE [dbo].[Cliente] ADD  CONSTRAINT [DF_Cliente_DNI]  DEFAULT ('Test') FOR [DNI]
GO

ALTER TABLE [dbo].[Cliente] ADD  CONSTRAINT [DF_Cliente_Activar]  DEFAULT ((0)) FOR [Activar]
GO

