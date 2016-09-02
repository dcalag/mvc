SET SQL DIALECT 3;
SET NAMES UTF8;

CREATE DATABASE '/db/mvc.fdb'
USER 'SYSDBA' PASSWORD '0'
PAGE_SIZE 8192
DEFAULT CHARACTER SET UTF8;

CREATE TABLE PERSONAS (
    ID       INTEGER NOT NULL,
    NOMBRE     VARCHAR(100),
    EDAD  VARCHAR(10),
    CONSTRAINT PERSONAS_PK PRIMARY KEY (ID)
);

INSERT INTO PERSONAS (ID, NOMBRE, EDAD) VALUES (1, 'Daniel', '36');
