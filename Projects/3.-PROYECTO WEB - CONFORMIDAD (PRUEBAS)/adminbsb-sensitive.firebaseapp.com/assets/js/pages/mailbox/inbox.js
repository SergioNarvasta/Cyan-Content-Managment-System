(function ($) {
    'use strict';
    $(document).ready(function () {

        $('input').iCheck({
            checkboxClass: 'icheckbox_flat-green',
            radioClass: 'iradio_flat-green',
            increaseArea: '20%'
        });

        //Important status click event
        $('.js-btn-email-star').on('click', function () {
            $(this).find('.fa').toggleClass('important');
        });

        //Checked changed
        $('input').on('ifChanged', function (event) {
            var $tr = $(this).parents('tr');

            if ($(this).is(':checked')) {
                $tr.addClass('selected');
            } else {
                $tr.removeClass('selected');
            }
        });

        //Select/Deselect All
        $('.js-selectall').on('ifChanged', function () {
            $(this)
                .parents('.email-panel')
                .find('.email-panel-body input[type="checkbox"]')
                .iCheck($(this).is(':checked') ? 'check' : 'uncheck');
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