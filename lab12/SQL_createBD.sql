CREATE DATABASE PhoneBookDB_НЕКРАСОВА_2307Б2;
GO
USE PhoneBookDB_НЕКРАСОВА_2307Б2;
GO
CREATE TABLE Contacts (
Id INT IDENTITY(1,1) PRIMARY KEY,
Name NVARCHAR(100) NOT NULL,
Phone NVARCHAR(20) NOT NULL
);
INSERT INTO Contacts (Name, Phone) VALUES
('Иванов Иван', '+7 (999) 123-45-67'),
('Петрова Мария', '+7 (999) 765-43-21'),
('Сидоров Алексей', '+7 (999) 555-88-99');