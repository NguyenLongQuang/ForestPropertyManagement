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

insert into Facility (FormerName) values (N'GreenHarbor Woodworks')
insert into Facility (FormerName) values (N'NatureGrow Nurseries')
insert into Facility (FormerName) values (N'WildlifeCare Conservatories')

insert into Category (FormerName) values (N'Wood processing')
insert into Category (FormerName) values (N'Seedling')
insert into Category (FormerName) values (N'Creature management')

insert into Offering (FacilityId, CatagoryId)
select Id, (select Id from Category where FormerName = N'Wood processing')
from Facility
where FormerName in 
( N'GreenHarbor Woodworks'
)

insert into Offering (FacilityId, CatagoryId)
select Id, (select Id from Category where FormerName = N'Seedling')
from Facility
where FormerName in 
( N'NatureGrow Nurseries'
)

insert into Offering (FacilityId, CatagoryId)
select Id, (select Id from Category where FormerName = N'Creature management')
from Facility
where FormerName in 
( N'WildlifeCare Conservatories'
)

