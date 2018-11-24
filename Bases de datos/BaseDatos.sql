--Tabla para guardar clientes
CREATE TABLE Clientes(
Numero_cli int,
Nombre_cli varchar(50),
CONSTRAINT pk_ccli PRIMARY KEY(Numero_cli)
);

--Tabla de tarjetas de credito
CREATE TABLE TarjetaCredito(
Numero_tc varchar(16),
Credito_tc float,    
CONSTRAINT pk_ctc PRIMARY KEY(Numero_tc)
);

--Tabla de tarjetas de debito
CREATE TABLE TarjetaDebito(
Numero_td varchar(16),
Saldo_td float,
CONSTRAINT pk_ctd PRIMARY KEY(Numero_td)
);

--Tabla para relacionar la tarjeta de credito con su contrasena
CREATE TABLE TarjetaCredito_Contrasena(
Numero_tc2 varchar(16),
Numero_ctsa2 int,
CONSTRAINT fk_ftc2 FOREIGN KEY(Numero_tc2) REFERENCES TarjetaCredito(Numero_tc)
);

--Tabla para relacionar la tarjeta de debito con su contrasena
CREATE TABLE TarjetaDebito_Contrasena(
Numero_td2 varchar(16),
Numero_ctsa1 int,
CONSTRAINT fk_ftd2 FOREIGN KEY(Numero_td2) REFERENCES TarjetaDebito(Numero_td)
);

--Tabla para relacionar los clientes con su respectiva tarjeta de credito
CREATE TABLE Clientes_TarjetaCredito(
Numero_cli1 int,
Numero_tc1 varchar(16),
CONSTRAINT fk_fcli1 FOREIGN KEY(Numero_cli1) REFERENCES Clientes(Numero_cli),
CONSTRAINT fk_ftc1 FOREIGN KEY(Numero_tc1) REFERENCES TarjetaCredito(Numero_tc)
);

--Tabla para relacionar los clientes con su respectiva tarjeta de debito
CREATE TABLE Clientes_TarjetaDebito(
Numero_cli2 int,
Numero_td1 varchar(16),
CONSTRAINT fk_fcli2 FOREIGN KEY(Numero_cli2) REFERENCES Clientes(Numero_cli),
CONSTRAINT fk_ftd1 FOREIGN KEY(Numero_td1) REFERENCES TarjetaDebito(Numero_td)
);

--Tabla de empresas
CREATE TABLE Empresas(
Nombre_emp varchar(50),
Numero_emp int,
CONSTRAINT pk_cempnum PRIMARY KEY(Numero_emp)
);

--Tabla para relacionar las empresas con sus respectivos clientes
CREATE TABLE Empresas_clientes(
Numero_emp1 int,
Numero_cli3 int,
NumeroReferencia int,
CantidadDeposito int,  
CONSTRAINT fk_femp1 FOREIGN KEY(Numero_emp1) REFERENCES Empresas(Numero_emp),
CONSTRAINT fk_fcli3 FOREIGN KEY(Numero_cli3) REFERENCES Clientes(Numero_cli)
);


--Inserciones de empresas 
INSERT INTO empresas VALUES('Telmex',1);
INSERT INTO empresas VALUES('Netflix',2);
INSERT INTO empresas VALUES('CFE',3);
INSERT INTO empresas VALUES('SAT',4);

--Inserciones de clientes
INSERT INTO clientes VALUES(1,'Eduardo Marquez');
INSERT INTO clientes VALUES(2,'Norman Saldana');
INSERT INTO clientes VALUES(3,'Armando Rodriguez');
INSERT INTO clientes VALUES(4,'Enrique Graue');

--Inserciones de tarjetas de credito
INSERT INTO tarjetacredito VALUES('5632908851787856',10000);
INSERT INTO tarjetacredito VALUES('8247592745762994',7999);
INSERT INTO tarjetacredito VALUES('9847619375789138',92763);
INSERT INTO tarjetacredito VALUES('1234085908236784',43426);

--Inserciones de tarjetas de debito
INSERT INTO tarjetadebito VALUES('1242754383559995',10000);
INSERT INTO tarjetadebito VALUES('7893462391734713',20000);
INSERT INTO tarjetadebito VALUES('7761272473896356',30000);
INSERT INTO tarjetadebito VALUES('1230974561236348',40000);


--Inserciones de la relacion entre clientes y tarjetas de credito
INSERT INTO clientes_tarjetacredito VALUES(1,'5632908851787856');
INSERT INTO clientes_tarjetacredito VALUES(2,'8247592745762994');
INSERT INTO clientes_tarjetacredito VALUES(3,'9847619375789138');
INSERT INTO clientes_tarjetacredito VALUES(4,'1234085908236784');

--Inserciones de la relacion entre clientes y tarjetas de debito
INSERT INTO clientes_tarjetadebito VALUES(2,'1242754383559995');
INSERT INTO clientes_tarjetadebito VALUES(1,'7893462391734713');
INSERT INTO clientes_tarjetadebito VALUES(3,'7761272473896356');
INSERT INTO clientes_tarjetadebito VALUES(4,'1230974561236348');

--Inserciones de la relacion entre tarjetas de debito y contraseÃ±as
INSERT INTO tarjetadebito_contrasena VALUES('1242754383559995',2424);
INSERT INTO tarjetadebito_contrasena VALUES('7893462391734713',1111);
INSERT INTO tarjetadebito_contrasena VALUES('7761272473896356',2222);
INSERT INTO tarjetadebito_contrasena VALUES('1230974561236348',3333);

--Inserciones de la relacion entre tarjetas de credito y contraseÃ±as
INSERT INTO tarjetacredito_contrasena VALUES('5632908851787856',4242);
INSERT INTO tarjetacredito_contrasena VALUES('8247592745762994',5555);
INSERT INTO tarjetacredito_contrasena VALUES('9847619375789138',6666);
INSERT INTO tarjetacredito_contrasena VALUES('1234085908236784',7777);


--Consultas de contrasenas utilizando numero de tarjeta
SELECT Numero_ctsa2 FROM TarjetaCredito_Contrasena WHERE Numero_tc2=5632908851787856;

SELECT Numero_ctsa1 FROM TarjetaDebito_Contrasena WHERE Numero_td1=1242754383559995;

--Consultas de saldo utilizando numero de tarjeta
SELECT credito_tc FROM tarjetacredito WHERE Numero_tc=5632908851787856;

SELECT debito_td FROM tarjetadebito WHERE Numero_td=1242754383559995;

--Actualizar contrasenas utilizando numero de trajeta

UPDATE TarjetaCredito_Contrasena SET Numero_ctsa2=18099 WHERE Numero_tc2=5632908851787856;

UPDATE TarjetaDebito_Contrasena SET Numero_ctsa1=(textbox) WHERE Numero_td1=1242754383559995;

--Actualizar saldo y credito utilizando numero de contrasena

UPDATE tarjetacredito SET credito_tc=(depende) WHERE Numero_tc=5632908851787856;

UPDATE tarjetadebito SET debito_td=(depende) WHERE Numero_td=1242754383559995;

--Insert en tabla cliente-empresa
numeroDeCliente = SElECT Numero_cli1 FROM Clientes_TarjetaCredito WHERE Numero_tc1=5632908851787856;
numeroDeEmpresa = SELECT Numero_emp FROM Empresas WHERE Numero_emp=1;
INSERT INTO empresas_clientes VALUES (numeroDeEmpresa,numeroDeCliente); 







--Codigo listo para ejecutar


CREATE TABLE Clientes(
Numero_cli int,
Nombre_cli varchar(50),
CONSTRAINT pk_ccli PRIMARY KEY(Numero_cli)
);


CREATE TABLE TarjetaCredito(
Numero_tc varchar(16),
Credito_tc float,    
CONSTRAINT pk_ctc PRIMARY KEY(Numero_tc)
);

CREATE TABLE TarjetaDebito(
Numero_td varchar(16),
Saldo_td float,
CONSTRAINT pk_ctd PRIMARY KEY(Numero_td)
);

CREATE TABLE TarjetaCredito_Contrasena(
Numero_tc2 varchar(16),
Numero_ctsa2 int,
CONSTRAINT fk_ftc2 FOREIGN KEY(Numero_tc2) REFERENCES TarjetaCredito(Numero_tc)
);


CREATE TABLE TarjetaDebito_Contrasena(
Numero_td2 varchar(16),
Numero_ctsa1 int,
CONSTRAINT fk_ftd2 FOREIGN KEY(Numero_td2) REFERENCES TarjetaDebito(Numero_td)
);


CREATE TABLE Clientes_TarjetaCredito(
Numero_cli1 int,
Numero_tc1 varchar(16),
CONSTRAINT fk_fcli1 FOREIGN KEY(Numero_cli1) REFERENCES Clientes(Numero_cli),
CONSTRAINT fk_ftc1 FOREIGN KEY(Numero_tc1) REFERENCES TarjetaCredito(Numero_tc)
);


CREATE TABLE Clientes_TarjetaDebito(
Numero_cli2 int,
Numero_td1 varchar(16),
CONSTRAINT fk_fcli2 FOREIGN KEY(Numero_cli2) REFERENCES Clientes(Numero_cli),
CONSTRAINT fk_ftd1 FOREIGN KEY(Numero_td1) REFERENCES TarjetaDebito(Numero_td)
);


CREATE TABLE Empresas(
Nombre_emp varchar(50),
Numero_emp int,
CONSTRAINT pk_cempnum PRIMARY KEY(Numero_emp)
);


CREATE TABLE Empresas_clientes(
Numero_emp1 int,
Numero_cli3 int,
NumeroReferencia int,
CantidadDeposito int,  
CONSTRAINT fk_femp1 FOREIGN KEY(Numero_emp1) REFERENCES Empresas(Numero_emp),
CONSTRAINT fk_fcli3 FOREIGN KEY(Numero_cli3) REFERENCES Clientes(Numero_cli)
);



INSERT INTO empresas VALUES('Telmex',1);
INSERT INTO empresas VALUES('Netflix',2);
INSERT INTO empresas VALUES('CFE',3);
INSERT INTO empresas VALUES('SAT',4);

INSERT INTO clientes VALUES(1,'Eduardo Marquez');
INSERT INTO clientes VALUES(2,'Norman Saldana');
INSERT INTO clientes VALUES(3,'Armando Rodriguez');
INSERT INTO clientes VALUES(4,'Enrique Graue');

INSERT INTO tarjetacredito VALUES('5632908851787856',10000);
INSERT INTO tarjetacredito VALUES('8247592745762994',7999);
INSERT INTO tarjetacredito VALUES('9847619375789138',92763);
INSERT INTO tarjetacredito VALUES('1234085908236784',43426);

INSERT INTO tarjetadebito VALUES('1242754383559995',10000);
INSERT INTO tarjetadebito VALUES('7893462391734713',20000);
INSERT INTO tarjetadebito VALUES('7761272473896356',30000);
INSERT INTO tarjetadebito VALUES('1230974561236348',40000);



INSERT INTO clientes_tarjetacredito VALUES(1,'5632908851787856');
INSERT INTO clientes_tarjetacredito VALUES(2,'8247592745762994');
INSERT INTO clientes_tarjetacredito VALUES(3,'9847619375789138');
INSERT INTO clientes_tarjetacredito VALUES(4,'1234085908236784');

INSERT INTO clientes_tarjetadebito VALUES(2,'1242754383559995');
INSERT INTO clientes_tarjetadebito VALUES(1,'7893462391734713');
INSERT INTO clientes_tarjetadebito VALUES(3,'7761272473896356');
INSERT INTO clientes_tarjetadebito VALUES(4,'1230974561236348');

INSERT INTO tarjetadebito_contrasena VALUES('1242754383559995',2424);
INSERT INTO tarjetadebito_contrasena VALUES('7893462391734713',1111);
INSERT INTO tarjetadebito_contrasena VALUES('7761272473896356',2222);
INSERT INTO tarjetadebito_contrasena VALUES('1230974561236348',3333);

INSERT INTO tarjetacredito_contrasena VALUES('5632908851787856',4242);
INSERT INTO tarjetacredito_contrasena VALUES('8247592745762994',5555);
INSERT INTO tarjetacredito_contrasena VALUES('9847619375789138',6666);
INSERT INTO tarjetacredito_contrasena VALUES('1234085908236784',7777);



SELECT Numero_ctsa2 FROM TarjetaCredito_Contrasena WHERE Numero_tc2=5632908851787856;

SELECT Numero_ctsa1 FROM TarjetaDebito_Contrasena WHERE Numero_td2=1242754383559995;


SELECT credito_tc FROM tarjetacredito WHERE Numero_tc=5632908851787856;

SELECT saldo_td FROM tarjetadebito WHERE Numero_td=1242754383559995;



UPDATE TarjetaCredito_Contrasena SET Numero_ctsa2=18099 WHERE Numero_tc2=5632908851787856;

UPDATE TarjetaDebito_Contrasena SET Numero_ctsa1=(textbox) WHERE Numero_td1=1242754383559995;



UPDATE tarjetacredito SET credito_tc=(depende) WHERE Numero_tc=5632908851787856;

UPDATE tarjetadebito SET debito_td=(depende) WHERE Numero_td=1242754383559995;

numeroDeCliente = SElECT Numero_cli1 FROM Clientes_TarjetaCredito WHERE Numero_tc1=5632908851787856;
numeroDeEmpresa = SELECT Numero_emp FROM Empresas WHERE Nombre_emp="Telmex";
INSERT INTO empresas_clientes VALUES (1,1,32345654334,400); 


