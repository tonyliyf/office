

/*
 * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：-前端开发组
 * 日 期：2017.04.11
 * 描 述：个人中心-我的头像	
 */
var baseinfo;
var base64str
var bootstrap = function ($, learun) {
    "use strict";
    var getBaseinfo = function (callback) {
        baseinfo = learun.frameTab.currentIframe().baseinfo;
        if (!baseinfo) {
            setTimeout(function () { getBaseinfo(callback) }, 100);
        }
        else {
            callback();
        }
    };


    var page = {
        init: function () {
            getBaseinfo(function () {
                page.initData();
                page.bind();
            });
        },
        bind: function () {
            $.get(top.$.rootUrl + "/LR_CodeDemo/DC_OA_UserSignature/GetFromData", function (res) {
                if (res.code == 200) {
                    $('#iptPassword').val(res.data.password)
                    base64str = res.data.base64str
                    $("#signature").jSignature('setData', base64str, 'image/png;base64')
                    $("#signature").resize(function () {
                        $("#signature").jSignature('setData', base64str, 'image/png;base64')
                    })
                }
            }, 'json')
        },
        initData: function () {
            var $sigdiv = $("#signature")
            $sigdiv.jSignature({ lineWidth: 5 })
            $('#btnReset').click(function () {
                $sigdiv.jSignature('reset')
            })
            $('#btnSave').click(function () {
                $.post(top.$.rootUrl + "/LR_CodeDemo/DC_OA_UserSignature/Save",
                    {
                        password: $('#iptPassword').val(),
                        base64str: $sigdiv.jSignature('getData')
                    }, function (res) {
                        if (res.code == 200) {
                            learun.alert.success(res.info)
                        } else {
                            learun.alert.error(res.info)
                        }
                    }, 'json')
            })
            $('#btnRemove').click(function () {
                $.get(top.$.rootUrl + "/LR_CodeDemo/DC_OA_UserSignature/Delete", function (res) {
                    if (res.code == 200) {
                        $sigdiv.jSignature('reset')
                        learun.alert.success(res.info)
                    } else {
                        learun.alert.error(res.info)
                    }
                }, 'json')
            })
        }
    };
    page.init();
}