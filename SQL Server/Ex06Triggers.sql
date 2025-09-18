create table Customer(
	CstId int primary key identity(1,1),
	CstName varchar(50) not null,
	CstAddress varchar(100) not null,
	BillDate date  default GetDate(),
	BillAmount money
)

create table Customer_Audit(
	Id int primary key identity(1,1),
	description varchar(200) not null
)

--------------------------Insertion Trigger---------------------------
create trigger OnNewCustomer
on Customer
for insert
as
begin
	declare @id int
	select @id=CstId from inserted--inserted is a predefined object that contains the data of the inserted record
	declare @desc varchar(200)
	declare @name varchar(100)
	select @name=CstName from inserted
	set @desc='Customer with Id '+Cast(@id as varchar(4))+' and name '+ @name +' inserted succesfull on ' +dbo.CreateDate(GetDate())
	insert into Customer_Audit values(@desc)
end


insert into Customer(CstName,CstAddress,BillAmount) values ('Aditya','Bangalore',800)

select * from Customer_Audit

---------------------Updation Trigger--------------------
Create trigger OnUpdateCustomer
On Customer
After update
AS
BEGIN
DECLARE @id int
 select @id = CstId from inserted 
 Declare @oldName varchar(50)
 Declare @newName varchar(50)
 Select @oldName = CstName from deleted
 Select @newName = CstName from inserted
 Insert into Customer_Audit values('' + 'Customer with id ' + Cast(@id as varchar(4)) + ' has updated name from ' + @oldName + ' to ' + @newName + 'successfully on ' + dbo.CreateDate(GetDate()))
END

update customer
set CstName = 'Besos' where CstName = 'Aditya'

Select * from Customer_Audit

--------------------------------Deletion Trigger--------------------------------
ALTER TRIGGER OnDeleteCustomer
ON Customer
AFTER DELETE
AS
BEGIN
    DECLARE @id INT;
    DECLARE @name VARCHAR(50)
    DECLARE @message VARCHAR(500)
    SELECT @id = CstId FROM deleted
    SELECT @name = CstName FROM deleted
    SET @message = 'Customer with id ' + CAST(@id AS VARCHAR(10)) +' and name ' + @name +' was deleted on ' + dbo.CreateDate(GetDate())
    INSERT INTO Customer_Audit (description) VALUES (@message)
END

DELETE FROM Customer WHERE CstName = 'Aditya'
SELECT * FROM Customer_Audit
SELECT * FROM Customer

