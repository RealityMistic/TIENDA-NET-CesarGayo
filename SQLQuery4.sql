CREATE TABLE [dbo].[StockSet] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    
    [Producto_Id] INT            NOT NULL,

    [Cantidad] INT NOT NULL, 
    CONSTRAINT [PK_StockSet] PRIMARY KEY CLUSTERED ([Id] ASC)
);