INSERT INTO dbo.Agenda 
(Title, Description) 
VALUES 
('Test title', 'Test description')
GO

INSERT INTO dbo.[User] 
(FirstName, LastName, Email, Password, AgendaId) 
VALUES 
('admin', 'admin', 'aa@aa.aa','123456', 1)
GO