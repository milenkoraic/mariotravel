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
/******/ 		"transfers": 0
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
/******/ 	deferredModules.push(["./src/js/transfers.js","vendors"]);
/******/ 	// run deferred modules when ready
/******/ 	return checkDeferredModules();
/******/ })
/************************************************************************/
/******/ ({

/***/ "./src/js/transfers.js":
/*!*****************************!*\
  !*** ./src/js/transfers.js ***!
  \*****************************/
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






const errorModal = $('#errorMessage');
$('#closeErrorMessage').on("click", function () {
  $(".show-route-loader").hide(); //HIDE ERROR MESSAGE

  errorModal.hide();
  emptyAllFieldValues();
}); // TRANSFER BOOKING FORM BUTTON DONE - SUCCESS MODAL CLICK FUNCTION

$('#booking-done').click(function () {
  window.location.href = "/";
}); // TRANSFER BOOKING FORM BUTTON CANCEL - FAILED MODAL CLICK FUNCTION

$('#cancel-on-failed').click(function () {
  window.location.href = "/";
}); // TRANSFER BOOKING FORM BUTTON BOOK AGAIN - FAILED MODAL CLICK FUNCTION

$('#book-again-on-failed').click(function () {
  $(".payment-failed-modal").fadeOut();
}); //TRANSFER MODAL BUTTON CLOSE - CLICK FUNCTION

(function () {
  $('.modal-window-close').click(function () {
    $(this).data('clicked', true);
    $(this).parent().parent().fadeOut();
    window.location.reload();
  });
})();

function showFailureModal() {
  $('.payment-failed-modal').fadeIn().css('display', 'flex');
}

function showSuccessModal() {
  $('.payment-successful-modal').fadeIn().css('display', 'flex');
}

function chargeCustomerDeposit() {
  const transferId = $('#transfer-id').val();
  const applicationId = $('#application-id').val();
  const date = $('#date').val();
  const time = $('#time').val();
  const numberOfPeople = $('#number-of-people').val();
  const fullName = $('#full-name').val();
  const phone = $('#phone').val();
  const email = $('#email').val();
  const additionalInfo = $('#additional-info').val();
  const fromLocation = $('#location-a').val();
  const toLocation = $('#location-b').val();
  const transferDistance = $('#transfer-distance').val();
  const transferDuration = $('#transfer-duration').val();
  const bookingTransferDeposit = {
    transferId,
    date,
    time,
    numberOfPeople,
    fullName,
    phone,
    email,
    additionalInfo,
    fromLocation,
    toLocation,
    transferDistance,
    transferDuration,
    applicationId
  };
  $.ajax({
    type: 'POST',
    data: JSON.stringify(bookingTransferDeposit),
    contentType: 'application/json; charset=UTF-8',
    url: '/api/booking/deposit/transfer'
  }).done(function (data) {
    const {
      externalId,
      totalPrice
    } = data; //SET PAYMENT METHOD BUTTONS PARENT ELEMENT

    const paymentMethodModal = $('#payment-buttons'); //ANNOUNCE NEW DEPOSIT BUTTON ELEMENT

    let newDepositPaymentBtn = document.createElement('button');
    var buttonText = document.createTextNode(String("DEPOSIT"));
    newDepositPaymentBtn.appendChild(buttonText);
    newDepositPaymentBtn.setAttribute('type', 'button');
    newDepositPaymentBtn.setAttribute('onclick', "chargeCustomerDeposit()");
    newDepositPaymentBtn.setAttribute('id', "btn-checkout-deposit");
    newDepositPaymentBtn.setAttribute('class', "btn btn-ghost-primary btn-checkout");
    newDepositPaymentBtn.setAttribute('data-callback-url', $('#btn-checkout-deposit').attr('data-callback-url'));
    newDepositPaymentBtn.setAttribute('data-language', $('#btn-checkout-deposit').attr('data-language'));
    newDepositPaymentBtn.setAttribute('data-external-id', externalId);
    newDepositPaymentBtn.setAttribute('data-amount', totalPrice); //ANNOUNCE NEW FULL BUTTON ELEMENT

    let newFullPaymentBtn = document.createElement('button');
    var buttonText = document.createTextNode(String("FULL PAYMENT"));
    newFullPaymentBtn.appendChild(buttonText);
    newFullPaymentBtn.setAttribute('type', 'button');
    newFullPaymentBtn.setAttribute('onclick', "chargeCustomerFull()");
    newFullPaymentBtn.setAttribute('id', "btn-checkout-full");
    newFullPaymentBtn.setAttribute('class', "btn btn-primary btn-checkout");
    newFullPaymentBtn.setAttribute('data-callback-url', $('#btn-checkout-full').attr('data-callback-url'));
    newFullPaymentBtn.setAttribute('data-language', $('#btn-checkout-full').attr('data-language'));
    newFullPaymentBtn.setAttribute('data-external-id', externalId);
    newFullPaymentBtn.setAttribute('data-amount', totalPrice); //ADD NEW FULL AND DEPOSIT PAYMENT BUTTONS TO PAYMENT MODAL

    paymentMethodModal.append(newDepositPaymentBtn);
    paymentMethodModal.append(newFullPaymentBtn);
    const customer = {};

    if (fullName) {
      customer.fullName = fullName;
    }

    if (email) {
      customer.email = email;
    }

    $(".payment-method-modal").fadeOut();
    window.agentcash.chargeAmount(newDepositPaymentBtn, customer).done(function (invoice) {
      $('.ac-checkout-container').fadeOut();

      if (invoice.status === 'approved') {
        showSuccessModal();
      } else {
        showFailureModal();
      }
    }).fail(function (error) {
      console.log("Failure!", error);
      showFailureModal();
    });
  });
}

window.chargeCustomerDeposit = chargeCustomerDeposit;

function chargeCustomerFull() {
  const transferId = $('#transfer-id').val();
  const applicationId = $('#application-id').val();
  const date = $('#date').val();
  const time = $('#time').val();
  const numberOfPeople = $('#number-of-people').val();
  const fullName = $('#full-name').val();
  const phone = $('#phone').val();
  const email = $('#email').val();
  const additionalInfo = $('#additional-info').val();
  const fromLocation = $('#location-a').val();
  const toLocation = $('#location-b').val();
  const transferDistance = $('#transfer-distance').val();
  const transferDuration = $('#transfer-duration').val();
  const bookingTransferFull = {
    transferId,
    date,
    time,
    numberOfPeople,
    fullName,
    phone,
    email,
    additionalInfo,
    fromLocation,
    toLocation,
    transferDistance,
    transferDuration,
    applicationId
  };
  $.ajax({
    type: 'POST',
    data: JSON.stringify(bookingTransferFull),
    contentType: 'application/json; charset=UTF-8',
    url: '/api/booking/full/transfer'
  }).done(function (data) {
    const {
      externalId,
      totalPrice
    } = data; //SET PAYMENT METHOD BUTTONS PARENT ELEMENT

    const paymentMethodModal = $('#payment-buttons'); //ANNOUNCE NEW DEPOSIT BUTTON ELEMENT

    let newDepositPaymentBtn = document.createElement('button');
    var buttonText = document.createTextNode(String("DEPOSIT"));
    newDepositPaymentBtn.appendChild(buttonText);
    newDepositPaymentBtn.setAttribute('type', 'button');
    newDepositPaymentBtn.setAttribute('onclick', "chargeCustomerDeposit()");
    newDepositPaymentBtn.setAttribute('id', "btn-checkout-deposit");
    newDepositPaymentBtn.setAttribute('class', "btn btn-ghost-primary btn-checkout");
    newDepositPaymentBtn.setAttribute('data-callback-url', $('#btn-checkout-deposit').attr('data-callback-url'));
    newDepositPaymentBtn.setAttribute('data-language', $('#btn-checkout-deposit').attr('data-language'));
    newDepositPaymentBtn.setAttribute('data-external-id', externalId);
    newDepositPaymentBtn.setAttribute('data-amount', totalPrice); //ANNOUNCE NEW FULL BUTTON ELEMENT

    let newFullPaymentBtn = document.createElement('button');
    var buttonText = document.createTextNode(String("FULL PAYMENT"));
    newFullPaymentBtn.appendChild(buttonText);
    newFullPaymentBtn.setAttribute('type', 'button');
    newFullPaymentBtn.setAttribute('onclick', "chargeCustomerFull()");
    newFullPaymentBtn.setAttribute('id', "btn-checkout-full");
    newFullPaymentBtn.setAttribute('class', "btn btn-primary btn-checkout");
    newFullPaymentBtn.setAttribute('data-callback-url', $('#btn-checkout-full').attr('data-callback-url'));
    newFullPaymentBtn.setAttribute('data-language', $('#btn-checkout-full').attr('data-language'));
    newFullPaymentBtn.setAttribute('data-external-id', externalId);
    newFullPaymentBtn.setAttribute('data-amount', totalPrice); //ADD NEW FULL AND DEPOSIT PAYMENT BUTTONS TO PAYMENT MODAL

    paymentMethodModal.append(newDepositPaymentBtn);
    paymentMethodModal.append(newFullPaymentBtn);
    const customer = {};

    if (fullName) {
      customer.fullName = fullName;
    }

    if (email) {
      customer.email = email;
    }

    $(".payment-method-modal").fadeOut();
    window.agentcash.chargeAmount(newFullPaymentBtn, customer).done(function (invoice) {
      $('.ac-checkout-container').fadeOut();

      if (invoice.status === 'approved') {
        showSuccessModal();
      } else {
        showFailureModal();
      }
    }).fail(function (error) {
      console.log("Failure!", error);
      showFailureModal();
    });
  });
}

window.chargeCustomerFull = chargeCustomerFull; //TRANSFER - BOOKING FORM - SUBMIT FUNCTION

$('#submit-form').click(function () {
  $(this).data('clicked', true);

  if ($(".ac-checkout-container").length > 0 && $('.modal-window-close').attr('clicked') != true) {
    $('#btn-checkout-full').remove();
    $('#btn-checkout-deposit').remove();
  }

  if ($('#submit-form').attr('clicked') == true) {
    $('#btn-checkout-full').remove();
    $('#btn-checkout-deposit').remove();
  }

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
});
$('#btn-checkout-full').click(function () {
  chargeCustomerFull();
});
$('#btn-checkout-deposit').click(function () {
  chargeCustomerDeposit();
});

function makeTransferRequest() {
  const date = $('#date').val();
  const time = $('#time').val();
  const numberOfPeople = $('#number-of-people').val();
  const fullName = $('#full-name').val();
  const phone = $('#phone').val();
  const email = $('#email').val();
  const additionalInfo = $('#additional-info').val();
  const fromLocation = $('#location-a').val();
  const toLocation = $('#location-b').val();
  const transferDistance = $('#transfer-distance').val();
  const transferDuration = $('#transfer-duration').val();
  const requestTransfer = {
    date,
    time,
    numberOfPeople,
    fullName,
    phone,
    email,
    additionalInfo,
    fromLocation,
    toLocation,
    transferDistance,
    transferDuration
  };
  $.ajax({
    type: 'POST',
    data: JSON.stringify(requestTransfer),
    contentType: 'application/json; charset=UTF-8',
    url: '/api/booking/transfer/request'
  }).done(function () {
    $('.error').hide();
    $('.success').addClass('success');
    $('input').val('');
    $('textarea').val('');
    $('.success').html('Your transfer request has been sent. We will be in touch!');
    setTimeout(function () {
      window.location.reload();
    }, 5000);
  }).fail(function () {
    $('.error').addClass('error');
    $('.error').html('Something went wrong and we couldn\'t send your message, please try again later.');
    setTimeout(function () {
      window.location.reload();
    }, 5000);
  });
}

; //TRANSFER - BOOKING FORM - SUBMIT REQUEST FUNCTION

$('#submit-form-request').click(function () {
  if ($(".ac-checkout-container").length > 0 && $('.modal-window-close').attr('clicked') != true) {
    $('#btn-checkout-full').remove();
    $('#btn-checkout-deposit').remove();
  }

  const form = $('#booking');

  if (!form.valid()) {
    return;
  }

  makeTransferRequest();
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
//# sourceMappingURL=transfers.js.map