/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-13 11:36
 * 描  述：DC_ASSETS_LandBaseInfo
 */
var refreshGirdData;
var keyValue = request('keyValue');
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
            $('#multiple_condition_query').lrMultipleQuery(function (queryJson) {
                page.search(queryJson);
            }, 220, 400);

            $('#lr_form_tabs').lrFormTab();
            $('#lr_form_tabs ul li').eq(0).trigger('click');
            $('#F_LandUseRight').lrDataItemSelect({ code: 'LandUseRight' });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_LandBaseInfo/Form',
                    width: 650,
                    height: 600,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            //导出
            $('#lr-export1').on('click', function () {
                learun.download({
                    method: "POST",
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_LandBaseInfo/ExportExcel',
                    param: {
                        fileName: "土地招拍挂信息表",
                        columnJson: JSON.stringify($('#gridtable').jfGridGet('settingInfo').headData),
                        queryJson: JSON.stringify(query)
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_LBIId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/AssetManager/DC_ASSETS_LandBaseInfo/Form?keyValue=' + keyValue,
                        width: 650,
                        height: 600,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_LBIId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_LandBaseInfo/DeleteForm', { keyValue: keyValue }, function () {
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
            openMapWnd = function (keyValue) {
                learun.layerForm({
                    id: 'areaform',
                    title: '查看区域',
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_LandBaseInfo/MapForm?look=1&keyValue=' + keyValue,
                    width: 600,
                    height: 400,
                    maxmin: true,
                    btn: null
                });
            }
            //查看附件
            $('#lr_file').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_LBIId')
                if (learun.checkrow(keyValue)) {
                    var FIDS = $('#gridtable').jfGridValue('F_NoteAccessories')
                    var FIDS1 = $('#gridtable').jfGridValue('F_PictureAccessories')
                    var FIDS2 = $('#gridtable').jfGridValue('F_ContractAccessories')
                    var FIDS3 = $('#gridtable').jfGridValue('F_SalesConfirmation')
                    var FIDS4 = $('#gridtable').jfGridValue('F_OtherAccessories') 
                    top.learun.frameTab.open({
                        F_ModuleId: FIDS, F_Icon: '',
                        F_FullName: '附件信息查看', F_UrlAddress: '/LR_CodeDemo/FileViewer/Index?FIDS=' + FIDS + ',' + FIDS1 + ',' + FIDS2 + ',' + FIDS3 + ',' + FIDS4
                    });
                }
            })
         
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/AssetManager/DC_ASSETS_LandBaseInfo/GetPageList',
                headData: [
                    { label: "土地名称", name: "F_LandName", width: 150, align: "center" },
                    { label: "资产编号", name: "F_AssetsNumber", width: 120, align: "center" },
                    { label: "土地证号", name: "F_LandCertificate", width: 170, align: "center" },
                    { label: "宗地编号", name: "F_LandNumber", width: 70, align: "center" },
                    { label: "面积", name: "F_Area", width: 60, align: "center" },
                    {
                        label: "使用性质", name: "F_LandUseNature", width: 60, align: "center",
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
                    {
                        label: "使用权类型", name: "F_LandUseRight", width:80, align: "center",
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
                    { label: "出让年限", name: "F_TransferAge", width: 80, align: "center" },
                    { label: "出让金额", name: "F_SellingPrice", width: 80, align: "center" },
                    { label: "宗地地址", name: "F_ParcelAddress", width: 140, align: "center" },
              
                    {
                        label: "交付日期", name: "F_DeliveryDate", width: 100, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                            if (value.length <= 10) {
                                callback(value);
                            } else {
                                callback(value.substring(0, 10));
                            }
                        }
                    },
                    {
                        label: "竣工日期", name: "F_CompletionDate", width: 100, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                            if (value.length <= 10) {
                                callback(value);
                            } else {
                                callback(value.substring(0, 10));
                            }
                        }
                    },
                    {
                        label: "开工日期", name: "F_StartDate", width: 80, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                            if (value.length <= 10) {
                                callback(value);
                            } else {
                                callback(value.substring(0, 10));
                            }
                        }
                    },
                    {
                        label: "开工到期", name: "F_StartLimit", width: 80, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                            if (value.length <= 10) {
                                callback(value);
                            } else {
                                callback(value.substring(0, 10));
                            }
                        }
                    },
                    { label: "出让人", name: "F_Transferor", width: 80, align: "center" },
                    { label: "受让人", name: "F_Assignee", width: 80, align: "center" },
                   
                    { label: "合同编号", name: "F_ContractNumber", width: 80, align: "center" },
                    { label: "合同名称", name: "F_ContractName", width: 80, align: "center" },
                   
                    { label: "票据说明", name: "F_NoteDescription", width: 100, align: "center" },
                    { label: "备注", name: "F_Remarks", width: 120, align: "center" },                 
                    {
                        label: "地理位置", name: "F_BoundaryCoordinates", width: 100, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                            callback('<button class="btn btn-success btn-xs" onclick = "openMapWnd(\'' + row.F_LBIId + '\')">查看地址</button>');
                        }
                    },

                ],
                mainId: 'F_LBIId',
                isPage: true,
                dblclick: function (rowdata) {
                    $('#ifr1').attr('src', '../DC_ASSETS_LandBaseInfo/Index1?keyValue=' + rowdata.F_LBIId);
                    $('#ifr2').attr('src', '../DC_ASSETS_LandBaseInfo/LandBaseContract?keyValue=' + rowdata.F_LBIId);
                    $('#ifr3').attr('src', '../DC_ASSETS_LandBaseInfo/LandBaseIdleFeesPayment?keyValue=' + rowdata.F_LBIId);
                    $('#ifr4').attr('src', '../DC_ASSETS_LandBaseInfo/LandBaseStartComplete?keyValue=' + rowdata.F_LBIId);
                    $('#ifr5').attr('src', '../DC_ASSETS_LandBaseInfo/LandBaseMortgage?keyValue=' + rowdata.F_LBIId);
                }
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            query = param;
            $('#gridtable').jfGridSet('reload', { queryJson: JSON.stringify(param) });
        },
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
