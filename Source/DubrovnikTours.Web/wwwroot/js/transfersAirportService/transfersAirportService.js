/******/ (function(modules) { // webpackBootstrap
/******/ 	// install a JSONP callback for chunk loading
/******/ 	function webpackJsonpCallback(data) {
/******/ 		var chunkIds = data[0];
/******/ 		var moreModules = data[1];
/******/ 		var executeModules = data[2];
/******/
/******/ 		// add "moreModules" to the modules object,
/******/ 		// then flag all "chunkIds" as loaded and fire callback
/******/ 		var moduleId, chunkId, i = 0, resolves = [];
/******/ 		for(;i < chunkIds.length; i++) {
/******/ 			chunkId = chunkIds[i];
/******/ 			if(Object.prototype.hasOwnProperty.call(installedChunks, chunkId) && installedChunks[chunkId]) {
/******/ 				resolves.push(installedChunks[chunkId][0]);
/******/ 			}
/******/ 			installedChunks[chunkId] = 0;
/******/ 		}
/******/ 		for(moduleId in moreModules) {
/******/ 			if(Object.prototype.hasOwnProperty.call(moreModules, moduleId)) {
/******/ 				modules[moduleId] = moreModules[moduleId];
/******/ 			}
/******/ 		}
/******/ 		if(parentJsonpFunction) parentJsonpFunction(data);
/******/
/******/ 		while(resolves.length) {
/******/ 			resolves.shift()();
/******/ 		}
/******/
/******/ 		// add entry modules from loaded chunk to deferred list
/******/ 		deferredModules.push.apply(deferredModules, executeModules || []);
/******/
/******/ 		// run deferred modules when all chunks ready
/******/ 		return checkDeferredModules();
/******/ 	};
/******/ 	function checkDeferredModules() {
/******/ 		var result;
/******/ 		for(var i = 0; i < deferredModules.length; i++) {
/******/ 			var deferredModule = deferredModules[i];
/******/ 			var fulfilled = true;
/******/ 			for(var j = 1; j < deferredModule.length; j++) {
/******/ 				var depId = deferredModule[j];
/******/ 				if(installedChunks[depId] !== 0) fulfilled = false;
/******/ 			}
/******/ 			if(fulfilled) {
/******/ 				deferredModules.splice(i--, 1);
/******/ 				result = __webpack_require__(__webpack_require__.s = deferredModule[0]);
/******/ 			}
/******/ 		}
/******/
/******/ 		return result;
/******/ 	}
/******/
/******/ 	// The module cache
/******/ 	var installedModules = {};
/******/
/******/ 	// object to store loaded and loading chunks
/******/ 	// undefined = chunk not loaded, null = chunk preloaded/prefetched
/******/ 	// Promise = chunk loading, 0 = chunk loaded
/******/ 	var installedChunks = {
/******/ 		"transfersAirportService": 0
/******/ 	};
/******/
/******/ 	var deferredModules = [];
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
/******/ 	var jsonpArray = window["webpackJsonp"] = window["webpackJsonp"] || [];
/******/ 	var oldJsonpFunction = jsonpArray.push.bind(jsonpArray);
/******/ 	jsonpArray.push = webpackJsonpCallback;
/******/ 	jsonpArray = jsonpArray.slice();
/******/ 	for(var i = 0; i < jsonpArray.length; i++) webpackJsonpCallback(jsonpArray[i]);
/******/ 	var parentJsonpFunction = oldJsonpFunction;
/******/
/******/
/******/ 	// add entry module to deferred list
/******/ 	deferredModules.push(["./src/js/transfersAirportService.js","vendors"]);
/******/ 	// run deferred modules when ready
/******/ 	return checkDeferredModules();
/******/ })
/************************************************************************/
/******/ ({

/***/ "./src/js/transfersAirportService.js":
/*!*******************************************!*\
  !*** ./src/js/transfersAirportService.js ***!
  \*******************************************/
/*! no exports provided */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var jquery_ui_ui_widgets_datepicker__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! jquery-ui/ui/widgets/datepicker */ "./node_modules/jquery-ui/ui/widgets/datepicker.js");
/* harmony import */ var jquery_ui_ui_widgets_datepicker__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(jquery_ui_ui_widgets_datepicker__WEBPACK_IMPORTED_MODULE_0__);
/* harmony import */ var jquery_ui_themes_base_core_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! jquery-ui/themes/base/core.css */ "./node_modules/jquery-ui/themes/base/core.css");
/* harmony import */ var jquery_ui_themes_base_core_css__WEBPACK_IMPORTED_MODULE_1___default = /*#__PURE__*/__webpack_require__.n(jquery_ui_themes_base_core_css__WEBPACK_IMPORTED_MODULE_1__);
/* harmony import */ var jquery_ui_themes_base_datepicker_css__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! jquery-ui/themes/base/datepicker.css */ "./node_modules/jquery-ui/themes/base/datepicker.css");
/* harmony import */ var jquery_ui_themes_base_datepicker_css__WEBPACK_IMPORTED_MODULE_2___default = /*#__PURE__*/__webpack_require__.n(jquery_ui_themes_base_datepicker_css__WEBPACK_IMPORTED_MODULE_2__);
/* harmony import */ var jquery_ui_themes_base_theme_css__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! jquery-ui/themes/base/theme.css */ "./node_modules/jquery-ui/themes/base/theme.css");
/* harmony import */ var jquery_ui_themes_base_theme_css__WEBPACK_IMPORTED_MODULE_3___default = /*#__PURE__*/__webpack_require__.n(jquery_ui_themes_base_theme_css__WEBPACK_IMPORTED_MODULE_3__);
/* harmony import */ var jquery_scrollbar__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! jquery.scrollbar */ "./node_modules/jquery.scrollbar/index.js");
/* harmony import */ var jquery_scrollbar__WEBPACK_IMPORTED_MODULE_4___default = /*#__PURE__*/__webpack_require__.n(jquery_scrollbar__WEBPACK_IMPORTED_MODULE_4__);
/* harmony import */ var jquery_scrollbar_sass_jquery_scrollbar_scss__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! jquery.scrollbar/sass/jquery.scrollbar.scss */ "./node_modules/jquery.scrollbar/sass/jquery.scrollbar.scss");
/* harmony import */ var jquery_scrollbar_sass_jquery_scrollbar_scss__WEBPACK_IMPORTED_MODULE_5___default = /*#__PURE__*/__webpack_require__.n(jquery_scrollbar_sass_jquery_scrollbar_scss__WEBPACK_IMPORTED_MODULE_5__);







function getAirportToDestinationTransferPrice() {
  let airportSelectedIndex = $(".form-airport-selector option:selected").index();
  let groupSelectedIndex = $(".form-number-selector option:selected").index();
  let destinationSelectedIndex = $(".form-location-selector option:selected").index();
  const airportId = airportSelectedIndex + 1;
  const groupType = groupSelectedIndex + 1;
  const destinationId = destinationSelectedIndex + 1;
  const totalPriceInput = $("#total-price");
  const userDisplayPriceInput = $("#airport-service-price");
  const transferDistanceInput = $("#transfer-distance");
  const transferDurationInput = $("#transfer-duration");
  let transferType = $('#transfer-type');
  $.ajax({
    type: 'GET',
    url: '/api/prices/transfer/airport/service/price/' + airportId + "/" + groupType + "/" + destinationId,
    contentType: 'application/json; charset=UTF-8'
  }).done(function (data) {
    const {
      totalPrice,
      transferDistance,
      transferDuration,
      serviceCounted
    } = data;
    transferDistanceInput.val(transferDistance);
    transferDurationInput.val(transferDuration);
    totalPriceInput.val(totalPrice);
    userDisplayPriceInput.val(totalPrice + " HRK");
    transferType.val(serviceCounted);
    console.log(data);
  }).fail(function (error) {
    console.log("Failure!", error);
  });
}

getAirportToDestinationTransferPrice(); //IF AIRPORT IS CHANGED SWAP LOCATIONS

$('.form-airport-selector').change(function () {
  getAirportToDestinationTransferPrice();
}); //IF LOCATION IS CHANGED SHOW DIFFERENT PRICE

$('.form-number-selector').change(function () {
  getAirportToDestinationTransferPrice();
}); //IF LOCATION IS CHANGED SHOW DIFFERENT PRICE

$('.form-location-selector').change(function () {
  getAirportToDestinationTransferPrice();
}); //IF SERVICE TYPE (DIRECTION) IS CHANGED SWAP LOCATIONS

$('.form-direction-selector').change(function () {
  let selectedDirectionIndex = $(".form-direction-selector option:selected").index();
  let selectedStart = $('.form-airport-selector').children("option:selected").val();
  let selectedEnd = $('.form-location-selector').children("option:selected").val();

  if (selectedDirectionIndex == 0) {
    $('#start-label').show();
    $('#end-label').hide();
    $('.direction-indicator').html("DEPARTURE");
    $('#location-a').val(selectedStart);
    $('#location-b').val(selectedEnd);
  } else {
    $('#start-label').hide();
    $('#end-label').show();
    $('.direction-indicator').html("ARRIVAL");
    $('#location-a').val(selectedStart);
    $('#location-b').val(selectedEnd);
  }
});
$('#airport-service-btn').on("click", function () {
  $("#map").css({
    'visibility': 'hidden'
  });
  $('.transfer-cards-container').hide();
  let selectedDirectionIndex = $(".form-direction-selector option:selected").index();

  if (selectedDirectionIndex == 0) {
    let selectedStart = $('.form-location-selector').children("option:selected").val();
    let selectedEnd = $('.form-airport-selector').children("option:selected").val();
    $('#location-a').val(selectedStart);
    console.log(selectedStart);
    $('#location-b').val(selectedEnd);
    console.log(selectedEnd);
    $('#transfer-price').val($("#total-price").val() + " HRK");
  } else {
    let selectedStart = $('.form-airport-selector').children("option:selected").val();
    let selectedEnd = $('.form-location-selector').children("option:selected").val();
    $('#location-a').val(selectedStart);
    console.log(selectedStart);
    $('#location-b').val(selectedEnd);
    console.log(selectedEnd);
    $('#transfer-price').val($("#total-price").val() + " HRK");
  }

  let selectedGroupIndex = $(".form-number-selector option:selected").index();

  if (selectedGroupIndex == 0) {
    if ($('#location-a').val() !== "" && $('#location-b').val() !== "") $('.page-transfers-form-container').fadeIn(1000);
    $("#reservation-text").html("SMALL GROUP RESERVATION <br/>(1 - 4 PERSONS)");
    $("#number-of-people").val(1);
    $("#number-of-people").attr({
      "max": 4,
      "min": 1
    });
    $('#submit-form-request').hide();
    $('#submit-form').show();
  } else if (selectedGroupIndex == 1) {
    if ($('#location-a').val() !== "" && $('#location-b').val() !== "") $('.page-transfers-form-container').fadeIn(1000);
    $("#reservation-text").html("MEDIUM GROUP RESERVATION <br/> (5-8 PERSONS)");
    $("#number-of-people").val(5);
    $("#number-of-people").attr({
      "max": 8,
      "min": 5
    });
    $('#submit-form-request').hide();
    $('#submit-form').show();
  } else {
    $('.page-transfers-form-container').fadeIn(1000);
    $("#reservation-text").html("LARGE GROUP REQUEST <br/>(9+ PERSONS)");
    $("#number-of-people").val(10);
    $("#number-of-people").attr({
      "max": 1000,
      "min": 9
    });
    $('#submit-form-request').show();
    $('#submit-form').hide();
  } //SCROLL BOOKING FORM SMOOTH


  $('html, body').animate({
    scrollTop: $(".page-transfers-calculations-container").offset().top - 10
  }, 500);
}); // TOUR - BOOKING FORM - VALIDATION MODALS

(function (w) {
  $('.tour-info-text-content').scrollbar(); //TOUR BOOKING FORM - DATAPICKER FUNCTION FOR INACTIVE DATES

  w.createDatePicker = function (selector, inactiveDuringVacation, yearlyVacations) {
    const now = new Date(Date.now());
    const nowDateOnly = new Date(now.getFullYear(), now.getMonth(), now.getDate()).getTime();
    $(selector).datepicker({
      minDate: 0,
      beforeShowDay: function (date) {
        const currentDate = date.getTime();
        const isTodayOrAfter = currentDate >= nowDateOnly;

        if (!inactiveDuringVacation) {
          return [isTodayOrAfter];
        }

        const year = date.getFullYear();
        const vacations = yearlyVacations[year];

        if (!vacations) {
          return [isTodayOrAfter];
        }

        const valid = isTodayOrAfter && isNotDuringVacation(currentDate, vacations);
        return [valid];
      },
      dateFormat: 'mm-dd-yy',
      defaultDate: now
    });

    function isNotDuringVacation(date, vacations) {
      for (let i = 0; i < vacations.length; i++) {
        const vacation = vacations[i];

        if (date >= vacation.start && date <= vacation.end) {
          return false;
        }
      }

      return true;
    }
  };
})(window);

/***/ }),

/***/ "jquery":
/*!*************************!*\
  !*** external "jQuery" ***!
  \*************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = jQuery;

/***/ })

/******/ });
//# sourceMappingURL=transfersAirportService.js.map