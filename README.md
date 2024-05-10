CREATE TABLE [dbo].[Equipes] (
    [RefEquipe] INT           IDENTITY (1, 1) NOT NULL,
    [Nom]       NVARCHAR (50) NULL,
    [Ville]     NVARCHAR (50) NULL,
    [Budget]    MONEY         NULL,
    [Coach]     NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([RefEquipe] ASC)
);


CREATE TABLE [dbo].[Joueurs] (
    [RefJoueur]   INT           IDENTITY (1, 1) NOT NULL,
    [Nom]         NVARCHAR (50) NULL,
    [Poste]       NVARCHAR (50) NULL,
    [Salaire]     MONEY         NULL,
    [Naissance]   DATETIME      NULL,
    [ReferEquipe] INT           NULL,
    PRIMARY KEY CLUSTERED ([RefJoueur] ASC),
    CONSTRAINT [FK_Joueurs_Equipes] FOREIGN KEY ([ReferEquipe]) REFERENCES [dbo].[Equipes] ([RefEquipe])
);
