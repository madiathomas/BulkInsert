If(db_id(N'People') IS NULL)
BEGIN
CREATE DATABASE People;
END;

USE People
GO
IF NOT EXISTS(SELECT [name] FROM sys.tables WHERE [name] = 'Person')
BEGIN
	CREATE TABLE Person(
        FirstName nvarchar(100) NULL,
        LastName nvarchar(100) NULL,
        Gender nvarchar(100) NULL,
        Age nvarchar(100) NULL,
        Email nvarchar(100) NULL,
        Phone nvarchar(100) NULL,
        Education nvarchar(100) NULL,
        Occupation nvarchar(100) NULL,
        Experience nvarchar(100) NULL,
        MaritalStatus nvarchar(100) NULL	  
	);
END;