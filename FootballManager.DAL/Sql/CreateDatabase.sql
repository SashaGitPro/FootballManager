USE master;
GO

IF  EXISTS (SELECT * FROM master.sys.databases WHERE name = 'FootballManager')
DROP DATABASE FootballManager;
GO

CREATE DATABASE FootballManager
COLLATE Cyrillic_General_CI_AS;
GO

USE FootballManager;
GO

/*************************************************
  Creating tables
*************************************************/

CREATE TABLE dbo.Club (
  Id int identity(1, 1) NOT NULL
    CONSTRAINT PK_Club_Id PRIMARY KEY CLUSTERED,
  Name varchar(60) NOT NULL
  CONSTRAINT Club_Name UNIQUE(Name),
  Country varchar(30) NOT NULL,
  President varchar(60) NOT NULL,
  Coach varchar(60) NOT NULL,
);
GO

CREATE TABLE dbo.Player (
  Id int identity(1, 1) NOT NULL
    CONSTRAINT PK_Publisher_Id PRIMARY KEY CLUSTERED,
  Name varchar(60) NOT NULL,
  BornCountry varchar(60) NOT NULL,
  Age int NOT NULL,
  MainPosition varchar(60) NOT NULL,
  Number int NOT NULL,
  ClubId int NOT NULL
    CONSTRAINT FK_Player_ClubId_Club_Id FOREIGN KEY 
      REFERENCES dbo.Club(Id)
);
GO

CREATE TABLE dbo.Tournament (
  Id int identity(1, 1) NOT NULL
  CONSTRAINT PK_Tournament_Id PRIMARY KEY CLUSTERED,
  Name varchar(60) NOT NULL
);
GO

CREATE TABLE dbo.ClubToTournament (
  ClubId int NOT NULL
    CONSTRAINT FK_ClubToTournament_Club_Id FOREIGN KEY 
      REFERENCES dbo.Club(Id),
  TournamentId int NOT NULL
    CONSTRAINT FK_ClubToTournament_TournamentId_Tournament_Id FOREIGN KEY 
      REFERENCES dbo.Tournament(Id),
  CONSTRAINT PK_ClubToTournament_ClubId_TournamentId PRIMARY KEY CLUSTERED (ClubId, TournamentId) 
);
GO

/*************************************************
  Inserting data
*************************************************/

SET IDENTITY_INSERT dbo.Club ON;
INSERT INTO dbo.Club (
  [Id], [Name],[Country],[President],[Coach]
) VALUES 
  (1, 'Read Madrid','Spain','Florentino Peres','Carlo Ancelotti'),
  (2, 'Barcelona','Spain','Joseph Bartomeu','Louis Enrique'),
  (3,'Chelsea','England','Roman Abramovich','Jose Mourinho'),
  (4,'Bayern Munchen', 'Karl Hophner', 'Josep Guardiola'),
  (5,'Milan AC','Silvio Berluskoni','Filippo Indzaggi')
GO
SET IDENTITY_INSERT dbo.Club OFF;

SET IDENTITY_INSERT dbo.Player ON;
INSERT INTO dbo.Player (
  [Id], [Name],[BornCountry],[Age],[MainPosition],[Number],[ClubId]
) VALUES 
  (1, 'Cristiano Ronaldo', 'Portugal',27,'Forward', 7,1),
  (2, 'Lionel Messi', 'Argentina',26,'Forward', 10,2),
  (3,'Eden Hazard', 'Belgium', 24,'Halfback',10,3),
  (4,'Tomas Muller', 'Germany', 22, 'Forward', 13, 4),
  (5,'Rickardo Montolivo','Italy', 25, 'Midfielder', 18,5)
GO
SET IDENTITY_INSERT dbo.Player OFF;

SET IDENTITY_INSERT dbo.Tournament ON;
INSERT INTO dbo.Tournament(
  [Id],[Name]
) VALUES 
 (1,'Liga BBVA'),
 (2,'APL'),
 (3,'Bundesliga'),
 (4,'Serie A')
GO
SET IDENTITY_INSERT dbo.Tournament OFF;

INSERT INTO dbo.ClubToTournament(
[ClubId],[TournamentId]
) VALUES
(1,1),
(2,1),
(3,2),
(4,3),
(5,4)
GO
