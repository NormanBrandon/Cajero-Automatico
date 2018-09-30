create database ProyectoBanfi
use ProyectoBanfi

--Tabla Cliente
create table Cliente(
Nom_c char(50),
Nip1_c int,
constraint pk_cc primary key (Nom_c)
)

insert into Cliente values ('Juan Perez',673245)
insert into Cliente values ('Pedro Millan',785342)
insert into Cliente values ('Bill Gates',989876)

select*from Cliente

--Tabla Tarjeta de credito
create table TarjetaC(
Num_tc bigint,
Cred_tc bigint,
Nip2_tc int,
Cvv_tc smallint,
Nom_c2 char(50),
constraint pk_ctc primary key (Num_tc),
constraint fk_ftc foreign key (Nom_c2) references Cliente (Nom_c)
)

insert into TarjetaC values (8978475632847297,6000,673245,375,'Juan Perez')
insert into TarjetaC values (7584765928374657,20000,364588,987,'Pedro Millan')
insert into TarjetaC values (1987987436253456,3000000,542114,122, 'Bill Gates')

select*from TarjetaC

delete from TarjetaC

--Tabla Tarjeta de debito
create table TarjetaD(
Num_td bigint,
Sal_td bigint,
Nip3_td int,
Cvv2_td smallint,
Nom_c3 char(50),
constraint pk_ctd primary key (Num_td),
constraint fk_ftd foreign key (Nom_c3) references Cliente (Nom_c)
)

insert into TarjetaD values (2453654865029387,2500,253454,675,'Juan Perez')
insert into TarjetaD values (7362873645123209,8000,133243,788,'Pedro Millan')
insert into TarjetaD values (2435877835546376,10000000,567655,999,'Bill Gates')

select*from TarjetaD



