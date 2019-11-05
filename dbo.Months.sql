CREATE TABLE [dbo].[Months] (
    [KeyMonts] INT           IDENTITY (1, 1) NOT NULL,
    [KeyDays]  INT           NULL,
    [MonthA]   DATETIME2 (7) NULL, 
    CONSTRAINT [PK_Months] PRIMARY KEY ([KeyMonts])
);

