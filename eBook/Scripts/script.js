'use strict';

$(document).ready(function () {

    if ("geolocation" in navigator) {
        navigator.geolocation.getCurrentPosition(function (position) {
            updateWeather(position);
        }, function (error) {
            // Default position if an error occured (e.g. user denied)
            updateWeather(defaultLocation);
        });
    } else {
        /* geolocation IS NOT available */
        updateWeather(defaultLocation);
    }
});

var defaultLocation = {
    coords: {
        latitude: 32.074302,
        longitude: 34.791007
    }
};


// Call weather API
function updateWeather(position) {
    $.get("https://api.openweathermap.org/data/2.5/weather?lat=" + position.coords.latitude + "&lon=" + position.coords.longitude + "&appid=b9da17a60e42e3086ba964c8fa1106c8&units=metric", function (data) {
        $("#temperature").html(data.main.temp + "&#8451;");
        $("#city").html(data.name);
    });
}



