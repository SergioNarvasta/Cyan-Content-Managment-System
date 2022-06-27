(function ($) {
    'use strict';
    $(function () {
        var owlCarousel = $('.owl-carousel')
            .owlCarousel({
                dots: true,
                items: 4,
                nav: true,
                navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>']
            });

        $.each(owlCarousel,
            function (i, key) {
                if ($(key).hasClass('styleThree')) {
                    var title = $(key).data('title');
                    if (title !== '') {
                        var $div = $('<div>').addClass('owl-carousel-title');
                        var $h3 = $('<h3>').text(title);
                        $div.append($h3);

                        $(key).append($div);
                    }
                }
            });
    });
}(jQuery))
