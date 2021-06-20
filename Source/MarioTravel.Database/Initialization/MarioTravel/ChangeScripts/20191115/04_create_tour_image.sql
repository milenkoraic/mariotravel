
-- ----------------------------
-- Table structure for tour_image
-- ----------------------------
DROP TABLE IF EXISTS "public"."tour_image";
CREATE TABLE "public"."tour_image" (
  "id" SERIAL NOT NULL,
  "tour_id"  
  INTEGER                 
  NOT NULL
  CONSTRAINT tour_image_tour_id_fkey
  REFERENCES tour,
  "is_active" bool NOT NULL,
  "url" text NOT NULL,
  "alt_description" text NOT NULL,
  "ordinal" INTEGER NOT NULL,
  "application_id" INT NOT NULL,
  "date_created" timestamptz(6) NOT NULL,
  "date_updated" timestamptz(6) NOT NULL
);

-- ----------------------------
-- Records of tour_image
-- ----------------------------

INSERT INTO "public"."tour_image" VALUES (1, 20, 't', 'tour_20_image_1.jpg', 'Private Game of Thrones driving tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (2, 20, 't', 'tour_20_image_2.jpg', 'Private Game of Thrones driving tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (3, 20, 't', 'tour_20_image_3.jpg', 'Private Game of Thrones driving tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (4, 20, 't', 'tour_20_image_4.jpg', 'Private Game of Thrones driving tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (6, 20, 't', 'tour_20_image_5.jpg', 'Private Game of Thrones driving tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (7, 20, 'f', 'tour_20_image_6.jpg', 'Private Game of Thrones driving tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (8, 20, 't', 'tour_20_image_7.jpg', 'Private Game of Thrones driving tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (9, 20, 't', 'tour_20_image_8.jpg', 'Private Game of Thrones driving tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (10, 20, 't', 'tour_20_image_9.jpg', 'Private Game of Thrones driving tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (12,  20, 't', 'tour_20_image_10.jpg', 'Private Game of Thrones driving tour', 0, 1, '2019-07-10 18:00:55+00', '2019-07-10 18:00:55+00');
INSERT INTO "public"."tour_image" VALUES (13,  20, 't', 'tour_20_image_11.jpg', 'Private Game of Thrones driving tour', 0, 1, '2019-07-10 18:00:55+00', '2019-07-10 18:00:55+00');
INSERT INTO "public"."tour_image" VALUES (14,  20, 't', 'tour_20_image_12.jpg', 'Private Game of Thrones driving tour', 0, 1, '2019-07-10 18:00:55+00', '2019-07-10 18:00:55+00');
INSERT INTO "public"."tour_image" VALUES (15,  20, 't', 'tour_20_image_13.jpg', 'Private Game of Thrones driving tour', 0, 1, '2019-07-10 18:00:55+00', '2019-07-10 18:00:55+00');
INSERT INTO "public"."tour_image" VALUES (16,  20, 't', 'tour_20_image_14.jpg', 'Private Game of Thrones driving tour', 0, 1, '2019-07-10 18:00:55+00', '2019-07-10 18:00:55+00');

INSERT INTO "public"."tour_image" VALUES (18, 21, 't', 'tour_21_image_1.jpg', 'Private Game Of Thrones + Iron throne walking tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (25, 21, 't', 'tour_21_image_8.jpg', 'Private Game Of Thrones + Iron throne walking tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (26, 21, 'f', 'tour_21_image_9.jpg', 'Private Game Of Thrones + Iron throne walking tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (27, 21, 't', 'tour_21_image_10.jpg', 'Private Game Of Thrones + Iron throne walking tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (28, 21, 't', 'tour_21_image_11.jpg', 'Private Game Of Thrones + Iron throne walking tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (30, 21, 't', 'tour_21_image_13.jpg', 'Private Game Of Thrones + Iron throne walking tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (32, 21, 't', 'tour_21_image_15.jpg', 'Private Game Of Thrones + Iron throne walking tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (33, 21, 't', 'tour_21_image_16.jpg', 'Private Game Of Thrones + Iron throne walking tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (34, 21, 't', 'tour_21_image_17.jpg', 'Private Game Of Thrones + Iron throne walking tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (35, 21, 't', 'tour_21_image_18.jpg', 'Private Game Of Thrones + Iron throne walking tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (36, 21, 't', 'tour_21_image_19.jpg', 'Private Game Of Thrones + Iron throne walking tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (37, 21, 't', 'tour_21_image_20.jpg', 'Private Game Of Thrones + Iron throne walking tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (38, 21, 't', 'tour_21_image_21.jpg', 'Private Game Of Thrones + Iron throne walking tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (39, 21, 't', 'tour_21_image_22.jpg', 'Private Game Of Thrones + Iron throne walking tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (40, 21, 't', 'tour_21_image_23.jpg', 'Private Game Of Thrones + Iron throne walking tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (41, 21, 't', 'tour_21_image_24.jpg', 'Private Game Of Thrones + Iron throne walking tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (42, 21, 't', 'tour_21_image_25.jpg', 'Private Game Of Thrones + Iron throne walking tour', 1, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (43, 21, 't', 'tour_21_image_26.jpg', 'Private Game Of Thrones + Iron throne walking tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (44,  21, 't', 'tour_21_image_27.jpg', 'Private Game Of Thrones + Iron throne walking tour', 0, 1, '2119-07-10 18:00:55+00', '2119-07-10 18:00:55+00');
INSERT INTO "public"."tour_image" VALUES (45,  21, 't', 'tour_21_image_28.jpg', 'Private Game Of Thrones + Iron throne walking tour', 0, 1, '2119-07-10 18:00:55+00', '2119-07-10 18:00:55+00');
INSERT INTO "public"."tour_image" VALUES (46,  21, 't', 'tour_21_image_29.jpg', 'Private Game Of Thrones + Iron throne walking tour', 0, 1, '2119-07-10 18:00:55+00', '2119-07-10 18:00:55+00');
INSERT INTO "public"."tour_image" VALUES (47,  21, 't', 'tour_21_image_30.jpg', 'Private Game Of Thrones + Iron throne walking tour', 0, 1, '2119-07-10 18:00:55+00', '2119-07-10 18:00:55+00');
INSERT INTO "public"."tour_image" VALUES (49,  21, 't', 'tour_21_image_31.jpg', 'Private Game Of Thrones + Iron throne walking tour', 0, 1, '2119-07-10 18:00:55+00', '2119-07-10 18:00:55+00');
INSERT INTO "public"."tour_image" VALUES (50,  21, 't', 'tour_21_image_32.jpg', 'Private Game Of Thrones + Iron throne walking tour', 0, 1, '2119-07-10 18:00:55+00', '2119-07-10 18:00:55+00');

INSERT INTO "public"."tour_image" VALUES (51, 23, 't', 'tour_23_image_1.jpg', 'Private tour City walls of Dubrovnik ', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (52, 23, 't', 'tour_23_image_2.jpg', 'Private tour City walls of Dubrovnik ', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (53, 23, 't', 'tour_23_image_3.jpg', 'Private tour City walls of Dubrovnik ', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (54, 23, 't', 'tour_23_image_4.jpg', 'Private tour City walls of Dubrovnik ', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (55, 23, 't', 'tour_23_image_5.jpg', 'Private tour City walls of Dubrovnik ', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (56, 23, 't', 'tour_23_image_6.jpg', 'Private tour City walls of Dubrovnik ', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (57, 23, 't', 'tour_23_image_7.jpg', 'Private tour City walls of Dubrovnik ', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (59, 23, 't', 'tour_23_image_9.jpg', 'Private tour City walls of Dubrovnik ', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (60, 23, 't', 'tour_23_image_10.jpg','Private tour City walls of Dubrovnik ', 1, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');

INSERT INTO "public"."tour_image" VALUES (61, 24, 't', 'tour_24_image_1.jpg', 'Private tour Discover Dubrovnik Old Town', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (62, 24, 't', 'tour_24_image_2.jpg', 'Private tour Discover Dubrovnik Old Town', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (63, 24, 't', 'tour_24_image_3.jpg', 'Private tour Discover Dubrovnik Old Town', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (64, 24, 't', 'tour_24_image_4.jpg', 'Private tour Discover Dubrovnik Old Town', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (65, 24, 't', 'tour_24_image_5.jpg', 'Private tour Discover Dubrovnik Old Town', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (67, 24, 't', 'tour_24_image_7.jpg', 'Private tour Discover Dubrovnik Old Town', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (68, 24, 't', 'tour_24_image_8.jpg', 'Private tour Discover Dubrovnik Old Town', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (69, 24, 't', 'tour_24_image_9.jpg', 'Private tour Discover Dubrovnik Old Town', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (70, 24, 't', 'tour_24_image_10.jpg', 'Private tour Discover Dubrovnik Old Town', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (71, 24, 't', 'tour_24_image_11.jpg', 'Private tour Discover Dubrovnik Old Town', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (72, 24, 't', 'tour_24_image_12.jpg', 'Private tour Discover Dubrovnik Old Town', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (75, 24, 't', 'tour_24_image_14.jpg', 'Private tour Discover Dubrovnik Old Town', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (76, 24, 't', 'tour_24_image_15.jpg', 'Private tour Discover Dubrovnik Old Town', 1, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');

INSERT INTO "public"."tour_image" VALUES (77, 25, 't', 'tour_25_image_1.jpg', 'Private tour Discover Old town including Srđ hill and pick up', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (78, 25, 't', 'tour_25_image_2.jpg', 'Private tour Discover Old town including Srđ hill and pick up', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (80, 25, 't', 'tour_25_image_3.jpg', 'Private tour Discover Old town including Srđ hill and pick up', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (81, 25, 't', 'tour_25_image_4.jpg', 'Private tour Discover Old town including Srđ hill and pick up', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (87, 25, 't', 'tour_25_image_10.jpg', 'Private tour Discover Old town including Srđ hill and pick up', 1, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');

INSERT INTO "public"."tour_image" VALUES (95,  27, 't', 'tour_27_image_1.jpg', 'Juego de tronos tour + Recorrido por la Ciudad antigua de Dubrovnik', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (96,  27, 't', 'tour_27_image_2.jpg', 'Juego de tronos tour + Recorrido por la Ciudad antigua de Dubrovnik', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (97,  27, 't', 'tour_27_image_3.jpg', 'Juego de tronos tour + Recorrido por la Ciudad antigua de Dubrovnik', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (98,  27, 't', 'tour_27_image_4.jpg', 'Juego de tronos tour + Recorrido por la Ciudad antigua de Dubrovnik', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (99,  27, 't', 'tour_27_image_5.jpg', 'Juego de tronos tour + Recorrido por la Ciudad antigua de Dubrovnik', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (100, 27, 't', 'tour_27_image_6.jpg', 'Juego de tronos tour + Recorrido por la Ciudad antigua de Dubrovnik', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (101, 27, 't', 'tour_27_image_7.jpg', 'Juego de tronos tour + Recorrido por la Ciudad antigua de Dubrovnik', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (102, 27, 't', 'tour_27_image_8.jpg', 'Juego de tronos tour + Recorrido por la Ciudad antigua de Dubrovnik', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (103, 27, 't', 'tour_27_image_9.jpg', 'Juego de tronos tour + Recorrido por la Ciudad antigua de Dubrovnik', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (104, 27, 't', 'tour_27_image_10.jpg', 'Juego de tronos tour + Recorrido por la Ciudad antigua de Dubrovnik', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (105, 27, 't', 'tour_27_image_11.jpg', 'Juego de tronos tour + Recorrido por la Ciudad antigua de Dubrovnik', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (106, 27, 't', 'tour_27_image_12.jpg', 'Juego de tronos tour + Recorrido por la Ciudad antigua de Dubrovnik', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (107, 27, 't', 'tour_27_image_13.jpg', 'Juego de tronos tour + Recorrido por la Ciudad antigua de Dubrovnik', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (108, 27, 't', 'tour_27_image_14.jpg', 'Juego de tronos tour + Recorrido por la Ciudad antigua de Dubrovnik', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (110, 27, 't', 'tour_27_image_16.jpg', 'Juego de tronos tour + Recorrido por la Ciudad antigua de Dubrovnik', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (112, 27, 't', 'tour_27_image_18.jpg', 'Juego de tronos tour + Recorrido por la Ciudad antigua de Dubrovnik', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (116, 27, 't', 'tour_27_image_22.jpg', 'Juego de tronos tour + Recorrido por la Ciudad antigua de Dubrovnik', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (118, 27, 't', 'tour_27_image_24.jpg', 'Juego de tronos tour + Recorrido por la Ciudad antigua de Dubrovnik', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');

INSERT INTO "public"."tour_image" VALUES (119, 29, 't', 'tour_29_image_1.jpg', 'Tour privado Juego de Tronos tour recorrido a pie', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (133, 29, 't', 'tour_29_image_15.jpg', 'Tour privado Juego de Tronos tour recorrido a pie', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (134, 29, 't', 'tour_29_image_16.jpg', 'Tour privado Juego de Tronos tour recorrido a pie', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (135, 29, 't', 'tour_29_image_17.jpg', 'Tour privado Juego de Tronos tour recorrido a pie', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (136, 29, 't', 'tour_29_image_18.jpg', 'Tour privado Juego de Tronos tour recorrido a pie', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (137, 29, 't', 'tour_29_image_19.jpg', 'Tour privado Juego de Tronos tour recorrido a pie', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (138, 29, 't', 'tour_29_image_20.jpg', 'Tour privado Juego de Tronos tour recorrido a pie', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (139, 29, 't', 'tour_29_image_21.jpg', 'Tour privado Juego de Tronos tour recorrido a pie', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (140, 29, 't', 'tour_29_image_22.jpg', 'Tour privado Juego de Tronos tour recorrido a pie', 1, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (141, 29, 't', 'tour_29_image_23.jpg', 'Tour privado Juego de Tronos tour recorrido a pie', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');

INSERT INTO "public"."tour_image" VALUES (142, 30, 't', 'tour_30_image_1.jpg', 'Tour privado por la muralla de Dubrovnik', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (143, 30, 't', 'tour_30_image_2.jpg', 'Tour privado por la muralla de Dubrovnik', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (144, 30, 't', 'tour_30_image_3.jpg', 'Tour privado por la muralla de Dubrovnik', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (145, 30, 't', 'tour_30_image_4.jpg', 'Tour privado por la muralla de Dubrovnik', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (146, 30, 't', 'tour_30_image_5.jpg', 'Tour privado por la muralla de Dubrovnik', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (147, 30, 't', 'tour_30_image_6.jpg', 'Tour privado por la muralla de Dubrovnik', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (148, 30, 't', 'tour_30_image_7.jpg', 'Tour privado por la muralla de Dubrovnik', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (149, 30, 't', 'tour_30_image_8.jpg', 'Tour privado por la muralla de Dubrovnik', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (151, 30, 't', 'tour_30_image_10.jpg', 'Tour privado por la muralla de Dubrovnik', 1, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');

INSERT INTO "public"."tour_image" VALUES (152,  31, 't', 'tour_31_image_1.jpg', 'Private tour to Mostar', 0, 1, '2019-07-09 15:00:48+00', '2019-07-09 15:00:48+00');
INSERT INTO "public"."tour_image" VALUES (153,  31, 't', 'tour_31_image_2.jpg', 'Private tour to Mostar', 0, 1, '2019-07-09 15:00:48+00', '2019-07-09 15:00:48+00');
INSERT INTO "public"."tour_image" VALUES (154,  31, 't', 'tour_31_image_3.jpg', 'Private tour to Mostar', 0, 1, '2019-07-09 15:00:48+00', '2019-07-09 15:00:48+00');
INSERT INTO "public"."tour_image" VALUES (155,  31, 't', 'tour_31_image_4.jpg', 'Private tour to Mostar', 0, 1, '2019-07-09 15:00:48+00', '2019-07-09 15:00:48+00');

INSERT INTO "public"."tour_image" VALUES (156,  32, 't', 'tour_32_image_1.jpg', 'Private tour to Montenegro', 0, 1, '2019-07-30 15:00:48+00', '2019-07-30 15:00:48+00');
INSERT INTO "public"."tour_image" VALUES (157,  32, 't', 'tour_32_image_2.jpg', 'Private tour to Montenegro', 0, 1, '2019-07-30 15:00:48+00', '2019-07-30 15:00:48+00');
INSERT INTO "public"."tour_image" VALUES (158,  32, 't', 'tour_32_image_3.jpg', 'Private tour to Montenegro', 0, 1, '2019-07-30 15:00:48+00', '2019-07-30 15:00:48+00');
INSERT INTO "public"."tour_image" VALUES (159,  32, 't', 'tour_32_image_4.jpg', 'Private tour to Montenegro', 0, 1, '2019-07-30 15:00:48+00', '2019-07-30 15:00:48+00');
INSERT INTO "public"."tour_image" VALUES (160,  32, 't', 'tour_32_image_5.jpg', 'Private tour to Montenegro', 0, 1, '2019-07-30 15:00:48+00', '2019-07-30 15:00:48+00');
INSERT INTO "public"."tour_image" VALUES (161,  32, 't', 'tour_32_image_6.jpg', 'Private tour to Montenegro', 0, 1, '2019-07-30 15:00:48+00', '2019-07-30 15:00:48+00');
INSERT INTO "public"."tour_image" VALUES (162,  32, 't', 'tour_32_image_7.jpg', 'Private tour to Montenegro', 0, 1, '2019-07-30 15:00:48+00', '2019-07-30 15:00:48+00');

INSERT INTO "public"."tour_image" VALUES (163, 34, 't', 'tour_34_image_1.jpg', 'Recorrido a pie, visita al monte de Srđ', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (164, 34, 't', 'tour_34_image_2.jpg', 'Recorrido a pie, visita al monte de Srđ', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (165, 34, 't', 'tour_34_image_3.jpg', 'Recorrido a pie, visita al monte de Srđ', 1, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (163, 34, 't', 'tour_34_image_4.jpg', 'Recorrido a pie, visita al monte de Srđ', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (164, 34, 't', 'tour_34_image_5.jpg', 'Recorrido a pie, visita al monte de Srđ', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (165, 34, 't', 'tour_34_image_6.jpg', 'Recorrido a pie, visita al monte de Srđ', 1, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (163, 34, 't', 'tour_34_image_7.jpg', 'Recorrido a pie, visita al monte de Srđ', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');

INSERT INTO "public"."tour_image" VALUES (168, 35, 't', 'tour_35_image_1.jpg', 'Dubrovnik Panorama tour - cable car', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (169, 35, 't', 'tour_35_image_2.jpg', 'Dubrovnik Panorama tour - cable car', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (170, 35, 't', 'tour_35_image_3.jpg', 'Dubrovnik Panorama tour - cable car', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (171, 35, 't', 'tour_35_image_4.jpg', 'Dubrovnik Panorama tour - cable car', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (172, 35, 't', 'tour_35_image_5.jpg', 'Dubrovnik Panorama tour - cable car', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (173, 35, 't', 'tour_35_image_6.jpg', 'Dubrovnik Panorama tour - cable car', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (174, 35, 't', 'tour_35_image_7.jpg', 'Dubrovnik Panorama tour - cable car', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');

INSERT INTO "public"."tour_image" VALUES (177, 38, 't', 'tour_38_image_1.jpg', 'Montenegro tour', 1, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (178, 38, 't', 'tour_38_image_2.jpg', 'Montenegro tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (179, 38, 't', 'tour_38_image_3.jpg', 'Montenegro tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (180, 38, 't', 'tour_38_image_4.jpg', 'Montenegro tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (181, 38, 't', 'tour_38_image_5.jpg', 'Montenegro tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');

INSERT INTO "public"."tour_image" VALUES (182, 39,  't', 'tour_39_image_1.jpg', 'Discover Dubrovnik Old Town', 0, 1, '2018-04-29 22:57:29.92+00', '2018-04-29 22:57:29.92+00');
INSERT INTO "public"."tour_image" VALUES (183, 39,  't', 'tour_39_image_2.jpg', 'Discover Dubrovnik Old Town', 1, 1, '2018-04-29 22:57:29.92+00', '2018-04-29 22:57:29.92+00');
INSERT INTO "public"."tour_image" VALUES (184, 39,  't', 'tour_39_image_3.jpg', 'Discover Dubrovnik Old Town', 3, 1, '2018-04-29 22:57:29.92+00', '2018-04-29 22:57:29.92+00');
INSERT INTO "public"."tour_image" VALUES (186, 39,  't', 'tour_39_image_4.jpg', 'Discover Dubrovnik Old Town', 13, 1, '2018-04-29 22:57:29.92+00', '2018-04-29 22:57:29.92+00');
INSERT INTO "public"."tour_image" VALUES (187, 39,  't', 'tour_39_image_5.jpg', 'Discover Dubrovnik Old Town', 24, 1, '2018-04-29 22:57:29.92+00', '2018-04-29 22:57:29.92+00');
INSERT INTO "public"."tour_image" VALUES (188, 39,  't', 'tour_39_image_6.jpg', 'Discover Dubrovnik Old Town',  22, 1, '2018-04-29 22:57:29.92+00', '2018-04-29 22:57:29.92+00');
INSERT INTO "public"."tour_image" VALUES (189, 39,  't', 'tour_39_image_7.jpg', 'Discover Dubrovnik Old Town', 15, 1, '2018-04-29 22:57:29.92+00', '2018-04-29 22:57:29.92+00');
INSERT INTO "public"."tour_image" VALUES (190, 39,  't', 'tour_39_image_8.jpg', 'Discover Dubrovnik Old Town', 10, 1, '2018-04-29 22:57:29.92+00', '2018-04-29 22:57:29.92+00');
INSERT INTO "public"."tour_image" VALUES (193, 39,  't', 'tour_39_image_19.jpg', 'Discover Dubrovnik Old Town', 8, 1, '2018-04-29 22:57:29.92+00', '2018-04-29 22:57:29.92+00');
INSERT INTO "public"."tour_image" VALUES (194, 39,  't', 'tour_39_image_10.jpg', 'Discover Dubrovnik Old Town', 5, 1, '2018-04-29 22:57:29.92+00', '2018-04-29 22:57:29.92+00');
INSERT INTO "public"."tour_image" VALUES (195, 39,  't', 'tour_39_image_11.jpg', 'Discover Dubrovnik Old Town', 9, 1, '2018-04-29 22:57:29.92+00', '2018-04-29 22:57:29.92+00');
INSERT INTO "public"."tour_image" VALUES (196, 39,  't', 'tour_39_image_12.jpg', 'Discover Dubrovnik Old Town', 11, 1, '2018-04-29 22:57:29.92+00', '2018-04-29 22:57:29.92+00');
INSERT INTO "public"."tour_image" VALUES (197, 39,  't', 'tour_39_image_13.jpg', 'Discover Dubrovnik Old Town', 15, 1, '2018-04-29 22:57:29.92+00', '2018-04-29 22:57:29.92+00');
INSERT INTO "public"."tour_image" VALUES (198, 39,  't', 'tour_39_image_14.jpg', 'Discover Dubrovnik Old Town', 23, 1, '2018-04-29 22:57:29.92+00', '2018-04-29 22:57:29.92+00');
INSERT INTO "public"."tour_image" VALUES (199, 39,  't', 'tour_39_image_15.jpg', 'Discover Dubrovnik Old Town', 20, 1, '2018-04-29 22:57:29.92+00', '2018-04-29 22:57:29.92+00');
INSERT INTO "public"."tour_image" VALUES (200, 39,  't', 'tour_39_image_16.jpg', 'Discover Dubrovnik Old Town', 20, 1, '2018-04-29 22:57:29.92+00', '2018-04-29 22:57:29.92+00');
INSERT INTO "public"."tour_image" VALUES (201, 39,  't', 'tour_39_image_17.jpg', 'Discover Dubrovnik Old Town', 20, 1, '2018-04-29 22:57:29.92+00', '2018-04-29 22:57:29.92+00');
INSERT INTO "public"."tour_image" VALUES (202, 39,  't', 'tour_39_image_18.jpg', 'Discover Dubrovnik Old Town', 20, 1, '2018-04-29 22:57:29.92+00', '2018-04-29 22:57:29.92+00');
INSERT INTO "public"."tour_image" VALUES (203, 39,  't', 'tour_39_image_19.jpg', 'Discover Dubrovnik Old Town', 20, 1, '2018-04-29 22:57:29.92+00', '2018-04-29 22:57:29.92+00');
INSERT INTO "public"."tour_image" VALUES (204, 39,  't', 'tour_39_image_20.jpg', 'Discover Dubrovnik Old Town', 20, 1, '2018-04-29 22:57:29.92+00', '2018-04-29 22:57:29.92+00');
INSERT INTO "public"."tour_image" VALUES (205, 39,  't', 'tour_39_image_21.jpg', 'Discover Dubrovnik Old Town', 20, 1, '2018-04-29 22:57:29.92+00', '2018-04-29 22:57:29.92+00');
INSERT INTO "public"."tour_image" VALUES (206, 39,  't', 'tour_39_image_22.jpg', 'Discover Dubrovnik Old Town', 20, 1, '2018-04-29 22:57:29.92+00', '2018-04-29 22:57:29.92+00');
INSERT INTO "public"."tour_image" VALUES (207, 39,  't', 'tour_39_image_23.jpg', 'Discover Dubrovnik Old Town', 20, 1, '2018-04-29 22:57:29.92+00', '2018-04-29 22:57:29.92+00');
INSERT INTO "public"."tour_image" VALUES (208, 39,  't', 'tour_39_image_24.jpg', 'Discover Dubrovnik Old Town', 20, 1, '2018-04-29 22:57:29.92+00', '2018-04-29 22:57:29.92+00');

INSERT INTO "public"."tour_image" VALUES (209, 40,  't', 'tour_40_image_1.jpg', 'Game Of Thrones driving tour', 1, 1, '2018-04-30 01:22:10.661503+00', '2018-04-30 01:22:10.661503+00');
INSERT INTO "public"."tour_image" VALUES (210, 40,  't', 'tour_40_image_2.jpg', 'Game Of Thrones driving tour', 2, 1, '2018-04-30 01:22:10.661503+00', '2018-04-30 01:22:10.661503+00');
INSERT INTO "public"."tour_image" VALUES (211, 40,  't', 'tour_40_image_3.jpg', 'Game Of Thrones driving tour', 3, 1, '2018-04-30 01:22:10.661503+00', '2018-04-30 01:22:10.661503+00');
INSERT INTO "public"."tour_image" VALUES (213, 40,  't', 'tour_40_image_5.jpg', 'Game Of Thrones driving tour', 5, 1, '2018-04-30 01:22:10.661503+00', '2018-04-30 01:22:10.661503+00');
INSERT INTO "public"."tour_image" VALUES (214, 40,  't', 'tour_40_image_6.jpg', 'Game Of Thrones driving tour', 6, 1, '2018-04-30 01:22:10.661503+00', '2018-04-30 01:22:10.661503+00');
INSERT INTO "public"."tour_image" VALUES (215, 40,  't', 'tour_40_image_7.jpg', 'Game Of Thrones driving tour', 7, 1, '2018-04-30 01:22:10.661503+00', '2018-04-30 01:22:10.661503+00');
INSERT INTO "public"."tour_image" VALUES (216, 40,  't', 'tour_40_image_8.jpg', 'Game Of Thrones driving tour', 8, 1, '2018-04-30 01:22:10.661503+00', '2018-04-30 01:22:10.661503+00');
INSERT INTO "public"."tour_image" VALUES (218, 40,  't', 'tour_40_image_10.jpg', 'Game Of Thrones driving tour', 10, 1, '2018-04-30 01:22:10.661503+00', '2018-04-30 01:22:10.661503+00');
INSERT INTO "public"."tour_image" VALUES (219, 40,  't', 'tour_40_image_11.jpg', 'Game Of Thrones driving tour', 11, 1, '2018-04-30 01:22:10.661503+00', '2018-04-30 01:22:10.661503+00');
INSERT INTO "public"."tour_image" VALUES (220, 40,  't', 'tour_40_image_12.jpg', 'Game Of Thrones driving tour', 12, 1, '2018-04-30 01:22:10.661503+00', '2018-04-30 01:22:10.661503+00');
INSERT INTO "public"."tour_image" VALUES (221, 40,  't', 'tour_40_image_13.jpg', 'Game Of Thrones driving tour', 13, 1, '2018-04-30 01:22:10.661503+00', '2018-04-30 01:22:10.661503+00');
INSERT INTO "public"."tour_image" VALUES (222, 40,  't', 'tour_40_image_14.jpg', 'Game Of Thrones driving tour', 0, 1, '2018-04-30 01:22:10.661503+00', '2018-04-30 01:22:10.661503+00');
INSERT INTO "public"."tour_image" VALUES (223, 40,  't', 'tour_40_image_15.jpg', 'Game Of Thrones driving tour', 15, 1, '2018-04-30 01:22:10.661503+00', '2018-04-30 01:22:10.661503+00');
INSERT INTO "public"."tour_image" VALUES (224, 40,  't', 'tour_40_image_16.jpg', 'Game Of Thrones driving tour', 16, 1, '2018-04-30 01:22:10.661503+00', '2018-04-30 01:22:10.661503+00');
INSERT INTO "public"."tour_image" VALUES (225, 40,  't', 'tour_40_image_17.jpg', 'Game Of Thrones driving tour', 17, 1, '2018-04-30 01:22:10.661503+00', '2018-04-30 01:22:10.661503+00');
INSERT INTO "public"."tour_image" VALUES (226, 40,  't', 'tour_40_image_18.jpg', 'Game Of Thrones driving tour', 18, 1, '2018-04-30 01:22:10.661503+00', '2018-04-30 01:22:10.661503+00');
INSERT INTO "public"."tour_image" VALUES (227, 40,  't', 'tour_40_image_19.jpg', 'Game Of Thrones driving tour', 19, 1, '2018-04-30 01:22:10.661503+00', '2018-04-30 01:22:10.661503+00');
INSERT INTO "public"."tour_image" VALUES (229, 40,  't', 'tour_40_image_21.jpg', 'Game Of Thrones driving tour', 21, 1, '2018-04-30 01:22:10.661503+00', '2018-04-30 01:22:10.661503+00');
INSERT INTO "public"."tour_image" VALUES (230, 40,  't', 'tour_40_image_22.jpg', 'Game Of Thrones driving tour', 0, 1, '2019-07-10 18:00:55+00', '2019-07-10 18:00:55+00');
INSERT INTO "public"."tour_image" VALUES (231, 40,  't', 'tour_40_image_23.jpg', 'Game Of Thrones driving tour', 0, 1, '2019-07-10 18:00:55+00', '2019-07-10 18:00:55+00');
INSERT INTO "public"."tour_image" VALUES (232, 40,  't', 'tour_40_image_24.jpg', 'Game Of Thrones driving tour', 0, 1, '2019-07-10 18:00:55+00', '2019-07-10 18:00:55+00');
INSERT INTO "public"."tour_image" VALUES (233, 40,  't', 'tour_40_image_25.jpg', 'Game Of Thrones driving tour', 0, 1, '2019-07-10 18:00:55+00', '2019-07-10 18:00:55+00');
INSERT INTO "public"."tour_image" VALUES (234, 40,  't', 'tour_40_image_26.jpg', 'Game Of Thrones driving tour', 0, 1, '2019-07-10 18:00:55+00', '2019-07-10 18:00:55+00');
INSERT INTO "public"."tour_image" VALUES (235, 40,  't', 'tour_40_image_27.jpg', 'Game Of Thrones driving tour', 0, 1, '2019-07-10 18:00:55+00', '2019-07-10 18:00:55+00');
INSERT INTO "public"."tour_image" VALUES (236, 40,  't', 'tour_40_image_28.jpg', 'Game Of Thrones driving tour', 0, 1, '2019-07-10 18:00:55+00', '2019-07-10 18:00:55+00');

INSERT INTO "public"."tour_image" VALUES (249, 41, 't', 'tour_41_image_13.jpg', 'Game Of Thrones + Iron throne walking tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (250, 41, 't', 'tour_41_image_14.jpg', 'Game Of Thrones + Iron throne walking tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (251, 41, 't', 'tour_41_image_15.jpg', 'Game Of Thrones + Iron throne walking tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (252, 41, 't', 'tour_41_image_16.jpg', 'Game Of Thrones + Iron throne walking tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (253, 41, 't', 'tour_41_image_17.jpg', 'Game Of Thrones + Iron throne walking tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (254, 41, 't', 'tour_41_image_18.jpg', 'Game Of Thrones + Iron throne walking tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (255, 41, 't', 'tour_41_image_19.jpg', 'Game Of Thrones + Iron throne walking tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (256, 41, 't', 'tour_41_image_20.jpg', 'Game Of Thrones + Iron throne walking tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (257, 41, 't', 'tour_41_image_21.jpg', 'Game Of Thrones + Iron throne walking tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (258, 41, 't', 'tour_41_image_22.jpg', 'Game Of Thrones + Iron throne walking tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (259, 41, 't', 'tour_41_image_23.jpg', 'Game Of Thrones + Iron throne walking tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (260, 41, 't', 'tour_41_image_24.jpg', 'Game Of Thrones + Iron throne walking tour', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (261, 41, 't', 'tour_41_image_25.jpg', 'Game Of Thrones driving tour', 0, 1, '2019-07-10 18:00:55+00', '2019-07-10 18:00:55+00');
INSERT INTO "public"."tour_image" VALUES (262, 41, 't', 'tour_41_image_26.jpg', 'Game Of Thrones driving tour', 0, 1, '2019-07-10 18:00:55+00', '2019-07-10 18:00:55+00');
INSERT INTO "public"."tour_image" VALUES (263, 41, 't', 'tour_41_image_27.jpg', 'Game Of Thrones driving tour', 0, 1, '2019-07-10 18:00:55+00', '2019-07-10 18:00:55+00');
INSERT INTO "public"."tour_image" VALUES (264, 41, 't', 'tour_41_image_28.jpg', 'Game Of Thrones driving tour', 0, 1, '2019-07-10 18:00:55+00', '2019-07-10 18:00:55+00');
INSERT INTO "public"."tour_image" VALUES (265, 41, 't', 'tour_41_image_29.jpg', 'Game Of Thrones driving tour', 0, 1, '2019-07-10 18:00:55+00', '2019-07-10 18:00:55+00');
INSERT INTO "public"."tour_image" VALUES (266, 41, 't', 'tour_41_image_30.jpg', 'Game Of Thrones driving tour', 0, 1, '2019-07-10 18:00:55+00', '2019-07-10 18:00:55+00');

INSERT INTO "public"."tour_image" VALUES (267, 42, 't', 'tour_42_image_1.jpg', 'Tour privado Recorrido a pie por la Ciudad Antigua', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (268, 42, 't', 'tour_42_image_2.jpg', 'Tour privado Recorrido a pie por la Ciudad Antigua', 1, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (270, 42, 't', 'tour_42_image_4.jpg', 'Tour privado Recorrido a pie por la Ciudad Antigua', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (272, 42, 't', 'tour_42_image_6.jpg', 'Tour privado Recorrido a pie por la Ciudad Antigua', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (273, 42, 't', 'tour_42_image_7.jpg', 'Tour privado Recorrido a pie por la Ciudad Antigua', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (277, 42, 't', 'tour_42_image_11.jpg', 'Tour privado Recorrido a pie por la Ciudad Antigua', 1, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (278, 42, 't', 'tour_42_image_12.jpg', 'Tour privado Recorrido a pie por la Ciudad Antigua', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (279, 42, 't', 'tour_42_image_13.jpg', 'Tour privado Recorrido a pie por la Ciudad Antigua', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (280, 42, 't', 'tour_42_image_14.jpg', 'Tour privado Recorrido a pie por la Ciudad Antigua', 1, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (281, 42, 't', 'tour_42_image_15.jpg', 'Tour privado Recorrido a pie por la Ciudad Antigua', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (282, 42, 't', 'tour_42_image_16.jpg', 'Tour privado Recorrido a pie por la Ciudad Antigua', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (283, 42, 't', 'tour_42_image_17.jpg', 'Tour privado Recorrido a pie por la Ciudad Antigua', 1, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (284, 42, 't', 'tour_42_image_18.jpg', 'Tour privado Recorrido a pie por la Ciudad Antigua', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (285, 42, 't', 'tour_42_image_19.jpg', 'Tour privado Recorrido a pie por la Ciudad Antigua', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');

INSERT INTO "public"."tour_image" VALUES (286, 43, 't', 'tour_43_image_1.jpg', 'Juego de Tronos tour, recorrido a pie', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (287, 43, 't', 'tour_43_image_2.jpg', 'Juego de Tronos tour, recorrido a pie', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (288, 43, 't', 'tour_43_image_3.jpg', 'Juego de Tronos tour, recorrido a pie', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (289, 43, 't', 'tour_43_image_4.jpg', 'Juego de Tronos tour, recorrido a pie', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (290, 43, 't', 'tour_43_image_5.jpg', 'Juego de Tronos tour, recorrido a pie', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (291, 43, 't', 'tour_43_image_6.jpg', 'Juego de Tronos tour, recorrido a pie', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (292, 43, 't', 'tour_43_image_7.jpg', 'Juego de Tronos tour, recorrido a pie', 1, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (293, 43, 't', 'tour_43_image_8.jpg', 'Juego de Tronos tour, recorrido a pie', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (294, 43, 't', 'tour_43_image_9.jpg', 'Juego de Tronos tour, recorrido a pie', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (295, 43, 't', 'tour_43_image_10.jpg', 'Juego de Tronos tour, recorrido a pie', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (296, 43, 't', 'tour_43_image_11.jpg', 'Juego de Tronos tour, recorrido a pie', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (297, 43, 't', 'tour_43_image_12.jpg', 'Juego de Tronos tour, recorrido a pie', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');

INSERT INTO "public"."tour_image" VALUES (301, 44, 't', 'tour_44_image_4.jpg', 'Tour privado Juego de Tronos ', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (302, 44, 't', 'tour_44_image_5.jpg', 'Tour privado Juego de Tronos ', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (303, 44, 't', 'tour_44_image_6.jpg', 'Tour privado Juego de Tronos ', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (304, 44, 't', 'tour_44_image_7.jpg', 'Tour privado Juego de Tronos ', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (305, 44, 't', 'tour_44_image_8.jpg', 'Tour privado Juego de Tronos ', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (306, 44, 't', 'tour_44_image_9.jpg', 'Tour privado Juego de Tronos ', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (307, 44, 't', 'tour_44_image_10.jpg', 'Tour privado Juego de Tronos ', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (308, 44, 't', 'tour_44_image_11.jpg', 'Tour privado Juego de Tronos ', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (309, 44, 't', 'tour_44_image_12.jpg', 'Tour privado Juego de Tronos ', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (311, 44, 't', 'tour_44_image_14.jpg', 'Tour privado Juego de Tronos ', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (312, 44, 't', 'tour_44_image_15.jpg', 'Tour privado Juego de Tronos ', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (313, 44, 't', 'tour_44_image_16.jpg', 'Tour privado Juego de Tronos ', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (314, 44, 't', 'tour_44_image_17.jpg', 'Tour privado Juego de Tronos ', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (315, 44, 't', 'tour_44_image_19.jpg', 'Tour privado Juego de Tronos ', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (316, 44, 't', 'tour_44_image_12.jpg', 'Tour privado Juego de Tronos ', 0, 1, '2018-04-30 03:05:49.927545+00', '2018-04-30 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (316, 45, 't', 'tour_45_image_1.jpg', 'Discover Dubrovnik Old Town',0, 4, '2020-02-10 12:05:49.927545+00', '2020-02-10 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (317, 46, 't', 'tour_46_image_1.jpg', 'Discover Dubrovnik old town - Walking tour + cable car', 0, 4, '2020-02-10 12:05:49.927545+00','2020-02-10 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (318, 47, 't', 'tour_47_image_1.jpg', 'Walking tour + panoramic drive', 0, 4, '2020-02-10 12:05:49.927545+00','2020-02-10 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (319, 48, 't', 'tour_48_image_1.jpg', 'Panoramic drive',0, 4, '2020-02-10 12:05:49.927545+00','2020-02-10 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (320, 48, 't', 'tour_48_image_2.jpg', 'Panoramic drive',0, 4, '2020-02-10 12:05:49.927545+00','2020-02-10 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (321, 48, 't', 'tour_48_image_3.jpg', 'Panoramic drive',0, 4, '2020-02-10 12:05:49.927545+00','2020-02-10 03:05:49.927545+00');
INSERT INTO "public"."tour_image" VALUES (322, 48, 't', 'tour_48_image_4.jpg', 'Panoramic drive',0, 4, '2020-02-10 12:05:49.927545+00','2020-02-10 03:05:49.927545+00');