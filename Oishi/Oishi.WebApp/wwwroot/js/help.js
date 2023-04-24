
function initMap() {

    const local = { lat: 38.72263, lng: -9.13448 };
    const map = new google.maps.Map(document.getElementById("googlemaps"), {
        center: local,
        zoom: 8,
    });

    const marker = new google.maps.Marker({
        position: local,
        map: map,
    });
}

window.initMap = initMap;

