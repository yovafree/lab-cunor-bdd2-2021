--
-- PostgreSQL database dump
--

-- Dumped from database version 10.12
-- Dumped by pg_dump version 12.0

-- Started on 2021-08-26 02:58:43 UTC

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 2931 (class 1262 OID 79591)
-- Name: bd_cunor; Type: DATABASE; Schema: -; Owner: app_cunor
--

CREATE DATABASE bd_cunor WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'en_US.utf8' LC_CTYPE = 'en_US.utf8';


ALTER DATABASE bd_cunor OWNER TO app_cunor;

\connect bd_cunor

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 2925 (class 0 OID 79611)
-- Dependencies: 201
-- Data for Name: det_factura; Type: TABLE DATA; Schema: public; Owner: app_cunor
--

INSERT INTO public.det_factura VALUES (1, 2.00, 350.00, 150.00, 2, 1);
INSERT INTO public.det_factura VALUES (2, 3.00, 432.00, 143.00, 3, 1);
INSERT INTO public.det_factura VALUES (3, 4.00, 32.00, 8.00, 4, 1);


--
-- TOC entry 2923 (class 0 OID 79603)
-- Dependencies: 199
-- Data for Name: factura; Type: TABLE DATA; Schema: public; Owner: app_cunor
--

INSERT INTO public.factura VALUES (1, '2021-08-26', 'Leonardo Alvarez', '4565546', 555.85);


--
-- TOC entry 2921 (class 0 OID 79594)
-- Dependencies: 197
-- Data for Name: producto; Type: TABLE DATA; Schema: public; Owner: app_cunor
--

INSERT INTO public.producto VALUES (2, 'Pantalon', 180.00);
INSERT INTO public.producto VALUES (3, 'Manzana', 160.00);
INSERT INTO public.producto VALUES (5, 'Micrófono', 350.75);
INSERT INTO public.producto VALUES (6, 'Billetera', 150.75);
INSERT INTO public.producto VALUES (4, 'Laptop', 4700.99);


--
-- TOC entry 2935 (class 0 OID 0)
-- Dependencies: 200
-- Name: det_factura_cod_det_factura_seq; Type: SEQUENCE SET; Schema: public; Owner: app_cunor
--

SELECT pg_catalog.setval('public.det_factura_cod_det_factura_seq', 3, true);


--
-- TOC entry 2936 (class 0 OID 0)
-- Dependencies: 198
-- Name: facturacion_cod_factura_seq; Type: SEQUENCE SET; Schema: public; Owner: app_cunor
--

SELECT pg_catalog.setval('public.facturacion_cod_factura_seq', 1, true);


--
-- TOC entry 2937 (class 0 OID 0)
-- Dependencies: 196
-- Name: producto_cod_producto_seq; Type: SEQUENCE SET; Schema: public; Owner: app_cunor
--

SELECT pg_catalog.setval('public.producto_cod_producto_seq', 6, true);


-- Completed on 2021-08-26 02:58:43 UTC

--
-- PostgreSQL database dump complete
--

