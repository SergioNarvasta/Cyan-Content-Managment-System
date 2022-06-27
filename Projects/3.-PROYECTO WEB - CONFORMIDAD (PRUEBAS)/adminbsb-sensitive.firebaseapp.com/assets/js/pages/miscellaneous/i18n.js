(function ($) {
    'use strict';
    $(function () {

        //Init localization
        i18n.init({
            lng: "en",
            fallbackLng: "en",
            resGetPath: '/assets/locales/__lng__/__ns__.json',
            resPostPath: '/assets/locales/add/__lng__/__ns__'
        }, function (err, t) {
            $('.panel').i18n();
        });

        //Change language
        $('.js-language input').on('change', function () {
            var val = $(this).val();
            i18n.setLng(val, function () {
                $('.panel').i18n();
            });
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
