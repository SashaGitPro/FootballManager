CREATE TABLE [dbo].[Player] (
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (60) NOT NULL,
    [BornCountry]  VARCHAR (60) NOT NULL,
    [Age]          INT          NOT NULL,
    [MainPosition] VARCHAR (60) NOT NULL,
    [Number]       INT          NOT NULL,
    [ClubId]       INT          NOT NULL,
    CONSTRAINT [PK_Publisher_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Player_ClubId_Club_Id] FOREIGN KEY ([ClubId]) REFERENCES [dbo].[Club] ([Id])
);

