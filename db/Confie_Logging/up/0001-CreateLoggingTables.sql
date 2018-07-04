CREATE TABLE dbo.ExecutableTypes
(
    ExecutableTypeId INT NOT NULL IDENTITY(1, 1)
  , ExecutableType VARCHAR(100) NOT NULL
);
GO

ALTER TABLE dbo.ExecutableTypes
ADD CONSTRAINT pk_ExecutableTypes
    PRIMARY KEY (ExecutableTypeId);
ALTER TABLE dbo.ExecutableTypes
ADD CONSTRAINT ak_ExecutableTypes_ExecutableType
    UNIQUE (ExecutableType);
GO

CREATE TABLE dbo.Executables
(
    ExecutableId INT NOT NULL IDENTITY(1, 1)
  , ExecutableName VARCHAR(500) NOT NULL
  , ExecutableTypeId INT NOT NULL
);
GO

ALTER TABLE dbo.Executables
ADD CONSTRAINT pk_Executables
    PRIMARY KEY (ExecutableId);
ALTER TABLE dbo.Executables
ADD CONSTRAINT ak_Executables_ExecutableName_ExecutableTypeId
    UNIQUE (
               ExecutableName
             , ExecutableTypeId
           );
ALTER TABLE dbo.Executables
ADD CONSTRAINT fk_Executables_ExecutableTypes
    FOREIGN KEY (ExecutableTypeId)
    REFERENCES dbo.ExecutableTypes (ExecutableTypeId);
GO

CREATE TABLE dbo.Levels
(
    LevelId INT NOT NULL IDENTITY(1, 1)
  , LevelName VARCHAR(100) NOT NULL
);
GO

ALTER TABLE dbo.Levels ADD CONSTRAINT pk_Levels PRIMARY KEY (LevelId);
ALTER TABLE dbo.Levels
ADD CONSTRAINT ak_Levels_LevelName
    UNIQUE (LevelName);
GO

CREATE TABLE dbo.IpAddresses
(
    IpAddressId INT NOT NULL IDENTITY(1,1)
  , IpAddress VARCHAR(45) NOT NULL
);

ALTER TABLE dbo.IpAddresses
ADD CONSTRAINT pk_IpAddresses
    PRIMARY KEY (IpAddressId);

ALTER TABLE dbo.IpAddresses
ADD CONSTRAINT ak_IpAddresses_IpAddress
    UNIQUE (IpAddress);
GO

CREATE TABLE dbo.LogTypes
(
    LogTypeId INT NOT NULL IDENTITY(1, 1)
  , LogType VARCHAR(100) NOT NULL
);
GO

ALTER TABLE dbo.LogTypes
ADD CONSTRAINT pk_LogTypes
    PRIMARY KEY (LogTypeId);

ALTER TABLE dbo.LogTypes
ADD CONSTRAINT ak_LogTypes_LogType
    UNIQUE (LogType);
GO

CREATE TABLE dbo.Logs
(
    LogId INT NOT NULL
  , CorrelationId UNIQUEIDENTIFIER NOT NULL
  , LogTimestamp DATETIME2(3) NOT NULL
  , LogTypeId INT NOT NULL
  , IpAddressId INT NOT NULL
  , ExecutableId INT NOT NULL
);
GO

ALTER TABLE dbo.Logs ADD CONSTRAINT pk_Logs PRIMARY KEY (LogId);

ALTER TABLE dbo.Logs
ADD CONSTRAINT fk_Logs_LogTypes
    FOREIGN KEY (LogTypeId)
    REFERENCES dbo.LogTypes (LogTypeId);

ALTER TABLE dbo.Logs
ADD CONSTRAINT fk_Logs_Executables
    FOREIGN KEY (ExecutableId)
    REFERENCES dbo.Executables (ExecutableId);

ALTER TABLE dbo.Logs
ADD CONSTRAINT fk_Logs_IpAddresses
    FOREIGN KEY (IpAddressId)
    REFERENCES dbo.IpAddresses (IpAddressId);

GO

CREATE TABLE dbo.LogMessages
(
    LogId INT NOT NULL
  , LevelId INT NOT NULL
  , LogMessage VARCHAR(MAX) NOT NULL
);

ALTER TABLE dbo.LogMessages
ADD CONSTRAINT pk_LogMessages
    PRIMARY KEY (LogId);

ALTER TABLE dbo.LogMessages
ADD CONSTRAINT fk_LogMessages_Logs
    FOREIGN KEY (LogId)
    REFERENCES dbo.Logs (LogId)
	ON DELETE CASCADE;

ALTER TABLE dbo.LogMessages
ADD CONSTRAINT fk_LogMessages_Levels
    FOREIGN KEY (LevelId)
    REFERENCES dbo.Levels (LevelId);
GO

CREATE TABLE dbo.HttpVerbs
(
    HttpVerbId INT NOT NULL IDENTITY(1, 1)
  , HttpVerb VARCHAR(10) NOT NULL
);
GO

ALTER TABLE dbo.HttpVerbs ADD CONSTRAINT pk_HttpVerbs PRIMARY KEY (HttpVerbId);
ALTER TABLE dbo.HttpVerbs
ADD CONSTRAINT ak_HttpVerbs_HttpVerb
    UNIQUE (HttpVerb);
GO

CREATE TABLE dbo.RequestUrls
(
    RequestUrlId INT NOT NULL IDENTITY(1, 1)
  , RequestUrl VARCHAR(1000) NOT NULL
);
GO

ALTER TABLE dbo.RequestUrls ADD CONSTRAINT pk_RequestUrls PRIMARY KEY (RequestUrlId);
ALTER TABLE dbo.RequestUrls
ADD CONSTRAINT ak_RequestUrls_RequestUrl
    UNIQUE (RequestUrl);
GO

CREATE TABLE dbo.WebRequests
(
    LogId INT NOT NULL
  , RequestUrlId INT NOT NULL
  , RequestHttpVerbId INT NOT NULL
  , RequestTimestamp DATETIME2(3) NOT NULL
  , RequesterIpAddressId INT NOT NULL
  , RequesterExecutableId INT NULL
  , ResponseTimestamp DATETIME2(3) NOT NULL
  , ResponseHttpStatusCode INT NOT NULL
  , ResponseIsCached BIT NOT NULL
);

ALTER TABLE dbo.WebRequests
ADD CONSTRAINT pk_WebRequests
    PRIMARY KEY (LogId);

ALTER TABLE dbo.WebRequests
ADD CONSTRAINT fk_WebRequests_Logs
    FOREIGN KEY (LogId)
    REFERENCES dbo.Logs (LogId)
	ON DELETE CASCADE;

ALTER TABLE dbo.WebRequests
ADD CONSTRAINT fk_WebRequests_Executables
    FOREIGN KEY (RequesterExecutableId)
    REFERENCES dbo.Executables (ExecutableId);

ALTER TABLE dbo.WebRequests
ADD CONSTRAINT fk_WebRequests_IpAddresses
    FOREIGN KEY (RequesterIpAddressId)
    REFERENCES dbo.IpAddresses (IpAddressId);

ALTER TABLE dbo.WebRequests
ADD CONSTRAINT fk_WebRequests_HttpVerbs
    FOREIGN KEY (RequestHttpVerbId)
    REFERENCES dbo.HttpVerbs (HttpVerbId);

ALTER TABLE dbo.WebRequests
ADD CONSTRAINT fk_WebRequests_RequestUrls
    FOREIGN KEY (RequestUrlId)
    REFERENCES dbo.RequestUrls (RequestUrlId);
GO

CREATE TABLE dbo.WebRequests_Contents
(
	LogId INT NOT NULL,
	Request VARCHAR(MAX) NULL,
	Response VARCHAR(MAX) NULL
);

ALTER TABLE dbo.WebRequests_Contents
ADD CONSTRAINT pk_WebRequests_Contents
    PRIMARY KEY (LogId);

ALTER TABLE dbo.WebRequests_Contents
ADD CONSTRAINT fk_WebRequests_Contents_WebRequests
    FOREIGN KEY (LogId)
    REFERENCES dbo.WebRequests (LogId)
	ON DELETE CASCADE;

-----------------------------------------

CREATE SEQUENCE dbo.LogId AS INT START WITH 1 INCREMENT BY 1;
GO

INSERT INTO dbo.ExecutableTypes
(
    ExecutableType
)
VALUES
('WebApi')
, ('ConsoleApplication');
GO

INSERT INTO dbo.Levels
(
    LevelName
)
VALUES
('Information')
, ('Error')
, ('Verbose');
GO

INSERT INTO dbo.HttpVerbs
(
    HttpVerb
)
VALUES
('GET'), ('POST'), ('PUT'), ('DELETE'), ('OPTIONS');

INSERT INTO dbo.LogTypes
(
    LogType
)
VALUES
('LogMessage')
, ('WebRequest');
