USE [BBDDMascota]
GO

/****** Object: Table [dbo].[mascota] Script Date: 2/4/2022 12:05:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[mascota] (
    [Id]     INT          IDENTITY (1, 1) NOT NULL,
    [nombre] VARCHAR (30) NOT NULL,
    [raza]   VARCHAR (30) NOT NULL,
    [edad]   INT          NOT NULL
);


