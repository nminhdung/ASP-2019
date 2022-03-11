use WebBanHangASP
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
TypeId int,
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
isPopular int,
CategoryId int,
BrandId int,
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
insert into Category (name,avatar,slug,ShowOnHomePage,DisplayOrder,Deleted,isPopular)
values(N'Điện Thoại','dienthoai.jpg','dien-thoai',1,0,0,1)
insert into Category (name,avatar,slug,ShowOnHomePage,DisplayOrder,Deleted,isPopular)
values(N'Máy Tính','maytinh.jpg','may-tinh',1,0,0,1)
insert into Category (name,avatar,slug,ShowOnHomePage,DisplayOrder,Deleted,isPopular)
values(N'Đồng Hồ','dongho.jpg','dong-ho',1,0,0,1)
insert into Category (name,avatar,slug,ShowOnHomePage,DisplayOrder,Deleted,isPopular)
values(N'Phụ Kiện','phukien.jpg','phu-kien',1,0,0,0)

insert into Brand (name,avatar,slug,ShowOnHomePage,DisplayOrder,Deleted)
values(N'Apple','apple.jpg','apple',1,0,0)
insert into Brand (name,avatar,slug,ShowOnHomePage,DisplayOrder,Deleted)
values(N'Acer','acer.jpg','acer',1,0,0)
insert into Brand (name,avatar,slug,ShowOnHomePage,DisplayOrder,Deleted)
values(N'Xiaomi','xiaomi.jpg','xiaomi',1,0,0)
insert into Brand (name,avatar,slug,ShowOnHomePage,DisplayOrder,Deleted)
values(N'Asus','asus.jpg','asus',1,0,0)
/*apple*/

insert into
    Product_0242(name,slug,avatar,price,PriceDiscount)
	values(N'Macbook Pro 16inch','macbook-pro-16inch',N'Macbook Pro 16inch.jpg',36720000,NULL);
insert into
    Product_0242(name,slug,avatar,price,PriceDiscount)
	values(N'Macbook Pro M1','macbook-pro-m1',N'Macbook Pro M1.jpg',22949000,18677000);
insert into
    Product_0242(name,slug,avatar,price,PriceDiscount)
	values(N'Macbook Retina','macbook-retina',N'Macbook Retina.jpg',22009000,15099000);
insert into
    Product_0242(name,slug,avatar,price,PriceDiscount)
    values(N'Apple Watch Series 7','apple-watch-series-7',N'Apple Watch Series 7.jpeg',10790000,NULL);
insert into
    Product_0242(name,slug,avatar,price,PriceDiscount)
    values(N'Iphone 8 Plus','iphone-8-plus',N'Iphone 8 Plus.jpg',8418000,NULL);
insert into
    Product_0242(name,slug,avatar,price,PriceDiscount)
    values(N'AirPods Pro','airpods-pro',N'AirPods Pro.jpg',2241000,NULL);
insert into
    Product_0242(name,slug,avatar,price,PriceDiscount)
    values(N'AirPods 2','airpods-2',N'AirPods 2.jpg',2662000,NULL);
insert into
    Product_0242(name,slug,avatar,price,PriceDiscount)
    values(N'AirPods 3','airpods-3',N'AirPods 3.jpg',2308000,NULL);
insert into
    Product_0242(name,slug,avatar,price,PriceDiscount)
    values(N'Apple Watch Series 4','apple-watch-series-4',N'Apple Watch Series 4.jpg',5822000,NULL);
insert into
    Product_0242(name,slug,avatar,price,PriceDiscount)
    values(N'Apple Watch Series 5','apple-watch-series-5',N'Apple Watch Series 5.jpg',6109000,NULL);
insert into
    Product_0242(name,slug,avatar,price,PriceDiscount)
    values(N'Apple Watch Series 6','apple-watch-series-6',N'Apple Watch Series 6.jpg',6955000,6180000);
/*xiaomi*/
insert into
    Product_0242(name,slug,avatar,price,PriceDiscount)
	values(N'Xiaomi Life 5g','xiaomi-life-5g',N'Xiaomi Life 5g.jpg',15906000,NULL);
insert into
    Product_0242(name,slug,avatar,price,PriceDiscount)
	values(N'Xiaomi Redmi 10','xiaomi-redmi-10',N'Xiaomi Redmi 10.jpg',14975000,NULL);
insert into
    Product_0242(name,slug,avatar,price,PriceDiscount)
    values(N'Xiaomi Mi Mix 3','xiaomi-mi-mix-3',N'Xiaomi Mi Mix 3.jpg',70844000,NULL);
insert into
    Product_0242(name,slug,avatar,price,PriceDiscount)
    values(N'Xiaomi Redmi Note 11','xiaomi-redmi-note-11',N'Xiaomi Redmi Note 11.jpg',15789000,12331000);
insert into
    Product_0242(name,slug,avatar,price,PriceDiscount)
    values(N'Xiaomi Redmi 10','xiaomi-redmi-10',N'Xiaomi Redmi 10.jpg',29304000,NULL);
insert into
    Product_0242(name,slug,avatar,price,PriceDiscount)
    values(N'Xiaomi 11 Life NE','xiaomi-11-life-ne',N'Xiaomi 11 Life NE.jpg',22489000,NULL);
/*asus*/
insert into
    Product_0242(name,slug,avatar,price,PriceDiscount)
    values(N'Asus Trixg 15','asus-trixg-15',N'Asus Trixg 15.jpg',15541000,NULL);
insert into
    Product_0242(name,slug,avatar,price,PriceDiscount)
    values(N'Asus Rog Zephyrus duo 15','asus-rog-zephyrus-duo-15',N'Asus Rog Zephyrus duo 15.jpg',37143000,32836000);
insert into
    Product_0242(name,slug,avatar,price,PriceDiscount)
    values(N'Asus Rog Zephyrus g14','asus-rog-zephyrus-g14',N'Asus Rog Zephyrus g14.jpg',36658000,NULL);
insert into
    Product_0242(name,slug,avatar,price,PriceDiscount)
    values(N'Asus Trixg 15','asus-trixg-15',N'Asus Trixg 15.jpg',16205000,NULL);
insert into
    Product_0242(name,slug,avatar,price,PriceDiscount)
    values(N'Assus VivoBook S15','assus-vivobook-s15',N'Assus VivoBook S15.jpg',19498000,NULL);
insert into
    Product_0242(name,slug,avatar,price,PriceDiscount)
    values(N'Asus Zenfone 7','asus-zenfone-7',N'Asus Zenfone 7.jpg',19618000,NULL);
insert into
    Product_0242(name,slug,avatar,price,PriceDiscount)
    values(N'Asus Zenfone 8','asus-zenfone-8',N'Asus Zenfone 8.jpg',24338000,NULL);
insert into
    Product_0242(name,slug,avatar,price,PriceDiscount)
    values(N'Asus Rog Strix Fusion 300','asus-rog-strix-fusion-300',N'Asus Rog Strix Fusion 300.jpg',6252000,NULL);
insert into
    Product_0242(name,slug,avatar,price,PriceDiscount)
    values(N'Asus Rog TheTa 7','asus-rog-theta-7',N'Asus Rog TheTa 7.1.jpg',10575000,NULL);
/*acer*/
insert into
    Product_0242(name,slug,avatar,price,PriceDiscount)
    values(N'Acer Aspire 7','acer-aspire-7',N'Acer Aspire 7.jpg',28048000,NULL);
insert into
    Product_0242(name,slug,avatar,price,PriceDiscount)
    values(N'Acer Aspire 5','acer-aspire-5',N'Acer Aspire 5.jpg',15095000,NULL);
insert into
    Product_0242(name,slug,avatar,price,PriceDiscount)
    values(N'Acer AMD Ryzen 5','acer-amd-ryzen-5',N'Acer AMD Ryzen 5.jpg',22806000,NULL);
insert into
    Product_0242(name,slug,avatar,price,PriceDiscount)
    values(N'Acer Predator Galea 300','acer-predator-galea-300',N'Acer Predator Galea 300.jpg',2031000,NULL);
insert into
    Product_0242(name,slug,avatar,price,PriceDiscount)
    values(N'Acer Predator Galea 500','acer-predator-galea-500',N'Acer Predator Galea 500.jpg',2789000,NULL);
