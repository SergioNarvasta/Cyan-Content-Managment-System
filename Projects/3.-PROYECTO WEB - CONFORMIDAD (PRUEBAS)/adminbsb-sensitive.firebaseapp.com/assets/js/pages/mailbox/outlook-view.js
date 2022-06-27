(function ($) {
    'use strict';
    $(function () {

        setUserListHeight(function (height) {
            setUserListScroll(height);
        });
        setMailDetailHeight(function (height) {
            setMailDetailScroll(height);
        });

        $(window).resize(function () {
            setUserListHeight(function (height) {
                setUserListScroll(height);
            });
            setMailDetailHeight(function (height) {
                setMailDetailScroll(height);
            });
        });


        function setUserListHeight(callback) {
            var height = $(window).height() - ($('.navbar').innerHeight() + $('.content .page-heading').innerHeight() + 40);
            $('.from-list').height(height);

            callback(height);
        }

        function setMailDetailHeight(callback) {
            var height = $(window).height() - ($('.navbar').innerHeight() + $('.content .page-heading').innerHeight() + $('.sender-info').innerHeight() + 72);
            $('.mail-detail .mail').height(height);

            callback(height);
        }

        function setUserListScroll(height) {
            $('.from-list').slimScroll({
                height: height
            });
        }

        function setMailDetailScroll(height) {
            $('.mail-detail .mail').slimScroll({
                height: height
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
}(jQuery));
