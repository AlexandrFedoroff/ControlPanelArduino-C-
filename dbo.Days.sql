CREATE TABLE [dbo].[Days] (
    [KeyDays]  INT           IDENTITY (1, 1) NOT NULL,
    [KeyTimes] INT           NULL,
    [DayA]     DATETIME2 (7) NULL, 
    CONSTRAINT [PK_Days] PRIMARY KEY ([KeyDays])
);

