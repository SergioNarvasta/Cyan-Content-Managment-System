(function ($) {
    'use strict';
    $(function () {
        //iCheck init
        $('input[type="checkbox"]').iCheck({
            checkboxClass: 'icheckbox_square-green',
            radioClass: 'iradio_square-green'
        });

        //Jquery validation
        $('#frmSignin').validate({
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
    });
}(jQuery))
