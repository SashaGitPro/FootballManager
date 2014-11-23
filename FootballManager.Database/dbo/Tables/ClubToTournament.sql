CREATE TABLE [dbo].[ClubToTournament] (
    [ClubId]       INT NOT NULL,
    [TournamentId] INT NOT NULL,
    CONSTRAINT [PK_ClubToTournament_ClubId_TournamentId] PRIMARY KEY CLUSTERED ([ClubId] ASC, [TournamentId] ASC),
    CONSTRAINT [FK_ClubToTournament_Club_Id] FOREIGN KEY ([ClubId]) REFERENCES [dbo].[Club] ([Id]),
    CONSTRAINT [FK_ClubToTournament_TournamentId_Tournament_Id] FOREIGN KEY ([TournamentId]) REFERENCES [dbo].[Tournament] ([Id])
);

