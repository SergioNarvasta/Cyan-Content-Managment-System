(function ($) {
    'use strict';
    $(function () {
        //Init sparkline
        $('[data-sparkline="true"]')
            .each(function (i, key) {
                var type = $(key).data('type');
                var height = $(key).data('height');
                var barColor = $(key).data('barColor');

                height = height === undefined ? 24 : height;
                barColor = barColor === undefined ? '#d2d2d2' : barColor;

                $(key)
                    .sparkline('html',
                    {
                        type: type,
                        barColor: barColor,
                        height: height,
                        chartRangeMin: 0
                    });
            });

        //Init flot chart
        var flotChartDatas = [[[0, 21], [1, 12], [2, 27], [3, 12], [4, 16], [5, 20], [6, 15], [7, 12], [8, 35], [9, 20], [10, 10], [11, 18], [12, 12]], [[0, 3], [1, 9], [2, 15], [3, 9], [4, 16], [5, 8], [6, 15], [7, 12], [8, 19], [9, 14], [10, 10], [11, 16], [12, 10]]];
        var flotChartOptions = {
            series: {
                lines: {
                    show: false,
                    fill: true
                },
                points: {
                    show: false,
                    radius: 5,
                    width: 5
                },
                splines: {
                    show: true,
                    tension: 0.4,
                    lineWidth: 1,
                    fill: 0.3
                },
                shadowSize: 0
            },
            grid: {
                hoverable: true,
                clickable: true,
                tickColor: '#f0f0f0',
                borderWidth: 1,
                color: '#f0f0f0'
            },
            colors: ['#d0d0d0', '#1ab394'],
            yaxis: {
                ticks: 4
            }
        }

        setTimeout(initFlotChart, 550);
        function initFlotChart() {
            $.plot('#line_chart', flotChartDatas, flotChartOptions);
        }

        $('.js-toggle-left-sidebar').on('click', function () {
            setTimeout(initFlotChart, 500);
        });
        window.onresize = function (e) {
            initFlotChart();
        };

        //Init peity chart
        $("span.pie")
            .peity("pie",
            {
                fill: ['#009688', '#ddd']
            });

        //Exportable table
        $('.js-exportable').DataTable({
            responsive: true,
            dom: '<"html5buttons"B>lTfgtip',
            buttons: ['copy', 'csv', 'excel', 'pdf', 'print']
        });

        //To-Do List
        //Check or uncheck to-do item
        $('.todo-list').on('click', 'li', function (e) {
            if ($(e.target).closest('.controls, .move-handle').length === 0) {
                $(this).find('input').iCheck('toggle');
            }
        });

        //Init sortable
        $('.todo-list').sortable({
            handle: '.move-handle'
        });

        //Delete to-do item
        $('.todo-list').on('click', '.js-delete-todo', function () {
            $(this).parents('li').fadeOut(500, function () {
                $(this).remove();
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

        //Add item
        $('.js-btn-add-item').on('click', addToItem);
        $('.js-input').on('keyup', function (event) {
            var key = event.keyCode || event.which;
            if (key === 13) addToItem();
        });

        //Init iCheckbox
        setICheckbox();
        function setICheckbox() {
            $('input:not(.js-switch)').iCheck({
                checkboxClass: 'icheckbox_flat-green',
                radioClass: 'iradio_flat-green'
            });

            $('input:not(.js-switch)').on('ifToggled', function (e) {
                $(this).parents('li').toggleClass('closed');
            });
        }

        //Add to-do item to list
        function addToItem() {
            var $input = $('.js-input');
            var $toDoList = $('.todo-list');

            var item = $input.val();
            if (item !== '') {
                var newItemHtml = '<li>' +
                                  '   <a href="javascript:void(0);" title="Move"><i class="fa fa-arrows move-handle"></i></a>' +
                                  '   <input type="checkbox" />' +
                                  '   <span>' + item + '</span>' +
                                  '   <span class="controls pull-right">' +
                                  '       <a href="javascript:void(0);" title="Edit"><i class="fa fa-pencil"></i></a>' +
                                  '       <a href="javascript:void(0);" title="Delete"><i class="fa fa-trash js-delete-todo"></i></a>' +
                                  '   </span>' +
                                  '</li>';

                $toDoList.append(newItemHtml);
                $input.val('');
            }

            $input.focus();
            setICheckbox();
        }
    });
}(jQuery));
