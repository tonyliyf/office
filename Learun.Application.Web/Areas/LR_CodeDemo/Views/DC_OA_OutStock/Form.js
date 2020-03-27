/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-10 15:49
 * 描  述：DC_OA_OutStock
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
            learun.httpAsync('GET', top.$.rootUrl + '/LR_SystemModule/CodeRule/GetEnCode', { code: '10010' }, function (data) {
                if (!$('#DC_OA_OutStockNo').val()) {
                    $('#DC_OA_OutStockNo').val(data);
                }
            });
            $('#F_CreateUserId')[0].lrvalue = learun.clientdata.get(['userinfo']).userId;
            $('#F_CreateUserId').val(learun.clientdata.get(['userinfo']).realName);
            $('#DC_OA_OutStockState').lrDataItemSelect({ code: 'StockOutNo' });
            $('#DC_OA_OutStockDetails').jfGrid({
                headData: [
                    {
                        label: '办公用品信息', name: 'DC_OA_WoodsName', width: 100, align: 'left'
                        , edit: {
                            type: 'layer',
                            change: function (data, rownum, selectData) {
                                data.DC_OA_WoodsRefId = selectData.dc_oa_woodsrefid;
                                data.DC_OA_WoodsName = selectData.dc_oa_woodsname;
                                $('#DC_OA_OutStockDetails').jfGridSet('updateRow', rownum);
                            },
                            op: {
                                width: 600,
                                height: 400,
                                colData: [
                                    { label: "办公用品名称", name: "dc_oa_woodsname", width: 100, align: "left" },
                                    { label: "类型", name: "dc_oa_woodtype", width: 100, align: "left" },
                                    { label: "数量", name: "dc_oa_woodsnumbers", width: 100, align: "left" },
                                ],
                                url: top.$.rootUrl + '/LR_SystemModule/DataSource/GetDataTable',
                                param: {
                                    code: 'GetStockData'
                                }
                            }
                        }
                    },
                    {
                        label: '数量', name: 'DC_OA_OutStockNums', width: 100, align: 'left'
                        , edit: {
                            type: 'input'
                        }
                    },
                    {
                        label: '价格', name: 'DC_OA_OutStockPrice', width: 100, align: 'left'
                        , edit: {
                            type: 'input'
                        }
                    },
                ],
                isEdit: true,
                height: 400
            });
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OutStock/GetFormData?keyValue=' + keyValue, function (data) {
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
        postData.strEntity = JSON.stringify($('[data-table="DC_OA_OutStock"]').lrGetFormData());
        postData.strdC_OA_OutStockDetailsList = JSON.stringify($('#DC_OA_OutStockDetails').jfGridGet('rowdatas'));
        $.lrSaveForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OutStock/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
