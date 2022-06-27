(function ($) {
    'use strict';
    $(function () {
        initLineChart();
        initBarChart();
        initPieChart();
        initRadarChart();

        //Init line chart
        function initLineChart() {
            var config = {
                type: 'line',
                data: {
                    labels: ['2010', '2011', '2012', '2013', '2014', '2015', '2016'],
                    datasets: [{
                        label: "Series A",
                        data: [75, 69, 90, 80, 65, 75, 50],
                        borderColor: 'rgba(1, 192, 200, 0.75)',
                        backgroundColor: 'rgba(1, 192, 200, 0.3)',
                        pointBorderColor: 'rgba(1, 192, 200, 0)',
                        pointBackgroundColor: 'rgba(1, 192, 200, 0.9)',
                        pointBorderWidth: 1
                    }, {
                        label: "Series B",
                        data: [30, 50, 45, 25, 85, 30, 90],
                        borderColor: 'rgba(218, 68, 83, 0.75)',
                        backgroundColor: 'rgba(218, 68, 83, 0.3)',
                        pointBorderColor: 'rgba(218, 68, 83, 0)',
                        pointBackgroundColor: 'rgba(218, 68, 83, 0.9)',
                        pointBorderWidth: 1
                    }]
                },
                options: {
                    responsive: true
                }
            }
            var chart = new Chart(document.getElementById("line_chart").getContext("2d"), config);
        }

        //Init bar chart
        function initBarChart() {
            var config = {
                type: 'bar',
                data: {
                    labels: ['2010', '2011', '2012', '2013', '2014', '2015', '2016'],
                    datasets: [{
                        label: "Series A",
                        data: [75, 69, 90, 80, 65, 75, 50],
                        backgroundColor: 'rgb(1, 192, 200)'
                    }, {
                        label: "Series B",
                        data: [30, 50, 45, 25, 85, 30, 90],
                        backgroundColor: 'rgb(218, 68, 83)'
                    }]
                },
                options: {
                    responsive: true
                }
            }

            var chart = new Chart(document.getElementById("bar_chart").getContext("2d"), config);
        }

        //Init pie chart
        function initPieChart() {
            var config = {
                type: 'pie',
                data: {
                    datasets: [{
                        data: [182, 50, 100],
                        backgroundColor: ["#DA4453", "#f6b225", "#01C0C8"]
                    }],
                    labels: ["Series A", "Series B", "Series C"]
                },
                options: {
                    responsive: true
                }
            }

            var chart = new Chart(document.getElementById("pie_chart").getContext("2d"), config);
        }

        //Inir radar chart
        function initRadarChart() {
            var config = {
                type: 'radar',
                data: {
                    labels: ['2010', '2011', '2012', '2013', '2014', '2015', '2016'],
                    datasets: [{
                        label: "Series A",
                        data: [65, 48, 90, 81, 56, 55, 40],
                        borderColor: 'rgba(1, 192, 200, 0.8)',
                        backgroundColor: 'rgba(1, 192, 200, 0.5)',
                        pointBorderColor: 'rgba(1, 192, 200, 0)',
                        pointBackgroundColor: 'rgba(1, 192, 200, 0.8)',
                        pointBorderWidth: 1
                    }, {
                        label: "Series B",
                        data: [72, 48, 40, 62, 96, 27, 100],
                        borderColor: 'rgba(218, 68, 83, 0.8)',
                        backgroundColor: 'rgba(218, 68, 83, 0.5)',
                        pointBorderColor: 'rgba(218, 68, 83, 0)',
                        pointBackgroundColor: 'rgba(218, 68, 83, 0.8)',
                        pointBorderWidth: 1
                    }]
                },
                options: {
                    responsive: true
                }
            }

            var chart = new Chart(document.getElementById("radar_chart").getContext("2d"), config);
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
