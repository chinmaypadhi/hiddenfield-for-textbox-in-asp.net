alter login sa with password ='or22e1856'





create database hidden
use hidden


create table hiddenfield(id int identity primary key not null,name varchar(46),city varchar(45))


alter procedure disp1 
@id int
as
begin
select id,name,city from hiddenfield where id=@id
end

create proc update1 
@id int,
@name varchar(56),
@city varchar(45)
as 
begin
update hiddenfield set name=@name,city=@city where id=@id
end

insert into hiddenfield values('nitish','cuttack')

exec disp1 1

