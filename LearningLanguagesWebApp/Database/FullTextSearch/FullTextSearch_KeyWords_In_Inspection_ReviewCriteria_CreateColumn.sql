INSERT INTO #Description VALUES ('Create column fulltextsearch first')
GO

IF NOT EXISTS (SELECT 1  FROM   sys.columns  WHERE  object_id = OBJECT_ID(N'[Inspection].[ReviewCriteria]') AND name = 'KeyWords')
BEGIN
	ALTER TABLE [Inspection].[ReviewCriteria] ADD KeyWords NVARCHAR(MAX) NULL
END
GO