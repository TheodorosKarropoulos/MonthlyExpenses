CREATE TABLE [exp].[Expenses] (
    [Id]     INT          NOT NULL,
    [Month]  VARCHAR (1)  NOT NULL,
    [Year]   INT          NOT NULL,
    [Amount] DECIMAL (18) NOT NULL,
    [Status] TINYINT      NOT NULL,
    [CategoryId] INT NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

