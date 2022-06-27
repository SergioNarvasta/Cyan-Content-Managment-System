(function ($) {
    'use strict';
    $(function () {
        var types = {
            'default': {
                'icon': 'fa fa-folder fa-fw'
            },
            'html': {
                'icon': 'fa fa-file-code-o fa-fw'
            },
            'json': {
                'icon': 'fa fa-file-text-o fa-fw'
            },
            'css': {
                'icon': 'fa fa-file-code-o fa-fw'
            },
            'scss': {
                'icon': 'fa fa-file-code-o fa-fw'
            },
            'img': {
                'icon': 'fa fa-file-image-o fa-fw'
            },
            'js': {
                'icon': 'fa fa-file-text-o fa-fw'
            }
        };

        var $folder = $('.folder-list');

        $folder.on('open_node.jstree', function (e, data) {
            data.instance.set_icon(data.node, 'fa fa-folder-open fa-fw');
        });

        $folder.on('close_node.jstree', function (e, data) {
            data.instance.set_icon(data.node, 'fa fa-folder fa-fw');
        });

        $folder.jstree({
            'types': types,
            'plugins': ['types']
        });

        //iCheck Init
        var $fileManagerInput = $('.file-manager input');
        $fileManagerInput.iCheck({
            checkboxClass: 'icheckbox_square-green',
            radioClass: 'iradio_square-green',
            increaseArea: '20%' // optional
        });

        $fileManagerInput.on('ifToggled', function (event) {
            $(this).parents('.file-box').toggleClass('active');
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
