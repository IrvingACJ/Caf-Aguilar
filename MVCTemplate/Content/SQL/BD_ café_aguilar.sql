USE [CafeAguilar]
GO
/****** Object:  Table [dbo].[Cafés]    Script Date: 6/24/2021 5:20:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cafés](
	[IDcafé] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[IDtamaño] [int] NOT NULL,
	[IDtipo] [int] NOT NULL,
	[Precio] [money] NULL,
 CONSTRAINT [PK_Cafés] PRIMARY KEY CLUSTERED 
(
	[IDcafé] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetallesOrdenCafés]    Script Date: 6/24/2021 5:20:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallesOrdenCafés](
	[ID] [int] NOT NULL,
	[IDorden] [int] NULL,
	[IDcafé] [int] NULL,
	[Cantidad] [int] NULL,
 CONSTRAINT [PK_DetallesOrdenCafés] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetallesOrdenPostres]    Script Date: 6/24/2021 5:20:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallesOrdenPostres](
	[ID] [int] NOT NULL,
	[IDorden] [int] NULL,
	[IDpostres] [int] NULL,
	[Cantidad] [int] NULL,
 CONSTRAINT [PK_DetallesOrden	Postres] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Postres]    Script Date: 6/24/2021 5:20:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Postres](
	[IDpostre] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Precio] [money] NULL,
 CONSTRAINT [PK_Postres] PRIMARY KEY CLUSTERED 
(
	[IDpostre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[OrdenCompleta]    Script Date: 6/24/2021 5:20:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[OrdenCompleta] AS
SELECT ROW_NUMBER()OVER(ORDER BY t.IDorden ASC) as ID_COL,t.* 
from(
SELECT tD.IDorden, td.IDcafé as IDproduct, tC.Nombre, tC.Precio, td.Cantidad, 'Café' as Tipo FROM  DetallesOrdenCafés as tD
	INNER JOIN Cafés as tC
		on tD.IDcafé = tC.IDcafé
	UNION ALL
	SELECT tD.IDorden, tD.IDpostres as IDproduct, tP.Nombre,tP.Precio, td.Cantidad,'Postre' as Tipo FROM DetallesOrdenPostres tD
		INNER JOIN Postres as tP
			on tD.IDpostres = tP.IDpostre) AS t
GO
/****** Object:  Table [dbo].[Inventario_Productos]    Script Date: 6/24/2021 5:20:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventario_Productos](
	[IDproducto] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Precio] [money] NULL,
	[Cantidad] [int] NULL,
	[Minimo] [int] NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[IDproducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orden]    Script Date: 6/24/2021 5:20:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orden](
	[IDorden] [int] NOT NULL,
	[Fecha] [datetime] NULL,
	[postres] [money] NULL,
	[cafés] [money] NULL,
	[extras] [money] NULL,
	[total] [money] NULL,
 CONSTRAINT [PK_Orden] PRIMARY KEY CLUSTERED 
(
	[IDorden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permisos]    Script Date: 6/24/2021 5:20:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permisos](
	[IDpermiso] [int] NOT NULL,
	[Permiso] [varchar](100) NULL,
 CONSTRAINT [PK_Permisos] PRIMARY KEY CLUSTERED 
(
	[IDpermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permisos_Usuarios]    Script Date: 6/24/2021 5:20:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permisos_Usuarios](
	[ID] [int] NOT NULL,
	[IDpermiso] [int] NOT NULL,
	[IDusuario] [int] NOT NULL,
 CONSTRAINT [PK_Permiso_Usuarios] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tamaños]    Script Date: 6/24/2021 5:20:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tamaños](
	[IDtamaño] [int] NOT NULL,
	[Tamaño] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tamaños] PRIMARY KEY CLUSTERED 
(
	[IDtamaño] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipos]    Script Date: 6/24/2021 5:20:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipos](
	[IDtipo] [int] NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tipos] PRIMARY KEY CLUSTERED 
(
	[IDtipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 6/24/2021 5:20:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IDusuario] [int] NOT NULL,
	[Nombre] [varchar](20) NULL,
	[Contraseña] [varchar](50) NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[IDusuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ventas_Inventario]    Script Date: 6/24/2021 5:20:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ventas_Inventario](
	[ID] [int] NOT NULL,
	[IDproducto] [int] NULL,
	[IDcafé] [int] NULL,
	[IDpostre] [int] NULL,
 CONSTRAINT [PK_Inventario_Productos] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Cafés] ([IDcafé], [Nombre], [IDtamaño], [IDtipo], [Precio]) VALUES (1, N'Expresso', 1, 1, 10.0000)
GO
INSERT [dbo].[Cafés] ([IDcafé], [Nombre], [IDtamaño], [IDtipo], [Precio]) VALUES (2, N'Expresso', 2, 1, 18.0000)
GO
INSERT [dbo].[Cafés] ([IDcafé], [Nombre], [IDtamaño], [IDtipo], [Precio]) VALUES (3, N'Americano', 1, 1, 20.0000)
GO
INSERT [dbo].[Cafés] ([IDcafé], [Nombre], [IDtamaño], [IDtipo], [Precio]) VALUES (4, N'Americano', 2, 1, 25.0000)
GO
INSERT [dbo].[Cafés] ([IDcafé], [Nombre], [IDtamaño], [IDtipo], [Precio]) VALUES (5, N'Capuccino', 1, 1, 35.0000)
GO
INSERT [dbo].[Cafés] ([IDcafé], [Nombre], [IDtamaño], [IDtipo], [Precio]) VALUES (6, N'Capuccino', 2, 1, 45.0000)
GO
INSERT [dbo].[Cafés] ([IDcafé], [Nombre], [IDtamaño], [IDtipo], [Precio]) VALUES (7, N'Latte', 1, 3, 60.0000)
GO
INSERT [dbo].[Cafés] ([IDcafé], [Nombre], [IDtamaño], [IDtipo], [Precio]) VALUES (8, N'Mazapan', 1, 3, 60.0000)
GO
INSERT [dbo].[Cafés] ([IDcafé], [Nombre], [IDtamaño], [IDtipo], [Precio]) VALUES (9, N'Oreo', 1, 3, 60.0000)
GO
INSERT [dbo].[DetallesOrdenCafés] ([ID], [IDorden], [IDcafé], [Cantidad]) VALUES (1, 1, 1, 1)
GO
INSERT [dbo].[DetallesOrdenCafés] ([ID], [IDorden], [IDcafé], [Cantidad]) VALUES (2, 1, 4, 1)
GO
INSERT [dbo].[DetallesOrdenCafés] ([ID], [IDorden], [IDcafé], [Cantidad]) VALUES (3, 2, 5, 1)
GO
INSERT [dbo].[DetallesOrdenCafés] ([ID], [IDorden], [IDcafé], [Cantidad]) VALUES (4, 4, 4, 1)
GO
INSERT [dbo].[DetallesOrdenCafés] ([ID], [IDorden], [IDcafé], [Cantidad]) VALUES (5, 4, 6, 1)
GO
INSERT [dbo].[DetallesOrdenCafés] ([ID], [IDorden], [IDcafé], [Cantidad]) VALUES (6, 4, 8, 1)
GO
INSERT [dbo].[DetallesOrdenCafés] ([ID], [IDorden], [IDcafé], [Cantidad]) VALUES (7, 4, 3, 1)
GO
INSERT [dbo].[DetallesOrdenPostres] ([ID], [IDorden], [IDpostres], [Cantidad]) VALUES (1, 1, 1, 1)
GO
INSERT [dbo].[DetallesOrdenPostres] ([ID], [IDorden], [IDpostres], [Cantidad]) VALUES (2, 2, 1, 1)
GO
INSERT [dbo].[DetallesOrdenPostres] ([ID], [IDorden], [IDpostres], [Cantidad]) VALUES (3, 2, 2, 1)
GO
INSERT [dbo].[DetallesOrdenPostres] ([ID], [IDorden], [IDpostres], [Cantidad]) VALUES (4, 4, 2, 1)
GO
INSERT [dbo].[DetallesOrdenPostres] ([ID], [IDorden], [IDpostres], [Cantidad]) VALUES (5, 4, 4, 1)
GO
INSERT [dbo].[Inventario_Productos] ([IDproducto], [Nombre], [Precio], [Cantidad], [Minimo]) VALUES (2, N'Vaso Cartón 20oz', 1.5000, 248, 50)
GO
INSERT [dbo].[Inventario_Productos] ([IDproducto], [Nombre], [Precio], [Cantidad], [Minimo]) VALUES (3, N'Cuchara Desechable', 0.6500, 498, 100)
GO
INSERT [dbo].[Inventario_Productos] ([IDproducto], [Nombre], [Precio], [Cantidad], [Minimo]) VALUES (4, N'Tenedor Desechable', 0.6500, 498, 100)
GO
INSERT [dbo].[Inventario_Productos] ([IDproducto], [Nombre], [Precio], [Cantidad], [Minimo]) VALUES (5, N'Popote', 0.3600, 1249, 100)
GO
INSERT [dbo].[Inventario_Productos] ([IDproducto], [Nombre], [Precio], [Cantidad], [Minimo]) VALUES (6, N'Tapadera Americano 20oz', 2.3200, 248, 50)
GO
INSERT [dbo].[Inventario_Productos] ([IDproducto], [Nombre], [Precio], [Cantidad], [Minimo]) VALUES (9, N'Vaso Plastico 12oz', 3.0300, 197, 50)
GO
INSERT [dbo].[Inventario_Productos] ([IDproducto], [Nombre], [Precio], [Cantidad], [Minimo]) VALUES (10, N'Vaso Cartón 12oz', 1.3000, 249, 50)
GO
INSERT [dbo].[Inventario_Productos] ([IDproducto], [Nombre], [Precio], [Cantidad], [Minimo]) VALUES (11, N'Tapadera Americano 12oz', 2.1200, 249, 50)
GO
INSERT [dbo].[Inventario_Productos] ([IDproducto], [Nombre], [Precio], [Cantidad], [Minimo]) VALUES (12, N'Tapadera Frappe 12oz', 1.7500, 199, 50)
GO
INSERT [dbo].[Inventario_Productos] ([IDproducto], [Nombre], [Precio], [Cantidad], [Minimo]) VALUES (13, N'Tapadera Plástico Plana 12oz', 1.7500, 198, 50)
GO
INSERT [dbo].[Orden] ([IDorden], [Fecha], [postres], [cafés], [extras], [total]) VALUES (1, CAST(N'2021-06-22T18:14:44.623' AS DateTime), NULL, NULL, NULL, 80.0000)
GO
INSERT [dbo].[Orden] ([IDorden], [Fecha], [postres], [cafés], [extras], [total]) VALUES (2, CAST(N'2021-06-22T18:25:05.847' AS DateTime), NULL, NULL, NULL, 115.0000)
GO
INSERT [dbo].[Orden] ([IDorden], [Fecha], [postres], [cafés], [extras], [total]) VALUES (3, CAST(N'2021-06-23T17:49:20.430' AS DateTime), NULL, NULL, NULL, 0.0000)
GO
INSERT [dbo].[Orden] ([IDorden], [Fecha], [postres], [cafés], [extras], [total]) VALUES (4, CAST(N'2021-06-23T20:10:28.797' AS DateTime), NULL, NULL, NULL, 230.0000)
GO
INSERT [dbo].[Postres] ([IDpostre], [Nombre], [Precio]) VALUES (1, N'Chessecake Brownie', 45.0000)
GO
INSERT [dbo].[Postres] ([IDpostre], [Nombre], [Precio]) VALUES (2, N'Affogato', 35.0000)
GO
INSERT [dbo].[Postres] ([IDpostre], [Nombre], [Precio]) VALUES (3, N'Pastel de Queso', 45.0000)
GO
INSERT [dbo].[Postres] ([IDpostre], [Nombre], [Precio]) VALUES (4, N'Pastel de Zanahoria', 45.0000)
GO
INSERT [dbo].[Postres] ([IDpostre], [Nombre], [Precio]) VALUES (5, N'Tarta de Limón', 45.0000)
GO
INSERT [dbo].[Tamaños] ([IDtamaño], [Tamaño]) VALUES (1, N'Normal')
GO
INSERT [dbo].[Tamaños] ([IDtamaño], [Tamaño]) VALUES (2, N'Grande')
GO
INSERT [dbo].[Tipos] ([IDtipo], [Tipo]) VALUES (1, N'Regular')
GO
INSERT [dbo].[Tipos] ([IDtipo], [Tipo]) VALUES (2, N'Rocas')
GO
INSERT [dbo].[Tipos] ([IDtipo], [Tipo]) VALUES (3, N'Frappe')
GO
ALTER TABLE [dbo].[Cafés]  WITH CHECK ADD FOREIGN KEY([IDtamaño])
REFERENCES [dbo].[Tamaños] ([IDtamaño])
GO
ALTER TABLE [dbo].[Cafés]  WITH CHECK ADD FOREIGN KEY([IDtipo])
REFERENCES [dbo].[Tipos] ([IDtipo])
GO
ALTER TABLE [dbo].[DetallesOrdenCafés]  WITH CHECK ADD FOREIGN KEY([IDcafé])
REFERENCES [dbo].[Cafés] ([IDcafé])
GO
ALTER TABLE [dbo].[DetallesOrdenCafés]  WITH CHECK ADD FOREIGN KEY([IDorden])
REFERENCES [dbo].[Orden] ([IDorden])
GO
ALTER TABLE [dbo].[DetallesOrdenPostres]  WITH CHECK ADD FOREIGN KEY([IDorden])
REFERENCES [dbo].[Orden] ([IDorden])
GO
ALTER TABLE [dbo].[DetallesOrdenPostres]  WITH CHECK ADD FOREIGN KEY([IDpostres])
REFERENCES [dbo].[Postres] ([IDpostre])
GO
ALTER TABLE [dbo].[Permisos_Usuarios]  WITH CHECK ADD FOREIGN KEY([IDpermiso])
REFERENCES [dbo].[Permisos] ([IDpermiso])
GO
ALTER TABLE [dbo].[Permisos_Usuarios]  WITH CHECK ADD FOREIGN KEY([IDusuario])
REFERENCES [dbo].[Usuarios] ([IDusuario])
GO
ALTER TABLE [dbo].[Ventas_Inventario]  WITH CHECK ADD FOREIGN KEY([IDcafé])
REFERENCES [dbo].[Cafés] ([IDcafé])
GO
ALTER TABLE [dbo].[Ventas_Inventario]  WITH CHECK ADD FOREIGN KEY([IDpostre])
REFERENCES [dbo].[Postres] ([IDpostre])
GO
ALTER TABLE [dbo].[Ventas_Inventario]  WITH CHECK ADD FOREIGN KEY([IDproducto])
REFERENCES [dbo].[Inventario_Productos] ([IDproducto])
GO
/****** Object:  StoredProcedure [dbo].[SP_CafeFecha]    Script Date: 6/24/2021 5:20:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_CafeFecha]
@fechaInicio DATETIME, @fechaFin DATETIME
AS
SELECT COUNT(*) AS Total  FROM OrdenCompleta as ventas
		INNER JOIN Orden as detalles 
		 ON ventas.IDorden = detalles.IDorden
		 WHERE Fecha BETWEEN @fechaInicio AND @fechaFin AND Tipo='Café';
GO
/****** Object:  StoredProcedure [dbo].[SP_PostresFechas]    Script Date: 6/24/2021 5:20:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_PostresFechas]
@fechaInicio DATETIME, @fechaFin DATETIME
AS
SELECT COUNT(*) AS Total  FROM OrdenCompleta as ventas
		INNER JOIN Orden as detalles 
		 ON ventas.IDorden = detalles.IDorden
		 WHERE Fecha BETWEEN @fechaInicio AND @fechaFin AND Tipo='Postre';
GO
/****** Object:  StoredProcedure [dbo].[SP_TopVentaCafe]    Script Date: 6/24/2021 5:20:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_TopVentaCafe]
@fechaInicio DATETIME, @fechaFin DATETIME
AS
SELECT ventas.Nombre, sum(ventas.Cantidad) AS Cantidad FROM OrdenCompleta as ventas
	INNER JOIN Orden as detalles ON ventas.IDorden =detalles.IDorden
	WHERE (ventas.Tipo) = 'Café' AND (detalles.Fecha BETWEEN @fechaInicio AND @fechaFin)
	GROUP BY (Nombre) ORDER BY Cantidad DESC
GO
/****** Object:  StoredProcedure [dbo].[SP_TopVentaPostres]    Script Date: 6/24/2021 5:20:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_TopVentaPostres]
@fechaInicio DATETIME, @fechaFin DATETIME
AS
SELECT ventas.Nombre, sum(ventas.Cantidad) AS Cantidad FROM OrdenCompleta as ventas
	INNER JOIN Orden as detalles ON ventas.IDorden =detalles.IDorden
	WHERE (ventas.Tipo) = 'Postre' AND (detalles.Fecha BETWEEN @fechaInicio AND @fechaFin)
	GROUP BY (Nombre) ORDER BY Cantidad DESC
GO
USE [master]
GO
ALTER DATABASE [CafeAguilar] SET  READ_WRITE 
GO
