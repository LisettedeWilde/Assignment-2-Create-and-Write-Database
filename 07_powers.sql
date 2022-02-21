USE SuperHeroesDb

INSERT INTO Power(Name, Description)
	VALUES('X-ray vision', 'See through things')

INSERT INTO Power(Name, Description)
	VALUES('Agility', 'Moves like acrobatic')

INSERT INTO Power(Name, Description)
	VALUES('Super strength', 'Superhuman strength')

INSERT INTO Power(Name, Description)
	VALUES('Grapple', 'Grapple between distances')

INSERT INTO SuperheroPower(SuperheroID, PowerID)
	VALUES(1, 1)

INSERT INTO SuperheroPower(SuperheroID, PowerID)
	VALUES(1, 3)

INSERT INTO SuperheroPower(SuperheroID, PowerID)
	VALUES(2, 2)

INSERT INTO SuperheroPower(SuperheroID, PowerID)
	VALUES(2, 4)

INSERT INTO SuperheroPower(SuperheroID, PowerID)
	VALUES(3, 4)