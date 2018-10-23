IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE id=OBJECT_ID('tempdb..#tmpErrors')) DROP TABLE #tmpErrors
GO
CREATE TABLE #tmpErrors (Error int)
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
GO
BEGIN TRANSACTION
GO
IF SCHEMA_ID('dbo') IS NULL
	EXEC('CREATE SCHEMA dbo AUTHORIZATION [dbo]');
GO

SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SchemaChanges]') AND type in (N'U'))
	CREATE TABLE [dbo].[SchemaChanges](
		[MajorReleaseNumber] [varchar](5) NULL,
		[MinorReleaseNumber] [varchar](5) NULL,
		[BuildReleaseNumber] [varchar](5) NULL,
		[RevisionReleaseNumber] [varchar](5) NULL,
		[ScriptName] [varchar](50) NULL,
		[Description] [nvarchar](500) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO



IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
IF EXISTS (SELECT * FROM #tmpErrors) ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT>0 BEGIN
	PRINT 'The database update succeeded'
	COMMIT TRANSACTION
END
ELSE 
	PRINT 'The database update failed'
GO
DROP TABLE #tmpErrors
GO