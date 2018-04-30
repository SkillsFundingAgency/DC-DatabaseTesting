CREATE TABLE [dbo].[TestTable] (
    [ID]        INT            IDENTITY (1, 1) NOT NULL,
    [anInt]     INT            NOT NULL,
    [aString]   NVARCHAR (MAX) NOT NULL,
    [aBool]     BIT            NOT NULL,
    [aDecimal]  DECIMAL (18)   NOT NULL,
    [aDateTime] DATETIME       NOT NULL,
    CONSTRAINT [PK_TestTable] PRIMARY KEY CLUSTERED ([ID] ASC)
);

