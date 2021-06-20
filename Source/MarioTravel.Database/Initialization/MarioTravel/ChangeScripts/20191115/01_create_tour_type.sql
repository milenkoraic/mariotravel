-- ----------------------------
-- Table structure for tour_type
-- ----------------------------
DROP TABLE IF EXISTS "public"."tour_type";
CREATE TABLE "public"."tour_type" (
  "id" SERIAL NOT NULL,
  "name" text NOT NULL,
  "is_active" bool NOT NULL,
  "date_created" timestamptz(6) NOT NULL,
  "date_updated" timestamptz(6) NOT NULL,
  "application_id" INTEGER NOT NULL
);

-- ----------------------------
-- Records of tour_type
-- ----------------------------
INSERT INTO "public"."tour_type" VALUES (1, 'scheduled', 't', '2018-04-29 18:39:19.860938+00', '2018-04-29 18:39:19.860938+00', 1);
INSERT INTO "public"."tour_type" VALUES (2, 'private', 't', '2018-04-29 18:39:19.867286+00', '2018-04-29 18:39:19.867286+00', 1);
-- ----------------------------
-- Primary Key structure for table tour_type
-- ----------------------------
ALTER TABLE "public"."tour_type" ADD CONSTRAINT "tour_type_pkey" PRIMARY KEY ("id");