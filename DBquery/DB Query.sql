create database Clicmanagement
go
---Table for user login---
Create table Userlogin(
Username char(20),
Firstname varchar(20),
Lastname varchar(20),
Paasword varchar(20)
)
insert into Userlogin values('Krishna12','Krishna','Moorthy','12345')
Select * from Userlogin
drop table Userlog 
TRUNCATE TABLE  Userlogin

----Doctor adding table--
Create table Doctortab(
Doctorid int identity(100,1),
Firstname varchar(20),
Lastname varchar(20),
Gender varchar(1),
Specialization char(30),
Visitinghours varchar(20),
Timings varchar(10)
)
insert into Doctortab values()
select * from Doctortab
drop table Doctor
TRUNCATE TABLE  Doctortab

---Table for patient---
create table Patient(
PatientId int identity(1001,1),
Firstname varchar(20),
Lastname varchar(20),
Gender varchar(1),
Dateofbirth varchar(10),
Age int)
select * from Patient
drop table Patient
truncate table Patient

---Scheduling appointment--
create table Scheduledoc
(
AppointmentId int identity(1,1),
PatientID int,
Specializations varchar(30),
DoctorName varchar(20),
VisitDate varchar(20),
AppointmentTime varchar(10)
)
select * from Scheduledoc
drop table Scheduledoc

truncate table Scheduledoc

---doctor procedure--
create proc Doctoradd
@fname varchar(20),
@lname varchar(20),
@gen varchar(1),
@spec char(20),
@vis varchar(10),
@tim varchar(10)
as
insert into Doctortab(Firstname,Lastname,Gender,Specialization,Visitinghours,Timings)
 values(@fname,@lname,@gen,@spec,@vis,@tim)
 exec Doctoradd 'Giri','dharan','M','Gynacology','1-2pm'
 drop proc Doctoradd

 ---patient procedure--
 create proc Patientadd
@finame varchar(20),
@laname varchar(20),
@gend varchar(1),
@Dob char(20),
@age int
as
insert into Patient(Firstname,Lastname,Gender,Dateofbirth,Age)
 values(@finame,@laname,@gend,@Dob,@age)
 exec Patientadd
 drop proc Patientadd

 ---checkuser--
 create proc ChkUsr
@User varchar(20),
@Pass varchar(10)
as
select*from Userlogin   where Username like @User and Paasword=@Pass
drop proc ChkUsr

--Get appointment--
create proc GetAppmnt
@patid int,
@spec varchar(20),
@doctor varchar(20),
@vd varchar(20),
@at varchar(20)
as 
insert into Scheduledoc (PatientID,Specializations,DoctorName,VisitDate,AppointmentTime)
 values(@patid,@spec,@doctor,@vd,@at) 
 exec GetAppmnt
 drop proc GetAppmnt

 --delete procedure--
create proc Delsch
@id int
as
delete from Scheduledoc where AppointmentId = @id
drop proc Delsch



create proc GetAppmnts
as 
select AppointmentId,PatientID,Specializations,DoctorName,VisitDate,AppointmentTime
from Scheduledoc

create proc Getdoctor
as 
select Doctorid ,Firstname,Lastname,Gender,Specialization,Visitinghours,Timings
From Doctortab
drop proc GetDoctor
--deletedoctor
create proc Deletedocter
@did int
as
delete from Doctortab where Doctorid = @did

Deletedocter 100