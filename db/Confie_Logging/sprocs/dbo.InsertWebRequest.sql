IF OBJECT_ID('[dbo].[InsertWebRequest]', 'P') IS NULL
    EXECUTE ('CREATE PROCEDURE [dbo].[InsertWebRequest] AS SET NOCOUNT ON;');
GO

ALTER PROCEDURE [dbo].[InsertWebRequest]
    @CorrelationId UNIQUEIDENTIFIER
  , @LogTimestamp DATETIME2
  , @LogTypeId INT
  , @IpAddressId INT
  , @ExecutableId INT
  , @RequestUrlId INT
  , @RequestHttpVerbId INT
  , @RequestTimestamp DATETIME2
  , @RequesterIpAddressId INT
  , @RequesterExecutableId INT
  , @ResponseTimestamp DATETIME2
  , @ResponseHttpStatusCode INT
  , @ResponseIsCached BIT
  , @Request VARCHAR(MAX)
  , @Response VARCHAR(MAX)
AS
BEGIN TRANSACTION;
SET XACT_ABORT ON;

DECLARE @LogId INT = NEXT VALUE FOR dbo.LogId;

INSERT INTO dbo.Logs
(
    LogId
  , CorrelationId
  , LogTimestamp
  , LogTypeId
  , IpAddressId
  , ExecutableId
)
VALUES
(@LogId, @CorrelationId, @LogTimestamp, @LogTypeId, @IpAddressId, @ExecutableId);

INSERT INTO dbo.WebRequests
(
    LogId
  , RequestUrlId
  , RequestHttpVerbId
  , RequestTimestamp
  , RequesterIpAddressId
  , RequesterExecutableId
  , ResponseTimestamp
  , ResponseHttpStatusCode
  , ResponseIsCached
)
VALUES
(@LogId, @RequestUrlId, @RequestHttpVerbId, @RequestTimestamp, @RequesterIpAddressId, @RequesterExecutableId
, @ResponseTimestamp, @ResponseHttpStatusCode, @ResponseIsCached);

IF (@Request IS NOT NULL OR @Response IS NOT NULL)
BEGIN
    INSERT INTO dbo.WebRequests_Contents
    (
        LogId
      , Request
      , Response
    )
    VALUES
    (@LogId, @Request, @Response);
END;

COMMIT TRANSACTION;
