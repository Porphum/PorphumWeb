BEGIN;

DROP TABLE IF EXISTS document_config;

CREATE TABLE document_config(
	id SMALLSERIAL PRIMARY KEY,
	master_id BIGINT NOT NULL
);


CALL sp_update_db_version(3);

COMMIT;