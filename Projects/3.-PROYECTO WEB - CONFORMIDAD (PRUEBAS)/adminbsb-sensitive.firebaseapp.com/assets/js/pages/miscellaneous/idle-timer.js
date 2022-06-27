(function ($) {
    'use strict';
    $(function () {
        // Set idle time
        $(document).idleTimer(6000);

        $(document).on("idle.idleTimer", function (event, elem, obj) {
            $('.alert-danger').removeClass('hide');
            $('.alert-success').addClass('hide');
        });

        $(document).on("active.idleTimer", function (event, elem, obj, triggerevent) {
            $('.alert-danger').addClass('hide');
            $('.alert-success').removeClass('hide');
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
