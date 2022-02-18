USE SuperheroesDb;

INSERT INTO Powers (Name, Description)
VALUES 
('Enhanced strength', 'The hero possesses a level of strength beyond that of the peak members of their specie'),
('Invisibility', 'The power to render oneself unable to be seen.'),
('Flight', 'Ability to lift off the ground, to ride air currents or to fly self-propelled through the air'),
('Mind control', 'The power to control the minds of others');

INSERT INTO SuperheroPowers (SuperheroID, PowerID)
VALUES
(1, 1),
(2, 1),
(3, 1),
(3, 3);