(function ($) {
    'use strict';
    $(function () {
        $('.dd').nestable();

        $('.dd').on('change', function () {
            var $this = $(this);
            var serializedData = window.JSON.stringify($($this).nestable('serialize'));

            $this.parents('div.panel-body').find('textarea').val(serializedData);
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
