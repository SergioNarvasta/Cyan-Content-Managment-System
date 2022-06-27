(function ($) {
    'use strict';
    $(document).ready(function () {
        //Colorpicker
        $('.colorpicker-component').colorpicker();

        //Dropzone fileupload
        Dropzone.options.frmFileUpload = {
            paramName: "file",
            maxFilesize: 2
        };

        //Masked Input
        $('[data-inputmask]').inputmask();

        //Multi-select
        $('#optgroup').multiSelect({
            selectableOptgroup: true
        });

        //Bootstrap TagsInput
        $('.js-tagsinput')
            .tagsinput({
                tagClass: function (item) {
                    switch (item) {
                        case 'Tag-1':
                            return 'label label-primary';
                        case 'Tag-2':
                            return 'label label-danger';
                        case 'Tag-3':
                            return 'label label-success';
                        case 'Tag-4':
                            return 'label label-default';
                        case 'Tag-5':
                            return 'label label-warning';
                        case 'Tag-6':
                            return 'label label-info';
                    }

                    return 'label label-default';
                }
            });

        //Select 2
        $('.js-select2').select2();
        $('.js-select2-placeholder').select2({
            placeholder: 'Please select a car',
            allowClear: true
        });

        //Chosen
        $('.chosen-select').chosen();

        //DateRange Picker
        $('.js-daterange-picker').daterangepicker({
            startDate: "2017/08/06",
            endDate: "2017/09/30",
            drops: "up",
            applyClass: "btn-primary",
            locale: {
                format: 'YYYY/MM/DD'
            }
        });

        $('.js-daterange-picker-rangesoption').daterangepicker({
            ranges: {
                "Today": [
                    '2017/08/11', '2017/08/11'
                ],
                "Yesterday": [
                    '2017/08/10', '2017/08/10'
                ],
                "Last 7 Days": [
                    '2017/08/04', '2017/08/11'
                ],
                "Last 30 Days": [
                    '2017/07/11', '2017/08/11'
                ],
                "This Month": [
                    '2017/08/01', '2017/08/31'
                ],
                "Last Month": [
                    '2017/07/01', '2017/07/31'
                ]
            },
            showCustomRangeLabel: false,
            startDate: "2017/08/11",
            endDate: "2017/08/11",
            drops: "up",
            applyClass: "btn-primary",
            locale: {
                format: 'YYYY/MM/DD'
            }
        });

        $('.js-daterange-picker-rangesoption-2').daterangepicker({
            ranges: {
                "Today": [
                    '2017/08/11', '2017/08/11'
                ],
                "Yesterday": [
                    '2017/08/10', '2017/08/10'
                ],
                "Last 7 Days": [
                    '2017/08/04', '2017/08/11'
                ],
                "Last 30 Days": [
                    '2017/07/11', '2017/08/11'
                ],
                "This Month": [
                    '2017/08/01', '2017/08/31'
                ],
                "Last Month": [
                    '2017/07/01', '2017/07/31'
                ]
            },
            showCustomRangeLabel: false,
            alwaysShowCalendars: true,
            startDate: "2017/08/01",
            endDate: "2017/08/31",
            drops: "up",
            opens: "left",
            applyClass: "btn-primary",
            locale: {
                format: 'YYYY/MM/DD'
            }
        });

        //noUISlider
        noUiSlider.create(document.getElementById('ui_slider_1'), {
            start: 75,
            connect: [true, false],
            step: 1,
            tooltips: true,
            format: wNumb({
                decimals: 0
            }),
            range: {
                min: 0,
                max: 100
            }
        });        noUiSlider.create(document.getElementById('ui_slider_2'), {
            start: 52,
            connect: [true, false],
            step: 1,
            format: wNumb({
                decimals: 0
            }),
            range: {
                min: 0,
                max: 100
            }
        });
        noUiSlider.create(document.getElementById('ui_slider_3'),
        {
            start: [15, 75],
            connect: true,
            behaviour: 'drag',
            tooltips: [true, wNumb({ decimals: 2 })],
            range: {
                min: 0,
                max: 100
            }
        });

        noUiSlider.create(document.getElementById('ui_slider_4'),
        {
            start: [15, 75],
            connect: true,
            behaviour: 'drag-fixed',
            tooltips: [true, wNumb({ decimals: 2 })],
            range: {
                min: 0,
                max: 100
            }
        });

        noUiSlider.create(document.getElementById('ui_slider_5'),
        {
            start: 75,
            orientation: 'vertical',
            connect: [true, false],
            direction: 'rtl',
            tooltips: true,
            range: {
                min: 0,
                max: 100
            },
            format: wNumb({
                decimals: 0
            })
        });

        //Ion Range Slider
        $('#range_01').ionRangeSlider({
            from: 75,
            grid: true
        });

        $('#range_02').ionRangeSlider({
            type: 'double',
            grid: true,
            min: 0,
            max: 2000,
            from: 250,
            to: 1750,
            prefix: '$'
        });

        $('#range_03').ionRangeSlider({
            grid: true,
            from: 4,
            values: ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday']
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