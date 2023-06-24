BEGIN;

CREATE OR REPLACE PROCEDURE sp_update_db_version(new_version INT)
LANGUAGE plpgsql
AS $$

BEGIN

    UPDATE db_version SET 
    version = new_version,
    update_date = NOW();

END; $$;

DROP TABLE IF EXISTS documents_rows;
DROP TABLE IF EXISTS documents;
DROP TABLE IF EXISTS documents_statuses;
DROP TABLE IF EXISTS documents_types;

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


create table documents_types(
	id SMALLSERIAL PRIMARY KEY,
	name VARCHAR(40) NOT NULL
);

insert INTo documents_types(id, name) 
values 
(1,'Приход'),(2,'Расход');

create table documents_statuses(
	id SMALLSERIAL PRIMARY KEY,
	name VARCHAR(40) NOT NULL
);

insert INTo documents_statuses(id, name) 
values 
(1,'Создан'),(2,'Заполнен'),(3,'Закрыт');


create table documents(
	id BIGSERIAL PRIMARY KEY,
	number INT NOT NULL,
	date TIMESTAMP  NOT NULL,
	client_who_id BIGINT NOT NULL,
	client_with_id BIGINT NOT NULL,
	type_id INT NOT NULL,
	status_id INT NOT NULL,
	FOREIGN KEY (type_id) REFERENCES documents_types(id) ON DELETE restrict,
	FOREIGN KEY (status_id) REFERENCES documents_statuses(id) ON DELETE restrict,
	FOREIGN KEY (client_who_id) REFERENCES clients(id) ON DELETE restrict,
	FOREIGN KEY (client_with_id) REFERENCES clients(id) ON DELETE restrict,
	UNIQUE(number)
);

create table documents_rows(
	product_id BIGINT NOT NULL,
	document_id BIGINT NOT NULL,
	quantity INT NOT NULL default 0 CHECK (cost >= 0),
	cost NUMERIC(20,2) NOT NULL CHECK (cost > 0),
	FOREIGN KEY (document_id) REFERENCES documents(id) ON DELETE CASCADE,
	FOREIGN KEY (product_id) REFERENCES products(id) ON DELETE restrict,
	PRIMARY KEY(product_id, document_id)
);

CALL sp_update_db_version(3);

COMMIT;