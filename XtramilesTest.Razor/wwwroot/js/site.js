"use strict";



$(document).ready(function () {
    $('#countryEx').select2({
        placeholder: 'Select Country...',
        allowClear: true
    });
    $('#cityEx').select2({
        placeholder: 'Select City...',
        allowClear: true
    });

    $('#countryEx').on('select2:select', function (e) {
        let dataId = e.params.data.id;
        if (dataId != "") {
            window.$.ajax({
                type: 'GET',
                url: 'http://localhost:5000/WeatherForecast/City/' + dataId,
                dataType: 'json',
                cors: true,
                contentType: 'application/json',
                secure: true,
                headers: {
                    'Access-Control-Allow-Origin': '*',
                },
                success: function (datas) {
                    let datax = $.map(datas, function (obj) {
                        obj.text = obj.text || obj.name;
                        return obj;
                    });
                    console.log(datax);

                    $('#cityEx').empty();
                    $('#cityEx').select2({
                        placeholder: 'Select City...',
                        allowClear: true,
                        data: datax
                    });
                    $('#cityEx').val(null).trigger("change");
                    $('#cityEx').prop('disabled', false);
                },
                error: function (request) {
                    console.log(request)
                }
            });
        }
    });

    $('#countryEx').on('select2:unselect', function (e) {
        var elements = document.getElementsByTagName("input");
        for (var ii = 0; ii < elements.length; ii++) {
            if (elements[ii].type == "text") {
                elements[ii].value = "";
            }
        }
        $('#cityEx').prop('disabled', true);
        $('#cityEx').val(null).trigger('change');
    });

    $('#cityEx').on('select2:unselect', function (e) {
        var elements = document.getElementsByTagName("input");
        for (var ii = 0; ii < elements.length; ii++) {
            if (elements[ii].type == "text") {
                elements[ii].value = "";
            }
        }
    });

    $('#cityEx').on('select2:select', function (e) {
        let dataId = e.params.data.id;
        if (dataId != null) {
            window.$.ajax({
                type: 'GET',
                url: 'http://localhost:5000/WeatherForecast/' + dataId,
                dataType: 'json',
                cors: true,
                contentType: 'application/json',
                secure: true,
                headers: {
                    'Access-Control-Allow-Origin': '*',
                },
                success: function (datas) {
                    $('#lat').val(datas.city.coord.lat);
                    $('#long').val(datas.city.coord.lon);
                    let datTime = getDateTime(datas.time);
                    $('#time').val(datTime);
                    $('#wSpeed').val(datas.wind.speed);
                    $('#visi').val(datas.weather[0].main);
                    $('#weather').val(datas.weather[0].description);
                    $('#tempF').val(kelvinTofahrenheit(datas.main.temp) + ' Fahrenheit');
                    $('#tempC').val(kelvinToCelsius(datas.main.temp) + ' Celcius');
                    $('#humid').val(datas.main.humidity);
                    $('#press').val(datas.main.pressure);
                },
                error: function (request) {
                    console.log(request)
                }
            });
        }
    });
});

function getDateTime(t) {
    let date = new Date(t * 1000);
    // Hours part from the timestamp
    let hours = date.getHours();
    // Minutes part from the timestamp
    let minutes = "0" + date.getMinutes();
    // Seconds part from the timestamp
    let seconds = "0" + date.getSeconds();

    // Will display time in 10:30:23 format
    return hours + ':' + minutes.substr(-2) + ':' + seconds.substr(-2);
}

function kelvinToCelsius(t) {
    return t - 273.15;
}

function kelvinTofahrenheit(t) {
    return ((t - 273.15) * 1.8) + 32;
}