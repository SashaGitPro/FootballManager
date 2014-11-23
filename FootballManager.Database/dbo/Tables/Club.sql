CREATE TABLE [dbo].[Club] (
    [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (60) NOT NULL,
    [Country]   VARCHAR (30) NOT NULL,
    [President] VARCHAR (60) NOT NULL,
    [Coach]     VARCHAR (60) NOT NULL,
    CONSTRAINT [PK_Club_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [Club_Name] UNIQUE NONCLUSTERED ([Name] ASC)
);

