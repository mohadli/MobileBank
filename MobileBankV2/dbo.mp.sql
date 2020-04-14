CREATE TABLE [dbo].[mp] (
    [Id]     NVARCHAR (15)  NOT NULL,
    [Brand]  NVARCHAR (20)  NOT NULL,
    [Name]   NVARCHAR (20)  NOT NULL,
    [Size]   NVARCHAR (4)   NOT NULL,
    [CPU]    NVARCHAR (50)  NULL,
    [Camera] NVARCHAR (4)   NULL,
    [Pic]    VARBINARY(MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

