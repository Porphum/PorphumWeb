\c porphum_sales
BEGIN;

DROP VIEW IF EXISTS public.products_storage;
DROP TABLE IF EXISTS products_prices;

CREATE TABLE products_prices(
	product_id BIGINT NOT null,
	price NUMERIC(20,2) NOT NULL CHECK (price > 0), 
	from_date TIMESTAMP not null default NOW(),
	primary key(product_id, from_date)
);

DROP TABLE IF EXISTS products_count_history;
CREATE TABLE products_count_history(
	history_id BIGSERIAL not null primary key,
	product_id BIGINT NOT null,
	document_id BIGINT references documents(id) on delete set null,
	delta INT not null CHECK (delta != 0),
	accur_date TIMESTAMP not null default NOW(),
	write_type VARCHAR(10) not null
);

CREATE OR REPLACE VIEW public.products_storage
AS SELECT h.product_id,
    sum(h.delta) AS sum,
    max(h.accur_date) as last_upd
   FROM products_count_history h
  GROUP BY h.product_id
  ORDER BY h.product_id;

CALL sp_update_db_version(5);

COMMIT;
