INSERT INTO dbo.Agenda 
(Title, Description) 
VALUES 
('Test title', 'Test description')
GO

INSERT INTO dbo.[User] 
(FirstName, LastName, UserName, Password, AgendaId) 
VALUES 
('Pesho', 'Peshev','123456', 'Pshpsh', 1)
GO