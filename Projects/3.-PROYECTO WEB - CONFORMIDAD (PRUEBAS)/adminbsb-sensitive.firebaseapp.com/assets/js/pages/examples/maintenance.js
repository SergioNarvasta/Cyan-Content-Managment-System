(function ($) {
    'use strict';
    $(function () {

        $('body').countdown({
            date: 'December  08, 2024 00:00:00',
            render: function (data) {
                var days = this.leadingZeros(data.days, 3);
                var hours = this.leadingZeros(data.hours, 2);
                var mins = this.leadingZeros(data.min, 2);
                var sec = this.leadingZeros(data.sec, 2);

                $('.days').text(days);
                $('.hours').text(hours);
                $('.min').text(mins);
                $('.sec').text(sec);
            }
        });

        //Init tooltip
        $('[data-toggle="tooltip"]').tooltip();
    });
}(jQuery))
