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
/******/ 		"app": 0
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
/******/ 	deferredModules.push(["./src/js/app.js","vendors"]);
/******/ 	// run deferred modules when ready
/******/ 	return checkDeferredModules();
/******/ })
/************************************************************************/
/******/ ({

/***/ "./src/js/app.js":
/*!***********************!*\
  !*** ./src/js/app.js ***!
  \***********************/
/*! no exports provided */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var jquery__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! jquery */ "jquery");
/* harmony import */ var jquery__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(jquery__WEBPACK_IMPORTED_MODULE_0__);
/* harmony import */ var bootstrap__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! bootstrap */ "./node_modules/bootstrap/dist/js/bootstrap.js");
/* harmony import */ var bootstrap__WEBPACK_IMPORTED_MODULE_1___default = /*#__PURE__*/__webpack_require__.n(bootstrap__WEBPACK_IMPORTED_MODULE_1__);
/* harmony import */ var bootstrap_dist_css_bootstrap_min_css__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! bootstrap/dist/css/bootstrap.min.css */ "./node_modules/bootstrap/dist/css/bootstrap.min.css");
/* harmony import */ var bootstrap_dist_css_bootstrap_min_css__WEBPACK_IMPORTED_MODULE_2___default = /*#__PURE__*/__webpack_require__.n(bootstrap_dist_css_bootstrap_min_css__WEBPACK_IMPORTED_MODULE_2__);
/* harmony import */ var bootstrap_dist_js_bootstrap_min__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! bootstrap/dist/js/bootstrap.min */ "./node_modules/bootstrap/dist/js/bootstrap.min.js");
/* harmony import */ var bootstrap_dist_js_bootstrap_min__WEBPACK_IMPORTED_MODULE_3___default = /*#__PURE__*/__webpack_require__.n(bootstrap_dist_js_bootstrap_min__WEBPACK_IMPORTED_MODULE_3__);
/* harmony import */ var _scss_app_scss__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../scss/app.scss */ "./src/scss/app.scss");
/* harmony import */ var _scss_app_scss__WEBPACK_IMPORTED_MODULE_4___default = /*#__PURE__*/__webpack_require__.n(_scss_app_scss__WEBPACK_IMPORTED_MODULE_4__);





jquery__WEBPACK_IMPORTED_MODULE_0___default()('.carousel').carousel({
  pause: "false"
  /* Change to true to make it paused when your mouse cursor enter the background */

}); //LAYOUT - HEADER - BUTTONS FUNCTION

(function () {
  jquery__WEBPACK_IMPORTED_MODULE_0___default()('.header-menu-icon').click(function () {
    jquery__WEBPACK_IMPORTED_MODULE_0___default()(this).toggleClass('is-active');
    jquery__WEBPACK_IMPORTED_MODULE_0___default()('.header-menu').stop().fadeToggle();
  });
  jquery__WEBPACK_IMPORTED_MODULE_0___default()('.header-language').click(function () {
    jquery__WEBPACK_IMPORTED_MODULE_0___default()(this).find('.header-language-chevron').toggleClass('is-active');
    jquery__WEBPACK_IMPORTED_MODULE_0___default()(this).find('.header-language-pickers').stop().fadeToggle();
    jquery__WEBPACK_IMPORTED_MODULE_0___default()(this).find('.header-language-pickers-picker').click(function () {
      jquery__WEBPACK_IMPORTED_MODULE_0___default()('.header-language-pickers-picker').removeClass('is-active');
      jquery__WEBPACK_IMPORTED_MODULE_0___default()(this).addClass('is-active');
    });
  });
})(); //LAYOUT HEADER - LANGUAGE SWITCHING FUNCTION


(function () {
  const selectLanguageForm = jquery__WEBPACK_IMPORTED_MODULE_0___default()('#select-language');
  const languageInput = jquery__WEBPACK_IMPORTED_MODULE_0___default()('#language');
  jquery__WEBPACK_IMPORTED_MODULE_0___default()('#english-language').click(function () {
    var newLang = jquery__WEBPACK_IMPORTED_MODULE_0___default()(this).data('language');
    languageInput.val(newLang);
    selectLanguageForm.submit();
  });
  jquery__WEBPACK_IMPORTED_MODULE_0___default()('#spanish-language').click(function () {
    var newLang = jquery__WEBPACK_IMPORTED_MODULE_0___default()(this).data('language');
    languageInput.val(newLang);
    selectLanguageForm.submit();
  });
})(); // LAYOUT - SMOOTH SCROLLING TO HASH FUNCTION


jquery__WEBPACK_IMPORTED_MODULE_0___default()(window).width() < 500 ? jquery__WEBPACK_IMPORTED_MODULE_0___default()('a[href*="#"]').not('[href="#"]').not('[href="#0"]').click(function (t) {
  if (location.pathname.replace(/^\//, "") == this.pathname.replace(/^\//, "") && location.hostname == this.hostname) {
    var e = jquery__WEBPACK_IMPORTED_MODULE_0___default()(this.hash);
    (e = e.length ? e : jquery__WEBPACK_IMPORTED_MODULE_0___default()("[name=" + this.hash.slice() + "]")).length && jquery__WEBPACK_IMPORTED_MODULE_0___default()("html, body").animate({
      scrollTop: e.offset().top - 100
    }, 1500, function () {
      var t = jquery__WEBPACK_IMPORTED_MODULE_0___default()(e);
      if (t.focus(), t.is(":focus") - 180) return !1;
      t.attr("tabindex", "-1"), t.focus();
    });
  }
}) : jquery__WEBPACK_IMPORTED_MODULE_0___default()('a[href*="#"]').not('[href="#"]').not('[href="#0"]').click(function (t) {
  if (location.pathname.replace(/^\//, "") == this.pathname.replace(/^\//, "") && location.hostname == this.hostname) {
    var e = jquery__WEBPACK_IMPORTED_MODULE_0___default()(this.hash);
    (e = e.length ? e : jquery__WEBPACK_IMPORTED_MODULE_0___default()("[name=" + this.hash.slice() + "]")).length && jquery__WEBPACK_IMPORTED_MODULE_0___default()("html, body").animate({
      scrollTop: e.offset().top - 100
    }, 900, function () {
      var t = jquery__WEBPACK_IMPORTED_MODULE_0___default()(e);
      if (t.focus(), t.is(":focus") + 0) return !1;
      t.attr("tabindex", "-1"), t.focus();
    });
  }
}); // LAYOUT - SMOOTH SCROLLING WHEN REDIRECTION COMES FROM ANOTHER PAGE
// Get the hash from the URL

var hash = window.location.hash; // If a hash exists && starts with "#scroll:"

if (hash.length && hash.indexOf('#scroll:') === 0) {
  // Get the anchor name we are scrolling to
  var selectionID = hash.substr('#scroll:'.length); // Call the jQuery scroll function

  jQuery("html, body").animate({
    scrollTop: jQuery('#' + selectionID).offset().top - 100
  }, 1000);
  history.pushState("", document.title, window.location.pathname);
} // LAYOUT - SWITCH INDICATOR WHEN USERS ARE SCROLLING ACROSS THE HOME PAGE


jquery__WEBPACK_IMPORTED_MODULE_0___default()(window).scroll(function () {
  var scrollDistance = jquery__WEBPACK_IMPORTED_MODULE_0___default()(window).scrollTop(); // Assign active class to nav links while scolling

  jquery__WEBPACK_IMPORTED_MODULE_0___default()('.section-indicator').each(function (i) {
    if (jquery__WEBPACK_IMPORTED_MODULE_0___default()(this).position().top <= scrollDistance + 200) {
      jquery__WEBPACK_IMPORTED_MODULE_0___default()('.indicator').removeClass('is-active');
      jquery__WEBPACK_IMPORTED_MODULE_0___default()('.indicator').eq(i).addClass('is-active');
    } else {
      jquery__WEBPACK_IMPORTED_MODULE_0___default()('.indicator').eq(i).removeClass('is-active');
    }
  });
}).scroll(); // LAYOUT - ADD INDICATOR TO THE SELECTED LINK WHEN USER CLICKS ONE OF THE MENU LINKS

jquery__WEBPACK_IMPORTED_MODULE_0___default()('.indicator').click(function () {
  jquery__WEBPACK_IMPORTED_MODULE_0___default()('.indicator').removeClass('is-active');
  const btn = jquery__WEBPACK_IMPORTED_MODULE_0___default()(this);
  btn.addClass('is-active');
  jquery__WEBPACK_IMPORTED_MODULE_0___default()('.header-menu').fadeOut();
  jquery__WEBPACK_IMPORTED_MODULE_0___default()('.header-menu-icon').removeClass('is-active');
}); // LAYOUT - GO-TOP ICON SCROLL DISPLAY FUNCTION

jquery__WEBPACK_IMPORTED_MODULE_0___default()(window).scroll(function () {
  var sc = jquery__WEBPACK_IMPORTED_MODULE_0___default()(window).scrollTop();

  if (sc > 420) {
    jquery__WEBPACK_IMPORTED_MODULE_0___default()("#go-top-icon").addClass("visible");
  } else if (sc < 420) {
    jquery__WEBPACK_IMPORTED_MODULE_0___default()("#go-top-icon").removeClass("visible");
  }
}); // LAYOUT - GO-TOP ICON SWITCH IMAGE FUNCTION

var slideIndex = 0;
carousel();

function carousel() {
  var i;
  var x = document.getElementsByClassName("images");

  for (i = 0; i < x.length; i++) {
    x[i].style.display = "none";
  }

  slideIndex++;

  if (slideIndex > x.length) {
    slideIndex = 1;
  }

  x[slideIndex - 1].style.display = "block";
  setTimeout(carousel, 700); // Change image every 2 seconds
}

; //LAYOUT - COPYRIGHT - AUTOMATIC YEAR UPDATE

jquery__WEBPACK_IMPORTED_MODULE_0___default()('.copyright').append(new Date().getFullYear());

/***/ }),

/***/ "./src/scss/app.scss":
/*!***************************!*\
  !*** ./src/scss/app.scss ***!
  \***************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

// extracted by mini-css-extract-plugin

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
//# sourceMappingURL=app.js.map