Create table dbo.Product(
Id int,
Name nvarchar(100),
Avata nchar(100),
CategoryId int,
BrandId int,
FullDescription nvarchar(500),
Price float,
PriceDiscount float,
Slug nvarchar(50),
)

Create table dbo.Brand(
Id int,
Name nvarchar(100),
Avatar nvarchar(100),
ShowOnHomePage bit,
Slug varchar(50),
DisplayOrder int,
Deleted bit,
)

Create table dbo.Category(
Id int,
Name nvarchar(100),
Avatar nchar(100),
Slug varchar(100),
ShowOnHomePage bit,
DisplayOrder int,
Deleted bit,
)
Create table dbo_Order (
Id int,
Name nvarchar(100),
ProductId int,
Price float,
Status bit,
CreatedOnUtc datetime
)

Create table dbo_User
(
Id int,
FirstName varchar(100),
LastName varchar(100),
Email varchar(100),
Password varchar(100),
IsAdmin bit
)