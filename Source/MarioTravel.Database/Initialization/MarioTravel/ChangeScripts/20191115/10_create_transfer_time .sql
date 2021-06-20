
-- ----------------------------
-- Table structure for transfer_time
-- ----------------------------
DROP TABLE IF EXISTS "public"."transfer_time";
CREATE TABLE "public"."transfer_time" (
  "id" SERIAL  NOT NULL,
  "transfer_id" 
  INTEGER 
  NOT NULL
  CONSTRAINT transfer_time_transfer_id_fkey
  REFERENCES tour,
  "is_active" bool NOT NULL,
  "start_at" time(6) NOT NULL,
  "application_id" INT NOT NULL,
  "date_created" timestamptz(6) NOT NULL,
  "date_updated" timestamptz(6) NOT NULL
);

-- ----------------------------
-- Primary Key structure for table transfer_time
-- ----------------------------
ALTER TABLE "public"."transfer_time" ADD CONSTRAINT "transfer_time_pkey" PRIMARY KEY ("id");