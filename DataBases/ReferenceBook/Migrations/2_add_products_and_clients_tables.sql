BEGIN;

CREATE OR REPLACE PROCEDURE sp_update_db_version(new_version INT)
LANGUAGE plpgsql
AS $$

BEGIN

    UPDATE db_version SET 
    version = new_version,
    update_date = NOW();

END; $$;

DROP TABLE IF EXISTS products_info;
DROP TABLE IF EXISTS products;
DROP TABLE IF EXISTS products_groups;

DROP TABLE IF EXISTS clients_info;
DROP TABLE IF EXISTS clients;

CREATE TABLE products_groups(
	id SERIAL NOT NULL PRIMARY KEY,
	name VARCHAR(80) NOT NULL,
	parent_id INT NULL
);

CREATE TABLE products(
	id BIGSERIAL NOT NULL PRIMARY KEY,
	name VARCHAR(120) NOT NULL,
	cost NUMERIC(20,2) NOT NULL CHECK (cost > 0), 
	group_id INT NULL,
	FOREIGN KEY (group_id) REFERENCES products_groups(id) ON DELETE SET NULL
);



CREATE TABLE products_info(
	product_id BIGINT NOT NULL PRIMARY KEY,
	barcode VARCHAR(120) NULL,
	description TEXT NULL, 
	FOREIGN KEY (product_id) REFERENCES products(id) ON DELETE CASCADE
);

create table clients(
	id BIGSERIAL PRIMARY KEY,
	name VARCHAR(120) NOT NULL
);

create table clients_info(
	client_id BIGINT PRIMARY KEY,
	inn VARCHAR(10) NULL,
	adress VARCHAR(80) NULL,
	FOREIGN KEY (client_id) REFERENCES clients(id) ON DELETE CASCADE
);

CALL sp_update_db_version(2);

COMMIT;