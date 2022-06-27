(function ($) {
    'use strict';
    $(document).ready(function () {
        //Textarea auto growth
        autosize($('.auto-growth'));

        //Init checkboxes and radios
        $('input[data-icheck-theme]').each(function (i, key) {
            var color = $(key).data('icheckColor');
            var theme = $(key).data('icheckTheme');
            var baseCheckboxClass = 'icheckbox_' + theme;
            var baseRadioClass = 'iradio_' + theme;

            $(key).iCheck({
                checkboxClass: color === theme ? baseCheckboxClass : baseCheckboxClass + '-' + color,
                radioClass: color === theme ? baseRadioClass : baseRadioClass + '-' + color
            });
        });

        //Init switch button
        var elems = Array.prototype.slice.call(document.querySelectorAll('.js-switch'));
        elems.forEach(function (e) {
            var size = $(e).data('size');
            var options = {};
            options['color'] = '#009688';
            if (size !== undefined) options['size'] = size;

            var switchery = new Switchery(e, options);
        });

        //Init datetimepicker
        $('.js-dtp').each(function (i, key) {
            var format = $(key).data('format');
            $(key).datetimepicker({
                format: format,
                showClear: true
            });
        });
    });
}(jQuery));