(function ($) {
    'use strict';
    $(function () {
        //Autoloader init
        SyntaxHighlighter.autoloader(
            ['applescript', '../../assets/plugins/SyntaxHighlighter/scripts/shBrushAppleScript.js'],
            ['actionscript3', 'as3', '../../assets/plugins/SyntaxHighlighter/scripts/shBrushAS3.js'],
            ['bash', 'shell', '../../assets/plugins/SyntaxHighlighter/scripts/shBrushBash.js'],
            ['coldfusion', 'cf', '../../assets/plugins/SyntaxHighlighter/scripts/shBrushColdFusion.js'],
            ['cpp', 'c', '../../assets/plugins/SyntaxHighlighter/scripts/shBrushCpp.js'],
            ['c#', 'c-sharp', 'csharp', '../../assets/plugins/SyntaxHighlighter/scripts/shBrushCSharp.js'],
            ['css', '../../assets/plugins/SyntaxHighlighter/scripts/shBrushCss.js'],
            ['delphi', 'pascal', '../../assets/plugins/SyntaxHighlighter/scripts/shBrushDelphi.js'],
            ['diff', 'patch', 'pas', '../../assets/plugins/SyntaxHighlighter/scripts/shBrushDiff.js'],
            ['erl', 'erlang', '../../assets/plugins/SyntaxHighlighter/scripts/shBrushErlang.js'],
            ['groovy', '../../assets/plugins/SyntaxHighlighter/scripts/shBrushGroovy.js'],
            ['java', '../../assets/plugins/SyntaxHighlighter/scripts/shBrushJava.js'],
            ['jfx', 'javafx', '../../assets/plugins/SyntaxHighlighter/scripts/shBrushJavaFX.js'],
            ['js', 'jscript', 'javascript', '../../assets/plugins/SyntaxHighlighter/scripts/shBrushJScript.js'],
            ['perl', 'pl', '../../assets/plugins/SyntaxHighlighter/scripts/shBrushPerl.js'],
            ['php', '../../assets/plugins/SyntaxHighlighter/scripts/shBrushPhp.js'],
            ['text', 'plain', '../../assets/plugins/SyntaxHighlighter/scripts/shBrushPlain.js'],
            ['py', 'python', '../../assets/plugins/SyntaxHighlighter/scripts/shBrushPython.js'],
            ['ruby', 'rails', 'ror', 'rb', '../../assets/plugins/SyntaxHighlighter/scripts/shBrushRuby.js'],
            ['scala', '../../assets/plugins/SyntaxHighlighter/scripts/shBrushScala.js'],
            ['sql', '../../assets/plugins/SyntaxHighlighter/scripts/shBrushSql.js'],
            ['vb', 'vbnet', '../../assets/plugins/SyntaxHighlighter/scripts/shBrushVb.js'],
            ['xml', 'xhtml', 'xslt', 'html', '../../assets/plugins/SyntaxHighlighter/scripts/shBrushXml.js']);

        //Plugin init
        SyntaxHighlighter.all();

        //Theme changer
        $('.js-theme').on('change', function () {
            $('#linkSyntaxhighlighterTheme').attr('href', '../../assets/plugins/SyntaxHighlighter/styles/' + $(this).val() + '.css');
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
