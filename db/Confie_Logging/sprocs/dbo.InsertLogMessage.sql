IF OBJECT_ID('[dbo].[InsertLogMessage]', 'P') IS NULL
    EXECUTE ('CREATE PROCEDURE [dbo].[InsertLogMessage] AS SET NOCOUNT ON;');
GO

ALTER PROCEDURE [dbo].[InsertLogMessage]
    @CorrelationId UNIQUEIDENTIFIER
  , @LogTimestamp DATETIME2
  , @LogTypeId INT
  , @IpAddressId INT
  , @ExecutableId INT
  , @LevelId INT
  , @LogMessage VARCHAR(MAX)
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


INSERT INTO dbo.LogMessages
(
    LogId
  , LevelId
  , LogMessage
)
VALUES
(@LogId, @LevelId, @LogMessage);

COMMIT TRANSACTION;
