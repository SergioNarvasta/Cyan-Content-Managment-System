(function ($) {
    'use strict';
    $(function () {

        $('#draggable').sortable({
            handle: '.panel .panel-heading'
        });
        $('#draggable').disableSelection();

    });
}(jQuery))
