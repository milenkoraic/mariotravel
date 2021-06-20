
-- ----------------------------
-- Table structure for booking
-- ----------------------------
DROP TABLE IF EXISTS "public"."tour_booking";
CREATE TABLE "public"."tour_booking" (
  "id" SERIAL NOT NULL,
  "tour_id" INTEGER                 
  NOT NULL,
  "date" date,
  "time_of_day" time(6),
  "duration" numeric(10,2),
  "number_of_persons" int4,
  "full_name" text,
  "phone" text,
  "email" text,
  number_of_children INTEGER,
  number_of_babies INTEGER,
  pick_up_point text,
  "additional_info" text,
  "total_price" numeric(10,2),
  "external_id" uuid,
  "raw_payment_response" text,
  "created_at" timestamptz(6),
  "send_not_completed_notification" bool NOT NULL,
  "deposit_price" numeric(10,2),
  "to_be_charged" numeric(10,2),
  "application_id" INTEGER NOT NULL
);

