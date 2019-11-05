CREATE TABLE [dbo].[Times] (
    [KeyTimes]        INT           IDENTITY (1, 1) NOT NULL,
    [KeyControlPanel] INT           NULL,
    [TimeA]           DATETIME2 (7) NULL, 
    CONSTRAINT [PK_Times] PRIMARY KEY ([KeyTimes])
);

