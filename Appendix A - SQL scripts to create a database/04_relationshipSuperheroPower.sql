USE SuperheroesDb;

CREATE TABLE SuperheroPowers (
	SuperheroID int FOREIGN KEY REFERENCES Superhero(ID),
	PowerID int FOREIGN KEY REFERENCES Power(ID),
	PRIMARY KEY (SuperheroID, PowerID)
);
