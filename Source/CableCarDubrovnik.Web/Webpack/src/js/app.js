import $ from 'jquery';
import 'bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.min';
import '../scss/app.scss';

$('.carousel').carousel({
    pause: "false" /* Change to true to make it paused when your mouse cursor enter the background */
});

//LAYOUT - HEADER - BUTTONS FUNCTION
(function() {
    $('.header-menu-icon').click(function() {
        $(this).toggleClass('is-active');
        $('.header-menu')
            .stop()
            .fadeToggle();
    });

    $('.header-language').click(function() {
        $(this)
            .find('.header-language-chevron')
            .toggleClass('is-active');

        $(this)
            .find('.header-language-pickers')
            .stop()
            .fadeToggle();

        $(this)
            .find('.header-language-pickers-picker')
            .click(function() {
                $('.header-language-pickers-picker').removeClass('is-active');
                $(this).addClass('is-active');
            });
    });
})();

//LAYOUT HEADER - LANGUAGE SWITCHING FUNCTION
(function() {
    const selectLanguageForm = $('#select-language');
    const languageInput = $('#language');

    $('#english-language').click(function() {
        var newLang = $(this).data('language');
        languageInput.val(newLang);
        selectLanguageForm.submit();
    });

    $('#spanish-language').click(function() {
        var newLang = $(this).data('language');
        languageInput.val(newLang);
        selectLanguageForm.submit();
    });
})();

// LAYOUT - SMOOTH SCROLLING TO HASH FUNCTION
$(window).width() < 500 ? $('a[href*="#"]').not('[href="#"]').not('[href="#0"]').click(function(t) {
    if (location.pathname.replace(/^\//, "") == this.pathname.replace(/^\//, "") && location.hostname == this.hostname) {
        var e = $(this.hash);
        (e = e.length ? e : $("[name=" + this.hash.slice() + "]")).length && ($("html, body").animate({
            scrollTop: e.offset().top - 100
        }, 1500, function() {
            var t = $(e);
            if (t.focus(), t.is(":focus") - 180) return !1;
            t.attr("tabindex", "-1"), t.focus();
        }));
    }
}) : $('a[href*="#"]').not('[href="#"]').not('[href="#0"]').click(function(t) {
    if (location.pathname.replace(/^\//, "") == this.pathname.replace(/^\//, "") && location.hostname == this.hostname) {
        var e = $(this.hash);
        (e = e.length ? e : $("[name=" + this.hash.slice() + "]")).length && ($("html, body").animate({
            scrollTop: e.offset().top - 100
        }, 900, function() {
            var t = $(e);
            if (t.focus(), t.is(":focus") + 0) return !1;
            t.attr("tabindex", "-1"), t.focus();
        }));
    }
});

// LAYOUT - SMOOTH SCROLLING WHEN REDIRECTION COMES FROM ANOTHER PAGE
// Get the hash from the URL
var hash = window.location.hash;
// If a hash exists && starts with "#scroll:"
if (hash.length && hash.indexOf('#scroll:') === 0) {
    // Get the anchor name we are scrolling to
    var selectionID = hash.substr('#scroll:'.length);
    // Call the jQuery scroll function
    jQuery("html, body").animate({
        scrollTop: jQuery('#' + selectionID).offset().top - 100
    }, 1000);
    history.pushState("", document.title, window.location.pathname);
}

// LAYOUT - SWITCH INDICATOR WHEN USERS ARE SCROLLING ACROSS THE HOME PAGE
$(window).scroll(function() {
    var scrollDistance = $(window).scrollTop();
    // Assign active class to nav links while scolling
    $('.section-indicator').each(function(i) {
        if ($(this).position().top <= scrollDistance + 200) {
            $('.indicator').removeClass('is-active');
            $('.indicator').eq(i).addClass('is-active');
        } else {
            $('.indicator').eq(i).removeClass('is-active');
        }
    });
}).scroll();

// LAYOUT - ADD INDICATOR TO THE SELECTED LINK WHEN USER CLICKS ONE OF THE MENU LINKS
$('.indicator').click(function() {
    $('.indicator').removeClass('is-active');
    const btn = $(this);
    btn.addClass('is-active');
    $('.header-menu').fadeOut();
    $('.header-menu-icon').removeClass('is-active');
});

// LAYOUT - GO-TOP ICON SCROLL DISPLAY FUNCTION
$(window).scroll(function() {
    var sc = $(window).scrollTop();
    if (sc > 420) {
        $("#go-top-icon").addClass("visible");
    } else if (sc < 420) {
        $("#go-top-icon").removeClass("visible");
    }
});

// LAYOUT - GO-TOP ICON SWITCH IMAGE FUNCTION
var slideIndex = 0;
carousel();

function carousel() {
    var i;
    var x = document.getElementsByClassName("images");
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "none";
    }
    slideIndex++;
    if (slideIndex > x.length) { slideIndex = 1; }
    x[slideIndex - 1].style.display = "block";
    setTimeout(carousel, 700); // Change image every 2 seconds
};

//LAYOUT - COPYRIGHT - AUTOMATIC YEAR UPDATE
$('.copyright').append(new Date().getFullYear());