USE [colegio]
GO
/****** Object:  Table [dbo].[alumno]    Script Date: 16/06/24 9:39:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[alumno](
	[ci] [int] primary key NOT NULL,
	[nombre] [varchar](50) NULL,
	[paterno] [varchar](50) NULL,
	[materno] [varchar](50) NULL,
	[edad] [int] NULL)
GO

INSERT [dbo].[alumno] ([ci], [nombre], [paterno], [materno], [edad]) VALUES (4561236, 'juan', 'perez', 'garcia', 23)
GO
INSERT [dbo].[alumno] ([ci], [nombre], [paterno], [materno], [edad]) VALUES (8786541, 'ana', 'quisbert', 'casas', 25)
GO
INSERT [dbo].[alumno] ([ci], [nombre], [paterno], [materno], [edad]) VALUES (5451355, 'luis', 'layme', 'rojas', 22)
GO


drop table alumno;

update alumno set nombre = 'ana' where id = 3;

select * from alumno
