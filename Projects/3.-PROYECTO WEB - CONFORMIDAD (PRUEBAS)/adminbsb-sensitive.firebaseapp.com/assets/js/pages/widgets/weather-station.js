(function ($) {
    'use strict';
    $(function () {

        $('[data-weather]').each(function (i, key) {
            var weather = $(key).data('weather');

            var skycons = new Skycons({ 'color': '#555' });
            skycons.add($(key)[0], weather);
            skycons.play();
        });

        //Init switch buttons
        var $switchButtons = Array.prototype.slice.call(document.querySelectorAll('.js-switch'));
        $switchButtons.forEach(function (e) {
            var size = $(e).data('size');
            var options = {};
            options['color'] = '#009688';
            if (size !== undefined) options['size'] = size;

            var switchery = new Switchery(e, options);
        });
    });
}(jQuery))
