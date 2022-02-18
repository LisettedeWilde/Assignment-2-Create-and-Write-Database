USE SuperheroesDb;

CREATE TABLE Superheroes (
	ID int PRIMARY KEY IDENTITY(1,1),
	Superhero_Name nvarchar(35) NULL,
	Alias nvarchar(35) NULL,
	Origin nvarchar(50) NULL
);

CREATE TABLE Assistants (
	ID int PRIMARY KEY IDENTITY(1,1),
	Name nvarchar(35) NULL
);

CREATE TABLE Powers (
	ID int PRIMARY KEY IDENTITY(1,1),
	Name nvarchar(35) NULL,
	Description nvarchar(100) NULL,
);