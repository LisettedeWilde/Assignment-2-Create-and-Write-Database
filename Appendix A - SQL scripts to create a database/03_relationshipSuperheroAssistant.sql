USE SuperheroesDb

ALTER TABLE Assistant
ADD SuperheroID int;

ALTER TABLE Assistant
ADD FOREIGN KEY (SuperheroID) REFERENCES Superhero(ID); 