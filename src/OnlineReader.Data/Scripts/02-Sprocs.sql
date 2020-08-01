CREATE PROC dbo.Files_Post
	(
	@FileName nvarchar(150),
	@Created datetime2,
	@MimeType nvarchar(100),
	@BlobId uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO dbo.Files
		(FileName, Created, MimeType, BlobId)
	VALUES(@FileName, @Created, @MimeType, @BlobId)

	SELECT SCOPE_IDENTITY() AS Id
END
GO
