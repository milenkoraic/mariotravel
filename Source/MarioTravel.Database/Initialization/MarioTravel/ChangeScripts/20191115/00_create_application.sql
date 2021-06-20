
-- ----------------------------
-- Table structure for application
-- ----------------------------
DROP TABLE IF EXISTS "public"."application";
CREATE TABLE "public"."application" (
  "id" SERIAL NOT NULL,
  "application_name" text NOT NULL,
  "is_active" bool NOT NULL,
  "date_created" timestamptz(6) NOT NULL,
  "date_updated" timestamptz(6) NOT NULL
);

-- ----------------------------
-- Records of application
-- ----------------------------
INSERT INTO "public"."application" VALUES (1, 'Dubrovnik Tours', 't', '2019-12-23 18:00:19.867286+00', '2019-12-23 18:00:19.867286+00');
INSERT INTO "public"."application" VALUES (2, 'Zagreb Tours', 't', '2019-12-23 18:00:19.867286+00', '2019-12-23 18:00:19.867286+00');
INSERT INTO "public"."application" VALUES (3, 'Split Tours', 't', '2019-12-23 18:00:19.867286+00', '2019-12-23 18:00:19.867286+00');
INSERT INTO "public"."application" VALUES (4, 'Cable Car Dubrovnik', 't', '2019-12-23 18:00:19.867286+00', '2019-12-23 18:00:19.867286+00');

-- ----------------------------
-- Primary Key structure for table application
-- ----------------------------
ALTER TABLE "public"."application" ADD CONSTRAINT "application_pkey" PRIMARY KEY ("id");