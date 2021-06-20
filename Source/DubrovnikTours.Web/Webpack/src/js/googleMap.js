function initMap() {
    
    var center = { lat: 42.6422404, lng: 18.1056881 };

    var map = new google.maps.Map(document.getElementById('meeting-point-map'),
    {
    center: center,
    zoom: 17,
    fullscreenControl: true,
    zoomControl: true,
    scaleControl: true});
    var styles = 
                [
                {featureType: 'administrative', elementType: 'geometry',stylers: [{ visibility: 'off', },],},
                {featureType: 'administrative.land_parcel',stylers: [{ visibility: 'off', },],},
                {featureType: 'administrative.neighborhood',stylers: [{ visibility: 'off', },],}, 
                {featureType: 'poi',stylers: [{ visibility: 'off', },],}, 
                {featureType: 'poi', elementType: 'labels.text',stylers: [{ visibility: 'on', },],}, 
                {featureType: 'road', elementType: 'labels',stylers: [{ visibility: 'on', },],}, 
                {featureType: 'road', elementType: 'labels.icon',stylers: [{ visibility: 'off', },],}, 
                {featureType: 'transit',stylers: [{ visibility: 'off', },]}, 
                {featureType: 'water', elementType: 'labels.text',stylers: [{ visibility: 'off', },],},
                ];

     map.setOptions({ styles: styles });

     var image = '/ico/location.png'; new google.maps.Marker({ position: center, map: map, icon: image});};

     window.initMap = initMap;