/******/ (function(modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};
/******/
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/
/******/ 		// Check if module is in cache
/******/ 		if(installedModules[moduleId]) {
/******/ 			return installedModules[moduleId].exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			i: moduleId,
/******/ 			l: false,
/******/ 			exports: {}
/******/ 		};
/******/
/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/
/******/ 		// Flag the module as loaded
/******/ 		module.l = true;
/******/
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/
/******/
/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;
/******/
/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;
/******/
/******/ 	// define getter function for harmony exports
/******/ 	__webpack_require__.d = function(exports, name, getter) {
/******/ 		if(!__webpack_require__.o(exports, name)) {
/******/ 			Object.defineProperty(exports, name, { enumerable: true, get: getter });
/******/ 		}
/******/ 	};
/******/
/******/ 	// define __esModule on exports
/******/ 	__webpack_require__.r = function(exports) {
/******/ 		if(typeof Symbol !== 'undefined' && Symbol.toStringTag) {
/******/ 			Object.defineProperty(exports, Symbol.toStringTag, { value: 'Module' });
/******/ 		}
/******/ 		Object.defineProperty(exports, '__esModule', { value: true });
/******/ 	};
/******/
/******/ 	// create a fake namespace object
/******/ 	// mode & 1: value is a module id, require it
/******/ 	// mode & 2: merge all properties of value into the ns
/******/ 	// mode & 4: return value when already ns object
/******/ 	// mode & 8|1: behave like require
/******/ 	__webpack_require__.t = function(value, mode) {
/******/ 		if(mode & 1) value = __webpack_require__(value);
/******/ 		if(mode & 8) return value;
/******/ 		if((mode & 4) && typeof value === 'object' && value && value.__esModule) return value;
/******/ 		var ns = Object.create(null);
/******/ 		__webpack_require__.r(ns);
/******/ 		Object.defineProperty(ns, 'default', { enumerable: true, value: value });
/******/ 		if(mode & 2 && typeof value != 'string') for(var key in value) __webpack_require__.d(ns, key, function(key) { return value[key]; }.bind(null, key));
/******/ 		return ns;
/******/ 	};
/******/
/******/ 	// getDefaultExport function for compatibility with non-harmony modules
/******/ 	__webpack_require__.n = function(module) {
/******/ 		var getter = module && module.__esModule ?
/******/ 			function getDefault() { return module['default']; } :
/******/ 			function getModuleExports() { return module; };
/******/ 		__webpack_require__.d(getter, 'a', getter);
/******/ 		return getter;
/******/ 	};
/******/
/******/ 	// Object.prototype.hasOwnProperty.call
/******/ 	__webpack_require__.o = function(object, property) { return Object.prototype.hasOwnProperty.call(object, property); };
/******/
/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "";
/******/
/******/
/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(__webpack_require__.s = "./src/js/transfersMapService.js");
/******/ })
/************************************************************************/
/******/ ({

/***/ "./src/js/transfersMapService.js":
/*!***************************************!*\
  !*** ./src/js/transfersMapService.js ***!
  \***************************************/
/*! no static exports found */
/***/ (function(module, exports) {

let distance = $("#transfer-distance");
let smallPriceInput = $("#small-price");
let mediumPriceInput = $("#medium-price");
let smallTransferCardPrice = $("#small-transfer-card-price");
let mediumTransferCardPrice = $("#medium-transfer-card-price");

function getTransferPrices() {
  $.ajax({
    type: 'GET',
    url: '/api/prices/google/map/transfer/price/' + distance,
    contentType: 'application/json; charset=UTF-8'
  }).done(function (data) {
    const {
      smallGroupPrice,
      mediumGroupPrice
    } = data;
    smallPriceInput.val(smallGroupPrice);
    mediumPriceInput.val(mediumGroupPrice);
    smallTransferCardPrice.text(smallGroupPrice + " HRK");
    mediumTransferCardPrice.text(mediumGroupPrice + " HRK");
    console.log(data);
  }).fail(function (error) {
    console.log("Failure!", error);
  });
}

function displayMapWithValues() {
  $("#map").css({
    'visibility': 'visible'
  });
  $("#transfer-cards").show();
  $(".form-container").show(); //SCROLL TO GOOGLE MAP BASED ON RESOLUTION

  $('html, body').animate({
    scrollTop: $("#map").offset().top - 100
  }, 1000);
  $('.new-calculation').show();
  $(".show-route-loader").hide();
}

$('#from-input').keypress(function (event) {
  if (event.keyCode == 13) {
    event.preventDefault();
  }
});
$('#to-input').keypress(function (event) {
  if (event.keyCode == 13) {
    event.preventDefault();
  }
}); //EMPTY ALL VALUES

function emptyAllFieldValues() {
  $('#from-input').val('');
  $('#to-input').val('');
  $(".location-a").val('');
  $(".location-b").val('');
  $(".distance").val('');
  $(".user-distance").val('');
  $(".duration").val('');
  $("#location-a").val('');
  $("#location-b").val('');
  $("#transfer-distance").val('');
  $("#transfer-duration").val('');
  $("#small-transfer-price").empty();
  $("#medium-transfer-price").empty();
  $("#small-price").empty();
  $("#medium-price").empty();
  $("#total-price").empty();
  $('.page-transfers-form-container').hide();
}

$('#reset-map-calculation-btn').on("click", function () {
  emptyAllFieldValues();
  hideMapWithValues();
  $('.new-calculation').fadeOut(500);
});

function hideMapWithValues() {
  $("#map").css({
    'visibility': 'hidden'
  });
  $('.transfer-cards-container').hide();
}

let transferType = $('#transfer-type');
$('#book-small-group').click(function () {
  transferType.val("TRANSFER CALCULATION");
  $('#location-a').val($(".location-a").val());
  $('#location-b').val($(".location-b").val());
  $('#transfer-distance').val($(".distance").val());
  $('#transfer-duration').val($(".duration").val());
  $('#total-price').val($("#small-price").val());
  $('#transfer-price').val($("#small-price").val() + " HRK");
  if ($('#location-a').val() !== "" && $('#location-b').val() !== "") $('.page-transfers-form-container').fadeIn(1000);
  $("#reservation-text").html("SMALL GROUP RESERVATION <br/>(1 - 4 PERSONS)");
  $("#number-of-people").val(1);
  $("#number-of-people").attr({
    "max": 4,
    "min": 1
  });
  $('#submit-form-request').hide();
  $('#submit-form').show(); //SCROLL BOOKING FORM SMOOTH

  $('html, body').animate({
    scrollTop: $(".page-transfers-calculations-container").offset().top - 20
  }, 500);
});
$('#book-medium-group').click(function () {
  transferType.val("TRANSFER CALCULATION");
  $('#location-a').val($(".location-a").val());
  $('#location-b').val($(".location-b").val());
  $('#transfer-distance').val($(".distance").val());
  $('#transfer-duration').val($(".duration").val());
  $('#total-price').val($("#medium-price").val());
  $('#transfer-price').val($("#medium-price").val() + " HRK");
  if ($('#location-a').val() !== "" && $('#location-b').val() !== "") $('.page-transfers-form-container').fadeIn(1000);
  $("#reservation-text").html("MEDIUM GROUP RESERVATION <br/> (5-8 PERSONS)");
  $("#number-of-people").val(5);
  $("#number-of-people").attr({
    "max": 8,
    "min": 5
  });
  $('#submit-form-request').hide();
  $('#submit-form').show(); //SCROLL BOOKING FORM SMOOTH

  $('html, body').animate({
    scrollTop: $(".page-transfers-calculations-container").offset().top - 20
  }, 500);
});
$('#book-large-group').click(function () {
  transferType.val("TRANSFER CALCULATION");
  $('#location-a').val($(".location-a").val());
  $('#location-b').val($(".location-b").val());
  $('#transfer-distance').val($(".distance").val());
  $('#transfer-duration').val($(".duration").val());
  $('#total-price').val("Request");
  $('#transfer-price').val("ON REQUEST");
  if ($('#location-a').val() !== "" && $('#location-b').val() !== "") $('.page-transfers-form-container').fadeIn(1000);
  $("#reservation-text").html("LARGE GROUP REQUEST <br/>(9+ PERSONS)");
  $("#number-of-people").val(10);
  $("#number-of-people").attr({
    "max": 1000,
    "min": 9
  });
  $('#submit-form-request').show();
  $('#submit-form').hide(); //SCROLL BOOKING FORM SMOOTH

  $('html, body').animate({
    scrollTop: $(".page-transfers-calculations-container").offset().top - 20
  }, 500);
});
const errorModal = $('#errorMessage');
$('#closeErrorMessage').on("click", function () {
  $(".show-route-loader").hide(); //HIDE ERROR MESSAGE

  errorModal.hide();
  emptyAllFieldValues();
});

function initMap() {
  var map = new google.maps.Map(document.getElementById('map'), {
    zoom: 6,
    center: {
      lat: 42.6507,
      lng: 18.0944
    },
    mapTypeId: 'roadmap',
    disableDefaultUI: false,
    scrollwheel: false,
    navigationControl: true,
    mapTypeControl: false,
    scaleControl: true
  });
  var directionsDisplay = new google.maps.DirectionsRenderer();
  ;
  var directionsService = new google.maps.DirectionsService();
  directionsDisplay.setMap(map);
  var geocoder = new google.maps.Geocoder();
  var input1 = document.getElementById('from-input');
  var input2 = document.getElementById('to-input');
  var searchBox1 = new google.maps.places.SearchBox(input1);
  var searchBox2 = new google.maps.places.SearchBox(input2);
  map.addListener('bounds_changed', function () {
    searchBox1.setBounds(map.getBounds());
    searchBox2.setBounds(map.getBounds());
  });
  var markers1 = [];
  var markers2 = [];
  searchBox1.addListener('places_changed', function () {
    places_changed();
  });
  searchBox2.addListener('places_changed', function () {
    places_changed();
  });

  function places_changed() {
    console.clear();
    var places1 = searchBox1.getPlaces();

    if (places1 == null || places1.length == 0) {
      return;
    }

    markers1.forEach(function (marker) {
      marker.setMap(null);
    });
    markers1 = [];
    var bounds = new google.maps.LatLngBounds();
    places1.forEach(function (place) {
      if (!place.geometry) {
        console.log("Returned place contains no geometry");
        return;
      }

      var icon = {
        url: place.icon,
        size: new google.maps.Size(71, 71),
        origin: new google.maps.Point(0, 0),
        anchor: new google.maps.Point(0, 0),
        scaledSize: new google.maps.Size(25, 25)
      };
      markers1.push(new google.maps.Marker({
        map: map,
        icon: icon,
        title: place.name,
        position: place.geometry.location
      }));

      if (place.geometry.viewport) {
        bounds.union(place.geometry.viewport);
      } else {
        bounds.extend(place.geometry.location);
      }
    });
    var places2 = searchBox2.getPlaces();

    if (places2 == null || places2.length == 0) {
      return;
    }

    markers2.forEach(function (marker) {
      marker.setMap(null);
    });
    markers2 = [];
    places2.forEach(function (place) {
      if (!place.geometry) {
        console.log("Returned place contains no geometry");
        return;
      }

      var icon = {
        url: place.icon,
        size: new google.maps.Size(71, 71),
        origin: new google.maps.Point(0, 0),
        anchor: new google.maps.Point(0, 0),
        scaledSize: new google.maps.Size(25, 25)
      };
      markers2.push(new google.maps.Marker({
        map: map,
        icon: icon,
        title: place.name,
        position: place.geometry.location
      }));

      if (place.geometry.viewport) {
        bounds.union(place.geometry.viewport);
      } else {
        bounds.extend(place.geometry.location);
      }
    });
    map.fitBounds(bounds);

    if (markers1 != [] && markers2 != []) {
      var start = document.getElementById('from-input').value;
      var end = document.getElementById('to-input').value;
      var request = {
        origin: start,
        destination: end,
        travelMode: 'DRIVING'
      };

      if ($('#from-input').val() !== '' && $('#to-input').val() !== '') {
        directionsService.route(request, function (result, status) {
          if (status == 'OK') {
            $('#errorMessage').hide();
            markers1[0].setMap(null);
            markers2[0].setMap(null);
            directionsDisplay.setDirections(result);
            var inputDistanceResult = result.routes[0].legs[0].distance.value;
            var duration = directionsDisplay.directions.routes[0].legs[0].duration.text;
            inputDistanceResult = inputDistanceResult / 1000;
            var latlng = result.routes[0].legs[0].start_location;
            geocoder.geocode({
              'placeId': result.geocoded_waypoints[result.geocoded_waypoints.length - 1].place_id,
              'language': 'hr'
            }, function (results, status) {
              if (status === 'OK') {
                console.log("Ending position:");
                console.log(results);

                if (results[0]) {
                  var searchAddressComponents = results[0].address_components,
                      endInDubrovackoNeretvanska = "";
                  endInForeignCountry = "";
                  $.each(searchAddressComponents, function () {
                    if (this.types[0] == "administrative_area_level_1") {
                      if (this.short_name === "Dubrovačko-neretvanska županija") {
                        endInDubrovackoNeretvanska = true;
                      } else {
                        endInDubrovackoNeretvanska = false;
                      }
                    }

                    if (this.types[0] == "country") {
                      if (this.short_name !== "HR") {
                        endInForeignCountry = true;
                      } else {
                        endInForeignCountry = false;
                      }
                    }
                  });
                  endQuery(endInDubrovackoNeretvanska);
                }
              }
            });

            function endQuery(endInDubrovackoNeretvanska) {
              geocoder.geocode({
                'location': latlng,
                'language': 'hr'
              }, function (results, status) {
                if (status === 'OK') {
                  console.log("Starting position:");
                  console.log(results);
                  console.log("-------------------------------");

                  if (results[0]) {
                    var searchPostalCode = "",
                        startInDubrovackoNeretvanska = "",
                        startInForeignCountry = "";
                    searchAdminArea = "";
                    $.each(results, function () {
                      $.each(this.address_components, function () {
                        if (this.types[0] == "postal_code") {
                          searchPostalCode = this.long_name;
                        }

                        if (this.types[0] == "administrative_area_level_1") {
                          searchAdminArea = this.long_name;
                          startInDubrovackoNeretvanska = true;
                        }

                        if (this.types[0] == "administrative_area_level_1") {
                          if (this.short_name === "Dubrovačko-neretvanska županija") {
                            startInDubrovackoNeretvanska = true;
                          } else {
                            startInDubrovackoNeretvanska = false;
                          }
                        }

                        if (this.types[0] == "country") {
                          if (this.short_name !== "HR") {
                            startInForeignCountry = true;
                          } else {
                            startInForeignCountry = false;
                          }
                        }
                      });
                    });
                    let locationsValid = 1;

                    if (startInDubrovackoNeretvanska == false && endInDubrovackoNeretvanska == false) {
                      console.log("Selected locations are not in Dubrovacko-neretvanska Zupanija! Rule selectiom!");
                      $('#errorMessage').show();
                      $('#errorHeader').html("Selected locations are bad!");
                      $('#errorContent').html("Selected locations are far away from Dubrovnik! Starting or ending location must be in Dubrovacko-neretvanska Zupanija. Please select correct locations or contact our <a href=\"contact-us\" class=\"page-transfers-contact-link\" style=\"cursor:pointer;\">cutomer service</a>!");
                      emptyAllFieldValues();
                      hideMapWithValues();
                      locationsValid = 0;
                    } else if (inputDistanceResult == 0) {
                      console.log("Selected locations are the same!");
                      $('#errorMessage').show();
                      $('#errorHeader').html("Locations are not different!");
                      $('#errorContent').html("Selected locations are starting and ending at same place! We can't provide you this service! Please select different places. If you have any bad experiance please contact our <a href=\"contact-us\" class=\"page-transfers-contact-link\" style=\"cursor:pointer;\">cutomer service</a>!");
                      emptyAllFieldValues();
                      hideMapWithValues();
                      locationsValid = 0;
                    } else if (inputDistanceResult > 1000) {
                      console.log("Distance is too large! Rule 1000 km!");
                      $('#errorMessage').show();
                      $('#errorHeader').html("Distance is too large!");
                      $('#errorContent').html("Selected distance is larger than 1000 km! We can't provide you this service! Please select distance less than 1000 km or contact our <a href=\"contact-us\" class=\"page-transfers-contact-link\" style=\"cursor:pointer;\">cutomer service</a>!");
                      emptyAllFieldValues();
                      hideMapWithValues();
                      locationsValid = 0;
                    } else if (inputDistanceResult < 35 && !(searchPostalCode == 20000 || searchPostalCode == 20233 || searchPostalCode == 20234 || searchPostalCode == 20235 || searchPostalCode == 20236 || searchPostalCode == 20207 || searchPostalCode == 20210 || searchPostalCode == 20213 || searchPostalCode == 20232 || searchPostalCode == 20215)) {
                      console.log("Distance is bad for selected locations! Rule 35 km!");
                      $('#errorMessage').show();
                      $('#errorHeader').html("Distance is too small for this places!");
                      $('#errorContent').html("Selected distance must be greater than 35 km if this places are not selected: Dubrovnik, Trsteno, Orašac, Zaton, Mokošica, Kupari, Mlini, Srebreno, Plat, Cavtat, Čilipi, Slano, Gruda! We can't provide you this service! Please select places in this rule or contact our <a href=\"contact-us\" class=\"page-transfers-contact-link\" style=\"cursor:pointer;\">cutomer service</a>!");
                      emptyAllFieldValues();
                      hideMapWithValues();
                      locationsValid = 0;
                    } else if (inputDistanceResult < 35 && !(searchAdminArea === "Dubrovačko-neretvanska županija")) {
                      console.log("Distance is too is bad for selected locations! Rule 35 km!");
                      $('#errorMessage').show();
                      $('#errorHeader').html("Distance is too small for this places!");
                      $('#errorContent').html("Selected distance must be greater than 35 km if selected places are not within 150 km from Dubrovnik! We can't provide you this service! Please select places in this rule or contact our <a href=\"contact-us\" class=\"page-transfers-contact-link\" style=\"cursor:pointer;\">cutomer service</a>!");
                      emptyAllFieldValues();
                      hideMapWithValues();
                      locationsValid = 0;
                    }

                    let $startLocation = $("#location-a");
                    let $finalLocation = $("#location-b");
                    let $transferDuration = $("#transfer-duration");
                    $startLocation.attr('value', $('#from-input').val());
                    $finalLocation.attr('value', $('#to-input').val());
                    $("#transfer-distance").attr('value', inputDistanceResult.toFixed(2));
                    $transferDuration.attr('value', duration.toString());
                    distance = inputDistanceResult.toFixed(2);
                    getTransferPrices();

                    if (locationsValid === 1) {
                      displayMapWithValues();
                    } //SET TRANSFER CARD VALUES FOR USER DISPLAY


                    $(".location-a").val($('#from-input').val());
                    $(".location-b").val($('#to-input').val());
                    $(".distance").val(inputDistanceResult.toFixed(2));
                    $(".user-distance").val(inputDistanceResult.toFixed(2) + " km");
                    $(".duration").val(duration.toString()); //SET HIDDEN TRANSFER SUBMIT VALUES FROM DATA ATTRIBUTES

                    $("#location-a").val($('#from-input').val());
                    $("#location-b").val($('#to-input').val());
                    $("#transfer-distance").val($("#transfer-distance").attr('value'));
                    $("#transfer-duration").val($("#transfer-duration").attr('value'));
                    const englishHomeCountryPassportNotification = "Selected locations are in Croatia but be aware if you travel to or from Dubrovnik, we may cross country border. <b>Please bring your passports always with you!<b/>";
                    const englishForeignCountryPassportNotification = "Starting or ending location is in foreign country! <b>Please bring your passports always with you!<b/>";
                    const spanishHomeCountryPassportNotification = "Las ubicaciones seleccionadas están en Croacia, pero tenga en cuenta si viaja hacia o desde las partes occidentales de Croacia. <b> ¡Por favor traiga sus pasaportes siempre con usted! <b />";
                    const spanishForeignCountryPassportNotification = "¡La ubicación inicial o final está en un país extranjero! <b> ¡Por favor traiga sus pasaportes siempre con usted! <b />";
                    let language = $('#selectedLanguage').html();

                    if (startInForeignCountry === true || endInForeignCountry === true) {
                      if (language === "EN") {
                        $('#border-crossing').html(englishForeignCountryPassportNotification);
                      } else if (language === "ES") {
                        $('#border-crossing').html(spanishForeignCountryPassportNotification);
                      } else {
                        console.log("Culture not valid!");
                      }
                    } else {
                      if (language === "EN") {
                        $('#border-crossing').html(englishHomeCountryPassportNotification);
                      } else if (language === "ES") {
                        $('#border-crossing').html(spanishHomeCountryPassportNotification);
                      } else {
                        console.log("Culture not valid!");
                      }
                    }

                    console.log("Distance : " + inputDistanceResult.toFixed(2) + " km");
                    console.log("Starting point postal code : " + searchPostalCode);
                    console.log("Starting point administrative_area_level_1 : " + searchAdminArea);
                    console.log("In Dubrovacko-neretvanska zupanija? start: " + startInDubrovackoNeretvanska + ", end: " + endInDubrovackoNeretvanska);
                    console.log("In FOREIGN COUNTRY? start: " + startInForeignCountry + ", end: " + endInForeignCountry);
                    console.log("------------------------------");
                  } else {
                    window.alert('No results found');
                    emptyAllFieldValues();
                    hideMapWithValues();
                  }
                } else {
                  window.alert('Geocoder failed due to: ' + status);
                  emptyAllFieldValues();
                  hideMapWithValues();
                }
              });
            }
          }
        });
      }
    }
  }
}

window.initMap = initMap;

/***/ })

/******/ });
//# sourceMappingURL=transfersMapService.js.map