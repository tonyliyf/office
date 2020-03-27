/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-16 13:45
 * 描  述：DC_ASSETS_HouseRentMain
 */
var refreshGirdData;
var openDownFileWnd
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
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentMain/Form',
                    width: 1200,
                    height: 600,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_HRMId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentMain/Form?keyValue=' + keyValue,
                        width: 1200,
                        height: 560,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_HRMId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentMain/DeleteForm', { keyValue: keyValue }, function () {
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
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentMain/ExportExcel',
                    param: {
                        fileName: "房屋招租信息表",
                        columnJson: JSON.stringify($('#gridtable').jfGridGet('settingInfo').headData),
                        queryJson: JSON.stringify(query)
                    }
                });
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
                url: top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentMain/GetPageList',
                headData: [
                    { label: "招租名称", name: "F_RentName", width: 200, align: "center" },
                    { label: "年度", name: "F_RentYear", width: 100, align: "center" },
                    { label: "批次", name: "F_RentNumber", width: 100, align: "center" },
                    {
                        label: "状态", name: "F_RentState", width: 100, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'HouseRentState',
                                callback: function (_data) {
                                    callback(_data.text);
                                }
                            });
                        }
                    },
                  
                    { label: "招租单位", name: "F_Unit", width: 200, align: "center" },
                    { label: "备注", name: "F_Remarks", width: 300, align: "center" },
                    {
                        label: "附件", name: "F_Accessories", width: 100, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                            callback('<button class="btn btn-success btn-xs" onclick = "openDownFileWnd(\'' + value + '\')">查看附件</button>');
                        }
                    },
                ],
                mainId: 'F_HRMId',
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
