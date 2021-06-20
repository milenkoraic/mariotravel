// API REQUEST FOR TOUR BOOKING TIMES 
function getAvailibleTourBookingTimes(){
    let id = $("#tour-id").val();
    let date = $("#date").datepicker().val();

    $.ajax({
        type: 'GET',
        url: '/api/tour/booking/default/times/availible/' + id + "/" + date,
        contentType: 'application/json; charset=UTF-8',
    })

    .done(function(data) {
        const { availibleTourBookingTimes } = data;

        $("#time").empty();  
        let arrayLength = availibleTourBookingTimes.length;
        let tourBookingTimes = availibleTourBookingTimes.map(a => a.startAt.substring(0, a.startAt.length-3));

        for (let i = 0; i < arrayLength; i++) {
            $("#time").append("<option value='" + tourBookingTimes[i] + "'>" + tourBookingTimes[i] + "</option>");
        }
        console.log(data);
    })
    .fail(function(error) {
        console.log("Failure!", error);
    });
}

// API REQUEST FOR NESTED BOOKING TIMES 
function getNestedTourBookingTimes(){
    let id = $("#tour-id").val();
    let date = $("#date").datepicker().val();
    $.ajax({
        type: 'GET',
        url: '/api/tour/booking/nested/times/availible/' + id + "/" + date,
        contentType: 'application/json; charset=UTF-8',
    })
    .done(function(data) {
        const { availibleNestedBookingTimes } = data;
        $("#time").empty();  
        let arrayLength = availibleNestedBookingTimes.length;
        let nestedBookingTimes = availibleNestedBookingTimes.map(a => a.startAt.substring(0, a.startAt.length-3));
        for (let i = 0; i < arrayLength; i++) {
            $("#time").append("<option value='" + nestedBookingTimes[i] + "'>" + nestedBookingTimes[i] + "</option>");
        }
        console.log(data);
    })
    .fail(function(error) {
        console.log("Failure!", error);
    });
}

// DATE CHANGED - DATAPICKER EVENT LISTNER FOR BOOKING TIME SERVICE REQUESTS
const service = $("#service-name").val();
const timeNestingInput = $('#time-nesting');
let usingNestedTimes = timeNestingInput.val();

$('#date').change(function () {  
    console.log(service);

    if(usingNestedTimes == "True"){
        getNestedTourBookingTimes();
        console.log("Nested times API request sent!");
    }
    
    else{
        getAvailibleTourBookingTimes();
        console.log("Tour times API request sent!");
    }
});