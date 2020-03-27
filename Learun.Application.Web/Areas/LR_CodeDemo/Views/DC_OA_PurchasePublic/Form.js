/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn) 
 * Copyright (c) 2013-2018 信息技术有限公司 
 * 创建人：超级管理员 
 * 日  期：2019-02-07 14:22 
 * 描  述：DC_OA_PurchasePublic 
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
            $('#F_ModifyUserId')[0].lrvalue = learun.clientdata.get(['userinfo']).userId;
            $('#F_ModifyUserId').val(learun.clientdata.get(['userinfo']).realName);
            $('#DC_OA_PurchasePublicDetail').jfGrid({
                headData: [
                   
                    {
                        label: '发布时间', name: 'F_PublicTime', width: 150, align: 'left'
                        , edit: {
                            type: 'datatime',
                            dateformat: '0'
                        }
                    },
                    {
                        label: '开标时间', name: 'F_OpenTime', width: 150, align: 'left'
                        , edit: {
                            type: 'datatime',
                            dateformat: '0'
                        }
                    },
                    {
                        label: '延期开标时间', name: 'F_OpenTimelater', width: 150, align: 'left'
                        , edit: {
                            type: 'datatime',
                            dateformat: '0'
                        }
                    },
                    {
                        label: '是否成功', name: 'F_IsPurchase', width: 100, align: 'left'
                        , edit: {
                            type: 'select',
                            datatype: 'dataItem',
                            code: 'YesOrNo'
                        }
                    },
                    {
                        label: '第一澄清公告发布时间', name: 'F_AuditPublicTime', width: 150, align: 'left'
                        , edit: {
                            type: 'datatime',
                            dateformat: '0'
                        }
                    },
                    {
                        label: '第二次澄清公告发布时间', name: 'F_SecondAuditPublicTime', width: 150, align: 'left'
                        , edit: {
                            type: 'datatime',
                            dateformat: '0'
                        }
                    },
                  
                    {
                        label: 'DC_OA_PurchasePublicDetailId', name: 'DC_OA_PurchasePublicDetailId', width: 1, align: 'left'
                    },
                ],
                isEdit: true,
                height: 200
            });
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PurchasePublic/GetFormData?keyValue=' + keyValue, function (data) {
                    for (var id in data) {
                        if (!!data[id].length && data[id].length > 0) {
                            $('#' + id).jfGridSet('refreshdata', data[id]);
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
        postData.strEntity = JSON.stringify($('[data-table="DC_OA_PurchasePublic"]').lrGetFormData());
        postData.strdC_OA_PurchasePublicDetailList = JSON.stringify($('#DC_OA_PurchasePublicDetail').jfGridGet('rowdatas'));
        $.lrSaveForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PurchasePublic/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调 
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
} 