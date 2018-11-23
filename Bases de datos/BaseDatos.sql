--Tabla de clientes
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

CREATE TABLE TarjetaCredito_Contraseña(
Numero_tc2 varchar(16),
Numero_ctsa2 int,
CONSTRAINT fk_ftc2 FOREIGN KEY(Numero_tc2) REFERENCES TarjetaCredito(Numero_tc)
);


CREATE TABLE TarjetaDebito_Contraseña(
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
CONSTRAINT pk_cemp PRIMARY KEY(Nombre_emp)
);


CREATE TABLE Transferencia(
Transferencia_cliente float,
Numero_cli4 int,
Nombre_emp2 varchar(16),
CONSTRAINT pk_ccliente PRIMARY KEY(Transferencia_cliente),
CONSTRAINT fk_fcli4 FOREIGN KEY(Numero_cli4) REFERENCES Clientes(Numero_cli),
CONSTRAINT fk_femp2 FOREIGN KEY(Nombre_emp2) REFERENCES Empresas(Nombre_emp)
);


CREATE TABLE Empresas_clientes(
Nombre_emp1 varchar(16),
Numero_cli3 int,
CONSTRAINT fk_femp1 FOREIGN KEY(Nombre_emp1) REFERENCES Empresas(Nombre_emp),
CONSTRAINT fk_fcli3 FOREIGN KEY(Numero_cli3) REFERENCES Clientes(Numero_cli)
);


CREATE TABLE Deposito(
Cliente_dep float,
CONSTRAINT pk_cdep PRIMARY KEY(Cliente_dep)
);


CREATE TABLE Deposito_Transferencia(
Cliente_dep1 float,
Transferencia_cliente10 float,
CONSTRAINT fk_fdep1 FOREIGN KEY(Cliente_dep1) REFERENCES Deposito(Cliente_dep),
CONSTRAINT fk_fcliente10 FOREIGN KEY(Transferencia_cliente10) REFERENCES Transferencia(Transferencia_cliente)
);



INSERT INTO empresas VALUES('Telmex');
INSERT INTO empresas VALUES('Netflix');
INSERT INTO empresas VALUES('CFE');
INSERT INTO empresas VALUES('SAT');

INSERT INTO clientes VALUES(1,'Eduardo Marquez');
INSERT INTO clientes VALUES(2,'Norman SaldaÃ±a');
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

INSERT INTO tarjetadebito_contraseña VALUES('1242754383559995',2424);
INSERT INTO tarjetadebito_contraseña VALUES('7893462391734713',1111);
INSERT INTO tarjetadebito_contraseña VALUES('7761272473896356',2222);
INSERT INTO tarjetadebito_contraseña VALUES('1230974561236348',3333);

INSERT INTO tarjetacredito_contraseña VALUES('5632908851787856',4242);
INSERT INTO tarjetacredito_contraseña VALUES('8247592745762994',5555);
INSERT INTO tarjetacredito_contraseña VALUES('9847619375789138',6666);
INSERT INTO tarjetacredito_contraseña VALUES('1234085908236784',7777);

INSERT INTO empresas_clientes VALUES('Telmex',1);
INSERT INTO empresas_clientes VALUES('Netflix',1);
INSERT INTO empresas_clientes VALUES('CFE',1);
INSERT INTO empresas_clientes VALUES('SAT',1);
INSERT INTO empresas_clientes VALUES('Telmex',2);
INSERT INTO empresas_clientes VALUES('Netflix',2);
INSERT INTO empresas_clientes VALUES('CFE',2);
INSERT INTO empresas_clientes VALUES('SAT',2);

--Consultas de contraseÃ±as utilizando numero de tarjeta
SELECT Numero_ctsa2 FROM TarjetaCredito_Contraseña WHERE Numero_tc2=5632908851787856;

SELECT Numero_ctsa1 FROM TarjetaDebito_Contraseña WHERE Numero_td1=1242754383559995;

--Consultas de saldo utilizando numero de tarjeta
SELECT credito_tc FROM tarjetacredito WHERE Numero_tc=5632908851787856;

SELECT debito_td FROM tarjetadebito WHERE Numero_td=1242754383559995;

--Actualizar contraseÃ±as utilizando numero de trajeta

UPDATE TarjetaCredito_Contraseña SET Numero_ctsa2=18099 WHERE Numero_tc2=5632908851787856;

UPDATE TarjetaDebito_Contraseña SET Numero_ctsa1=(textbox) WHERE Numero_td1=1242754383559995;

--Actualizar saldo y credito utilizando numero de contraseÃ±a

UPDATE tarjetacredito SET credito_tc=(depende) WHERE Numero_tc=5632908851787856;

UPDATE tarjetadebito SET debito_td=(depende) WHERE Numero_td=1242754383559995;

