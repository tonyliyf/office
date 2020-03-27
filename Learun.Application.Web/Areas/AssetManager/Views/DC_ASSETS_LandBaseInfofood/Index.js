/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-13 17:40
 * 描  述：DC_ASSETS_HouseInfo
 */
var refreshGirdData;
var BID = request('keyValue');
var openDownFileWnd;
var query;
var openMapWnd;
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
            $('#F_PropertyOwner').lrDataItemSelect({ code: 'oldManager' });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            $('#F_Assignee').lrDataItemSelect({ code: 'oldManager' });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_LandBaseInfofood/Form' + '?BID=' + BID,
                    width: 600,
                    height: 590,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            openMapWnd = function (keyValue) {
                learun.layerForm({
                    id: 'areaform',
                    title: '查看区域',
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_LandBaseInfofood/MapForm?look=1&keyValue=' + keyValue,
                    width: 600,
                    height: 400,
                    maxmin: true,
                    btn: null
                });
            };

            //查看附件
            $('#lr_file').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_HouseID')
                if (learun.checkrow(keyValue)) {
                    var FIDS = $('#gridtable').jfGridValue('F_ContractAccessories')
                    var FIDS1 = $('#gridtable').jfGridValue('F_SalesConfirmation')
                    var FIDS2 = $('#gridtable').jfGridValue('F_NoteAccessories')
                    var FIDS3 = $('#gridtable').jfGridValue('F_PictureAccessories')
                    var FIDS4 = $('#gridtable').jfGridValue('F_OtherAccessories')
                    var FIDS5 = $('#gridtable').jfGridValue('F_PictureAccessories_HouseInfo')
                    top.learun.frameTab.open({
                        F_ModuleId: FIDS, F_Icon: '',
                        F_FullName: '附件信息查看', F_UrlAddress: '/LR_CodeDemo/FileViewer/Index?FIDS=' + FIDS + ',' + FIDS1 + ',' + FIDS2 + ',' + FIDS3 + ',' + FIDS4 + ',' + FIDS5
                    });
                }
            })
        

            // 新增
            $('#lr_export').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '导入',
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_LandBaseInfofood/ExcelImport',
                    width: 600,
                    height: 250,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_LBIId');
                if (keyValue == undefined || keyValue == "" || keyValue == 'null' || keyValue == 'undefined')
                {
                    var keyValue = $('#gridtable').jfGridValue('F_LBIId');
                }
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/AssetManager/DC_ASSETS_LandBaseInfofood/Form?keyValue=' + keyValue + '&BID=' + BID,
                        width: 600,
                        height: 590,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_HouseID');
                if (keyValue == undefined || keyValue == "" || keyValue == 'null' || keyValue == 'undefined') {
                    var keyValue = $('#gridtable').jfGridValue('F_LBIId');
                }
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_LandBaseInfofood/DeleteForm', { keyValue: keyValue }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            //导出
            $('#lr-export1').on('click', function () {
                learun.download({
                    method: "POST",
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_LandBaseInfofood/ExportLandHouseExcel',
                    param: {
                        fileName: "土地房屋信息表",
                        columnJson: JSON.stringify($('#gridtable').jfGridGet('settingInfo').headData),
                        queryJson: JSON.stringify(query)
                    }
                });
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
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/AssetManager/DC_ASSETS_LandBaseInfofood/GetPageList',
                headData: [

                    { label: "原单位", name: "F_Transferor", width: 100, align: "center" },
                    { label: "土地名称", name: "F_LandName", width: 100, align: "center" },
                    { label: "土地坐落", name: "F_ParcelAddress", width: 100, align: "center" },
                    { label: "所有权人", name: "F_Assignee", width: 100, align: "center" },
                    { label: "权属证号", name: "F_LandCertificate", width: 100, align: "center" },
                    { label: "使用面积", name: "F_Area", width: 100, align: "center" },
                    {
                        label: "使用权类型", name: "F_LandUseRight", width: 80, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'LandUseRight',
                                callback: function (_data) {
                                    callback(_data.text);
                                }
                            });
                        }
                    },

                    {
                        label: "地类用途", name: "F_LandUseNature", width: 80, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'LandUseBy',
                                callback: function (_data) {
                                    callback(_data.text);
                                }
                            });
                        }
                    },
                  
                    { label: "账面价值", name: "F_TransferAmount", width: 100, align: "center" },

                 
                    { label: "房屋名称", name: "F_HouseName", width: 100, align: "center" },
                  
                    { label: "房产证号", name: "F_CertificateNo", width: 200, align: "center" },
                                  
                  
                    { label: "建筑面积", name: "F_HouseArea", width: 100, align: "center" },

                    {
                        label: "建筑用途", name: "F_UseCategories", width: 80, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'BuildingUsedBy',
                                callback: function (_data) {
                                    callback(_data.text);
                                }
                            });
                        }
                    },
                   
                    { label: "资产价值", name: "F_BuildingValue", width: 100, align: "center" },
                               
                    {
                        label: "总楼层", name: "F_ConstructionFloorCount", width: 100, align: "center",
                       
                    },
                    {
                        label: "所在楼层", name: "F_FloorNumber", width: 100, align: "center",

                    },
                    { label: "原管联系人", name: "F_FormerUnitContacts", width: 100, align: "center" },
                    { label: "联系人电话", name: "F_ContactsPhone", width: 90, align: "center" },        
                    
                    { label: "备注", name: "F_Remarks", width: 120, align: "center" },
                    //{
                    //    label: "地理位置", name: "F_BoundaryCoordinates", width: 100, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                    //        callback('<button class="btn btn-success btn-xs" onclick = "openMapWnd(\'' + row.F_LBIId + '\')">查看地址</button>');
                    //    }
                    //}
                ],
                mainId: 'F_LBIId',
                isPage: true
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            param.F_BBIId = BID;
            query = param;
            $('#gridtable').jfGridSet('reload', { queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
