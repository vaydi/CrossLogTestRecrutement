CREATE TABLE [dbo].[Orders] (
    [OrderId]     INT          IDENTITY (1, 1) NOT NULL,
    [OrderNumber] VARCHAR (50) NULL,
    [CustomerId]  INT          NULL,
    [OrderDate]   DATETIME     NULL
);

