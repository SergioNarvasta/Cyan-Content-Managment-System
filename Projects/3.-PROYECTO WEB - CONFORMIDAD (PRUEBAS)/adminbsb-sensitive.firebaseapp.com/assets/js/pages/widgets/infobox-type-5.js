(function ($) {
    'use strict';
    $(function () {
        //Count To
        $('.count-to').countTo();

        //HexCode To Rgba Helper
        function hexToRgba(hexCode, opacity) {
            var patt = /^#([\da-fA-F]{2})([\da-fA-F]{2})([\da-fA-F]{2})$/;
            var matches = patt.exec(hexCode);
            var rgb = "rgba(" + parseInt(matches[1], 16) + "," + parseInt(matches[2], 16) + "," + parseInt(matches[3], 16) + "," + opacity + ")";
            return rgb;
        }

        //Chart Bar
        $.each($('.chart.chart-bar'), function (i, key) {
            var chartColor = $(key).data('chartcolor');
            $(key).sparkline(undefined, {
                type: 'bar',
                barColor: chartColor,
                negBarColor: chartColor,
                barWidth: '8px',
                height: '34px'
            });
        });

        //Chart Pie
        $.each($('.chart.chart-pie'), function (i, key) {
            var chartColor = $(key).data('chartcolor');
            $(key).sparkline(undefined, {
                type: 'pie',
                height: '50px',
                sliceColors: [hexToRgba(chartColor, '0.55'), hexToRgba(chartColor, '0.70'), hexToRgba(chartColor, '0.85'), hexToRgba(chartColor, '1')]
            });
        });

        //Chart Line
        $.each($('.chart.chart-line'), function (i, key) {
            var chartColor = $(key).data('chartcolor');
            $(key).sparkline(undefined, {
                type: 'line',
                width: '60px',
                height: '45px',
                lineColor: chartColor,
                lineWidth: 1.3,
                fillColor: 'rgba(0,0,0,0)',
                spotColor: chartColor,
                maxSpotColor: chartColor,
                minSpotColor: chartColor,
                spotRadius: 3,
                highlightSpotColor: chartColor
            });
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
