(function ($) {
    'use strict';
    $(document).ready(function () {
        //Chosen
        $('.chosen-select').chosen();

        //Init SummerNote
        $('#summernote').summernote({
            minHeight: 320
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