/* * 版 本 Learun-ADMS V7.0.0 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-07 17:47
 * 描  述：DC_OA_OverSeeWorkTaskExecute
 */
var acceptClick;
var keyValue = request('keyValue');
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            $('.lr-form-wrap').lrscroll();
            page.bind();
            page.initData();
        },
        bind: function () {
            $.post(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkTaskSplitDelete/GetNoticeMembersData?', { keyValue: keyValue }, function (res) {
                $('#sel_sendUsers').lrselect({
                    data: res.data.userdata,
                    value: 'value',
                    text: 'text',
                    type: 'multiple'
                })
                $('#area_content').val('工作项：“' + res.data.text + '”提醒您尽快办理')
            }, 'json')
        },
        initData: function () {

        }
    };
    // 保存数据
    acceptClick = function (callBack) {
        $.lrSaveForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkTaskSplitDelete/SendOsNoticeMsg', {
            userlist: $('#sel_sendUsers').lrselectGet(),
            msg: $('#area_content').val()
        }, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
