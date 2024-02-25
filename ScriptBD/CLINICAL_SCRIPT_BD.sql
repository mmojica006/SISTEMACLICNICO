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
@Name varchar(100),
@State int,
@AuditCreateDate datetime
)
AS
BEGIN
INSERT INTO Analysis(Name,State,AuditCreateDate) values(@Name,@State,@AuditCreateDate);
END


-- exec uspAnalysisById 2