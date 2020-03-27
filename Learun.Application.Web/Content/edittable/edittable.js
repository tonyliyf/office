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
                'role': '1',//1为被考核者 2为考核者
            }, options)
            return this.each(function () {
                //var selector = (settings.role == 1 ? 'th.user-edit' : 'th.checker-edit')
                //var selector1 = (settings.role == 1 ? 'input.check-edit' : 'input.user-edit')
                var selector = 'th.user-edit,th.checker-edit'
                var selector1 = 'input.check-edit,input.user-edit'
                $(this).find(selector).bind("click", function () {
                    var input = "<textarea id='temp'>" + $(this).text() + "</textarea>";
                    $(this).text("");
                    $(this).append(input);
                    $("textarea#temp").focus();
                    $("textarea#temp").blur(function () {
                        if ($(this).val() == "") {
                            $(this).remove();
                        } else {
                            $(this).closest("th").text($(this).val());
                        }
                    });
                });
                $(this).find(selector1).attr('disabled', 'disabled')
            })
        },
        SetData: function (data) {//设置表单数据
            if (data && data.inputData) {
                for (var id in data.inputData) {
                    $('#' + id).val(data.inputData[id])
                }
            }
            if (data && data.tdData) {
                for (var id in data.tdData) {
                    $('#' + id).text(data.tdData[id])
                }
            }
        },
        GetData: function () {//获取表单数据
            var inputData = {}
            var tdData = {}
            $(this).find('th.user-edit,th.checker-edit,th.none-edit').each(function () {
                tdData[$(this).attr('id')] = $(this).text()
            })
            $(this).find('input.user-edit,input.checker-edit').each(function () {
                inputData[$(this).attr('id')] = $(this).val()
            })
            return { inputData: inputData, tdData: tdData }
        }
    }

    $.fn.EditTable = function (method) {
        if (methods[method]) {
            return methods[method].apply(this, Array.prototype.slice.call(arguments, 1));
        } else if (typeof method === 'object' || !method) {
            return methods.init.apply(this, arguments);
        } else {
            $.error('Method' + method + 'does not exist on jQuery.WebOffice');
        }
    }
})(window.jQuery)