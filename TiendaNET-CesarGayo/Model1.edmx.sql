
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/08/2019 18:10:29
-- Generated from EDMX file: C:\Users\cesar\source\repos\TiendaNET-CesarGayo\TiendaNET-CesarGayo\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO

GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[PedidoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PedidoSet];
GO
IF OBJECT_ID(N'[dbo].[ProductoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductoSet];
GO
IF OBJECT_ID(N'[dbo].[UsuarioSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsuarioSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'PedidoSet'
CREATE TABLE [dbo].[PedidoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Fecha] datetime  NULL,
    [Completado] nvarchar(max)  NOT NULL,
    [Producto_Id] nvarchar(max)  NOT NULL,
    [Precio] nvarchar(max)  NOT NULL,
    [Cantidad] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProductoSet'
CREATE TABLE [dbo].[ProductoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NULL,
    [Cantidad] int  NOT NULL,
    [Precio] int  NOT NULL
);
GO

-- Creating table 'UsuarioSet'
CREATE TABLE [dbo].[UsuarioSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Telefono] nvarchar(max)  NOT NULL,
    [Direccion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'StockSet'
CREATE TABLE [dbo].[StockSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Producto_Id] nvarchar(max)  NOT NULL,
    [Cantidad] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'PedidoSet'
ALTER TABLE [dbo].[PedidoSet]
ADD CONSTRAINT [PK_PedidoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductoSet'
ALTER TABLE [dbo].[ProductoSet]
ADD CONSTRAINT [PK_ProductoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsuarioSet'
ALTER TABLE [dbo].[UsuarioSet]
ADD CONSTRAINT [PK_UsuarioSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StockSet'
ALTER TABLE [dbo].[StockSet]
ADD CONSTRAINT [PK_StockSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------