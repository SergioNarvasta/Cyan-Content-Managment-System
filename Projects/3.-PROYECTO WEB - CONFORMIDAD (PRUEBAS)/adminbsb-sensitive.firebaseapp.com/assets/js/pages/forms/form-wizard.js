(function ($) {
    'use strict';
    $(document).ready(function () {
        //Basic - Horizontal
        $('#wizard_horizontal').steps({
            headerTag: 'h2',
            bodyTag: 'div',
            transitionEffect: 'fade'
        });

        //Basic - Vertical
        $('#wizard_vertical').steps({
            headerTag: 'h2',
            bodyTag: 'div',
            transitionEffect: 'fade',
            stepsOrientation: 'vertical'
        });

        //Advanced form with validation
        var form = $('#wizard_with_validation').show();
        form.steps({
            headerTag: 'h3',
            bodyTag: 'fieldset',
            transitionEffect: 'fade',
            onInit: function (event, currentIndex) {
                //Set tab width
                var $tab = $(event.currentTarget).find('ul[role="tablist"] li');
                var tabCount = $tab.length;
                $tab.css('width', (100 / tabCount) + '%');
            },
            onStepChanging: function (event, currentIndex, newIndex) {
                if (currentIndex > newIndex) { return true; }

                if (currentIndex < newIndex) {
                    form.find('.body:eq(' + newIndex + ') label.error').remove();
                    form.find('.body:eq(' + newIndex + ') .error').removeClass('error');
                }

                form.validate().settings.ignore = ':disabled,:hidden';
                return form.valid();
            },
            onFinishing: function (event, currentIndex) {
                form.validate().settings.ignore = ':disabled';
                return form.valid();
            },
            onFinished: function (event, currentIndex) {
                alert('Good Job!\nSubmitted!');
            }
        });

        form.validate({
            highlight: function (element) {
                $(element).closest('.form-group').addClass('has-error');
            },
            unhighlight: function (element) {
                $(element).closest('.form-group').removeClass('has-error');
            },
            errorPlacement: function (error, element) {
                $(element).parents('.form-group').append(error);
            },
            rules: {
                'confirm': {
                    equalTo: '#password'
                }
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
    });
}(jQuery));