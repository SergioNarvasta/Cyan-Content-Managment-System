(function ($) {
    'use strict';
    $(function () {
        $('[name="password"]').on('propertychange change keyup paste input', function () {
            var $this = $(this).val();
            var paswScore = zxcvbn($this)['score'];

            var updateMeter = function (width, background, text) {
                $('.password-meter .meter').css({ 'width': 'calc(' + width + ' - 4px)', 'background-color': background });
                $('.strength-text').text('Strength: ' + text);
            }

            if (paswScore === 0) if ($this.length === 0) { updateMeter('0%', '#ffa0a0', 'None'); } else { updateMeter('20%', '#ffa0a0', 'Very Weak'); }
            if (paswScore === 1) updateMeter('40%', '#ffb78c', 'Weak');
            if (paswScore === 2) updateMeter('60%', '#ffec8b', 'Medium');
            if (paswScore === 3) updateMeter('80%', '#c3ff88', 'Strong');
            if (paswScore === 4) updateMeter('100%', '#ACE872', 'Very Strong');
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
