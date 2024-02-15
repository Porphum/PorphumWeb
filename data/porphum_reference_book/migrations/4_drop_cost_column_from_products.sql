\c porphum_reference_book
BEGIN;

ALTER TABLE products DROP CONSTRAINT products_cost_check;
ALTER TABLE products DROP COLUMN "cost";

COMMIT;
