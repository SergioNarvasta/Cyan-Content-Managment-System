(function ($) {
    'use strict';
    $(function () {
        //Line chart
        var chart1 = c3.generate({
            bindto: '#chart_1',
            data: {
                columns: [
                  ['Series A', 25, 125, 50, 175, 75, 125, 60],
                  ['Series B', 50, 40, 20, 60, 50, 35, 50]
                ],
                colors: {
                    'Series A': '#16a085',
                    'Series B': '#DA4453'
                }
            }
        });

        //Spline chart
        var chart2 = c3.generate({
            bindto: '#chart_2',
            data: {
                columns: [
                  ['Series A', 25, 125, 50, 175, 75, 125, 60],
                  ['Series B', 50, 40, 20, 60, 50, 35, 50]
                ],
                colors: {
                    'Series A': '#16a085',
                    'Series B': '#DA4453'
                },
                type: 'spline'
            }
        });

        //Bar chart
        var chart3 = c3.generate({
            bindto: '#chart_3',
            data: {
                columns: [
                  ['Series A', 25, 125, 50, 175, 75, 125, 60],
                  ['Series B', 50, 40, 20, 60, 50, 35, 50]
                ],
                colors: {
                    'Series A': '#16a085',
                    'Series B': '#DA4453'
                },
                type: 'bar'
            }
        });

        //Pie chart
        var chart4 = c3.generate({
            bindto: '#chart_4',
            data: {
                columns: [
                  ['Series A', 20],
                  ['Series B', 35],
                  ['Series C', 45]
                ],
                colors: {
                    'Series A': '#16a085',
                    'Series B': '#DA4453',
                    'Series C': '#f6b225'
                },
                type: 'pie'
            }
        });

        //Area chart
        var chart5 = c3.generate({
            bindto: '#chart_5',
            data: {
                columns: [
                  ['Series A', 25, 125, 50, 175, 75, 125, 60],
                  ['Series B', 50, 40, 20, 60, 50, 35, 50]
                ],
                colors: {
                    'Series A': '#16a085',
                    'Series B': '#DA4453'
                },
                type: 'area-spline'
            }
        });

        //Stacked bar chart
        var chart6 = c3.generate({
            bindto: '#chart_6',
            data: {
                columns: [
                  ['Series A', 25, 125, 50, 175, 75, 125, 60],
                  ['Series B', 50, 40, 20, 60, 50, 35, 50]
                ],
                colors: {
                    'Series A': '#16a085',
                    'Series B': '#DA4453'
                },
                type: 'bar',
                groups: [['Series A', 'Series B']]
            }
        });

        //Donut chart
        var chart7 = c3.generate({
            bindto: '#chart_7',
            data: {
                columns: [
                  ['Series A', 20],
                  ['Series B', 35],
                  ['Series C', 45]
                ],
                colors: {
                    'Series A': '#16a085',
                    'Series B': '#DA4453',
                    'Series C': '#f6b225'
                },
                type: 'donut'
            },
            donut: {
                title: 'Donut Chart'
            }
        });

        //Gauge chart
        var chart8 = c3.generate({
            bindto: '#chart_8',
            data: {
                columns: [
                  ['Series A', 92]
                ],
                colors: {
                    'Series A': '#16a085'
                },
                type: 'gauge'
            }
        });

        //Scatter plot chart
        var chart9 = c3.generate({
            bindto: '#chart_9',
            data: {
                xs: {
                    'Series A': 'series_a',
                    'Series B': 'series_b'
                },
                columns: [
                    ['series_a', 3.5, 3.0, 3.2, 3.1, 3.6, 3.9, 3.4, 3.4, 2.9, 3.1, 3.7, 3.4, 3.0, 3.0, 4.0, 4.4, 3.9, 3.5, 3.8, 3.8, 3.4, 3.7, 3.6, 3.3, 3.4, 3.0, 3.4, 3.5, 3.4, 3.2, 3.1, 3.4, 4.1, 4.2, 3.1, 3.2, 3.5, 3.6, 3.0, 3.4, 3.5, 2.3, 3.2, 3.5, 3.8, 3.0, 3.8, 3.2, 3.7, 3.3],
                    ['series_b', 3.2, 3.2, 3.1, 2.3, 2.8, 2.8, 3.3, 2.4, 2.9, 2.7, 2.0, 3.0, 2.2, 2.9, 2.9, 3.1, 3.0, 2.7, 2.2, 2.5, 3.2, 2.8, 2.5, 2.8, 2.9, 3.0, 2.8, 3.0, 2.9, 2.6, 2.4, 2.4, 2.7, 2.7, 3.0, 3.4, 3.1, 2.3, 3.0, 2.5, 2.6, 3.0, 2.6, 2.3, 2.7, 3.0, 2.9, 2.9, 2.5, 2.8],
                    ['Series A', 0.2, 0.2, 0.2, 0.2, 0.2, 0.4, 0.3, 0.2, 0.2, 0.1, 0.2, 0.2, 0.1, 0.1, 0.2, 0.4, 0.4, 0.3, 0.3, 0.3, 0.2, 0.4, 0.2, 0.5, 0.2, 0.2, 0.4, 0.2, 0.2, 0.2, 0.2, 0.4, 0.1, 0.2, 0.2, 0.2, 0.2, 0.1, 0.2, 0.2, 0.3, 0.3, 0.2, 0.6, 0.4, 0.3, 0.2, 0.2, 0.2, 0.2],
                    ['Series B', 1.4, 1.5, 1.5, 1.3, 1.5, 1.3, 1.6, 1.0, 1.3, 1.4, 1.0, 1.5, 1.0, 1.4, 1.3, 1.4, 1.5, 1.0, 1.5, 1.1, 1.8, 1.3, 1.5, 1.2, 1.3, 1.4, 1.4, 1.7, 1.5, 1.0, 1.1, 1.0, 1.2, 1.6, 1.5, 1.6, 1.5, 1.3, 1.3, 1.3, 1.2, 1.4, 1.2, 1.0, 1.3, 1.2, 1.3, 1.3, 1.1, 1.3]
                ],
                colors: {
                    'Series A': '#16a085',
                    'Series B': '#DA4453'
                },
                type: 'scatter'

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
