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

        //Basic Example
        var $basicExample = $('.js-basic-example');
        $basicExample.jstree({
            'plugins': ['search']
        });

        $('.js-searchbox-for-basic-example').on('keyup', function () {
            var val = $(this).val();

            $basicExample.jstree(true).search(val);
        });


        //With custom icon
        var $customIconExample = $('.js-custom-icon-example');

        $customIconExample.on('open_node.jstree', function (e, data) {
            data.instance.set_icon(data.node, 'fa fa-folder-open fa-fw');
        });

        $customIconExample.on('close_node.jstree', function (e, data) {
            data.instance.set_icon(data.node, 'fa fa-folder fa-fw');
        });

        $customIconExample.jstree({
            'core': {
                'check_callback': true
            },
            'plugins': ['types', 'search'],
            'types': types
        });

        $('.js-searchbox-for-custom-icon-example').on('keyup', function () {
            var val = $(this).val();

            $customIconExample.jstree(true).search(val);
        });

        //Context menu example
        var $contextMenuExample = $('.js-contextmenu-example');
        $contextMenuExample.on('open_node.jstree', function (e, data) {
            data.instance.set_icon(data.node, 'fa fa-folder-open fa-fw');
        });

        $contextMenuExample.on('close_node.jstree', function (e, data) {
            data.instance.set_icon(data.node, 'fa fa-folder fa-fw');
        });

        $contextMenuExample.jstree({
            'core': {
                'check_callback': true
            },
            'plugins': ['types', 'contextmenu'],
            'types': types
        });

        //Drag&Drop with context menu example
        var $dragDropExample = $('.js-drag-drop-example');
        $dragDropExample.on('open_node.jstree', function (e, data) {
            data.instance.set_icon(data.node, 'fa fa-folder-open fa-fw');
        });

        $dragDropExample.on('close_node.jstree', function (e, data) {
            data.instance.set_icon(data.node, 'fa fa-folder fa-fw');
        });

        $dragDropExample.jstree({
            'core': {
                'check_callback': true
            },
            'plugins': ['types', 'contextmenu', 'dnd'],
            'types': types
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
