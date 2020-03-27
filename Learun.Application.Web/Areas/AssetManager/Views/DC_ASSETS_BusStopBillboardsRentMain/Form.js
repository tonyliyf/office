/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-03-07 11:49
 * 描  述：广告招租
 */
var acceptClick;
var keyValue = request('keyValue');
var F_BSBId;
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            $('.lr-form-wrap').lrscroll();
            page.bind();
            page.initData();
        },
        bind: function () {
            $('#F_Accessories').lrUploader();
            $('#F_RentState').lrDataItemSelect({ code: 'HouseRentState' });
            $('#DC_ASSETS_BusStopBillboardsRentDetail').jfGrid({
                headData: [
                    {
                        edit:{
                            type:'layer',
                            change: function (data, rownum, selectData) {
                                data.F_BillboardsName = selectData.f_billboardsname;
                                F_BSBId = selectData.f_bsbid;
                                $('#DC_ASSETS_BusStopBillboardsRentDetail').jfGridSet('updateRow', rownum);
                            },
                            op: {
                                width: 600,
                                height: 300,
                                colData: [
                                    { label: "广告牌名称", name: "f_billboardsname", width: 100, align: "left" },
                                    { label: "规格型号", name: "f_specificationtype", width: 100, align: "left" },
                                    { label: "广告资源分类", name: "f_billboardscategory", width: 100, align: "left" },
                                    {
                                        label: "生产厂商", name: "f_manufacturer", width: 100, align: "center",
                                        formatterAsync: function (callback, value, row, op, $cell) {
                                            learun.clientdata.getAsync('custmerData', {
                                                url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'ProductUnit',
                                                key: value,
                                                keyId: 'f_cuid',
                                                callback: function (_data) {
                                                    callback(_data['f_unitname']);
                                                }
                                            });
                                        }
                                    },
                                      {
                                          label: "服务商", name: "f_serviceprovider", width: 100, align: "center",
                                          formatterAsync: function (callback, value, row, op, $cell) {
                                              learun.clientdata.getAsync('custmerData', {
                                                  url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'ServiceUnit',
                                                  key: value,
                                                  keyId: 'f_cuid',
                                                  callback: function (_data) {
                                                      callback(_data['f_unitname']);
                                                  }
                                              });
                                          }
                                      },
                                     {
                                         label: "广告牌标识", name: "f_billboardsidentification", width: 100, align: "center",
                                         formatterAsync: function (callback, value, row, op, $cell) {
                                             learun.clientdata.getAsync('dataItem', {
                                                 key: value,
                                                 code: 'BoardContent',
                                                 callback: function (_data) {
                                                     callback(_data.text);
                                                 }
                                             });
                                         }
                                     },
                                    { label: "安装时间", name: "f_installationtime", width: 100, align: "left" },
                                    { label: "安装地点", name: "f_installationlocation", width: 100, align: "left" },
                                    { label: "使用状况", name: "f_usestate", width: 100, align: "left" },
                                    { label: "备注", name: "f_remarks", width: 100, align: "left" },
                                ],
                                url: top.$.rootUrl + '/LR_SystemModule/DataSource/GetDataTable',
                                param: { code: '111'
}                             }
                        }
                    }, 
                    {
                        label: '广告牌名称', name: 'F_BillboardsName', width: 150, align: "center"
                    },
                    {
                        label: '租赁状态', name: 'F_LeaseState', width: 100, align: 'center'
                        ,edit:{
                            type:'select',
                            datatype: 'dataItem',
                            code:'HouseRentState1'
                        }
                    },
                    {
                        label: '招租底价', name: 'F_RentReservePrice', width: 100, align: 'center'
                        ,edit:{
                            type:'input'
                        }
                    },
                    {
                        label: '竟租保证金', name: 'F_RentDeposit', width: 100, align: 'center'
                        ,edit:{
                            type:'input'
                        }
                    },
                    {
                        label: '出租年限', name: 'F_RentAge', width: 100, align: 'center'
                        , edit: {
                            type: 'input'
                        }
                    },
                    {
                        label: '出租面积', name: 'F_RentArea', width: 100, align: 'center'
                        , edit: {
                            type: 'input'
                        }
                    },
                ],
                isEdit: true,
                height: 200
            });
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_BusStopBillboardsRentMain/GetFormData?keyValue=' + keyValue, function (data) {
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

        var entity = $('#DC_ASSETS_BusStopBillboardsRentDetail').jfGridGet('rowdatas')
        for (var i = 0; i < entity.length; i++) {
            var o = entity[i]

            if (!o.F_LeaseState) {
                learun.alert.warning('租赁状态不能为空')
                return false
            }
            if (!o.F_RentReservePrice || !/^\d+(\.\d+)?$/.test(o.F_RentReservePrice)) {
                learun.alert.warning('请填写正确的招租底价')
                return false
            }
            if (!o.F_RentDeposit || !/^\d+(\.\d+)?$/.test(o.F_RentDeposit)) {
                learun.alert.warning('请填写正确的竞租保证金')
                return false
            }


            if (!o.F_RentAge || !/^\d+(\.\d+)?$/.test(o.F_RentAge)) {
                learun.alert.warning('请填写正确的出租年限')
                return false
            } 

            if (!o.F_RentArea || !/^\d+(\.\d+)?$/.test(o.F_RentArea)) {
                learun.alert.warning('请填写正确的出租面积')
                return false
            } 

        }

        postData.strEntity = JSON.stringify($('[data-table="DC_ASSETS_BusStopBillboardsRentMain"]').lrGetFormData());
        postData.strdC_ASSETS_BusStopBillboardsRentDetailList = JSON.stringify($('#DC_ASSETS_BusStopBillboardsRentDetail').jfGridGet('rowdatas'));
        postData.F_BSBId = F_BSBId;
        //alert(F_BSBId);
        $.lrSaveForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_BusStopBillboardsRentMain/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
