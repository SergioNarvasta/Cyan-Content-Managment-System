(function ($) {
    'use strict';
    $(function () {
        var $body = $('body');
        var $settingBox = $('.setting-box');

        $body.on('change', '.setting-box .configuration-list-container ul li .switch input[type="checkbox"]', function () {
            var $this = $(this);
            var isChecked = $this.is(':checked');
            var $body = $('body');
            var dataClass = $this.data('class');
            var $boxedLayout = document.querySelector('.setting-box input[data-class="boxed-layout"]');

            if (dataClass === 'footer-fixed' && $boxedLayout.checked) {
                $boxedLayout.checked = false;
                if (typeof Event === 'function' || !document.fireEvent) {
                    var event = document.createEvent('HTMLEvents');
                    event.initEvent('change', true, true);
                    $boxedLayout.dispatchEvent(event);
                } else {
                    $boxedLayout.fireEvent('onchange');
                }
            }

            if (isChecked) { $body.addClass(dataClass); } else { $body.removeClass(dataClass); }
        });

        $body.on('click', '.setting-box .open-close-ear', function () {
            $(this).parent().toggleClass('open');
        });

        $body.on('click', '.setting-box .theme-choose-list-container ul li', function () {

            var theme = $(this).data('theme');

            $('.setting-box .theme-choose-list-container ul li').removeClass('active');
            $(this).addClass('active');

            $body.removeClass(function (index, className) {
                return (className.match(/(^|\s)theme-\S+/g) || []).join(' ');
            });

            if (theme !== undefined && theme !== 'default') {
                $body.addClass('theme-' + theme);
            }
        });

        initSettingToolbox();
        function initSettingToolbox() {
            var $settingBoxHtml =
                '<div class="setting-box">' +
                '        <div class="open-close-ear">' +
                '            <i class="material-icons fa-spin">settings</i>' +
                '        </div>' +
                '        <div class="label">SKINS</div>' +
                '        <div class="theme-choose-list-container">' +
                '            <ul>' +
                '                <li data-theme="default" class="active">' +
                '                    <div class="default"></div>' +
                '                    <span>Default</span>' +
                '                </li>' +
                '                <li data-theme="red">' +
                '                    <div class="red"></div>' +
                '                    <span>Red</span>' +
                '                </li>' +
                '                <li data-theme="warning">' +
                '                    <div class="warning"></div>' +
                '                    <span>Warning</span>' +
                '                </li>' +

                '                <li data-theme="blue">' +
                '                    <div class="blue"></div>' +
                '                    <span>Blue</span>' +
                '                </li>' +
                '                <li data-theme="purple">' +
                '                    <div class="purple"></div>' +
                '                    <span>Purple</span>' +
                '                </li>' +
                '            </ul>' +
                '        </div>' +
                '        <div class="label">CONFIGURATIONS</div>' +
                '        <div class="configuration-list-container">' +
                '            <ul>' +
                '                <li>' +
                '                    <span>Collapse Left Menu</span>' +
                '                    <div class="switch">' +
                '                        <input type="checkbox" class="js-switch" data-size="small" data-class="ls-toggled" />' +
                '                    </div>' +
                '                </li>' +
                '                <li>' +
                '                    <span>Fixed Sidebar</span>' +
                '                    <div class="switch">' +
                '                        <input type="checkbox" class="js-switch" data-size="small" data-class="ls-fixed" />' +
                '                    </div>' +
                '                </li>' +
                '                <li>' +
                '                    <span>Top Navbar</span>' +
                '                    <div class="switch">' +
                '                        <input type="checkbox" class="js-switch" data-size="small" data-class="navbar-fixed" />' +
                '                    </div>' +
                '                </li>' +
                '                <li>' +
                '                    <span>Boxed Layout</span>' +
                '                    <div class="switch">' +
                '                        <input type="checkbox" class="js-switch" data-size="small" data-class="boxed-layout" />' +
                '                    </div>' +
                '                </li>' +
                '                <li>' +
                '                    <span>Fixed Footer</span>' +
                '                    <div class="switch">' +
                '                        <input type="checkbox" class="js-switch" data-size="small" data-class="footer-fixed" />' +
                '                    </div>' +
                '                </li>' +
                '            </ul>' +
                '        </div>' +
                '    </div>';

            $body.append($settingBoxHtml);

            //Init switch buttons
            var $switchButtons = Array.prototype.slice.call(document.querySelectorAll('.setting-box .js-switch'));
            $switchButtons.forEach(function (e) {
                var size = $(e).data('size');
                var options = {};
                options['color'] = '#009688';
                if (size !== undefined) options['size'] = size;

                var switchery = new Switchery(e, options);
            });
        }
    });
}(jQuery));
