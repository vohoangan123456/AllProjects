INSERT INTO #Description VALUES ('create CRUD for tblCategories')
GO

IF  NOT EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'Items' AND ss.name = N'dbo')
	CREATE TYPE dbo.Items AS TABLE(
		[Id] [int] NOT NULL,
		[Value] [int] NULL
	)
GO

IF  NOT EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'TableWords' AND ss.name = N'dbo')
	CREATE TYPE [dbo].[TableWords] AS TABLE(
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Word] [nvarchar](100) NOT NULL,
		[Type] [nchar](20) NULL,
		[Pronunciation] [nvarchar](100) NULL,
		[Meaning] [nvarchar](1000) NOT NULL,
		[Example] [nvarchar](1000) NULL,
		[Translation] [nvarchar](1000) NULL,
		[Note] [nvarchar](1000) NULL,
		[CategoryId] [int] NULL
	)
GO

IF OBJECT_ID('dbo.CreateNewCategory', 'p') IS NULL
    EXEC ('CREATE PROCEDURE dbo.CreateNewCategory AS SELECT 1')
GO
ALTER PROCEDURE dbo.CreateNewCategory
	@CategoryName NVARCHAR(100)
AS
SET NOCOUNT ON
BEGIN
	INSERT INTO dbo.tblCategories
		(Name)
	VALUES
		(@CategoryName)

	SELECT SCOPE_IDENTITY()
END
GO

IF OBJECT_ID('dbo.UpdateCategory', 'p') IS NULL
    EXEC ('CREATE PROCEDURE dbo.UpdateCategory AS SELECT 1')
GO
ALTER PROCEDURE dbo.UpdateCategory
	@Id INT,
    @Name NVARCHAR(250),
    @IsDeleted BIT
AS
SET NOCOUNT ON
BEGIN
	UPDATE dbo.tblCategories
	SET Name = @Name,
		IsDeleted = @IsDeleted
	WHERE Id = @Id
END
GO

IF OBJECT_ID('dbo.DeleteCategory', 'p') IS NULL
    EXEC ('CREATE PROCEDURE dbo.DeleteCategory AS SELECT 1')
GO
ALTER PROCEDURE dbo.DeleteCategory
	@Ids AS dbo.Items READONLY
AS
SET NOCOUNT ON
BEGIN
	UPDATE dbo.tblCategories
		SET IsDeleted = 1
	WHERE Id IN (SELECT Id FROM @Ids)
END
GO

IF OBJECT_ID('dbo.GetActiveCategories', 'p') IS NULL
    EXEC ('CREATE PROCEDURE dbo.GetActiveCategories AS SELECT 1')
GO
ALTER PROCEDURE dbo.GetActiveCategories
AS
SET NOCOUNT ON
BEGIN
	SELECT *
	FROM dbo.tblCategories
	WHERE IsDeleted = 0
END
GO
