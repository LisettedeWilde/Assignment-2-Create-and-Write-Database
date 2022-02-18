USE SuperheroesDb;

CREATE TABLE SuperheroPowers (
	SuperheroID int FOREIGN KEY REFERENCES Superheroes(ID),
	PowerID int FOREIGN KEY REFERENCES Powers(ID),
	PRIMARY KEY (SuperheroID, PowerID)
);
