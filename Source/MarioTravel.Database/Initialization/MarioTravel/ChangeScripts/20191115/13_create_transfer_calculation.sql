
-- ----------------------------
-- Table structure for transfer_calculation
-- ----------------------------
DROP TABLE IF EXISTS "public"."transfer_calculation";
CREATE TABLE "public"."transfer_calculation" (
  "id" SERIAL NOT NULL,
  "airport_id" INTEGER NOT NULL,
  "destination_id" INTEGER NOT NULL,
  "distance" NUMERIC (10,2),
  "duration" text NOT NULL,
  "date_created" timestamptz(6)  NOT NULL,
  "date_updated" timestamptz(6)  NOT NULL,
	"application_id" INT NOT NULL
);

-- ----------------------------
-- Records of transfer_calculation
-- ----------------------------

-- ----------------------------
-- DUBROVNIK AIRPORT CALCULATIONS 1-11
-- ----------------------------

INSERT INTO "public"."transfer_calculation" VALUES (
1, 
1,
1,
20.54,
'27 min',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00', 
1);

INSERT INTO "public"."transfer_calculation" VALUES (
2, 
1,
2,
5.63,
'9 min',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00', 
1);

INSERT INTO "public"."transfer_calculation" VALUES (
3, 
1,
3,
8.24,
'11 min',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00', 
1);

INSERT INTO "public"."transfer_calculation" VALUES (
4, 
1,
4,
2.25,
'4 min',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00', 
1);

INSERT INTO "public"."transfer_calculation" VALUES (
5, 
1,
5,
10.70,
'12 min',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00',
1);

INSERT INTO "public"."transfer_calculation" VALUES (
6, 
1,
6,
10.80,
'14 min',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00',
1);

INSERT INTO "public"."transfer_calculation" VALUES (
7, 
1,
7,
11.57,
'16 min',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00', 
1);

INSERT INTO "public"."transfer_calculation" VALUES (
8, 
1,
8,
13.84,
'18 min',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00',
1);

INSERT INTO "public"."transfer_calculation" VALUES (
9, 
1,
9,
23.69,
'29 min',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00', 
1);

INSERT INTO "public"."transfer_calculation" VALUES (
10, 
1,
10,
34.18,
'42 min',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00', 
1);

INSERT INTO "public"."transfer_calculation" VALUES (
11, 
1,
11,
36.73,
'44 min',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00', 
1);

-- ----------------------------
-- SPLIT AIRPORT CALCULATIONS 12-22
-- ----------------------------

INSERT INTO "public"."transfer_calculation" VALUES (
12, 
2,
1,
241.62,
'3h 12 min',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00', 
1);

INSERT INTO "public"."transfer_calculation" VALUES (
13, 
2,
2,
259.27,
'3h 33 min',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00', 
1);

INSERT INTO "public"."transfer_calculation" VALUES (
14, 
2,
3,
252.37,
'3h 24 min',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00', 
1);

INSERT INTO "public"."transfer_calculation" VALUES (
15, 
2,
4,
261.49,
'3h 34 min',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00', 
1);

INSERT INTO "public"."transfer_calculation" VALUES (
16, 
2,
5,
269.94,
'3h 42 min',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00', 
1);

INSERT INTO "public"."transfer_calculation" VALUES (
17, 
2,
6,
248.75,
'3h 19 min',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00', 
1);

INSERT INTO "public"."transfer_calculation" VALUES (
18, 
2,
7,
249.76,
'3h 22 min',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00', 
1);

INSERT INTO "public"."transfer_calculation" VALUES (
19, 
2,
8,
247.83,
'3h 17 min',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00', 
1);

INSERT INTO "public"."transfer_calculation" VALUES (
20, 
2,
9,
235.86,
'3h 3 min',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00', 
1);

INSERT INTO "public"."transfer_calculation" VALUES (
21, 
2,
10,
226.73,
'2h 53 min',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00',
1);

INSERT INTO "public"."transfer_calculation" VALUES (
22, 
2,
11,
222.81,
'2h 48 min',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00',
1);

-- ----------------------------
-- TIVAT AIRPORT CALCULATIONS 23-33
-- ----------------------------

INSERT INTO "public"."transfer_calculation" VALUES (
23, 
3,
1,
70.88,
'2h 3 min',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00', 
1);

INSERT INTO "public"."transfer_calculation" VALUES (
24, 
3,
2,
55.97,
'1h 45 min',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00', 
1);

INSERT INTO "public"."transfer_calculation" VALUES (
25, 
3,
3,
58.59,
'1h 49 min',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00', 
1);

INSERT INTO "public"."transfer_calculation" VALUES (
26, 
3,
4,
50.10,
'1h 37 min',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00', 
1);

INSERT INTO "public"."transfer_calculation" VALUES (
27, 
3,
5,
40.23,
'1h 28 min',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00',
1);

INSERT INTO "public"."transfer_calculation" VALUES (
28, 
3,
6,
61.14,
'1h 49 min',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00',
1);

INSERT INTO "public"."transfer_calculation" VALUES (
29, 
3,
7,
61.91,
'1h 52 min',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00',
1);

INSERT INTO "public"."transfer_calculation" VALUES (
30, 
3,
8,
65.52,
'2h 8 min',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00', 
1);

INSERT INTO "public"."transfer_calculation" VALUES (
31, 
3,
9,
74.03,
'2h 5 min',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00',
1);

INSERT INTO "public"."transfer_calculation" VALUES (
32, 
3,
10,
84.52,
'2h 18 min',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00', 
1);

INSERT INTO "public"."transfer_calculation" VALUES (
33, 
3,
11,
87.08,
'2h 19 min',
'2019-12-10 09:49:29.455954+00',
'2019-12-10 09:49:29.455954+00',
1);

-- ----------------------------
-- Primary Key structure for table transfer_calculation
-- ----------------------------
ALTER TABLE "public"."transfer_calculation" ADD CONSTRAINT "transfer_calculation_pkey" PRIMARY KEY ("id");
