(function ($) {
    'use strict';
    $(function () {

        //Init charts
        $('.peity-chart').each(function (i, key) {
            var chartType = $(key).data('chartType');

            if (chartType === 'pie' || chartType === 'donut') {
                $(key).peity(chartType, { fill: ['#009688', '#ddd'] });
            } else if (chartType === 'line') {
                $(key).peity(chartType, { fill: 'rgba(0, 150, 136, 0.25)', stroke: 'rgba(0, 150, 136, 1)' });
            }
            else if (chartType === 'bar') {
                $(key).peity(chartType, { fill: ['#16a085'] });
            }
            else {
                $(key).peity(chartType);
            }
        });

        //Init animating chart
        var animatingChart = $('.animating-chart').peity('line', { width: 175, fill: 'rgba(0, 150, 136, 0.25)', stroke: 'rgba(0, 150, 136, 1)' });
        setInterval(function () {
            var random = Math.round(Math.random() * 10);
            var values = animatingChart.text().split(',');
            values.shift();
            values.push(random);

            animatingChart.text(values.join(',')).change();
        },
            1000);

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
