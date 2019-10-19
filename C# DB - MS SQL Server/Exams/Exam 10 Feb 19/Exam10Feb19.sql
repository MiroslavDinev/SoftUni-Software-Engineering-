--01. DDL

CREATE TABLE Planets(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE Spaceports(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
PlanetId INT FOREIGN KEY REFERENCES Planets(Id) NOT NULL
)

CREATE TABLE Spaceships(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
Manufacturer VARCHAR(30) NOT NULL,
LightSpeedRate INT DEFAULT 0
)

CREATE TABLE Colonists(
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(20) NOT NULL,
LastName VARCHAR(20) NOT NULL,
Ucn VARCHAR(10) UNIQUE NOT NULL,
BirthDate DATE NOT NULL
)

CREATE TABLE Journeys(
Id INT PRIMARY KEY IDENTITY,
JourneyStart DATETIME NOT NULL,
JourneyEnd DATETIME NOT NULL,
Purpose VARCHAR(11) CHECK(Purpose ='Medical' OR Purpose ='Technical' OR Purpose = 'Educational'OR Purpose = 'Military'),
DestinationSpaceportId INT FOREIGN KEY REFERENCES Spaceports(Id) NOT NULL,
SpaceshipId INT FOREIGN KEY REFERENCES Spaceships(Id) NOT NULL
)

CREATE TABLE TravelCards(
Id INT PRIMARY KEY IDENTITY,
CardNumber CHAR(10) UNIQUE NOT NULL,
JobDuringJourney VARCHAR(8) CHECK(JobDuringJourney = 'Pilot' OR JobDuringJourney ='Engineer' OR JobDuringJourney = 'Trooper' OR JobDuringJourney = 'Cleaner' OR JobDuringJourney = 'Cook'),
ColonistId INT FOREIGN KEY REFERENCES Colonists(Id) NOT NULL,
JourneyId INT FOREIGN KEY REFERENCES Journeys(Id) NOT NULL
)

--02. Insert

INSERT INTO Planets ([Name]) VALUES
('Mars'),
('Earth'),
('Jupiter'),
('Saturn')

INSERT INTO Spaceships ([Name], Manufacturer, LightSpeedRate) VALUES
('Golf', 'VW', 3),
('WakaWaka', 'Wakanda',	4),
('Falcon9',	'SpaceX', 1),
('Bed',	'Vidolov', 6)

--03. Update

UPDATE Spaceships
SET LightSpeedRate +=1
WHERE Id BETWEEN 8 AND 12

--04. Delete

DELETE FROM TravelCards
WHERE JourneyId IN (SELECT TOP(3) Id
FROM Journeys)

DELETE FROM Journeys
WHERE Id IN (SELECT TOP(3) Id
FROM Journeys)

--05. Select All Travel Cards

SELECT CardNumber, JobDuringJourney
FROM TravelCards
ORDER BY CardNumber 

--06. Select All Colonists

SELECT Id, FirstName + ' ' + LastName AS [FullName], Ucn
FROM Colonists
ORDER BY FirstName, LastName, Id

--07. Select All Military Journeys

SELECT Id, CONVERT(VARCHAR,JourneyStart,103) AS [JourneyStart], CONVERT(VARCHAR,JourneyEnd,103) AS [JourneyEnd]
FROM Journeys
WHERE Purpose = 'Military'
ORDER BY JourneyStart

--08. Select All Pilots

SELECT c.Id, c.FirstName + ' ' + c.LastName AS [full_name]
FROM Colonists AS c
JOIN TravelCards AS tc
ON tc.ColonistId = c.Id
WHERE JobDuringJourney = 'Pilot'
ORDER BY c.Id

--09. Count Colonists

SELECT COUNT(*) AS [count]
FROM Colonists AS c
JOIN TravelCards AS tc
ON tc.ColonistId = c.Id
JOIN Journeys AS j
ON j.Id = tc.JourneyId
WHERE j.Purpose = 'Technical'

--10. Select The Fastest Spaceship

SELECT TOP(1) s.[Name] AS [SpaceshipName], sp.[Name] AS [SpaceportName]
FROM Spaceships AS s
JOIN Journeys AS j
ON j.SpaceshipId = s.Id
JOIN Spaceports AS sp
ON sp.Id = j.DestinationSpaceportId
ORDER BY s.LightSpeedRate DESC

--11. Select Spaceships With Pilots

SELECT DISTINCT s.[Name], s.Manufacturer
FROM Spaceships AS s
JOIN Journeys AS j
ON j.SpaceshipId = s.Id
JOIN TravelCards AS tc
ON tc.JourneyId = j.Id
JOIN Colonists AS c
ON c.Id = tc.ColonistId
WHERE DATEDIFF(YEAR,c.BirthDate,'2019-01-01') <30 AND tc.JobDuringJourney = 'Pilot'
ORDER BY s.[Name]

--12. Select All Educational Mission

SELECT p.[Name] AS [PlanetName], s.[Name] AS [SpaceportName]
FROM Planets AS p
JOIN Spaceports AS s
ON s.PlanetId = p.Id
JOIN Journeys AS j
ON j.DestinationSpaceportId = s.Id
WHERE j.Purpose = 'Educational'
ORDER BY s.[Name] DESC

--13. Planets And Journeys

SELECT p.[Name] AS [PlanetName], COUNT(j.Id) AS [JourneysCount]
FROM Planets AS p
JOIN Spaceports AS s
ON s.PlanetId = p.Id
JOIN Journeys AS j
ON j.DestinationSpaceportId = s.Id
GROUP BY p.[Name]
ORDER BY [JourneysCount] DESC, [PlanetName]

--14. Extract The Shortest Journey

SELECT TOP(1) j.Id, p.[Name] AS [PlanetName], s.[Name] AS [SpaceportName], j.Purpose AS [JourneyPurpose]
FROM Journeys AS j
JOIN Spaceports AS s
ON s.Id = j.DestinationSpaceportId
JOIN Planets AS p
ON p.Id = s.PlanetId
ORDER BY DATEDIFF(DAY,j.JourneyStart,j.JourneyEnd)

--15. Select The Less Popular Job

SELECT TOP(1) j.Id AS [JourneyId], tc.JobDuringJourney AS [JobName]
FROM Journeys AS j
JOIN TravelCards AS tc
ON tc.JourneyId = j.Id
JOIN Colonists AS c
ON c.Id = tc.ColonistId
GROUP BY j.Id, tc.JobDuringJourney,j.JourneyStart, j.JourneyEnd
ORDER BY DATEDIFF(DAY,j.JourneyStart, j.JourneyEnd) DESC, COUNT(tc.JobDuringJourney)

--16. Select Special Colonists
SELECT k.JobDuringJourney, k.FullName, k.[Rank] AS [JobRank] FROM(
SELECT tc.JobDuringJourney, c.FirstName + ' ' + c.LastName AS [FullName],
RANK() OVER (PARTITION BY tc.JobDuringJourney ORDER BY c.BirthDate) AS [Rank]
FROM Colonists AS c
JOIN TravelCards AS tc
ON tc.ColonistId = c.Id
JOIN Journeys AS j
ON j.Id = tc.JourneyId) AS k
WHERE k.Rank=2

--17. Planets and Spaceports

SELECT p.[Name], COUNT(s.Id) AS [Count]
FROM Planets AS p
LEFT JOIN Spaceports AS s
ON p.Id = s.PlanetId
GROUP BY p.[Name]
ORDER BY [Count] DESC, p.[Name]

GO

--18. Get Colonists Count

CREATE FUNCTION dbo.udf_GetColonistsCount(@planetName VARCHAR (30))
RETURNS INT
BEGIN
DECLARE @count INT = (SELECT COUNT(c.Id) FROM Planets AS p
JOIN Spaceports AS s ON s.PlanetId = p.Id
JOIN Journeys AS j ON j.DestinationSpaceportId = s.Id
JOIN TravelCards AS tc ON tc.JourneyId = j.Id
JOIN Colonists AS c ON c.Id = tc.ColonistId
WHERE p.[Name] = @planetName)
RETURN @count
END

GO
--19. Change Journey Purpose

CREATE PROCEDURE usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(20)) 
AS
DECLARE @journey INT = (SELECT Id FROM Journeys WHERE Id = @JourneyId)

IF(@journey IS NULL)
BEGIN 
RAISERROR ('The journey does not exist!',16,1)
RETURN
END

DECLARE @oldPurpose VARCHAR(20) = (SELECT Purpose FROM Journeys WHERE Id = @JourneyId)

IF(@oldPurpose=@NewPurpose)
BEGIN
RAISERROR('You cannot change the purpose!',16,2)
RETURN
END

UPDATE Journeys
SET Purpose = @NewPurpose
WHERE Id = @JourneyId

GO

--20. Deleted Journeys

CREATE TABLE DeletedJourneys(
Id INT PRIMARY KEY,
JourneyStart DATETIME NOT NULL,
JourneyEnd DATETIME NOT NULL,
Purpose VARCHAR(11) CHECK(Purpose ='Medical' OR Purpose ='Technical' OR Purpose = 'Educational'OR Purpose = 'Military'),
DestinationSpaceportId INT FOREIGN KEY REFERENCES Spaceports(Id) NOT NULL,
SpaceshipId INT FOREIGN KEY REFERENCES Spaceships(Id) NOT NULL
)

CREATE TRIGGER tr_DeletedJourney
ON Journeys
FOR DELETE AS
INSERT INTO DeletedJourneys (Id,JourneyStart, JourneyEnd, Purpose, DestinationSpaceportId, SpaceshipId)
SELECT Id,JourneyStart, JourneyEnd, Purpose, DestinationSpaceportId, SpaceshipId FROM deleted


