import 'lightslider';
import 'jquery-ui/ui/widgets/datepicker';
import 'jquery-ui/themes/base/core.css';
import 'jquery-ui/themes/base/datepicker.css';
import 'jquery-ui/themes/base/theme.css';
import 'jquery.scrollbar';
import 'jquery.scrollbar/sass/jquery.scrollbar.scss';

// GO BACK - BUTTON CLICK FUNCTION
$('#go-back').click(function () {
    window.history.back();
});

//TOUR LIGHT GALLERY SLIDER CONFIGRATION
$('.tour-info-gallery-items').lightSlider({
    gallery: true,
    item: 1,
    infinite: false,
    loop: false,
    slideMargin: 0,
    enableDrag: false,
    onSliderLoad: removeFlicker(),
});

//tour page flickering fix function
function removeFlicker() {
    $('#tour-fix').hide(500);
    $('.tour-info-text').show();
    $('.tour-info-gallery').attr('style', 'visibility:visible');
};

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

// TOUR BOOKING FORM BUTTON DONE - SUCCESS MODAL CLICK FUNCTION
$('#booking-done').click(function () {
    window.location.href = "/";
});

// TOUR BOOKING FORM BUTTON CANCEL - FAILED MODAL CLICK FUNCTION
$('#cancel-on-failed').click(function () {
    window.location.href = "/";
});

// TOUR BOOKING FORM BUTTON BOOK AGAIN - FAILED MODAL CLICK FUNCTION
$('#book-again-on-failed').click(function () {
    $(".payment-failed-modal").fadeOut();
});

//TOUR MODAL BUTTON CLOSE - CLICK FUNCTION
(function () {
    $('.modal-window-close').click(function () {
        $(this).data('clicked', true);
        $(this)
            .parent()
            .parent()
            .fadeOut();
            window.location.reload();
    });
})();

function chargeCustomerDeposit() {
    const tourId = $('#tour-id').val();
    const date = $('#date').val();
    const time = $('#time').val();
    const numberOfPeople = $('#number-of-people').val();
    const fullName = $('#full-name').val();
    const phone = $('#phone').val();
    const email = $('#email').val();
    const additionalInfo = $('#additional-info').val();
    const applicationId = $('#application-id').val();

    const bookingDeposit = {
        tourId,
        date,
        time,
        numberOfPeople,
        fullName,
        phone,
        email,
        additionalInfo,
        applicationId
    };

    $.ajax({
        type: 'POST',
        data: JSON.stringify(bookingDeposit),
        contentType: 'application/json; charset=UTF-8',
        url: '/api/booking/deposit/tour'
    })
        .done(function (data) {
            const { externalId, totalPrice } = data;

            //SET PAYMENT METHOD BUTTONS PARENT ELEMENT
            const paymentMethodModal = $('#payment-buttons');

            //ANNOUNCE NEW DEPOSIT BUTTON ELEMENT
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
            newDepositPaymentBtn.setAttribute('data-amount', totalPrice);

            //ANNOUNCE NEW FULL BUTTON ELEMENT
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
            newFullPaymentBtn.setAttribute('data-amount', totalPrice);

            //ADD NEW FULL AND DEPOSIT PAYMENT BUTTONS TO PAYMENT MODAL
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

            function showFailureModal() {
                $('.payment-failed-modal')
                    .fadeIn()
                    .css('display', 'flex');
            }

            function showSuccessModal() {
                $('.payment-successful-modal')
                    .fadeIn()
                    .css('display', 'flex');
            }

            window.agentcash.chargeAmount(newDepositPaymentBtn, customer)
                .done(function (invoice) {
                    $('.ac-checkout-container').fadeOut();
                    if (invoice.status === 'approved') {
                        showSuccessModal();
                    } else {
                        showFailureModal();
                    }
                })
                .fail(function (error) {
                    console.log("Failure!", error);
                    showFailureModal();
                });
        })
        .fail(function (jqXhr, status, error) {
            console.error('An error has occurred while creating a booking');
            console.error(error);
            showFailureModal();
        });
}

window.chargeCustomerDeposit = chargeCustomerDeposit;

function chargeCustomerFull() {
    const tourId = $('#tour-id').val();
    const date = $('#date').val();
    const time = $('#time').val();
    const numberOfPeople = $('#number-of-people').val();
    const fullName = $('#full-name').val();
    const phone = $('#phone').val();
    const email = $('#email').val();
    const additionalInfo = $('#additional-info').val();
    const applicationId = $('#application-id').val();

    const bookingFull = {
        tourId,
        date,
        time,
        numberOfPeople,
        fullName,
        phone,
        email,
        additionalInfo,
        applicationId
    };

    $.ajax({
        type: 'POST',
        data: JSON.stringify(bookingFull),
        contentType: 'application/json; charset=UTF-8',
        url: '/api/booking/full/tour'
    })
        .done(function (data) {
            const { externalId, totalPrice } = data;

            //SET PAYMENT METHOD BUTTONS PARENT ELEMENT
            const paymentMethodModal = $('#payment-buttons');

            //ANNOUNCE NEW DEPOSIT BUTTON ELEMENT
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
            newDepositPaymentBtn.setAttribute('data-amount', totalPrice);

            //ANNOUNCE NEW FULL BUTTON ELEMENT
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
            newFullPaymentBtn.setAttribute('data-amount', totalPrice);

            //ADD NEW FULL AND DEPOSIT PAYMENT BUTTONS TO PAYMENT MODAL
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

            function showFailureModal() {
                $('.payment-failed-modal')
                    .fadeIn()
                    .css('display', 'flex');
            }

            function showSuccessModal() {
                $('.payment-successful-modal')
                    .fadeIn()
                    .css('display', 'flex');
            }

            window.agentcash.chargeAmount(newFullPaymentBtn, customer)
                .done(function (invoice) {
                    $('.ac-checkout-container').fadeOut();
                    if (invoice.status === 'approved') {
                        showSuccessModal();
                    } else {
                        showFailureModal();
                    }
                })
                .fail(function (error) {
                    console.log("Failure!", error);
                    showFailureModal();
                });
        })
        .fail(function (jqXhr, status, error) {
            console.error('An error has occurred while creating a booking');
            console.error(error);
            showFailureModal();
        });
}

window.chargeCustomerFull = chargeCustomerFull;

$('#btn-checkout-full').click(function () {
    chargeCustomerFull();
});

$('#btn-checkout-deposit').click(function () {
    chargeCustomerDeposit();
});

