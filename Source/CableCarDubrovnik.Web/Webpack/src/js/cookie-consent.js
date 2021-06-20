//GDPR COOKIES - BUTTONS FUNCTION
(function () {
    let selectedCookies = {
        basic: true,
        functional: false,
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
})();

//  GDPR COOKIE CONSENT - ACCEPT ALL COOKIES BUTTON CLICK FUNCTION
(function () {
    const buttonAllCookies = document.querySelector("#buttonAllCookies[data-cookie-string]");
    if (buttonAllCookies) {
        buttonAllCookies.addEventListener("click", function (event) {
            document.cookie = buttonAllCookies.dataset.cookieString;
            WriteTrackingCookie();
        }, false);
    }
})();

// GDPR COOKIE CONSENT - ACCEPT SELECTED COOKIES BUTTON CLICK FUNCTION
(function () {
    const buttonSelectedCookies = document.querySelector("#buttonSelectedCookies[data-cookie-string]");
    if (buttonSelectedCookies) {
        buttonSelectedCookies.addEventListener("click", function (event) {
            document.cookie = buttonSelectedCookies.dataset.cookieString;
        }, false);
    }
})();

// GDPR COOKIE CONSENT - CREATE TRACKING COOKIE FUNCTION
function WriteTrackingCookie() {
    var now = new Date();
    var time = now.getTime();
    var expireTime = time + 365 * 24 * 60 * 60 * 1000;
    now.setTime(expireTime);
    document.cookie = ".CanTrack =" + "true" + ';expires=' + now.toGMTString();
}