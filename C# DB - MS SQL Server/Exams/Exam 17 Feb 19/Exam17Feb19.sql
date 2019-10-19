--01. DDL

CREATE TABLE Students(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30) NOT NULL,
MiddleName NVARCHAR(25),
LastName NVARCHAR(30) NOT NULL,
Age INT CHECK(Age BETWEEN 5 AND 100),
[Address] NVARCHAR(50),
Phone NCHAR(10)
)

CREATE TABLE Subjects(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(20) NOT NULL,
Lessons INT CHECK(Lessons>=1) NOT NULL
)

CREATE TABLE StudentsSubjects(
Id INT PRIMARY KEY IDENTITY,
StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL,
Grade DECIMAL(15,2) CHECK(Grade BETWEEN 2 AND 6) NOT NULL
)

CREATE TABLE Exams(
Id INT PRIMARY KEY IDENTITY,
[Date] DATETIME,
SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsExams(
StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
ExamId INT FOREIGN KEY REFERENCES Exams(Id) NOT NULL,
Grade DECIMAL(15,2) CHECK(Grade BETWEEN 2 AND 6) NOT NULL,
PRIMARY KEY(StudentId, ExamId)
)

CREATE TABLE Teachers(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(20) NOT NULL,
LastName NVARCHAR(20) NOT NULL,
[Address] NVARCHAR(20) NOT NULL,
Phone CHAR(10),
SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsTeachers(
StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
TeacherId INT FOREIGN KEY REFERENCES Teachers(Id) NOT NULL,
PRIMARY KEY (StudentId, TeacherId)
)

--02. Insert

INSERT INTO Teachers (FirstName, LastName, [Address], Phone, SubjectId) VALUES
('Ruthanne', 'Bamb', '84948 Mesta Junction','3105500146', 6),
('Gerrard',	'Lowin','370 Talisman Plaza', '3324874824', 2),
('Merrile',	'Lambdin', '81 Dahle Plaza', '4373065154', 5),
('Bert', 'Ivie',	'2 Gateway Circle',	'4409584510', 4)

INSERT INTO Subjects ([Name], Lessons) VALUES
('Geometry', 12),
('Health',	10),
('Drama',	7),
('Sports',	9)

--03. Update

UPDATE StudentsSubjects
SET Grade = 6.00
WHERE SubjectId IN (1,2) AND Grade>=5.50

--04. Delete

DELETE FROM StudentsTeachers
WHERE TeacherId IN (SELECT Id FROM Teachers WHERE Phone LIKE '%72%')

DELETE FROM Teachers
WHERE Phone LIKE '%72%'

--05. Teen Students

SELECT FirstName, LastName, Age
FROM Students
WHERE Age>=12
ORDER BY FirstName, LastName

--06. Cool Addresses

SELECT FirstName + ' ' + ISNULL(MiddleName,'') + ' ' + LastName AS [Full Name], [Address]
FROM Students
WHERE Address LIKE '%road%'
ORDER BY FirstName, LastName, [Address]

--07. 42 Phones

SELECT FirstName, Address, Phone
FROM Students
WHERE MiddleName IS NOT NULL AND Phone LIKE '42%'
ORDER BY FirstName

--08. Students Teachers

SELECT s.FirstName, s.LastName, COUNT(st.TeacherId) AS TeachersCount
FROM Students AS s
JOIN StudentsTeachers AS st
ON st.StudentId = s.Id
GROUP BY s.FirstName, s.LastName

--09. Subjects with Students

SELECT t.FirstName + ' ' + t.LastName AS FullName, 
CONCAT(sb.[Name],'-',sb.Lessons) AS [Subjects], COUNT(st.StudentId) AS [Students]
FROM Teachers AS t
 JOIN Subjects AS sb
ON sb.Id = t.SubjectId
JOIN StudentsTeachers AS st
ON st.TeacherId = t.Id
GROUP BY t.FirstName + ' ' + t.LastName, CONCAT(sb.[Name],'-',sb.Lessons)
ORDER BY [Students] DESC, FullName, [Subjects]

--10. Students to Go

SELECT s.FirstName + ' ' + s.LastName AS [Full Name]
FROM Students AS s
LEFT JOIN StudentsExams AS se
ON se.StudentId = s.Id
WHERE se.ExamId IS NULL
ORDER BY [Full Name]

--11. Busiest Teachers

SELECT TOP(10) t.FirstName, t.LastName, COUNT(st.StudentId) AS [StudentsCount]
FROM Teachers AS t
JOIN StudentsTeachers AS st
ON st.TeacherId = t.Id
GROUP BY t.FirstName, t.LastName
ORDER BY [StudentsCount] DESC, t.FirstName, t.LastName

--12. Top Students

SELECT TOP(10) s.FirstName, s.LastName, FORMAT(AVG(se.Grade),'N2') AS [Grade]
FROM Students AS s
JOIN StudentsExams AS se
ON se.StudentId = s.Id
GROUP BY s.FirstName, s.LastName
ORDER BY [Grade] DESC, s.FirstName, s.LastName

--13. Second Highest Grade
SELECT k.FirstName, k.LastName, k.Grade FROM(
SELECT s.FirstName, s.LastName, ss.Grade, 
ROW_NUMBER() OVER (PARTITION BY s.FirstName, s.LastName ORDER BY ss.Grade DESC) AS [Rank]
FROM Students AS s
JOIN StudentsSubjects AS ss
ON ss.StudentId = s.Id
) AS k
WHERE k.[Rank]=2
ORDER BY k.FirstName, k.LastName

--14. Not So In The Studying

SELECT s.FirstName + ' ' + COALESCE(s.MiddleName+ ' ','') + s.Lastname AS [Full Name]
FROM Students AS s
LEFT JOIN StudentsSubjects AS ss
ON ss.StudentId = s.Id
WHERE ss.SubjectId IS NULL
ORDER BY [Full Name]

--15. Top Student per Teacher

SELECT j.[Teacher Full Name], j.SubjectName ,j.[Student Full Name], FORMAT(j.TopGrade, 'N2') AS Grade
  FROM (
SELECT k.[Teacher Full Name],k.SubjectName, k.[Student Full Name], k.AverageGrade  AS TopGrade,
	   ROW_NUMBER() OVER (PARTITION BY k.[Teacher Full Name] ORDER BY k.AverageGrade DESC) AS RowNumber
  FROM (
  SELECT t.FirstName + ' ' + t.LastName AS [Teacher Full Name],
  	   s.FirstName + ' ' + s.LastName AS [Student Full Name],
  	   AVG(ss.Grade) AS AverageGrade,
  	   su.Name AS SubjectName
    FROM Teachers AS t 
    JOIN StudentsTeachers AS st ON st.TeacherId = t.Id
    JOIN Students AS s ON s.Id = st.StudentId
    JOIN StudentsSubjects AS ss ON ss.StudentId = s.Id
    JOIN Subjects AS su ON su.Id = ss.SubjectId AND su.Id = t.SubjectId
GROUP BY t.FirstName, t.LastName, s.FirstName, s.LastName, su.Name
) AS k
) AS j
   WHERE j.RowNumber = 1 
ORDER BY j.SubjectName,j.[Teacher Full Name], TopGrade DESC

--16. Average Grade per Subject

SELECT s.[Name], AVG(ss.Grade) AS [AverageGrade]
FROM Subjects AS s
JOIN StudentsSubjects AS ss
ON ss.SubjectId = s.Id
GROUP BY s.[Name], s.Id
ORDER BY s.Id 

--17. Exams Information
SELECT k.[Quarter], k.SubjectName, SUM(k.StudentsCount) AS [StudentsCount] FROM(
SELECT 
ISNULL('Q' + CONVERT(VARCHAR(10),DATEPART(QUARTER,e.Date)),'TBA') AS [Quarter],
s.[Name] AS [SubjectName], COUNT(se.StudentId) AS [StudentsCount]
FROM StudentsExams AS se
LEFT JOIN Exams AS e
ON e.Id = se.ExamId
LEFT JOIN Subjects AS s
ON s.Id = e.SubjectId
GROUP BY DATEPART(QUARTER,e.Date),s.[Name] ,se.Grade
HAVING se.Grade>=4.00)AS k
GROUP BY k.[Quarter], k.SubjectName
ORDER BY k.[Quarter]

GO

--18. Exam Grades

CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(15,2))
RETURNS VARCHAR(MAX)
BEGIN
DECLARE @studentName VARCHAR(30) = (SELECT FirstName FROM Students WHERE Id = @studentId)

IF(@studentName IS NULL)
BEGIN
RETURN 'The student with provided id does not exist in the school!'
END

IF(@grade>6.00)
BEGIN
RETURN 'Grade cannot be above 6.00!'
END

DECLARE @lowestGrade DECIMAL(15,2) = @grade - 0.50
DECLARE @highestGrade DECIMAL(15,2) = @grade + 0.50

DECLARE @countGrades INT = (SELECT COUNT(Grade) FROM StudentsExams WHERE StudentId=@studentId AND Grade BETWEEN @lowestGrade AND @highestGrade)

RETURN 'You have to update ' + CAST(@countGrades AS VARCHAR(10)) + ' grades for the student ' + @studentName
END

GO

--19. Exclude From School

CREATE PROCEDURE usp_ExcludeFromSchool(@StudentId INT) AS
DECLARE @student INT = (SELECT Id FROM Students WHERE Id = @StudentId)

IF(@student IS NULL)
BEGIN 
RAISERROR('This school has no student with the provided id!',16,1)
RETURN
END

DELETE FROM StudentsTeachers
WHERE StudentId = @StudentId

DELETE FROM StudentsExams
WHERE StudentId = @StudentId

DELETE FROM StudentsSubjects
WHERE StudentId = @StudentId

DELETE FROM Students
WHERE Id = @StudentId

--20. Deleted Students

CREATE TABLE ExcludedStudents(
StudentId INT,
StudentName NVARCHAR(30)
)

CREATE TRIGGER tr_DeleteStudents
ON Students
FOR DELETE AS
INSERT INTO ExcludedStudents (StudentId, StudentName)
SELECT Id, FirstName + ' ' + LastName FROM deleted




