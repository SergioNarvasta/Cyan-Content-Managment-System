(function ($) {
    'use strict';
    $(function () {
        var tour = new Tour({
            steps: [
                {
                    element: '.page-body .panel',
                    title: 'Panel',
                    content:
                        'Lorem ipsum dolor sit amet, mel id minimum maluisset. Ius ea feugiat officiis eleifend, ut duis dicant possim his, dolor theophrastus delicatissimi et pri.',
                    placement: 'bottom',
                    backdrop: true
                },
                {
                    element: 'section .page-heading',
                    title: 'Main Title',
                    content:
                        'Lorem ipsum dolor sit amet, mel id minimum maluisset. Ius ea feugiat officiis eleifend, ut duis dicant possim his, dolor theophrastus delicatissimi et pri.',
                    placement: 'bottom',
                    backdrop: true
                },
                {
                    element: 'header',
                    title: 'Top Bar/Menu',
                    content:
                        'Lorem ipsum dolor sit amet, mel id minimum maluisset. Ius ea feugiat officiis eleifend, ut duis dicant possim his, dolor theophrastus delicatissimi et pri.',
                    placement: 'bottom',
                    backdrop: true
                }
            ]
        });

        tour.init();

        //Start Bootstrap Tour - Button Click Event
        $('.js-start-tour').on('click', function () {
            tour.restart();
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
}(jQuery))
