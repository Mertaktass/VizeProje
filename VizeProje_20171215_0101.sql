

Create Proc [dbo].[VizeProje_CategoryList]
as
select CategoryID,CategoryName,Description from Categories
go
Create Proc [dbo].[VizeProje_CategoryAdd]
@CategoryName nvarchar(20),
@Description nvarchar(max)
as
insert into Categories(CategoryName,[Description]) values (@CategoryName,@Description)
go
Create Proc [dbo].[VizeProje_CategoryUpdate]
@CategoryName nvarchar(20),
@Description nvarchar(100),
@CategoryID int
as
update Categories set CategoryName=@CategoryName,[Description]=@Description where CategoryID=@CategoryID
go
Create Proc [dbo].[VizeProje_CategoryDelete]
@CategoryID int
as
delete Categories where CategoryID=@CategoryID
go
---------------------------------------------------------
Create Proc [dbo].[VizeProje_CustomerList]
as
select * from Customers
go
Create Procedure [dbo].[VizeProje_CustomerAdd]
@CustomerID nvarchar(10),
@CompanyName nvarchar(40),
@ContactName nvarchar(30),
@ContactTitle nvarchar(30),
@Address nvarchar(60),
@City nvarchar(20),
@Region nvarchar(20),
@PostalCode nvarchar(10),
@Country nvarchar(15),
@Phone nvarchar(24),
@Fax nvarchar(24)
as
insert into Customers(
CustomerID,
CompanyName,
ContactName,
ContactTitle,
[Address],
City,
Region,
PostalCode,
Country,
Phone,
Fax
)values(
@CustomerID,
@CompanyName,
@ContactName,
@ContactTitle,
@Address,
@City,
@Region,
@PostalCode,
@Country,
@Phone,
@Fax
)
go
Create Proc [dbo].[VizeProje_CustomerDelete]
@CustomerID nchar(10)
as
delete Customers where CustomerID=@CustomerID
go
Create Procedure VizeProje_CustomerUpdate
@CustomerID nchar(10),
@CompanyName nvarchar(40),
@ContactName nvarchar(30),
@ConctactTitle nvarchar(30),
@Address nvarchar(60),
@City nvarchar(15),
@Region nvarchar(15),
@PostalCode nvarchar(10),
@Country nvarchar(15),
@Phone nvarchar(24),
@Fax nvarchar(24)
as
Update Customers set CompanyName = @CompanyName,
ContactName = @ContactName,
ContactTitle = @ConctactTitle,
[Address] = @Address,
City = @City,
Region = @Region,
PostalCode = @PostalCode,
Country = @Country,
Phone = @Phone,
Fax = @Fax
where CustomerID = @CustomerID
----------------------------------------------------------
go
Create Proc VizeProje_EmployeesList
as
select 
E.EmployeeID,
E.LastName,
E.FirstName,
E.Title,
E.TitleOfCourtesy,
E.BirthDate,
E.HireDate,
E.[Address],
E.City,
E.Region,
E.PostalCode,
E.Country,
E.HomePhone,
E.Extension,
E.Notes,
E.ReportsTo
from Employees E
go
Create Proc VizeProje_EmployeesAdd
@EmployeeID int,
@LastName nvarchar(20),
@FirstName nvarchar(20),
@Title nvarchar(50),
@TitleOfCourtesy nvarchar(20),
@BirthDate DateTime,
@HireDate DateTime,
@Address nvarchar(50),
@City nvarchar(20),
@Region nvarchar(10),
@PostalCode nvarchar(15),
@Country nvarchar(15),
@HomePhone nvarchar(24),
@Extension nvarchar(5),
@Notes ntext,
@ReportsTo int
As
insert into Employees(
EmployeeID,
LastName,
FirstName,
Title,
TitleOfCourtesy,
BirthDate,
HireDate,
[Address],
City,
Region,
PostalCode,
Country,
HomePhone,
Extension,
Notes,
ReportsTo

)values(
@EmployeeID,
@LastName,
@FirstName,
@Title,
@TitleOfCourtesy,
@BirthDate,
@HireDate,
@Address,
@City,
@Region,
@PostalCode,
@Country,
@HomePhone,
@Extension,
@Notes,
@ReportsTo

)
Go
Create Proc [dbo].[VizeProje_EmployeeDelete]
@EmployeeID int
as
delete Employees where EmployeeID=@EmployeeID
go 

create Proc VizeProje_EmployeesUpdate
@EmployeeID int,
@LastName nvarchar(20),
@FirstName nvarchar(20),
@Title nvarchar(50),
@TitleOfCourtesy nvarchar(20),
@BirthDate DateTime,
@HireDate DateTime,
@Address nvarchar(50),
@City nvarchar(20),
@Region nvarchar(10),
@PostalCode nvarchar(15),
@Country nvarchar(15),
@HomePhone nvarchar(24),
@Extension nvarchar(8),
@Notes ntext,
@ReportsTo int
as
Update Employees set 
LastName = @LastName,
FirstName=@FirstName,
Title=@Title,
TitleOfCourtesy=@TitleOfCourtesy,
BirthDate=@BirthDate,
HireDate=@HireDate,
[Address]=@Address,
City=@City,
Region=@Region,
PostalCode=@PostalCode,
Country=@Country,
HomePhone=@HomePhone,
Extension=@Extension,
Notes=@Notes,
ReportsTo=@ReportsTo
where EmployeeID = @EmployeeID

go
Create Proc VizeProje_OrderDetailList
As
Select * From [Order Details]
go
Create Procedure [dbo].[VizeProje_OrderDetailAdd]
@OrderID int,
@ProductID int,
@UnitPrice int,
@Quantity int,
@Discount decimal
as
insert into [Order Details](
OrderID,
ProductID,
UnitPrice,
Quantity,
Discount

)Values(
@OrderID,
@UnitPrice,
@Quantity,
@Discount

)
go
Create Proc [dbo].[VizeProje_OrderDetailDelete]
@OrderID int
as
delete [Order Details] where OrderID=@OrderID
go
Create Procedure [dbo].[VizeProje_OrderDetailUpdate]
@OrderID int,
@ProductID int,
@UnitPrice int,
@Quantity int,
@Discount decimal
as
Update [Order Details] set
ProductID=@ProductID,
UnitPrice=@UnitPrice,
Quantity=@Quantity,
Discount=@Discount
where OrderID=@OrderID
go
Create Proc VizeProje_OrderList
as
Select * From Orders

go
Create Procedure [dbo].[VizeProje_OrderAdd]
@OrderID int,
@CustomerID nchar(5),
@EmloyeeID int,
@OrderDate datetime,
@RequidredDate datetime,
@ShippedDate datetime,
@shipVia int,
@Freight money,
@ShipName nvarchar (40),
@ShipAddress nvarchar(60),
@ShipCity nvarchar(15),
@ShipRegion nvarchar(15),
@ShipPostalCode nvarchar(10),
@ShipCountry nvarchar (15)
as
insert into Orders (
OrderID,
CustomerID,
EmployeeID,
OrderDate,
RequiredDate,
ShippedDate,
ShipVia,
Freight,
ShipName,
ShipAddress,
ShipCity,
ShipRegion,
ShipPostalCode,
ShipCountry
)values(
@OrderID,
@CustomerID,
@EmloyeeID,
@OrderDate,
@RequidredDate,
@ShippedDate,
@shipVia,
@Freight,
@ShipName,
@ShipAddress,
@ShipCity,
@ShipRegion,
@ShipPostalCode,
@ShipCountry
)
go
Create Proc [dbo].[VizeProje_OrderDelete]
@OrderID int
as
delete Orders where OrderID=@OrderID
go
Create Procedure [dbo].[VizeProje_OrderUpdate]
@OrderID int,
@CustomerID nchar(5),
@EmloyeeID int,
@OrderDate datetime,
@RequidredDate datetime,
@ShippedDate datetime,
@shipVia int,
@Freight money,
@ShipName nvarchar (40),
@ShipAddress nvarchar(60),
@ShipCity nvarchar(15),
@ShipRegion nvarchar(15),
@ShipPostalCode nvarchar(10),
@ShipCountry nvarchar (15)
as
Update Orders set 
CustomerID=@CustomerID,
EmployeeID=@EmloyeeID,
OrderDate=@OrderDate,
RequiredDate=@RequidredDate,
ShippedDate=@ShippedDate,
ShipVia=@shipVia,
Freight=@Freight,
ShipName=@ShipName,
ShipAddress=@ShipAddress,
ShipCity=@ShipCity,
ShipRegion=@ShipRegion,
ShipPostalCode=@ShipPostalCode,
ShipCountry=@ShipCountry
where OrderID=@OrderID

go
----------------------------------------------------------
Create Proc VizeProje_ProductList
as
Select * From Products
go
Create Procedure [dbo].[VizeProje_ProductsAdd]
@ProductID int,
@ProductName nvarchar(40),
@SupplierID int,
@CategoryID int,
@QuantityPerUnit nvarchar(20),
@UnitPrice money,
@UnitInStock smallint,
@UnitsOnOrder smallint,
@ReorderLevel smallint,
@Discontinued bit
as
insert into Products(
ProductID,
ProductName,
SupplierID,
CategoryID,
QuantityPerUnit,
UnitPrice,
UnitsInStock,
UnitsOnOrder,
ReorderLevel,
Discontinued
)Values(
@ProductID,
@ProductName,
@SupplierID,
@CategoryID,
@QuantityPerUnit,
@UnitPrice,
@UnitInStock,
@UnitsOnOrder,
@ReorderLevel,
@Discontinued
)
go
Create Proc [dbo].[VizeProje_ProductDelete]
@ProductID int
as
delete Products where ProductID=@ProductID
go
Create Procedure [dbo].[VizeProje_ProductUpdate]
@ProductID int,
@ProductName nvarchar(40),
@SupplierID int,
@CategoryID int,
@QuantityPerUnit nvarchar(20),
@UnitPrice money,
@UnitInStock smallint,
@UnitsOnOrder smallint,
@ReorderLevel smallint,
@Discontinued bit
as
Update Products Set
ProductName=@ProductName,
SupplierID=@SupplierID,
CategoryID=@CategoryID,
QuantityPerUnit=@QuantityPerUnit,
UnitPrice=@UnitPrice,
UnitsInStock=@UnitInStock,
UnitsOnOrder=@UnitsOnOrder,
ReorderLevel=@ReorderLevel,
Discontinued=@Discontinued
where ProductID=@ProductID
go
-----------------------------------------------------------
Create Proc VizeProje_ShippersList
as
Select * From Shippers
go
Create Procedure [dbo].[VizeProje_ShippersAdd]
@ShipperID int,
@CompanyName nvarchar (40),
@Phone nvarchar(24)
as
insert into Shippers(
ShipperID,
CompanyName,
Phone
)values (
@ShipperID,
@CompanyName,
@Phone
)
go
Create Proc [dbo].[VizeProje_ShipperDelete]
@ShipperID int
as
delete Shippers where ShipperID=@ShipperID
go
Create Procedure [dbo].[VizeProje_ShipperUpdate]
@ShipperID int,
@CompanyName nvarchar (40),
@Phone nvarchar(24)
as
Update Shippers set
CompanyName=@CompanyName,
Phone=@Phone
where ShipperID=@ShipperID
go
Create Proc VizeProje_SupplierList
as
Select * From Suppliers