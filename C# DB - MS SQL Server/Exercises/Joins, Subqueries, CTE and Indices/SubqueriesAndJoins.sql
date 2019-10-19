--01. Employee Address

SELECT TOP(5) e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText
FROM Employees AS e
JOIN Addresses AS a
ON a.AddressID = e.AddressID
ORDER BY e.AddressID

--02. Addresses with Towns

SELECT TOP(50) e.FirstName, e.LastName, t.Name,a.AddressText
FROM Employees AS e
JOIN Addresses AS a
ON a.AddressID = e.AddressID
JOIN Towns AS t
ON t.TownID = a.TownID
ORDER BY e.FirstName, e.LastName

--03. Sales Employees

SELECT e.EmployeeID, e.FirstName, e.LastName,d.[Name]
FROM Employees AS e
JOIN Departments AS d
ON d.DepartmentID = e.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY e.EmployeeID

--04. Employee Departments

SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.[Name]
FROM Employees AS e
JOIN Departments AS d
ON d.DepartmentID = e.DepartmentID
WHERE e.Salary > 15000
ORDER BY e.DepartmentID

--05. Employees Without Projects

SELECT TOP(3) e.EmployeeID, e.FirstName
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep
ON ep.EmployeeID = e.EmployeeID
WHERE ep.EmployeeID IS NULL
ORDER BY e.EmployeeID

--06. Employees Hired After

SELECT e.FirstName, e.LastName, e.HireDate, d.[Name]
FROM Employees AS e
JOIN Departments AS d
ON d.DepartmentID = e.DepartmentID
WHERE e.HireDate > '01.01.1999' AND d.[Name] IN ('Sales', 'Finance')
ORDER BY e.HireDate

--07. Employees With Project

SELECT TOP(5) e.EmployeeID, e.FirstName, p.[Name]
FROM Employees AS e
JOIN EmployeesProjects AS emp
ON emp.EmployeeID = e.EmployeeID
JOIN Projects AS p
ON p.ProjectID = emp.ProjectID
WHERE p.StartDate > '08.13.2002' AND p.EndDate IS NULL
ORDER BY e.EmployeeID

--08. Employee 24

SELECT e.EmployeeID, e.FirstName,
CASE
WHEN p.StartDate >= '01.01.2005' THEN NULL
ELSE p.[Name]
END AS [ProjectName]
FROM Employees AS e
JOIN EmployeesProjects AS emp
ON emp.EmployeeID = e.EmployeeID
JOIN Projects AS p
ON p.ProjectID = emp.ProjectID
WHERE e.EmployeeID = 24

--09. Employee Manager

SELECT e.EmployeeID, e.FirstName, e.ManagerID, m.FirstName
FROM Employees AS e
JOIN Employees AS m
ON m.EmployeeID = e.ManagerID
WHERE e.ManagerID IN (3,7)
ORDER BY e.EmployeeID

--10. Employees Summary

SELECT TOP(50) e.EmployeeID, e.FirstName + ' ' + e.LastName AS [EmployeeName], 
m.FirstName + ' ' + m.LastName AS [ManagerName], 
d.[Name] AS [DepartmentName]
FROM Employees AS e
JOIN Employees AS m
ON m.EmployeeID = e.ManagerID
JOIN Departments AS d
ON d.DepartmentID = e.DepartmentID
ORDER BY e.EmployeeID

--11. Min Average Salary

SELECT TOP(1) AVG(Salary) AS MinAverageSalary
FROM Employees
GROUP BY DepartmentID
ORDER BY MinAverageSalary 

--12. Highest Peaks in Bulgaria

SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation
FROM Countries AS c
JOIN MountainsCountries AS mc
ON mc.CountryCode = c.CountryCode
JOIN Mountains AS m
ON m.Id = mc.MountainId
JOIN Peaks AS p
ON p.MountainId = m.Id
WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

--13. Count Mountain Ranges

SELECT c.CountryCode, COUNT(m.MountainRange) AS [MountainRanges]
FROM Countries AS c
JOIN MountainsCountries AS mc
ON mc.CountryCode = c.CountryCode
JOIN Mountains AS m
ON m.Id = mc.MountainId
WHERE c.CountryCode IN ('US', 'RU', 'BG')
GROUP BY c.CountryCode

--14. Countries With or Without Rivers

SELECT TOP(5) c.CountryName, r.RiverName
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr
ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r
ON r.Id = cr.RiverId
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName

--15. Continents and Currencies
WITH CTE_CountriesInfo (ContinentCode, CurrencyCode, CurrencyUsage) AS
(
SELECT c.ContinentCode, c.CurrencyCode, COUNT(c.CurrencyCode) AS [CurrencyUsage]
FROM Countries AS c
GROUP BY c.ContinentCode, c.CurrencyCode
HAVING COUNT(c.CurrencyCode)>1) 

SELECT e.ContinentCode, cci.CurrencyCode, cci.CurrencyUsage
FROM(
SELECT ContinentCode, MAX(CurrencyUsage) AS MaxCurrency
FROM CTE_CountriesInfo
GROUP BY ContinentCode) AS e
JOIN CTE_CountriesInfo AS cci
ON cci.ContinentCode = e.ContinentCode AND cci.CurrencyUsage = e.MaxCurrency

--16. Countries Without any Mountains

SELECT COUNT(c.CountryCode) AS [CountryCode]
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc
ON mc.CountryCode = c.CountryCode
WHERE mc.MountainId IS NULL

--17. Highest Peak and Longest River by Country

SELECT TOP(5) c.CountryName, MAX(p.Elevation) AS [HighestPeakElevation], MAX(r.[Length]) AS[LongestRiverLength]
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc
ON mc.CountryCode = c.CountryCode
LEFT JOIN Mountains AS m
ON m.Id = mc.MountainId
LEFT JOIN Peaks AS p
ON p.MountainId = m.Id
LEFT JOIN CountriesRivers AS cr
ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r
ON r.Id = cr.RiverId
GROUP BY c.CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC

--18. Highest Peak Name and Elevation by Country

SELECT TOP(5) c.CountryName, ISNULL(p.PeakName,'(no highest peak)') AS [Highest Peak Name], 
ISNULL(MAX(p.Elevation),0) AS [Highest Peak Elevation], ISNULL(m.MountainRange,'(no mountain)')
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc
ON mc.CountryCode = c.CountryCode
LEFT JOIN Mountains AS m
ON m.Id = mc.MountainId
LEFT JOIN Peaks AS p
ON p.MountainId = m.Id
GROUP BY c.CountryName,p.PeakName,m.MountainRange
ORDER BY c.CountryName, [Highest Peak Elevation] DESC,p.PeakName


