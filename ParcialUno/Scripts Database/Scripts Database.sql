IF NOT EXISTS (SELECT * FROM sysdatabases WHERE (name = 'ParcialUno')) 
BEGIN
	CREATE DATABASE ParcialUno
END
GO
USE ParcialUno

----------------- CREACIÓN TABLAS ------------------------------------
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Usuario')
BEGIN
	CREATE TABLE [dbo].[Usuario] (
		[UsuarioCedula]                             BIGINT							NOT NULL,
		[UsuarioNombre]								VARCHAR (250)					NOT NULL,
		[UsuarioApellido]							VARCHAR (250)					NOT NULL,
		[UsuarioCorreo]								VARCHAR (250)					NOT NULL,
		CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED ([UsuarioCedula] ASC)
	);
END
GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'VideoJuego')
BEGIN
	CREATE TABLE [dbo].[VideoJuego] (
		[VideoJuegoCodigo]                          BIGINT							NOT NULL,
		[VideoJuegoCodigoEjemplar]					BIGINT							NOT NULL,
		[VideoJuegoNombre]							VARCHAR (250)					NOT NULL,
		CONSTRAINT [PK_VideoJuego] PRIMARY KEY CLUSTERED ([VideoJuegoCodigo],[VideoJuegoCodigoEjemplar] ASC)
	);
END
GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Prestamo')
BEGIN
	CREATE TABLE [dbo].[Prestamo] (
		[PrestamoId]								BIGINT			IDENTITY(1,1)	NOT NULL,
		[UsuarioCedula]								BIGINT							NOT NULL,
		[VideoJuegoCodigo]                          BIGINT							NOT NULL,
		[VideoJuegoCodigoEjemplar]					BIGINT							NOT NULL,
		[PrestamoFechaRegistro]						DATETIME						NOT NULL,
		[EsDevuelto]								BIT								NOT NULL,
		CONSTRAINT [PK_Prestamo] PRIMARY KEY CLUSTERED ([PrestamoId] ASC),
		FOREIGN KEY (VideoJuegoCodigo, VideoJuegoCodigoEjemplar) REFERENCES VideoJuego(VideoJuegoCodigo, VideoJuegoCodigoEjemplar),
		FOREIGN KEY (UsuarioCedula) REFERENCES Usuario(UsuarioCedula)
	);
END
GO

