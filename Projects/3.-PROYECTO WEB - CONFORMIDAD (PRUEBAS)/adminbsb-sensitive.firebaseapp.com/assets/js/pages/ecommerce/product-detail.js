(function ($) {
    'use strict';
    $(function () {
        var $mainImageCarousel = $('.owl-carousel.main-image');
        var $thumbCarousel = $('.owl-carousel.thumbnails');

        $mainImageCarousel.owlCarousel({
            items: 1,
            dots: false,
            autoWidth: false,
            nav: true,
            navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
            onChanged: function (e) {
                var index = e.item.index;

                $thumbCarousel.trigger('to.owl.carousel', [index, 250]);
                $thumbCarousel.find('.owl-item').removeClass('img-active');
                $thumbCarousel.find('.owl-item:eq(' + index + ')').addClass('img-active');
            }
        });

        $thumbCarousel.owlCarousel({
            items: 4,
            dots: false,
            autoWidth: false,
            nav: true,
            navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
            onInitialized: function () {
                $thumbCarousel.find('.owl-item:eq(0)').addClass('img-active');
            }
        });

        $thumbCarousel.find('.owl-item img').on('click', function () {
            var index = $(this).parents('.owl-item').index();

            $mainImageCarousel.trigger('to.owl.carousel', [index, 250]);
            $thumbCarousel.find('.owl-item').removeClass('img-active');
            $thumbCarousel.find('.owl-item:eq(' + index + ')').addClass('img-active');
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
