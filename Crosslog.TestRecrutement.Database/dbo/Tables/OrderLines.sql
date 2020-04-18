CREATE TABLE [dbo].[OrderLines] (
    [OrderLineId] INT IDENTITY (1, 1) NOT NULL,
    [OrderId]     INT NULL,
    [ProductId]   INT NULL,
    [Quantity]    INT NULL
);

