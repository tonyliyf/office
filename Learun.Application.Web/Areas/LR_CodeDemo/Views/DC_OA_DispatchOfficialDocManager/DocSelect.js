(function ($, learun) {
    "use strict";

    $(function () {
        $(document).click(function (e) {
            e = e || Window.event;
            var et = e.target || e.srcElement;
            if (et.tagName != 'BODY') {
                $('.lr-select-option').slideUp(150);
                $('.lr-select').removeClass('lr-select-focus');
            }

        });
    });

    $.DocSelect = {
        htmlToData: function ($self) {
            var dfop = $self[0]._lrselect.dfop;
            var $ul = $self.find('ul');
            dfop.data = [];
            $ul.find('li').each(function () {
                var $li = $(this);
                var point = { id: $li.attr('data-value'), text: $li.html() };
                dfop.data.push(point);
            });
            $ul.remove();
            $ul = null;
            dfop = null;
        },
        calc: function ($this, op) { // 计算高度和方向
            var bodyHeight = 0;
            var top = 0;

            bodyHeight = $('body').height();
            top = $this.offset().top;
            var topH = top - 1;
            var bottomH = bodyHeight - top - 30;
            var selctH = 2;
            // 计算选择框的高度
            if (op.allowSearch) {
                selctH += 30;
            }
            selctH += op.data.length * 26;
            if (op.placeholder) {
                selctH += 25;
            }

            if ((op.type === 'tree' || op.type === 'treemultiple') && op.data.length > 1) {
                selctH = 200;
            }

            selctH = op.height || selctH;

            var res = {
                type: 0, // 0 向下 1 向上
                height: 0
            };

            if (bottomH > 130 || bottomH > topH || bottomH > selctH) { // 如果能够显示四条数据和搜索框就采用下拉方式
                res.height = bottomH > selctH ? selctH : bottomH;
            } else {
                res.type = 1;
                res.height = topH > selctH ? selctH : topH;
            }

            return res;
        },
        initRender: function (dfop, $self) {
            $('#learun_select_option_' + dfop.id).remove();
            var $option = $('<div class="lr-select-option" id="learun_select_option_' + dfop.id + '"></div>');

            var $optionContent = $('<div class="lr-select-option-content"></div>');
            var $ul = $('<ul id="learun_select_option_content' + dfop.id + '"></ul>');
            //$optionContent.css('max-height', dfop.maxHeight + 'px');
            $option.hide();
            $optionContent.html($ul);
            $option.prepend($optionContent);
            if (dfop.allowSearch) {
                var $search = $('<div class="lr-select-option-search"><input type="text" placeholder="搜索关键字"><span class="input-query" title="查询"><i class="fa fa-search"></i></span></div>');
                $option.append($search);
                $option.css('padding-bottom', '25px');
                $search.on('click', function () { return false; });
                $search.find('input').on("keypress", function (e) {
                    e = e || window.event;
                    if (e.keyCode === 13) {
                        var $this = $(this);
                        var keyword = $this.val();
                        var $option = $this.parents('.lr-select-option');
                        var dfop = $option[0].dfop;
                        if (dfop.type === "tree" || dfop.type === "treemultiple") {
                            var $optionContent = $this.parent().prev();
                            $optionContent.lrtreeSet('search', { keyword: keyword });
                        }
                        else if (dfop.type === "default" || dfop.type === "multiple") {
                            for (var i = 0, l = dfop.data.length; i < l; i++) {
                                var _item = dfop.data[i];
                                if (!keyword || _item[dfop.text].indexOf(keyword) != -1) {
                                    _item._lrhide = false;
                                }
                                else {
                                    _item._lrhide = true;
                                }
                            }
                            $.DocSelect.render(dfop);
                        }

                        $option = null;

                    }
                });
            }
            $('body').append($option);
            $option.on('click', $.DocSelect.itemClick);
            $option[0].dfop = dfop;
            $self.append('<input class="lr-select-placeholder" value="==' + dfop.placeholder + '=="  />');
            $self.attr('type','lrselect1').addClass('lr-select1');

            if (dfop.type != 'tree') {
                $optionContent.lrscroll();
            }
        },
        render: function (dfop) {
            switch (dfop.type) {
                case 'default':
                    $.DocSelect.defaultRender(dfop);
                    break;
                case 'tree':
                case 'treemultiple':
                    $.DocSelect.treeRender(dfop);
                    break;
                case 'gird':
                    break;
                case 'multiple':
                    $.DocSelect.multipleRender(dfop);
                    break;
                default:
                    break;
            }
            dfop.isrender = true;

        },
        defaultRender: function (dfop) {
            var $ul = $('#learun_select_option_content' + dfop.id);
            $ul.html("");
            if (dfop.placeholder) {
                $ul.append('<li data-value="-1" class="lr-selectitem-li" >==' + dfop.placeholder + '==</li>');
            }
            for (var i = 0, l = dfop.data.length; i < l; i++) {
                var item = dfop.data[i];
                if (!item._lrhide) {
                    var $li = $('<li data-value="' + i + '" class="lr-selectitem-li" >' + item[dfop.text] + '</li>');
                    $ul.append($li);
                }

            }
        },
        multipleRender: function (dfop) {
            var $ul = $('#learun_select_option_content' + dfop.id);
            $ul.html("");
            if (dfop.placeholder) {
                $ul.append('<li data-value="-1" class="lr-selectitem-li" >==' + dfop.placeholder + '==</li>');
            }
            for (var i = 0, l = dfop.data.length; i < l; i++) {
                var item = dfop.data[i];
                if (!item._lrhide) {
                    if (!!dfop.multipleMapValue && dfop.multipleMapValue[i] != undefined) {
                        var $li = $('<li data-value="' + i + '" class="lr-selectitem-li" ><img class="lr-select-node-cb" src="/Content/images/learuntree/checkbox_1.png">' + item[dfop.text] + '</li>');
                        $ul.append($li);
                    }
                    else {
                        var $li = $('<li data-value="' + i + '" class="lr-selectitem-li" ><img class="lr-select-node-cb" src="/Content/images/learuntree/checkbox_0.png">' + item[dfop.text] + '</li>');
                        $ul.append($li);
                    }
                }
            }
        },
        treeRender: function (dfop) {
            var $option = $('#learun_select_option_' + dfop.id);
            $option.find('.lr-select-option-content').remove();
            var $optionContent = $('<div class="lr-select-option-content"></div>');
            $option.prepend($optionContent);
            //$optionContent.css('max-height', dfop.maxHeight + 'px');
            dfop.data.unshift({
                "id": "-1",
                "text": '==' + dfop.placeholder + '==',
                "value": "-1",
                "icon": "-1",
                "parentnodes": "0",
                "showcheck": false,
                "isexpand": false,
                "complete": true,
                "hasChildren": false,
                "ChildNodes": []
            });
            var treeop = {
                data: dfop.data,
                nodeClick: $.DocSelect.treeNodeClick
            };
            if (dfop.type === 'treemultiple') {
                treeop.nodeClick = $.DocSelect.treeNodeClick2;
                treeop.nodeCheck = $.DocSelect.treeNodeCheck;
            }
            $optionContent.lrtree(treeop);
        },
        bindEvent: function ($self) {
            $self.unbind('click');
            $self.on('click', $.DocSelect.click);
        },
        click: function (e) {
            var $this = $(this);
            if ($this.attr('readonly') == 'readonly' || $this.attr('disabled') == 'disabled') {
                return false;
            }
            var dfop = $this[0]._lrselect.dfop;
            if (!dfop.isload) {
                return false;
            }
            if (!dfop.isrender) {
                $.DocSelect.render(dfop);
            }

            // 选中下拉框的某一项
            e = e || Window.event;
            var et = e.target || e.srcElement;
            var $et = $(et);

            var $option = $('#learun_select_option_' + dfop.id);
            if ($option.is(":hidden")) {
                $('.lr-select').removeClass('lr-select-focus');
                $('.lr-select-option').slideUp(150);

                $this.addClass('lr-select-focus');
                var width = dfop.width || $this.parent().width();//+ (dfop.diffWidth || 0);
                var height = $this.innerHeight();
                var top = $this.offset().top;
                var left = $this.offset().left;
                var res = $.DocSelect.calc($this, dfop);

                if (res.type == 0) {
                    $option.css({ 'width': width, 'top': top + height + 2, 'left': left, 'height': res.height }).show();
                }
                else {
                    $option.css({ 'width': width, 'top': top - res.height - 2, 'left': left, 'height': res.height }).show();
                }
                $option.find('.lr-select-option-search').find('input').select();

                if (dfop.type != 'multiple') {
                    $option.find('.selected').removeClass('selected');
                    if (dfop._index != -1) {
                        $option.find('.lr-selectitem-li[data-value="' + dfop._index + '"]').addClass('selected');
                    }
                }

            }
            else {
                $option.slideUp(150);
                $this.removeClass('lr-select-focus');
            }

            dfop = null;
            e.stopPropagation();
        },
        itemClick: function (e) {
            // 选中下拉框的某一项
            e = e || Window.event;
            var et = e.target || e.srcElement;
            var $et = $(et);
            var $option = $(this);
            var dfop = $option[0].dfop;
            var $this = $('#' + dfop.id);
            if (dfop.type != 'multiple') {
                if ($et.hasClass('lr-selectitem-li')) {
                    var _index = $et.attr('data-value');
                    $option.find('.selected').removeClass('selected');
                    $et.addClass('selected');
                    if (dfop._index != _index) {
                        var $inputText = $this.find('.lr-select-placeholder');

                        if (_index == -1) {
                            $inputText.css('color', '#999');
                            $inputText.val('==' + dfop.placeholder + '==');
                        }
                        else {
                            $inputText.css('color', '#000');
                            $inputText.val(dfop.data[_index][dfop.text]);
                        }
                        dfop._index = _index;

                        $this.trigger("change");
                        if (dfop.select) {
                            dfop.select(dfop.data[_index]);
                        }
                    }
                    $option.slideUp(150);
                    $this.removeClass('lr-select-focus');
                }

            }
            else {
                if ($et.hasClass('lr-selectitem-li') || $et.hasClass('lr-select-node-cb')) {
                    var $inputText = $this.find('.lr-select-placeholder');
                    var $cbobj = $et.find('.lr-select-node-cb');
                    var _index = $et.attr('data-value');
                    if ($et.hasClass('lr-select-node-cb')) {
                        $cbobj = $et;
                        _index = $et.parent().attr('data-value');
                    }

                    dfop.multipleMapValue = dfop.multipleMapValue || {};
                    dfop.multipleValue = dfop.multipleValue || [];
                    dfop.multipleText = dfop.multipleText || [];

                    if (_index == -1) {
                        $inputText.css('color', '#999');
                        $inputText.val('==' + dfop.placeholder + '==');
                        dfop.multipleMapValue = {};
                        dfop.multipleValue = [];
                        dfop.multipleText = [];

                        $option.find('.lr-select-node-cb[src$="checkbox_1.png"]').attr('src', '/Content/images/learuntree/checkbox_0.png');
                        $option.slideUp(150);
                        $this.removeClass('lr-select-focus');
                    }
                    else {
                        var selected = true;
                        if (dfop.multipleMapValue[_index] == undefined) {
                            $inputText.css('color', '#000');
                            dfop.multipleValue.push(dfop.data[_index][dfop.value]);
                            dfop.multipleText.push(dfop.data[_index][dfop.text]);

                            dfop.multipleMapValue[_index] = dfop.data[_index];
                            $inputText.val(String(dfop.multipleText));

                            $cbobj.attr('src', '/Content/images/learuntree/checkbox_1.png');
                        }
                        else {
                            dfop.multipleValue = [];
                            dfop.multipleText = [];
                            delete dfop.multipleMapValue[_index];
                            $.each(dfop.multipleMapValue, function (_id, _item) {
                                dfop.multipleValue.push(_item[dfop.value]);
                                dfop.multipleText.push(_item[dfop.text]);
                            });
                            if (dfop.multipleText.length == 0) {
                                $inputText.css('color', '#999');
                                $inputText.val('==' + dfop.placeholder + '==');
                            }
                            else {
                                $inputText.val(String(dfop.multipleText));
                            }
                            selected = false;
                            $cbobj.attr('src', '/Content/images/learuntree/checkbox_0.png');
                        }

                        $this.trigger("change");
                        if (dfop.select) {
                            dfop.select(dfop.data[_index], selected, $this);
                        }
                    }
                }
            }
            e.stopPropagation();
        },
        treeNodeClick: function (item, $item) {
            var $option = $item.parents('.lr-select-option');
            var dfop = $option[0].dfop;
            $option.slideUp(150);
            var $select = $('#' + dfop.id);
            $select.removeClass('lr-select-focus');
            dfop.currtentItem = item;
            var $inputText = $select.find('.lr-select-placeholder');
            $inputText.html(dfop.currtentItem.text);
            if (item.value == '-1') {
                $inputText.css('color', '#999');
            }
            else {
                $inputText.css('color', '#000');
            }
            $select.trigger("change");
            if (dfop.select) {
                dfop.select(dfop.currtentItem);
            }

            $option = null;
            $select = null;
        },
        treeNodeClick2: function (item, $item) {
            var $tree = $item.parents('.lr-select-option-content');
            var $option = $item.parents('.lr-select-option');
            var dfop = $option[0].dfop;
            var $select = $('#' + dfop.id);

            $select.removeClass('lr-select-focus');
            dfop.currtentItems = [];
            if (item.value == '-1') {
                $item.parents('.lr-select-option').slideUp(150);
                $tree.lrtreeSet('allNoCheck');
                var $inputText = $select.find('.lr-select-placeholder');
                $inputText.val(item.text);
                $inputText.css('color', '#999');
                $select.trigger("change");
                if (dfop.select) {
                    dfop.select([]);
                }
            }
            $tree = null;
            $option = null;
            $select = null;
        },
        treeNodeCheck: function (item, $item) {
            var $tree = $item.parents('.lr-select-option-content');
            var $option = $item.parents('.lr-select-option');
            var dfop = $option[0].dfop;
            var $select = $('#' + dfop.id);
            var $inputText = $select.find('.lr-select-placeholder');
            $select.removeClass('lr-select-focus');
            var data = $tree.lrtreeSet('getCheckNodesEx');
            dfop.currtentItems = data;
            var text = "";
            for (var i = 0, l = data.length; i < l; i++) {
                var one = data[i];
                if (text != "") {
                    text += ",";
                }
                text += one.text;
            }
            if (text == "") {
                $inputText.val("==" + dfop.placeholder + "==");
                $inputText.css('color', '#999');
            }
            else {
                $inputText.val(text);
                $inputText.css('color', '#000');
            }
            $select.trigger("change");
            if (dfop.select) {
                dfop.select(dfop.currtentItems);
            }
            $tree = null;
            $option = null;
            $select = null;
            $inputText = null;

        },
        defaultValue: function ($self, type) {
            var dfop = $self[0]._lrselect.dfop;
            dfop.currtentItem = null;
            dfop._index = -1;
            var $inputText = $self.find('.lr-select-placeholder');
            $inputText.css('color', '#999');
            $inputText.val('==' + dfop.placeholder + '==');

            $('#' + dfop.id + ' .lr-select-option .selected').removeClass('selected');
            dfop.select && dfop.select(null, type);
            $self.trigger("change");
        }
    };


    $.fn.DocSelect = function (op) {
        var dfop = {
            // 请选择
            placeholder: "请选择",
            // 类型
            type: 'default',// default,tree,treemultiple,gird,multiple
            // 字段
            value: "id",
            text: "text",
            title: "title",
            // 宽度
            width: false,
            // 是否允许搜索
            allowSearch: false,
            // 访问数据接口地址
            url: false,
            data: false,
            // 访问数据接口参数
            param: null,
            // 接口请求的方法
            method: "GET",

            //选择事件
            select: false,

            isload: false, // 数据是否加载完成
            isrender: false// 选项是否渲染完成
        };
        $.extend(dfop, op || {});
        var $self = $(this);
        if ($self.length == 0) {
            return $self;
        }

        dfop.id = $self.attr('id');

        if (!dfop.id) {
            return false;
        }
        if ($self[0]._lrselect) {
            return $self;
        }

        $self[0]._lrselect = { dfop: dfop };
        // 基础信息渲染
        $.DocSelect.bindEvent($self);

        // 数据获取方式有三种：url,data,html
        // url优先级最高
        if (dfop.url) {
            learun.httpAsync(dfop.method, dfop.url, dfop.param, function (data) {
                $self[0]._lrselect.dfop.data = data || [];
                $self[0]._lrselect.dfop.backdata = data || [];
                dfop.isload = true;
            });
        }
        else if (dfop.data) {
            dfop.isload = true;
            dfop.backdata = dfop.data;
        }
        else {// 最后是html方式获取（只适合数据比较少的情况）
            $.DocSelect.htmlToData($self);
            dfop.isload = true;
            dfop.backdata = dfop.data;
        }
        $.DocSelect.initRender(dfop, $self);
        return $self;

    };
})(jQuery, top.learun);