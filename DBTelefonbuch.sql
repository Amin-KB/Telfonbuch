CREATE DATABASE DBTelefonbuch

GO

USE DBTelefonbuch

GO

CREATE TABLE TblTelefon(
PersonId INT PRIMARY KEY IDENTITY,
Anrede VARCHAR(10),
Vorname NVARCHAR(100),
Nachname NVARCHAR(100),
Ort NVARCHAR(50),
Telefon NVARCHAR(50),
Email NVARCHAR(100)
)