--- Fecha: 05/08/2021

create table paises(id number, nombre varchar2(20));

create sequence s_paises start with 1 increment by 1;

create trigger bi_paises before insert on paises for each row
begin
   :new.id := s_paises.nextval;
end;
/

insert into paises(nombre) values ('Uruguay');
insert into paises(nombre) values ('Argentina');
insert into paises(nombre) values ('Guatemala');
insert into paises(nombre) values ('Honduras');
insert into paises(nombre) values ('El Salvador');
insert into paises(nombre) values ('Costa Rica');

DELETE FROM paises;

SELECT * FROM paises;


COMMIT;

ROLLBACK;


CREATE VIEW v_paises AS SELECT ID, NOMBRE FROM PAISES WHERE ID > 21;


select * from v_paises WHERE

CREATE MATERIALIZED VIEW v_mat_paises AS SELECT ID, NOMBRE FROM PAISES WHERE ID > 21;



create sequence s_mov start with 7 increment by 1;

CREATE OR REPLACE PROCEDURE TRANSFERIR(
   V_ORIGEN IN NUMBER, 
   V_DESTINO IN NUMBER,
   V_MONTO IN NUMBER) IS
BEGIN
  -- Sacamos V_MONTO de la cuenta V_ORIGEN
  update cuentas set monto = monto-V_MONTO where id = V_ORIGEN;

  -- Agregamos V_MONTO a la cuenta V_DESTINO
  update cuentas set monto = monto + V_MONTO where id = V_DESTINO;

  -- Registramos el movimiento
  insert into movimientos(id, origen, destino, monto)
  values (s_mov.nextval, V_ORIGEN, V_DESTINO, V_MONTO);
  
  COMMIT;
END;
/

create or replace trigger trg_audit_cuentas
    after insert on movimientos
    for each row
begin
    insert into aud_m(id, origen, destino, monto, fmod, umod)
    values (:new.id, :new.origen, :new.destino, :new.monto, sysdate, user);
end;


INSERT INTO CUENTAS(ID,MONTO,TITULAR) VALUES(1, 1500, 'Raul Peña');
INSERT INTO CUENTAS(ID,MONTO,TITULAR) VALUES(2, 1546, 'Luis Peña');
INSERT INTO CUENTAS(ID,MONTO,TITULAR) VALUES(3, 2000, 'Carlos Peña');
INSERT INTO CUENTAS(ID,MONTO,TITULAR) VALUES(4, 150, 'Mynor Peña');
INSERT INTO CUENTAS(ID,MONTO,TITULAR) VALUES(5, 800, 'David Peña');
INSERT INTO CUENTAS(ID,MONTO,TITULAR) VALUES(6, 15000, 'Daniel Peña');
INSERT INTO CUENTAS(ID,MONTO,TITULAR) VALUES(7, 200000, 'José Peña');
commit;


EXEC TRANSFERIR(7,2,10000);

SELECT * FROM cuentas;
SELECT * FROM movimientos;
SELECT * FROM grandes_movimientos;
SELECT * FROM aud_m;


