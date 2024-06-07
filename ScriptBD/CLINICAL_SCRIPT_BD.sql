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
-- exec uspAnalysisById 2