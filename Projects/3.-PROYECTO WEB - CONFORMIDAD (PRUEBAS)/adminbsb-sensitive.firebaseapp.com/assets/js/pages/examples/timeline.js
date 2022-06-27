(function ($) {
    'use strict';
    $(function () {
        $('.js-version input').on('change', function () {
            var val = $(this).val();

            if (val === 'left-ver') {
                $('.timeline').addClass('timeline-left-version');
            } else {
                $('.timeline').removeClass('timeline-left-version');
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
}(jQuery))
