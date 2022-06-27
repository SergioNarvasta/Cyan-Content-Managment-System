(function ($) {
    'use strict';
    $(function () {
        //Count To
        $('.count-to').countTo();

        //Chart Bar
        $('.chart.chart-bar').sparkline(undefined, {
            type: 'bar',
            barColor: 'rgba(0, 0, 0, 0.15)',
            negBarColor: 'rgba(0, 0, 0, 0.15)',
            barWidth: '5px',
            height: '34px'
        });

        //Chart Pie
        $('.chart.chart-pie').sparkline(undefined, {
            type: 'pie',
            height: '50px',
            sliceColors: ['rgba(0,0,0,0.10)', 'rgba(0,0,0,0.15)', 'rgba(0,0,0,0.20)', 'rgba(0,0,0,0.25)']
        });

        //Chart Line
        $('.chart.chart-line').sparkline(undefined, {
            type: 'line',
            width: '60px',
            height: '45px',
            lineColor: 'rgba(0, 0, 0, 0.15)',
            lineWidth: 2,
            fillColor: 'rgba(0,0,0,0)',
            spotColor: 'rgba(0, 0, 0, 0.15)',
            maxSpotColor: 'rgba(0, 0, 0, 0.15)',
            minSpotColor: 'rgba(0, 0, 0, 0.15)',
            spotRadius: 3,
            highlightSpotColor: 'rgba(0, 0, 0, 0.15)'
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
