CREATE TABLE [dbo].[Tournament] (
    [Id]   INT          IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (60) NOT NULL,
    CONSTRAINT [PK_Tournament_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);

