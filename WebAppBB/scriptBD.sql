create database bb
go
use bb
go

create table categories(
categoryid int primary key identity,
description varchar(70) not null
)
insert into categories(description)
values('Marketing'),('Products'),('Intentions')
go
create table subcategories(
subcategoryid int primary key identity,
description varchar(70) not null,
categoryid int,
featured_header bit default 0,
featured_banner bit default 0,
featured_titles bit default 0,
icon varchar(100),
thumbnail varchar(100),
main_description text,
main_headline varchar(150),
subcategory_description text,
active bit,
static_subcategoryid bit
)
insert into subcategories(description,categoryid,active)
values('Flyers',1,1),('Brochures',1,1),('Social Media',1,1)
,('Flags',2,1),('Posters',2,1),('Sphere Marketing',3,1)
go
create table interiorcategories(
interiorcategoryid int primary key identity,
description varchar(70) not null,
subcategoryid int,
categoryid int,
use_url bit,
thumbnail varchar(100),
main_description text,
subcategory_headline text,
subcategory_description text,
active bit
)

insert into interiorcategories(description,subcategoryid,active)
values('Listing',1,1),('Individual',2,1),('Facebook',3,1)
,('Flags Int',4,1),('Posters Int',5,1),('Sphere Int',6,1)
go
create table posts(
postId int primary key identity,
title varchar(255) not null,
url varchar(75) null,
subtitle varchar(255) null,
headline varchar(255) not null,
author varchar(255) null,
document_date datetime null,
teaser varchar(5000) null,
teaser_thumbnail varchar(500) null,
use_only_homepage bit null,
main_text text null,
meta_description text null,
image_span bit,
image_align bit,
image_wrap bit,
wrap_text bit null,
display int,
homepage int,
category_landing int,
created datetime default getdate(),
modified datetime default getdate()
)

create table postscategories(
postcategoriesId int primary key identity,
postId int references posts(postid),
categoryid int ,
subcategoryid int,
interiorcategoryid int,
active bit default 1
)


