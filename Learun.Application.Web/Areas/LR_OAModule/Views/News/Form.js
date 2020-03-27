/*
 * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：-前端开发组
 * 日 期：2017.11.11
 * 描 述：新闻中心
 */
var acceptClick;
var keyValue = '';
var bootstrap = function ($, learun) {
    "use strict";
    var selectedRow = learun.frameTab.currentIframe().selectedRow;
    var ue;
    var page = {
        init: function () {
            page.bind();
            page.initData();
        },
        bind: function () {
            //新闻栏目
            $('#F_CategoryId').lrDataItemSelect({ code: 'NewsCategory', maxHeight: 230 });
            //内容编辑器
            ue = UE.getEditor('F_NewsContent');
            $('#F_NewsContent')[0].ue = ue;
        },
        initData: function () {
            if (!!selectedRow) {
                keyValue = selectedRow.F_NewsId;
                $('#form').lrSetFormData(selectedRow);
                $("#F_ReleaseTime").val(learun.formatDate(selectedRow.F_ReleaseTime, 'yyyy/MM/dd hh:mm'));
                $.lrSetForm(top.$.rootUrl + '/LR_OAModule/News/GetEntity?keyValue=' + keyValue, function (data) {
                    ue.ready(function () {
                        ue.setContent(data.F_NewsContent);
                    });
                });
            }
        }
    };
    acceptClick = function (callBack) {
        if (!$('#form').lrValidform()) {
            return false;
        }
        var postData = $('#form').lrGetFormData(keyValue);
        $.lrSaveForm(top.$.rootUrl + '/LR_OAModule/News/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    }

    page.init();
}


