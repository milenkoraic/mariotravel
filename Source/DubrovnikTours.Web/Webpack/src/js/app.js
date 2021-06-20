import '../sass/app.scss';
import $ from 'jquery';
import 'bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.min';
import 'lightslider';
import 'slick-carousel/slick/slick';
import 'jquery-ui/ui/widgets/datepicker';
import 'jquery-ui/themes/base/core.css';
import 'jquery-ui/themes/base/datepicker.css';
import 'jquery-ui/themes/base/theme.css';
import 'jquery.scrollbar';
import 'jquery.scrollbar/sass/jquery.scrollbar.scss';
import 'jquery-lazyload';

//LAYOUT - SECTION ---------------------------------------------------------------------------------

//CAROUSEL SETTINGS
$('.carousel').carousel({
    pause: "false" /* Change to true to make it paused when your mouse cursor enter the background */
});

//FIX SLIDING EVENT LISTNER ERROR
$('.lSSlideOuter').on('touchmove',ontouchmove);
$('#meeting-point-map').on('touchmove',ontouchmove);

function ontouchmove(e){
  if(e.cancelable){
    e.preventDefault();
  }
}

//LAZYLOAD INITIALIZATION FUNCTION
function lazyLoad() {
    $("img.lazy").lazyload();
};

$("img.lazy").lazyload();

// HOME - HERO SLIDER TOUR BOOK ONLINE BUTTON DISPLAY BASED ON .ASPNETCORE.CULTURE COOKIE
var selectedLanguage = $('.header-language-name').html();
// Now take key value pair out of this array
$('.esp').hide();
if (selectedLanguage === "EN") {
    $('.esp').hide();
    $('.eng').show();
} else {
    $('.esp').show();
    $('.eng').hide();
}

// HIDE BACKEND COMMA CHARACHTERS FROM FRONTEND
$(".comma-target-box ul").each(function() {
    var commaTargetBox = $(".comma-target-box ul"),
        targetBoxIsIncludedHtml = commaTargetBox.html();
    commaTargetBox.html(targetBoxIsIncludedHtml.replace(/,/g, ''));
});

$(".tour-info-text-content ul").each(function() {
    var commaTargetBox = $(".tour-info-text-content ul"),
        targetBoxIsIncludedHtml = commaTargetBox.html();
    commaTargetBox.html(targetBoxIsIncludedHtml.replace(/,/g, ''));
});

$(".tour-info-text-footer").each(function() {
    var commaTargetBox = $(".tour-info-text-footer"),
        targetBoxIsIncludedHtml = commaTargetBox.html();
    commaTargetBox.html(targetBoxIsIncludedHtml.replace(/,/g, ''));
});

//LAYOUT - HEADER - BUTTONS FUNCTION
$('.header-menu-btn').click(function() {
    $('.header-menu-icon').toggleClass('is-active');
    $('.header-menu')
        .stop()
        .fadeToggle();
});

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

// LAYOUT - HEADER - LETTER PARALLAX EFFECT
(function() {
    $(window).scroll(function() {
        $('.page-header h3').css('transform', `translateY(-${window.scrollY / 8}px)`);
    });
})();

// LAYOUT - SMOOTH SCROLLING TO HASH FUNCTION
$(window).width() < 500 ? $('a[href*="#"]').not('[href="#"]').not('[href="#0"]').click(function(t) {
    if (location.pathname.replace(/^\//, "") == this.pathname.replace(/^\//, "") && location.hostname == this.hostname) {
        var e = $(this.hash);
        (e = e.length ? e : $("[name=" + this.hash.slice() + "]")).length && ($("html, body").animate({
            scrollTop: e.offset().top - 65
        }, 1500, function() {
            var t = $(e);
            if (t.focus(), t.is(":focus") - 65) return !1;
            t.attr("tabindex", "-1"), t.focus();
        }));
    }
}) : $('a[href*="#"]').not('[href="#"]').not('[href="#0"]').click(function(t) {
    if (location.pathname.replace(/^\//, "") == this.pathname.replace(/^\//, "") && location.hostname == this.hostname) {
        var e = $(this.hash);
        (e = e.length ? e : $("[name=" + this.hash.slice() + "]")).length && ($("html, body").animate({
            scrollTop: e.offset().top - 65
        }, 1200, function() {
            var t = $(e);
            if (t.focus(), t.is(":focus") - 65) return !1;
            t.attr("tabindex", "-1"), t.focus();
        }));
    }
});

$('.nav-menu-link').click(function() {
    $('.nav-menu-link').removeClass('is-active');
    const btn = $(this);
    btn.addClass('is-active');
    $('.navbar-toggler').click();
});

// LAYOUT - GO-TOP ICON ON SCROLL DISPLAY
$(window).scroll(function() {
    var sc = $(window).scrollTop();
    if (sc > 420) {
        $("#go-top-icon").addClass("visible");
    } else {
        $("#go-top-icon").removeClass("visible");
    }
});

// LAYOUT - GO-TOP ICON SWITCH IMAGE
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

//END O LAYOUT SECTION---------------------------------------------------------------------------

(function() {
    // HOME HERO SLIDER CONFIGURATION
    $('.hero-slider-inner').slick({
        infinite: true,
        autoplay: true,
        autoplaySpeed: 8000,
        nextArrow: $('.hero-slider-arrow-next'),
        prevArrow: $('.hero-slider-arrow-prev'),
        slidesToShow: 1,
        slidesToScroll: 1,
        init: showHeaderSlides(),
        responsive: [{
            breakpoint: 1080,
            settings: {
                arrows: false,
            },
        }, ],
    });

    //show slides on hero slider initialization
    function showHeaderSlides() {
        $(".hero-slider-inner").attr('style', 'visibility:visible');
    };

    // HOME TOURS TABS SLIDE FUNCTION
    const slickSliders = ['scheduled', 'private'];

    $.each(slickSliders, function(ix, val) {
        const sliderId = `#${val}-slider`;
        const nextArrowId = `#${val}-arrow-next`;
        const prevArrowId = `#${val}-arrow-prev`;

        if ($(sliderId).length) {
            initializeSlickSlider(sliderId, nextArrowId, prevArrowId);
        }
    });
})();

// HOME TOUR TABS DISPLAY CARDS FUNCTION
(function() {
    const FADE_MS = 300;

    function slickFadeIn(tab) {
        // this is required because slick can't calculate correct slider
        // size when using display: none on initialization
        // 1. before fading in, remove display: none and set visibility: hidden
        // 2. force refresh by calling slick setPosition function
        // 3. switch back to using display: none
        // 4. use regular fade in
        tab.css({ 'display': '', 'visibility': 'hidden' });
        const slider = tab.find('.tours-cards-slider');
        if (slider) {
            slider.slick('setPosition');
        }

        tab.css({ 'display': 'none', 'visibility': 'visible' });
        tab.fadeIn(FADE_MS);
    }

    $('.tours-tabs-tab').click(function() {
        $('.tours-tabs-tab').removeClass('is-active');
        const btn = $(this);
        btn.addClass('is-active');
        const showTabName = btn.data('show-tab');

        let showTab = null;
        let hideTab = null;

        $.each($('.tours-cards'), function(index, value) {
            const tourTab = $(value);
            const tabName = tourTab.data('tab');

            if (showTabName === tabName) {
                showTab = tourTab;
            } else if (!hideTab && tourTab.is(':visible')) {
                hideTab = tourTab;
            }
        });

        if (hideTab) {
            hideTab.fadeOut(FADE_MS, function() {
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
})();

//LAZYLOAD FOR MOBILE DEVICE ON TOUCH CALLING
$('.tours').on('touchstart', function(e) {
    lazyLoad();
});

$('.tours').on('touchmove', function(e) {
    lazyLoad();
});

//LAZYLOAD FOR DESKTOP DEVICE ON MOUSEMOVE CALLING
$('.tours').on('mousemove', function(e) {
    lazyLoad();
});

//LAZYLOAD FOR DESKTOP DEVICE ON MOUSEMOVE CALLING
$('.tours-slider-arrow-prev').on('click', function(e) {
    lazyLoad();
});

// HOME TOURS CARDS SLIDER CONFIGURATION
function initializeSlickSlider(containerSelector, nextArrowSelector, prevArrowSelector) {
    $(containerSelector).slick({
        infinite: false,
        slidesToShow: 3,
        slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 3000,
        nextArrow: $(nextArrowSelector),
        prevArrow: $(prevArrowSelector),
        init: showTourSlides(),
        init: lazyLoad(),
        responsive: [{
                breakpoint: 1080,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 2,
                    arrows: false,
                },
            },
            {
                breakpoint: 680,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    arrows: false,
                },
            },
        ],
    });
}

//home page flickering fix function
function showTourSlides() {
    $("#home-fix").hide();
    $(".tours-cards-slider").attr('style', 'visibility:visible');
};

//LAZYLOAD FOR DESKTOP DEVICE ON MOUSEMOVE CALLING
$('.tours-slider-arrow-next').on('click', function(e) {
    lazyLoad();
});

// HOME REVIEWS SLIDER CONFIGURATION
$('.reviews-slider-container').slick({
    infinite: true,
    nextArrow: $('.reviews-actions-next'),
    prevArrow: $('.reviews-actions-prev'),
    init: showReviews(),
});

//show reviews on reviews slider initialization
function showReviews() {
    $(".reviews").attr('style', 'visibility:visible');
};

//END OF HOME PAGE SECTION-------------------------------------------------------------------------