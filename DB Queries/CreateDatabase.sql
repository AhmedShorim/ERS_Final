----Create tables and database
--USE [master]
--GO
--ALTER DATABASE [ERS] SET  SINGLE_USER WITH ROLLBACK IMMEDIATE
--GO
--USE [master]
--GO
--/****** Object:  Database [MorganDB]    Script Date: 11/29/2013 13:40:36 ******/
--DROP DATABASE [ERS]
--Create DATABASE [ERS]
--GO



USE [ERS]

if not exists (select * from sysobjects where name='Customer' and xtype='U')
create table Customer
(
C_ID int NOT NULL IDENTITY PRIMARY KEY,
Name varchar(255) NOT NULL,
Mobile decimal(11,0) NOT NULL UNIQUE
)
go
if not exists (select * from sysobjects where name='Room' and xtype='U')
create table Room
(
 R_ID int NOT NULL   PRIMARY KEY,
 Disc varchar(255),
 Price money,
 Deleted bit
)
go
if not exists (select * from sysobjects where name='Reservation' and xtype='U')
create table Reservation
(
Res_ID int NOT NULL IDENTITY  PRIMARY KEY,
C_ID int NOT NULL,
R_ID int NOT NULL,
StartTime smalldatetime NOT NULL,
EndTime smalldatetime
)
go
if not exists (select * from sysobjects where name='Catering' and xtype='U')
CREATE UNIQUE NONCLUSTERED INDEX Unique_Name_Status ON Catering (Name) where Deleted='False'
if not exists (select * from sysobjects where name='Catering' and xtype='U')
create table Catering
(
F_ID int Not NULL IDENTITY  PRIMARY KEY,
Name varchar(255) NOT NULL ,
Price money NOT NULL,
Cost money NOT NULL,
Stock int,
Deleted bit
)

go

go
if not exists (select * from sysobjects where name='Room_Catering' and xtype='U')
create table Room_Catering
(
Res_ID int,
F_ID int,
Quantity int not null
)
go
if not exists (select * from sysobjects where name='User' and xtype='U')
create table [User]
(
U_ID  varchar(255) NOT NULL primary key,
PW    varchar(255),
[type] varchar(255),
Salary money  
)
go
if not exists (select * from sysobjects where name='Expense' and xtype='U')
create table [Expense]
(
Description  varchar(255) NOT NULL,
Paid    money NOT NULL,
[ExpenseTime] smalldatetime NOT NULL
)
go