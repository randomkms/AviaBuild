use master
IF DB_ID('AviaBuildDB') is not null
DROP DATABASE AviaBuildDB
GO
CREATE DATABASE AviaBuildDB
GO
use AviaBuildDB

GO
IF OBJECT_ID('TestLab') is not null 
DROP TABLE TestLab
CREATE TABLE TestLab(IdTestLab int PRIMARY KEY, TestLabName varchar(100) not null)
GO
INSERT INTO TestLab VALUES
(0, 'Planes TestLab1'),
(1, 'Rockets TestLab1')
GO
select * FROM TestLab

GO
IF OBJECT_ID('TestEquipment') is not null 
DROP TABLE TestEquipment
CREATE TABLE TestEquipment(IdTestEquipment int PRIMARY KEY, TestEquipmentName varchar(100) not null,
TestLabId int not null foreign key references TestLab)
GO
INSERT INTO TestEquipment VALUES
(0, 'TEPlanesType1', 0),
(1, 'TERocketsType1', 1),
(2, 'TEPlanesType2', 0),
(3, 'TERocketsType2', 1)
GO
select * FROM TestEquipment

GO
IF OBJECT_ID('Ceh') is not null 
DROP TABLE Ceh
CREATE TABLE Ceh(IdCeh int PRIMARY KEY)
GO
INSERT INTO Ceh VALUES
(0),
(1)
GO
select * FROM Ceh

GO
IF OBJECT_ID('Product') is not null 
DROP TABLE Product
GO
CREATE TABLE Product(IdProduct int PRIMARY KEY,
CehId int not null foreign key references Ceh,
TestEquipmentId int not null foreign key references TestEquipment,
StartBuild Date, EndBuild Date, StartTest Date, EndTest Date,
Category varchar(100) not null)
GO
INSERT INTO Product VALUES
(0, 0, 0, '2007-11-11', '2008-11-11', '2008-11-11', '2009-11-11', 'Plane'),
(1, 1, 1, '2008-11-11', '2009-11-11', '2009-11-11', '2010-11-11', 'Rocket'),
(2, 0, 2, '2018-10-01', null, null, null, 'Plane'),
(3, 1, 3, '2018-10-01', '2018-10-20', null, null, 'Rocket')
GO
select * FROM Product

GO
IF OBJECT_ID('Plane') is not null 
DROP TABLE Plane
CREATE TABLE Plane(IdPlane int PRIMARY KEY, PlaneName varchar(100) not null,
PlaneType varchar(100),
PlaneProductID int not null foreign key references Product)
GO
INSERT INTO Plane VALUES
(0, 'IS-8', 'Military', 0),
(1, 'Boing', 'Civil', 2)
GO
select * FROM Plane

GO
IF OBJECT_ID('Rocket') is not null 
DROP TABLE Rocket
CREATE TABLE Rocket(IdRocket int PRIMARY KEY, RocketName varchar(100) not null,
RocketType varchar(100),
RocketProductID int not null foreign key references Product)
GO
INSERT INTO Rocket VALUES
(0, 'Little boy', 'Military', 1),
(1, 'Fat man', 'Military', 3)
GO
select * FROM Rocket

GO
IF OBJECT_ID('Work') is not null 
DROP TABLE Work
CREATE TABLE Work(IdWork int PRIMARY KEY, WorkName varchar(100) not null,
ProductID int not null foreign key references Product, StartDate Date not null, EndDate Date)
GO
INSERT INTO Work VALUES
(0, 'Making engine', 0, '2007-11-11', '2008-01-01'),
(1, 'Making body', 1, '2008-11-11', '2009-01-01'),
(2, 'Making prototype', 2, '2018-10-01', null),
(3, 'Making wings', 3, '2018-10-01', '2018-10-03'),
(4, 'Finishing works', 0, '2008-01-01', '2008-11-11'),
(5, 'Finishing works', 1, '2009-01-01', '2009-11-11')
GO
select * FROM Work

GO
IF OBJECT_ID('Tester') is not null 
DROP TABLE Tester
CREATE TABLE Tester(IdTester int PRIMARY KEY, TesterName varchar(100) not null,
TestLabId int not null foreign key references TestLab)
GO
INSERT INTO Tester VALUES
(0, 'Miky Spilleyn', 0),
(1, 'Margaret Tetcher' ,1)
GO
select * FROM Tester

GO
IF OBJECT_ID('Area') is not null 
DROP TABLE Area
CREATE TABLE Area(IdArea int PRIMARY KEY,
CehId int not null foreign key references Ceh)
GO
INSERT INTO Area VALUES
(0, 1),
(1, 1),
(2, 0)
GO
select * FROM Area

GO
IF OBJECT_ID('EngTehWorker') is not null 
DROP TABLE EngTehWorker
CREATE TABLE EngTehWorker(IdEngTehWorker int PRIMARY KEY, EngTehWorkerName varchar(100) not null,
AreaId int not null foreign key references Area,
IsHead BIT not null, IsMaster BIT not null, UnderHeadId int)
GO
INSERT INTO EngTehWorker VALUES
(0, 'Jeky Chan', 0, 1, 0, NULL),
(1, 'Tom Hanks', 1, 0, 1, 0)
GO
select * FROM EngTehWorker

GO
IF OBJECT_ID('EngTehProf') is not null 
DROP TABLE EngTehProf
CREATE TABLE EngTehProf(IdEngTehProf int PRIMARY KEY, EngTehProfName varchar(100) not null)
GO
INSERT INTO EngTehProf VALUES
(0, 'Engineer'),
(1, 'Technologist'),
(2, 'Technician')
GO
select * FROM EngTehProf

GO
IF OBJECT_ID('EngTehWorkerProf') is not null 
DROP TABLE EngTehWorkerProf
CREATE TABLE EngTehWorkerProf(EngTehWorkerId int not null foreign key references EngTehWorker,
EngTehProfId int not null foreign key references EngTehProf,
PRIMARY KEY (EngTehWorkerId, EngTehProfId),
StartWorkDate Date,
QuitDate Date)
GO
INSERT INTO EngTehWorkerProf VALUES
(0, 0, '2007-11-11', '2008-11-11'),
(1, 1, '2008-11-11', '2009-11-11')
GO
select * FROM EngTehWorkerProf

GO
IF OBJECT_ID('Brigade') is not null 
DROP TABLE Brigade
CREATE TABLE Brigade(IdBrigade int PRIMARY KEY, AreaId int not null foreign key references Area)
GO
INSERT INTO Brigade VALUES
(0, 0),
(1, 1)
GO
select * FROM Brigade

GO
IF OBJECT_ID('Worker') is not null 
DROP TABLE Worker
CREATE TABLE Worker(IdWorker int PRIMARY KEY, BrigadeId int not null foreign key references Brigade,
IsBrigadier BIT not null, WorkerName varchar(100) not null)
GO
INSERT INTO Worker VALUES
(0, 0, 1, 'Orlando Bloom'),
(1, 1, 0, 'Bred Pit')
GO
select * FROM Worker

GO
IF OBJECT_ID('Prof') is not null 
DROP TABLE Prof
CREATE TABLE Prof(IdProf int PRIMARY KEY, ProfName varchar(100) not null)
GO
INSERT INTO Prof VALUES
(0, 'Turner'),
(1, 'Locksmith'),
(2, 'Welder')
GO
select * FROM Prof

GO
IF OBJECT_ID('WorkerProf') is not null 
DROP TABLE WorkerProf
CREATE TABLE WorkerProf(WorkerId int not null foreign key references Worker,
ProfId int not null foreign key references Prof,
PRIMARY KEY (WorkerId, ProfId),
StartWorkDate Date,
QuitDate Date)
GO
INSERT INTO WorkerProf VALUES
(0, 0, '2007-11-11', '2008-11-11'),
(1, 1, '2008-11-11', '2009-11-11')
GO
select * FROM WorkerProf


--lab3
--GO
--IF OBJECT_ID('ViewProductTypes') is not null 
--DROP VIEW ViewProductTypes
--GO CREATE VIEW ViewProductTypes  
--AS
-- select distinct *
-- FROM Product inner join Ceh on Product.CehId=Ceh.IdCeh
-- inner join Plane on Product.IdProduct=Plane.ProductID
-- inner join Rocket on Product.IdProduct=Rocket.ProductID;

GO
IF OBJECT_ID('pr1') is not null 
DROP proc pr1
go
 Create proc pr1 @category varchar(100), @cehId int
 as
 SET NOCOUNT ON;
 SELECT DISTINCT Plane.PlaneType, Rocket.RocketType
 FROM Product inner join Ceh on Product.CehId=Ceh.IdCeh
 left join Plane on Product.IdProduct=Plane.PlaneProductID
 left join Rocket on Product.IdProduct=Rocket.RocketProductID
 WHERE
 (@cehId is null OR Ceh.IdCeh=@cehId) AND
 (@category is null OR Product.Category=@category) 



GO
IF OBJECT_ID('pr2') is not null 
DROP proc pr2
GO
 Create proc pr2 @startDate Date, @endDate Date, @category varchar(100), @cehId int, @areaId int
 as
 SET NOCOUNT ON;
 SELECT Product.IdProduct, Product.TestEquipmentId, Product.StartBuild, Product.EndBuild, Product.StartTest, Product.EndTest, Product.Category, Product.CehId, Area.IdArea
 FROM Product inner join Ceh on Product.CehId=Ceh.IdCeh
 inner join Area on Ceh.IdCeh=Area.CehId
 WHERE (@startDate is null OR @startDate <= Product.StartBuild) AND 
 (@endDate is null OR @endDate >= Product.EndBuild) AND
 (@cehId is null OR Ceh.IdCeh=@cehId) AND
 (@category is null OR Product.Category=@category) AND 
 (@areaId is null OR Area.IdArea=@areaId)

 GO
IF OBJECT_ID('pr2Count') is not null 
DROP proc pr2Count
GO
 Create proc pr2Count @startDate Date, @endDate Date, @category varchar(100), @cehId int, @areaId int
 as
 SET NOCOUNT ON;
 SELECT Count(*) as ProductsCount
 FROM Product inner join Ceh on Product.CehId=Ceh.IdCeh
 inner join Area on Ceh.IdCeh=Area.CehId
 WHERE (@startDate is null OR @startDate <= Product.StartBuild) AND 
 (@endDate is null OR @endDate >= Product.EndBuild) AND
 (@cehId is null OR Ceh.IdCeh=@cehId) AND
 (@category is null OR Product.Category=@category) AND 
 (@areaId is null OR Area.IdArea=@areaId)


 GO
IF OBJECT_ID('pr3') is not null 
DROP proc pr3
GO
 Create proc pr3 @cehId int, @engProf varchar(100), @workerProf varchar(100)
 as
 SET NOCOUNT ON;
 SELECT Worker.BrigadeId, Worker.IdWorker, Worker.IsBrigadier, Worker.WorkerName, Prof.ProfName,
 EngTehWorker.AreaId, EngTehWorker.IdEngTehWorker, EngTehWorker.EngTehWorkerName, 
 EngTehWorker.IsHead, EngTehWorker.IsMaster, EngTehWorker.UnderHeadId, EngTehProf.EngTehProfName
 FROM Ceh
 inner join Area on Ceh.IdCeh=Area.CehId
 inner join Brigade on Area.IdArea=Brigade.AreaId
 inner join Worker on Brigade.IdBrigade=Worker.BrigadeId
 inner join WorkerProf on Worker.IdWorker=WorkerProf.WorkerId
 inner join Prof on WorkerProf.ProfId=Prof.IdProf
 inner join EngTehWorker on EngTehWorker.AreaId=Area.IdArea
 inner join EngTehWorkerProf on EngTehWorkerProf.EngTehWorkerId=EngTehWorker.IdEngTehWorker
 inner join EngTehProf on EngTehProf.IdEngTehProf=EngTehWorkerProf.EngTehProfId
 WHERE (@cehId is null OR @cehId=Ceh.IdCeh) AND 
 (@engProf is null OR @engProf=EngTehProf.EngTehProfName) AND
 (@workerProf is null OR @workerProf=Prof.ProfName)



  GO
IF OBJECT_ID('pr4') is not null 
DROP proc pr4
GO
 Create proc pr4 @cehId int
 as
 SET NOCOUNT ON;
 SELECT *
 FROM Ceh
 inner join Area on Ceh.IdCeh=Area.CehId
 inner join EngTehWorker on EngTehWorker.AreaId=Area.IdArea
 WHERE (@cehId is null OR @cehId=Ceh.IdCeh)
 AND EngTehWorker.IsHead=1

   GO
IF OBJECT_ID('pr4Count') is not null 
DROP proc pr4Count
GO
 Create proc pr4Count @cehId int
 as
 SET NOCOUNT ON;
 SELECT COUNT(*) as ProductsCount
 FROM Ceh
 inner join Area on Ceh.IdCeh=Area.CehId
 inner join EngTehWorker on EngTehWorker.AreaId=Area.IdArea
 WHERE (@cehId is null OR @cehId=Ceh.IdCeh)
 AND EngTehWorker.IsHead=1



   GO
IF OBJECT_ID('pr5') is not null 
DROP proc pr5
GO
 Create proc pr5 @productId int
 as
 SET NOCOUNT ON;
 SELECT *
 FROM Product
 inner join Work on Product.IdProduct=Work.ProductID
 WHERE Product.IdProduct=@productId



   GO
IF OBJECT_ID('pr6') is not null 
DROP proc pr6
GO
 Create proc pr6 @cehId int, @areaId int
 as
 SET NOCOUNT ON;
 SELECT *
 FROM Ceh
 inner join Area on Ceh.IdCeh=Area.CehId
 inner join Brigade on Area.IdArea=Brigade.AreaId
 inner join Worker on Worker.BrigadeId=Brigade.IdBrigade
 WHERE (@cehId is null OR @cehId=Ceh.IdCeh)
 AND (@areaId is null OR @areaId=Area.IdArea)



    GO
IF OBJECT_ID('pr7') is not null 
DROP proc pr7
GO
 Create proc pr7 @cehId int, @areaId int
 as
 SET NOCOUNT ON;
 SELECT *
 FROM Ceh
 inner join Area on Ceh.IdCeh=Area.CehId
 inner join EngTehWorker on EngTehWorker.AreaId=Area.IdArea
 WHERE (@cehId is null OR @cehId=Ceh.IdCeh)
 AND (@areaId is null OR @areaId=Area.IdArea)
 AND EngTehWorker.IsMaster=1



 GO
IF OBJECT_ID('pr8') is not null 
DROP proc pr8
GO
 Create proc pr8 @category varchar(100), @cehId int, @areaId int
 as
 SET NOCOUNT ON;
 SELECT Product.IdProduct, Product.CehId, Area.IdArea, Product.StartBuild, Product.Category
 FROM Product inner join Ceh on Product.CehId=Ceh.IdCeh
 inner join Area on Ceh.IdCeh=Area.CehId
 WHERE
 (@cehId is null OR Ceh.IdCeh=@cehId) AND
 (@category is null OR Product.Category=@category) AND 
 (@areaId is null OR Area.IdArea=@areaId) AND
 GETDATE()>=Product.StartBuild AND (Product.EndBuild is null OR GETDATE()<=Product.EndBuild)



  GO
IF OBJECT_ID('pr9') is not null 
DROP proc pr9
GO
 Create proc pr9 @productId int
 as
 SET NOCOUNT ON;
 SELECT Worker.BrigadeId, Worker.IdWorker, Worker.IsBrigadier, Worker.WorkerName
 FROM Product inner join Ceh on Product.CehId=Ceh.IdCeh
 inner join Area on Ceh.IdCeh=Area.CehId
 inner join Brigade on Area.IdArea=Brigade.AreaId
 inner join Worker on Brigade.IdBrigade=Worker.BrigadeId
 WHERE Product.IdProduct=@productId



   GO
IF OBJECT_ID('pr10') is not null 
DROP proc pr10
GO
 Create proc pr10 @productId int
 as
 SET NOCOUNT ON;
 SELECT TestLab.IdTestLab, TestLab.TestLabName
 FROM Product
 inner join TestEquipment on Product.TestEquipmentId=TestEquipment.IdTestEquipment
 inner join TestLab on TestEquipment.TestLabId=TestLab.IdTestLab
 WHERE Product.IdProduct=@productId



    GO
IF OBJECT_ID('pr11') is not null 
DROP proc pr11
GO
 Create proc pr11 @category varchar(100), @testLabId int, @startDate Date, @endDate Date
 as
 SET NOCOUNT ON;
 SELECT *
 FROM Product
 inner join TestEquipment on Product.TestEquipmentId=TestEquipment.IdTestEquipment
 inner join TestLab on TestEquipment.TestLabId=TestLab.IdTestLab
 WHERE
 (@category is null OR Product.Category=@category) AND 
 (@testLabId is null OR TestLab.IdTestLab=@testLabId) AND 
 (@startDate is null OR Product.EndTest is null OR @startDate<=Product.EndTest) AND 
 (@endDate is null OR @endDate>=Product.StartTest)



     GO
IF OBJECT_ID('pr12') is not null 
DROP proc pr12
GO
 Create proc pr12 @productId int, @category varchar(100), @testLabId int, @startDate Date, @endDate Date
 as
 SET NOCOUNT ON;
 SELECT DISTINCT Tester.TestLabId, Tester.IdTester, Tester.TesterName
 FROM Product
 inner join TestEquipment on Product.TestEquipmentId=TestEquipment.IdTestEquipment
 inner join TestLab on TestEquipment.TestLabId=TestLab.IdTestLab
 inner join Tester on TestLab.IdTestLab=Tester.TestLabId
 WHERE
 (@productId is null OR Product.IdProduct=@productId) AND 
 (@category is null OR Product.Category=@category) AND 
 (@testLabId is null OR TestLab.IdTestLab=@testLabId) AND 
 (@startDate is null OR Product.EndTest is null OR @startDate<=Product.EndTest) AND 
 (@endDate is null OR @endDate>=Product.StartTest)



      GO
IF OBJECT_ID('pr13') is not null 
DROP proc pr13
GO
 Create proc pr13 @productId int, @category varchar(100), @testLabId int, @startDate Date, @endDate Date
 as
 SET NOCOUNT ON;
 SELECT TestEquipment.TestLabId, TestEquipment.IdTestEquipment, TestEquipment.TestEquipmentName
 FROM Product
 inner join TestEquipment on Product.TestEquipmentId=TestEquipment.IdTestEquipment
 inner join TestLab on TestEquipment.TestLabId=TestLab.IdTestLab
 WHERE
 (@productId is null OR Product.IdProduct=@productId) AND 
 (@category is null OR Product.Category=@category) AND 
 (@testLabId is null OR TestLab.IdTestLab=@testLabId) AND 
 (@startDate is null OR Product.EndTest is null OR @startDate<=Product.EndTest) AND 
 (@endDate is null OR @endDate>=Product.StartTest)



  GO
IF OBJECT_ID('pr14') is not null 
DROP proc pr14
GO
 Create proc pr14 @category varchar(100), @cehId int, @areaId int
 as
 SET NOCOUNT ON;
 SELECT *
 FROM Product inner join Ceh on Product.CehId=Ceh.IdCeh
 inner join Area on Ceh.IdCeh=Area.CehId
 WHERE
 (@cehId is null OR Ceh.IdCeh=@cehId) AND
 (@category is null OR Product.Category=@category) AND 
 (@areaId is null OR Area.IdArea=@areaId) AND
 GETDATE()>=Product.StartBuild AND (Product.EndBuild is null OR GETDATE()<=Product.EndBuild)



   GO
IF OBJECT_ID('pr14Count') is not null 
DROP proc pr14Count
GO
 Create proc pr14Count @category varchar(100), @cehId int, @areaId int
 as
 SET NOCOUNT ON;
 SELECT COUNT(*) as ProductsCount
 FROM Product inner join Ceh on Product.CehId=Ceh.IdCeh
 inner join Area on Ceh.IdCeh=Area.CehId
 WHERE
 (@cehId is null OR Ceh.IdCeh=@cehId) AND
 (@category is null OR Product.Category=@category) AND 
 (@areaId is null OR Area.IdArea=@areaId) AND
 GETDATE()>=Product.StartBuild AND (Product.EndBuild is null OR GETDATE()<=Product.EndBuild)



 --TRIGGERS
 GO
 IF EXISTS (SELECT * FROM sys.triggers WHERE parent_class = 0 AND name = 'safety') DROP TRIGGER safety ON DATABASE; 
GO 
CREATE TRIGGER safety ON DATABASE 
FOR DROP_SYNONYM AS 
RAISERROR ('You must disable Trigger "safety" to drop synonyms!',10, 1) 
ROLLBACK 
GO 
DROP TRIGGER safety ON DATABASE; 
GO

--DISABLE TRIGGER { [ schema_name . ] trigger_name [ ,...n ] | ALL } 
--ON { object_name | DATABASE | ALL SERVER } [ ; ]

--ENABLE TRIGGER { [ schema_name . ] trigger_name [ ,...n ] | ALL } 
--ON { object_name | DATABASE | ALL SERVER } [ ; ]


IF OBJECT_ID ('NotWokerProf','TR') IS NOT NULL DROP TRIGGER NotWokerProf; 
GO 
CREATE TRIGGER NotWokerProf ON Prof
AFTER INSERT 
AS
IF EXISTS (SELECT * FROM EngTehProf inner join inserted on EngTehProf.EngTehProfName=inserted.ProfName) 
BEGIN
RAISERROR ('В доданих професіях є інженерно-технічна, а не робітнича', 16, 1); 
ROLLBACK TRANSACTION; 
RETURN 
END; 
GO

ENABLE TRIGGER NotWokerProf ON Prof;
INSERT INTO Prof VALUES
(4, 'Engineer')
GO

IF OBJECT_ID ('NotEngTehProf','TR') IS NOT NULL DROP TRIGGER NotEngTehProf; 
GO 
CREATE TRIGGER NotEngTehProf ON EngTehProf
AFTER INSERT 
AS
IF EXISTS (SELECT * FROM Prof inner join inserted on Prof.ProfName=inserted.EngTehProfName) 
BEGIN 
RAISERROR ('В доданих професіях є робітнича, а не інженерно-технічна', 16, 1); 
ROLLBACK TRANSACTION; 
RETURN 
END; 
GO

INSERT INTO EngTehProf VALUES
(3, 'Welder')
GO

IF OBJECT_ID ('BadProductDate','TR') IS NOT NULL DROP TRIGGER BadProductDate; 
GO 
CREATE TRIGGER BadProductDate ON Product
AFTER INSERT 
AS
IF EXISTS (SELECT * FROM inserted AS i
WHERE i.EndBuild < i.StartBuild OR i.EndTest < i.StartTest OR i.StartTest < i.EndBuild) 
BEGIN
RAISERROR ('В доданих виробах є виріб з некоректним вказанням дат', 16, 1); 
ROLLBACK TRANSACTION; 
RETURN 
END; 
GO

INSERT INTO Product VALUES
(4, 0, 0, '2007-11-11', '2008-11-11', '2008-11-11', '2009-11-11', 'Plane')
GO

IF OBJECT_ID ('BadWorkDate','TR') IS NOT NULL DROP TRIGGER BadWorkDate; 
GO 
CREATE TRIGGER BadWorkDate ON Work
AFTER INSERT 
AS
IF EXISTS (SELECT * FROM inserted AS i
WHERE i.EndDate < i.StartDate) 
BEGIN
RAISERROR ('В доданих роботах є робота з некоректним вказанням дат', 16, 1); 
ROLLBACK TRANSACTION; 
RETURN 
END; 
GO

INSERT INTO Work VALUES
(6, 'Making engine', 0, '2007-11-11', '2006-01-01')
GO



--CURSORS
SET NOCOUNT ON; 
DECLARE FinishedWorks_Cursor  CURSOR 
FOR SELECT WorkName, StartDate, EndDate
        FROM Work
        WHERE WorkName like 'F%';
OPEN FinishedWorks_Cursor;
FETCH NEXT FROM FinishedWorks_Cursor;
WHILE @@FETCH_STATUS = 0
BEGIN    
   FETCH  NEXT  FROM FinishedWorks_Cursor
END;
CLOSE FinishedWorks_Cursor;
DEALLOCATE FinishedWorks_Cursor; 
GO

SET NOCOUNT ON;    
DECLARE @plane_id int ,@plane_name varchar(20);    
PRINT '-------- All Planes Report --------';    
DECLARE plane_cursor CURSOR FOR     
SELECT IdPlane, PlaneName    
FROM Plane  
order by IdPlane;    
OPEN plane_cursor    
FETCH NEXT FROM plane_cursor     
INTO @plane_id,@plane_name    
print 'Plane_ID  Plane_Name'       
WHILE @@FETCH_STATUS = 0    
BEGIN    
    print '   ' + CAST(@plane_id as varchar(10)) +'         '+  
        cast(@plane_name as varchar(100))  
    FETCH NEXT FROM plane_cursor     
INTO @plane_id,@plane_name    
END     
CLOSE plane_cursor;    
DEALLOCATE plane_cursor;    
GO



--INDEXES
IF EXISTS (SELECT name FROM sys.indexes WHERE name = N'IX_Workers')    
DROP INDEX IX_Workers ON Worker;
GO
CREATE UNIQUE INDEX  IX_Workers
ON Worker(WorkerName)
GO

IF EXISTS (SELECT name FROM sys.indexes WHERE name = N'IX_EngTehWorkers')    
DROP INDEX IX_EngTehWorkers ON EngTehWorker;
GO
CREATE UNIQUE INDEX IX_EngTehWorkers
ON EngTehWorker(EngTehWorkerName)
GO

IF EXISTS (SELECT name FROM sys.indexes WHERE name = N'IX_ProductDates')    
DROP INDEX IX_ProductDates ON Product;
GO
CREATE NONCLUSTERED INDEX IX_ProductDates
ON Product (StartBuild, EndBuild, StartTest, EndTest);
GO

SELECT * FROM Product ORDER BY StartBuild


Exec pr1 null, null;

Exec pr1 null, 0;

Exec pr2 '2008-11-11', '2009-11-11', 'Rocket', 1, 0;

Exec pr2 null, null, null, null, null;

Exec pr2Count null, null, null, null, null;

Exec pr3 null, null, null;

Exec pr3 null, 'Engineer', null;

Exec pr4 null;

Exec pr4Count null;

Exec pr5 0;

Exec pr6 1, 0;

Exec pr7 null, null;

Exec pr8 null, null, null;

Exec pr9 1;

Exec pr10 0;

Exec pr11 null, null, null, null;

Exec pr11 null, null, '2009-11-11', '2011-01-01';

Exec pr12 null, null, null, null, null;

Exec pr12 null, null, 0, null, null;

Exec pr13 null, null, null, null, null;

Exec pr14 null, null, null;

Exec pr14Count null, null, null;



--ROLES
 --Drop role SysAdmin
 --go
 --Create role SysAdmin
 --GRANT all to SysAdmin

 go 
 drop role Architect
 Create role Architect
 GRANT SELECT, INSERT, UPDATE, DELETE on Product to Architect
 GRANT SELECT, INSERT, UPDATE, DELETE on Work to Architect
 GRANT SELECT, INSERT, UPDATE, DELETE on Plane to Architect
 GRANT SELECT, INSERT, UPDATE, DELETE on Rocket to Architect
 GRANT SELECT, INSERT, UPDATE, DELETE on TestLab to Architect
 GRANT SELECT, INSERT, UPDATE, DELETE on TestEquipment to Architect
 GRANT SELECT, INSERT, UPDATE, DELETE on Ceh to Architect
 GRANT SELECT, INSERT, UPDATE, DELETE on Area to Architect
 GRANT SELECT, INSERT, UPDATE, DELETE on Brigade to Architect
 GRANT EXECUTE on pr1 to Architect
 GRANT EXECUTE on pr2 to Architect
 GRANT EXECUTE on pr4 to Architect
 GRANT EXECUTE on pr5 to Architect
 GRANT EXECUTE on pr7 to Architect
 GRANT EXECUTE on pr8 to Architect
 GRANT EXECUTE on pr9 to Architect
 GRANT EXECUTE on pr10 to Architect
 GRANT EXECUTE on pr11 to Architect
 GRANT EXECUTE on pr13 to Architect
 GRANT EXECUTE on pr14 to Architect


 go
 drop role HRManager
 Create role HRManager
 GRANT SELECT, INSERT, UPDATE, DELETE on Worker to HRManager
 GRANT SELECT, INSERT, UPDATE, DELETE on WorkerProf to HRManager
 GRANT SELECT, INSERT, UPDATE, DELETE on Prof to HRManager
 GRANT SELECT, INSERT, UPDATE, DELETE on EngTehWorker to HRManager
 GRANT SELECT, INSERT, UPDATE, DELETE on EngTehWorkerProf to HRManager
 GRANT SELECT, INSERT, UPDATE, DELETE on EngTehProf to HRManager
 GRANT SELECT, INSERT, UPDATE, DELETE on Tester to HRManager
 GRANT EXECUTE on pr3 to HRManager
 GRANT EXECUTE on pr6 to HRManager
 GRANT EXECUTE on pr12 to HRManager
 
 go
 drop role DbUser
 Create role DbUser
 --GRANT SELECT on Product to DbUser
 --GRANT SELECT on Work to DbUser
 --GRANT SELECT on Plane to DbUser
 --GRANT SELECT on Rocket to DbUser
 --GRANT SELECT on TestLab to DbUser
 --GRANT SELECT on TestEquipment to DbUser
 --GRANT SELECT on Ceh to DbUser
 --GRANT SELECT on Area to DbUser
 --GRANT SELECT on Brigade to DbUser
 GRANT EXECUTE on pr1 to DbUser
 GRANT EXECUTE on pr2 to DbUser
 GRANT EXECUTE on pr4 to DbUser
 GRANT EXECUTE on pr5 to DbUser
 GRANT EXECUTE on pr7 to DbUser
 GRANT EXECUTE on pr8 to DbUser
 GRANT EXECUTE on pr9 to DbUser
 GRANT EXECUTE on pr10 to DbUser
 GRANT EXECUTE on pr11 to DbUser
 GRANT EXECUTE on pr13 to DbUser
 GRANT EXECUTE on pr14 to DbUser

 --USERS
 go
 Exec sp_addlogin 'SystemAdmin1','551233AdminQweEwq', 'AviaBuildDB'
 Exec sp_addlogin 'Architect1','551233ArchQweEwq', 'AviaBuildDB'
 Exec sp_addlogin 'HRManager1','551233HRQweEwq', 'AviaBuildDB'
 Exec sp_addlogin 'User111','551233UserQweEwq', 'AviaBuildDB'

 EXEC sp_adduser 'SystemAdmin1', 'SystemAdmin1', 'db_owner'
 EXEC sp_adduser 'Architect1', 'Architect1', 'Architect'
 EXEC sp_adduser 'HRManager1', 'HRManager1', 'HRManager'
 EXEC sp_adduser 'User111', 'User111', 'DbUser'

 --exec sp_addrolemember SysAdmin, ad
 --exec sp_addrolemember Manager1, User1