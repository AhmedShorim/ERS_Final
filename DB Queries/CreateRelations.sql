--Create Relation Query
USE [ERS]

if not exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[Reservation_Customer_C_ID]') AND parent_object_id = OBJECT_ID('Reservation'))
ALTER TABLE Reservation
ADD CONSTRAINT Reservation_Customer_C_ID
FOREIGN KEY (C_ID)
REFERENCES Customer(C_ID)
go

if not exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[Reservation_Customer_R_ID]') AND parent_object_id = OBJECT_ID('Reservation'))
ALTER TABLE Reservation
ADD CONSTRAINT Reservation_Customer_R_ID
FOREIGN KEY (R_ID)
REFERENCES Room(R_ID)
go

if not exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[Room_Catering_F_ID]') AND parent_object_id = OBJECT_ID('Room_Catering'))
ALTER TABLE Room_Catering
ADD CONSTRAINT Room_Catering_F_ID
FOREIGN KEY (F_ID)
REFERENCES Catering(F_ID)
go

if not exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[Room_Catering_Res_ID]') AND parent_object_id = OBJECT_ID('Room_Catering'))
ALTER TABLE Room_Catering
ADD CONSTRAINT Room_Catering_Res_ID
FOREIGN KEY (Res_ID)
REFERENCES Reservation(Res_ID)
go

if not exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[Price_Cost]') AND parent_object_id = OBJECT_ID('Catering'))
ALTER TABLE Catering
ADD CONSTRAINT Price_Cost
CHECK (Price > Cost)
go

if not exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[USER_TYPE]') AND parent_object_id = OBJECT_ID('User'))
ALTER TABLE [User]
ADD CONSTRAINT USER_TYPE
CHECK ([type] = 'Admin' OR  [type] = 'User' )
go


