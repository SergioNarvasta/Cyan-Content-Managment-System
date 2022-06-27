(function ($) {
    'use strict';
    $(function () {
        $('.js-basic-example').DataTable();

        //Exportable table
        $('.js-exportable').DataTable({
            responsive: true,
            dom: '<"html5buttons"B>lTfgtip',
            buttons: ['copy', 'csv', 'excel', 'pdf', 'print']
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
