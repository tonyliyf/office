/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-14 13:32
 * 描  述：DC_ASSETS_EquipmentPartsInfo
 */
var refreshGirdData;
var openDownFileWnd;
var query;
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            page.initGird();
            page.bind();
        },
        bind: function () {
            $('#multiple_condition_query').lrMultipleQuery(function (queryJson) {
                page.search(queryJson);
            }, 220, 400);
            $('#F_PartsType').lrDataItemSelect({ code: 'DevicePartType' });
            $('#F_Manufacturer').lrDataSourceSelect({ code: 'ProductUnit', value: 'f_cuid', text: 'f_unitname' });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_EquipmentPartsInfo/Form',
                    width: 600,
                    height: 560,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            //导出
            $('#lr-export1').on('click', function () {
                learun.download({
                    method: "POST",
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_EquipmentPartsInfo/ExportExcel',
                    param: {
                        fileName: "配件分类管理信息表",
                        columnJson: JSON.stringify($('#gridtable').jfGridGet('settingInfo').headData),
                        queryJson: JSON.stringify(query)
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_EPIId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/AssetManager/DC_ASSETS_EquipmentPartsInfo/Form?keyValue=' + keyValue,
                        width: 600,
                        height: 560,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_EPIId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_EquipmentPartsInfo/DeleteForm', { keyValue: keyValue }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
           
            openDownFileWnd = function (folderid) {
                learun.layerForm({
                    id: "fileDownloadWnd",
                    title: "下载附件",
                    url: top.$.rootUrl + '/LR_SystemModule/Annexes/DownForm?keyVaule=' + folderid,
                    width: 600,
                    height: 400,
                    maxmin: true,
                    btn: null
                });
            }
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/AssetManager/DC_ASSETS_EquipmentPartsInfo/GetPageList',
                headData: [
                    { label: "配件名称", name: "F_PartsName", width: 100, align: "center" },
                    { label: "资产编号", name: "F_PartsCode", width: 100, align: "center" },
                    {
                        label: "配件类型", name: "F_PartsType", width: 100, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'DevicePartType',
                                callback: function (_data) {
                                    callback(_data.text);
                                }
                            });
                        }
                    },
                    { label: "规格型号", name: "F_SpecificationType", width: 100, align: "center" },
                    { label: "计量单位", name: "F_MeasurementUnit", width: 100, align: "center" },
                    { label: "单价", name: "F_UnitPrice", width: 100, align: "center" },
                    {
                        label: "生产厂商", name: "F_Manufacturer", width: 100, align: "center",
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
                        label: "经销商", name: "F_Distributor", width: 100, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('custmerData', {
                                url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'SellUnit',
                                key: value,
                                keyId: 'f_cuid',
                                callback: function (_data) {
                                    callback(_data['f_unitname']);
                                }
                            });
                        }
                    },
                    { label: "存放位置", name: "F_StorageLocation", width: 100, align: "center" },
                    { label: "初始库存", name: "F_InitialInventory", width: 100, align: "center" },
                    { label: "最大库存", name: "F_MaximumInventory", width: 100, align: "center" },
                    { label: "最小库存", name: "F_MinimumInventory", width: 100, align: "center" },
                   
                    {
                        label: "关联设备", name: "RelativeDevice", width: 120, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('custmerData', {
                                url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'DeviceData',
                                key: value,
                                keyId: 'f_eiid',
                                callback: function (_data) {
                                    callback(_data['f_equipmentname']);
                                }
                            });
                        }
                    },
                    {
                        label: "配件状态", name: "F_PartsState", width: 100, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'DevicePartState', 
                                callback: function (_data) {
                                    callback(_data.text);
                                }
                            });
                        }
                    },
                    { label: "备注", name: "F_Remarks", width: 200, align: "center" },
                    {
                        label: "图片附件", name: "F_PictureAccessories", width: 100, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                            callback('<button class="btn btn-success btn-xs" onclick = "openDownFileWnd(\'' + value + '\')">查看附件</button>');
                        }
                    },
                ],
                mainId: 'F_EPIId',
                isPage: true
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            query = param;
            $('#gridtable').jfGridSet('reload', { queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
