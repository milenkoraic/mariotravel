
-- ----------------------------
-- Table structure for transfer_airport
-- ----------------------------
DROP TABLE IF EXISTS "public"."transfer_airport";
CREATE TABLE "public"."transfer_airport" (
  "id" SERIAL NOT NULL,
  "airport_id" SERIAL NOT NULL,
  "airport_name" text NOT NULL,
  "airport_address" text NOT NULL,
  "application_id" INT NOT NULL,
  "is_active" bool NOT NULL,
  "date_created" timestamptz(6)  NOT NULL,
  "date_updated" timestamptz(6)  NOT NULL
);

-- ----------------------------
-- Records of transfer_airport
-- ----------------------------

INSERT INTO "public"."transfer_airport" VALUES (
1, 
1,
'DUBROVNIK, CROATIA',
'Zračna luka Dubrovnik d.o.o, Čilipi, Hrvatska',
1,
't',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00');

INSERT INTO "public"."transfer_airport" VALUES (
2, 
2,
'SPLIT, CROATIA',
'Zračna luka Split, Cesta Doktor Franje Tuđmana, Kaštel Štafilić, Hrvatska',
1,
't',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00');

INSERT INTO "public"."transfer_airport" VALUES (
3, 
3,
'TIVAT, MONTENEGRO',
'Tivat Airport, Narodnih Heroja, Tivat, Crna Gora',
1,
't',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00');


-- ----------------------------
-- Primary Key structure for table transfer_airport
-- ----------------------------
ALTER TABLE "public"."transfer_airport" ADD CONSTRAINT "transfer_airport_pkey" PRIMARY KEY ("id");