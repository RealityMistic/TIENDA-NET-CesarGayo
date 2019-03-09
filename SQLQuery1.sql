
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/06/2019 16:39:06
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

IF OBJECT_ID(N'[dbo].[FK_PedidoProducto_Pedido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PedidoProducto] DROP CONSTRAINT [FK_PedidoProducto_Pedido];
GO
IF OBJECT_ID(N'[dbo].[FK_PedidoProductoProductoSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PedidoProducto] DROP CONSTRAINT [FK_PedidoProductoProductoSet];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[PedidoProducto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PedidoProducto];
GO
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

-- Creating table 'PedidoProducto'
CREATE TABLE [dbo].[PedidoProducto] (
    [Pedido_Id] int  NOT NULL,
    [Producto_Id] int  NOT NULL,
    [ProductoSet_Id] int  NOT NULL
);
GO

-- Creating table 'PedidoSet'
CREATE TABLE [dbo].[PedidoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Fecha] datetime  NULL,
    [Completado] nvarchar(max)  NOT NULL,
    [Usuario_Id] int  NOT NULL
);
GO

-- Creating table 'ProductoSet'
CREATE TABLE [dbo].[ProductoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [Stock] nvarchar(max)  NOT NULL,
    [Cantidad] nvarchar(max)  NOT NULL
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

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Pedido_Id], [Producto_Id] in table 'PedidoProducto'
ALTER TABLE [dbo].[PedidoProducto]
ADD CONSTRAINT [PK_PedidoProducto]
    PRIMARY KEY CLUSTERED ([Pedido_Id], [Producto_Id] ASC);
GO

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

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Pedido_Id] in table 'PedidoProducto'
ALTER TABLE [dbo].[PedidoProducto]
ADD CONSTRAINT [FK_PedidoProducto_Pedido]
    FOREIGN KEY ([Pedido_Id])
    REFERENCES [dbo].[PedidoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ProductoSet_Id] in table 'PedidoProducto'
ALTER TABLE [dbo].[PedidoProducto]
ADD CONSTRAINT [FK_PedidoProductoProductoSet]
    FOREIGN KEY ([ProductoSet_Id])
    REFERENCES [dbo].[ProductoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PedidoProductoProductoSet'
CREATE INDEX [IX_FK_PedidoProductoProductoSet]
ON [dbo].[PedidoProducto]
    ([ProductoSet_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------