(function ($) {
    'use strict';
    $(function () {
        //Area
        var graph = new Rickshaw.Graph({
            element: document.querySelector('#chart_1'),
            series: [{
                color: '#009688',
                data: [{ x: 0, y: 45 }, { x: 1, y: 36 }, { x: 2, y: 48 }, { x: 3, y: 56 }, { x: 4, y: 50 }]
            }]
        });
        graph.render();

        //Stacked Area
        var graph2 = new Rickshaw.Graph({
            element: document.querySelector('#chart_2'),
            series: [{
                data: [{ x: 0, y: 45 }, { x: 1, y: 36 }, { x: 2, y: 48 }, { x: 3, y: 56 }, { x: 4, y: 50 }],
                color: 'rgba(0, 150, 136, 1)'
            }, {
                data: [{ x: 0, y: 45 }, { x: 1, y: 36 }, { x: 2, y: 48 }, { x: 3, y: 56 }, { x: 4, y: 50 }],
                color: 'rgba(0, 150, 136, 0.50)'
            }]
        });
        graph2.render();

        //Multiple Area
        var graph3 = new Rickshaw.Graph({
            element: document.querySelector('#chart_3'),
            renderer: 'area',
            stroke: true,
            series: [{
                data: [{ x: 0, y: 45 }, { x: 1, y: 36 }, { x: 2, y: 48 }, { x: 3, y: 56 }, { x: 4, y: 50 }],
                color: 'rgba(0, 150, 136, 1)',
                stroke: 'rgba(0, 150, 136, 1)'
            }, {
                data: [{ x: 0, y: 45 }, { x: 1, y: 36 }, { x: 2, y: 48 }, { x: 3, y: 56 }, { x: 4, y: 50 }],
                color: 'rgba(0, 150, 136, 0.50)',
                stroke: 'rgba(0, 150, 136, 0.50)'
            }]
        });
        graph3.render();

        //Line
        var graph4 = new Rickshaw.Graph({
            element: document.querySelector('#chart_4'),
            renderer: 'line',
            series: [{
                data: [{ x: 0, y: 45 }, { x: 1, y: 36 }, { x: 2, y: 48 }, { x: 3, y: 56 }, { x: 4, y: 50 }],
                color: 'rgba(0, 150, 136, 1)'
            }]
        });
        graph4.render();

        //Multiple Line
        var graph5 = new Rickshaw.Graph({
            element: document.querySelector('#chart_5'),
            renderer: 'line',
            series: [{
                data: [{ x: 0, y: 45 }, { x: 1, y: 36 }, { x: 2, y: 48 }, { x: 3, y: 56 }, { x: 4, y: 50 }],
                color: 'rgba(0, 150, 136, 1)'
            },
            {
                data: [{ x: 0, y: 32 }, { x: 1, y: 20 }, { x: 2, y: 33 }, { x: 3, y: 46 }, { x: 4, y: 40 }],
                color: '#DA4453'
            }]
        });
        graph5.render();

        //Bars
        var graph6 = new Rickshaw.Graph({
            element: document.querySelector('#chart_6'),
            renderer: 'bar',
            series: [{
                data: [{ x: 0, y: 45 }, { x: 1, y: 36 }, { x: 2, y: 48 }, { x: 3, y: 56 }, { x: 4, y: 50 }],
                color: 'rgba(0, 150, 136, 1)'
            }]
        });
        graph6.render();

        //Stacked Bars
        var graph7 = new Rickshaw.Graph({
            element: document.querySelector('#chart_7'),
            renderer: 'bar',
            series: [{
                data: [{ x: 0, y: 45 }, { x: 1, y: 36 }, { x: 2, y: 48 }, { x: 3, y: 56 }, { x: 4, y: 50 }],
                color: 'rgba(0, 150, 136, 1)'
            },
            {
                data: [{ x: 0, y: 45 }, { x: 1, y: 36 }, { x: 2, y: 48 }, { x: 3, y: 56 }, { x: 4, y: 50 }],
                color: 'rgba(0, 150, 136, 0.5)'
            }]
        });
        graph7.render();

        //Multiple Bars
        var graph8 = new Rickshaw.Graph({
            element: document.querySelector('#chart_8'),
            renderer: 'bar',
            stack: false,
            series: [{
                data: [{ x: 0, y: 45 }, { x: 1, y: 36 }, { x: 2, y: 48 }, { x: 3, y: 56 }, { x: 4, y: 50 }],
                color: 'rgba(0, 150, 136, 1)'
            },
            {
                data: [{ x: 0, y: 25 }, { x: 1, y: 16 }, { x: 2, y: 28 }, { x: 3, y: 36 }, { x: 4, y: 30 }],
                color: '#DA4453'
            }]
        });
        graph8.render();

        //Bars
        var graph9 = new Rickshaw.Graph({
            element: document.querySelector('#chart_9'),
            renderer: 'scatterplot',
            series: [{
                data: [{ x: 0, y: 45 }, { x: 1, y: 36 }, { x: 2, y: 48 }, { x: 3, y: 56 }, { x: 4, y: 50 }, { x: 5, y: 45 }, { x: 6, y: 36 }, { x: 7, y: 48 }, { x: 8, y: 56 }, { x: 9, y: 50 }],
                color: 'rgba(0, 150, 136, 1)'
            }]
        });
        graph9.render();

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
