/* * 版 本 Learun-ADMS V7.0.0 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-03 15:50
 * 描  述：DC_OA_InStock
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
            learun.httpAsync('GET', top.$.rootUrl + '/LR_SystemModule/CodeRule/GetEnCode', { code: '10009' }, function (data) {
                if (!$('#DC_OA_InStockNo').val()) {
                    $('#DC_OA_InStockNo').val(data);
                }
            });
            $('#F_CurrentUserId')[0].lrvalue = learun.clientdata.get(['userinfo']).userId;
            $('#F_CurrentUserId').val(learun.clientdata.get(['userinfo']).realName);
            $('#DC_OA_InStockState').lrDataItemSelect({ code: 'officeWoodsInstockState' });
            $('#DC_OA_InStockDetails').jfGrid({
                headData: [
                    {
                        label: '办公用品信息', name: 'DC_OA_WoodsName', width:300, align: 'left'
                        ,edit:{
                            type:'layer',
                            change: function (data, rownum, selectData) {
                                data.DC_OA_WoodsRefId = selectData.dc_oa_woodsid;
                                data.DC_OA_WoodsName = selectData.dc_oa_woodsname;
                                data.DC_OA_WoodsNo = selectData.dc_oa_woodsno;
                               
                                $('#DC_OA_InStockDetails').jfGridSet('updateRow', rownum);
                            },
                            op: {
                                width: 600,
                                height: 400,
                                colData: [
                                    { label: "", name: "dc_oa_woodsid", width: 0, align: "left", visible: false },
                                    { label: "办公用品名称", name: "dc_oa_woodsname", width: 200, align: "left" },
                                    { label: "编号", name: "dc_oa_woodsno", width: 100, align: "left" },
                                    { label: "类型", name: "dc_oa_woodstype", width: 100, align: "left" },
                                   
                                ],
                                url: top.$.rootUrl + '/LR_SystemModule/DataSource/GetDataTable',
                                param: { code: '获取商品信息'
}                             }
                        }
                    },
                    {
                        label: '数量', name: 'DC_OA_InStockNums', width:100, align: 'left'
                        ,edit:{
                            type:'input'
                        }
                    },
                    {
                        label: '价格', name: 'DC_OA_InStockPrice', width:100, align: 'left'
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
                $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_InStock/GetFormData?keyValue=' + keyValue, function (data) {
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
        postData.strEntity = JSON.stringify($('[data-table="DC_OA_InStock"]').lrGetFormData());
        postData.strdC_OA_InStockDetailsList = JSON.stringify($('#DC_OA_InStockDetails').jfGridGet('rowdatas'));
        $.lrSaveForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_InStock/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
