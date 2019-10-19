--DDL

CREATE TABLE Planes(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(30) NOT NULL,
Seats INT NOT NULL,
[Range] INT NOT NULL
)

CREATE TABLE Flights(
Id INT PRIMARY KEY IDENTITY,
DepartureTime DATETIME,
ArrivalTime DATETIME,
Origin VARCHAR(50) NOT NULL,
Destination VARCHAR(50) NOT NULL,
PlaneId INT NOT NULL FOREIGN KEY REFERENCES Planes(Id)
)

CREATE TABLE Passengers(
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(30) NOT NULL,
LastName VARCHAR(30) NOT NULL,
Age INT NOT NULL,
[Address] VARCHAR(30) NOT NULL,
PassportId CHAR(11) NOT NULL
)

CREATE TABLE LuggageTypes(
Id INT PRIMARY KEY IDENTITY,
[Type] VARCHAR(30) NOT NULL,
)

CREATE TABLE Luggages(
Id INT PRIMARY KEY IDENTITY,
LuggageTypeId INT NOT NULL FOREIGN KEY REFERENCES LuggageTypes(Id),
PassengerId INT NOT NULL FOREIGN KEY REFERENCES Passengers(Id)
)

CREATE TABLE Tickets(
Id INT PRIMARY KEY IDENTITY,
PassengerId INT  NOT NULL FOREIGN KEY REFERENCES Passengers(Id),
FlightId INT NOT NULL FOREIGN KEY REFERENCES Flights(Id),
LuggageId INT NOT NULL FOREIGN KEY REFERENCES Luggages(Id),
Price DECIMAL(15,2) NOT NULL
)

--02. Insert

INSERT INTO Planes ([Name], Seats, [Range]) VALUES
('Airbus 336',	112, 5132) ,
('Airbus 330',	432, 5325) ,
('Boeing 369',	231, 2355) ,
('Stelt 297',	254, 2143) ,
('Boeing 338',	165, 5111) ,
('Airbus 558',	387, 1342) ,
('Boeing 128',	345, 5541)

INSERT INTO LuggageTypes ([Type]) VALUES
('Crossbody Bag'),
('School Backpack'),
('Shoulder Bag')

--03. Update

UPDATE Tickets
SET Price *= 1.13
WHERE FlightId = (SELECT Id FROM Flights WHERE Destination='Carlsbad')

--04. Delete

DELETE FROM Tickets
WHERE FlightId = (SELECT TOP(1) Id FROM Flights WHERE Destination = 'Ayn Halagim')

DELETE FROM Flights
WHERE Destination = 'Ayn Halagim'

--05. Trips

SELECT Origin, Destination
FROM Flights
ORDER BY Origin,Destination

--06. The "Tr" Planes

SELECT *
FROM Planes
WHERE [Name] LIKE '%tr%'
ORDER BY Id, [Name], Seats, [Range]

--07. Flight Profits

SELECT FlightId, SUM(Price) AS [Price]
FROM Tickets
GROUP BY FlightId
ORDER BY Price DESC, FlightId

--08. Passanger and Prices

SELECT TOP(10) p.FirstName, p.LastName, t.Price
FROM Passengers AS p
JOIN Tickets AS t
ON t.PassengerId = p.Id
ORDER BY t.Price DESC,p.FirstName, p.LastName

--09. Top Luggages

SELECT lt.[Type], COUNT(l.PassengerId) AS [MostUsedLuggage]
FROM LuggageTypes AS lt
JOIN Luggages AS l
ON l.LuggageTypeId = lt.Id
GROUP BY lt.[Type]
ORDER BY [MostUsedLuggage] DESC, lt.[Type]

--10. Passanger Trips

SELECT p.FirstName + ' ' + p.LastName AS [Full Name], f.Origin, f.Destination
FROM Passengers AS p
JOIN Tickets AS t
ON t.PassengerId = p.Id
JOIN Flights AS f
ON f.Id = t.FlightId
ORDER BY [Full Name], f.Origin, f.Destination

--11. Non Adventures People

SELECT p.FirstName, p.LastName, p.Age
FROM Passengers AS p
LEFT JOIN Tickets AS t
ON t.PassengerId = p.Id
WHERE t.PassengerId IS NULL
ORDER BY p.Age DESC, p.FirstName, p.LastName

--12. Lost Luggages

SELECT p.PassportId, p.[Address]
FROM Passengers AS p
LEFT JOIN Luggages AS l
ON l.PassengerId = p.Id
WHERE l.LuggageTypeId IS NULL
ORDER BY p.PassportId, p.[Address]

--13. Count of Trips

SELECT p.FirstName, p.LastName, COUNT(t.PassengerId) AS [Total Trips]
FROM Passengers AS p
LEFT JOIN Tickets AS t
ON t.PassengerId = p.Id
GROUP BY p.FirstName, p.LastName
ORDER BY [Total Trips] DESC, p.FirstName, p.LastName

--14. Full Info

SELECT p.FirstName + ' ' + p.LastName AS [Full Name], pl.[Name] AS [Plane Name],
f.Origin + ' - ' + f.Destination AS [Trip], lt.[Type] AS [Luggage Type]
FROM Passengers AS p
JOIN Tickets AS t
ON t.PassengerId = p.Id
JOIN Flights AS f
ON f.Id = t.FlightId
JOIN Planes AS pl
ON pl.Id = f.PlaneId
JOIN Luggages AS l
ON l.Id = t.LuggageId
JOIN LuggageTypes AS lt
ON lt.Id = l.LuggageTypeId
ORDER BY [Full Name], [Plane Name], f.Origin, f.Destination, lt.[Type]

--15. Most Expesnive Trips

SELECT k.FirstName, k.LastName, k.Destination, k.Price FROM
(SELECT p.FirstName, p.LastName, f.Destination, t.Price,
DENSE_RANK() OVER(PARTITION BY p.FirstName, p.LastName ORDER BY t.Price DESC) AS PriceRank
FROM Passengers AS p
JOIN Tickets AS t
ON t.PassengerId = p.Id
JOIN Flights AS f
ON f.Id = t.FlightId) AS k
WHERE k.PriceRank = 1
ORDER BY k.Price DESC, k.FirstName, k.LastName, k.Destination

--16. Destinations Info

SELECT f.Destination, COUNT(t.FlightId) AS [FilesCount]
FROM Flights AS f
 LEFT JOIN Tickets AS t
 ON t.FlightId = f.Id
 GROUP BY f.Destination
 ORDER BY [FilesCount] DESC, f.Destination

 --17. PSP

 SELECT p.[Name], p.Seats, COUNT(t.PassengerId) AS [Passengers Count]
 FROM Planes AS p
 LEFT JOIN Flights AS f
 ON f.PlaneId = p.Id
 LEFT JOIN Tickets AS t
 ON t.FlightId = f.Id
 GROUP BY p.[Name], p.Seats
 ORDER BY [Passengers Count] DESC, p.[Name], p.Seats

 GO

 --18. Vacation

CREATE FUNCTION dbo.udf_CalculateTickets(@origin VARCHAR(30), @destination VARCHAR(30), @peopleCount INT) 
RETURNS VARCHAR(30)
BEGIN
DECLARE @originId INT = (SELECT Id FROM Flights WHERE Origin=@origin)
DECLARE @destinationId INT = (SELECT Id FROM Flights WHERE Destination=@destination)

IF(@originId != @destinationId OR @originId IS NULL OR @destinationId IS NULL)
BEGIN
RETURN 'Invalid flight!'
END

IF(@peopleCount<=0)
BEGIN
RETURN 'Invalid people count!'
END

DECLARE @singlePrice DECIMAL(15,2) = (SELECT Price FROM Tickets WHERE FlightId = @originId)
RETURN 'Total price ' + CAST(@singlePrice*@peopleCount AS VARCHAR(30))
END

GO

--19. Wrong Data

CREATE PROC usp_CancelFlights AS
BEGIN
DECLARE @arrivalTime TABLE (Id INT)
INSERT INTO @arrivalTime (Id) 
SELECT Id FROM Flights WHERE ArrivalTime>DepartureTime

UPDATE Flights
SET DepartureTime = NULL, ArrivalTime = NULL
WHERE Id IN (SELECT * FROM @arrivalTime)

END

EXEC usp_CancelFlights

GO

--20. Deleted Planes

CREATE TABLE DeletedPlanes(
Id INT,
[Name] VARCHAR(30) NOT NULL,
Seats INT NOT NULL,
[Range] INT NOT NULL
)

GO

CREATE TRIGGER tr_DeletePlane 
ON Planes
FOR DELETE AS
INSERT INTO DeletedPlanes (Id,[Name],Seats,[Range])
SELECT Id, [Name],Seats,[Range] FROM deleted


