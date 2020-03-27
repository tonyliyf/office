/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-14 10:05
 * 描  述：DC_ASSETS_BusStopBillboards
 */
var refreshGirdData;
var openDownFileWnd
var openMapWnd;
var query;
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            page.initGird();
            page.bind();
        },
        bind: function () {
            //隐藏打印按钮
            $("#lr_print")[0].style.display = 'none';  

            $('#multiple_condition_query').lrMultipleQuery(function (queryJson) {
                page.search(queryJson);
            }, 260, 400);
            $('#F_BillboardsCategory').lrDataItemSelect({ code: 'BuildingBaseFL' });
            $('#F_Manufacturer').lrDataSourceSelect({ code: 'ProductUnit', value: 'f_cuid', text: 'f_unitname' });
            $('#F_ServiceProvider').lrDataSourceSelect({ code: 'ServiceUnit', value: 'f_cuid', text: 'f_unitname' });

            // 初始化左侧树形数据
            $('#dataTree').lrtree({
                url: top.$.rootUrl + '/AssetManager/DC_ASSETS_BusStopBillboards/GetTree',
                nodeClick: function (item) {
                    if (item.value != 0) {
                      
                        page.search({ F_BSBId: item.value });
                        
                    }
                }
            });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_BusStopBillboards/Form',
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
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_BusStopBillboards/ExportExcel',
                    param: {
                        fileName: "建筑信息表",
                        columnJson: JSON.stringify($('#gridtable').jfGridGet('settingInfo').headData),
                        queryJson: JSON.stringify(query)
                    }
                });
            });

            // 新增
            $('#lr_export').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '导入',
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_BusStopBillboards/ExcelImport',
                    width: 600,
                    height: 250,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_BSBId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/AssetManager/DC_ASSETS_BusStopBillboards/Form?keyValue=' + keyValue,
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
                var keyValue = $('#gridtable').jfGridValue('F_BSBId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_BusStopBillboards/DeleteForm', { keyValue: keyValue }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            // 打印
            $('#lr_print').on('click', function () {
                $('#gridtable').jqprintTable();
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
            openMapWnd = function (keyValue) {
                learun.layerForm({
                    id: 'areaform',
                    title: '查看区域',
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_BusStopBillboards/MapForm?look=1&keyValue=' + keyValue,
                    width: 600,
                    height: 400,
                    maxmin: true,
                    btn: null
                });
            }
            //查看附件
            $('#lr_file').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_BSBId')
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
                var keyValue = $('#gridtable').jfGridValue('F_BSBId')
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
                url: top.$.rootUrl + '/AssetManager/DC_ASSETS_BusStopBillboards/GetPageList',
                headData: [
                    { label: "广告牌名称", name: "F_BillboardsName", width: 300, align: "center" },
                    { label: "资产编号", name: "F_BillboardsNumber", width: 120, align: "center" },
                    { label: "面积(平方米)", name: "F_SpecificationType", width: 100, align: "center" },
                    {
                        label: "广告牌类别", name: "F_BillboardsCategory", width: 180, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'BuildingBaseFL',
                                callback: function (_data) {
                                    callback(_data.text);
                                }
                            });
                        }
                    },
                
                    {
                        label: "发布类型和形式", name: "F_BillboardsIdentification", width: 100, align: "center",
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
                    {
                        label: "使用状态", name: "F_UseState", width: 100, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'AdBoardUseState',
                                callback: function (_data) {
                                    callback(_data.text);
                                }
                            });
                        }
                    },
                    {
                        label: "广告发布时间", name: "F_InstallationTime", width: 100, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                            if (value.length <= 10) {
                                callback(value);
                            } else {
                                callback(value.substring(0, 10));
                            }
                        }
                    },
                    { label: "位置", name: "F_InstallationLocation", width: 140, align: "center" },
                    
                    {
                        label: "使用部门", name: "F_UseDepartmentId", width: 120, align: "center",
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
                        label: "负责人", name: "F_LeaderId", width: 100, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('user', {
                                key: value,
                                callback: function (_data) {
                                    callback(_data.name);
                                }
                            });
                        }
                    },
                    {
                        label: "管理人", name: "F_ManagerId", width: 100, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('user', {
                                key: value,
                                callback: function (_data) {
                                    callback(_data.name);
                                }
                            });
                        }
                    },
                 
                    {
                        label: "地理位置", name: "F_BoundaryCoordinates", width: 100, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                            callback('<button class="btn btn-success btn-xs" onclick = "openMapWnd(\'' + row.F_BSBId + '\')">查看地址</button>');
                        }
                    },

                   
                   
                ],
                mainId: 'F_BSBId',
                isPage: false
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
