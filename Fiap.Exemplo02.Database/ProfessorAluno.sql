CREATE TABLE [dbo].[ProfessorAluno]
(
	[AlunoId] INT NOT NULL , 
    [ProfessorId] INT NOT NULL, 
    PRIMARY KEY ([AlunoId], [ProfessorId]),
	CONSTRAINT [FK_ProfessorAluno_Aluno] FOREIGN KEY ([AlunoId]) REFERENCES [Aluno]([Id]), 
    CONSTRAINT [FK_ProfessorAluno_Professor] FOREIGN KEY ([ProfessorId]) REFERENCES [Professor]([Id])
)
