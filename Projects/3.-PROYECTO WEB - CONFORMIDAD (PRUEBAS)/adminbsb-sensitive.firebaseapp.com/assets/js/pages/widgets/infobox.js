(function ($) {
    'use strict';
    $(function () {
        //Count To
        $('.count-to').countTo();

        //Chart Bar
        $('.chart.chart-bar').sparkline(undefined, {
            type: 'bar',
            barColor: '#fff',
            negBarColor: '#fff',
            barWidth: '4px',
            height: '34px'
        });

        //Chart Pie
        $('.chart.chart-pie').sparkline(undefined, {
            type: 'pie',
            height: '50px',
            sliceColors: ['rgba(255,255,255,0.70)', 'rgba(255,255,255,0.85)', 'rgba(255,255,255,0.95)', 'rgba(255,255,255,1)']
        });

        //Chart Line
        $('.chart.chart-line').sparkline(undefined, {
            type: 'line',
            width: '60px',
            height: '45px',
            lineColor: '#fff',
            lineWidth: 1.3,
            fillColor: 'rgba(0,0,0,0)',
            spotColor: 'rgba(255,255,255,0.40)',
            maxSpotColor: 'rgba(255,255,255,0.40)',
            minSpotColor: 'rgba(255,255,255,0.40)',
            spotRadius: 3,
            highlightSpotColor: '#fff'
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
