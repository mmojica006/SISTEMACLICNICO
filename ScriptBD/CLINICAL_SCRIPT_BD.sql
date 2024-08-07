CREATE TABLE Analysis (
	AnalysisId int identity(1,1) primary key not null,
	Name varchar(50),
	State int not null,
	AuditCreateDate datetime2(7) not null
)
go

--uspAnalysisList
CREATE PROCEDURE uspAnalysisList  as 
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
CREATE PROCEDURE uspAnalysisRegister
(
@Name varchar(100)

)
AS
BEGIN
INSERT INTO Analysis(Name,State,AuditCreateDate) values(@Name,1,GETDATE());
END


CREATE PROCEDURE uspAnalysisEdit 
(
@AnalysisId INT,
@Name VARCHAR(50)

)
AS
BEGIN
UPDATE Analysis SET Name = @Name
WHERE AnalysisId = @AnalysisId
END

CREATE PROCEDURE uspAnalysisRemove 
(
@AnalysisId INT
)
AS
BEGIN
DELETE FROM Analysis 
WHERE AnalysisId = @AnalysisId
END

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


create table Exams(
ExamId int identity(1,1) primary key not null,
Name varchar(100),
AnalysisId int not null,
State int not null,
AuditCreateDate datetime2(7) not null,
foreign key (AnalysisId) references Analysis(AnalysisId)
)



create or alter procedure uspExamList
as
begin
select ex.ExamId, ex.Name, an.Name Analysis ,ex.AuditCreateDate, case ex.State when 1 then 'Activo' else 'Inactivo' end StateExam 
from Exams ex
inner join Analysis an on ex.AnalysisId = an.AnalysisId
end

create or alter procedure uspExamById(
@ExamId int
)
as
begin
	select ex.ExamId, ex.Name, ex.AnalysisId 

	from Exams ex
	where ex.ExamId=@ExamId
end



create or alter procedure uspExamRegister
(
@Name varchar(100),
@AnalysisId int
)
as
begin

insert into Exams (Name, AnalysisId, state, AuditCreateDate) values( @Name,@AnalysisId, 1,GETDATE())


end


Create or alter procedure UspExamEdit(
@ExamId int,
@Name varchar(100),
@AnalysisId int
)
as

begin
	update Exams set Name = @Name, AnalysisId = @AnalysisId where ExamId = @ExamId
end


-- exec uspAnalysisById 2