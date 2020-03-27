/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-13 11:36
 * 描  述：DC_ASSETS_LandBaseInfo
 */
var refreshGirdData;
var keyValue = request('keyValue');
var openDownFileWnd
var openMapWnd
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

            $('#lr_form_tabs').lrFormTab();
            $('#lr_form_tabs ul li').eq(0).trigger('click');
            $('#multiple_condition_query').lrMultipleQuery(function (queryJson) {
                page.search(queryJson);
            }, 220, 400);
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
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_LandBaseInfo/MapForm?look=1&keyValue=' + keyValue,
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
                url: top.$.rootUrl + '/AssetManager/DC_ASSETS_LandBaseInfo/GetPageList',
                headData: [
                    { label: "资产编号", name: "F_AssetsNumber", width: 120, align: "center" },
                    { label: "土地证号", name: "F_LandCertificate", width: 80, align: "center" },
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
                    { label: "宗地地址", name: "F_ParcelAddress", width: 100, align: "center" },
              
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
                    {
                        label: "受让人", name: "F_Assignee", width: 190, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('company', {
                                key: value,
                                callback: function (_data) {
                                    callback(_data.name);
                                }
                            });
                        }
                    },
                    { label: "合同编号", name: "F_ContractNumber", width: 80, align: "center" },
                    { label: "合同名称", name: "F_ContractName", width: 80, align: "center" },
                   
                    { label: "票据说明", name: "F_NoteDescription", width: 100, align: "center" },
                    { label: "备注", name: "F_Remarks", width: 120, align: "center" },
                    {
                        label: "票据附件", name: "F_NoteAccessories", width: 100, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                            callback('<button class="btn btn-success btn-xs" onclick = "openDownFileWnd(\'' + value + '\')">查看附件</button>');
                        }
                    },
                    {
                        label: "地理位置", name: "F_BoundaryCoordinates", width: 100, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                            callback('<button class="btn btn-success btn-xs" onclick = "openMapWnd(\'' + row.F_LBIId + '\')">查看地址</button>');
                        }
                    },
                    {
                        label: "图片附件", name: "F_PictureAccessories", width: 100, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                            callback('<button class="btn btn-success btn-xs" onclick = "openDownFileWnd(\'' + value + '\')">查看附件</button>');
                        }
                    },
                    {
                        label: "合同附件", name: "F_ContractAccessories", width: 100, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                            callback('<button class="btn btn-success btn-xs" onclick = "openDownFileWnd(\'' + value + '\')">查看附件</button>');
                        }
                    },
                    {
                        label: "成交确认书附件", name: "F_SalesConfirmation", width: 100, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                            callback('<button class="btn btn-success btn-xs" onclick = "openDownFileWnd(\'' + value + '\')">查看附件</button>');
                        }
                    },
                    {
                        label: "其他资料附件", name: "F_OtherAccessories", width: 100, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                            callback('<button class="btn btn-success btn-xs" onclick = "openDownFileWnd(\'' + value + '\')">查看附件</button>');
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
            $('#gridtable').jfGridSet('reload', { queryJson: JSON.stringify(param) });
        },
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
