-- Se crea un usuario

CREATE USER app_cunor2 WITH PASSWORD '85464rQrrd';

CREATE ROLE app_role;

GRANT CONNECT ON DATABASE bd_cunor TO app_role;

GRANT app_role TO app_cunor2;

GRANT ALL PRIVILEGES ON public.producto TO app_role;

GRANT ALL ON SEQUENCE public.producto_cod_producto_seq TO app_role;

GRANT SELECT, INSERT ON public.factura TO app_role;

GRANT ALL ON SEQUENCE public.facturacion_cod_factura_seq TO app_role;

GRANT SELECT, INSERT, UPDATE ON public.factura TO app_role;

GRANT SELECT, INSERT, UPDATE ON public.usuario TO app_role;

GRANT ALL ON SEQUENCE public.usuario_cod_usuario_seq TO app_role;


--- Crear un usuario 3

CREATE USER app_cunor3 WITH PASSWORD '554988QrjdW';

GRANT app_role TO app_cunor3;