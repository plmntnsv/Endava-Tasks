CREATE TABLE [dbo].[Agenda]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY,
	[Title] nvarchar(100) NOT NULL,
	[Description] NVARCHAR(max) NOT NULL,
)
