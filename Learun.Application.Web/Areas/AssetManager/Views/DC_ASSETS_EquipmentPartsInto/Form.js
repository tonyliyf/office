/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-14 16:09
 * 描  述：DC_ASSETS_EquipmentPartsInto
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
            learun.httpAsync('GET', top.$.rootUrl + '/LR_SystemModule/CodeRule/GetEnCode', { code: '10017' }, function (data) {
                if (!$('#F_IntoNumber').val()) {
                    $('#F_IntoNumber').val(data);
                }
            });
            $('#F_IntoType').lrDataItemSelect({ code: 'AssetPartIntoType' });       
            $('#F_UseDepartmentId').lrselect({
                type: 'tree',
                allowSearch: true,
                url: top.$.rootUrl + '/LR_OrganizationModule/Department/GetTree',
                param: {}
            });
            $('#DC_ASSETS_EquipmentPartsIntoDetail').jfGrid({
                headData: [
                    {
                        label: '配件名称', name: 'displayName', width: 100, align: 'left'
                        , edit: {
                            type: 'layer',
                            change: function (data, rownum, selectData) {
                                data.F_EPIId = selectData.f_epiid;
                                data.displayName = selectData.f_partsname;
                                $('#DC_ASSETS_EquipmentPartsIntoDetail').jfGridSet('updateRow', rownum);
                            },
                            op: {
                                width: 600,
                                height: 400,
                                colData: [
                                    //{ label: "", name: "f_epiid", width: 100, align: "left" },
                                    { label: "配件编号", name: "f_partscode", width: 100, align: "left" },
                                    { label: "配件名称", name: "f_partsname", width: 100, align: "left" },
                                    //{ label: "", name: "f_partstype", width: 100, align: "left" },
                                    { label: "规格型号", name: "f_specificationtype", width: 100, align: "left" },
                                    //{ label: "", name: "f_measurementunit", width: 100, align: "left" },
                                    //{ label: "", name: "f_unitprice", width: 100, align: "left" },
                                    //{ label: "", name: "f_manufacturer", width: 100, align: "left" },
                                    //{ label: "", name: "f_distributor", width: 100, align: "left" },
                                    //{ label: "", name: "f_storagelocation", width: 100, align: "left" },
                                    { label: "初始库存", name: "f_initialinventory", width: 100, align: "left" },
                                    { label: "期末库存", name: "currentnum", width: 100, align: "left" },
                                    //{ label: "", name: "f_maximuminventory", width: 100, align: "left" },
                                    //{ label: "", name: "f_pictureaccessories", width: 100, align: "left" },
                                    //{ label: "", name: "f_remarks", width: 100, align: "left" },
                                    //{ label: "", name: "f_partsstate", width: 100, align: "left" },
                                    //{ label: "", name: "f_createdepartmentid", width: 100, align: "left" },
                                    //{ label: "", name: "f_createdepartment", width: 100, align: "left" },
                                    //{ label: "", name: "f_createuserid", width: 100, align: "left" },
                                    //{ label: "", name: "f_createuser", width: 100, align: "left" },
                                    //{ label: "", name: "f_createdatetime", width: 100, align: "left" },
                                ],
                                url: top.$.rootUrl + '/LR_SystemModule/DataSource/GetDataTable',
                                param: {
                                    code: 'DevicePartData'
                                }
                            }
                        }
                    },
                    //{
                    //    label: '配件主键', name: 'F_EPIId', width: 0, align: 'left'
                    //},
                    {
                        label: '数量', name: 'F_IntoNum', width: 100, align: 'left', edit: {
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
                $.lrSetForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_EquipmentPartsInto/GetFormData?keyValue=' + keyValue, function (data) {
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
        postData.strEntity = JSON.stringify($('[data-table="DC_ASSETS_EquipmentPartsInto"]').lrGetFormData());
        var tabledata = $('#DC_ASSETS_EquipmentPartsIntoDetail').jfGridGet('rowdatas')
        for (var i = 0; i < tabledata.length; i++) {
            if (!tabledata[i].F_IntoNum || !/^\d+(\.\d+)?$/.test(tabledata[i].F_IntoNum)) {
                learun.alert.warning('请填写正确的数量!')
                return false
            }
        }
        postData.strdC_ASSETS_EquipmentPartsIntoDetailList = JSON.stringify(tabledata);
        $.lrSaveForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_EquipmentPartsInto/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
