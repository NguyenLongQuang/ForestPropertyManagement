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
, EstablishedDate datetime
, DissolvedDate datetime
, DistrictId int foreign key references District(Id)
, BusinessStructureId int foreign key references BusinessStructure(Id)
)
go

insert into Facility values (N'Cơ sở A', DATEFROMPARTS(2000, 12, 1), DATEFROMPARTS(2050, 12, 1), 1, 3)
insert into Facility values (N'Cơ sở B', DATEFROMPARTS(2023, 12, 1), DATEFROMPARTS(2073, 12, 1), 2, 4)
insert into Facility values (N'Cơ sở C', DATEFROMPARTS(2023, 6, 1), DATEFROMPARTS(2073, 6, 1), 2, 2)

create table Category
( Id int primary key identity(1, 1)
, FormerName nvarchar(50)
)
go

insert into Category values (N'Cây giống')
insert into Category values (N'Chế biến gỗ')
insert into Category values (N'Lưu trữ sinh vật rừng')

create table Product
( Id int primary key identity(1, 1)
, FormerName nvarchar(50)
, Info nvarchar(500)
, CategoryId int foreign key references Category(Id) 
)
go

insert into Product values (N'Cây chanh', N'đang cập nhật', 1)
insert into Product values (N'Cây bưởi', N'đang cập nhật', 1)
insert into Product values (N'Cây chuối', N'đang cập nhật', 1)
insert into Product values (N'Cây đào', N'đang cập nhật', 1)
insert into Product values (N'Cây quất', N'đang cập nhật', 1)

insert into Product values (N'Ván ép', N'đang cập nhật', 2)
insert into Product values (N'Gỗ đặc', N'đang cập nhật', 2)
insert into Product values (N'Ván sợi', N'đang cập nhật', 2)
insert into Product values (N'Ván dăm', N'đang cập nhật', 2)
insert into Product values (N'Gỗ nhiều lớp', N'đang cập nhật', 2)


insert into Product values (N'Hươu', N'đang cập nhật', 3)
insert into Product values (N'Gấu', N'đang cập nhật', 3)
insert into Product values (N'Hổ', N'đang cập nhật', 3)
insert into Product values (N'Sư tử', N'đang cập nhật', 3)
insert into Product values (N'Báo', N'đang cập nhật', 3)

create table Offering
( AId int foreign key references Facility(Id)
, BId int foreign key references Product(Id)
)
go

insert into Offering values (1 , 1)
insert into Offering values (1 , 2)
insert into Offering values (1 , 3)
insert into Offering values (1 , 4)
insert into Offering values (1 , 5)
insert into Offering values (1 , 6)
insert into Offering values (1 , 7)

insert into Offering values (2 , 1)
insert into Offering values (2 , 2)
insert into Offering values (2 , 6)
insert into Offering values (2 , 7)
insert into Offering values (2 , 8)
insert into Offering values (2 , 9)
insert into Offering values (2 , 10)

insert into Offering values (3 , 1)
insert into Offering values (3 , 2)
insert into Offering values (3 , 3)
insert into Offering values (3 , 4)
insert into Offering values (3 , 5)
insert into Offering values (3 , 11)
insert into Offering values (3 , 12)
insert into Offering values (3 , 13)
insert into Offering values (3 , 14)
insert into Offering values (3 , 15)


create table ProductReport
( Id int primary key identity(1, 1)
, ReferenceId int foreign key references Product(Id)
, Number int
, RecordDate datetime
)	
go

insert into ProductReport values (11, 100, DATEFROMPARTS(2023, 1, 1))
insert into ProductReport values (11, 13, DATEFROMPARTS(2023, 2, 1))
insert into ProductReport values (11, -10, DATEFROMPARTS(2023, 3, 1))
insert into ProductReport values (11, 10, DATEFROMPARTS(2023, 4, 1))
insert into ProductReport values (11, 2, DATEFROMPARTS(2023, 5, 1))

insert into ProductReport values (12, 500, DATEFROMPARTS(2023, 1, 1))
insert into ProductReport values (12, 11, DATEFROMPARTS(2023, 2, 1))
insert into ProductReport values (12, -80, DATEFROMPARTS(2023, 3, 1))
insert into ProductReport values (12, 10, DATEFROMPARTS(2023, 4, 1))
insert into ProductReport values (12, 2, DATEFROMPARTS(2023, 5, 1))

insert into ProductReport values (13, 150, DATEFROMPARTS(2023, 1, 1))
insert into ProductReport values (13, 13, DATEFROMPARTS(2023, 2, 1))
insert into ProductReport values (13, -10, DATEFROMPARTS(2023, 3, 1))
insert into ProductReport values (13, 10, DATEFROMPARTS(2023, 4, 1))
insert into ProductReport values (13, 2, DATEFROMPARTS(2023, 5, 1))

insert into ProductReport values (14, 300, DATEFROMPARTS(2023, 1, 1))
insert into ProductReport values (14, -50, DATEFROMPARTS(2023, 2, 1))
insert into ProductReport values (14, -10, DATEFROMPARTS(2023, 3, 1))
insert into ProductReport values (14, 10, DATEFROMPARTS(2023, 4, 1))
insert into ProductReport values (14, 2, DATEFROMPARTS(2023, 5, 1))

insert into ProductReport values (15, 600, DATEFROMPARTS(2023, 1, 1))
insert into ProductReport values (15, -10, DATEFROMPARTS(2023, 2, 1))
insert into ProductReport values (15, -100, DATEFROMPARTS(2023, 3, 1))
insert into ProductReport values (15, 10, DATEFROMPARTS(2023, 4, 1))
insert into ProductReport values (15, 2, DATEFROMPARTS(2023, 5, 1))



--create view CategoryFacility as select distinct
--p.CategoryId as CategoryId, F.*
--from Facility F
--join Offering O on F.Id = O.AId
--join Product P on O.BId = P.Id;

--create view FacilityAddress as select
--C.Id as CategoryId, F.FormerName as FacilityName, D.FormerName as DistrictName
--from Facility F
--join CategoryFacility CF on F.Id = CF.Id
--join Category C on CF.CategoryId = C.Id
--join District D on F.DistrictId = D.Id;

--create view FacilityProduct as select
--F.Id as FacilityId, P.*
--from Facility F
--join Offering O on F.Id = O.AId
--join Product P on O.BId = P.Id;


