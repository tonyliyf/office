/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-09 15:20
 * 描  述：DC_OA_PartyMember
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

            $('#lr_form_tabs').lrFormTab();
            $('#lr_form_tabs ul li').eq(0).trigger('click'); 
            $('#DC_OA_PartyMemberDependents').jfGrid({
                headData: [
                    {
                        label: '姓名', name: 'F_RealName', width: 100, align: 'left'
                        , edit: {
                            type: 'input'
                        }
                    },
                    {
                        label: '性别', name: 'F_Gender', width: 100, align: 'left'
                        , edit: {
                            type: 'select',
                            datatype: 'dataItem',
                            code: 'usersex'
                        }
                    },
                    {
                        label: '与党员关系', name: 'F_AppellationName', width: 100, align: 'left'
                        , edit: {
                            type: 'select',
                            datatype: 'dataItem',
                            code: '8'
                        }
                    },
                    {
                        label: '政治面貌', name: 'F_PoliticalTypeName', width: 60, align: 'left'
                        , edit: {
                            type: 'select',
                            datatype: 'dataItem',
                            code: '6'
                        }
                    },
                    {
                        label: '工作单位', name: 'F_CompanyDuties', width: 200, align: 'left'
                        , edit: {
                            type: 'input'
                        }
                    },
                    {
                        label: '职业类型名称', name: 'F_OccupationType', width: 150, align: 'left'
                        , edit: {
                            type: 'select',
                            datatype: 'dataItem',
                            code: '7'
                        }
                    },
                    {
                        label: '联系方式', name: 'F_ContactInfo', width: 100, align: 'left'
                        , edit: {
                            type: 'input'
                        }
                    },
                ],
                isEdit: true,
                height: 500
            });
            $('#F_IfSysUser').lrDataItemSelect({ code: 'YesOrNo' });
            $('#F_UserId').lrformselect({
                layerUrl: top.$.rootUrl + '/LR_OrganizationModule/User/SelectOnlyForm',
                layerUrlW: 400,
                layerUrlH: 300,
                dataUrl: top.$.rootUrl + '/LR_OrganizationModule/User/GetListByUserIds'
            });
            $('#F_Gender').lrDataItemSelect({ code: 'usersex' });
            $('#F_Nation').lrDataItemSelect({ code: 'National' });
            $('#F_MaritalStatus').lrDataItemSelect({ code: 'Marriage' });
            $('#F_Degree').lrDataItemSelect({ code: '3' });
            $('#F_PartyBranchGUID').lrDataSourceSelect({ code: '11111111111512546156',value: 'f_partybranchguid',text: 'f_partybranchname' });
            $('#F_PartyDutiesName').lrDataItemSelect({ code: '0005' });
            $('#F_OccupationType').lrDataItemSelect({ code: '7' });
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PartyMember/GetFormData?keyValue=' + keyValue, function (data) {
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
        postData.strdC_OA_PartyMemberDependentsList = JSON.stringify($('#DC_OA_PartyMemberDependents').jfGridGet('rowdatas'));
        $.lrSaveForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PartyMember/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
