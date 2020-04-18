CREATE TABLE [dbo].[Products] (
    [ProductId]   INT             IDENTITY (1, 1) NOT NULL,
    [ProductName] VARCHAR (50)    NULL,
    [ProductCode] VARCHAR (50)    NULL,
    [Price]       DECIMAL (18, 2) NULL
);

