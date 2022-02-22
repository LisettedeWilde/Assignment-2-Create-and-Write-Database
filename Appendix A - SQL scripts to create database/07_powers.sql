USE SuperHeroesDb

INSERT INTO Power(Name, Description)
VALUES
('X-ray vision', 'See through things'),
('Agility', 'Moves like acrobatic'),
('Super strength', 'Superhuman strength'),
('Grapple', 'Grapple between distances');

INSERT INTO SuperheroPower(SuperheroID, PowerID)
VALUES
(1, 1),
(1, 3),
(2, 2),
(2, 4),
(3, 4);