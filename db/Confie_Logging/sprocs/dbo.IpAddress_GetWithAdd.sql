IF OBJECT_ID('[dbo].[IpAddress_GetWithAdd]', 'P') IS NULL
    EXECUTE ('CREATE PROCEDURE [dbo].[IpAddress_GetWithAdd] AS SET NOCOUNT ON;');
GO

ALTER PROCEDURE [dbo].[IpAddress_GetWithAdd] @IpAddress VARCHAR(45)
AS
IF NOT EXISTS
(
    SELECT ip.IpAddressId
    FROM dbo.IpAddresses AS ip
    WHERE ip.IpAddress = @IpAddress
)
BEGIN

    INSERT INTO dbo.IpAddresses
    (
        IpAddress
    )
    VALUES
    (@IpAddress);
END;

SELECT ip.IpAddressId
     , ip.IpAddress
FROM dbo.IpAddresses AS ip
WHERE ip.IpAddress = @IpAddress;
