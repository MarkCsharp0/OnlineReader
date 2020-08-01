CREATE TABLE dbo.Files(
	Id int IDENTITY(1,1) NOT NULL,
	FileName nvarchar(100) NOT NULL,
	Mimetype nvarchar(100) NOT NULL,
	Created datetime2(7) NOT NULL,
	BlobId uniqueidentifier NOT NULL
 CONSTRAINT PK_Files PRIMARY KEY CLUSTERED 
(
	Id ASC
)
) 
GO