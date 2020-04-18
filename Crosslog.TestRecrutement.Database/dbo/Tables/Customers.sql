CREATE TABLE [dbo].[Customers] (
    [CustomerId] INT          IDENTITY (1, 1) NOT NULL,
    [LastName]   VARCHAR (50) NULL,
    [FirstName]  VARCHAR (50) NULL,
    [Address]    VARCHAR (50) NULL,
    [ZipCode]    VARCHAR (50) NULL,
    [City]       VARCHAR (50) NULL,
    [Email]      VARCHAR (50) NULL,
    [Phone]      VARCHAR (50) NULL
);

