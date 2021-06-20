
-- ----------------------------
-- Table structure for tour_language
-- ----------------------------
DROP TABLE IF EXISTS "public"."tour_language";
CREATE TABLE "public"."tour_language" (
  "id" SERIAL NOT NULL,
  "culture_name" varchar(10) NOT NULL,
  "name" varchar(255) NOT NULL,
  "date_created" timestamptz(6) NOT NULL,
  "date_updated" timestamptz(6) NOT NULL,
  "application_id" INTEGER NOT NULL
);

-- ----------------------------
-- Records of tour_language
-- ----------------------------
INSERT INTO "public"."tour_language" VALUES (1, 'en-US', 'ENG', '2018-04-29 18:39:19.890426+00', '2018-04-29 18:39:19.890426+00', 1);
INSERT INTO "public"."tour_language" VALUES (2, 'es', 'ESP', '2018-04-29 18:39:19.893847+00', '2018-04-29 18:39:19.893847+00', 1);

-- ----------------------------
-- Primary Key structure for table tour_language
-- ----------------------------
ALTER TABLE "public"."tour_language" ADD CONSTRAINT "tour_language_pkey" PRIMARY KEY ("id");