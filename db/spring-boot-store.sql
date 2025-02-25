CREATE TYPE "order_status" AS ENUM (
  'delivered',
  'order_placed',
  'en_route',
  'cancelled'
);

CREATE TYPE "current_status" AS ENUM (
  'in_stock',
  'out_of_stock',
  'low'
);

CREATE TABLE "users" (
  "id" SERIAL PRIMARY KEY,
  "username" varchar NOT NULL,
  "email" varchar UNIQUE NOT NULL,
  "password" varchar NOT NULL
);

CREATE TABLE "address" (
  "id" SERIAL PRIMARY KEY,
  "street" varchar NOT NULL,
  "street_number" int NOT NULL,
  "country" varchar NOT NULL,
  "surname" varchar NOT NULL,
  "name" varchar NOT NULL,
  "phone_number" varchar,
  "email" varchar,
  "is_default" boolean DEFAULT true,
  "user_id" int NOT NULL
);

CREATE TABLE "orders_client" (
  "id" SERIAL PRIMARY KEY,
  "id_user" int NOT NULL,
  "status" order_status DEFAULT 'order_placed',
  "created_at" timestamp DEFAULT (CURRENT_TIMESTAMP)
);

CREATE TABLE "order_list" (
  "id_order" int NOT NULL,
  "id_product" int NOT NULL,
  "quantity" int DEFAULT 1,
  "price_at_order" double precision DEFAULT 0,
  PRIMARY KEY ("id_order", "id_product")
);

CREATE TABLE "products" (
  "id" SERIAL PRIMARY KEY,
  "product_name" varchar NOT NULL,
  "price" double precision DEFAULT 0,
  "quantity_in_stock" int NOT NULL DEFAULT 0,
  "status" current_status DEFAULT 'out_of_stock',
  "id_category" int
);


CREATE TABLE "category" (
  "id" SERIAL PRIMARY KEY,
  "category_name" varchar NOT NULL,
  "subcategory_id" int DEFAULT null
);

ALTER TABLE "address" ADD FOREIGN KEY ("user_id") REFERENCES "users" ("id") ON DELETE CASCADE;

ALTER TABLE "orders_client" ADD FOREIGN KEY ("id_user") REFERENCES "users" ("id") ON DELETE CASCADE;

ALTER TABLE "order_list" ADD FOREIGN KEY ("id_order") REFERENCES "orders_client" ("id") ON DELETE CASCADE;

ALTER TABLE "order_list" ADD FOREIGN KEY ("id_product") REFERENCES "products" ("id") ON DELETE CASCADE;

ALTER TABLE "products" ADD FOREIGN KEY ("id_category") REFERENCES "category" ("id") ON DELETE CASCADE;

ALTER TABLE "category" ADD FOREIGN KEY ("subcategory_id") REFERENCES "category" ("id") ON DELETE SET NULL;