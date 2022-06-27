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
        var data1 = [[0, 21], [1, 12], [2, 27], [3, 12], [4, 16], [5, 20], [6, 15], [7, 12], [8, 35], [9, 20], [10, 10], [11, 18], [12, 12]];
        var data2 = [[0, 3], [1, 9], [2, 15], [3, 9], [4, 16], [5, 8], [6, 15], [7, 12], [8, 19], [9, 14], [10, 10], [11, 16], [12, 10]];

        $.plot('#line_chart',
            [data1, data2],
            {
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
        );

        //Online Users - jvectorMap
        var onlineUsers = { 'TR': 1250, 'DE': 1120, 'RU': 1800, 'AR': 918, 'CA': 1122, 'US': 1624, 'HU': 242, 'VE': 125, 'AU': 417 };
        var $el = $('#world-map-markers');

        $el.vectorMap({
            map: 'world_mill_en',
            normalizeFunction: 'polynomial',
            hoverOpacity: 0.7,
            hoverColor: false,
            backgroundColor: 'transparent',
            regionStyle: {
                initial: {
                    'fill': 'rgba(210, 214, 222, 1)',
                    'fill-opacity': 1,
                    'stroke': 'none',
                    'stroke-width': 0,
                    'stroke-opacity': 1
                },
                hover: {
                    'fill-opacity': 0.7,
                    'cursor': 'pointer'
                },
                selected: {
                    'fill': 'yellow'
                },
                selectedHover: {}
            },
            series: {
                regions: [{
                    values: onlineUsers,
                    scale: ['#a7dad5', '#009688'],
                    normalizeFunction: 'polynomial'
                }]
            },
            onRegionTipShow: function (e, el, code) {
                if (onlineUsers[code] !== undefined) {
                    el.html(el.html() + ': ' + onlineUsers[code] + ' online users');
                }
            }
        });

        //Online user table
        $('.jvector-map + table').dataTable({
            sorting: [[2, 'desc']],
            pageLength: 5,
            lengthMenu: [[5, 10, 25, 50, -1], [5, 10, 25, 50, "All"]]
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

        //Add item
        $('.js-btn-add-item').on('click', addToItem);
        $('.js-input').on('keyup', function (event) {
            var key = event.keyCode || event.which;
            if (key === 13) addToItem();
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
