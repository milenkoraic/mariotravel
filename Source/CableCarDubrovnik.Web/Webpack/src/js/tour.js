import 'jquery-ui/ui/widgets/datepicker';
import 'jquery-ui/themes/base/core.css';
import 'jquery-ui/themes/base/datepicker.css';
import 'jquery-ui/themes/base/theme.css';
import 'jquery.scrollbar';
import 'jquery.scrollbar/sass/jquery.scrollbar.scss';

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
btn6Href.attr("href", homeUrl + "#scroll:" + link6Href);

// GO BACK - BUTTON CLICK FUNCTION
$('#go-back').click(function () {
    window.history.back();
});

// TOUR - BOOKING FORM - VALIDATION MODALS
(function (w) {
    $('.tour-info-text-content').scrollbar();

    //TOUR - BOOKING FORM - SUBMIT FUNCTION
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
        }

        // clear field state
        const errors = form.find('.field-validation-error span');
        errors.each(function () { validator.settings.success($(this)); });

        // clear validation summary
        form.find("[data-valmsg-summary=true]")
            .removeClass("validation-summary-errors")
            .addClass("validation-summary-valid")
            .find("ul").empty();
        $(".payment-method-modal").fadeIn().css("display", "flex");
    });

    //TOUR BOOKING FORM - DATAPICKER FUNCTION FOR INACTIVE DATES
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