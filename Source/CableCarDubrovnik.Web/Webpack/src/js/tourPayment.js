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
    });
})();

function chargeCustomerDeposit() {
    const tourId = $('#tour-id').val();
    const date = $('#date').val();
    const time = $('#time').val();
    const numberOfPeople = $('#number-of-people').val();
    const numberOfChildren = $('#number-of-children').val();
    const numberOfBabies = $('#number-of-babies').val();
    const pickUpPoint = $('#pick-up-point').val();
    const fullName = $('#full-name').val();
    const phone = $('#phone').val();
    const email = $('#email').val();
    const additionalInfo = $('#additional-info').val();

    const bookingDeposit = {
        tourId,
        date,
        time,
        numberOfPeople,
        numberOfChildren,
        numberOfBabies,
        pickUpPoint,
        fullName,
        phone,
        email,
        additionalInfo
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

            //LOG DEPOSIT BUTTON ATTRIBUTES DATA TO CONSOLE
            console.log("FULL PAYMANT DATA ATTRIBUTES-------------------");
            console.log($('#btn-checkout-deposit').attr('data-callback-url'));
            console.log($('#btn-checkout-deposit').attr('data-language'));
            console.log($('#btn-checkout-deposit').attr('data-external-id'));
            console.log($('#btn-checkout-deposit').attr('data-amount'));
            console.log("------------------------------------------------");

            //LOG FULL BUTTON ATTRIBUTES DATA TO CONSOLE
            console.log("FULL PAYMANT DATA ATTRIBUTES-------------------");
            console.log($('#btn-checkout-full').attr('data-callback-url'));
            console.log($('#btn-checkout-full').attr('data-language'));
            console.log($('#btn-checkout-full').attr('data-external-id'));
            console.log($('#btn-checkout-full').attr('data-amount'));
            console.log("------------------------------------------------");

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
    const numberOfChildren = $('#number-of-children').val();
    const numberOfBabies = $('#number-of-babies').val();
    const pickUpPoint = $('#pick-up-point').val();
    const fullName = $('#full-name').val();
    const phone = $('#phone').val();
    const email = $('#email').val();
    const additionalInfo = $('#additional-info').val();

    const bookingFull = {
        tourId,
        date,
        time,
        numberOfPeople,
        numberOfChildren,
        numberOfBabies,
        pickUpPoint,
        fullName,
        phone,
        email,
        additionalInfo
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

            //LOG DEPOSIT BUTTON ATTRIBUTES DATA TO CONSOLE
            console.log("FULL PAYMANT DATA ATTRIBUTES-------------------");
            console.log($('#btn-checkout-deposit').attr('data-callback-url'));
            console.log($('#btn-checkout-deposit').attr('data-language'));
            console.log($('#btn-checkout-deposit').attr('data-external-id'));
            console.log($('#btn-checkout-deposit').attr('data-amount'));
            console.log("------------------------------------------------");

            //LOG FULL BUTTON ATTRIBUTES DATA TO CONSOLE
            console.log("FULL PAYMANT DATA ATTRIBUTES-------------------");
            console.log($('#btn-checkout-full').attr('data-callback-url'));
            console.log($('#btn-checkout-full').attr('data-language'));
            console.log($('#btn-checkout-full').attr('data-external-id'));
            console.log($('#btn-checkout-full').attr('data-amount'));
            console.log("------------------------------------------------");

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

$('#btn-checkout-deposit').click(function () {
    chargeCustomerDeposit();
});

$('#btn-checkout-full').click(function () {
    chargeCustomerFull();
});