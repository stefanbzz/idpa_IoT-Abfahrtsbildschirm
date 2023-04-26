// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var hrTrans = 'translate(-50%, 16px)';
var minTrans = 'translate(-50%, 16px)';
var secTrans = 'translate(-50%, 20px)';
var hrHand, minHand, secHand;

$(document).ready(function () {
    hrHand = $('#hr-hand');
    minHand = $('#min-hand');
    secHand = $('#sec-hand');

    initMarkers();

    setClockTime();
    setInterval(setClockTime, 1000);
});

var initMarkers = function () {
    var i = 0;
    var hrMarkers = $('#hrMarkers');
    var minMarkers = $('#minMarkers');

    if (hrMarkers.length) {
        for (i = 0; i < 12; i++) {
            $('<div></div>').appendTo(hrMarkers[0]);
        }
    }
    if (minMarkers.length) {
        for (i = 0; i < 60; i++) {
            $('<div></div>').appendTo(minMarkers[0]);
        }
    }
};

var setClockTime = function () {
    var now = new Date();
    var hr = now.getHours();
    var min = now.getMinutes();
    var sec = now.getSeconds();

    if (sec === 0 || sec === 1) {
        sec = 0;
        min = (min - 1) % 60;
    }

    setHours(hr, min);
    setMinutes(min, sec);
    setSeconds(sec);
};

var setHours = function (hr, min) {
    var h = (hr % 12) / 12;
    var m = min / 720;
    var rotation = (h + m) * 360;
    hrHand.css('transform', getHandTransform(hrTrans, rotation));
};

var setMinutes = function (min) {
    var rotation = min / 60 * 360;
    minHand.css('transform', getHandTransform(minTrans, rotation));
};

var setSeconds = function (sec) {
    var rotation = sec / 60 * 360;
    secHand.css('transform', getHandTransform(secTrans, rotation));
};

var getHandTransform = function (baseTrans, zRotation) {
    return baseTrans + ' rotateZ(' + zRotation + 'deg)';
};
