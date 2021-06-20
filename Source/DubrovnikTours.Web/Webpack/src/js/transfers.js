import 'jquery-ui/ui/widgets/datepicker';
import 'jquery-ui/themes/base/core.css';
import 'jquery-ui/themes/base/datepicker.css';
import 'jquery-ui/themes/base/theme.css';
import 'jquery.scrollbar';
import 'jquery.scrollbar/sass/jquery.scrollbar.scss';

const errorModal = $('#errorMessage');

$('#closeErrorMessage').on("click", function () {
    $(".show-route-loader").hide();
    //HIDE ERROR MESSAGE
    errorModal.hide();
    emptyAllFieldValues();
});

// TRANSFER BOOKING FORM BUTTON DONE - SUCCESS MODAL CLICK FUNCTION
$('#booking-done').click(function () {
    window.location.href = "/";
});

// TRANSFER BOOKING FORM BUTTON CANCEL - FAILED MODAL CLICK FUNCTION
$('#cancel-on-failed').click(function () {
    window.location.href = "/";
});

// TRANSFER BOOKING FORM BUTTON BOOK AGAIN - FAILED MODAL CLICK FUNCTION
$('#book-again-on-failed').click(function () {
    $(".payment-failed-modal").fadeOut();
});

//TRANSFER MODAL BUTTON CLOSE - CLICK FUNCTION
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
        });
}

window.chargeCustomerFull = chargeCustomerFull;

//TRANSFER - BOOKING FORM - SUBMIT FUNCTION
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
    })
        .done(function () {
            $('.error').hide();
            $('.success').addClass('success');
            $('input').val('');
            $('textarea').val('');
            $('.success').html('Your transfer request has been sent. We will be in touch!');
            setTimeout(function () {
                window.location.reload();
            }, 5000);
        })
        .fail(function () {
            $('.error').addClass('error');
            $('.error').html('Something went wrong and we couldn\'t send your message, please try again later.');
            setTimeout(function () {
                window.location.reload();
            }, 5000);
        });
};

//TRANSFER - BOOKING FORM - SUBMIT REQUEST FUNCTION
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

