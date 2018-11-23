--Tabla de clientes
CREATE TABLE Clientes(
Numero_cli int,
Nombre_cli varchar(50),
CONSTRAINT pk_ccli PRIMARY KEY(Numero_cli)
);


--Tabla de las tarjetas de credito
CREATE TABLE TarjetaCredito(
Numero_tc varchar(16),
Credito_tc float,    
CONSTRAINT pk_ctc PRIMARY KEY(Numero_tc)
);

--Tabla de las tarjetas de debito
CREATE TABLE TarjetaDebito(
Numero_td varchar(16),
Saldo_td float,
CONSTRAINT pk_ctd PRIMARY KEY(Numero_td)
);


--Tabla para almacenar contraseñas
CREATE TABLE Contraseña(
Numero_ctsa int,
CONSTRAINT pk_cctsa PRIMARY KEY(Numero_ctsa)
);


--Tabla para relacionar los numeros de tarjeta de credito con sus respectivas contraseñas
CREATE TABLE TarjetaCredito_Contraseña(
Numero_tc2 varchar(16),
Numero_ctsa2 int,
CONSTRAINT fk_ftc2 FOREIGN KEY(Numero_tc2) REFERENCES TarjetaCredito(Numero_tc),
CONSTRAINT fk_fctsa2 FOREIGN KEY (Numero_ctsa2) REFERENCES Contraseña(Numero_ctsa)
);


--Tabla para relacionar los numeros de tarjeta de debito con sus respectivas contraseñas
CREATE TABLE TarjetaDebito_Contraseña(
Numero_td2 varchar(16),
Numero_ctsa1 int,
CONSTRAINT fk_ftd2 FOREIGN KEY(Numero_td2) REFERENCES TarjetaDebito(Numero_td),
CONSTRAINT fk_fctsa1 FOREIGN KEY(Numero_ctsa1) REFERENCES Contraseña(Numero_ctsa)
);


--Tabla para relacionar el numero de cliente del banco con su tarjeta de credito
CREATE TABLE Clientes_TarjetaCredito(
Numero_cli1 int,
Numero_tc1 varchar(16),
CONSTRAINT fk_fcli1 FOREIGN KEY(Numero_cli1) REFERENCES Clientes(Numero_cli),
CONSTRAINT fk_ftc1 FOREIGN KEY(Numero_tc1) REFERENCES TarjetaCredito(Numero_tc)
);


--Tabla para relacionar el numero de cliente del banco con su tarjeta de debito
CREATE TABLE Clientes_TarjetaDebito(
Numero_cli2 int,
Numero_td1 varchar(16),
CONSTRAINT fk_fcli2 FOREIGN KEY(Numero_cli2) REFERENCES Clientes(Numero_cli),
CONSTRAINT fk_ftd1 FOREIGN KEY(Numero_td1) REFERENCES TarjetaDebito(Numero_td)
);


--Tabla de empresas
CREATE TABLE Empresas(
Nombre_emp varchar(50),
CONSTRAINT pk_cemp PRIMARY KEY(Nombre_emp)
);


--Tabla para realizar transferencias a empresas
CREATE TABLE Transferencia(
Transferencia_cliente float,
Numero_cli4 int,
Nombre_emp2 varchar(16),
CONSTRAINT pk_ccliente PRIMARY KEY(Transferencia_cliente),
CONSTRAINT fk_fcli4 FOREIGN KEY(Numero_cli4) REFERENCES Clientes(Numero_cli),
CONSTRAINT fk_femp2 FOREIGN KEY(Nombre_emp2) REFERENCES Empresas(Nombre_emp)
);


--Tabla para relacionar a las empresas con sus respectivos clientes
CREATE TABLE Empresas_clientes(
Nombre_emp1 varchar(16),
Numero_cli3 int,
CONSTRAINT fk_femp1 FOREIGN KEY(Nombre_emp1) REFERENCES Empresas(Nombre_emp),
CONSTRAINT fk_fcli3 FOREIGN KEY(Numero_cli3) REFERENCES Clientes(Numero_cli)
);


--Tabla para almacenar los depositos que los clientes pueden realizar
CREATE TABLE Deposito(
Cliente_dep float,
CONSTRAINT pk_cdep PRIMARY KEY(Cliente_dep)
);


--Tabla para relacionar los depositos y transferencias
CREATE TABLE Deposito_Transferencia(
Cliente_dep1 float,
Transferencia_cliente10 float,
CONSTRAINT fk_fdep1 FOREIGN KEY(Cliente_dep1) REFERENCES Deposito(Cliente_dep),
CONSTRAINT fk_fcliente10 FOREIGN KEY(Transferencia_cliente10) REFERENCES Transferencia(Transferencia_cliente)
);



--Insertando empresas existentes
INSERT INTO empresas VALUES('Telmex');
INSERT INTO empresas VALUES('Netflix');
INSERT INTO empresas VALUES('CFE');
INSERT INTO empresas VALUES('SAT');

--Insertando los posibles clientes
INSERT INTO clientes VALUES(1,'Eduardo Marquez');
INSERT INTO clientes VALUES(2,'Norman Saldaña');
INSERT INTO clientes VALUES(3,'Armando Rodriguez');
INSERT INTO clientes VALUES(4,'Enrique Graue');

--Insertando numeros de tarjetas de credito y saldos
INSERT INTO tarjetacredito VALUES('5632908851787856',10000);
INSERT INTO tarjetacredito VALUES('8247592745762994',7999);
INSERT INTO tarjetacredito VALUES('9847619375789138',92763);
INSERT INTO tarjetacredito VALUES('1234085908236784',43426);

--Insertando numeros de tarjetas de debito y creditos
INSERT INTO tarjetadebito VALUES('1242754383559995',10000);
INSERT INTO tarjetadebito VALUES('7893462391734713',20000);
INSERT INTO tarjetadebito VALUES('7761272473896356',30000);
INSERT INTO tarjetadebito VALUES('1230974561236348',40000);

--Insertando contraseñas de las tarjetas
INSERT INTO contraseña VALUES(4242);
INSERT INTO contraseña VALUES(2424);
INSERT INTO contraseña VALUES(1111);
INSERT INTO contraseña VALUES(2222);
INSERT INTO contraseña VALUES(3333);
INSERT INTO contraseña VALUES(5555);
INSERT INTO contraseña VALUES(6666);
INSERT INTO contraseña VALUES(7777);

--Insertando relacion de clientes y numeros de tarjetas de credito
INSERT INTO clientes_tarjetacredito VALUES(1,'5632908851787856');
INSERT INTO clientes_tarjetacredito VALUES(2,'8247592745762994');
INSERT INTO clientes_tarjetacredito VALUES(3,'9847619375789138');
INSERT INTO clientes_tarjetacredito VALUES(4,'1234085908236784');

--Insertando relacion de clientes y numeros de tarjetas de debito
INSERT INTO clientes_tarjetadebito VALUES(2,'1242754383559995');
INSERT INTO clientes_tarjetadebito VALUES(1,'7893462391734713');
INSERT INTO clientes_tarjetadebito VALUES(3,'7761272473896356');
INSERT INTO clientes_tarjetadebito VALUES(4,'1230974561236348');

--Insertando relacion de tarjetas de debito y sus respectivas contraseñas
INSERT INTO tarjetadebito_contraseña VALUES('1242754383559995',2424);
INSERT INTO tarjetadebito_contraseña VALUES('7893462391734713',1111);
INSERT INTO tarjetadebito_contraseña VALUES('7761272473896356',2222);
INSERT INTO tarjetadebito_contraseña VALUES('1230974561236348',3333);

--Insertando relacion de tarjetas de credito y sus respectivas contraseñas
INSERT INTO tarjetacredito_contraseña VALUES('5632908851787856',4242);
INSERT INTO tarjetacredito_contraseña VALUES('8247592745762994',5555);
INSERT INTO tarjetacredito_contraseña VALUES('9847619375789138',6666);
INSERT INTO tarjetacredito_contraseña VALUES('1234085908236784',7777);

--Insertando relacion entre los clientes y las empresas
INSERT INTO empresas_clientes VALUES('Telmex',1);
INSERT INTO empresas_clientes VALUES('Netflix',1);
INSERT INTO empresas_clientes VALUES('CFE',1);
INSERT INTO empresas_clientes VALUES('SAT',1);
INSERT INTO empresas_clientes VALUES('Telmex',2);
INSERT INTO empresas_clientes VALUES('Netflix',2);
INSERT INTO empresas_clientes VALUES('CFE',2);
INSERT INTO empresas_clientes VALUES('SAT',2);

--Consultas de contraseñas utilizando numero de tarjeta
SELECT Numero_ctsa2 FROM TarjetaCredito_Contraseña WHERE Numero_tc2=5632908851787856;

SELECT Numero_ctsa1 FROM TarjetaDebito_Contraseña WHERE Numero_td1=1242754383559995;

--Consultas de saldo utilizando numero de tarjeta
SELECT credito_tc FROM tarjetacredito WHERE Numero_tc=5632908851787856;

SELECT  FROM tarjetadebito WHERE Numero_td=1242754383559995;

--Actualizar contraseñas utilizando numero de trajeta



--Actualizar saldo utilizando numero de contraseña



