INSERT INTO "users" ("username", "email", "password")
VALUES ('john', 'john@example.com', 'securepassword123')
ON CONFLICT ("email")
DO NOTHING;

INSERT INTO "users" ("username", "email", "password")
VALUES ('john_doe', 'john2@example.com', 'securepassword123')
ON CONFLICT ("email")
DO NOTHING;

INSERT INTO "users" ("username", "email", "password")
VALUES ('john_doeee', 'john3@example.com', 'securepassword123')
ON CONFLICT ("email")
DO NOTHING;

INSERT INTO "address" ("street", "street_number", "country", "surname", "name", "phone_number", "email","is_default","user_id") SELECT 'Place du général', '5', 'France', 'Doe', 'John', NULL, NULL,true, id
FROM "users" WHERE NOT EXISTS (
  SELECT 1 FROM "address" WHERE "street" = 'Place du général') AND username = 'john_doe';

INSERT INTO "address" ("street", "street_number", "country", "surname", "name", "phone_number", "email","is_default","user_id") SELECT 'Avenue du miléan', '17', 'Switzerland', 'Doeing', 'John', NULL, NULL, false,id
FROM "users" WHERE NOT EXISTS (
  SELECT 1 FROM "address" WHERE "street" = 'Avenue du miléan') AND username = 'john_doeee';

INSERT INTO "address" ("street", "street_number", "country", "surname", "name", "phone_number", "email","is_default","user_id") SELECT 'Place de la tour', '2', 'Switzerland', 'Doeing', 'John', NULL, NULL,true, id
FROM "users" WHERE NOT EXISTS (
  SELECT 1 FROM "address" WHERE "street" = 'Place de la tour') AND username = 'john_doeee';


-- INSERT INTO "category" ("category_name", "subcategory_id")
-- SELECT 'TEST', NULL
-- WHERE NOT EXISTS (
--   SELECT 1 FROM "category" WHERE "category_name" = 'TEST'
-- );

INSERT INTO "category" ("category_name", "subcategory_id")
SELECT 'Sport', NULL
WHERE NOT EXISTS (
  SELECT 1 FROM "category" WHERE "category_name" = 'Sport'
);

INSERT INTO "category" ("category_name", "subcategory_id")
SELECT 'Kitchen', NULL
WHERE NOT EXISTS (
  SELECT 1 FROM "category" WHERE "category_name" = 'Kitchen'
);

INSERT INTO "category" ("category_name", "subcategory_id")
SELECT 'Drinks', NULL
WHERE NOT EXISTS (
  SELECT 1 FROM "category" WHERE "category_name" = 'Drinks'
);

INSERT INTO "category" ("category_name", "subcategory_id")
SELECT 'Clothing', NULL
WHERE NOT EXISTS (
  SELECT 1 FROM "category" WHERE "category_name" = 'Clothing'
);

INSERT INTO "category" ("category_name", "subcategory_id")
SELECT 'Electronics', NULL
WHERE NOT EXISTS (
  SELECT 1 FROM "category" WHERE "category_name" = 'Electronics'
);

-- INSERT INTO "products" ("product_name", "price", "quantity_in_stock", "status", "id_category")
-- SELECT 'TEST', '17.50', '2', 'in_stock', NULL WHERE NOT EXISTS (
--     SELECT 1 FROM "products" WHERE "product_name" = 'TEST'
-- );

INSERT INTO "products" ("product_name", "price", "quantity_in_stock", "status", "id_category")
SELECT 'Yellow T-Shirt', '17.50', '2', 'in_stock', id 
FROM "category" 
WHERE category_name = 'Clothing'
AND NOT EXISTS (
    SELECT 1 FROM "products" WHERE "product_name" = 'Yellow T-Shirt'
);

INSERT INTO "products" ("product_name", "price", "quantity_in_stock", "status", "id_category")
SELECT 'Black T-Shirt', '20.99', '6', 'in_stock', id 
FROM "category" 
WHERE category_name = 'Clothing'
AND NOT EXISTS (
    SELECT 1 FROM "products" WHERE "product_name" = 'Black T-Shirt'
);

INSERT INTO "products" ("product_name", "price", "quantity_in_stock", "status", "id_category")
SELECT 'Red T-Shirt', '18.75', '4', 'in_stock', id 
FROM "category" 
WHERE category_name = 'Clothing'
AND NOT EXISTS (
    SELECT 1 FROM "products" WHERE "product_name" = 'Red T-Shirt'
);

INSERT INTO "products" ("product_name", "price", "quantity_in_stock", "status", "id_category")
SELECT 'Laptop V2', '740.35', '29', 'in_stock', id 
FROM "category" 
WHERE category_name = 'Electronics'
AND NOT EXISTS (
    SELECT 1 FROM "products" WHERE "product_name" = 'Laptop V2'
);

INSERT INTO "products" ("product_name", "price", "quantity_in_stock", "status", "id_category")
SELECT 'Laptop V5', '1599.99', '8', 'in_stock', id 
FROM "category" 
WHERE category_name = 'Electronics'
AND NOT EXISTS (
    SELECT 1 FROM "products" WHERE "product_name" = 'Laptop V5'
);

INSERT INTO "products" ("product_name", "price", "quantity_in_stock", "status", "id_category")
SELECT 'Smartphone Pro', '999.99', '15', 'in_stock', id 
FROM "category" 
WHERE category_name = 'Electronics'
AND NOT EXISTS (
    SELECT 1 FROM "products" WHERE "product_name" = 'Smartphone Pro'
);

INSERT INTO "products" ("product_name", "price", "quantity_in_stock", "status", "id_category")
SELECT 'Bluetooth Headphones', '120.00', '50', 'in_stock', id 
FROM "category" 
WHERE category_name = 'Electronics'
AND NOT EXISTS (
    SELECT 1 FROM "products" WHERE "product_name" = 'Bluetooth Headphones'
);

INSERT INTO "products" ("product_name", "price", "quantity_in_stock", "status", "id_category")
SELECT 'Football', '25.99', '10', 'in_stock', id 
FROM "category" 
WHERE category_name = 'Sport'
AND NOT EXISTS (
    SELECT 1 FROM "products" WHERE "product_name" = 'Football'
);

INSERT INTO "products" ("product_name", "price", "quantity_in_stock", "status", "id_category")
SELECT 'Basketball', '22.50', '12', 'in_stock', id 
FROM "category" 
WHERE category_name = 'Sport'
AND NOT EXISTS (
    SELECT 1 FROM "products" WHERE "product_name" = 'Basketball'
);

INSERT INTO "products" ("product_name", "price", "quantity_in_stock", "status", "id_category")
SELECT 'Yoga Mat', '30.00', '20', 'in_stock', id 
FROM "category" 
WHERE category_name = 'Sport'
AND NOT EXISTS (
    SELECT 1 FROM "products" WHERE "product_name" = 'Yoga Mat'
);

INSERT INTO "products" ("product_name", "price", "quantity_in_stock", "status", "id_category")
SELECT 'Blender', '45.75', '14', 'in_stock', id 
FROM "category" 
WHERE category_name = 'Kitchen'
AND NOT EXISTS (
    SELECT 1 FROM "products" WHERE "product_name" = 'Blender'
);

INSERT INTO "products" ("product_name", "price", "quantity_in_stock", "status", "id_category")
SELECT 'Coffee Maker', '89.99', '9', 'in_stock', id 
FROM "category" 
WHERE category_name = 'Kitchen'
AND NOT EXISTS (
    SELECT 1 FROM "products" WHERE "product_name" = 'Coffee Maker'
);

INSERT INTO "products" ("product_name", "price", "quantity_in_stock", "status", "id_category")
SELECT 'Wine Glass Set', '35.50', '18', 'in_stock', id 
FROM "category" 
WHERE category_name = 'Kitchen'
AND NOT EXISTS (
    SELECT 1 FROM "products" WHERE "product_name" = 'Wine Glass Set'
);

INSERT INTO "products" ("product_name", "price", "quantity_in_stock", "status", "id_category")
SELECT 'Orange Juice', '3.99', '100', 'in_stock', id 
FROM "category" 
WHERE category_name = 'Drinks'
AND NOT EXISTS (
    SELECT 1 FROM "products" WHERE "product_name" = 'Orange Juice'
);

INSERT INTO "products" ("product_name", "price", "quantity_in_stock", "status", "id_category")
SELECT 'Green Tea', '5.50', '80', 'in_stock', id 
FROM "category" 
WHERE category_name = 'Drinks'
AND NOT EXISTS (
    SELECT 1 FROM "products" WHERE "product_name" = 'Green Tea'
);

INSERT INTO "products" ("product_name", "price", "quantity_in_stock", "status", "id_category")
SELECT 'Cola Soda', '1.50', '200', 'in_stock', id 
FROM "category" 
WHERE category_name = 'Drinks'
AND NOT EXISTS (
    SELECT 1 FROM "products" WHERE "product_name" = 'Cola Soda'
);
