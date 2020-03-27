/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-03-21 11:44
 * 描  述：DC_EngineProject_ProjectPersonRiskControl
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
            $('#F_PIId').lrDataSourceSelect({ code: 'DC_EngineProject_ProjectInfo', value: 'f_piid', text: 'f_projectname' });
            $('#F_PPRCDepartment').lrselect({
                type: 'tree',
                allowSearch: true,
                url: top.$.rootUrl + '/LR_OrganizationModule/Department/GetTree',
                param: {} 
            });
            $('#DC_EngineProject_ProjectPersonRiskControlAssessment').jfGrid({
                headData: [
                    {
                        label: '序号', name: 'F_PPRCANum', width:100, align: 'left'
                        ,edit:{
                            type:'input'
                        }
                    },
                    {
                        label: '风险点', name: 'F_RiskPoint', width:100, align: 'left'
                        ,edit:{
                            type:'input'
                        }
                    },
                    {
                        label: '风险等级', name: 'F_RiskGrade', width:100, align: 'left'
                        ,edit:{
                            type:'select',
                            datatype: 'dataItem',
                            code:'RiskGrade'
                        }
                    },
                ],
                isEdit: true,
                height: 400
            });
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectPersonRiskControl/GetFormData?keyValue=' + keyValue, function (data) {
                    for (var id in data) {
                        if (!!data[id].length && data[id].length > 0) {
                            $('#' + id ).jfGridSet('refreshdata', data[id]);
                        }
                        else {
                            if (data[id].F_PCRCDate && data[id].F_PCRCDate.length > 10) {
                                data[id].F_PCRCDate = data[id].F_PCRCDate.substr(0, 10)
                            }
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
        var postData = {};
        postData.strEntity = JSON.stringify($('[data-table="DC_EngineProject_ProjectPersonRiskControl"]').lrGetFormData());
        postData.strdC_EngineProject_ProjectPersonRiskControlAssessmentList = JSON.stringify($('#DC_EngineProject_ProjectPersonRiskControlAssessment').jfGridGet('rowdatas'));
        $.lrSaveForm(top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectPersonRiskControl/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
