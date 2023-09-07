\c porphum_web
BEGIN;

DROP TABLE IF EXISTS connections;

CREATE TABLE connections(
    key_id VARCHAR(10) NOT NULL PRIMARY KEY,
    db_name VARCHAR(20) NOT NULL,
    is_active BOOLEAN NOT NULL default false
);

INSERT INTO connections(Key_id, db_name, is_active) VALUES ('postgres', 'porphum_sales', True);

CALL sp_update_db_version(4);

COMMIT;