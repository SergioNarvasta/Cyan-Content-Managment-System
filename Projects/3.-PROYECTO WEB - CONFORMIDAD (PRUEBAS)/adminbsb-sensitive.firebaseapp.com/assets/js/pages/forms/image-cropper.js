(function ($) {
    'use strict';
    $(document).ready(function () {
        //Cropit Image
        var $cropitImg = $('.cropit-image-editor');
        $cropitImg.cropit({
            imageState: {
                src: '../../../assets/images/cropit-demo.jpg'
            }
        });

        $('.rotate-cw').click(function () {
            $('.cropit-image-editor').cropit('rotateCW');
        });

        $('.rotate-ccw').click(function () {
            $('.cropit-image-editor').cropit('rotateCCW');
        });

        $('.export').click(function () {
            var imageData = $cropitImg.cropit('export');
            window.open(imageData);
        });

        $('.select-new-image').click(function () {
            $('.cropit-image-input').click();
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