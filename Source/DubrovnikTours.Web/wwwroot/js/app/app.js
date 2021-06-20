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
/* harmony import */ var _sass_app_scss__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../sass/app.scss */ "./src/sass/app.scss");
/* harmony import */ var _sass_app_scss__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(_sass_app_scss__WEBPACK_IMPORTED_MODULE_0__);
/* harmony import */ var jquery__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! jquery */ "jquery");
/* harmony import */ var jquery__WEBPACK_IMPORTED_MODULE_1___default = /*#__PURE__*/__webpack_require__.n(jquery__WEBPACK_IMPORTED_MODULE_1__);
/* harmony import */ var bootstrap__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! bootstrap */ "./node_modules/bootstrap/dist/js/npm.js");
/* harmony import */ var bootstrap__WEBPACK_IMPORTED_MODULE_2___default = /*#__PURE__*/__webpack_require__.n(bootstrap__WEBPACK_IMPORTED_MODULE_2__);
/* harmony import */ var bootstrap_dist_css_bootstrap_min_css__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! bootstrap/dist/css/bootstrap.min.css */ "./node_modules/bootstrap/dist/css/bootstrap.min.css");
/* harmony import */ var bootstrap_dist_css_bootstrap_min_css__WEBPACK_IMPORTED_MODULE_3___default = /*#__PURE__*/__webpack_require__.n(bootstrap_dist_css_bootstrap_min_css__WEBPACK_IMPORTED_MODULE_3__);
/* harmony import */ var bootstrap_dist_js_bootstrap_min__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! bootstrap/dist/js/bootstrap.min */ "./node_modules/bootstrap/dist/js/bootstrap.min.js");
/* harmony import */ var bootstrap_dist_js_bootstrap_min__WEBPACK_IMPORTED_MODULE_4___default = /*#__PURE__*/__webpack_require__.n(bootstrap_dist_js_bootstrap_min__WEBPACK_IMPORTED_MODULE_4__);
/* harmony import */ var lightslider__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! lightslider */ "./node_modules/lightslider/dist/js/lightslider.js");
/* harmony import */ var lightslider__WEBPACK_IMPORTED_MODULE_5___default = /*#__PURE__*/__webpack_require__.n(lightslider__WEBPACK_IMPORTED_MODULE_5__);
/* harmony import */ var slick_carousel_slick_slick__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! slick-carousel/slick/slick */ "./node_modules/slick-carousel/slick/slick.js");
/* harmony import */ var slick_carousel_slick_slick__WEBPACK_IMPORTED_MODULE_6___default = /*#__PURE__*/__webpack_require__.n(slick_carousel_slick_slick__WEBPACK_IMPORTED_MODULE_6__);
/* harmony import */ var jquery_ui_ui_widgets_datepicker__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! jquery-ui/ui/widgets/datepicker */ "./node_modules/jquery-ui/ui/widgets/datepicker.js");
/* harmony import */ var jquery_ui_ui_widgets_datepicker__WEBPACK_IMPORTED_MODULE_7___default = /*#__PURE__*/__webpack_require__.n(jquery_ui_ui_widgets_datepicker__WEBPACK_IMPORTED_MODULE_7__);
/* harmony import */ var jquery_ui_themes_base_core_css__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! jquery-ui/themes/base/core.css */ "./node_modules/jquery-ui/themes/base/core.css");
/* harmony import */ var jquery_ui_themes_base_core_css__WEBPACK_IMPORTED_MODULE_8___default = /*#__PURE__*/__webpack_require__.n(jquery_ui_themes_base_core_css__WEBPACK_IMPORTED_MODULE_8__);
/* harmony import */ var jquery_ui_themes_base_datepicker_css__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! jquery-ui/themes/base/datepicker.css */ "./node_modules/jquery-ui/themes/base/datepicker.css");
/* harmony import */ var jquery_ui_themes_base_datepicker_css__WEBPACK_IMPORTED_MODULE_9___default = /*#__PURE__*/__webpack_require__.n(jquery_ui_themes_base_datepicker_css__WEBPACK_IMPORTED_MODULE_9__);
/* harmony import */ var jquery_ui_themes_base_theme_css__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! jquery-ui/themes/base/theme.css */ "./node_modules/jquery-ui/themes/base/theme.css");
/* harmony import */ var jquery_ui_themes_base_theme_css__WEBPACK_IMPORTED_MODULE_10___default = /*#__PURE__*/__webpack_require__.n(jquery_ui_themes_base_theme_css__WEBPACK_IMPORTED_MODULE_10__);
/* harmony import */ var jquery_scrollbar__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! jquery.scrollbar */ "./node_modules/jquery.scrollbar/index.js");
/* harmony import */ var jquery_scrollbar__WEBPACK_IMPORTED_MODULE_11___default = /*#__PURE__*/__webpack_require__.n(jquery_scrollbar__WEBPACK_IMPORTED_MODULE_11__);
/* harmony import */ var jquery_scrollbar_sass_jquery_scrollbar_scss__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! jquery.scrollbar/sass/jquery.scrollbar.scss */ "./node_modules/jquery.scrollbar/sass/jquery.scrollbar.scss");
/* harmony import */ var jquery_scrollbar_sass_jquery_scrollbar_scss__WEBPACK_IMPORTED_MODULE_12___default = /*#__PURE__*/__webpack_require__.n(jquery_scrollbar_sass_jquery_scrollbar_scss__WEBPACK_IMPORTED_MODULE_12__);
/* harmony import */ var jquery_lazyload__WEBPACK_IMPORTED_MODULE_13__ = __webpack_require__(/*! jquery-lazyload */ "./node_modules/jquery-lazyload/jquery.lazyload.js");
/* harmony import */ var jquery_lazyload__WEBPACK_IMPORTED_MODULE_13___default = /*#__PURE__*/__webpack_require__.n(jquery_lazyload__WEBPACK_IMPORTED_MODULE_13__);













 //LAYOUT - SECTION ---------------------------------------------------------------------------------
//CAROUSEL SETTINGS

jquery__WEBPACK_IMPORTED_MODULE_1___default()('.carousel').carousel({
  pause: "false"
  /* Change to true to make it paused when your mouse cursor enter the background */

}); //FIX SLIDING EVENT LISTNER ERROR

jquery__WEBPACK_IMPORTED_MODULE_1___default()('.lSSlideOuter').on('touchmove', ontouchmove);
jquery__WEBPACK_IMPORTED_MODULE_1___default()('#meeting-point-map').on('touchmove', ontouchmove);

function ontouchmove(e) {
  if (e.cancelable) {
    e.preventDefault();
  }
} //LAZYLOAD INITIALIZATION FUNCTION


function lazyLoad() {
  jquery__WEBPACK_IMPORTED_MODULE_1___default()("img.lazy").lazyload();
}

;
jquery__WEBPACK_IMPORTED_MODULE_1___default()("img.lazy").lazyload(); // HOME - HERO SLIDER TOUR BOOK ONLINE BUTTON DISPLAY BASED ON .ASPNETCORE.CULTURE COOKIE

var selectedLanguage = jquery__WEBPACK_IMPORTED_MODULE_1___default()('.header-language-name').html(); // Now take key value pair out of this array

jquery__WEBPACK_IMPORTED_MODULE_1___default()('.esp').hide();

if (selectedLanguage === "EN") {
  jquery__WEBPACK_IMPORTED_MODULE_1___default()('.esp').hide();
  jquery__WEBPACK_IMPORTED_MODULE_1___default()('.eng').show();
} else {
  jquery__WEBPACK_IMPORTED_MODULE_1___default()('.esp').show();
  jquery__WEBPACK_IMPORTED_MODULE_1___default()('.eng').hide();
} // HIDE BACKEND COMMA CHARACHTERS FROM FRONTEND


jquery__WEBPACK_IMPORTED_MODULE_1___default()(".comma-target-box ul").each(function () {
  var commaTargetBox = jquery__WEBPACK_IMPORTED_MODULE_1___default()(".comma-target-box ul"),
      targetBoxIsIncludedHtml = commaTargetBox.html();
  commaTargetBox.html(targetBoxIsIncludedHtml.replace(/,/g, ''));
});
jquery__WEBPACK_IMPORTED_MODULE_1___default()(".tour-info-text-content ul").each(function () {
  var commaTargetBox = jquery__WEBPACK_IMPORTED_MODULE_1___default()(".tour-info-text-content ul"),
      targetBoxIsIncludedHtml = commaTargetBox.html();
  commaTargetBox.html(targetBoxIsIncludedHtml.replace(/,/g, ''));
});
jquery__WEBPACK_IMPORTED_MODULE_1___default()(".tour-info-text-footer").each(function () {
  var commaTargetBox = jquery__WEBPACK_IMPORTED_MODULE_1___default()(".tour-info-text-footer"),
      targetBoxIsIncludedHtml = commaTargetBox.html();
  commaTargetBox.html(targetBoxIsIncludedHtml.replace(/,/g, ''));
}); //LAYOUT - HEADER - BUTTONS FUNCTION

jquery__WEBPACK_IMPORTED_MODULE_1___default()('.header-menu-btn').click(function () {
  jquery__WEBPACK_IMPORTED_MODULE_1___default()('.header-menu-icon').toggleClass('is-active');
  jquery__WEBPACK_IMPORTED_MODULE_1___default()('.header-menu').stop().fadeToggle();
});
jquery__WEBPACK_IMPORTED_MODULE_1___default()('.header-menu-icon').click(function () {
  jquery__WEBPACK_IMPORTED_MODULE_1___default()(this).toggleClass('is-active');
  jquery__WEBPACK_IMPORTED_MODULE_1___default()('.header-menu').stop().fadeToggle();
});
jquery__WEBPACK_IMPORTED_MODULE_1___default()('.header-language').click(function () {
  jquery__WEBPACK_IMPORTED_MODULE_1___default()(this).find('.header-language-chevron').toggleClass('is-active');
  jquery__WEBPACK_IMPORTED_MODULE_1___default()(this).find('.header-language-pickers').stop().fadeToggle();
  jquery__WEBPACK_IMPORTED_MODULE_1___default()(this).find('.header-language-pickers-picker').click(function () {
    jquery__WEBPACK_IMPORTED_MODULE_1___default()('.header-language-pickers-picker').removeClass('is-active');
    jquery__WEBPACK_IMPORTED_MODULE_1___default()(this).addClass('is-active');
  });
}); //LAYOUT HEADER - LANGUAGE SWITCHING FUNCTION

(function () {
  const selectLanguageForm = jquery__WEBPACK_IMPORTED_MODULE_1___default()('#select-language');
  const languageInput = jquery__WEBPACK_IMPORTED_MODULE_1___default()('#language');
  jquery__WEBPACK_IMPORTED_MODULE_1___default()('#english-language').click(function () {
    var newLang = jquery__WEBPACK_IMPORTED_MODULE_1___default()(this).data('language');
    languageInput.val(newLang);
    selectLanguageForm.submit();
  });
  jquery__WEBPACK_IMPORTED_MODULE_1___default()('#spanish-language').click(function () {
    var newLang = jquery__WEBPACK_IMPORTED_MODULE_1___default()(this).data('language');
    languageInput.val(newLang);
    selectLanguageForm.submit();
  });
})(); // LAYOUT - HEADER - LETTER PARALLAX EFFECT


(function () {
  jquery__WEBPACK_IMPORTED_MODULE_1___default()(window).scroll(function () {
    jquery__WEBPACK_IMPORTED_MODULE_1___default()('.page-header h3').css('transform', `translateY(-${window.scrollY / 8}px)`);
  });
})(); // LAYOUT - SMOOTH SCROLLING TO HASH FUNCTION


jquery__WEBPACK_IMPORTED_MODULE_1___default()(window).width() < 500 ? jquery__WEBPACK_IMPORTED_MODULE_1___default()('a[href*="#"]').not('[href="#"]').not('[href="#0"]').click(function (t) {
  if (location.pathname.replace(/^\//, "") == this.pathname.replace(/^\//, "") && location.hostname == this.hostname) {
    var e = jquery__WEBPACK_IMPORTED_MODULE_1___default()(this.hash);
    (e = e.length ? e : jquery__WEBPACK_IMPORTED_MODULE_1___default()("[name=" + this.hash.slice() + "]")).length && jquery__WEBPACK_IMPORTED_MODULE_1___default()("html, body").animate({
      scrollTop: e.offset().top - 65
    }, 1500, function () {
      var t = jquery__WEBPACK_IMPORTED_MODULE_1___default()(e);
      if (t.focus(), t.is(":focus") - 65) return !1;
      t.attr("tabindex", "-1"), t.focus();
    });
  }
}) : jquery__WEBPACK_IMPORTED_MODULE_1___default()('a[href*="#"]').not('[href="#"]').not('[href="#0"]').click(function (t) {
  if (location.pathname.replace(/^\//, "") == this.pathname.replace(/^\//, "") && location.hostname == this.hostname) {
    var e = jquery__WEBPACK_IMPORTED_MODULE_1___default()(this.hash);
    (e = e.length ? e : jquery__WEBPACK_IMPORTED_MODULE_1___default()("[name=" + this.hash.slice() + "]")).length && jquery__WEBPACK_IMPORTED_MODULE_1___default()("html, body").animate({
      scrollTop: e.offset().top - 65
    }, 1200, function () {
      var t = jquery__WEBPACK_IMPORTED_MODULE_1___default()(e);
      if (t.focus(), t.is(":focus") - 65) return !1;
      t.attr("tabindex", "-1"), t.focus();
    });
  }
});
jquery__WEBPACK_IMPORTED_MODULE_1___default()('.nav-menu-link').click(function () {
  jquery__WEBPACK_IMPORTED_MODULE_1___default()('.nav-menu-link').removeClass('is-active');
  const btn = jquery__WEBPACK_IMPORTED_MODULE_1___default()(this);
  btn.addClass('is-active');
  jquery__WEBPACK_IMPORTED_MODULE_1___default()('.navbar-toggler').click();
}); // LAYOUT - GO-TOP ICON ON SCROLL DISPLAY

jquery__WEBPACK_IMPORTED_MODULE_1___default()(window).scroll(function () {
  var sc = jquery__WEBPACK_IMPORTED_MODULE_1___default()(window).scrollTop();

  if (sc > 420) {
    jquery__WEBPACK_IMPORTED_MODULE_1___default()("#go-top-icon").addClass("visible");
  } else {
    jquery__WEBPACK_IMPORTED_MODULE_1___default()("#go-top-icon").removeClass("visible");
  }
}); // LAYOUT - GO-TOP ICON SWITCH IMAGE

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

jquery__WEBPACK_IMPORTED_MODULE_1___default()('.copyright').append(new Date().getFullYear()); //END O LAYOUT SECTION---------------------------------------------------------------------------

(function () {
  // HOME HERO SLIDER CONFIGURATION
  jquery__WEBPACK_IMPORTED_MODULE_1___default()('.hero-slider-inner').slick({
    infinite: true,
    autoplay: true,
    autoplaySpeed: 8000,
    nextArrow: jquery__WEBPACK_IMPORTED_MODULE_1___default()('.hero-slider-arrow-next'),
    prevArrow: jquery__WEBPACK_IMPORTED_MODULE_1___default()('.hero-slider-arrow-prev'),
    slidesToShow: 1,
    slidesToScroll: 1,
    init: showHeaderSlides(),
    responsive: [{
      breakpoint: 1080,
      settings: {
        arrows: false
      }
    }]
  }); //show slides on hero slider initialization

  function showHeaderSlides() {
    jquery__WEBPACK_IMPORTED_MODULE_1___default()(".hero-slider-inner").attr('style', 'visibility:visible');
  }

  ; // HOME TOURS TABS SLIDE FUNCTION

  const slickSliders = ['scheduled', 'private'];
  jquery__WEBPACK_IMPORTED_MODULE_1___default.a.each(slickSliders, function (ix, val) {
    const sliderId = `#${val}-slider`;
    const nextArrowId = `#${val}-arrow-next`;
    const prevArrowId = `#${val}-arrow-prev`;

    if (jquery__WEBPACK_IMPORTED_MODULE_1___default()(sliderId).length) {
      initializeSlickSlider(sliderId, nextArrowId, prevArrowId);
    }
  });
})(); // HOME TOUR TABS DISPLAY CARDS FUNCTION


(function () {
  const FADE_MS = 300;

  function slickFadeIn(tab) {
    // this is required because slick can't calculate correct slider
    // size when using display: none on initialization
    // 1. before fading in, remove display: none and set visibility: hidden
    // 2. force refresh by calling slick setPosition function
    // 3. switch back to using display: none
    // 4. use regular fade in
    tab.css({
      'display': '',
      'visibility': 'hidden'
    });
    const slider = tab.find('.tours-cards-slider');

    if (slider) {
      slider.slick('setPosition');
    }

    tab.css({
      'display': 'none',
      'visibility': 'visible'
    });
    tab.fadeIn(FADE_MS);
  }

  jquery__WEBPACK_IMPORTED_MODULE_1___default()('.tours-tabs-tab').click(function () {
    jquery__WEBPACK_IMPORTED_MODULE_1___default()('.tours-tabs-tab').removeClass('is-active');
    const btn = jquery__WEBPACK_IMPORTED_MODULE_1___default()(this);
    btn.addClass('is-active');
    const showTabName = btn.data('show-tab');
    let showTab = null;
    let hideTab = null;
    jquery__WEBPACK_IMPORTED_MODULE_1___default.a.each(jquery__WEBPACK_IMPORTED_MODULE_1___default()('.tours-cards'), function (index, value) {
      const tourTab = jquery__WEBPACK_IMPORTED_MODULE_1___default()(value);
      const tabName = tourTab.data('tab');

      if (showTabName === tabName) {
        showTab = tourTab;
      } else if (!hideTab && tourTab.is(':visible')) {
        hideTab = tourTab;
      }
    });

    if (hideTab) {
      hideTab.fadeOut(FADE_MS, function () {
        if (showTab) {
          slickFadeIn(showTab);
        }
      });
    } else {
      if (showTab) {
        slickFadeIn(showTab);
      }
    }

    lazyLoad();
  });
})(); //LAZYLOAD FOR MOBILE DEVICE ON TOUCH CALLING


jquery__WEBPACK_IMPORTED_MODULE_1___default()('.tours').on('touchstart', function (e) {
  lazyLoad();
});
jquery__WEBPACK_IMPORTED_MODULE_1___default()('.tours').on('touchmove', function (e) {
  lazyLoad();
}); //LAZYLOAD FOR DESKTOP DEVICE ON MOUSEMOVE CALLING

jquery__WEBPACK_IMPORTED_MODULE_1___default()('.tours').on('mousemove', function (e) {
  lazyLoad();
}); //LAZYLOAD FOR DESKTOP DEVICE ON MOUSEMOVE CALLING

jquery__WEBPACK_IMPORTED_MODULE_1___default()('.tours-slider-arrow-prev').on('click', function (e) {
  lazyLoad();
}); // HOME TOURS CARDS SLIDER CONFIGURATION

function initializeSlickSlider(containerSelector, nextArrowSelector, prevArrowSelector) {
  jquery__WEBPACK_IMPORTED_MODULE_1___default()(containerSelector).slick({
    infinite: false,
    slidesToShow: 3,
    slidesToScroll: 1,
    autoplay: true,
    autoplaySpeed: 3000,
    nextArrow: jquery__WEBPACK_IMPORTED_MODULE_1___default()(nextArrowSelector),
    prevArrow: jquery__WEBPACK_IMPORTED_MODULE_1___default()(prevArrowSelector),
    init: showTourSlides(),
    init: lazyLoad(),
    responsive: [{
      breakpoint: 1080,
      settings: {
        slidesToShow: 2,
        slidesToScroll: 2,
        arrows: false
      }
    }, {
      breakpoint: 680,
      settings: {
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows: false
      }
    }]
  });
} //home page flickering fix function


function showTourSlides() {
  jquery__WEBPACK_IMPORTED_MODULE_1___default()("#home-fix").hide();
  jquery__WEBPACK_IMPORTED_MODULE_1___default()(".tours-cards-slider").attr('style', 'visibility:visible');
}

; //LAZYLOAD FOR DESKTOP DEVICE ON MOUSEMOVE CALLING

jquery__WEBPACK_IMPORTED_MODULE_1___default()('.tours-slider-arrow-next').on('click', function (e) {
  lazyLoad();
}); // HOME REVIEWS SLIDER CONFIGURATION

jquery__WEBPACK_IMPORTED_MODULE_1___default()('.reviews-slider-container').slick({
  infinite: true,
  nextArrow: jquery__WEBPACK_IMPORTED_MODULE_1___default()('.reviews-actions-next'),
  prevArrow: jquery__WEBPACK_IMPORTED_MODULE_1___default()('.reviews-actions-prev'),
  init: showReviews()
}); //show reviews on reviews slider initialization

function showReviews() {
  jquery__WEBPACK_IMPORTED_MODULE_1___default()(".reviews").attr('style', 'visibility:visible');
}

; //END OF HOME PAGE SECTION-------------------------------------------------------------------------

/***/ }),

/***/ "./src/sass/app.scss":
/*!***************************!*\
  !*** ./src/sass/app.scss ***!
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