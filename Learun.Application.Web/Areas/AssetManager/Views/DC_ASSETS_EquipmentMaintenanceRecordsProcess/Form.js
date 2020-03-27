/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-18 17:47
 * 描  述：DC_ASSETS_EquipmentMaintenanceRecordsProcess
 */
var PID = request("PID")
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
            $('#F_MaintenanceLevel').lrDataItemSelect({ code: 'MaintenanceLevel' });
            $('#F_FaultClassification').lrDataItemSelect({ code: 'FaultClassification' });
            $('#F_MaintenanceDepartmentId').lrselect({
                type: 'tree',
                allowSearch: true,
                url: top.$.rootUrl + '/LR_OrganizationModule/Department/GetTree',
                param: {}
            });
            $('#F_MaintenanceUserId').lrselect({
                value: 'F_UserId',
                text: 'F_RealName',
                title: 'F_RealName',
                allowSearch: true
            });
            $('#F_MaintenanceDepartmentId').on('change', function () {
                var value = $(this).lrselectGet();
                if (value == '') {
                    $('#F_MaintenanceUserId').lrselectRefresh({
                        url: '',
                        data: []
                    });
                }
                else {
                    $('#F_MaintenanceUserId').lrselectRefresh({
                        url: top.$.rootUrl + '/LR_OrganizationModule/User/GetList',
                        param: { departmentId: value }
                    });
                }
            })
            $('#DC_ASSETS_EquipmentMaintenancePartsUse').jfGrid({
                headData: [
                    {
                        label: '配件名称', name: 'name', width: 100, align: 'left'
                        , edit: {
                            type: 'layer',
                            change: function (data, rownum, selectData) {
                                console.log(rownum);
                                data.F_EPIId = selectData.f_epiid;
                                data.name = selectData.f_partsname
                                data.F_UnitPrice = selectData.f_unitprice;
                                data.type = selectData.f_specificationtype
                                data.code = selectData.f_partscode
                                $('#DC_ASSETS_EquipmentMaintenancePartsUse').jfGridSet('updateRow', rownum);
                            },
                            op: {
                                width: 600,
                                height: 400,
                                colData: [
                                    { label: "配件名称", name: "f_partsname", width: 100, align: "center" },
                                    { label: "配件编码", name: "f_partscode", width: 100, align: "center" },
                                    { label: "规格类型", name: "f_specificationtype", width: 100, align: "center" },
                                    { label: "单价", name: "f_unitprice", width: 100, align: "center" }
                                ],
                                url: top.$.rootUrl + '/LR_SystemModule/DataSource/GetDataTable',
                                param: {
                                    code: 'DevicePartData'
                                }
                            }
                        }
                    },
                    {
                        label: '配件主键', name: 'F_EPIId', width: 100, align: 'left'
                    },
                    {
                        label: '规格型号', name: 'type', width: 100, align: 'left'
                    },
                    {
                        label: '配件编号', name: 'code', width: 100, align: 'left'
                    },
                    {
                        label: '数量', name: 'F_UseNumber', width: 100, align: 'left'
                        , edit: {
                            type: 'input',
                            change: function (data, rownum, selectData) {
                                if (data.F_UseNumber && /^\d+(\.\d+)?$/.test(data.F_UseNumber) && data.F_UnitPrice && /^\d+(\.\d+)?$/.test(data.F_UnitPrice)) {
                                    data.F_AccountCosts = data.F_UseNumber * data.F_UnitPrice
                                    $('#DC_ASSETS_EquipmentMaintenancePartsUse').jfGridSet('updateRow', rownum);
                                }
                            }
                        }
                    },
                    {
                        label: '单价', name: 'F_UnitPrice', width: 100, align: 'left', edit: {
                            type: 'input', change: function (data, rownum, selectData) {

                                if (data.F_UseNumber && /^\d+(\.\d+)?$/.test(data.F_UseNumber) && data.F_UnitPrice && /^\d+(\.\d+)?$/.test(data.F_UnitPrice)) {
                                    data.F_AccountCosts = data.F_UseNumber * data.F_UnitPrice
                                    $('#DC_ASSETS_EquipmentMaintenancePartsUse').jfGridSet('updateRow', rownum);
                                }
                            }
                        }
                    },
                    {
                        label: '合计', name: 'F_AccountCosts', width: 100, align: 'left'
                    },
                ],
                isEdit: true,
                height: 400
            });
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_EquipmentMaintenanceRecordsProcess/GetFormData?keyValue=' + keyValue, function (data) {
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
        var entity = $('[data-table="DC_ASSETS_EquipmentMaintenanceRecordsProcess"]').lrGetFormData()
        entity.F_EMRPId = PID
        alert(PID);
        postData.strEntity = JSON.stringify(entity);
        postData.strdC_ASSETS_EquipmentMaintenancePartsUseList = JSON.stringify($('#DC_ASSETS_EquipmentMaintenancePartsUse').jfGridGet('rowdatas'));
        postData.PID=PID
        $.lrSaveForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_EquipmentMaintenanceRecordsProcess/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
