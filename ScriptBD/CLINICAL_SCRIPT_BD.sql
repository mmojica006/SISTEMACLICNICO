--CREATE DATABASE CLINICAL
--USE CLINICAL
CREATE TABLE Analysis (
	AnalysisId int identity(1,1) primary key not null,
	Name varchar(50),
	State int not null,
	AuditCreateDate datetime2(7) not null
)
go

--uspAnalysisList
CREATE or alter PROCEDURE uspAnalysisList  as 
BEGIN
select AnalysisId,Name,AuditCreateDate,State from Analysis
END

GO
/*procedimiento para obtener una analysis*/
CREATE OR ALTER PROCEDURE uspAnalysisById
(
@AnalysisId int
)
AS
BEGIN
	SELECT AnalysisId, Name FROM Analysis WHERE AnalysisId = @AnalysisId

END

/*Procedure uspAnalysisRegister*/
GO
CREATE OR ALTER PROCEDURE uspAnalysisRegister
(
@Name varchar(100)

)
AS
BEGIN
INSERT INTO Analysis(Name,State,AuditCreateDate) values(@Name,1,GETDATE());
END

GO
CREATE OR ALTER PROCEDURE uspAnalysisEdit 
(
@AnalysisId INT,
@Name VARCHAR(50)

)
AS
BEGIN
UPDATE Analysis SET Name = @Name
WHERE AnalysisId = @AnalysisId
END
GO

CREATE OR ALTER PROCEDURE uspAnalysisRemove 
(
@AnalysisId INT
)
AS
BEGIN
DELETE FROM Analysis 
WHERE AnalysisId = @AnalysisId
END
GO

create or alter procedure uspAnalysischangEstate(
@AnalysisId int,
@State int
)
as
begin

update Analysis 
set State = @State
where AnalysisId = @AnalysisId

end

GO
create table Exams(
ExamId int identity(1,1) primary key not null,
Name varchar(100),
AnalysisId int not null,
State int not null,
AuditCreateDate datetime2(7) not null,
foreign key (AnalysisId) references Analysis(AnalysisId)
)
GO


create or alter procedure uspExamList
as
begin
select ex.ExamId, ex.Name, an.Name Analysis ,ex.AuditCreateDate, case ex.State when 1 then 'Activo' else 'Inactivo' end StateExam 
from Exams ex
inner join Analysis an on ex.AnalysisId = an.AnalysisId
end
GO
create or alter procedure uspExamById(
@ExamId int
)
as
begin
	select ex.ExamId, ex.Name, ex.AnalysisId 

	from Exams ex
	where ex.ExamId=@ExamId
end

GO

create or alter procedure uspExamRegister
(
@Name varchar(100),
@AnalysisId int
)
as
begin
insert into Exams (Name, AnalysisId, state, AuditCreateDate) values( @Name,@AnalysisId, 1,GETDATE())
end

GO
Create or alter procedure UspExamEdit(
@ExamId int,
@Name varchar(100),
@AnalysisId int
)
as

begin
	update Exams set Name = @Name, AnalysisId = @AnalysisId where ExamId = @ExamId
end

go
CREATE OR ALTER PROCEDURE uspExamRemove
(
@ExamId INT
)
as

begin
delete from Exams where ExamId = @ExamId
end

go


create or alter procedure uspExamChangeState
(
@ExamId INT,
@state int
)
as

begin
update Exams
set State = @state
where ExamId = @ExamId
end


create table DocumentTypes
(
DocumentTypeId int identity(1,1) primary key not null,
Document varchar(50),
state int

)

create table TypeAges
(
TypeAgeId int identity(1,1) primary key not null,
TypeAge varchar(15),
State  int
)

create table Genders
(
GenderId int identity(1,1) primary key not null,
Gender varchar(25),
State int
)


create table Patients
(
PatiendId int identity(1,1) primary key not null,
Names varchar(100),
LastName varchar(50),
MotherMaidenName varchar(50),
DocumentTypeId int,
DocumentNumber varchar(25),
Phone varchar(15),
TypeAgeId int,
Age int,
GenderId int,
State int,
AuditCreateDate datetime2(7),

foreign key(DocumentTypeId) references DocumentTypes(DocumentTypeId),
foreign key(TypeAgeId) references TypeAges(TypeAgeId),
foreign key(GenderId) references Genders(GenderId),

)

go

create or alter procedure uspPatientList
as
begin
	select pa.PatiendId, pa.Names, CONCAT_WS(' ', pa.LastName, pa.MotherMaidenName) Surnames,
	dt.Document DocumentType,
	pa.DocumentNumber,
	pa.Phone,
	CONCAT_WS(' ', pa.Age, ta.TypeAge) Age,
	ge.Gender,
	case pa.State when 1 then 'ACTIVO' ELSE 'INACTIVO' END StatePatient,
	pa.AuditCreateDate
	from Patients pa
	inner join  DocumentTypes dt on pa.DocumentTypeId = dt.DocumentTypeId
	inner join TypeAges ta on pa.TypeAgeId = ta.TypeAgeId
	inner join Genders ge on pa.GenderId = ge.GenderId

end

go
create or alter procedure uspPatientById
(
@patientId int
)
as
begin
	select pa.PatiendId, pa.Names, pa.LastName, pa.MotherMaidenName, pa.DocumentTypeId, pa.DocumentNumber, pa.Phone, pa.TypeAgeId, pa.Age, pa.GenderId
	from Patients pa where PatiendId = @patientId
end
go
select * from Patients

go
create or alter procedure uspPaPatientRegister
(
@Names varchar(100),
@LastName varchar(50),
@MotherMaidenName varchar(50),
@DocumentTypeId int,
@DocumentNumber varchar(25),
@Phone varchar(15),
@TypeAgeId int,
@Age int,
@GenderId int

)
as

begin

insert into Patients(Names,LastName,MotherMaidenName,DocumentTypeId,DocumentNumber,Phone,TypeAgeId,Age,GenderId,State, AuditCreateDate)
values (@Names,@LastName,@MotherMaidenName,@DocumentTypeId,@DocumentNumber,@Phone,@TypeAgeId,@Age,@GenderId,1,GETDATE())
end

go

create or alter procedure uspPatientEdit
(
@PatientId int,
@Names varchar(100),
@LastName varchar(50),
@MotherMaidenName varchar(50),
@DocumentTypeId int,
@DocumentNumber varchar(25),
@Phone varchar(15),
@TypeAgeId int,
@Age int,
@GenderId int
)
as

begin
update Patients 
set Names = @Names, 
	LastName = @LastName, 
	MotherMaidenName = @MotherMaidenName, 
	DocumentTypeId=@DocumentTypeId, 
	DocumentNumber = @DocumentNumber, 
	Phone = @Phone, 
	TypeAgeId =@TypeAgeId, 
	Age =@Age,
	GenderId =@GenderId
	where PatiendId = @PatientId

end

go
CREATE OR ALTER PROCEDURE uspPatientRemove 
(
@PatientId INT
)
AS
BEGIN
DELETE FROM Patients 
WHERE PatiendId = @PatientId
END
GO

create or alter procedure uspPatientChangEstate(
@PatientId int,
@State int
)
as
begin

update Patients 
set State = @State
where PatiendId = @PatientId

end

select * from Patients
go
create table Specialties
(
SpecialtyId int identity(1,1) primary key,
Name varchar(100) not null,
State int not null,
AuditCreateDate datetime2(7) not null,

)

create table Medics
(
 MedicId int identity(1,1) primary key not null,
 Names varchar(100) not null,
 LastName varchar(100) not null,
 MotherMaidenName varchar(100) not null,
 Address varchar(255) null,
 Phone varchar(15) null,
 BirthDate date null,
 DocumentTypeId int not null,
 DocumentNumber varchar(25) not null,
 SpecialtyId int not null,
 State int not null,
 AuditCreateDate datetime2(7) not null,
 Foreign key(DocumentTypeId) references DocumentTypes(DocumentTypeId),
 Foreign key(SpecialtyId) references Specialties(SpecialtyId)
)

go
create or alter procedure uspMedicList
as
begin
select me.MedicId, me.Names, CONCAT(' ', me.LastName, me.MotherMaidenName) Surnames ,
sp.Name Specialty,dt.Document DocumentType, me.DocumentNumber, me.Address, me.Phone, me.BirthDate, 
case me.State when 1 then 'ACTIVO' else 'INACTIVO' end StateMedic, me.AuditCreateDate 
from Medics me
inner join DocumentTypes dt on me.DocumentTypeId = dt.DocumentTypeId
inner join Specialties sp on me.SpecialtyId = sp.SpecialtyId
end


-- exec uspPatientById 1 