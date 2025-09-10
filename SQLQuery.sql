create database PasseioStick;

select * from Points;

INSERT INTO Points (id, Title)
VALUES
(newid(), 'Shopping Palladium'),
(newid(), 'Parque Barigui'),
(newid(), 'Casa China'),
(newid(), 'Bosch'),
(newid(), 'Wenseslau Braz'),
(newid(), 'Pebbas Bar');

drop database PasseioStick;