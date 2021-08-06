-- Contenedor de Oracle utilizado
-- https://hub.docker.com/r/oracleinanutshell/oracle-xe-11g

-- Crear un esquema y un usuario.

CREATE USER DBACUNOR 
IDENTIFIED BY CunoR123456;


-- Permisos de la Base de Datos.
GRANT DBA TO DBACUNOR;
GRANT create session TO DBACUNOR;
GRANT create table TO DBACUNOR;
GRANT create view TO DBACUNOR;
GRANT create any trigger TO DBACUNOR;
GRANT create any procedure TO DBACUNOR;
GRANT create sequence TO DBACUNOR;
GRANT create synonym TO DBACUNOR;

-----

create table movimientos (                                     
  id integer not null primary key,
  origen integer not null,
  destino integer not null,
  monto number(12,2) not null
);

create sequence seq_movimientos start with 1 increment by 1;

select seq_movimientos.nextval from dual;

select seq_movimientos.currval from dual;

----

-- COMENTARIO DE UNA LÍNEA

insert into movimientos(id, origen, destino, monto) values (seq_movimientos.nextval, 1111, 2222, 500);

insert into movimientos(id, origen, destino, monto) values (seq_movimientos.nextval, 2222, 3333, 1000);

SELECT * FROM movimientos;


create table grandes_movimientos as (select * from movimientos where 0=1);


create or replace trigger trg_grandes_movimientos
after insert on movimientos
    for each row
    when (new.monto >= 10000)
begin
    insert into grandes_movimientos
    values (:new.id, :new.origen, :new.destino, :new.monto);
end;
/

select * from grandes_movimientos;

insert into movimientos(id, origen, destino, monto) values (seq_movimientos.nextval, 4444, 5555, 9900); 

insert into movimientos(id, origen, destino, monto) values (seq_movimientos.nextval, 6666, 7777, 10500);

create table aud_m as (select * from movimientos where 0=1); 

alter table aud_m add (fmod date, umod varchar2(10));


create or replace trigger trg_audit_movimientos
    after update on movimientos
    for each row
begin
    insert into aud_m(id, origen, destino, monto, fmod, umod)
    values (:old.id, :old.origen, :old.destino, :old.monto, sysdate, user);
end;
/


update movimientos set monto = 9999 where id = 6;

select * from aud_m;
