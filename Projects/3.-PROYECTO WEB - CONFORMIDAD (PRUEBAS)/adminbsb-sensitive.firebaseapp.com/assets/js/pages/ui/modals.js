(function ($) {
    'use strict';
    $(function () {
        $('.js-modal-buttons .btn').on('click', function () {
            var colorType = $(this).data('color');
            var type = $(this).text();

            $('#coloredModal .modal-content').removeAttr('class').addClass('modal-content modal-col-' + colorType);
            $('#coloredModal .modal-header h4').text(type);
            $('#coloredModal').modal('show');
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
