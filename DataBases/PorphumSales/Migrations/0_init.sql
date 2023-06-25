DROP DATABASE IF EXISTS porphum_sales;

CREATE DATABASE porphum_sales
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'Russian_Russia.1251'
    LC_CTYPE = 'Russian_Russia.1251'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;

-- Scaffold-DbContext "Host=localhost;Port=5432;Database=porphum_sales;Username=postgres;Password=root" Npgsql.EntityFrameworkCore.PostgreSQL