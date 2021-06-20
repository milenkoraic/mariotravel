
-- ----------------------------
-- Table structure for tour
-- ----------------------------
DROP TABLE IF EXISTS "public"."tour";
CREATE TABLE "public"."tour" (
  "id" SERIAL NOT NULL,
  "title" text NOT NULL,
  "description" text NOT NULL,
  "content" text NOT NULL,
  "is_included" text ,
  "not_included" text ,
  "is_active" bool NOT NULL,
  "time_nesting" bool NOT NULL,
  "tour_type_id"      
  INTEGER         
  NOT NULL
  CONSTRAINT tour_tour_type_id_fkey
  REFERENCES tour_type,
  "price_per_person" numeric(19,4) NOT NULL,
  "price_base" numeric(19,4),
  "price_per_child" numeric(19,4),
  "discount_percent" numeric(10,2),
  "duration" numeric(10,2) NOT NULL,
  "language_id" 
  INTEGER        
  NOT NULL
  CONSTRAINT tour_tour_language_id_fkey
  REFERENCES tour_language,
  "slug" text NOT NULL,
  "date_created" timestamptz(6)  NOT NULL,
  "date_updated" timestamptz(6)  NOT NULL,
  "application_id" INTEGER NOT NULL
);

-- ----------------------------
-- Records of tour
-- ----------------------------


INSERT INTO "public"."tour" VALUES (
20, 
'Private Game of Thrones driving tour',
'The driving tour includes all locations that were used for filming and that can not be seen by walking from Old Town(well it is possible but it would take us a lot, I mean a lot).',
'The driving tour includes all locations that were used for filming and that can not be seen by walking from Old Town(well it&#39;s possible but it would take us a lot, I mean a lot).
<strong class="comma-target-box">HIGHLIGHTS OF THE TOUR</strong>
<ul class="comma-target-box">
<li>King&#39;s Landing gardens (Trsteno botanical garden, one of the oldest botanical gardens in the world)</li>
<li>Srđ hill (visitors usually go there to take stunning photos of Old town but we know it is actually King&#39;s road)</li>
<li>Belvedere hotel (abandoned hotel, but it&#39;s amphitheater was place where fight between Mountain and Oberyn took place)</li>
</ul>',
'<strong>WHAT IS INCLUDED:</strong>
<ul>
<li>Minivan pickup from Pile Square (or agreed otherwise)</li>
<li>Professional licensed tour guide</li>
<li>Entrance fee to botanical garden</li>
<li>Drive back to Dubrovnik, drop off at city center</li>
</ul>',
'<strong>WHAT IS NOT INCLUDED:</strong>
<ul>
<li>Food and drinks</li>	<li>Guide tips (not obligatory)</li>
</ul>
<br>
<em>Note: There are no stops in a city center, all filming locations are beautiful landscapes or gardens outside the city center, so if you need to buy some snacks or water, you should do it before.</em>
<em>For private tours send us an email at least one day before the tour, we will create a tailor-made tour for you, in timing which suits you best.</em>',
't',
'f',
2,
260.0000,
600.0000,
NULL,
5.00,
3.00,
1,
'private-game-of-thrones-driving-tour', 
'2018-04-30 02:02:24.335954+00',
'2018-04-30 02:02:24.335954+00',
1);

INSERT INTO "public"."tour" VALUES (
21, 
'Private Game Of Thrones + Iron throne walking tour',
'Since 2011 Dubrovnik is used as setting for the most popular show ever. Seasons 2,3,4,5,6 and 7 were filmed all around the world. All of our guides are licensed professionals with experience on set and of course devoted ‘Game of Thrones’ fans. ', 'Since 2011 Dubrovnik is used as setting for the most popular show ever. Seasons 2,3,4,5,6 and 7 were filmed all around the world. All of our guides are licensed professionals with experience on set and of course devoted &lsquo;Game of Thrones’ fans. Enjoy breathtaking locations in Dubrovnik and hear interesting facts about history of Dubrovnik (It&#39;s how others call King&#39;s Landing), details behind scenes during the filming. How did this ongoing phenomenon affected locals and Dubrovnik tourism?
<br>
<br>
<strong>TOUR HIGHLIGTS:</strong>
<ul>
<li>Red Keep/ Fort Lovrjenac, you will enjoy stunning views of the Old Town. Few scenes were filmed here, Joffrey’s Nameday Tournament, Tyrion slapping Joffrey, Sansa is saved by the Hound after City riot, Cersei and Littlefinger are discussing if &ldquo;Power is Power&ldquo; or &ldquo;Knowledge is power&rdquo;</li>
<li>Docks of King’s Landing. Beach where Myrcella was sent to Dorne, and in season 6, Jamie returned to King’s Landing with Myrcellas&#39;s body, Robert Baratheon&#39; bastard kids were killed, dock where Sansa was speaking with Littlefinger.</li>\r\n	<li>Blackwater Bay, where famous battle took place.</li>
<li>View on city wall of Dubrovnik, House of the Undying and terrace where Tyrion said his famous sentence to Varys, &ldquo;where is God of tits and wine&rdquo;?</li>
<li>Spice King&#39;s Palace in Quarth. After leaving Westeros and crossing the Narrow Sea, we are going to Rector’s Palace. Will the Spice King give ships to Mother of Dragons? Find out!</li>
<li>Walk of Shame. One of the highlights of the tour isthe famous walk of shame. We can recreate part of Cersei&#39;s punishment. We can even throw things at you to make it even cooler while your friends are recording.</li>
<li>Qarth. When we arrive in Red Keep (Revelin Fortress ) you will enjoy the views of the Lokrum Island, magical city of Qarth.</li>
</ul>',
'<strong>WHAT IS INCLUDED:</strong>
<ul>
<li>Professional licensed tour guide</li>
</ul>',
'<strong>WHAT IS NOT INCLUDED:</strong>
<ul>
<li>Entrance fee for Red Keep (Fort Lovrijenac), 7 euros, or freeif you have Dubrovnik card or City Walls ticket</li>
</ul><em>Note: For private tours send us an email at least one day before the tour, we will create a tailor-made tour for you, in timing which suits you best.</em>',
't',
'f',
2,
100.0000,
800.0000,
NULL,
5.00, 
2.00, 
1,
'private-game-of-thrones-walking-tour',
'2018-04-30 02:02:24.335954+00',
'2018-04-30 02:02:24.335954+00',
1);


INSERT INTO "public"."tour" VALUES (
23,
'Private tour City walls of Dubrovnik ', 
'The City walls of Dubrovnik have been preserved to the present day, not only because of the knowledge and hard work of our skilful builders but because of our dimplomatic skills in avoiding conflicts.', 
'The City walls of Dubrovnik have been preserved to the present day, not only because of the knowledge and hard work of our skilful builders but because of our dimplomatic skills in avoiding conflicts.\r\n\r\nDid you know that Dubrovnik walls are on the list of 10 things people should visit before they die? ( Dubrovnik walls, Taj mahal, Machu Picchu&hellip;.)\r\n\r\nWhen the city got it’s shape in 12th c. (two settelments conected, and canal separating them was paved), first wall all around the city was built in 13th c. The present shape of the walls was defined in the 14th century after the city gained its full independence from Venetian rule, but the peak of its construction lasted from&nbsp; 15th century until the half of the 16th century, resistant even to a big earthquake from 1667. The biggest motivation to build and strengthen fortresses was a fear of sudden atack by Turcs, especially after fall of Costantinople in 1453. Walls have a shape of&nbsp; irregular&nbsp; cuadrangular, 14 towers, 5 bastions, two angular fotifications. The main wall on the landside is 13 to 20 ft thick, and the walls is up to 25 meters (80 feet) heigh. On the landside, the wall is protected with an additional supporting wall (scrap wall) as a defense against artillery fire, especially against possible Ottoman attacks. After invention of guns and cannons, having high walls wasn’t enough. Sea side is different, only 1 to 3 meters thick because it has the best obstacule, sea and cliffs. Land cannons were always bigger, stronger and heavier than the ones on ships, that is why landside had a deep moat filled with seawater.\r\n\r\n<em>Note: it would be good that you bring with you a hat, bottle of water and sun protection.</em>\r\n',
NULL,
NULL,
't', 
'f',
2,
225.0000, 
900.0000,
NULL,
5.00,
2.00,
1, 
'private-tour-city-walls-of-dubrovnik',
'2018-04-30 02:02:24.335954+00', 
'2018-04-30 02:02:24.335954+00',
1);

INSERT INTO "public"."tour" VALUES (
24, 
'Private tour Discover Dubrovnik Old Town',
'This is a must-do tour for all visitors. Dubrovnik is unique, it’ s beauty leaves many people speechless. For 500 years we were one of the smallest and richest Republics in the world, without any armies. Learn what is so special about Dubrovnik’s diplomacy! ',
'This is a must-do tour for all visitors. Dubrovnik is unique, it’ s beauty leaves many people speechless. For 500 years we were one of the smallest and richest Republics in the world, without any armies. Learn what is so special about Dubrovnik’s diplomacy! Our theory was: It’ s better to negotiate for 100 years, than to do war for 1 year. Centuries of peace and freedom allowed art and architecture to flourish.\r\n\r\nEntering through Pile Gate, you will see Franciscan Monastery, Onofrio’s Fountain, and Rector’s Palace. You’ll hear some of the fascinating stories and remarkable facts from around 1,400 years of Dubrovnik history, including a period of the Republic of Ragusa and Yugoslavian War. On the city tour, you will be able to see and discover all the highlights of Dubrovnik’s Old Town. On the main square, we will enjoy a view of Sponza Palace, Baroque church of St. Blasius and the most photographed monument, Orlando’ s column. In the Old Port, we will tell you all about Quarantine protected by fortresses of St. John and Revelin. You’ll learn about sea trade and shipbuilding.\r\n\r\nInside information for favorable bars, restaurants, and shopping are included. We will also discuss politics, food, Homeland war, sport, and filming industry that made Dubrovnik even more famous (Game of thrones, Star wars VII, Borgias, James Bond&hellip;) Did you know, that Dubrovnik was proclaimed to be the most romantic city in the world in 2014? Find out which celebrities got married here! Every summer Old Town becomes open air stage for a summer festival and Shakespear’ s plays are performed on these fortresses, cloisters and terraces.\r\n\r\n<em>For private tours send us an email at least one day before the tour, we will create a tailor-made tour for you, in timing which suits you best.</em>\r\n',
'<strong>What is included:</strong>
<ul>
<li>Tour guide</li>
</ul>',
NULL,
't',
'f',
2, 
75.0000,
600.0000,
NULL,
5.00,
2.00,
1,
'private-tour-discover-dubrovnik-old-town',
'2018-04-30 02:02:24.335954+00',
'2018-04-30 02:02:24.335954+00',
1);

INSERT INTO "public"."tour" VALUES (
25,
'Private tour Discover Old town including Srđ hill and pick up', 
'Our dear Guests your tour starts the moment you exit your cruise ship or hotel. After pick up in the port of Dubrovnik (cruise ship guests) or at your hotel at agreed time by one of our vehicles, you will meet your private and professional licensed tourist guide. ', 
'Our dear Guests your tour starts the moment you exit your cruise ship or hotel. After pick up in the port of Dubrovnik (cruise ship guests) or at your hotel at agreed time by one of our vehicles, you will meet your private and professional licensed tourist guide. Our first stop on your private tour is top of mountain Srdj with an amazing view of the Old Town of Dubrovnik, Lokrum and Elaphiti Islands, All of our are vehicles have air condition you are accompanied by a private licensed tourist guide during walking tour&nbsp; or a profesional driver while you are in a vehicle.\r\n\r\nDuring the ride to panorama sight (15 &ndash;20 mins, depends on the traffic), your driver &nbsp;will inform you about Dubrovnik&#39;s population, position, customs, festivities&hellip;.\r\n\r\nAt this point we can already see the Island of Lokrum, you will hear a little about the cursed island and some other legends and curiosities. On the top of the hill, you can take stunning photos (believe us, we are not exaggerating) and hear all about 1300 year long history of Dubrovnik. We are standing on the last line of defense when Dubrovnik was bombed in Homeland war. Half an hour later we start our journey downhill towards Old Town.\r\n\r\nNow that we are here, we will see all important monuments and historical buildings(Onofrio’s fountain, Franciscan Monastery, St. Blaise &#39;s Church, Sponza Palace, Rector’s Palace, Cathedral). You will learn about Croatian cuisine, politics, famous personalities. Our guides are locals and highly educated young people, you can ask anything you like about corals, famous weddings or filming industry&hellip; What made Dubrovnik even more popular? We will walk the main street &ndash;Stradun, used in filming last episode of Star wars and ongoing phenomenon Game of Thrones. In February 2017 Old Town became Nottingham for new Robin Hood and it looks like James Bond is coming in winter. After 2 hour long private tour, you have free time for souvenirs, lunch or taking photos of the Old town. Free time is optional (if you want to spend some time alone). If you have more questions, you can take a coffee or pancakes with your guide and continue a conversation, or if you want your guide to escort you to a particular place or shop. My point is, we are here for you, at your service.\r\n\r\nWhen the tour (coffee, shopping or just a hangout) is finished, our vehicle together with your guide takes you back to the starting point (Port, Hotel or somewhere else in the center)\r\n\r\n',
'<strong>Tour includes:</strong>
<ul>
<li>Private vehicle pick up at the port, hotel or other location in Dubrovnik</li>
<li>Transfer to Srdj mountain, accompanied by professional and driver</li>
<li>Drive to Old Town</li>
<li>Discover the Old Town tour with local guide</li>
<li>Return to your point of origin (hotel, harbor or city center)</li>
</ul>',
NULL,
't',
'f',
2,
225.0000, 
735.0000, 
NULL,
5.00, 
3.50, 
1, 
'private-tour-discover-old-town-including-srđ-hill-and-pick-up',
'2018-04-30 02:02:24.335954+00',
'2018-04-30 02:02:24.335954+00',
1);

INSERT INTO "public"."tour" VALUES (
27, 
'Combo tour: Juego de tronos tour + Recorrido por la Ciudad antigua de Dubrovnik ( lunes, miércoles, viernes y sábado)', 'Cada lunes, miércoles, viernes y sábado. Si no puedes decidir cual tour elegir, toma lo mejor de los dos tours! Los fans de Juego de Tronos estáis de suerte, mientras la guía les cuenta numerosas anécdotas sobre la historia de Dubrovnik, vais a recorer lugares de rodaje de la serie mas descargada! La información es de primera mano porque la guía vestía extras en la serie, es tambien  diseñadora de moda!',
'Combo tour: Juego de tronos tour +Recorrido por la Ciudad antigua de Dubrovnik\r\n\r\nCuando la compa&ntilde;&iacute;a de producci&oacute;n estadounidense HBO detr&aacute;s del Juego de Tronos serie ha elegido Dubrovnik como, la ciudad capital de Westeros, Desembarco del rey, no pod&iacute;an haber elegido mejor.\r\n\r\nUno de los m&aacute;s peque&ntilde;os y ricos estados del mundo por tener papel imprescindible en comercio terrestre y mar&iacute;timo. Hacemos una peque&ntilde;a introducci&oacute;n hist&oacute;rica antes de entrar en casco amurallado. Este tour es recorrido por la ciudad, pero su gu&iacute;a le explicara informaciones b&aacute;sicas sobre murallas medievales.\r\n\r\nLos fans de Juego de Tronos est&aacute;is de suerte, mientras la gu&iacute;a les cuenta numerosas an&eacute;cdotas sobre el rodaje en la ciudad, algunos de los gu&iacute;as han participado como extras en la serie o vest&iacute;an extras por ser dise&ntilde;adores de moda tambi&eacute;n, as&iacute; que la informaci&oacute;n es de primera mano. Tras pasar puerta de Pile, entrada occidental y puente levadizo, ver&aacute;n recuerdos de guerra Yugoslava. Ex canal fue pavimentado en el siglo 13 y hoy es la calle principal. Stradun es coraz&oacute;n de la ciudad.En Stradun se hallan la mayor&iacute;a de edificios importantes. Monasterio franciscano con farmacia antigua, palacio de Rectores donde gobernaba el Rector o pr&iacute;ncipe de rep&uacute;blica. Echamos un vistazo al palacio de Sponza, ex casa de moneda y aduana. La catedral da la asunci&oacute;n de la Virgen fue terminada al principio de siglo 18, construida al mismo lugar donde antes hab&iacute;a otra, completamente destruida en gran terremoto de 1667. Otros puntos de recorrido: Iglesia de san Blas, la columna de Rolan, iglesia Jesuita, calle de recuerdos, plazas principales.\r\n\r\nLugares de rodaje de Juego de Tronos:\r\n\r\n*Fortaleza de Lovrijenac o Fortaleza Roja fue donde el rey Joffrey celebraba su onom&aacute;stico. Desde la temporada dos en adelante el equipo de rodaje movi&oacute; a Croacia para poder tener m&aacute;s exteriores de Dubrovnik y la Fortaleza de Lovrijenac.\r\n\r\n*Entre la Fortaleza Roja y la Bah&iacute;a de Aguasnegras, se situ&aacute; el Puerto de Desembarco del rey.\r\n\r\n*En la muralla se encuentra la Torre Minceta, esta torre fue Casa de los Eternos d&oacute;nde la princesa Daenerys intenta salvar a sus dragones.\r\n\r\n*En el fuerte de Bokar Tyrion Lannister dice a Varys sus palabras m&aacute;s famosas&quot;&iquest;D&oacute;nde est&aacute; el dios de tetas y vino?&quot;\r\n\r\n*Quarth, partes de ciudad m&aacute;s grande y rica de todo el mundo fueron filmadas en la isla de Lokrum, incluyendo los jardines bot&aacute;nicos, usados para escenas exteriores como la fiesta de bienvenida a madre de dragones, organizada por Xaro.\r\n\r\n*Lugar donde Capas doradas matan a bastardos del rey Robert\r\n\r\n*Revuelta contra Joffrey, ciudadanos quieren matar a todos los Lannisters\r\n\r\n*El camino de la verg&uuml;enza Una de una de las escenas m&aacute;s memorables de la 5. Temporada.\r\n\r\nTour termina en el Trono de hiero\r\n\r\nEn este tour hist&oacute;rico, tambi&eacute;n conocer&aacute;n festividades, maldici&oacute;n que cayo sobre isla de Lokrum, cocina d&aacute;lmata, e importancia de San Blas, santo patr&oacute;n, de ciudad&hellip;y mucho m&aacute;s.\r\n\r\n<strong>Punto de encuentro:</strong>\r\n\r\nPlaza de Pile, Busca la fuente de Amerling, su gu&iacute;a tendr&aacute; bandera Targaryen.\r\n\r\nPile es la &uacute;ltima parada de autobuses cuando se va al Casco Viejo.\r\n\r\nEl pago se realiza en efectivo en lugar te encuentro (aparezca 10 minutos antes del tour)o a trav&eacute;s Internet (tarjeta de credito) con 10 por ciento de descuento!\r\n',
'Cuando la compa&ntilde;&iacute;a de producci&oacute;n estadounidense HBO detr&aacute;s del Juego de Tronos serie ha elegido Dubrovnik como, la ciudad capital de Westeros, Desembarco del rey, no pod&iacute;an haber elegido mejor. 
Uno de los m&aacute;s peque&ntilde;os y ricos estados del mundo por tener papel imprescindible en comercio terrestre y mar&iacute;timo. Hacemos una peque&ntilde;a introducci&oacute;n hist&oacute;rica antes de entrar en casco amurallado.
Este tour es recorrido por la ciudad, pero su gu&iacute;a le explicara informaciones b&aacute;sicas sobre murallas medievales. Los fans de Juego de Tronos est&aacute;is de suerte, mientras la gu&iacute;a les cuenta numerosas an&eacute;cdotas sobre el rodaje en la ciudad, algunos de los gu&iacute;as han participado como extras en la serie o vest&iacute;an extras por ser dise&ntilde;adores de moda tambi&eacute;n, as&iacute; que la informaci&oacute;n es de primera mano. 
Tras pasar puerta de Pile, entrada occidental y puente levadizo, ver&aacute;n recuerdos de guerra Yugoslava. Ex canal fue pavimentado en el siglo 13 y hoy es la calle principal. Stradun es coraz&oacute;n de la ciudad.En Stradun se hallan la mayor&iacute;a de edificios importantes. 
Monasterio franciscano con farmacia antigua, palacio de Rectores donde gobernaba el Rector o pr&iacute;ncipe de rep&uacute;blica. Echamos un vistazo al palacio de Sponza, ex casa de moneda y aduana. La catedral da la asunci&oacute;n de la Virgen fue terminada al principio de siglo 18, construida al mismo lugar donde antes hab&iacute;a otra, completamente destruida en gran terremoto de 1667. Otros puntos de recorrido: Iglesia de san Blas, la columna de Rolan, iglesia Jesuita, calle de recuerdos, plazas principales. 
Lugares de rodaje de Juego de Tronos:
<br><br>
&bull;&nbsp;Fortaleza de Lovrijenac o Fortaleza Roja fue donde el rey Joffrey celebraba su onom&aacute;stico. Desde la temporada dos en adelante el equipo de rodaje movi&oacute; a Croacia para poder tener m&aacute;s exteriores de Dubrovnik y la Fortaleza de Lovrijenac. 
<br><br>
&bull;&nbsp;En la muralla se encuentra la Torre Minceta, esta torre fue Casa de los Eternos d&oacute;nde la princesa Daenerys intenta salvar a sus dragones.
<br><br>
&bull;&nbsp;En el fuerte de Bokar Tyrion Lannister dice a Varys sus palabras m&aacute;s famosas&quot;&iquest;D&oacute;nde est&aacute; el dios de tetas y vino?&quot; 
<br><br>
&bull;&nbsp;Quarth, partes de ciudad m&aacute;s grande y rica de todo el mundo fueron filmadas en la isla de Lokrum, incluyendo los jardines bot&aacute;nicos, usados para escenas exteriores como la fiesta de bienvenida a madre de dragones, organizada por Xaro. 
<br><br>
&bull;&nbsp;;Lugar donde Capas doradas matan a bastardos del rey Robert 
<br><br>
&bull;&nbsp;;Revuelta contra Joffrey, ciudadanos quieren matar a todos los Lannisters. 
<br><br>
&bull;&nbsp;;El camino de la verg&uuml;enza Una de una de las escenas m&aacute;s memorables de la 5. Temporada. Tour termina en el Trono de hiero. En este tour hist&oacute;rico, tambi&eacute;n conocer&aacute;n festividades, maldici&oacute;n que cayo sobre isla de Lokrum, cocina d&aacute;lmata, e importancia de San Blas, santo patr&oacute;n, de ciudad&hellip;y mucho m&aacute;s.',
'<strong>El precio: </strong>30 euros\r\n\r\n',
't',
'f',
1,
260.0000, 
NULL, 
NULL,
5.00,
2.50, 
2,
'combo-tour-juego-de-tronos-tour-recorrido-por-la-ciudad-antigua-de-dubrovnik-lunes-miércoles-viernes-y-sábado',
'2018-04-30 02:02:24.335954+00',
'2018-04-30 02:02:24.335954+00',
1);


INSERT INTO "public"."tour" VALUES (
29, 
'Tour privado Juego de Tronos tour recorrido a pie',
'Cuando la compañía de producción estadounidense HBO detrás del Juego de Tronos serie ha elegido Dubrovnik como, la ciudad capital de Westeros, Desembarco del rey, no podían haber elegido mejor. Una ciudad costera rodeada de murallas defensivas es un candidato perfecto. ', 'Cuando la compa&ntilde;&iacute;a de producci&oacute;n estadounidense HBO detr&aacute;s del Juego de Tronos serie ha elegido Dubrovnik como, la ciudad capital de Westeros, Desembarco del rey, no pod&iacute;an haber elegido mejor. Una ciudad costera rodeada de murallas defensivas es un candidato perfecto. El productor ejecutivo David Benioff dice: &laquo;Al momento en que empec&eacute; a caminar alrededor de las paredes de la ciudad, sab&iacute;a que la usar&iacute;amos. Uno lee las descripciones en el libro y son exactamente iguales. Tiene el espumoso mar, el sol y la hermosa arquitectura&raquo;.Los fans de Juego de Tronos est&aacute;is de suerte, mientras la gu&iacute;a les cuenta numerosas an&eacute;cdotas sobre el rodaje en la ciudad, algunos de los gu&iacute;as han participado como extras en la serie o vest&iacute;an extras por ser dise&ntilde;adores de moda tambi&eacute;n, as&iacute; que la informaci&oacute;n es de primera mano.\r\n\r\n<strong>Punto de encuentro: Plaza de Pile, busca el gu&iacute;a con bandera Targaryen</strong>\r\n\r\n<em>El pago se realiza en efectivo en lugar te encuentro (aparezca 10 minutos antes del tour)o a trav&eacute;s Internet (tarjeta de credito) con 10 por ciento de descuento! Tours privados, manda nos un correo electr&oacute;nico por lo menos un d&iacute;a por adelantado, vamos a crear un tour para Usted, ajustado a sus deseos, tiempo e intereses</em>\r\n\r\n<em>Tour termina en el Trono de hierro, pueden asentarse y sacar foto en el trono, un bonito recuerdo, solo para mis fans GRATIS</em>\r\n',
'Cuando la compa&ntilde;&iacute;a de producci&oacute;n estadounidense HBO detr&aacute;s del Juego de Tronos serie ha elegido Dubrovnik como, la ciudad capital de Westeros, Desembarco del rey, no pod&iacute;an haber elegido mejor.
Una ciudad costera rodeada de murallas defensivas es un candidato perfecto.
El productor ejecutivo David Benioff dice: &laquo;Al momento en que empec&eacute; a caminar alrededor de las paredes de la ciudad, sab&iacute;a que la usar&iacute;amos. 
Uno lee las descripciones en el libro y son exactamente iguales. Tiene el espumoso mar, el sol y la hermosa arquitectura&raquo;.Los fans de Juego de Tronos est&aacute;is de suerte, mientras la gu&iacute;a les cuenta numerosas an&eacute;cdotas sobre el rodaje en la ciudad, algunos de los gu&iacute;as han participado como extras en la serie o vest&iacute;an extras por ser dise&ntilde;adores de moda tambi&eacute;n, as&iacute; que la informaci&oacute;n es de primera mano.',
NULL,
't', 
'f',
2, 
100.0000,
800.0000, 
NULL,
5.00,
1.50, 
2, 
'tour-privado-juego-de-tronos-tour-recorrido-a-pie',
'2018-04-30 02:02:24.335954+00',
'2018-04-30 02:02:24.335954+00',
1);


INSERT INTO "public"."tour" VALUES (
30, 
'Tour privado por la muralla de Dubrovnik', 
'Las murallas de Dubrovnik, tienen 1940 metros de recorrido con una altura máxima de 25 metros, con una serie de bastiones, torres y fortificaciones que rodean todo el centro histórico y el puerto. ',
'Las murallas de Dubrovnik, tienen 1940 metros de recorrido con una altura m&aacute;xima de 25 metros, con una serie de bastiones, torres y fortificaciones que rodean todo el centro hist&oacute;rico y el puerto.
Fueron construidas para defender la ciudad contra los invasores. Est&aacute;n consideradas una de las m&aacute;s bonitas y mejor conservadas de Europa. Hay bastante escalones porque muralla est&aacute; construida en acantilados y camino es cuesta arriba, cuesta abajo etc. 
Vale la pena por las vistas imprescindibles y las fotos que van a sacar. Hay solo una direcci&oacute;n para hacer el recorrido, inversa a las agujas del reloj, para evitar atasco. Si hubi&eacute;ramos sabido que estas murallas van a ser atracci&oacute;n tur&iacute;stica, las habr&iacute;amos construido m&aacute;s anchas y con sombra.',
'<strong>Importante: </strong>
<ul>
<li>Por favor, ll&eacute;vense agua embotellada, en Croacia agua es potable de cualquier grifo</li>
<li>Es recomendable usar crema solar y sombrero</li>	
</ul>',
'<strong>Entrada para muralla cuesta 150 kunas o 19 euros por persona y no esta incluida en el precio del tour</strong></li>
</ul>',
't', 
'f',
2, 
110.0000, 
600.0000,
NULL,
5.00,
2.00,
2, 
'tour-privado-por-la-muralla-de-dubrovnik', 
'2018-04-30 02:02:24.335954+00',
'2018-04-30 02:02:24.335954+00',
1);
        


INSERT INTO "public"."tour" VALUES (
31, 
'Private tour to Mostar',
'Visit Mostar, experience the hospitality of its culturally diverse nation, explore its architectural heritage. Explore the city with a tour guide, learn a brief history and some anecdotes about the city. See its Old Bridge, originally built in the 16th century and rebuilt after the recent war. Learn about the war devastation of the city, and what it meant for the local people.
Kravice waterfalls is a must-see attraction in this region. During the spring, this stunning waterfall turns into a steamy cascade of fury. In the summer, the waterfalls are less dynamic, but the surrounding pools become shallow enough to hop in for a swim.
The tour departs every day from Dubrovnik. Tour includes a hotel pick-up and drop-off, transportation in an air-conditioned vehicle, a tour guide and a city tour of Mostar.', 
'Visit Mostar, experience the hospitality of its culturally diverse nation, explore its architectural heritage. Explore the city with a tour guide, learn a brief history and some anecdotes about the city. See its Old Bridge, originally built in the 16th century and rebuilt after the recent war. Learn about the war devastation of the city, and what it meant for the local people.
Kravice waterfalls is a must-see attraction in this region. During the spring, this stunning waterfall turns into a steamy cascade of fury. In the summer, the waterfalls are less dynamic, but the surrounding pools become shallow enough to hop in for a swim.
The tour departs every day from Dubrovnik. Tour includes a hotel pick-up and drop-off, transportation in an air-conditioned vehicle, a tour guide and a city tour of Mostar.',
NULL,
NULL,
't',
'f',
2, 
4500.0000,
NULL, 
5.00,
NULL,
10.50,
1, 
'private-tour-to-mostar',
'2019-07-09 15:08:55+00',
'2019-07-09 15:08:55+00',
1);

INSERT INTO "public"."tour" VALUES (
32,
'Private tour to Montenegro',
'On this tour, we want to take you to the must-see places in Montenegro: Perast and Kotor Bay with an optional short boat trip to the island Our Lady of the Rocks.  This place has romantic energy, and so many calm places with astonishing natural beauty and rich cultural legacy, that will blow you away In the middle of the bay, the town Kotor hides his many secret stories, rich cultural and historic legacy.  ', 'On this tour, we want to take you to the must-see places in Montenegro: Perast and Kotor Bay with an optional short boat trip to the island Our Lady of the Rocks.  This place has romantic energy, and so many calm places with astonishing natural beauty and rich cultural legacy, that will blow you away In the middle of the bay, the town Kotor hides his many secret stories, rich cultural and historic legacy.  His shape of a butterfly tells a story about how even good love this area, so they reworded it with this magnificent shape The old Mediterian port of Kotor is surrounded by fortifications built during the Venetian period.  It is located on the Bay of Kotor (Boka Kotorska), one of the most indented parts of the Adriatic Sea. Some have called it the southern-most fjord in Europe, actually, it is a ria, a submerged river canyon.  Along with the rest, Kotor is part of the World Heritage Site dubbed the Natural and Culturo-Historical Region of Kotor.  The natural beauty that combines past and the present brought this area UNESCO heritage protection.  This strong and fascinating town fight the persistent wind from the sea, protecting its inhabitants and their stories.  The Bay of Kotor will calm you and take you far away from everyday stress.  Perast is an old town on the Bay of Kotor in Montenegro.  It is situated a few kilometres northwest of Kotor and is noted for its proximity to the islets of St. George and Our Lady of the Rocks and each one has a picturesque chapel worth seeing.  ',
NULL,
NULL,
't',
'f',
2,
2250.0000, 
NULL, 
NULL,
5.00, 
10.50, 
1,
'private-tour-to-montenegro',
'2019-07-30 15:08:55+00', 
'2019-07-30 15:08:55+00',
1);


INSERT INTO "public"."tour" VALUES (
34, 
'Recorrido a pie, visita al monte de Srđ y traslado de ida y vuelta', 
'Recorrido a pie por Ciudad antigua/ o tour en muralla de Dubrovnik (puede eligir), traslado de ida y vuelta a su hotel o puerto de cruceros y visita al monte de Sr? ! Si está limitado por tiempo y dispone de solo 4 horas de tiempo en Dubrovnik, este tour completo de Dubrovnik es la opción ideal.', 
'Dubrovnik experiencia completa: Recorrido a pie, el monte de Sr? y traslado de ida y vuelta. Recorrido a pie por Ciudad antigua/ o tour en muralla de Dubrovnik (puede eligir),
 traslado de ida y vuelta a su hotel o puerto de cruceros y visita al monte de Sr? ! Si est&aacute; limitado por tiempo y dispone de solo 4 horas de tiempo en Dubrovnik, este tour completo de Dubrovnik es la opci&oacute;n ideal. Podr&aacute; disfrutar de vistas panor&aacute;micas dese el tope del monte de Sr?. El mirador de Sr? da a ciudad amurallada, mar Adri&aacute;tico e isla de Lokrum. Su gui&aacute; le explicare todo sobre guerra yugoslava, &eacute;poca dorada de rep&uacute;blica de Dubrovnik e historia reciente. Despu&eacute;s, bajamos para disfrutar de un paseo por Ciudad antigua de Dubrovnik. El tiempo previsto es 2 horas. La superficie de Ciudad antigua es 13 hect&aacute;reas. La muralla de Dubrovnik es un circulo completo que rodea todo el casco antiguo. Hacer dos tour a la vez seria demasiado agotador as&iacute; que Usted decide si quier pasear con su gui&aacute; privada por muralla o hacer tour por la ciudad (los dos tours duran igual, 2 horas). Cuando termine la parte guiada de la excursi&oacute;n a pie, tendr&aacute; tiempo libre para explorar la ciudad por su cuenta, almorzar, comprar recuerdos antes de regresar a su barco, hotel&hellip;',
'<strong>El precio:</strong> <strong>120 euros mas 25 euros por persona</strong>
<br><br>
El pago se realiza en efectivo en lugar te encuentro (aparezca 10 minutos antes del tour)o a trav&eacute;s Internet (tarjeta de credito) con 10 por ciento de descuento!
&iquest;Qu&eacute; est&aacute; incluido?
<br><br>
&bull;&nbsp;Tour privado por Ciudad Antigua de Dubrovnik/ o tour por muralla de Dubrovnik
<br><br>
&bull;&nbsp;Veh&iacute;culo privado
<br><br>
&bull;&nbsp; traslado de ida y vuelta a puerto, hotel u otro lugar en el centro.
<br><br>
&bull;&nbsp;Gu&iacute;a local
<br><br>
&bull;&nbsp;Traslado de ida y vuelta al tope del monte de Srdj. &nbsp;&iquest;Y qu&eacute; no?
<br><br>
&bull;&nbsp;Entrada por muralla si elige esse tour (20 euros por persona)
<br><br>
&bull;&nbsp;Propina ( opcional )',
NULL,
't',
'f',
2,
225.0000,
750.0000,
NULL, 
5.00,
3.50,
2, 
'recorrido-a-pie-visita-al-monte-de-srđ-y-traslado-de-ida-y-vuelta',
'2018-04-30 02:02:24.335954+00', 
'2018-04-30 02:02:24.335954+00',
1);


INSERT INTO "public"."tour" VALUES (
35, 'Dubrovnik Panorama tour - cable car',
'If you’re looking for a different approach in the sightseeing, not just driving through the streets of the city, then this is the tour for you. Dubrovnik Panorama Tour will give you the same view as the cable car and much more for almost the same price while enjoying the comfort of our air-conditioned vehicles', 'Dubrovnik Panorama Tour is the perfect tour for visitors who want to see Dubrovnik from a different perspective. This tour is will give you a way to escape big crowds, providing best photo opportunities that Dubrovnik offers. With us, You will experience the best combination of sightseeing and local stories about Dubrovnik provided by our professional drivers&shy;-guides.\r\n\r\n&nbsp;\r\n\r\nThis tour will take you to all landmarks of Dubrovnik; Starting with mountain Srdj&nbsp;which offers several great photo stop opportunities with a breathtaking view of the Old city of Dubrovnik, including fort Imperial on the top of the mountain, the same place where the cable car goes. After the mountain Srdj, we are taking you to one of the shortest rivers in the world. But, don’t be fooled by its length, river Ombla has huge water supplies and it gives life to Dubrovnik city. Last stop is Dubrovnik Bridge, named after first Croatian president Dr. Franjo Tu?man, from which you will get an amazing view on main Dubrovnik port and Lapad Bay. Just taking the cable car can give you only one view. This tour is much more than the cable car.\r\n\r\n&nbsp;\r\n\r\nIf you’re looking for a different approach in the sightseeing, not just driving through the streets of the city, then this is the tour for you. Dubrovnik Panorama Tour will give you the same view as the cable car and much more for almost the same price while enjoying the comfort of our air-conditioned vehicles.\r\n\r\n&nbsp;\r\n\r\n',
'<strong>What is included:</strong>
<ul>
<li>Driver-guide</li>
<li>Pick up from Pile square</li>
<li>Drop off in city center</li>
</ul>',
NULL,
't',
't',
1,
150.0000,
NULL,
NULL,
5.00,
1.50,
1,
'dubrovnik-panorama-tour-cable-car',
'2018-04-30 02:02:24.335954+00',
'2018-05-19 12:14:00.335+00',
1);



INSERT INTO "public"."tour" VALUES (
38,
'Montenegro tour',
'Montenegro is a small country located south-east from Dubrovnik, known for its natural beauties and perfect harmony between mountains and Adriatic sea.',
'Montenegro is a small country located south-east from Dubrovnik, known for its natural beauties and perfect harmony between mountains and Adriatic sea.&nbsp; After the morning departure from Dubrovnik, we will pass through Konavle valley and continue our way towards Montenegro border, with amazing panoramic drive through Boka Kotorska bay waiting for you. While in Boka Kotorska we&#39;ll stop at city of Perast where you have an option to visit the island of Our Lady of the rocks, price for the ferry is 5&euro; per person.
The next stop is Kotor, one of most beautiful cities in Montenegro, whose Old Town is surrounded by city walls that climb over the mountain. While in Kotor consider a challenge- going up the 1350 steep steps to the San Giovanni Castle with incredible view and perfect location to take photos.
The Montenegro tour will also take you to Budva, a wonderful town on the Adriatic, a part of the Budva Riviera, famous for its sandy beaches and exciting nightlife.
<br>
<br>
<strong>TOUR HIGHLIGHTS</strong>
<br>
<br>
<strong>PERAST</strong> (approx. 45min free time)
<br>
Picturesque small town, famous for its captains
<ul>
<li>Option: you can take a short boat ride and visit Our Lady of the Rocks island for 5 &euro;</li>
</ul>
<br>
<br>
<strong>KOTOR</strong> (approx. 2 hours free time)
<br>
UNESCO World Heritage Site, Old Town surrounded by city walls that climb over the mountain.
<br>
<br>
<strong>BUDVA</strong> (approx. 2 hours free time)
Popular resort town on Montenegrian coast, nice beaches, fancy hotels &amp; casinos.
<ul>
<li>On our way back from Budva we cross the Bay of Kotor with a ferry and save time</li>
<li>Small group with minibus, up to 20 people.</li>
</ul>
<br>
<br>',
'<strong>BRING YOUR PASSPORT</strong>
<br>
<br>',
NULL,
't', 
'f',
1,
360.0000,
NULL,
NULL,
5.00,
10.00,
1,
'montenegro-tour',
'2018-04-30 02:02:24.335954+00',
'2018-04-30 02:02:24.335954+00',
1);

INSERT INTO "public"."tour" VALUES (
39,
'Discover Dubrovnik Old Town',
'This is a must-do tour for all visitors. Dubrovnik is unique, it’ s beauty leaves many people speechless. For 500 years we were one of the smallest and richest Republics in the world, without any armies. Learn what is so special about Dubrovnik’s diplomacy!',
'This is a must-do tour for all visitors. Dubrovnik is unique, it’ s beauty leaves many people speechless. For 500 years we were one of the smallest and richest Republics in the world, without any armies. Learn what is so special about Dubrovnik’s diplomacy! Our theory was: It’ s better to negotiate for 100 years, than to do war for 1 year. Centuries of peace and freedom allowed art and architecture to flourish.Entering through Pile Gate, you will see Franciscan Monastery, Onofrio’s Fountain, and Rector’s Palace. You’ll hear some of the fascinating stories and remarkable facts from around 1,400 years of Dubrovnik history, including a period of the Republic of Ragusa and Yugoslavian War. On the city tour, you will be able to see and discover all the highlights of Dubrovnik’s Old Town. On the main square, we will enjoy a view of Sponza Palace, Baroque church of St. Blasius and the most photographed monument, Orlando’ s column. In the Old Port, we will tell you all about Quarantine protected by fortresses of St. John and Revelin. You’ll learn about sea trade and shipbuilding.Inside information for favorable bars, restaurants, and shopping are included. We will also discuss politics, food, Homeland war, sport, and filming industry that made Dubrovnik even more famous (Game of thrones, Star wars VII, Borgias, James Bond&hellip;) Did you know, that Dubrovnik was proclaimed to be the most romantic city in the world in 2014? Find out which celebrities got married here! Every summer Old Town becomes open air stage for a summer festival and Shakespear’ s plays are performed on these fortresses, cloisters and terraces.', 
'<strong>What is included:</strong>
<ul>
<li>Tour guide</li>
</ul>',
NULL,
't',
'f',
1, 
135.0000, 
NULL, 
NULL,
5.00, 
1.50, 
1, 
'discover-dubrovnik-old-town',
'2018-04-30 02:02:24.335954+00',
'2018-04-30 02:02:24.335954+00',
1);

INSERT INTO "public"."tour" VALUES (
40, 
'Game Of Thrones driving tour', 
'The driving tour includes all locations that were used for filming and that can not be seen by walking from Old Town(well it is possible but it would take us a lot, I mean a lot).', 
'The driving tour includes all locations that were used for filming and that can not be seen by walking from Old Town(well it&#39;s possible but it would take us a lot, I mean a lot).
<br>
<br>
<strong class="comma-target-box">HIGHLIGHTS OF THE TOUR</strong>
<ul class="comma-target-box">
<li>King&#39;s Landing gardens (Trsteno botanical garden, one of the oldest botanical gardens in the world)</li>
<li>Srđ hill (visitors usually go there to take stunning photos of Old town but we know it is actually King&#39;s road)</li>
<li>Belvedere hotel (abandoned hotel, but it&#39;s amphitheater was place where fight between Mountain and Oberyn took place)</li>
</ul>',
'<strong>WHAT IS INCLUDED:</strong>
<ul>
<li>Minivan pickup from Pile Square (or agreed otherwise)</li>
<li>Professional licensed tour guide</li>
<li>Entrance fee to botanical garden</li>
<li>Drive back to Dubrovnik, drop off at city center</li>
</ul>',
'<strong>WHAT IS NOT INCLUDED:</strong>
<ul>
<li>Food and drinks</li>
<li>Guide tips (not obligatory)</li>
</ul>
<br>
<em>Note: There are no stops in a city center, all filming locations are beautiful landscapes or gardens outside the city center, so if you need to buy some snacks or water, you should do it before.</em>
<em>For private tours send us an email at least one day before the tour, we will create a tailor-made tour for you, in timing which suits you best.</em>',
't',
'f',
1,
375.0000,
NULL,
NULL,
5.00,
3.00,
1,
'game-of-thrones-driving-tour',
'2018-04-29 22:50:24.156+00',
'2018-04-29 22:50:24.156+00',
1);

INSERT INTO "public"."tour" VALUES (
41,
'Game Of Thrones + Iron throne walking tour',
'Since 2011 Dubrovnik is used as setting for the most popular show ever. Seasons 2, 3, 4, 5, 6 and 7 were filmed all around the world. All of our guides are licensed professionals with experience on set and of course devoted ‘Game of Thrones’ fans. ', 'Since 2011 Dubrovnik is used as setting for the most popular show ever. Seasons 2,3,4,5,6 and 7 were filmed all around the world. All of our guides are licensed professionals with experience on set and of course devoted &lsquo;Game of Thrones’ fans. Enjoy breathtaking locations in Dubrovnik and hear interesting facts about history of Dubrovnik (It&#39;s how others call King&#39;s Landing), details behind scenes during the filming. How did this ongoing phenomenon affected locals and Dubrovnik tourism?
<br>
<br>
<strong>TOUR HIGHLIGTS:</strong>
<ul>
<li>Red Keep/ Fort Lovrjenac, you will enjoy stunning views of the Old Town. Few scenes were filmed here, Joffrey’s Nameday Tournament, Tyrion slapping Joffrey, Sansa is saved by the Hound after City riot, Cersei and Littlefinger are discussing if &ldquo;Power is Power&ldquo; or &ldquo;Knowledge is power&rdquo;</li>
<li>Docks of King’s Landing</li>
<li>Beach where Myrcella was sent to Dorne, and in season 6, Jamie returned to King’s Landing with Myrcellas&#39;s body, Robert Baratheon&#39; bastard kids were killed, dock where Sansa was speaking with Littlefinger.</li>\r\n	<li>Blackwater Bay, where famous battle took place.</li>\r\n	<li>View on city wall of Dubrovnik, House of the Undying and terrace where Tyrion said his famous sentence to Varys, &ldquo;where is God of tits and wine&rdquo;?</li>
<li>Spice King&#39;s Palace in Quarth. After leaving Westeros and crossing the Narrow Sea, we are going to Rector’s Palace. Will the Spice King give ships to Mother of Dragons? Find out!</li>\r\n	<li>Walk of Shame. One of the highlights of the tour isthe famous walk of shame. We can recreate part of Cersei&#39;s punishment. We can even throw things at you to make it even cooler while your friends are recording.</li>\r\n	<li>Qarth. When we arrive in Red Keep (Revelin Fortress ) you will enjoy the views of the Lokrum Island, magical city of Qarth.</li>
</ul>',
'<strong>WHAT IS INCLUDED:</strong>
<ul>
<li>Professional licensed tour guide</li>
</ul>',
'<strong>WHAT IS NOT INCLUDED:</strong>
<ul>
<li>Entrance fee for Red Keep (Fort Lovrijenac), 7 euros, or free if you have Dubrovnik card or City Walls ticket</li>
</ul>',
't',
'f',
1,
150.0000,
NULL, 
NULL,
5.00, 
2.00,
1, 
'game-of-thrones-walking-tour',
'2018-04-30 01:43:26.062879+00', 
'2018-04-30 01:43:26.062879+00',
1);

INSERT INTO "public"."tour" VALUES (
42,
'Tour privado Recorrido a pie por la Ciudad Antigua de Dubrovnik',
'Dubrovnik deja muchos sin habla y su belleza es cautivadora. Uno de los más pequeños y ricos estados del mundo por tener papel imprescindible en comercio terrestre y marítimo. Hacemos una pequeña introducción histórica antes de entrar en casco amurallado.', 
'Dubrovnik deja muchos sin habla y su belleza es cautivadora. 
Uno de los m&aacute;s peque&ntilde;os y ricos estados del mundo por tener papel imprescindible en comercio terrestre y mar&iacute;timo. Hacemos una peque&ntilde;a introducci&oacute;n hist&oacute;rica antes de entrar en casco amurallado. Este tour es recorrido por la ciudad, pero su gu&iacute;a le explicara informaciones b&aacute;sicas sobre murallas medievales. 
Tras pasar puerta de Pile, entrada occidental y puente levadizo, ver&aacute; recuerdos de guerra Yugoslava. 
Hoy Dubrovnik es la ciudad m&aacute;s prospera e elegante dentro de Croacia independiente.
Tiene solo 45 000 habitantes y casi 4 millones de visitantes, definitivamente estamos de moda, descubra porqu&eacute;! Ex canal fue pavimentado en el siglo 12 y hoy es la calle principal. 
Stradun es coraz&oacute;n de la ciudad, popular lugar de encuentros y arteria comercial. 
No hay acontecimiento que no pase por aqu&iacute;! En Stradun se halla la mayor&iacute;a de edificios importantes. Les explicaremos todos, y luego Usted entra por su cuenta, donde quieran, museos e iglesias (en Dubrovnik no cobran entradas en iglesias). Monasterio franciscano con farmacia antigua, palacio de Rectores donde gobernaba el Rector o pr&iacute;ncipe de rep&uacute;blica. 
Echamos un vistazo al palacio de Sponza, ex casa de moneda y aduana. La catedral da la asunci&oacute;n de la Virgen fue terminada al principio de siglo 18, construida al mismo lugar donde antes hab&iacute;a otra, completamente destruida en gran terremoto de 1667. 
Otros puntos de recorrido: Iglesia de san Blas, la columna de Rolan, iglesia Jesuita, calle de recuerdos, plazas principales. Tour termina en puerto antigua, lugar perfecto para conocer historia de construcci&oacute;n naval. Nuestros barcos que gozaban una prestigiosa reputaci&oacute;n. Una nave a la ragusea significa una nave dura y s&oacute;lida. En este tour hist&oacute;rico, tambi&eacute;n conocer&aacute;n festividades, maldici&oacute;n que cayo sobre isla de Lokrum, cocina d&aacute;lmata, e importancia de San Blas, santo patr&oacute;n, de ciudad&hellip;y mucho m&aacute;s.\r\n\r\nTours se organizan en Junio, Julio, Agosto y Octubre de 2017\r\n\r\nEl precio:&nbsp; 80 euros mas 10 euros por persona\r\n\r\nDuracion: 1,5 horas.
Tiempo de salida: cuando quieran.',
NULL,
NULL, 
't',
'f',
2,
100.0000,
700.0000, 
NULL,
5.00, 
1.50, 
2, 
'tour-privado-recorrido-a-pie-por-la-ciudad-antigua-de-dubrovnik', 
'2018-04-30 02:02:24.335954+00',
'2018-04-30 02:02:24.335954+00',
1);

INSERT INTO "public"."tour" VALUES (
43, 
'Juego de Tronos tour, recorrido a pie ( lunes, miércoles, viernes y sábado)',
'Cuando la compañía de producción estadounidense HBO detrás del Juego de Tronos serie ha elegido Dubrovnik como, la ciudad capital de Westeros, Desembarco del rey, no podían haber elegido mejor. Una ciudad costera rodeada de murallas defensivas es un candidato perfecto.', 'Cuando la compa&ntilde;&iacute;a de producci&oacute;n estadounidense HBO detr&aacute;s del Juego de Tronos serie ha elegido Dubrovnik como, la ciudad capital de Westeros, Desembarco del rey, no pod&iacute;an haber elegido mejor. Una ciudad costera rodeada de murallas defensivas es un candidato perfecto. El productor ejecutivo David Benioff dice: &laquo;Al momento en que empec&eacute; a caminar alrededor de las paredes de la ciudad, sab&iacute;a que la usar&iacute;amos. Uno lee las descripciones en el libro y son exactamente iguales. Tiene el espumoso mar, el sol y la hermosa arquitectura&raquo;.Los fans de Juego de Tronos est&aacute;is de suerte, mientras la gu&iacute;a les cuenta numerosas an&eacute;cdotas sobre el rodaje en la ciudad, algunos de los gu&iacute;as han participado como extras en la serie o vest&iacute;an extras por ser dise&ntilde;adores de moda tambi&eacute;n, as&iacute; que la informaci&oacute;n es de primera mano.\r\n\r\n<strong>Punto de encuentro: Plaza de Pile, busca el gu&iacute;a con bandera Targaryen</strong>\r\n\r\n<em>El pago se realiza en efectivo en lugar te encuentro (aparezca 10 minutos antes del tour)o a trav&eacute;s Internet (tarjeta de credito) con 10 por ciento de descuento! Tours privados, manda nos un correo electr&oacute;nico por lo menos un d&iacute;a por adelantado, vamos a crear un tour para Usted, ajustado a sus deseos, tiempo e intereses</em>\r\n\r\n<em>Tour termina en el Trono de hierro, pueden asentarse y sacar foto en el trono, un bonito recuerdo, solo para mis fans GRATIS</em>\r\n',
'Cuando la compa&ntilde;&iacute;a de producci&oacute;n estadounidense HBO detr&aacute;s del Juego de Tronos serie ha elegido Dubrovnik como, la ciudad capital de Westeros, Desembarco del rey, no pod&iacute;an haber elegido mejor.
Una ciudad costera rodeada de murallas defensivas es un candidato perfecto. 
El productor ejecutivo David Benioff dice: &laquo;Al momento en que empec&eacute; a caminar alrededor de las paredes de la ciudad, sab&iacute;a que la usar&iacute;amos. 
Uno lee las descripciones en el libro y son exactamente iguales. 
Tiene el espumoso mar, el sol y la hermosa arquitectura&raquo;.
Los fans de Juego de Tronos est&aacute;is de suerte, mientras la gu&iacute;a les cuenta numerosas an&eacute;cdotas sobre el rodaje en la ciudad, algunos de los gu&iacute;as han participado como extras en la serie o vest&iacute;an extras por ser dise&ntilde;adores de moda tambi&eacute;n, as&iacute; que la informaci&oacute;n es de primera mano.
<br><br>
<em>El pago se realiza en efectivo en lugar te encuentro (aparezca 10 minutos antes del tour)o a trav&eacute;s Internet (tarjeta de credito) con 10 por ciento de descuento! Tours privados, manda nos un correo electr&oacute;nico por lo menos un d&iacute;a por adelantado, vamos a crear un tour para Usted, ajustado a sus deseos, tiempo e intereses</em>
<br><br>
<em>Tour termina en el Trono de hierro, pueden asentarse y sacar foto en el trono, un bonito recuerdo, solo para mis fans GRATIS</em>',
NULL,
't', 
'f',
1,
185.0000, 
NULL, 
NULL,
5.00, 
1.50,
2, 
'juego-de-tronos-tour-recorrido-a-pie-lunes-miércoles-viernes-y-sábado', 
'2018-04-30 02:02:24.335954+00', 
'2018-04-30 02:02:24.335954+00',
1);

INSERT INTO "public"."tour" VALUES (
44,
'Tour privado Juego de Tronos tour en vehículo',
'Tour en vehículo incluye todos los lugares del rodaje que no se pueden ver caminando por la Ciudad antigua', 
'<strong>Parte m&aacute;s destacada:</strong>
<ul>
<li>Jard&iacute;n bot&aacute;nico Trsteno Arboretum, se encuentra a unos 10 km de la ciudad, se trata de un antiguo conjunto arquitect&oacute;nico de jardines renacentistas y neorrom&aacute;nicos, con vistas al mar. Trsteno recrea los ex&oacute;ticos jardines aqu&iacute; se rodaron varias escenas de los jardines de la Fortaleza Roja.</li>
<li>Anfiteatro donde se film&oacute; pelea entre el Pr&iacute;ncipe Oberyn y La Monta&ntilde;a.</li>
<li>El camino del rey, normalmente la mayor&iacute;a de visitantes se dirigen al tope del monte de Srdj por vistas espectaculares, pero nosotros iremos all&iacute; por la carretera que lleva a Desembarco del Rey. Foto parada es obligatoria.</li>
</ul>',
'<strong>Que est&aacute; incluido:</strong>
<ul>
<li>Minivan recogida desde plaza de Pile</li>
<li>Gu&iacute;a Oficial de Turismo</li>
<li>Entrada en jard&iacute;n bot&aacute;nico en Trsteno</li>
<li>El traslado a Dubrovnik, el centro</li>
</ul>',
'<strong>Punto de encuentro: Plaza de Pile, busca el gu&iacute;a con bandera Targaryen</strong>
<em>ONLINE BOOKING: reserva para Juego de Tronos tour en veh&iacute;culo es obligatoria.</em>
<em>El pago se realiza en efectivo en lugar te encuentro (aparezca 10 minutos antes del tour)o a trav&eacute;s Internet con 10 por ciento de descuento!</em>
<em>Tours privados, manda nos un correo electr&oacute;nico por lo menos un d&iacute;a por adelantado, vamos a crear un tour para Usted, ajustado a sus deseos, tiempo e intereses</em>',
't',
'f',
2,
225.0000,
900.0000,
NULL,
5.00,
3.00,
2,
'tour-privado-juego-de-tronos-tour-en-vehículo',
'2018-04-30 02:02:24.335954+00',
'2018-04-30 02:02:24.335954+00',
1);


----------------------------------
-- INSERT CABLE CAR DUBROVNIK TOURS
----------------------------------
----------------------------------
-- INSERT CABLE CAR DUBROVNIK TOURS
----------------------------------
INSERT INTO "public"."tour" VALUES (
45, 
'Walking tour',
'The Old City of Dubrovnik is the best preserved old city in the world. As soon as you step inside you will understand that the people who built the place had to have a lot of money just to build it.',
'The Old City of Dubrovnik is the best preserved old city in the world. As soon as you step inside you will understand that the people who built the place had to have a lot of money just to build it. Meaning that they where an important player on a global scale. Let us represent you their world, their diplomacy, daily life and a constant struggle to maintain the most sacred of all – FREEDOM.',
'<strong>WHAT IS INCLUDED:</strong>
<ul>
<li><b>Arriving on one of the cruise ships? Pick up just infront of the port is available!</b></li>
</ul>',
'<strong>WHAT IS NOT INCLUDED:</strong>
<ul>
<li><b>Semi-private tours</b> where the tour becomes a dialogue rather than just listening to a monologue - <b>Maximum 8 guests per guide!</b></li>
<li><b>Tickets for the cable car ride are not included in the price and will be paid directly at the site!</b></li>
</ul>
</br>
<em><b>Note:</b>For additional languages or any other information please contact us!!!</em>
<br>',
't',
'f',
3,
150.0000,
NULL,
85.0000,
NULL,
1.50,
1,
'discover-dubrovnik-old-town', 
'2020-02-10 12:02:24.335954+00',
'2020-02-10 12:02:24.335954+00',
4);

INSERT INTO "public"."tour" VALUES (
46, 
'Walking Tour + Cable car',
'2h tour that combines a walking tour in the Old City and the cable car ride with total cost 170kn per person and 85kn for children between 4 and 12 years old.',
'On this tour you will be able to get to know the cool sights of the old town, including its past as well as its present. You will also have the opportunity to experience a cable car ride. If you are a fan of the beautiful views from the sky and history you will not regret if you book this tour. It is important to emphasize that sometimes it takes longer to take a cable car ride because of the crowds in the queues, so you need to have some patience.',
'<strong>WHAT IS INCLUDED:</strong>
<ul>
<li><b>Arriving on one of the cruise ships? Pick up just infront of the port is available!</b></li>
</ul>',
'<strong>WHAT IS NOT INCLUDED:</strong>
<ul>
<li><b>Tickets for the cable car ride are not included in the price and will be paid directly at the site!</b></li>
</ul>
</br>
<b>"IF THE CABLE CAR TICKET PRICE CHANGES WE WILL INFORM YOU OF THE CHANGE AS SOON AS POSSIBLE."</b></br></br>
<b>"THE TOUR CAN LAST SOMEWHAT LONGER BECAUSE OF THE CABLE CAR LINE, THERE IS STILL NO SKIPPING THE LINE."</b></br></br>
<em><b>Note:</b>For additional languages or any other information please contact us!!!</em>
<br>',
't',
'f',
3,
170.0000,
NULL,
85.0000,
NULL,
2.00,
1,
'Walking-tour-cable-car', 
'2020-02-10 12:02:24.335954+00',
'2020-02-10 12:02:24.335954+00',
4);

INSERT INTO "public"."tour" VALUES (
47, 
'Walking Tour + Panoramic drive',
'3h tour that combines a walking tour in the Old City and the Panoramic drive tour with total cost 290kn per person and 145kn for children between 4 and 12 years old.',
'On this tour you will be able to get to know the cool sights of the old town, including its past as well as its present. You will also have the opportunity to experience a cable car ride. If you are a fan of the beautiful views from the sky and history you will not regret if you book this tour. It is important to emphasize that sometimes it takes longer to take a cable car ride because of the crowds in the queues, so you need to have some patience.',
'<strong>WHAT IS INCLUDED:</strong>
<ul>
<li><b>For 4 or more guests pick up in Dubrovnik is included in the price.</b></li>
<li><b>For 1 to 3 guests pick up is 50kn per location.</b></li>
</ul>',
'<strong>WHAT IS NOT INCLUDED:</strong>
<ul>
<li><b>Tickets for the cable car ride are not included in the price and will be paid directly at the site!</b></li>
</ul>
</br>
<em><b>Note:</b>For additional languages or any other information please contact us!!!</em>
<br>',
't',
'f',
3,
290.0000,
NULL,
145.0000,
NULL,
3.00,
1,
'Walking-tour-cable-car', 
'2020-02-10 12:02:24.335954+00',
'2020-02-10 12:02:24.335954+00',
4);

INSERT INTO "public"."tour" VALUES (
48, 
'Panoramic drive',
'This tour does not use the cable car. Instead you will travel by an airconditioned vehicle to the upper cable car station and Imperial fort and you will enjoy the best panoramic views of the area.',
'This tour does not use the cable car. Instead you will travel by an airconditioned vehicle to the upper cable car station and Imperial fort and you will enjoy the best panoramic views of the area. Bigger vehicles can not use that road and it is recommended to do this with a professional driver to avoid additional costs of your rent-a-car. Then again, who can tell you stories about the area and the last war better than a local?
</br>
<div class="tour-db-image-container">
<img class="tour-db-image" src="/tour-images/tour_48_image_1.jpg" />
</div>
On your way up to the top you will make an extra stop. At this spot you will be blessed with the perfect angle to make the best photos of the Old City. Also you are about half way between strongholds of defenders and the attackers in the Homeland war. During the entire time of the siege on Dubrovnik in 1991./92. this was a place of constant fighting.
</br>
<div class="tour-db-image-container">
<img class="tour-db-image" src="/tour-images/tour_48_image_2.jpg" />
</div>
Another stop for you is dr. Franja Tuđmana bridge. This is also a newer addition to our beautiful city. It was finished building in 2002. At the time it was the most expensive bridge in Croatia. On top of all that it is a nice spot for you to see the new part of Dubrovnik, the area not visable from the hill.
</br>
<div class="tour-db-image-container">
<img class="tour-db-image" src="/tour-images/tour_48_image_4.jpg" />
</div>
On the other side of the hill you will see the Europe''s shortest river. It has a flow of about 35 - 65 meters (115 - 215 feet). Don''t underestimate this short beast, it''s spring creates a yearly average of about 23 m3 of water per second (over 6000 gallons per second). Through a sistem of underground caves the entire river rushes out from the ground and after the waterfall it is not powerful enough to push the sea away so it becomes a bay.
<div class="tour-db-image-container">
<img class="tour-db-image" src="/tour-images/tour_48_image_3.jpg" />
</div>',
'<strong>WHAT IS INCLUDED:</strong>
<ul>
<li>45 minutes on stops</li>
<li>4 stops included</li>
<li>8 people max per vehicle</li>
<li>Arriving on one of the cruise ships? Pick up just infront of the port is available!</li>
<li><b>For 4 or more guests pick up in Dubrovnik is included in the price.</b></li>
</ul>',
'<strong>WHAT IS NOT INCLUDED:</strong>
<ul>
<li><b>For 1 to 3 guests pick up is not free and you will be charged for 50kn per each location.</b></li>
</ul>
</br>
<em><b>Note:</b> For additional languages or any other information please contact us!!!</em>
<br>',
't',
'f',
3,
170.0000,
NULL,
85.0000,
NULL,
1.50,
1,
'panoramic-drive', 
'2020-02-10 12:02:24.335954+00',
'2020-02-10 12:02:24.335954+00',
4);

-- ----------------------------
-- Primary Key structure for table tour
-- ----------------------------
ALTER TABLE "public"."tour" ADD CONSTRAINT "tour_pkey" PRIMARY KEY ("id");