--01. Employees with Salary Above 35000

CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000 AS
BEGIN
SELECT FirstName, LastName
FROM Employees
WHERE Salary > 35000
END

GO
--02. Employees with Salary Above Number

CREATE PROC usp_GetEmployeesSalaryAboveNumber (@salaryNumber DECIMAL(18,4)) AS
BEGIN
SELECT FirstName, LastName
FROM Employees
WHERE Salary >= @salaryNumber
END

GO
--03. Town Names Starting With

CREATE PROC usp_GetTownsStartingWith (@input VARCHAR(50)) AS
BEGIN
SELECT [Name]
FROM Towns
WHERE [Name] LIKE @input + '%'
END

GO
--04. Employees from Town

CREATE PROC usp_GetEmployeesFromTown (@townName VARCHAR(50)) AS
BEGIN
SELECT e.FirstName, e.LastName
FROM Employees AS e
JOIN Addresses AS a
ON a.AddressID = e.AddressID
JOIN Towns AS t
ON t.TownID = a.TownID
WHERE t.Name = @townName
END

GO
--05. Salary Level Function

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(7)
BEGIN
	IF(@salary<30000)
	BEGIN
	RETURN 'Low';
	END
	ELSE IF(@salary BETWEEN 30000 AND 50000)
	BEGIN
	RETURN 'Average';
	END

	RETURN 'High';
END

GO

--06. Employees by Salary Level

CREATE PROC usp_EmployeesBySalaryLevel (@salaryLevel VARCHAR(7)) AS
BEGIN
SELECT FirstName, LastName
FROM Employees
WHERE dbo.ufn_GetSalaryLevel(Salary) = @salaryLevel
END

GO

--07. Define Function

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))
RETURNS BIT
BEGIN
DECLARE @index INT =1
DECLARE @currLetter CHAR(1)
DECLARE @currResult SMALLINT

  WHILE(@index<=LEN(@word))
  BEGIN
	SET @currLetter = SUBSTRING(@word,@index,1)
	SET @currResult= CHARINDEX(@currLetter,@setOfLetters)
	IF(@currResult=0)
	BEGIN
	RETURN 0;
	END
	SET @index +=1;
  END
RETURN 1
END

GO

--08. Delete Employees and Departments

CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT) AS
BEGIN

DELETE FROM EmployeesProjects
WHERE EmployeeID IN(SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

ALTER TABLE Departments
ALTER COLUMN ManagerID INT

UPDATE Employees
SET ManagerID = NULL
WHERE ManagerID IN(SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

UPDATE Departments
SET ManagerID = NULL
WHERE ManagerID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

DELETE FROM Employees
WHERE DepartmentID = @departmentId

DELETE FROM Departments
WHERE DepartmentID = @departmentId

SELECT COUNT(*)
FROM Employees
WHERE DepartmentID = @departmentId
END

GO

--09. Find Full Name

CREATE PROCEDURE usp_GetHoldersFullName AS
BEGIN
SELECT FirstName + ' ' + LastName AS [Full Name]
FROM AccountHolders
END

GO

--10. People with Balance Higher Than

CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan(@value DECIMAL(15,4)) AS
BEGIN
SELECT ah.FirstName AS [First Name], ah.LastName AS [Last Name]
FROM AccountHolders AS ah
JOIN Accounts AS a
ON a.AccountHolderId = ah.Id
GROUP BY ah.FirstName, ah.LastName
HAVING SUM(a.Balance) >  @value
ORDER BY ah.FirstName, ah.LastName
END

GO

--11. Future Value Function

CREATE FUNCTION ufn_CalculateFutureValue (@sum DECIMAL(15,2), @yearlyInterestRate FLOAT,@numberOfYears INT)
RETURNS DECIMAL(15,4)
BEGIN
RETURN @sum*POWER((1+@yearlyInterestRate),@numberOfYears)
END

GO

--12. Calculating Interest

CREATE PROCEDURE usp_CalculateFutureValueForAccount (@AccountId INT, @interestRate FLOAT) AS
BEGIN
SELECT a.Id, ah.FirstName, ah.LastName, a.Balance AS [Current Balance], 
dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, 5) AS [Balance in 5 years]
FROM Accounts AS a
JOIN AccountHolders AS ah
ON a.AccountHolderId = ah.Id
WHERE a.Id = @AccountId
END

GO

--13. *Cash in User Games Odd Rows

CREATE FUNCTION ufn_CashInUsersGames (@gameName VARCHAR(50)) 
RETURNS TABLE
AS
RETURN(SELECT SUM(e.Cash) AS [SumCash] FROM(
SELECT g.Id,ug.Cash, ROW_NUMBER() OVER(ORDER BY ug.Cash DESC) AS [RowNumber]
FROM UsersGames AS ug
JOIN Games AS g
ON g.Id = ug.GameId
WHERE g.Name = @gameName
) AS e
WHERE e.RowNumber %2=1
)







