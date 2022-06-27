(function ($) {
    'use strict';
    $(function () {
        //Basic Example
        $('.example-one').prettyTextDiff({
            originalContent: $('.example-one .original').text(),
            changedContent: $('.example-one .changed').text(),
            diffContainer: '.diff1'
        });

        //Editable Example & Function
        initEditableTextDiff();
        $('.example-two textarea').on('keyup', initEditableTextDiff);
        function initEditableTextDiff() {
            $('.example-two').prettyTextDiff({
                originalContent: $('.example-two .original').val(),
                changedContent: $('.example-two .changed').val(),
                diffContainer: '.diff2'
            });
        }

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
