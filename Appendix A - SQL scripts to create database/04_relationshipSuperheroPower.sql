USE SuperHeroesDb

CREATE TABLE SuperheroPower (
	SuperHeroID int NOT NULL,
	PowerID int NOT NULL,
	CONSTRAINT FK_Superhero_SuperheroPower FOREIGN KEY (SuperheroID) REFERENCES Superhero(ID),
	CONSTRAINT FK_Power_SuperheroPower FOREIGN KEY (PowerID) REFERENCES Power(ID),
	CONSTRAINT PK_SuperheroPowerID PRIMARY KEY (SuperheroID, PowerID)
)