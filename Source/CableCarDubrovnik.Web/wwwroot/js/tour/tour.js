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
/******/ 		"tour": 0
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
/******/ 	deferredModules.push(["./src/js/tour.js","vendors"]);
/******/ 	// run deferred modules when ready
/******/ 	return checkDeferredModules();
/******/ })
/************************************************************************/
/******/ ({

/***/ "./src/js/tour.js":
/*!************************!*\
  !*** ./src/js/tour.js ***!
  \************************/
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





 // CHANGE HREF LINKS TO REDIRECT TO HOME PAGE SECTIONS

let homeUrl = '/';
let btn1Href = $('.header-menu a:nth-child(2)');
let btn2Href = $('.header-menu a:nth-child(3)');
let btn3Href = $('.header-menu a:nth-child(4)');
let btn4Href = $('.header-menu a:nth-child(5)');
let btn5Href = $('.header-menu a:nth-child(6)');
let btn6Href = $('.header-menu a:nth-child(7)');
let link1Href = $('.header-menu a:nth-child(2)').attr("href");
let link2Href = $('.header-menu a:nth-child(3)').attr("href");
let link3Href = $('.header-menu a:nth-child(4)').attr("href");
let link4Href = $('.header-menu a:nth-child(5)').attr("href");
let link5Href = $('.header-menu a:nth-child(6)').attr("href");
let link6Href = $('.header-menu a:nth-child(7)').attr("href");
link1Href = link1Href.substring(1);
link2Href = link2Href.substring(1);
link3Href = link3Href.substring(1);
link4Href = link4Href.substring(1);
link5Href = link5Href.substring(1);
link6Href = link6Href.substring(1);
btn1Href.attr("href", homeUrl + "#scroll:" + link1Href);
btn2Href.attr("href", homeUrl + "#scroll:" + link2Href);
btn3Href.attr("href", homeUrl + "#scroll:" + link3Href);
btn4Href.attr("href", homeUrl + "#scroll:" + link4Href);
btn5Href.attr("href", homeUrl + "#scroll:" + link5Href);
btn6Href.attr("href", homeUrl + "#scroll:" + link6Href); // GO BACK - BUTTON CLICK FUNCTION

$('#go-back').click(function () {
  window.history.back();
}); // TOUR - BOOKING FORM - VALIDATION MODALS

(function (w) {
  $('.tour-info-text-content').scrollbar(); //TOUR - BOOKING FORM - SUBMIT FUNCTION

  $('#submit-form').click(function () {
    if ($(".ac-checkout-container").length > 0 && $('.modal-window-close').attr('clicked') != true) {
      $('#btn-checkout-full').remove();
      $('#btn-checkout-deposit').remove();
    }

    var msg = $('#form-msg');
    msg.removeClass();
    msg.empty();
    const form = $('#booking');
    const validator = form.validate();

    if (!form.valid()) {
      return;
    } // clear field state


    const errors = form.find('.field-validation-error span');
    errors.each(function () {
      validator.settings.success($(this));
    }); // clear validation summary

    form.find("[data-valmsg-summary=true]").removeClass("validation-summary-errors").addClass("validation-summary-valid").find("ul").empty();
    $(".payment-method-modal").fadeIn().css("display", "flex");
  }); //TOUR BOOKING FORM - DATAPICKER FUNCTION FOR INACTIVE DATES

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

const tourId = $('#tourType').text();
const pickupDropDown = $(".pickup-included-dropdown");
const pickupPoint = $('#pick-up-point');
const pickupDropDownStarrIndexValue = $(pickupDropDown).find(":selected").val();

if (tourId === "47" || tourId === "48") {
  pickupDropDown.css("display", "block");
  pickupPoint.text(pickupDropDownStarrIndexValue);
} else {
  pickupDropDown.css("display", "none");
}

console.log(tourId);
$(pickupDropDown).change(function () {
  let pickupDropDownIndexValue = $(this).find(":selected").val();
  const pickupTextAreaContainer = $('.pickup-textarea-container');

  if (pickupDropDownIndexValue === "Other location...") {
    pickupTextAreaContainer.css("display", "block");
    pickupPoint.text("");
    pickupPoint.focus();
  } else {
    pickupTextAreaContainer.css("display", "none");
    pickupPoint.text(pickupDropDownIndexValue);
  }

  console.log(pickupDropDownIndexValue);
});

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
//# sourceMappingURL=tour.js.map