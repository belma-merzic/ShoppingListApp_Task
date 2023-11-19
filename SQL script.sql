create database Task_DB

go

use Task_DB

go

create table Shopper
(
 ShopperID int primary key identity(1,1),
 ShopperName nvarchar(50)
)

create table Item
(
 ItemID int primary key identity(1,1),
 ItemName nvarchar(50)
)

create table ShoppingList
(
 ShoppingListID int primary key identity(1,1),
 ShopperID int,
 ItemID int,

 FOREIGN KEY (ShopperID) REFERENCES Shopper(ShopperID),
 FOREIGN KEY (ItemID) REFERENCES Item(ItemID),
)

insert into Shopper (ShopperName) values 
('Shopper1'),
('Shopper2'),
('Shopper3'),
('Shopper4')

go

insert into Item (ItemName) values 
('Item1'),
('Item2'),
('Item3'),
('Item4')