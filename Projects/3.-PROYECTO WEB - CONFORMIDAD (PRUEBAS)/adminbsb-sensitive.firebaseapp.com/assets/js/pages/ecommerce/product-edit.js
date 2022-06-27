(function ($) {
    'use strict';
    $(function () {
        CKEDITOR.replace('product_description');
        CKEDITOR.replace('product_features');

        //Radio button init
        $('.table input').iCheck({
            checkboxClass: 'icheckbox_square-red',
            radioClass: 'iradio_square-red'
        });

        //Init tags input
        $('.js-tagsinput').tagsinput();

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
