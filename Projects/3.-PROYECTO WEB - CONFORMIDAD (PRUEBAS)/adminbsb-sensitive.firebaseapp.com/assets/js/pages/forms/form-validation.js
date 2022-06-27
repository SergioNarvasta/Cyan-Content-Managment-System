(function ($) {
    'use strict';
    $(document).ready(function () {
        //Init checkboxes
        $('input[type="checkbox"],input[type="radio"]').iCheck({
            checkboxClass: 'icheckbox_square-green',
            radioClass: 'iradio_square-green'
        });

        //Form validations
        $('#form_basic_validation').validate({
            rules: {
                'gender': {
                    required: true
                }
            },
            highlight: function (element) {
                $(element).closest('.form-group').addClass('has-error');
            },
            unhighlight: function (element) {
                $(element).closest('.form-group').removeClass('has-error');
            },
            errorPlacement: function (error, element) {
                try {
                    var isCheckboxOrRadio = $(element).attr('type') !== undefined && ($(element).attr('type').toLowerCase() === 'checkbox' || $(element).attr('type').toLowerCase() === 'radio');

                    if (isCheckboxOrRadio) {
                        element.parents('.form-group').append(error);
                    } else {
                        element.after(error);
                    }
                } catch (e) { }
            }
        });

        $('#form_advanced_validation').validate({
            rules: {
                'date': {
                    customdate: true
                },
                'creditcard': {
                    creditcard: true
                }
            },
            highlight: function (element) {
                $(element).closest('.form-group').addClass('has-error');
            },
            unhighlight: function (element) {
                $(element).closest('.form-group').removeClass('has-error');
            },
            errorPlacement: function (error, element) {
                try {
                    var isCheckboxOrRadio = $(element).attr('type') !== undefined && ($(element).attr('type').toLowerCase() === 'checkbox' || $(element).attr('type').toLowerCase() === 'radio');

                    if (isCheckboxOrRadio) {
                        element.parents('.form-group').append(error);
                    } else {
                        element.after(error);
                    }
                } catch (e) { }
            }
        });

        //Custom Validations ===============================================================================
        //Date
        $.validator.addMethod('customdate', function (value, element) {
            return value.match(/^\d\d\d\d?-\d\d?-\d\d$/);
        },
            'Please enter a date in the format YYYY-MM-DD.'
        );

        //Credit card
        $.validator.addMethod('creditcard', function (value, element) {
            return value.match(/^\d\d\d\d?-\d\d\d\d?-\d\d\d\d?-\d\d\d\d$/);
        },
            'Please enter a credit card in the format XXXX-XXXX-XXXX-XXXX.'
        );
        //==================================================================================================

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