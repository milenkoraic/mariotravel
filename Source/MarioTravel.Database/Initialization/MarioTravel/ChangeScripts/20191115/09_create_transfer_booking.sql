
-- ----------------------------
-- Table structure for transfer_booking
-- ----------------------------
DROP TABLE IF EXISTS "public"."transfer_booking";
CREATE TABLE "public"."transfer_booking" (
  "id" SERIAL NOT NULL,
  "transfer_id"
  INTEGER                 
  NOT NULL,
  "date" date NOT NULL,
  "time_of_day" time(6) NOT NULL,
  "from_location" text,
  "to_location" text,
  "transfer_distance" text,
  "transfer_duration" text,
  "number_of_persons" INTEGER NOT NULL,
  "full_name" text NOT NULL,
  "phone" text NOT NULL,
  "email" text NOT NULL,
  "additional_info" text,
  "total_price" numeric(1000,2) NOT NULL,
  "deposit_price" numeric(1000,2),
  "to_be_charged" numeric(1000,2),
  "external_id" uuid NOT NULL,
  "raw_payment_response" text   ,
  "created_at" timestamptz(6) NOT NULL,
  "send_not_completed_notification" bool NOT NULL,
  "application_id" INTEGER NOT NULL
);

-- ----------------------------
-- Primary Key structure for table transfer_booking
-- ----------------------------
ALTER TABLE "public"."transfer_booking" ADD CONSTRAINT "transfer_booking_pkey" PRIMARY KEY ("id");