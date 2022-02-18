USE SuperheroesDb

ALTER TABLE Assistants
ADD SuperheroID int;

ALTER TABLE Assistants
ADD FOREIGN KEY (SuperheroID) REFERENCES Superheroes(ID); 