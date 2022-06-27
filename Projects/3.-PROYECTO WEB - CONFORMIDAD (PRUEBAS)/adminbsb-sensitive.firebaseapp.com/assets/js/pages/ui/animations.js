(function ($) {
    'use strict';
    $(function () {
        $('.js-animations').on('change', function () {
            var animation = $(this).val();
            $('.js-animating-object').animateCss(animation);
        });
    });

    //Copied from https://github.com/daneden/animate.css
    $.fn.extend({
        animateCss: function (animationName) {
            var animationEnd = 'webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend';
            $(this).addClass('animated ' + animationName).one(animationEnd, function () {
                $(this).removeClass('animated ' + animationName);
            });
        }
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
}(jQuery))
