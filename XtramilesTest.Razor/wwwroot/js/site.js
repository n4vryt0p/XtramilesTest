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
        $('#cityEx').prop('disabled', true);
        $('#cityEx').val(null).trigger('change');
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
                    console.log(datas)
                },
                error: function (request) {
                    console.log(request)
                }
            });
        }
    });
});