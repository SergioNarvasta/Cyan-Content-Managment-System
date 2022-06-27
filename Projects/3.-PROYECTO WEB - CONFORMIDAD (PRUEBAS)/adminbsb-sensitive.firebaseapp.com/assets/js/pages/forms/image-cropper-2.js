(function ($) {
    'use strict';
    $(document).ready(function () {
        var $image = $('.image-crop-holder img');
        var options = {
            aspectRatio: 16 / 9,
            preview: '.img-preview'
        };

        $image.cropper(options);

        //When change aspect ratio
        $('.js-aspect-ratio input').on('change', function () {
            var vals = $(this).val().split('/');

            options['aspectRatio'] = parseInt(vals[0]) / parseInt(vals[1]);
            $image.cropper('destroy').cropper(options);
        });

        //When cropper command
        $('.js-cropper-command button').on('click', function () {
            var command = $(this).data('cropperCommand').split(':');
            $image.cropper(command[0], parseFloat(command[1]));
        });

        //Croppped image modal when opened
        $('#croppedImageModal').on('show.bs.modal', function (e) {
            var canvas = $image.cropper('getCroppedCanvas', { width: 320, height: 240 });

            $(this).find('.modal-body').html('');
            $(this).find('.modal-body').append(canvas);

            $(this).find('.modal-footer a').attr('href', canvas.toDataURL('image/jpeg'));
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