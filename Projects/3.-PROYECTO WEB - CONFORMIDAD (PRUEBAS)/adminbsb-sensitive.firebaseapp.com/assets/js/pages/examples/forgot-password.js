(function ($) {
    'use strict';
    $(function () {
        //Jquery validation
        $('#frmForgotPassword').validate({
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
    });
}(jQuery))
