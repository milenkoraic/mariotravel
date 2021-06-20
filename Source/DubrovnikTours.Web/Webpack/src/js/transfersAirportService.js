import 'jquery-ui/ui/widgets/datepicker';
import 'jquery-ui/themes/base/core.css';
import 'jquery-ui/themes/base/datepicker.css';
import 'jquery-ui/themes/base/theme.css';
import 'jquery.scrollbar';
import 'jquery.scrollbar/sass/jquery.scrollbar.scss';

function getAirportToDestinationTransferPrice(){
    let airportSelectedIndex = $(".form-airport-selector option:selected").index();
    let groupSelectedIndex = $(".form-number-selector option:selected").index();
    let destinationSelectedIndex = $(".form-location-selector option:selected").index();

    const airportId = airportSelectedIndex + 1;
    const groupType = groupSelectedIndex + 1;
    const destinationId = destinationSelectedIndex + 1;

    const totalPriceInput = $("#total-price");
    const userDisplayPriceInput = $("#airport-service-price");
    const transferDistanceInput = $("#transfer-distance");
    const transferDurationInput = $("#transfer-duration");
    let transferType = $('#transfer-type');

    $.ajax({
        type: 'GET',
        url: '/api/prices/transfer/airport/service/price/' + airportId + "/" + groupType + "/" + destinationId,
        contentType: 'application/json; charset=UTF-8',
    })

    .done(function(data) {
        const {                 
            totalPrice,
            transferDistance,
            transferDuration,
            serviceCounted} = data;
            transferDistanceInput.val(transferDistance);
            transferDurationInput.val(transferDuration);
            totalPriceInput.val(totalPrice);
            userDisplayPriceInput.val(totalPrice + " HRK");
            transferType.val(serviceCounted);
            console.log(data);
    })
    .fail(function(error) {
        console.log("Failure!", error);
    });
}

getAirportToDestinationTransferPrice();

//IF AIRPORT IS CHANGED SWAP LOCATIONS
$('.form-airport-selector').change(function () {
    getAirportToDestinationTransferPrice();
});

//IF LOCATION IS CHANGED SHOW DIFFERENT PRICE
$('.form-number-selector').change(function () {
    getAirportToDestinationTransferPrice();
});

//IF LOCATION IS CHANGED SHOW DIFFERENT PRICE
$('.form-location-selector').change(function () {
    getAirportToDestinationTransferPrice();
});

//IF SERVICE TYPE (DIRECTION) IS CHANGED SWAP LOCATIONS
$('.form-direction-selector').change(function () {
    let selectedDirectionIndex = $(".form-direction-selector option:selected").index();

    let selectedStart = $('.form-airport-selector').children("option:selected").val();
    let selectedEnd = $('.form-location-selector').children("option:selected").val();

    if (selectedDirectionIndex == 0) {
        $('#start-label').show();
        $('#end-label').hide();

        $('.direction-indicator').html("DEPARTURE");

        $('#location-a').val(selectedStart);
        $('#location-b').val(selectedEnd);
    } else {
        $('#start-label').hide();
        $('#end-label').show();

        $('.direction-indicator').html("ARRIVAL");

        $('#location-a').val(selectedStart);
        $('#location-b').val(selectedEnd);
    }
});

$('#airport-service-btn').on("click", function () {
    $("#map").css({ 'visibility': 'hidden' });
    $('.transfer-cards-container').hide();
    let selectedDirectionIndex = $(".form-direction-selector option:selected").index();
    if (selectedDirectionIndex == 0) {
        let selectedStart = $('.form-location-selector').children("option:selected").val();
        let selectedEnd = $('.form-airport-selector').children("option:selected").val();

        $('#location-a').val(selectedStart);
        console.log(selectedStart);
        $('#location-b').val(selectedEnd);
        console.log(selectedEnd);
        $('#transfer-price').val($("#total-price").val() + " HRK");
    } else {
        let selectedStart = $('.form-airport-selector').children("option:selected").val();
        let selectedEnd = $('.form-location-selector').children("option:selected").val();

        $('#location-a').val(selectedStart);
        console.log(selectedStart);
        $('#location-b').val(selectedEnd);
        console.log(selectedEnd);
        $('#transfer-price').val($("#total-price").val() + " HRK");
    }

    let selectedGroupIndex = $(".form-number-selector option:selected").index();

    if (selectedGroupIndex == 0) {
        if ($('#location-a').val() !== "" && $('#location-b').val() !== "")
            $('.page-transfers-form-container').fadeIn(1000);
        $("#reservation-text").html("SMALL GROUP RESERVATION <br/>(1 - 4 PERSONS)");

        $("#number-of-people").val(1);
        $("#number-of-people").attr({
            "max": 4,
            "min": 1
        });
        $('#submit-form-request').hide();
        $('#submit-form').show();
    } else if (selectedGroupIndex == 1) {
        if ($('#location-a').val() !== "" && $('#location-b').val() !== "")
            $('.page-transfers-form-container').fadeIn(1000);
        $("#reservation-text").html("MEDIUM GROUP RESERVATION <br/> (5-8 PERSONS)");

        $("#number-of-people").val(5);
        $("#number-of-people").attr({
            "max": 8,
            "min": 5
        });
        $('#submit-form-request').hide();
        $('#submit-form').show();
    } else {
        $('.page-transfers-form-container').fadeIn(1000);
        $("#reservation-text").html("LARGE GROUP REQUEST <br/>(9+ PERSONS)");

        $("#number-of-people").val(10);
        $("#number-of-people").attr({
            "max": 1000,
            "min": 9
        });
        $('#submit-form-request').show();
        $('#submit-form').hide();
    }

    //SCROLL BOOKING FORM SMOOTH
    $('html, body').animate({
        scrollTop: $(".page-transfers-calculations-container").offset().top - 10
    }, 500);
});

// TOUR - BOOKING FORM - VALIDATION MODALS
(function (w) {
    $('.tour-info-text-content').scrollbar();

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