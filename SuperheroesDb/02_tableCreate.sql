-- =========================================
-- Create table template
-- =========================================
USE SuperHeroesDb

CREATE TABLE Superhero (
	ID int PRIMARY KEY IDENTITY(1, 1),
	Name nvarchar(50),
	Alias nvarchar(50),
	Origin nvarchar(50)
)

CREATE TABLE Assistant (
	ID int PRIMARY KEY IDENTITY(1, 1),
	Name nvarchar(50)
)

CREATE TABLE Power (
	ID int PRIMARY KEY IDENTITY(1, 1),
	Name nvarchar(50),
	Description nvarchar(50)
)
