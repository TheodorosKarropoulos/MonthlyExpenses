CREATE TABLE [exp].[Expenses] (
    [Id]     INT          NOT NULL identity,
    [Month]  VARCHAR (50)  NOT NULL,
    [Year]   INT          NOT NULL,
    [Amount] DECIMAL (15, 2) NOT NULL,
    [Status] TINYINT      NOT NULL,
    [CategoryId] INT NOT NULL, 
	CONSTRAINT FK_Expense_Expense_Category FOREIGN KEY (CategoryId)     
    REFERENCES exp.Expense_category (Id),
    PRIMARY KEY CLUSTERED ([Id] ASC)
	
);

