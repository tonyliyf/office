/*
 * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：-前端开发组
 * 日 期：2017.03.16
 * 描 述：弹层（基于layer.js-3.0.3）	
 */
(function ($, learun) {
    // debugger
    "use strict";
    $.extend(learun, {
        // 自定义表单弹层
        DocLayerForm: function (op) {
            var dfop = {
                id: null,
                title: '系统窗口',
                width: 550,
                height: 400,
                url: 'error',
                btn: ['发送', '上传正文', '关闭'],
                callBack: false,
                callBack1: false,
                maxmin: false,
                end: false,
                success: false
            };
            $.extend(dfop, op || {});
            if ($(window).width() != 0) {
                dfop.width = dfop.width > $(window).width() ? $(window).width() - 10 : dfop.width;
                dfop.height = dfop.height > $(window).height() ? $(window).height() - 10 : dfop.height;
            }

            var r = top.layer.open({
                id: dfop.id,
                maxmin: dfop.maxmin,
                type: 2,//0（信息框，默认）1（页面层）2（iframe层）3（加载层）4（tips层）
                title: dfop.title,
                area: [dfop.width + 'px', dfop.height + 'px'],
                btn: dfop.btn,
                content: op.url,
                skin: dfop.btn == null ? 'lr-layer-nobtn' : 'lr-layer',
                success: function (layero, index) {
                    top['layer_' + dfop.id] = learun.iframe($(layero).find('iframe').attr('id'), top.frames);
                    layero[0].learun_layerid = 'layer_' + dfop.id;
                    //如果底部有按钮添加-确认并关闭窗口勾选按钮
                    if (!!dfop.btn && layero.find('.lr-layer-btn-cb').length == 0) {
                        top.learun.language.get('确认并关闭窗口', function (text) {
                            layero.find('.layui-layer-btn').append('<div class="checkbox lr-layer-btn-cb" myIframeId="layer_' + dfop.id + '" ><label><input checked="checked" type="checkbox" >' + text + '</label></div>');
                        });
                        layero.find('.layui-layer-btn a').each(function () {
                            var $this = $(this);
                            var _text = $this.text();
                            top.learun.language.get(_text, function (text) {
                                $this.text(text);
                            });

                        });
                    }
                    layero.find('.layui-layer-title').each(function () {
                        var $this = $(this);
                        var _text = $this.text();
                        top.learun.language.get(_text, function (text) {
                            $this.text(text);
                        });

                    });
                    if (!!dfop.success) {
                        dfop.success('layer_' + dfop.id);
                    }
                },
                yes: function (index) {
                    var flag = true;
                    if (!!dfop.callBack) {
                        flag = dfop.callBack('layer_' + dfop.id);
                    }
                    if (!!flag) {
                        learun.layerClose('', index);
                    }
                },
                end: function (index) {
                    top['layer_' + dfop.id] = null;
                    if (!!dfop.end) {
                        dfop.end();
                    }
                },
                btn2: function () {
                    var flag = true;
                    if (!!dfop.callBack1) {
                        flag = dfop.callBack1('layer_' + dfop.id);
                    }
                    if (!!flag) {
                        learun.layerClose('', index);
                    }
                    return false
                }
            });
        }
    });


})(window.jQuery, top.learun);