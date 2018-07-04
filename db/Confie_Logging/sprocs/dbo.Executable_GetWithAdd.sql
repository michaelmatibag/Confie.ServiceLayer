IF OBJECT_ID('[dbo].[Executable_GetWithAdd]', 'P') IS NULL
    EXECUTE ('CREATE PROCEDURE [dbo].[Executable_GetWithAdd] AS SET NOCOUNT ON;');
GO

ALTER PROCEDURE [dbo].[Executable_GetWithAdd]
    @ExecutableName VARCHAR(500)
  , @ExecutableTypeId INT
AS
IF NOT EXISTS
(
    SELECT e.ExecutableId
    FROM dbo.Executables AS e
    WHERE e.ExecutableName = @ExecutableName
          AND e.ExecutableTypeId = @ExecutableTypeId
)
BEGIN

    INSERT INTO dbo.Executables
    (
        ExecutableName
      , ExecutableTypeId
    )
    VALUES
    (@ExecutableName, @ExecutableTypeId);
END;

SELECT e.ExecutableId
     , e.ExecutableName
     , e.ExecutableTypeId
FROM dbo.Executables AS e
WHERE e.ExecutableName = @ExecutableName
      AND e.ExecutableTypeId = @ExecutableTypeId;
