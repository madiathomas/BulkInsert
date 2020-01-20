USE People
GO

CREATE DATABASE People;
GO

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
GO

CREATE PROCEDURE prc_InsertPerson
(
	@FirstName nvarchar(100),
	@LastName nvarchar(100),
	@Gender nvarchar(100),
	@Age nvarchar(100),
	@Email nvarchar(100),
	@Phone nvarchar(100),
	@Education nvarchar(100),
	@Occupation nvarchar(100),
	@Experience nvarchar(100),
	@MaritalStatus nvarchar(100)
)
AS
INSERT INTO Person(FirstName,
				   LastName,
				   Gender,
				   Age,Email,
				   Phone,
				   Education,
				   Occupation,
				   Experience,
				   MaritalStatus) 
VALUES(@FirstName,
	   @LastName,
	   @Gender,
	   @Age,
	   @Email,
	   @Phone,
	   @Education,
	   @Occupation,
	   @Experience,
	   @MaritalStatus);
GO