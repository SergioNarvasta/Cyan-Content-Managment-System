(function ($) {
    'use strict';
    $(function () {
        setDashboardHeight(function () {
            setUserListScroll();
            setMessageScroll();
        });

        $(window).resize(function () {
            setDashboardHeight(function () {
                setUserListScroll();
                setMessageScroll();
            });
        });

        //Set dashboard height
        function setDashboardHeight(callback) {
            var height = $(window).height() - ($('.navbar').innerHeight() + $('.content .page-heading').innerHeight() + 40);
            $('.chat-dashboard').height(height);

            callback();
        }

        //Set user list scroll
        function setUserListScroll() {
            var height = $('.chat-dashboard').height() - ($('.search-holder').innerHeight() + $('.user-panel .heading').innerHeight() + 2);
            $('.user-list').slimScroll({
                height: height
            });
        }

        //Set message scroll
        function setMessageScroll() {
            var height = $('.chat-dashboard').height() - ($('.message-area .heading').innerHeight() + $('.message-area .footer').innerHeight() + 2);
            $('.message-area .body:eq(0)').slimScroll({
                height: height
            });
        }

        //User detail open/close
        $('.message-area .heading .avatar-info, .user-detail .heading a').on('click', function () {
            $('.user-detail').toggleClass('open');
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
