(function ($) {
    'use strict';
    $(document).ready(function () {
        var $el = $('#world-map-markers');

        $el.vectorMap({
            map: 'world_mill_en',
            normalizeFunction: 'polynomial',
            hoverOpacity: 0.7,
            hoverColor: false,
            backgroundColor: 'transparent',
            regionStyle: {
                initial: {
                    fill: 'rgba(210, 214, 222, 1)',
                    "fill-opacity": 1,
                    stroke: 'none',
                    "stroke-width": 0,
                    "stroke-opacity": 1
                },
                hover: {
                    "fill-opacity": 0.7,
                    cursor: 'pointer'
                },
                selected: {
                    fill: 'yellow'
                },
                selectedHover: {}
            },
            markerStyle: {
                initial: {
                    fill: '#009688',
                    stroke: '#000'
                }
            }
        });

        //Select country
        $('.jm-select-country-holder select').on('change', function () {
            var val = $(this).val();
            if (val !== '' && val !== 'ALL') {
                $el.vectorMap('set', 'focus', { region: val, animate: true });
            } else {
                $el.vectorMap('set', 'focus', { scale: 1, x: 0.5, y: 0.5, animate: true });
            }
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
}(jQuery));