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
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseInfo/Form' + '?BID=' + BID,
                    width: 600,
                    height: 590,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_HouseID');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseInfo/Form?keyValue=' + keyValue + '&BID=' + BID,
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
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseInfo/DeleteForm', { keyValue: keyValue }, function () {
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
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseInfo/ExportExcel',
                    param: {
                        fileName: "配件入库信息表",
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
                url: top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseInfo/GetPageList',
                headData: [

                    { label: "原单位", name: "F_Oldunit", width: 100, align: "center" },
                    { label: "土地名称", name: "F_Oldunit", width: 100, align: "center" },
                    { label: "土地坐落", name: "F_Oldunit", width: 100, align: "center" },
                    { label: "所有权人", name: "F_PropertyOwner", width: 100, align: "center" },
                    { label: "权属证号", name: "F_PropertyOwner", width: 100, align: "center" },
                    { label: "使用面积", name: "F_PropertyOwner", width: 100, align: "center" },
                    { label: "使用权类型", name: "F_PropertyOwner", width: 100, align: "center" },
                    { label: "地类用途", name: "F_PropertyOwner", width: 100, align: "center" },
                    { label: "账面价值", name: "F_PropertyOwner", width: 100, align: "center" },

                 
                    { label: "房屋名称", name: "F_HouseName", width: 100, align: "center" },
                  
                    { label: "房产证号", name: "F_CertificateNo", width: 200, align: "center" },
                  
                           
                   
                    {
                        label: "使用性质", name: "F_RoomUsage", width: 100, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'F_RoomUsage',
                                callback: function (_data) {
                                    callback(_data.text);
                                }
                            });
                        }
                    },
                  
                    { label: "房屋面积", name: "F_HouseArea", width: 100, align: "center" },
                   
                    { label: "房产地址", name: "F_BuildingAddress", width: 200, align: "center" },
                  
                    { label: "账面价值(万元)", name: "F_BuildingValue", width: 100, align: "center" },
                    { label: "土地证号", name: "F_LandCertificateNo", width: 150, align: "center" },
                    { label: "土地面积", name: "F_LandArea", width: 150, align: "center" },
            
                    {
                        label: "出租用途", name: "F_RentPurpose", width: 100, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'RentPurpose',
                                callback: function (_data) {
                                    callback(_data.text);
                                }
                            });
                        }
                    },
                                    
                   
                          
                    
                    { label: "备注", name: "F_Remarks", width: 300, align: "center" },
                ],
                mainId: 'F_HouseID',
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
