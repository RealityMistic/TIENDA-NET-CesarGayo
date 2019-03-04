
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/04/2019 22:07:09
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

IF OBJECT_ID(N'[dbo].[FK_UsuarioPedido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PedidoSet] DROP CONSTRAINT [FK_UsuarioPedido];
GO

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
    [Fecha] nvarchar(max)  NULL,
    [Completado] nvarchar(max)  NOT NULL,
    [Usuario_Id] int  NOT NULL,
    [Property1] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProductoSet'
CREATE TABLE [dbo].[ProductoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [Stock] nvarchar(max)  NOT NULL
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

-- Creating table 'PedidoSetProductoSet'
CREATE TABLE [dbo].[PedidoSetProductoSet] (
    [PedidoSet_Id] int  NOT NULL,
    [ProductoSet_Id] int  NOT NULL
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

-- Creating primary key on [PedidoSet_Id], [ProductoSet_Id] in table 'PedidoSetProductoSet'
ALTER TABLE [dbo].[PedidoSetProductoSet]
ADD CONSTRAINT [PK_PedidoSetProductoSet]
    PRIMARY KEY CLUSTERED ([PedidoSet_Id], [ProductoSet_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Usuario_Id] in table 'PedidoSet'
ALTER TABLE [dbo].[PedidoSet]
ADD CONSTRAINT [FK_UsuarioPedido]
    FOREIGN KEY ([Usuario_Id])
    REFERENCES [dbo].[UsuarioSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioPedido'
CREATE INDEX [IX_FK_UsuarioPedido]
ON [dbo].[PedidoSet]
    ([Usuario_Id]);
GO

-- Creating foreign key on [PedidoSet_Id] in table 'PedidoSetProductoSet'
ALTER TABLE [dbo].[PedidoSetProductoSet]
ADD CONSTRAINT [FK_PedidoSetProductoSet_PedidoSet]
    FOREIGN KEY ([PedidoSet_Id])
    REFERENCES [dbo].[PedidoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ProductoSet_Id] in table 'PedidoSetProductoSet'
ALTER TABLE [dbo].[PedidoSetProductoSet]
ADD CONSTRAINT [FK_PedidoSetProductoSet_ProductoSet]
    FOREIGN KEY ([ProductoSet_Id])
    REFERENCES [dbo].[ProductoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PedidoSetProductoSet_ProductoSet'
CREATE INDEX [IX_FK_PedidoSetProductoSet_ProductoSet]
ON [dbo].[PedidoSetProductoSet]
    ([ProductoSet_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------