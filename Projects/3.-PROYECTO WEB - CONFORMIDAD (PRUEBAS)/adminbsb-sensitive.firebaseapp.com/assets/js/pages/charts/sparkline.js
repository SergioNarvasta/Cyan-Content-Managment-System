(function ($) {
    'use strict';
    $(function () {
        //Chart examples
        $('.sparkline').each(function () {
            var $this = $(this);
            var type = $this.data('type');

            if (type === 'pie') {
                $this.sparkline('html',
                {
                    type: type,
                    sliceColors: ['#16a085', '#DA4453', '#f6b225'],
                    height: 150
                });
            } else if (type === 'line') {
                $this.sparkline('html',
                {
                    type: type,
                    height: 150,
                    width: '100%',
                    highlightSpotColor: 'rgb(0, 150, 136)',
                    highlightLineColor: 'rgb(0, 150, 136)',
                    minSpotColor: 'rgb(0, 150, 136)',
                    maxSpotColor: 'rgb(0, 150, 136)',
                    spotColor: 'rgb(0, 150, 136)',
                    lineColor: 'rgb(0, 150, 136)',
                    fillColor: 'rgba(0, 150, 136, 0.32)'
                });
            } else if (type === 'bar') {
                $this.sparkline('html',
                {
                    type: type,
                    barColor: 'rgb(0, 150, 136)',
                    height: 150,
                    barWidth: 16,
                    barSpacing: 7
                });
            }
        });

        //Inline chart examples
        $('.inline-sparkline').each(function () {
            var $this = $(this);
            var type = $this.data('type');

            if (type === 'pie') {
                $this.sparkline('html',
                {
                    type: type,
                    sliceColors: ['#16a085', '#DA4453', '#f6b225'],
                    height: 18
                });
            } else if (type === 'line') {
                $this.sparkline('html',
                {
                    type: type,
                    height: 18,
                    highlightSpotColor: 'rgb(0, 150, 136)',
                    highlightLineColor: 'rgb(0, 150, 136)',
                    minSpotColor: 'rgb(0, 150, 136)',
                    maxSpotColor: 'rgb(0, 150, 136)',
                    spotColor: 'rgb(0, 150, 136)',
                    lineColor: 'rgb(0, 150, 136)',
                    fillColor: 'rgba(0, 150, 136, 0.32)'
                });
            } else if (type === 'bar') {
                $this.sparkline('html',
                {
                    type: type,
                    barColor: 'rgb(0, 150, 136)',
                    height: 18
                });
            } else if (type === 'discrete') {
                $this.sparkline('html',
                {
                    type: type,
                    lineColor: 'rgb(0, 150, 136)',
                    height: 18
                });
            } else if (type === 'tristate') {
                $this.sparkline('html',
                {
                    type: type,
                    posBarColor: 'rgb(0, 150, 136)',
                    negBarColor: '#DA4453',
                    zeroBarColor: '#f6b225',
                    height: 18
                });
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
