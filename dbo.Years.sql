CREATE TABLE [dbo].[Years] (
    [KeyYars]  INT           IDENTITY (1, 1) NOT NULL,
    [KeyMonts] INT           NULL,
    [YearA]    DATETIME2 (7) NULL, 
    CONSTRAINT [PK_Years] PRIMARY KEY ([KeyYars])
);

