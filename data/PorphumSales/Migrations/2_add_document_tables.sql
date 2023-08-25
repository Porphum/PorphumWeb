BEGIN;

DROP TABLE IF EXISTS documents_rows;
DROP TABLE IF EXISTS documents;
DROP TABLE IF EXISTS documents_statuses;
DROP TABLE IF EXISTS documents_types;

CREATE TABLE documents_types(
	id SMALLSERIAL PRIMARY KEY,
	name VARCHAR(40) NOT NULL
);

INSERT INTo documents_types(id, name) 
VALUES 
(1,'Приход'),(2,'Расход');

CREATE TABLE documents_statuses(
	id SMALLSERIAL PRIMARY KEY,
	name VARCHAR(40) NOT NULL
);

INSERT INTo documents_statuses(id, name) 
VALUES 
(1,'Создан'),(2,'Заполнен'),(3,'Закрыт');


CREATE TABLE documents(
	id BIGSERIAL PRIMARY KEY,
	number INT NOT NULL,
	date TIMESTAMP  NOT NULL,
	client_who_id BIGINT NOT NULL,
	client_with_id BIGINT NOT NULL,
	type_id SMALLINT NOT NULL,
	status_id SMALLINT NOT NULL,
	FOREIGN KEY (type_id) REFERENCES documents_types(id) ON DELETE restrict,
	FOREIGN KEY (status_id) REFERENCES documents_statuses(id) ON DELETE restrict,
	-- FOREIGN KEY (client_who_id) REFERENCES clients(id) ON DELETE restrict,
	-- FOREIGN KEY (client_with_id) REFERENCES clients(id) ON DELETE restrict,
	UNIQUE(number)
);

CREATE TABLE documents_rows(
	product_id BIGINT NOT NULL,
	document_id BIGINT NOT NULL,
	quantity INT NOT NULL default 0 CHECK (cost >= 0),
	cost NUMERIC(20,2) NOT NULL CHECK (cost > 0),
	FOREIGN KEY (document_id) REFERENCES documents(id) ON DELETE CASCADE,
	-- FOREIGN KEY (product_id) REFERENCES products(id) ON DELETE restrict,
	PRIMARY KEY(product_id, document_id)
);

CALL sp_update_db_version(2);

COMMIT;