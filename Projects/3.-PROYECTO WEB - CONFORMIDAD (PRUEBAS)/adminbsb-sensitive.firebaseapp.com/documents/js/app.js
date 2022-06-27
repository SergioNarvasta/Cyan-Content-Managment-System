(function ($) {
    'use strict';
    $.AdminBSB = {};
    $.AdminBSB.options = {
        leftSideBar: {
            scrollColor: 'rgba(0,0,0,0.32)',
            scrollWidth: '5px',
            scrollAlwaysVisible: false,
            scrollBorderRadius: '8px',
            scrollRailBorderRadius: '8px'
        },
        rightSideBar: {
            scrollColor: 'rgba(0,0,0,0.32)',
            scrollWidth: '5px',
            scrollAlwaysVisible: false,
            scrollBorderRadius: '8px',
            scrollRailBorderRadius: '8px'
        },
        dropdownMenu: {
            effectIn: 'fadeIn',
            effectOut: 'fadeOut'
        },
        navbar: {
            toggleClass: 'ls-toggled'
        },
        panel: {
            iconClass: {
                close: 'fa fa-close',
                fullscreenOn: 'fa fa-expand',
                fullscreenOff: 'fa fa-compress',
                collapse: 'fa fa-chevron-up',
                expand: 'fa fa-chevron-down'
            },
            tooltip: {
                show: true,
                closeText: 'Close',
                fullscreenOnOffText: 'Toggle Fullscreen',
                collapseExpandText: 'Collapse/Expand',
                closePlacement: 'bottom',
                fullscreenPlacement: 'bottom',
                collapsePlacement: 'bottom'
            },
            controls: {
                collapsable: true,
                fullscreen: true,
                close: true
            }
        }
    }

    $.AdminBSB.panel = {
        init: function () {
            var $this = this;

            $this.initIcons();
        },
        initIcons: function () {
            var $this = this;
            var configs = $.AdminBSB.options.panel;

            $('.panel')
                .each(function (i, key) {
                    if (!$(key).parent().hasClass('panel-group')) {
                        var dataAttrs = $(key).data();
                        var $panelControls = $('<div>').addClass('panel-controls');
                        if ($(key).find('.panel-controls').length > 0) $panelControls = $(key).find('.panel-controls');

                        //Collapsable Icon
                        if (dataAttrs["panelCollapsable"] != undefined) {
                            if (dataAttrs["panelCollapsable"]) $panelControls.append($this.collapsableIcon());
                        } else {
                            if (configs.controls.collapsable) $panelControls.append($this.collapsableIcon());
                        }

                        //Fullscreen Icon
                        if (dataAttrs["panelFullscreen"] != undefined) {
                            if (dataAttrs["panelFullscreen"]) $panelControls.append($this.fullscreenIcon());
                        } else {
                            if (configs.controls.fullscreen) $panelControls.append($this.fullscreenIcon());
                        }

                        //Close Icon
                        if (dataAttrs["panelClose"] != undefined) {
                            if (dataAttrs["panelClose"]) $panelControls.append($this.closeIcon());
                        } else {
                            if (configs.controls.close) $panelControls.append($this.closeIcon());
                        }

                        //Add to panel heading
                        $($(key).find('.panel-heading')[0]).append($panelControls);
                    }
                });

            setTimeout(function () {
                $('[data-toggle="tooltip"]').tooltip();
                $this.closeEvent();
                $this.collapseEvent();
                $this.fullScreenEvent();
            },
                120);
        },
        closeIcon: function () {
            var configs = $.AdminBSB.options.panel;
            var $anchor = $('<a>')
                .attr('href', 'javascript:void(0);')
                .addClass('panel-close');

            //Check tooltip active/passive
            if (configs.tooltip.show) {
                $anchor.attr({
                    'data-toggle': 'tooltip',
                    'data-title': configs.tooltip.closeText,
                    'data-placement': configs.tooltip.closePlacement
                });
            }

            var $i = $('<i>').addClass(configs.iconClass.close);
            return $anchor.append($i);
        },
        collapsableIcon: function () {
            var configs = $.AdminBSB.options.panel;
            var $anchor = $('<a>')
                .attr('href', 'javascript:void(0);')
                .addClass('panel-collapsable');

            //Check tooltip active/passive
            if (configs.tooltip.show) {
                $anchor.attr({
                    'data-toggle': 'tooltip',
                    'data-title': configs.tooltip.collapseExpandText,
                    'data-placement': configs.tooltip.collapsePlacement
                });
            }

            var $i = $('<i>').addClass(configs.iconClass.collapse);
            return $anchor.append($i);
        },
        fullscreenIcon: function () {
            var configs = $.AdminBSB.options.panel;
            var $anchor = $('<a>')
                .attr('href', 'javascript:void(0);')
                .addClass('panel-fullscreen');

            //Check tooltip active/passive
            if (configs.tooltip.show) {
                $anchor.attr({
                    'data-toggle': 'tooltip',
                    'data-title': configs.tooltip.fullscreenOnOffText,
                    'data-placement': configs.tooltip.fullscreenPlacement
                });
            }

            var $i = $('<i>').addClass(configs.iconClass.fullscreenOn);
            return $anchor.append($i);
        },
        closeEvent: function () {
            $('.panel')
                .on('click',
                    'a.panel-close',
                    function () {
                        $(this)
                            .parents('.panel')
                            .fadeOut(function () {
                                $(this).remove();
                                $(this).tooltip('hide');
                            });
                    });
        },
        collapseEvent: function () {
            var configs = $.AdminBSB.options.panel;

            $('.panel')
                .on('click',
                    'a.panel-collapsable',
                    function () {
                        var $icon = $(this).find('i');
                        var iconClass = $icon.hasClass(configs.iconClass.collapse)
                            ? configs.iconClass.expand
                            : configs.iconClass.collapse;

                        $icon.removeAttr('class').addClass(iconClass);
                        $icon.parents('.panel').toggleClass('panel-collapsed');
                        $icon.parents('.panel').find('.panel-body').slideToggle();
                        $(this).tooltip('hide');
                    });
        },
        fullScreenEvent: function () {
            var configs = $.AdminBSB.options.panel;

            $('.panel')
                .on('click',
                    'a.panel-fullscreen',
                    function () {
                        var $icon = $(this).find('i');
                        var iconClass = $icon.hasClass(configs.iconClass.fullscreenOn)
                            ? configs.iconClass.fullscreenOff
                            : configs.iconClass.fullscreenOn;

                        $icon.removeAttr('class').addClass(iconClass);
                        $icon.parents('.panel').toggleClass('panel-fullscreen');
                        $(this).tooltip('hide');
                    });
        }
    }

    $.AdminBSB.leftSideBar = {
        init: function () {
            var $this = this;
            var $menu = $('.metismenu'), $body = $('body');

            //Init menu
            $menu.metisMenu();

            $this.setMenuWhenFixedAndToggled();

            $(window).bind('load resize', function () {
                $this.setVerticalScrollBar();
                $this.setMenuOnlyFixedSidebar();
                $this.setMenuNonFixed();
                $this.setMenuFixedButNavbarNonFixed();
                $this.changeHiddenStatu();
            });

            $(window).bind('scroll', function () {
                $this.setMenuOnlyFixedSidebar();
                $this.setMenuNonFixed();
                $this.setMenuFixedButNavbarNonFixed();
            });
        },
        fadeEffect: function () {
            var $menu = $('.metismenu');
            $menu.hide();
            setTimeout(function () {
                $menu.fadeIn();
            },
                400);
        },
        setMenuWhenFixedAndToggled: function () {
            var $this = this;
            var $menu = $('.metismenu');
            var $body = $('body');

            if ($this.isFixed() && $this.isToggled()) {
                $menu.hover(function () {
                    //$this.fadeEffect();
                    $body.removeClass('ls-toggled');
                }, function () {
                    //$this.fadeEffect();
                    $body.addClass('ls-toggled');
                });
            } else {
                $menu.unbind('mouseenter mouseleave');
            }
        },
        setSubMenuHeight: function () {
            $('.metismenu')
                .find('li')
                .has('ul')
                .children('a')
                .on('click',
                    function () {
                        var $this = $(this);
                        var heightVal = $(window).height() - $this.offset().top;
                        $this.next()
                            .css({
                                'max-height': heightVal,
                                'overflow-y': 'hidden'
                            });
                        setTimeout(function () { $this.next().css('overflow-y', 'auto') }, 400);
                    });
        },
        setVerticalScrollBar: function () {
            var $this = this;

            if ($this.isFixed()) {
                var $menu = $('.metismenu');
                var height = $.AdminBSB.navbar.isFixed() ? $(window).height() - $('.navbar').height() : $(window).height();

                $menu.slimScroll({ destroy: true }).height('auto');
                $menu.parent().find('.slimScrollBar, .slimScrollRail').remove();

                var configs = $.AdminBSB.options.leftSideBar;
                $menu.slimscroll({
                    height: height + "px",
                    color: configs.scrollColor,
                    size: configs.scrollWidth,
                    alwaysVisible: configs.scrollAlwaysVisible,
                    borderRadius: configs.scrollBorderRadius,
                    railBorderRadius: configs.scrollRailBorderRadius
                });
            }
        },
        isFixed: function () {
            return $('body').hasClass('ls-fixed');
        },
        isToggled: function () {
            return $('body').hasClass('ls-toggled');
        },
        setVerticalScrollbar: function () {
            var $menu = $('.metismenu');
            if (typeof $.fn.slimScroll != 'undefined' && $('body').hasClass('fixed-sidebar')) {
                var $body = $('body');
                var height;

                if ($body.hasClass('fixed-sidebar') && !$body.hasClass('fixed-navbar')) {
                    height = $(window).height();
                } else if ($body.hasClass('navbar-fixed')) {
                    height = $(window).height() - $('.navbar').height();
                } else {
                    $menu.slimScroll({ destroy: true });
                    return;
                }

                var configs = $.AdminBSB.options.leftSideBar;

                $menu.slimScroll({ destroy: true }).height('auto');
                $menu.parent().find('.slimScrollBar, .slimScrollRail').remove();

                $menu.slimscroll({
                    height: height + "px",
                    color: configs.scrollColor,
                    size: configs.scrollWidth,
                    alwaysVisible: configs.scrollAlwaysVisible,
                    borderRadius: configs.scrollBorderRadius,
                    railBorderRadius: configs.scrollRailBorderRadius
                });
            } else {
                $menu.slimScroll({ destroy: true });
            }
        },
        setMenuOnlyFixedSidebar: function () {
            var $body = $('body');
            if ($body.hasClass('fixed-sidebar') && !$body.hasClass('fixed-navbar')) {
                var paddingTop = 50 - $(window).scrollTop();
                paddingTop = paddingTop < 0 ? 0 : paddingTop;
                $('.sidebar').css('padding-top', paddingTop);
            }
        },
        setMenuNonFixed: function () {
            var $this = this;

            $this.setSidebarHeight();

            $('.metismenu')
                .on('click',
                    '.collapse.in li a',
                    function (e) {
                        e.stopPropagation();
                    });
        },
        setSidebarHeight: function () {
            var $sidebar = $('.sidebar');
            var $content = $('.content');
            var $doc = $(document);

            var sidebarHeight = $sidebar.find('.sidebar-nav').height();
            var contentHeight = $content.height();
            var docHeight = $doc.height() - $('.navbar').height();
            var sidebarNewHeight = Math.max(sidebarHeight, contentHeight, docHeight) +
                ($sidebar.innerHeight() - $sidebar.height());
            $sidebar.css('height', sidebarNewHeight);
        },
        setMenuFixedButNavbarNonFixed: function () {
            var $this = this;
            var $sidebar = $('.sidebar');

            if ($this.isFixed() && !$.AdminBSB.navbar.isFixed()) {
                var scrollTop = $(window).scrollTop();
                var top = 50 - scrollTop < 0 ? 0 : (scrollTop > 50 ? scrollTop : 50 - scrollTop);

                $sidebar.css('top', top);
            }
        },
        changeHiddenStatu: function () {
            var width = $(window).width();

            var $body = $('body');

            if (width < 767) {
                $body.addClass('ls-hidden');
            } else {
                $body.removeClass('ls-hidden');
            }
        }
    }

    $.AdminBSB.navbar = {
        init: function () {
            var $this = this;
            var $navbarToggle = $('.js-toggle-left-sidebar');
            var $leftNavbarToggle = $('.js-left-toggle-left-sidebar');
            var $body = $('body');
            var $navbarMenu = $('.dropdown .body .menu');
            var $searchBar = $('.search-bar');

            $navbarToggle.on('click',
                function () {
                    $body.toggleClass($.AdminBSB.options.navbar.toggleClass);
                    $.AdminBSB.leftSideBar.fadeEffect();
                    $.AdminBSB.leftSideBar.setMenuWhenFixedAndToggled();
                });

            $leftNavbarToggle.on('click',
                function () {
                    $body.toggleClass('ls-hidden');
                });

            $navbarMenu.slimscroll({
                height: 255,
                color: 'rgba(0,0,0,0.5)',
                size: '4px',
                alwaysVisible: false,
                borderRadius: '0',
                railBorderRadius: '0'
            });
        },
        isFixed: function () {
            return $('body').hasClass('navbar-fixed');
        }
    }

    $.AdminBSB.dropdownMenu = {
        init: function () {
            var $this = this;

            $('.dropdown, .dropup, .btn-group').on({
                "show.bs.dropdown": function () {
                    var dropdown = $this.dropdownEffect(this);
                    $this.dropdownEffectStart(dropdown, dropdown.effectIn);
                },
                "shown.bs.dropdown": function () {
                    var dropdown = $this.dropdownEffect(this);
                    if (dropdown.effectIn && dropdown.effectOut) {
                        $this.dropdownEffectEnd(dropdown, function () { });
                    }
                },
                "hide.bs.dropdown": function (e) {
                    var dropdown = $this.dropdownEffect(this);
                    if (dropdown.effectOut) {
                        e.preventDefault();
                        $this.dropdownEffectStart(dropdown, dropdown.effectOut);
                        $this.dropdownEffectEnd(dropdown, function () {
                            dropdown.dropdown.removeClass('open');
                        });
                    }
                }
            });
        },
        dropdownEffect: function (target) {
            var effectIn = $.AdminBSB.options.dropdownMenu.effectIn, effectOut = $.AdminBSB.options.dropdownMenu.effectOut;
            var dropdown = $(target), dropdownMenu = $('.dropdown-menu', target);

            if (dropdown.length > 0) {
                var udEffectIn = dropdown.data('effect-in');
                var udEffectOut = dropdown.data('effect-out');
                if (udEffectIn !== undefined) { effectIn = udEffectIn; }
                if (udEffectOut !== undefined) { effectOut = udEffectOut; }
            }

            return {
                target: target,
                dropdown: dropdown,
                dropdownMenu: dropdownMenu,
                effectIn: effectIn,
                effectOut: effectOut
            };
        },
        dropdownEffectStart: function (data, effectToStart) {
            if (effectToStart) {
                data.dropdown.addClass('dropdown-animating');
                data.dropdownMenu.addClass('animated dropdown-animated');
                data.dropdownMenu.addClass(effectToStart);
            }
        },
        dropdownEffectEnd: function (data, callback) {
            var animationEnd = 'webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend';
            data.dropdown.one(animationEnd, function () {
                data.dropdown.removeClass('dropdown-animating');
                data.dropdownMenu.removeClass('animated dropdown-animated');
                data.dropdownMenu.removeClass(data.effectIn);
                data.dropdownMenu.removeClass(data.effectOut);

                if (typeof callback == 'function') {
                    callback();
                }
            });
        }
    }

    $(function () {
        $.AdminBSB.leftSideBar.init();
        $.AdminBSB.navbar.init();
        $.AdminBSB.dropdownMenu.init();
    });

    //AngularJs
    angular.module('adminbsb', ['ngRoute'])
        .config(function ($routeProvider) {
            $routeProvider
                .when('/',
                {
                    templateUrl: 'templates/introduction.html'
                })
                .when('/download',
                {
                    templateUrl: 'templates/download.html'
                })
                .when('/file-structure',
                {
                    templateUrl: 'templates/file-structure.html',
                    controller: 'fileStructureCtrl'
                })
                .when('/dependencies',
                {
                    templateUrl: 'templates/dependencies.html'
                })
                .when('/colors',
                {
                    templateUrl: 'templates/colors.html'
                })
                .when('/browser-support',
                {
                    templateUrl: 'templates/browser-support.html'
                })
                .when('/faq',
                {
                    templateUrl: 'templates/faq.html'
                })
                .when('/license',
                {
                    templateUrl: 'templates/license.html'
                })
                .when('/plugins',
                {
                    templateUrl: 'templates/plugins.html'
                })
                .when('/helper-classes',
                {
                    templateUrl: 'templates/helper-classes.html'
                })
                .when('/javascript-options',
                {
                    templateUrl: 'templates/javascript-options.html'
                })
                .when('/infobox',
                {
                    templateUrl: 'templates/infobox.html'
                })
                .when('/panel',
                {
                    templateUrl: 'templates/panel.html'
                })
                .when('/sass',
                {
                    templateUrl: 'templates/sass.html',
                    controller: 'sassCtrl'
                })
                .when('/gulp',
                {
                    templateUrl: 'templates/gulp.html'
                })
                .when('/grunt',
                {
                    templateUrl: 'templates/grunt.html'
                })
                .when('/bower',
                {
                    templateUrl: 'templates/bower.html'
                })
                .when('/layouts',
                {
                    templateUrl: 'templates/layouts.html'
                });
        })
        .controller('fileStructureCtrl', function () {
            //Js Tree
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

            var $treeView = $('.js-treeview');

            $treeView.on('open_node.jstree', function (e, data) {
                data.instance.set_icon(data.node, 'fa fa-folder-open fa-fw');
            });

            $treeView.on('close_node.jstree', function (e, data) {
                data.instance.set_icon(data.node, 'fa fa-folder fa-fw');
            });

            $treeView.jstree({
                'core': {
                    'check_callback': true
                },
                'plugins': ['types', 'search'],
                'types': types
            });

            $('.js-searchbox').on('keyup', function () {
                var val = $(this).val();

                $treeView.jstree(true).search(val);
            });

        })
        .controller('sassCtrl', function () {
            //Js Tree
            var types = {
                'default': {
                    'icon': 'fa fa-folder fa-fw'
                },
                'scss': {
                    'icon': 'fa fa-file-code-o fa-fw'
                }
            };

            var $treeView = $('.js-treeview');

            $treeView.on('open_node.jstree', function (e, data) {
                data.instance.set_icon(data.node, 'fa fa-folder-open fa-fw');
            });

            $treeView.on('close_node.jstree', function (e, data) {
                data.instance.set_icon(data.node, 'fa fa-folder fa-fw');
            });

            $treeView.jstree({
                'core': {
                    'check_callback': true
                },
                'plugins': ['types'],
                'types': types
            });

        })
        .run(function ($rootScope, $location) {
            $rootScope.$on("$routeChangeSuccess",
                function (event, next, current) {
                    var path = $location.$$path;

                    $rootScope.url = path.replace('/', '');
                    $rootScope.title = path === '/' ? 'INTRODUCTION' : (path.replace('-', ' ').replace('/', '')).toUpperCase();
                    $.AdminBSB.panel.init();
                });
        });

}(jQuery));