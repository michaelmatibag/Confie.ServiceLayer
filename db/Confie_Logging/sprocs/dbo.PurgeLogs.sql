IF OBJECT_ID('[dbo].[PurgeLogs]', 'P') IS NULL
    EXECUTE ('CREATE PROCEDURE [dbo].[PurgeLogs] AS SET NOCOUNT ON;');
GO

ALTER PROCEDURE [dbo].[PurgeLogs]
    @KeepThisManyDays INT
  , @RetainErrorLogs BIT
AS
SET TRANSACTION ISOLATION LEVEL SNAPSHOT;

BEGIN TRANSACTION;
SET XACT_ABORT ON;

--Cleanup old logs
DELETE l
FROM dbo.Logs AS l
WHERE l.LogTimestamp < DATEADD(DAY, -@KeepThisManyDays, GETDATE())
      AND @RetainErrorLogs = 0
      OR
      (
          @RetainErrorLogs = 1
          AND l.LogId NOT IN
              (
                  SELECT DISTINCT
                         wr.LogId
                  FROM dbo.WebRequests AS wr
                  WHERE wr.ResponseHttpStatusCode = 500 -- Internal Server Error Code
                  UNION ALL
                  SELECT DISTINCT
                         m.LogId
                  FROM dbo.LogMessages AS m
                  WHERE m.LevelId = 2 --Error
              )
      );

--Cleanup Unneeded Executables
DELETE e
FROM dbo.Executables AS e
WHERE e.ExecutableId NOT IN
      (
          SELECT DISTINCT
                 l.ExecutableId
          FROM dbo.Logs AS l
          UNION ALL
          SELECT DISTINCT
                 wr.RequesterExecutableId
          FROM dbo.WebRequests AS wr
      );

--Cleanup Unneeded IpAddresses
DELETE ip
FROM dbo.IpAddresses AS ip
WHERE ip.IpAddressId NOT IN
      (
          SELECT DISTINCT
                 l.IpAddressId
          FROM dbo.Logs AS l
          UNION ALL
          SELECT DISTINCT
                 wr.RequesterIpAddressId
          FROM dbo.WebRequests AS wr
      );

--Cleanup Unneeded RequestUrls
DELETE u
FROM dbo.RequestUrls AS u
WHERE u.RequestUrlId NOT IN
      (
          SELECT DISTINCT wr.RequestUrlId FROM dbo.WebRequests AS wr
      );

COMMIT TRANSACTION;
