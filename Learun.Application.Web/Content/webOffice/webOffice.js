(function ($) {
    var $obj = null
    var settings;
    var methods = {
        init: function (options) {
            if (!Array.prototype.indexOf) {
                Array.prototype.indexOf = function (searchElement, fromIndex) {
                    var k;
                    if (this == null) {
                        throw new TypeError('"this" is null or not defined');
                    }
                    var o = Object(this);
                    var len = o.length >>> 0;
                    if (len === 0) {
                        return -1;
                    }
                    var n = fromIndex | 0;
                    if (n >= len) {
                        return -1;
                    }
                    k = Math.max(n >= 0 ? n : len - Math.abs(n), 0);
                    while (k < len) {
                        if (k in o && o[k] === searchElement) {
                            return k;
                        }
                        k++;
                    }
                    return -1;
                };
            }
            settings = $.extend({
                'saveUrl': '',//保存地址
                'openUrl': '',//打开地址
                'showMenu': true,//显示菜单
                'operator': '匿名者',//操作人  新建可以不填
                'title': '',//标题
                'editable': true,//可编辑
                'btn': []
            }, options)
            return this.each(function () {
                var container = $(this)
                $ocx = $('<object classid="clsid:FF09E4FA-BFAA-486E-ACB4-86EB0AE875D5"'
                    + ' codebase = "~/Content/webOffice/WebOffice.CAB#Version=2019,1,7,3"'
                    + 'id = "WebOffice" width = "100%" height = "1000"></object>')
                container.append($ocx)
                setTimeout(function () {
                    try {
                        $obj = document.getElementById('WebOffice')
                        $obj.WebClearMenuItem(0)
                        $obj.CustomMenuCount = 0;
                        $obj.SetMenuName(0, '操作');
                        if (settings.btn.length > 0) {
                            if (settings.btn.indexOf('save') >= 0) {
                                $obj.WebAddMenuItem(0, '保存编辑', '50000')
                            }
                            if (settings.btn.indexOf('download') >= 0) {
                                $obj.WebAddMenuItem(0, '下载', '50001')
                            }
                            if (settings.btn.indexOf('print') >= 0) {
                                $obj.WebAddMenuItem(0, '打印', '50002')
                            }
                            if (settings.btn.indexOf('signet') >= 0) {
                                $obj.WebAddMenuItem(0, '电子签章', '50003')
                            }
                            if (settings.btn.indexOf('redprint') >= 0) {
                                $obj.WebAddMenuItem(0, '套红', '50004')
                            }
                        }
                        if (settings.title.length > 0) {
                            $obj.Caption = this.title
                            $obj.Titlebar = true
                        } else {
                            $obj.Titlebar = false
                        }
                        $obj.Menubar = true
                        $obj.Toolbars = settings.showMenu

                        $obj.Open(settings.openUrl, true, "Word.Document", "", "")
                        if (settings.editable) {
                            $obj.SetTrackRevisions(1)
                            $obj.SetCurrUserName(settings.operator)
                        } else {
                            $obj.SetTrackRevisions(0)
                        }
                    }
                    catch (e) {
                        console.log(e)
                    }
                }, 2000)

            })
        },
        save: function () {
            $obj.HttpInit()
            $obj.HttpAddPostCurrFile("docfile", "")
            $obj.HttpPost(settings.saveUrl)
            //$obj.Save(settings.saveUrl)
            alert('文档保存成功！')
        },
        print: function () {
            $obj.ActiveDocument.Application.Dialogs(88).Show()
        },
        download: function () {
            $obj.showdialog(3)
        },
        signet: function (url) {
            $obj.SetFieldValue('mark_1', '', '::ADDMARK::');
            $obj.SetFieldValue('mark_1', url, '::FLOATJPG::');
        },
        redprint: function (template) {
            if (template.third && template.third.length > 0) {
                $obj.InsertFile(template.third, 2)
            }
            if (template.second && template.second.length > 0) {
                $obj.InsertFile(template.second, 1)
            }
            if (template.first && template.first.length > 0) {
                $obj.InsertFile(template.first, 1)
            }
        }
    }

    $.fn.WebOffice = function (method) {
        if (methods[method]) {
            return methods[method].apply(this, Array.prototype.slice.call(arguments, 1));
        } else if (typeof method === 'object' || !method) {
            return methods.init.apply(this, arguments);
        } else {
            $.error('Method' + method + 'does not exist on jQuery.WebOffice');
        }
    }
})(window.jQuery)