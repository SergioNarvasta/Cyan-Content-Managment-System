(function ($) {
    'use strict';
    $(function () {
        $('.table').on({
            "expand.ft.row": function (e, ft, row) {
                setTimeout(function () {
                    $(row.$el[0]).next().find('table').removeAttr('class').addClass('footable-details');
                }, 10);
            },
            "postdraw.ft.table": function (e, ft) {
                $(ft.$el[0]).find('.footable-filtering-search .btn').removeClass('btn-primary');
            }
        }).footable();

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
