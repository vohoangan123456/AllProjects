INSERT INTO #Description VALUES ('create CRUD for tblWords')
GO

IF OBJECT_ID('dbo.CreateNewWord', 'p') IS NULL
    EXEC ('CREATE PROCEDURE dbo.CreateNewWord AS SELECT 1')
GO
ALTER PROCEDURE dbo.CreateNewWord
    @Word NVARCHAR(100),
	@Type NCHAR(20),
	@Pronunciation NVARCHAR(100),
	@Meaning NVARCHAR(1000),
	@Example NVARCHAR(1000),
	@Translation NVARCHAR(1000),
	@Note NVARCHAR(1000),
	@CategoryId INT
AS
SET NOCOUNT ON
BEGIN
	INSERT INTO dbo.tblWords
		(Word, [Type], Pronunciation, Meaning, Example, Translation, Note, CategoryId)
	VALUES
		(@Word, @Type, @Pronunciation, @Meaning, @Example, @Translation, @Note, @CategoryId)

	SELECT SCOPE_IDENTITY()
END
GO

IF OBJECT_ID('dbo.UpdateWord', 'p') IS NULL
    EXEC ('CREATE PROCEDURE dbo.UpdateWord AS SELECT 1')
GO
ALTER PROCEDURE dbo.UpdateWord
	@Id INT,
    @Word NVARCHAR(100),
	@Type NCHAR(20),
	@Pronunciation NVARCHAR(100),
	@Meaning NVARCHAR(1000),
	@Example NVARCHAR(1000),
	@Translation NVARCHAR(1000),
	@Note NVARCHAR(1000),
	@CategoryId INT
AS
SET NOCOUNT ON
BEGIN
	UPDATE dbo.tblWords
	SET Word = @Word,
		[Type] = @Type,
		Pronunciation = @Pronunciation,
		Meaning = @Meaning,
		Example = @Example,
		Translation = @Translation,
		Note = @Note,
		CategoryId = @CategoryId
	WHERE Id = @Id
END
GO

IF OBJECT_ID('dbo.DeleteWords', 'p') IS NULL
    EXEC ('CREATE PROCEDURE dbo.DeleteWords AS SELECT 1')
GO
ALTER PROCEDURE dbo.DeleteWords
	@Ids AS dbo.Items READONLY
AS
SET NOCOUNT ON
BEGIN
	UPDATE dbo.tblWords
		SET IsDeleted = 1
	WHERE Id IN (SELECT Id FROM @Ids)
END
GO

IF OBJECT_ID('dbo.GetWordById', 'p') IS NULL
    EXEC ('CREATE PROCEDURE dbo.GetWordById AS SELECT 1')
GO
ALTER PROCEDURE dbo.GetWordById
	@Id INT
AS
SET NOCOUNT ON
BEGIN
	SELECT Id, Word, [Type], Pronunciation, Meaning, Example, Translation, Note, CategoryId
	FROM dbo.tblWords
	WHERE IsDeleted = 0
		AND Id = @Id
END
GO

IF OBJECT_ID('dbo.GetActiveWords', 'p') IS NULL
    EXEC ('CREATE PROCEDURE dbo.GetActiveWords AS SELECT 1')
GO
ALTER PROCEDURE dbo.GetActiveWords
AS
SET NOCOUNT ON
BEGIN
	SELECT Id, Word, [Type], Pronunciation, Meaning, Example, Translation, Note, CategoryId
	FROM dbo.tblWords
	WHERE IsDeleted = 0
END
GO
