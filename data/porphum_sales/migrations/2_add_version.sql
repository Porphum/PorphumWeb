\c porphum_sales
BEGIN;

DROP TABLE IF EXISTS db_version;

CREATE TABLE db_version(
    version INT NOT NULL,
	update_date TIMESTAMP WITH TIME ZONE DEFAULT NOW()
);

CREATE OR REPLACE PROCEDURE sp_update_db_version(new_version INT)
LANGUAGE plpgsql
AS $$

BEGIN

    UPDATE db_version SET 
    version = new_version,
    update_date = NOW();

END; $$;

CALL sp_update_db_version(2);

COMMIT;