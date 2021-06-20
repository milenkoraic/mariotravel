
-- ----------------------------
-- Table structure for transfer
-- ----------------------------
DROP TABLE IF EXISTS "public"."transfer";
CREATE TABLE "public"."transfer" (
  "id" SERIAL NOT NULL,
  "title" text NOT NULL,
  "is_active" bool NOT NULL,
  "discount_percent" numeric(1000,2),
  "slug" text NOT NULL,
  "small_group_transfer_price" numeric(1000,2)  NOT NULL,
  "medium_group_transfer_price" numeric(1000,2)  NOT NULL,
  "suv_start_price_small" numeric(1000,2)  NOT NULL,
  "van_start_price_small" numeric(1000,2)  NOT NULL,
  "suv_start_price_large" numeric(1000,2)  NOT NULL,
  "van_start_price_large" numeric(1000,2)  NOT NULL,
  "date_created" timestamptz(6)  NOT NULL,
  "date_updated" timestamptz(6)  NOT NULL,
  "application_id" INTEGER NOT NULL
);

-- ----------------------------
-- Records of transfer
-- ----------------------------

INSERT INTO "public"."transfer" VALUES (
1, 
'TRANSFER SERVICE',
't',
0,
'transfer', 
10.00,
13.50, 
30.00,
40.00,
55.00,
70.00,
'2019-10-27 09:49:29.455954+00',
'2019-10-27 09:49:29.455954+00',
1);

-- ----------------------------
-- Primary Key structure for table tour
-- ----------------------------
ALTER TABLE "public"."transfer" ADD CONSTRAINT "transfer_pkey" PRIMARY KEY ("id");