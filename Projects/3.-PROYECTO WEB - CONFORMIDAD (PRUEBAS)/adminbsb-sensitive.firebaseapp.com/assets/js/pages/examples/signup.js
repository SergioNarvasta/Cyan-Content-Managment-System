(function ($) {
    'use strict';
    $(function () {
        setContentHeight(true);
        $(window).resize(function () {
            setContentHeight(false);
        });

        //iCheck init
        $('input[type="checkbox"]').iCheck({
            checkboxClass: 'icheckbox_square-green',
            radioClass: 'iradio_square-green'
        });

        //Jquery validation
        $('#frmSignup').validate({
            rules: {
                'Terms': {
                    required: true
                },
                'ConfirmPassword': {
                    equalTo: '#Password'
                }
            },
            highlight: function (element) {
                $(element).closest('.form-group').addClass('has-error');
            },
            unhighlight: function (element) {
                $(element).closest('.form-group').removeClass('has-error');
            },
            errorPlacement: function (error, element) {
                element.parents('.form-group').append(error);
            }
        });

        //Tooltip Init
        $('[data-toggle="tooltip"]').tooltip();

        function setContentHeight(firstLoad) {
            var winHeight = $(window).height();
            $('.sign-up-bg').height(winHeight);

            if (firstLoad) $('.signup-links').removeClass('hide');
        }

    });
}(jQuery))
