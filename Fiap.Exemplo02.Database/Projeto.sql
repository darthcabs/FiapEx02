CREATE TABLE [dbo].[Projeto]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Nome] NVARCHAR(150) NOT NULL, 
    [Descricao] TEXT NULL, 
    [DataInicio] DATETIME NOT NULL, 
    [DataTermino] DATETIME NULL, 
    [Entregue] BIT NOT NULL, 
    CONSTRAINT [FK_Projeto_Grupo] FOREIGN KEY ([Id]) REFERENCES [Grupo]([Id])
)
