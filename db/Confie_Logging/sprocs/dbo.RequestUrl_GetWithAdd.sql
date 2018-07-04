IF OBJECT_ID('[dbo].[RequestUrl_GetWithAdd]', 'P') IS NULL
    EXECUTE ('CREATE PROCEDURE [dbo].[RequestUrl_GetWithAdd] AS SET NOCOUNT ON;');
GO

ALTER PROCEDURE [dbo].[RequestUrl_GetWithAdd] @RequestUrl VARCHAR(1000)
AS
IF NOT EXISTS
(
    SELECT u.RequestUrlId
    FROM dbo.RequestUrls AS u
    WHERE u.RequestUrl = @RequestUrl
)
BEGIN

    INSERT INTO dbo.RequestUrls
    (
        RequestUrl
    )
    VALUES
    (@RequestUrl);
END;

SELECT u.RequestUrlId
     , u.RequestUrl
FROM dbo.RequestUrls AS u
WHERE u.RequestUrl = @RequestUrl;
