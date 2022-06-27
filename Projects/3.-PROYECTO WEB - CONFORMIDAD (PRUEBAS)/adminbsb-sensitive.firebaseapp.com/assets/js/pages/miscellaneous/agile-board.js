(function ($) {
    'use strict';
    $(function () {

        $('#todo, #doing, #done, #published')
            .sortable({
                connectWith: '.panel-body',
                placeholder: 'agile-card-placeholder',
                start: function (e, ui) {
                    $('.agile-card-placeholder').height($(ui.item[0]).height());
                },
                update: function (e, ui) {
                    getOutputVal();
                }
            }).disableSelection();

        getOutputVal();

        function getOutputVal() {
            var resultObject = {
                todo: $('#todo').sortable('toArray'),
                doing: $('#doing').sortable('toArray'),
                done: $('#done').sortable('toArray'),
                published: $('#published').sortable('toArray')
            }

            $('.js-output-json').text(JSON.stringify(resultObject));
        }

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
