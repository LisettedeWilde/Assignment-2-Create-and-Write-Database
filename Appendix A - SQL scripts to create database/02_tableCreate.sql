-- =========================================
-- Create table template
-- =========================================
USE SuperHeroesDb

CREATE TABLE Superhero (
	ID int NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Name nvarchar(50) NOT NULL,
	Alias nvarchar(50) NULL,
	Origin nvarchar(50) NULL
)

CREATE TABLE Assistant (
	ID int NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Name nvarchar(50) NOT NULL
)

CREATE TABLE Power (
	ID int NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Name nvarchar(50) NOT NULL,
	Description nvarchar(50)
)
