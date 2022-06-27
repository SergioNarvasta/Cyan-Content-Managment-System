(function ($) {
    'use strict';
    var data = [], totalPoints = 110;
    var updateInterval = 320;

    $(function () {
        initBarChart();
        initLineChart();
        initPieChart();
        initTrackingChart();
        initRealTimeChart();

        //Init real time chart
        function getRandomData() {
            if (data.length > 0) data = data.slice(1);

            while (data.length < totalPoints) {
                var prev = data.length > 0 ? data[data.length - 1] : 50, y = prev + Math.random() * 10 - 5;
                if (y < 0) { y = 0; } else if (y > 100) { y = 100; }

                data.push(y);
            }

            var res = [];
            for (var i = 0; i < data.length; ++i) {
                res.push([i, data[i]]);
            }

            return res;
        }

        function initRealTimeChart() {
            var plot = $.plot('#real_time_chart', [getRandomData()], {
                series: {
                    shadowSize: 0,
                    color: '#16a085'
                },
                grid: {
                    borderColor: '#f3f3f3',
                    borderWidth: 1,
                    tickColor: '#f3f3f3'
                },
                lines: {
                    fill: true
                },
                yaxis: {
                    min: 0,
                    max: 100
                },
                xaxis: {
                    min: 0,
                    max: 100
                }
            });

            function updateRealTime() {
                plot.setData([getRandomData()]);
                plot.draw();

                setTimeout(updateRealTime, updateInterval);
            }

            updateRealTime();
        }

        //Init bar chart
        function initBarChart() {
            var barChartData = [];
            for (var i = 0; i <= 10; i += 1) {
                barChartData.push([i, parseInt(Math.random() * 30)]);
            }

            $.plot('#bar_chart', [barChartData], {
                series: {
                    stack: 0,
                    lines: {
                        show: false,
                        fill: true,
                        steps: false
                    },
                    bars: {
                        show: true,
                        barWidth: 0.6
                    },
                    color: '#009688'
                },
                grid: {
                    hoverable: true,
                    autoHighlight: false,
                    borderColor: '#f3f3f3',
                    borderWidth: 1,
                    tickColor: '#f3f3f3'
                }
            });
        }

        //Init line chart
        function initLineChart() {
            var lineChartData = [];
            for (var i = 0; i <= 10; i += 1) {
                lineChartData.push([i, parseInt(Math.random() * 30)]);
            }

            $.plot('#line_chart', [lineChartData],
            {
                series: {
                    color: '#009688'
                },
                grid: {
                    hoverable: true,
                    autoHighlight: false,
                    borderColor: '#f3f3f3',
                    borderWidth: 1,
                    tickColor: '#f3f3f3'
                }
            });
        }

        //Init pie chart
        function initPieChart() {
            var pieChartData = [], pieChartSeries = 3;
            var pieChartColors = ['#DA4453', '#16a085', '#f6b225'];
            var pieChartDatas = [35, 40, 30];

            for (var i = 0; i < pieChartSeries; i++) {
                pieChartData[i] = {
                    label: 'Series - ' + (i + 1),
                    data: pieChartDatas[i],
                    color: pieChartColors[i]
                }
            }
            $.plot('#pie_chart', pieChartData, {
                series: {
                    pie: {
                        show: true,
                        radius: 1,
                        label: {
                            show: true,
                            radius: 3 / 4,
                            formatter: labelFormatter,
                            background: {
                                opacity: 0.5
                            }
                        }
                    }
                },
                legend: {
                    show: true
                }
            });
            function labelFormatter(label, series) {
                return '<div style="font-size:13px; text-align:center; color:white;">' + Math.round(series.percent) + '%</div>';
            }
        }

        //Init tracking chart
        function initTrackingChart() {
            var sin = [], cos = [];
            for (var i = 0; i < 14; i += 0.1) {
                sin.push([i, Math.sin(i)]);
                cos.push([i, Math.cos(i)]);
            }

            var trackingData = [
                {
                    data: sin,
                    label: 'sin(x) = -0.00',
                    color: '#DA4453'
                },
                {
                    data: cos,
                    label: 'cos(x) = -0.00',
                    color: '#16a085'
                }
            ];

            var trackingPlot = $.plot('#tracking_chart', trackingData, {
                crosshair: {
                    mode: 'x'
                },
                grid: {
                    hoverable: true,
                    autoHighlight: false,
                    borderColor: '#f3f3f3',
                    borderWidth: 1,
                    tickColor: '#f3f3f3'
                },
                yaxis: {
                    min: -1.2,
                    max: 1.2
                }
            });

            var legends = $('#tracking_chart .legendLabel');

            legends.each(function () {
                $(this).css('width', $(this).width());
            });

            var updateLegendTimeout = null;
            var latestPosition = null;

            function updateLegend() {
                updateLegendTimeout = null;
                var pos = latestPosition;

                var axes = trackingPlot.getAxes();
                if (pos.x < axes.xaxis.min || pos.x > axes.xaxis.max ||
                    pos.y < axes.yaxis.min || pos.y > axes.yaxis.max) {
                    return;
                }

                var i, j, dataset = trackingPlot.getData();
                for (i = 0; i < dataset.length; ++i) {
                    var series = dataset[i];

                    for (j = 0; j < series.data.length; ++j) {
                        if (series.data[j][0] > pos.x) {
                            break;
                        }
                    }

                    var y, p1 = series.data[j - 1], p2 = series.data[j];

                    if (p1 == null) {
                        y = p2[1];
                    } else if (p2 == null) {
                        y = p1[1];
                    } else {
                        y = p1[1] + (p2[1] - p1[1]) * (pos.x - p1[0]) / (p2[0] - p1[0]);
                    }

                    legends.eq(i).text(series.label.replace(/=.*/, '= ' + y.toFixed(2)));
                }
            }

            $('#tracking_chart').bind('plothover', function (event, pos, item) {
                latestPosition = pos;
                if (!updateLegendTimeout) {
                    updateLegendTimeout = setTimeout(updateLegend, 50);
                }
            });
        }

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
