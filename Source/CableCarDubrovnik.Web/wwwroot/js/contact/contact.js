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
/******/ 	return __webpack_require__(__webpack_require__.s = "./src/js/contact-us.js");
/******/ })
/************************************************************************/
/******/ ({

/***/ "./src/js/contact-us.js":
/*!******************************!*\
  !*** ./src/js/contact-us.js ***!
  \******************************/
/*! no static exports found */
/***/ (function(module, exports) {

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
btn1Href.attr('onclick', '').unbind('click');
btn2Href.attr('onclick', '').unbind('click');
btn3Href.attr('onclick', '').unbind('click');
btn4Href.attr('onclick', '').unbind('click');
btn5Href.attr('onclick', '').unbind('click');
btn6Href.attr('onclick', '').unbind('click');
btn1Href.attr("href", homeUrl + "#scroll:" + link1Href);
btn2Href.attr("href", homeUrl + "#scroll:" + link2Href);
btn3Href.attr("href", homeUrl + "#scroll:" + link3Href);
btn4Href.attr("href", homeUrl + "#scroll:" + link4Href);
btn5Href.attr("href", homeUrl + "#scroll:" + link5Href);
btn6Href.attr("href", homeUrl + "#scroll:" + link6Href); // CONTACT US - CONTACT FORM - SUBMIT FUNCTION

$(function () {
  $('#submit-contact-form').click(function () {
    var form = $('#contact-us');
    form.validate();

    if (!form.valid()) {
      return;
    } else {
      $('#contact-us').submit(function (e) {
        e.preventDefault();
        var formData = ConvertFormToJSON(this);
        $.ajax({
          type: 'POST',
          contentType: "application/json",
          url: "/contact-us/submit",
          data: JSON.stringify(formData)
        }).done(function () {
          $('.error').hide();
          $('.success').addClass('success');
          $('input').val('');
          $('textarea').val('');
          $('#submit-contact-form').hide();
          $('.success').html('Your message has been sent. We will be in touch!');
          setTimeout(function () {
            window.location.reload();
          }, 5000);
        }).fail(function () {
          $('.error').addClass('error');
          $('.error').html('Something went wrong and we couldn\'t send your message, please try again later.');
        });
      });

      function ConvertFormToJSON(form) {
        var array = jQuery(form).serializeArray();
        var json = {};
        jQuery.each(array, function () {
          json[this.name] = this.value || '';
        });
        return json;
      }
    }
  });
}); //END OF CONTACT US SECTION-----------------------------------------------------------------------

/***/ })

/******/ });
//# sourceMappingURL=contact.js.map