--Procedures
USE [ERS]
go

IF object_id('Create_User') IS NULL
 EXEC ('create procedure Create_User as select 1')
 GO

Alter Procedure Create_User
 @ID   varchar(255),
 @PW   varchar(255),
 @Type varchar(255),
 @Salary money
 As
     INSERT INTO  [User]
          ( 
            U_ID                   ,
            PW                     ,
            [type]                   ,
            Salary                                   
          ) 
     VALUES 
          ( 
            @ID                   ,
            @PW                     ,
            @TYPE                   ,
            @Salary                   
	    	)
GO

---------------------------------------------------------------------------------------------------------
IF object_id('Change_PW') IS NULL
 EXEC ('create procedure Change_PW as select 1')
 GO

Alter Procedure Change_PW
 @ID   varchar(255),
 @Old_PW   varchar(255),
 @New_PW   varchar(255)
 As
 UPDATE [User]
SET PW=@New_PW
WHERE PW=@Old_PW AND U_ID=@ID; 
GO
-------------------------------------------------------------------------------------------------------------
IF object_id('Delete_User') IS NULL
 EXEC ('create procedure Delete_User as select 1')
 GO

Alter Procedure Delete_User
 @ID   varchar(255),
 @PW   varchar(255)	
 As
DELETE FROM [User]
WHERE PW=@PW AND U_ID=@ID; 
GO
--------------------------------------------------------------------------------------------------------------
IF object_id('Change_Salary') IS NULL
 EXEC ('create procedure Change_Salary as select 1')
 GO

Alter Procedure Change_Salary
 @ID   varchar(255),
 @Salary   money	
 As
UPDATE [User]
SET Salary=@Salary
WHERE U_ID=@ID; 
GO


---------------------------------------------------------------------------------------------------------------
-- User Tables procedure END
---------------------------------------------------------------------------------------------------------------

---------------------------------------------------------------------------------------------------------------
-- Room Tables procedure Begin
---------------------------------------------------------------------------------------------------------------
IF object_id('Create_Room') IS NULL
 EXEC ('create procedure Create_Room as select 1')
 GO

Alter Procedure Create_Room
 @ID   varchar(255),
 @DISC   varchar(255),
 @Price money,
 @Delete bit=False
 As
     INSERT INTO  [Room]
          ( 
            R_ID                   ,
            DISC                     ,
            Price                     ,
            Deleted			
          ) 
     VALUES 
          ( 
            @ID                   ,
            @DISC                     ,
            @Price                     ,
             @Delete			
	    	)
GO
---------------------------------------------------------------------------------------------------------------
IF object_id('Room_Price') IS NULL
 EXEC ('create procedure Room_Price as select 1')
 GO

Alter Procedure Room_Price
 @ID   varchar(255),
 @Price   money
 As
 UPDATE [Room]
SET Price=@Price
WHERE R_ID=@ID; 
GO
-------------------------------------------------------------------------------------------------------------------
IF object_id('Delete_Room') IS NULL
 EXEC ('create procedure Delete_Room as select 1')
 GO

Alter Procedure Delete_Room
 @ID   varchar(255)
 AS Update  [Room]
 SET Deleted='True'
WHERE R_ID=@ID and Deleted='False'; ; 

GO
-------------------------------------------------------------------------------------------------------------------
IF object_id('Edit_Room') IS NULL
 EXEC ('create procedure Edit_Room as select 1')
 GO

Alter Procedure Edit_Room
 @ID   varchar(255),
 @Price   money,
 @DISC varchar(255)
 As
 UPDATE [Room]
SET Price=@Price , DISC=@DISC
WHERE R_ID=@ID and Deleted='False'; 
GO
------------------------------------------------------------------------------------------------------------------
	IF object_id('Retrieve_Rooms') IS NULL
	 EXEC ('create procedure Retrieve_Rooms as select 1')
	 GO

	Alter Procedure Retrieve_Rooms
	AS
	SELECT R_ID
	FROM Room
	where Deleted = 'False';
	GO

---------------------------------------------------------------------------------------------------------------
-- Room Tables procedure END
---------------------------------------------------------------------------------------------------------------

---------------------------------------------------------------------------------------------------------------
-- Customer Tables procedure Begin
---------------------------------------------------------------------------------------------------------------
IF object_id('New_Customer') IS NULL
 EXEC ('create procedure New_Customer as select 1')
 GO

Alter Procedure New_Customer
 @Name   varchar(255),
 @Mobile decimal(11,0)
 As
     INSERT INTO  [Customer]
          ( 
            Name                   ,
            Mobile                                                      
          ) 
     VALUES 
          ( 
            @Name                   ,
            @Mobile                                                       
	    	)
GO
---------------------------------------------------------------------------------------------------------------
IF object_id('Edit_customer') IS NULL
 EXEC ('create procedure Edit_customer as select 1')
 GO

Alter Procedure Edit_customer
 @New_Mobile   Decimal(11,0),
 @New_Name varchar(255),
 @ID   Decimal(11,0)
 As
 UPDATE [Customer]
SET Mobile=@New_Mobile , Name=@New_Name
WHERE C_ID=@ID; 
GO
----------------------------------------------------------------------------------------------------------------
IF object_id('Delete_Customer') IS NULL
 EXEC ('create procedure Delete_Customer as select 1')
 GO

Alter Procedure Delete_Customer
 @ID   Decimal(11,0)
 As
 DELETE FROM [Customer]
WHERE C_ID=@ID; 
GO

---------------------------------------------------------------------------------------------------------------
-- Customer Table procedures END
---------------------------------------------------------------------------------------------------------------

---------------------------------------------------------------------------------------------------------------
-- Catering Table procedures Begin
---------------------------------------------------------------------------------------------------------------

IF object_id('New_Catering') IS NULL
 EXEC ('create procedure New_Catering as select 1')
 GO

Alter Procedure New_Catering
 @Name   varchar(255),
 @Cost  money,
 @Price money,
 @Stock decimal(11,0),
 @Delete bit='False'
 
 As
     INSERT INTO  Catering
          ( 
            Name                   ,
            Cost                   ,
			Price                  ,
			Stock                  ,
          	Deleted		
          ) 
     VALUES 
          ( 
            @Name                   ,
            @Cost                   ,
			@Price                  ,
			@Stock                  ,
            @Delete			
	    	)
GO
-------------------------------------------------------------------------------------
IF object_id('Update_catering') IS NULL
 EXEC ('create procedure Update_catering as select 1')
 GO

Alter Procedure Update_catering
  @Name   varchar(255),
 @Cost  money,
 @Price money,
 @Stock decimal(11,0),
 @ID int
 As
 UPDATE [Catering]
SET Price=@Price , Cost=@Cost , Stock=@Stock , Name=@Name 
WHERE F_ID=@ID and Deleted='False'; 
GO
--------------------------------------------------------------------------------------
IF object_id('Delete_catering') IS NULL
 EXEC ('create procedure Delete_catering as select 1')
 GO

Alter Procedure Delete_catering
 @ID int
 As
 Update  [Catering]
 SET Deleted='True' 
WHERE F_ID=@ID and Deleted='False'; 
GO
--------------------------------------------------------------------------------------
IF object_id('Add_Stock') IS NULL
 EXEC ('create procedure Add_Stock as select 1')
 GO

Alter Procedure Add_Stock
 @Name   varchar(255),
 @Stock int
 As
 UPDATE [Catering]
SET Stock=@Stock+Stock
WHERE Name=@Name; 
GO
----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------
-------Reservation Procedures
----------------------------------------------------------------------------------------
IF object_id('New_Reservation') IS NULL
 EXEC ('create procedure New_Reservation as select 1')
 GO

Alter Procedure New_Reservation
 @C_ID   int,
 @R_ID  int,
 @Start_Time smalldatetime,
 @End_Time smalldatetime
 As
     INSERT INTO  Reservation
          ( 
            C_ID                   ,
            R_ID                   ,
			StartTime                  ,
			EndTime                                                      
          ) 
     VALUES 
          ( 
            @C_ID                   ,
            @R_ID                   ,
			@Start_Time                  ,
			@End_Time                                    
	    	)
GO
-----------------------------------------------------------------------------------------
IF object_id('Edit_Reservation') IS NULL
 EXEC ('create procedure Edit_Reservation as select 1')
 GO

Alter Procedure Edit_Reservation
   @Res_ID        int,
  @StartTime   smalldatetime,
 @EndTime  smalldatetime
 As
 UPDATE [Reservation]
SET StartTime=@StartTime , EndTime=@EndTime 
WHERE Res_ID=@Res_ID; 
GO
----------------------------------------------------------------------------------------
IF object_id('FULL_Rooms') IS NULL
 EXEC ('create procedure FULL_Rooms as select 1')
 GO

Alter Procedure FULL_Rooms
@R_ID int
AS	
SELECT R_ID
FROM Reservation
where EndTime=NULL AND R_ID=@R_ID;
GO
----------------------------------------------------------------------------------------
IF object_id('Edit_User') IS NULL
 EXEC ('create procedure Edit_User as select 1')
 GO

Alter Procedure Edit_User
@U_ID varchar(255),
@Password varchar(255),
@Salary money,
@type varchar(255)
AS	
UPDATE [USER]
Set PW=@Password , Salary=@Salary , type=@type
where U_ID=@U_ID ;
GO
----------------------------------------------------------------------------------------
IF object_id('LoginU') IS NULL
 EXEC ('create procedure LoginU as select 1')
 GO

Alter Procedure LoginU
@ID varchar(255),
@PW varchar(255)
AS
SELECT [type] from [User] where U_ID=@ID and PW=@PW;
GO
----------------------------------------------------------------------------------------
IF object_id('NewExpense') IS NULL
 EXEC ('create procedure NewExpense as select 1')
 GO

Alter Procedure NewExpense
@Descr varchar(255),
@Cost money,
@DateT smalldatetime
AS
INSERT INTO  [Expense]
          ( 
            Description                   ,
            Paid                     ,
            ExpenseTime                                            
          ) 
     VALUES 
          ( 
            @Descr                   ,
            @Cost                     ,
            @DateT                                    
	    	)
go
----------------------------------------------------------------------------------------------
IF object_id('New_Room_Catering') IS NULL
 EXEC ('create procedure New_Room_Catering as select 1')
 GO

ALTER Procedure New_Room_Catering
@Res_ID int,
@F_ID int,
@Q int
AS	
Insert into Room_Catering
(
Res_ID,
F_ID ,
Quantity
)
VALUES
(
@Res_ID,
@F_ID,
@Q
)

Update Catering
set Stock=Stock- @Q
where F_ID=@F_ID;
go
-------------------------------------------------------------------------------------------------------------------
IF object_id('Catering_Price') IS NULL
 EXEC ('create procedure Catering_Price as select 1')
 GO
ALTER Procedure Catering_Price
 @Name   varchar(255),
 @New_Price money
 As
 UPDATE [Catering]
SET Price=@New_Price
WHERE Name=@Name; 
Go
---------------------------------------------------------------------------------------------------------------------
IF object_id('GetReservationsProfit') IS NULL
 EXEC ('create procedure GetReservationsProfit as select 1')
 GO
ALTER Procedure GetReservationsProfit
@StartTime smalldatetime
AS
select Room.R_ID ,sum(((Room.Price/60)*DATEDIFF(minute,Reservation.StartTime, Reservation.EndTime))) As Profit 	
From Room
INNER JOIN Reservation on Room.R_ID=Reservation.R_ID
where Reservation.EndTime is NOT NULL and Reservation.StartTime>=@StartTime
Group by Room.R_ID
GO
---------------------------------------------------------------------------------------------------------------------
IF object_id('GetCateringProfit') IS NULL
 EXEC ('create procedure GetCateringProfit as select 1')
 GO
ALTER Procedure GetCateringProfit
@StartTime smalldatetime
AS
select Catering.Name,sum(Catering.Price*Room_Catering.Quantity) As profit 
from Room_Catering
Inner Join Catering on Room_Catering.F_ID=Catering.F_ID
Inner Join Reservation on Reservation.Res_ID=Room_Catering.Res_ID
where Reservation.EndTime is NOT NULL and Reservation.StartTime>=@StartTime
Group by Catering.Name
Go
------------------------------------------------------------------------------------------------------------------------
IF object_id('GetCateringPaid') IS NULL
 EXEC ('create procedure GetCateringPaid as select 1')
 GO
ALTER Procedure GetCateringPaid
@StartTime smalldatetime
AS
select Catering.Name,sum(Catering.Cost*Room_Catering.Quantity) As profit 
from Room_Catering
Inner Join Catering on Room_Catering.F_ID=Catering.F_ID
Inner Join Reservation on Reservation.Res_ID=Room_Catering.Res_ID
where Reservation.EndTime is NOT NULL and Reservation.StartTime>=@StartTime
Group by Catering.Name
Go
------------------------------------------------------------------------------------------------------------------------
IF object_id('GetExpensePaid') IS NULL
 EXEC ('create procedure GetExpensePaid as select 1')
 GO
ALTER Procedure GetExpensePaid
@StartTime smalldatetime
AS
select Expense.Description ,sum(paid)as Paid
from Expense
where ExpenseTime >=@StartTime
group by Expense.Description
Go
-----------------------------------------------------------------------------------------------------------------------
