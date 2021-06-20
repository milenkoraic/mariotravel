
-- ----------------------------
-- Table structure for tour_time
-- ----------------------------
DROP TABLE IF EXISTS "public"."tour_time";
CREATE TABLE "public"."tour_time" (
  "id" SERIAL  NOT NULL,
  "tour_id" 
  INTEGER 
  NOT NULL
  CONSTRAINT tour_time_tour_id_fkey
  REFERENCES tour,
  "tour_type_id" INTEGER NOT NULL,
  "is_active" bool NOT NULL,
  "start_at" time(6) NOT NULL,
  "application_id" INT NOT NULL,
  "date_created" timestamptz(6) NOT NULL,
  "date_updated" timestamptz(6) NOT NULL
);

-- ----------------------------
-- Records of tour_time
-- ----------------------------
INSERT INTO "public"."tour_time" VALUES (13, 24, 2, 'f', '15:00:00', 1, '2018-04-29 18:39:19.860938+00', '2018-04-29 18:39:19.860938+00');
INSERT INTO "public"."tour_time" VALUES (11, 27, 1, 't', '09:30:00', 1, '2018-04-29 18:39:19.860938+00', '2018-04-29 18:39:19.860938+00');
INSERT INTO "public"."tour_time" VALUES (17, 35, 1, 't', '12:00:00', 1, '2018-04-29 18:39:19.860938+00', '2018-04-29 18:39:19.860938+00');
INSERT INTO "public"."tour_time" VALUES (18, 35, 1, 't', '13:00:00', 1, '2018-04-29 18:39:19.860938+00', '2018-04-29 18:39:19.860938+00');
INSERT INTO "public"."tour_time" VALUES (19, 35, 1, 't', '15:00:00', 1, '2018-04-29 18:39:19.860938+00', '2018-04-29 18:39:19.860938+00');
INSERT INTO "public"."tour_time" VALUES (1, 35, 1, 't', '17:00:00', 1, '2018-04-29 18:39:19.860938+00', '2018-04-29 18:39:19.860938+00');
INSERT INTO "public"."tour_time" VALUES (2, 39, 1, 't', '10:00:00', 1, '2018-04-29 18:39:19.860938+00', '2018-04-29 18:39:19.860938+00');
INSERT INTO "public"."tour_time" VALUES (3, 39, 1, 't', '12:00:00', 1, '2018-04-29 18:39:19.860938+00', '2018-04-29 18:39:19.860938+00');
INSERT INTO "public"."tour_time" VALUES (7, 39, 1, 't', '15:00:00', 1, '2018-04-29 18:39:19.860938+00', '2018-04-29 18:39:19.860938+00');
INSERT INTO "public"."tour_time" VALUES (8, 39, 1, 'f', '18:00:00', 1, '2018-04-29 18:39:19.860938+00', '2018-04-29 18:39:19.860938+00');
INSERT INTO "public"."tour_time" VALUES (9, 40, 1, 't', '14:30:00', 1, '2018-04-29 18:39:19.860938+00', '2018-04-29 18:39:19.860938+00');
INSERT INTO "public"."tour_time" VALUES (22, 41, 1, 't', '10:00:00', 1, '2018-04-29 18:39:19.860938+00', '2018-04-29 18:39:19.860938+00');
INSERT INTO "public"."tour_time" VALUES (24, 41, 1, 't', '15:30:00', 1, '2018-04-29 18:39:19.860938+00', '2018-04-29 18:39:19.860938+00');
INSERT INTO "public"."tour_time" VALUES (6, 41, 1, 't', '12:30:00', 1, '2018-04-29 18:39:19.860938+00', '2018-04-29 18:39:19.860938+00');
INSERT INTO "public"."tour_time" VALUES (15, 43, 1, 't', '09:30:00', 1, '2018-04-29 18:39:19.860938+00', '2018-04-29 18:39:19.860938+00');
INSERT INTO "public"."tour_time" VALUES (16, 43, 1, 't', '07:40:00', 1, '2018-04-29 18:39:19.860938+00', '2018-04-29 18:39:19.860938+00');

-- ----------------------------
-- Primary Key structure for table tour_time
-- ----------------------------
ALTER TABLE "public"."tour_time" ADD CONSTRAINT "tour_time_pkey" PRIMARY KEY ("id");