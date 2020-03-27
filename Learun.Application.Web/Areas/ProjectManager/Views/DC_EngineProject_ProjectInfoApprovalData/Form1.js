/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-03-25 15:19
 * 描  述：DC_EngineProject_ProjectInfoApprovalData
 */
var acceptClick;
var keyValue = request('keyValue');
var F_PIId = request('F_PIId');
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            $('.lr-form-wrap').lrscroll();
            page.bind();
            page.initData();
        },
        bind: function () {
            $('#F_PIId').lrDataSourceSelect({ code: 'ProjectInfo', value: 'f_piid', text: 'f_projectname' }).lrselectSet(F_PIId);
            $('#F_DataPhoto').lrUploader();
            $('#F_Attachment').lrUploader();
            $('#F_CreateUserid')[0].lrvalue = learun.clientdata.get(['userinfo']).userId;
            $('#F_CreateUserid').val(learun.clientdata.get(['userinfo']).realName);
            $('#F_CreateDepartmentId')[0].lrvalue = learun.clientdata.get(['userinfo']).userId;
            $('#F_CreateDepartmentId').val(learun.clientdata.get(['userinfo']).realName);

            $('#F_ProjectStage').lrselect({
                type: 'tree',
                allowSearch: true,
                url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfoApprovalData/GetTree',
                param: {}
            });
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfoApprovalData/GetFormData?keyValue=' + keyValue, function (data) {
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
            strEntity: null
        };
        $.lrSaveForm(top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfoApprovalData/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
