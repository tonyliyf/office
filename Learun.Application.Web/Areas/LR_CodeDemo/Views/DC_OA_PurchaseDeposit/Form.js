/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-06 16:45
 * 描  述：DC_OA_PurchaseDeposit
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
            $('#F_CurrentCompanyId')[0].lrvalue = learun.clientdata.get(['userinfo']).companyId;
            learun.clientdata.getAsync('company', {
                key: learun.clientdata.get(['userinfo']).companyId,
                callback: function (_data) {
                    $('#F_CurrentCompanyId').val(_data.name);
                }
            });
            $('#F_CurrentDeptId')[0].lrvalue = learun.clientdata.get(['userinfo']).departmentId;
            learun.clientdata.getAsync('department', {
                key: learun.clientdata.get(['userinfo']).departmentId,
                callback: function (_data) {
                    $('#F_CurrentDeptId').val(_data.name);
                }
            });
            $('#DC_OA_PurchaseDepositDetail').jfGrid({
                headData: [
                    {
                        label: '主键', name: 'F_PurchaseDepositDetailid', width:0, align: 'left'                    },
                    {
                        label: '退还对象名称', name: 'F_OrganizeId', width:200, align: 'left'
                        ,edit:{
                            type:'select',
                            datatype: 'dataSource',
                            code:'GetPurchaseCompany',
                            op:{
                                value: 'f_purchasecompanyid',
                                text:'f_purchasecompanyname',
                                title:'f_purchasecompanyname'
                            }
                        }
                    },
                    {
                        label: '退还金额', name: 'F_money', width:100, align: 'left'
                        ,edit:{
                            type:'input'
                        }
                    },
                    {
                        label: '是否退还', name: 'F_ISReturn', width:60, align: 'left'
                        ,edit:{
                            type:'select',
                            datatype: 'dataItem',
                            code:'YesOrNo'
                        }
                    },
                    {
                        label: '不退还理由', name: 'F_NoReason', width:300, align: 'left'
                        ,edit:{
                            type:'input'
                        }
                    },
                ],
                isEdit: true,
                height: 400
            });
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PurchaseDeposit/GetFormData?keyValue=' + keyValue, function (data) {
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
        var postData = {};
        postData.strEntity = JSON.stringify($('[data-table="DC_OA_PurchaseDeposit"]').lrGetFormData());
        postData.strdC_OA_PurchaseDepositDetailList = JSON.stringify($('#DC_OA_PurchaseDepositDetail').jfGridGet('rowdatas'));
        $.lrSaveForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PurchaseDeposit/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
