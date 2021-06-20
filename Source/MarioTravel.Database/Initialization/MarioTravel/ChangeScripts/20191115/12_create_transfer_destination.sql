
-- ----------------------------
-- Table structure for transfer_destination
-- ----------------------------
DROP TABLE IF EXISTS "public"."transfer_destination";
CREATE TABLE "public"."transfer_destination" (
  "id" SERIAL NOT NULL,
  "destination_id" SERIAL NOT NULL,
  "destination_name" text NOT NULL,
  "destination_address" text NOT NULL,
  "application_id" INT NOT NULL,
  "is_active" bool NOT NULL,
  "date_created" timestamptz(6)  NOT NULL,
  "date_updated" timestamptz(6)  NOT NULL
);

-- ----------------------------
-- Records of transfer_destination
-- ----------------------------

INSERT INTO "public"."transfer_destination" VALUES (
1, 
1,
'DUBROVNIK',
'Dubrovnik, Hrvatska',
1,
't',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00');

INSERT INTO "public"."transfer_destination" VALUES (
2,
2, 
'CAVTAT',
'Cavtat, Hrvatska',
1,
't',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00');

INSERT INTO "public"."transfer_destination" VALUES (
3, 
3,
'PLAT',
'Plat, Hrvatska',
1,
't',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00');

INSERT INTO "public"."transfer_destination" VALUES (
4, 
4,
'ČILIPI',
'Čilipi, Hrvatska',
1,
't',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00');

INSERT INTO "public"."transfer_destination" VALUES (
5, 
5,
'GRUDA',
'Gruda, Hrvatska',
1,
't',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00');

INSERT INTO "public"."transfer_destination" VALUES (
6, 
6,
'SREBRENO',
'Srebreno, Hrvatska',
1,
't',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00');

INSERT INTO "public"."transfer_destination" VALUES (
7, 
7,
'MLINI',
'Mlini, Hrvatska',
1,
't',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00');

INSERT INTO "public"."transfer_destination" VALUES (
8, 
8,
'KUPARI',
'Kupari, Hrvatska',
1,
't',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00');

INSERT INTO "public"."transfer_destination" VALUES (
9, 
9,
'LOZICA',
'Lozica, Hrvatska',
1,
't',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00');

INSERT INTO "public"."transfer_destination" VALUES (
10, 
10,
'ORAŠAC',
'Orašac, Hrvatska',
1,
't',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00');

INSERT INTO "public"."transfer_destination" VALUES (
11, 
11,
'TRSTENO',
'Trsteno, Hrvatska',
1,
't',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00');

-- ----------------------------
-- Primary Key structure for table transfer_destination
-- ----------------------------
ALTER TABLE "public"."transfer_destination" ADD CONSTRAINT "transfer_destination_pkey" PRIMARY KEY ("id");