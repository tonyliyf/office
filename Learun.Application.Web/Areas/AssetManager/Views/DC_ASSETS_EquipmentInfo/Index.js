/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-14 11:09
 * 描  述：DC_ASSETS_EquipmentInfo
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
            $('#F_DeviceIdentification').lrDataItemSelect({ code: 'DeviceIdentification' });
            $('#F_EquipmentCategory').lrDataItemSelect({ code: 'EquipmentType' });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_EquipmentInfo/Form',
                    width: 600,
                    height: 670,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            //导出
            $('#lr-export1').on('click', function () {
                learun.download({
                    method: "POST",
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_EquipmentInfo/ExportExcel',
                    param: {
                        fileName: "设备信息表",
                        columnJson: JSON.stringify($('#gridtable').jfGridGet('settingInfo').headData),
                        queryJson: JSON.stringify(query)
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_EIId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/AssetManager/DC_ASSETS_EquipmentInfo/Form?keyValue=' + keyValue,
                        width: 600,
                        height: 670,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_EIId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_EquipmentInfo/DeleteForm', { keyValue: keyValue }, function () {
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

            //查看附件
            $('#lr_file').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_EIId')
                if (learun.checkrow(keyValue)) {
                    var FIDS = $('#gridtable').jfGridValue('F_PictureAccessories')
                    top.learun.frameTab.open({
                        F_ModuleId: FIDS, F_Icon: '',
                        F_FullName: '附件信息查看', F_UrlAddress: '/LR_CodeDemo/FileViewer/Index?FIDS=' + FIDS
                    });
                }
            })
            //查看所有图片
            $('#lr_file1').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_EIId')
                if (learun.checkrow(keyValue)) {
                    var FIDS = $('#gridtable').jfGridValue('F_PictureAccessories')
                    top.learun.frameTab.open({
                        F_ModuleId: FIDS, F_Icon: '',
                        F_FullName: '图片查看', F_UrlAddress: '/LR_CodeDemo/FileViewer/ImageViewer?FIDS=' + FIDS
                    });
                }
            })
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/AssetManager/DC_ASSETS_EquipmentInfo/GetPageList',
                headData: [
                    { label: "设备名称", name: "F_EquipmentName", width: 100, align: "center" },
                    { label: "资产编号", name: "F_EquipmentNumber", width: 150, align: "center" },
                    { label: "规格型号", name: "F_SpecificationType", width: 80, align: "center" },
                    {
                        label: "设备类别", name: "F_EquipmentCategory", width: 80, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'EquipmentType',
                                callback: function (_data) {
                                    callback(_data.text);
                                }
                            });
                        }
                    },
                  
                    { label: "资源原值", name: "F_OriginalValueAssets", width: 80, align: "center" },
                    { label: "总功率（KW）", name: "F_TotalPowerKW", width: 100, align: "center" },
                    
                   
                    {
                        label: "购置时间", name: "F_AcquisitionTime", width: 120, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                            if (value.length <= 10) {
                                callback(value);
                            } else {
                                callback(value.substring(0, 10));
                            }
                        }
                    },
                    {
                        label: "使用部门", name: "F_UseDepartmentId", width: 160, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('department', {
                                key: value,
                                callback: function (_data) {
                                    callback(_data.name);
                                }
                            });
                        }
                    },
                    {
                        label: "资产负责人", name: "F_LeaderId", width: 120, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('user', {
                                key: value,
                                callback: function (_data) {
                                    callback(_data.name);
                                }
                            });
                        }
                    },
                   
                    { label: "净残值", name: "F_NetSalvageValue", width: 90, align: "center" },
                   
                    {
                        label: "折旧方法", name: "F_DepreciationMethod", width: 90, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'DepreciationMethod',
                                callback: function (_data) {
                                    callback(_data.text);
                                }
                            });
                        }
                    },
                    { label: "折旧年限", name: "F_UsefulYear", width: 90, align: "center" },
                    { label: "本月折旧", name: "F_DepreciationThisMonth", width: 90, align: "center" },
                    { label: "累计折旧", name: "F_AccumulatedDepreciation", width: 90, align: "center" },
                    { label: "安装地点", name: "F_InstallationLocation", width: 200, align: "center" },
                              
                ],
                mainId: 'F_EIId',
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
