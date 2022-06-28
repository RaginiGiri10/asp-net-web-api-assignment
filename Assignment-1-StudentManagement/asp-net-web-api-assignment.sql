--create database StudentDB
create database StudentDB
go
use StudentDB
go
--create table Student
create table Student(
Id int not null primary key identity(100,1),
[Name] varchar(40),
Age int,
Marks int
);
--insert into Student table
insert into Student values('Disha',23,80),('Monisha',23,55),('Oyshee',24,75)
go
select * from Student