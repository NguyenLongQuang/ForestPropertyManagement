drop database ForestResources
go

create database ForestResources
go

use ForestResources
go


create table Facility
( Id int primary key identity(1, 1)
, FormerName nvarchar(50)
)
go

create table Category
( Id int primary key identity(1, 1)
, FormerName nvarchar(50)
)
go

create table Offering
( FacilityId int foreign key references Facility(Id)
, CatagoryId int foreign key references Category(Id)
)
go

create table Product
( Id int primary key identity(1, 1)
, ReferenceId int foreign key references Category(Id)
, FormerName nvarchar(50)
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

create table BusinessStructure
( Id int primary key identity(1, 1)
, ReferenceId int foreign key references Facility(Id) 
, FormerName nvarchar(50)
)
go

create table ProductionMethod
( Id int primary key identity(1, 1)
, ReferenceId int foreign key references Facility(Id) 
, FormerName nvarchar(50)
)
go

create table District
( Id int primary key identity(1, 1)
, ReferenceId int foreign key references Facility(Id)
, FormerName nvarchar(50)
)
go
 
insert into Facility values (N'Cơ sở A')
insert into Facility values (N'Cơ sở B')
insert into Facility values (N'Cơ sở C')

insert into Category values (N'Chế biến gỗ')
insert into Category values (N'Cây giống')
insert into Category values (N'Lưu trữ sinh vật rừng')

insert into Offering (FacilityId, CatagoryId)
select Id, (select Id from Category where FormerName = N'Chế biến gỗ')
from Facility
where FormerName in 
( N'Công ty B'
)

insert into Offering (FacilityId, CatagoryId)
select Id, (select Id from Category where FormerName = N'Cây giống')
from Facility
where FormerName in 
( N'Công ty A'
, N'Công ty B'
)

insert into Offering (FacilityId, CatagoryId)
select Id, (select Id from Category where FormerName = N'Lưu trữ sinh vật rừng')
from Facility
where FormerName in 
( N'Công ty C'
, N'Công ty A'
)

