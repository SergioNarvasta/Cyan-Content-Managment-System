(function ($) {
    'use strict';
    $(function () {
        setDateTime();
        setInterval(setDateTime, 3000);

        function setDateTime() {
            $('.watch').text(moment().format('hh:mm'));
            $('.date').text(moment().format('dddd, MMMM YYYY'));
        }
    });
}(jQuery))
