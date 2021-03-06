--
-- PostgreSQL database dump
--

-- Dumped from database version 12.2
-- Dumped by pg_dump version 12.2

-- Started on 2020-05-06 23:08:43

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

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 202 (class 1259 OID 24801)
-- Name: user; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."user" (
    "Id" integer NOT NULL,
    "Name" character varying(255) NOT NULL,
    "Surname" character varying(255) NOT NULL,
    "DateOfBirth" date NOT NULL
);


ALTER TABLE public."user" OWNER TO postgres;

--
-- TOC entry 203 (class 1259 OID 24853)
-- Name: user_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."user" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."user_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 2816 (class 0 OID 24801)
-- Dependencies: 202
-- Data for Name: user; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."user" ("Id", "Name", "Surname", "DateOfBirth") FROM stdin;
1	On Post FirstName	On Post LastName	2020-03-19
3	On Post FirstName2	On Post LastName2	2020-03-19
\.


--
-- TOC entry 2823 (class 0 OID 0)
-- Dependencies: 203
-- Name: user_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."user_Id_seq"', 3, true);


--
-- TOC entry 2689 (class 2606 OID 24808)
-- Name: user user_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."user"
    ADD CONSTRAINT user_pkey PRIMARY KEY ("Id");


-- Completed on 2020-05-06 23:08:44

--
-- PostgreSQL database dump complete
--

