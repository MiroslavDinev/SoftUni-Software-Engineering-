--Problem 1 Create DB
CREATE DATABASE Minions

-- Problem 2 Create Tables
USE Minions

CREATE TABLE Minions(
Id INT PRIMARY KEY,
[Name] NVARCHAR(50) NOT NULL,
Age INT NOT NULL
)

CREATE TABLE Towns(
Id INT PRIMARY KEY,
[Name] NVARCHAR(50) NOT NULL
)

--Problem 3 Alter Minions Table
ALTER TABLE Minions
ADD TownId INT;

ALTER TABLE Minions
ADD CONSTRAINT FK_TownID FOREIGN KEY (TownId) REFERENCES Towns(Id)

-- Problem 4 Insert Records in Both Tables
INSERT INTO Towns (Id, [Name]) VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO Minions (Id , [Name], Age, TownId) VALUES
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2)

--Problem 5 
TRUNCATE TABLE Minions

--Problem 6 Drop All Tables
DROP TABLE Towns

--Problem 7 Create Table People
CREATE TABLE People(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(200) NOT NULL,
Picture VARBINARY(MAX),
Height NUMERIC(3,2),
[Weight] NUMERIC(5,2),
Gender CHAR(1) NOT NULL,
Birthdate DATE NOT NULL,
Biography NVARCHAR(MAX)
)

INSERT INTO People ([Name], Picture, Height, [Weight], Gender, Birthdate, Biography) VALUES
('Pesho', NULL, 1.77, 75, 'm', CONVERT(datetime, '12-06-1990', 103), 'Good guy'),
('Gosho', NULL, 1.80, 76.8, 'm', CONVERT(datetime, '18-12-1989', 103), 'Good man'),
('Ivan', NULL, 1.91, 94.3, 'm', CONVERT(datetime, '01-06-1991', 103), 'Good boy'),
('Stamat', NULL, 2.09, 97, 'm', CONVERT(datetime, '14-09-1987', 103), 'Good partner'),
('Merry', NULL, 1.60, 45, 'f', CONVERT(datetime, '12-08-1994', 103), 'Good girl')

--Problem 8 Create Table Users
CREATE TABLE Users(
Id BIGINT PRIMARY KEY IDENTITY,
Username VARCHAR(30) UNIQUE NOT NULL,
[Password] VARCHAR(26) NOT NULL,
ProfilePicture VARBINARY(MAX),
LastLoginTime DATETIME,
IsDeleted BIT
)

ALTER TABLE Users
ADD CONSTRAINT CK_ProfilePictureSize CHECK (DATALENGTH(ProfilePicture) <= 900*1024);

INSERT INTO Users (Username, [Password], ProfilePicture, LastLoginTime, IsDeleted) VALUES
('Pesho', '123', NULL, CONVERT(datetime, '22-08-2019',103),1),
('Ivan', '12345', NULL, CONVERT(datetime,'22-12-2018',103),1),
('Gosho', '12332', NULL, CONVERT(datetime,'11-08-2017',103),1),
('Stamat', '12311', NULL, CONVERT(datetime,'22-08-2019',103),0),
('Minka', '123132', NULL, CONVERT(datetime,'20-05-2019',103),1)

--Problem 9 Change Primary Key
ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC0744226CCF 

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY (Id, Username)

--Problem 10 Add Check Constraint
ALTER TABLE Users
ADD CONSTRAINT CK_PasswordAtLeast5Symbols CHECK (LEN([Password])>=5)

--Problem 11 Set Default Value of Field
ALTER TABLE Users
ADD DEFAULT GETDATE() FOR LastLoginTime

--Problem 12 Set Unique Field
ALTER TABLE Users
DROP CONSTRAINT PK_Users

ALTER TABLE Users
ADD CONSTRAINT PK_Id PRIMARY KEY (Id)

ALTER TABLE Users
ADD CONSTRAINT CHK_UsernameLength CHECK (LEN(Username)>=3)

--Problem 13 Movies Database
CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors(
Id INT PRIMARY KEY IDENTITY,
DirectorName NVARCHAR(50) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE Genres(
Id INT PRIMARY KEY IDENTITY,
GenreName NVARCHAR(30) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY,
CategoryName NVARCHAR(30) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE Movies(
Id INT PRIMARY KEY IDENTITY,
Title NVARCHAR(50) NOT NULL,
DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
CopyrightYear INT,
[Length] NVARCHAR(50),
GenreId INT FOREIGN KEY REFERENCES Genres(Id),
CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
Rating INT,
Notes NVARCHAR(MAX)
)

INSERT INTO Directors (DirectorName, Notes) VALUES
('Pesho', 'Good'),
('Ivan', 'Good'),
('Gosho', 'Good'),
('Stamat', 'Good'),
('Mimi', 'Good')

INSERT INTO Genres (GenreName, Notes) VALUES
('Action', NULL),
('Drama', NULL),
('Comedy', '5 star'),
('Thriller', NULL),
('Action', NULL)

INSERT INTO Categories (CategoryName, Notes) VALUES
('Oscar', NULL),
('Oscar', NULL),
('Asker', NULL),
('Oscar', 'Good'),
('Oscar', NULL)

INSERT INTO Movies (Title, DirectorId, CopyrightYear, [Length], GenreId, Rating, Notes) VALUES
('Rambo', 1, 1990, 125, 1, 5, 'Classic'),
('Rambo 2', 1, 1993, 130, 1, 5, 'Classic 2'),
('Matrix', 4, 2000, 155, 5, 5, 'Newer Classic'),
('Mr. Bean', 5, 1992, 105, 3, 5, 'Classic comedy'),
('Another', 4, 2016, 120, 5, 5, 'Classic')

--Problem 14 Car Rental Database
CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY,
CategoryName NVARCHAR(50) NOT NULL,
DailyRate DECIMAL(10,2),
WeeklyRate DECIMAL(10,2),
MonthlyRate DECIMAL(10,2),
WeekendRate DECIMAL(10,2)
)

CREATE TABLE Cars(
Id INT PRIMARY KEY IDENTITY,
PlateNumber VARCHAR(10) NOT NULL,
Manufacturer NVARCHAR(50) NOT NULL,
Model NVARCHAR(20) NOT NULL,
CarYear INT,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
Doors INT NOT NULL,
Picture VARBINARY(MAX),
Condition NVARCHAR(50),
Available BIT
)

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
Title NVARCHAR(20),
Notes NVARCHAR(MAX)
)

CREATE TABLE Customers(
Id INT PRIMARY KEY IDENTITY,
DriverLicenseNumber VARCHAR(50) NOT NULL,
FullName NVARCHAR(50) NOT NULL,
[Address] NVARCHAR(100) NOT NULL,
City NVARCHAR(30) NOT NULL,
ZIPCode INT,
Notes NVARCHAR(MAX)
)

CREATE TABLE RentalOrders(
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
CustomerId INT FOREIGN KEY REFERENCES Customers(Id),
CarId INT FOREIGN KEY REFERENCES Cars(Id),
TankLevel NUMERIC(5,2) NOT NULL,
KilometrageStart INT NOT NULL,
KilometrageEnd INT NOT NULL,
TotalKilometrage INT,
StartDate DATE NOT NULL,
EndDate DATE NOT NULL,
TotalDays INT,
RateApplied DECIMAL(10,2) NOT NULL,
TaxRate DECIMAL(10,2) NOT NULL,
OrderStatus NVARCHAR(50),
Notes NVARCHAR(MAX)
)

INSERT INTO Categories (CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate) VALUES
('First', 15.2, 40.8, 200, 30.5),
('Second', 12.2, 43.5, 180, 31.5),
('Third', 10.2, 35.8, 210, 39.5)

INSERT INTO Cars (PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available) VALUES
('A 6112 CT', 'Mercedes', 'GLS', 2018, 1, 4, NULL, 'Excellent', 1),
('B 1816 KT', 'Audi', 'S8', 2017, 2, 2, NULL, 'Excellent', 0),
('C 5817 MM', 'BMW', 'X7', 2019, 3, 4, NULL, 'Excellent', 1)

INSERT INTO Employees (FirstName, LastName, Title, Notes) VALUES
('Pesho', 'Peshev', 'Mr.', 'Good guy'),
('Ivan', 'Geshev', 'Mr.', 'Nice guy'),
('Mimi', 'Pesheva', 'Mrs.', 'Pesho Wife')

INSERT INTO Customers (DriverLicenseNumber, FullName, [Address], City, ZIPCode, Notes) VALUES
('1234','Ivan Ivanov', 'Somewhere', 'Burgas',8000,NULL),
('1233434','Petar Petrov', 'Somewhere else', 'Varna',9000,NULL),
('1564234','Georgi Georgiev', 'Other', 'Sofia',1000,NULL)

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel, 
KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, 
EndDate, TotalDays, RateApplied, TaxRate, OrderStatus,Notes)
VALUES
(1,1,1,65.2,125,135,21200, CONVERT(datetime,'12-06-2018',103),CONVERT(datetime,'13-06-2018',103),1,158.2,112,'OK',NULL),
(2,1,3,68.7,115,115,2100, CONVERT(datetime,'15-06-2018',103),CONVERT(datetime,'18-06-2018',103),3,178.2,112,'OK',NULL),
(3,2,1,13.2,105,145,8200, CONVERT(datetime,'12-06-2018',103),CONVERT(datetime,'14-06-2018',103),2,159.2,112,'OK',NULL)

--Problem 15 Hotel Database
CREATE DATABASE Hotel

USE Hotel

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
Title NVARCHAR(20),
Notes NVARCHAR(MAX)
)

CREATE TABLE Customers(
AccountNumber INT PRIMARY KEY NOT NULL,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
PhoneNumber VARCHAR(30) NOT NULL,
EmergencyName NVARCHAR(50) NOT NULL,
EmergencyNumber VARCHAR(30) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE RoomStatus(
RoomStatus NVARCHAR(30) PRIMARY KEY NOT NULL,
Notes NVARCHAR(50)
)

CREATE TABLE RoomTypes(
RoomType NVARCHAR(50) PRIMARY KEY NOT NULL,
Notes NVARCHAR(50)
)

CREATE TABLE BedTypes(
BedType NVARCHAR(50) PRIMARY KEY NOT NULL,
Notes NVARCHAR(50)
)

CREATE TABLE Rooms(
RoomNumber INT PRIMARY KEY NOT NULL,
RoomType NVARCHAR(50) FOREIGN KEY REFERENCES RoomTypes(RoomType),
BedType NVARCHAR(50) FOREIGN KEY REFERENCES BedTypes(BedType),
Rate DECIMAL(10,2) NOT NULL,
RoomStatus NVARCHAR(30) FOREIGN KEY REFERENCES RoomStatus(RoomStatus),
Notes NVARCHAR(50)
)

CREATE TABLE Payments(
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
PaymentDate DATE NOT NULL,
AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
FirstDateOccupied DATE NOT NULL,
LastDateOccupied DATE NOT NULL,
TotalDays INT NOT NULL,
AmountCharged DECIMAL(15,2) NOT NULL,
TaxRate DECIMAL(15,2) NOT NULL,
TaxAmount DECIMAL(15,2) NOT NULL,
PaymentTotal DECIMAL(15,2) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE Occupancies(
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
DateOccupied DATE NOT NULL,
AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber),
RateApplied DECIMAL(15,2) NOT NULL,
PhoneCharge DECIMAL(15,2) NOT NULL,
Notes NVARCHAR(MAX)
)

INSERT INTO Employees (FirstName, LastName, Title, Notes) VALUES
('Pesho', 'Peshev', 'Mr.', 'Good guy'),
('Gesho', 'Geshev', 'Mr.', 'Good man'),
('Desho', 'Deshev', 'Mr.', 'Good boy')

INSERT INTO Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes) VALUES
(123, 'Joro', 'Penev', '08812345', 'Ivan', '089937563', NULL),
(123353, 'Goro', 'Tenev', '088567645', 'Dragan', '08997785563', NULL),
(1243533, 'Doro', 'Menev', '05354345', 'Petkan', '089986986563', NULL)

INSERT INTO RoomStatus (RoomStatus, Notes) VALUES
('Available',NULL),
('Not Available',NULL),
('Under Renewal',NULL)

INSERT INTO RoomTypes (RoomType, Notes) VALUES
('Single', NULL),
('Double', NULL),
('President', NULL)

INSERT INTO BedTypes (BedType, Notes) VALUES
('Single', NULL),
('Double', NULL),
('President', NULL)

INSERT INTO Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes) VALUES
(1,'Single','Single',152,'Available',NULL),
(2,'Double','Double',192,'Not Available',NULL),
(3,'President','Single',202,'Available',NULL)

INSERT INTO Payments (EmployeeId, PaymentDate, AccountNumber, 
FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, 
TaxRate, TaxAmount, PaymentTotal, Notes)
VALUES
(1, CONVERT(datetime,'12-08-2019',103), 123, CONVERT(datetime,'12-08-2019',103), CONVERT(datetime,'15-08-2019',103),3,200,15.2,120,320,NULL),
(2, CONVERT(datetime,'12-08-2019',103), 123, CONVERT(datetime,'12-08-2019',103), CONVERT(datetime,'15-08-2019',103),3,200,15.2,120,320,NULL),
(3, CONVERT(datetime,'12-08-2019',103), 123, CONVERT(datetime,'12-08-2019',103), CONVERT(datetime,'15-08-2019',103),3,200,15.2,120,320,NULL)

INSERT INTO Occupancies (EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes) VALUES
(1, CONVERT(datetime,'12-08-2019',103), 123, 1, 152.8, 10, NULL),
(1, CONVERT(datetime,'15-08-2019',103), 123, 1, 152.8, 10, NULL),
(1, CONVERT(datetime,'12-12-2019',103), 123, 1, 152.8, 10, NULL)

--Problem 16 Create SoftUni Database
CREATE DATABASE SoftUni

USE SoftUni

CREATE TABLE Towns(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Addresses(
Id INT PRIMARY KEY IDENTITY,
AddressText NVARCHAR(50) NOT NULL,
TownId INT FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Departments(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
JobTitle NVARCHAR(50) NOT NULL,
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
HireDate DATE NOT NULL,
Salary DECIMAL (15,2) NOT NULL,
AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

--Problem 17 Back Up Database

-- Problem 18 BasicInsert 

CREATE DATABASE SoftUni

USE SoftUni

CREATE TABLE Towns(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Addresses(
Id INT PRIMARY KEY IDENTITY,
AddressText NVARCHAR(50) NOT NULL,
TownId INT FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Departments(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(50) NOT NULL,
MiddleName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
JobTitle NVARCHAR(50) NOT NULL,
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
HireDate DATE NOT NULL,
Salary DECIMAL (15,2) NOT NULL,
AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

INSERT INTO Towns ([Name]) VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO Departments ([Name]) VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary) VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, CONVERT(datetime,'01/02/2013',103), 3500.00),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, CONVERT(datetime,'02/03/2004',103), 4000.00),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, CONVERT(datetime,'28/08/2016',103), 525.25),
('Georgi', 'Terziev', 'Ivanov', 'CEO', 2, CONVERT(datetime,'09/12/2007',103), 3000.00),
('Peter ', 'Pan', 'Pan', 'Intern', 3, CONVERT(datetime,'28/08/2016',103), 599.88)

-- Prolbem 19 Basic Select all Fields

SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees

--Problem 20 Basic Select All Fields and Order Them
SELECT * FROM Towns
ORDER BY [Name]
SELECT * FROM Departments
ORDER BY [Name]
SELECT * FROM Employees
ORDER BY Salary DESC

--Problem 21 Basic Select Some Fields
SELECT [Name] FROM Towns
ORDER BY [Name]
SELECT [Name] FROM Departments
ORDER BY [Name]
SELECT FirstName, LastName,JobTitle, Salary FROM Employees
ORDER BY Salary DESC

-- Problem 22 Increase Employees Salary
UPDATE Employees
SET Salary *= 1.1

SELECT Salary FROM Employees

--Problem 23 Decrease Tax Rate
USE Hotel

UPDATE Payments
SET TaxRate *= 0.97

SELECT TaxRate FROM Payments

--Problem 24 Delete All Records
TRUNCATE TABLE Occupancies
