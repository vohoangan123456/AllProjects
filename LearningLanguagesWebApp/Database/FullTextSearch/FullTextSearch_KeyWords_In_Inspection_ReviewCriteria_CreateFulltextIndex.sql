INSERT INTO #Description VALUES ('Create FullTextIndex for existed column')
GO

IF NOT EXISTS (SELECT 1 FROM sys.fulltext_catalogs WHERE [name] = 'ReviewCriteriaCatalogs')
BEGIN
	CREATE FULLTEXT CATALOG ReviewCriteriaCatalogs AS DEFAULT;		
END
GO

IF NOT EXISTS(SELECT * FROM sys.fulltext_indexes WHERE object_id = OBJECT_ID('[Inspection].[ReviewCriteria]'))
BEGIN
	CREATE FULLTEXT INDEX ON  [Inspection].[ReviewCriteria] (
		KeyWords LANGUAGE 0
	) KEY INDEX PK_ReviewCriteria 
	WITH 
		CHANGE_TRACKING = AUTO, 
		STOPLIST=OFF
	;
END
GO