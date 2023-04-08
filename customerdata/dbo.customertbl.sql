CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL , 
    [Name] NVARCHAR(50) NULL, 
    [Address] NVARCHAR(50) NULL, 
    [Phone] NVARCHAR(50) NULL IDENTITY, 
    [Email] NVARCHAR(50) NULL, 
    CONSTRAINT [PK_Table] PRIMARY KEY ([Id])
)
