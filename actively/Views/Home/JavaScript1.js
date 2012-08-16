var map;
var pos;

function GeoLocation() {
    // Try HTML5 geolocation
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            $(document).trigger('simpledialog', { 'method': 'close' });
            pos = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
            map.setCenter(pos);
        }, function () {
            handleNoGeolocation(true);
        });
    } else {
        // Browser doesn't support Geolocation
        handleNoGeolocation(false);
    }
};

function initialize() {
    var myOptions = {
        d                   zoom: 13,
        mapTypeId: google.maps.MapTypeId.ROADMAP,
        streetViewControl: false,
        overviewMapControl: false,
        mapTypeControl: false
    };

    map = new google.maps.Map(document.getElementById('map'), myOptions);

    if (pos == null) {
        handleNoGeolocation();
    }
    else {
        map.setCenter(pos);
    }
};

function handleNoGeolocation(errorFlag) {
    $(document).simpledialog2(positionDialogModel);
    //map.setCenter(options.position);
}

$(document).ready(function () {
    WindowResize();
    initialize();
    GeoLocation();

    $(window).resize(WindowResize);
});

function WindowResize() {
    $('#map').height($(window).height() - $('#header').height() - $('#footer').outerHeight());
};

var positionDialogModel = {
    mode: 'button',
    width: '75%',
    headerText: 'Your Location',
    headerClose: false,
    themeDialog: 'a',
    themeInput: 'a',
    buttonPrompt: 'Please click to <b>allow the browser\'s prompt for Geolocation</b>, or enter your <b>location below (City,State,Zip)</b>.',
    buttonInput: true,
    buttons: {
        'OK': {
            click: function () {
                GetPosition($.mobile.sdLastInput);
                //centermap on position
                //search near position for everything
                //bind to knockout
            }
        },
    }
};


function GetPosition(query) {
    var url = './api/zip/' + query;
    $.ajax({
        url: url,
        dataType: 'json',
        type: 'GET'
    }).done(function (data) {
        pos = new google.maps.LatLng(data[0].Position.Latitude, data[0].Position.Longitude)
        map.setCenter(pos);
    })
        .fail(function () { alert("error"); })
        .always(function () { });
};

function Search(term, sucess, failure) {
    var url = './api/locations/search?latitude=' + pos.latitude + '&longitude=' + pos.longitude + '&term=' + term + '&distance=' + 50;
    $.ajax({
        url: url,
        dataType: 'json',
        type: 'GET'
    }).done(function () { sucess(); })
        .fail(function () { failure(); })
        .always(function () { alert("complete"); });
    //bind to knockout
    //should filter be part of knockout?                                    
};