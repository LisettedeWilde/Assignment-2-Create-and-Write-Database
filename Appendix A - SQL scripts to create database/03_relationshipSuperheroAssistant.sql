USE SuperHeroesDb

ALTER TABLE Assistant
	ADD SuperheroID int

ALTER TABLE Assistant
	ADD CONSTRAINT FK_Superhero_Assistant FOREIGN KEY (SuperheroID) REFERENCES Superhero(ID)