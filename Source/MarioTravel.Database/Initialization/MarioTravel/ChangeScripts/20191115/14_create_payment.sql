
-- ----------------------------
-- Table structure for payment
-- ----------------------------
DROP TABLE IF EXISTS "public"."payment";
CREATE TABLE "public"."payment" (
  "id" SERIAL NOT NULL 
  CONSTRAINT payment_pkey
  PRIMARY KEY ,
  "external_payment_id" uuid NOT NULL,
  "booking_external_id" uuid NOT NULL,
  "type" text,
  "status" text,
  "receipt_url" text,
  "amount" text,
  "currency" text,
  "approval_code" text,
  "processing_code" text,
  "card_brand" text,
  "card_masked_pan" text,
  "card_cardholder_name" text,
  "card_fingerprint" uuid,
  "external_created_at" timestamptz(6),
  "signature_order" text,
  "signature" text,
  "is_valid" bool NOT NULL,
  "created_at" timestamptz(6),
  "application_id" INTEGER NOT NULL
);
