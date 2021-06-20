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
/******/ 	return __webpack_require__(__webpack_require__.s = "./src/js/cookie-consent.js");
/******/ })
/************************************************************************/
/******/ ({

/***/ "./src/js/cookie-consent.js":
/*!**********************************!*\
  !*** ./src/js/cookie-consent.js ***!
  \**********************************/
/*! no static exports found */
/***/ (function(module, exports) {

//GDPR COOKIES - BUTTONS FUNCTION
(function () {
  let selectedCookies = {
    basic: true,
    functional: false
  };
  $('#buttonAllCookies').click(function () {
    $('.modal.cookie-modal').fadeOut();
  });
  $('#buttonSelectedCookies').click(function () {
    if ($('.cookie-descriptions-description.cookie-descriptions-description-functional').hasClass('is-active')) {
      WriteTrackingCookie();
      $('.modal.cookie-modal').fadeOut();
    } else {
      $('.modal.cookie-modal').fadeOut();
    }
  });
  $('.cookie-modal-toggle').click(function () {
    $('.cookie-modal-basic').toggle();
    $('.cookie-modal-advanced').toggle();
  });
  $('#functional-cookies').change(function () {
    $('.cookie-descriptions-description.cookie-descriptions-description-functional').toggleClass('is-active');
    selectedCookies.functional = !selectedCookies.functional;
  });
})(); //  GDPR COOKIE CONSENT - ACCEPT ALL COOKIES BUTTON CLICK FUNCTION


(function () {
  const buttonAllCookies = document.querySelector("#buttonAllCookies[data-cookie-string]");

  if (buttonAllCookies) {
    buttonAllCookies.addEventListener("click", function (event) {
      document.cookie = buttonAllCookies.dataset.cookieString;
      WriteTrackingCookie();
    }, false);
  }
})(); // GDPR COOKIE CONSENT - ACCEPT SELECTED COOKIES BUTTON CLICK FUNCTION


(function () {
  const buttonSelectedCookies = document.querySelector("#buttonSelectedCookies[data-cookie-string]");

  if (buttonSelectedCookies) {
    buttonSelectedCookies.addEventListener("click", function (event) {
      document.cookie = buttonSelectedCookies.dataset.cookieString;
    }, false);
  }
})(); // GDPR COOKIE CONSENT - CREATE TRACKING COOKIE FUNCTION


function WriteTrackingCookie() {
  var now = new Date();
  var time = now.getTime();
  var expireTime = time + 365 * 24 * 60 * 60 * 1000;
  now.setTime(expireTime);
  document.cookie = ".CanTrack =" + "true" + ';expires=' + now.toGMTString() + ";SameSite=Lax";
}

/***/ })

/******/ });
//# sourceMappingURL=cookies.js.map