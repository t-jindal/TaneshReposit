create table ProductDetails
(
productId int identity primary key,
productName varchar(30),
expDate DateTime,
price bigint
)

create proc usp_insert
(
@prodName varchar(30),
@expDate DateTime,
@price bigint
)
As
begin
insert into ProductDetails values (@prodName,@expDate,@price)
END

create proc display
as
begin
select * from [dbo].[ProductDetails]
end

exec display

