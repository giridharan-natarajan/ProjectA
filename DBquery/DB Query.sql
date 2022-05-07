create database Clicmanagement
go
---Table for user login---
Create table Userlogin(
Username char(20),
Firstname varchar(20),
Lastname varchar(20),
Paasword varchar(20)
)
Select * from userlogin
drop table userlogin 

----Doctor adding table--
Create table Doctor(
Doctorid int identity(100,1),
Firstname varchar(20),
Lastname varchar(20),
Gender varchar(1),
Specialization char(30),
Visitinghours varchar(20)
)
select * from Doctor
drop table Doctortable


---Table for patient---
create table Patient(
PatientId int identity(1001,1),
Firstname varchar(20),
Lastname varchar(20),
Gender varchar(1),
Dateofbirth varchar(10),
Age int)
select * from Patient

---Scheduling appointment--
create table scheduledoctor(
PatientId int,
Doctorname Varchar(20),
Visitdate date,
Specialization Char(30),
Visitinghours varchar(20)
)
select * from scheduledoctor
drop table scheduledoctor


use Clicmanagement
go
---doctor procedure--
create proc Doctoradd
@fname varchar(20),
@lname varchar(20),
@gen varchar(1),
@spec char(20),
@vis varchar(10)
as
insert into Doctor(Firstname,Lastname,Gender,Specialization,Visitinghours)
 values(@fname,@lname,@gen,@spec,@vis)
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