\c porphum_web
BEGIN;

CREATE OR REPLACE PROCEDURE sp_update_db_version(new_version INT)
LANGUAGE plpgsql
AS $$

BEGIN

    UPDATE db_version SET 
    version = new_version,
    update_date = NOW();

END; $$;

CALL sp_update_db_version(3);

COMMIT;