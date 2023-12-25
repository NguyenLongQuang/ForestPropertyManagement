drop database ForestResources
go

create database ForestResources
go

use ForestResources
go

create table BusinessStructure
( Id int primary key identity(1, 1)
, FormerName nvarchar(50)
, Info nvarchar(500)
)
go

insert into BusinessStructure values (N'Doanh nghiệp tư nhân', N'Doanh nghiệp tư nhân')
insert into BusinessStructure values (N'Công ty trách nhiệm hữu hạn', N'Công ty trách nhiệm hữu hạn')
insert into BusinessStructure values (N'Công ty trách nhiệm hữu hạn một thành viên', N'Công ty trách nhiệm hữu hạn một thành viên')
insert into BusinessStructure values (N'Công ty cổ phần', N'Công ty cổ phần')
insert into BusinessStructure values (N'Công ty hợp danh', N'Công ty hợp danh')

create table ProductionMethod
( Id int primary key identity(1, 1)
, FormerName nvarchar(50)
, Info nvarchar(500)
)
go

insert into ProductionMethod values (N'Loại hình sản xuất 1', N'Info')
insert into ProductionMethod values (N'Loại hình sản xuất 2', N'Info')
insert into ProductionMethod values (N'Loại hình sản xuất 3', N'Info')

create table District
( Id int primary key identity(1, 1)
, FormerName nvarchar(50)
, Info nvarchar(500)
)
go

insert into District values (N'Quận 1', N'Info')
insert into District values (N'Quận 2', N'Info')
insert into District values (N'Quận 3', N'Info')

create table Facility
( Id int primary key identity(1, 1)
, FormerName nvarchar(50)
, DistrictId int foreign key references District(Id)
, BusinessStructureId int foreign key references BusinessStructure(Id)
, ProductionMethodId int foreign key references ProductionMethod(Id)
)
go

create table Category
( Id int primary key identity(1, 1)
, FormerName nvarchar(50)
)
go

create table Offering
( FacilityId int foreign key references Facility(Id)
, CategoryId int foreign key references Category(Id)
)
go

create table Product
( Id int primary key identity(1, 1)
, FormerName nvarchar(50)
, Info nvarchar(500)
, CategoryId int foreign key references Category(Id) 
)
go

create table ProductReport
( Id int primary key identity(1, 1)
, ReferenceId int foreign key references Product(Id)
, Number int
, RecordMonth int
, RecordYear int
)	
go
create table FacilityReport
( Id int primary key identity(1, 1)
, ReferenceId int foreign key references Facility(Id)
, Number int
, RecordMonth int
, RecordYear int
)	
go
 
insert into Facility values (N'Cơ sở A', 1, 3, 2)
insert into Facility values (N'Cơ sở B', 2, 4, 2)
insert into Facility values (N'Cơ sở C', 2, 2, 1)

insert into Category values (N'Chế biến gỗ')
insert into Category values (N'Cây giống')
insert into Category values (N'Lưu trữ sinh vật rừng')

insert into Offering values (1 , 1)
insert into Offering values (2 , 1)
insert into Offering values (3 , 2)
insert into Offering values (1 , 2)
insert into Offering values (2 , 3)
insert into Offering values (3 , 3)

create view FacilityAddress as select
C.Id as CategoryId, F.FormerName as FacilityName, D.FormerName as DistrictName
from Facility F
join Offering O on F.Id = O.FacilityId
join Category C on O.CategoryId = C.Id
join District D on F.DistrictId = D.Id
