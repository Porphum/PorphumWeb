\c porphum_sales
BEGIN;

CREATE OR REPLACE FUNCTION trg_func_add_to_storage_when_complete()
RETURNS TRIGGER
AS
$trg$
DECLARE
    delta INT;
BEGIN
   IF new.status_id = 2
   		THEN
   			BEGIN
	   			IF new.type_id = 1
			        THEN
			            delta = 1;
			    END IF;
			    IF new.type_id = 2
			        THEN
			            delta = -1;
			    END IF;
			    INSERT INTO products_count_history(product_id, document_id, delta, write_type)
				    SELECT 
                        dr.product_id,
                        dr.document_id,
                        dr.quantity*delta,
                        'trigger'
				FROM documents_rows dr 
				WHERE dr.document_id = new.id;
	   		END;
   	END IF;

	RETURN NEW;
END
$trg$
LANGUAGE plpgsql;

CREATE OR REPLACE TRIGGER trg_add_to_storage_when_complete AFTER UPDATE ON documents
    FOR EACH ROW
    EXECUTE PROCEDURE trg_func_add_to_storage_when_complete();

CALL sp_update_db_version(6);

COMMIT;
