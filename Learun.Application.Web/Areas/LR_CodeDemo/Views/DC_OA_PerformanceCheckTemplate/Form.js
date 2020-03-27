/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-03-29 13:48
 * 描  述：DC_OA_PerformanceCheckTemplate
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
            $('#F_TimeType').lrDataItemSelect({ code: 'PerformanceCheckTemplate' });
            $('#F_Path').lrDataItemSelect({ code: 'types' });
            //$('#F_Roleid').lrDataSourceSelect({ code: 'PerformanceAppraisalTemplate', value: 'f_patid', text: 'f_templatename' });
            $('#F_Roleid').lrselect({
                // 字段
                value: "F_RoleId",
                text: "F_FullName",
                type: 'multiple',
                // 展开最大高度
                maxHeight: 200,
                // 是否允许搜索
                allowSearch: true,
                // 访问数据接口地址
                url: top.$.rootUrl + '/LR_OrganizationModule/Role/GetRoleList',
                // 访问数据接口参数
                param: { parentId: '' },
            });
            $('#F_Enabled').lrDataItemSelect({ code: 'YesOrNo' });
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceCheckTemplate/GetFormData?keyValue=' + keyValue, function (data) {
                    for (var id in data) {
                        if (!!data[id].length && data[id].length > 0) {
                            $('#' + id ).jfGridSet('refreshdata', data[id]);
                        }
                        else {
                            $('[data-table="' + id + '"]').lrSetFormData(data[id]);
                        }
                    }
                });
            }
        }
    };
    // 保存数据
    acceptClick = function (callBack) {
        if (!$('body').lrValidform()) {
            return false;
        }
        var postData = {
            strEntity: JSON.stringify($('body').lrGetFormData())
        };
        $.lrSaveForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceCheckTemplate/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
