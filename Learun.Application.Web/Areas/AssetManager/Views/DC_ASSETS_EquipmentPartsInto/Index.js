/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-14 16:09
 * 描  述：DC_ASSETS_EquipmentPartsInto
 */
var refreshGirdData;
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
            $('#F_IntoType').lrDataItemSelect({ code: 'AssetPartIntoType' });
            $('#F_UseDepartmentId').lrDepartmentSelect();
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_EquipmentPartsInto/Form',
                    width: 600,
                    height: 700,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            //导出
            $('#lr-export1').on('click', function () {
                learun.download({
                    method: "POST",
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_EquipmentPartsInto/ExportExcel',
                    param: {
                        fileName: "配件入库信息表",
                        columnJson: JSON.stringify($('#gridtable').jfGridGet('settingInfo').headData),
                        queryJson: JSON.stringify(query)
                    }
                });
            });
            //// 编辑
            //$('#lr_edit').on('click', function () {
            //    var keyValue = $('#gridtable').jfGridValue('F_EPInId');
            //    if (learun.checkrow(keyValue)) {
            //        learun.layerForm({
            //            id: 'form',
            //            title: '编辑',
            //            url: top.$.rootUrl + '/AssetManager/DC_ASSETS_EquipmentPartsInto/Form?keyValue=' + keyValue,
            //            width: 600,
            //            height: 400,
            //            callBack: function (id) {
            //                return top[id].acceptClick(refreshGirdData);
            //            }
            //        });
            //    }
            //});
            //// 删除
            //$('#lr_delete').on('click', function () {
            //    var keyValue = $('#gridtable').jfGridValue('F_EPInId');
            //    if (learun.checkrow(keyValue)) {
            //        learun.layerConfirm('是否确认删除该项！', function (res) {
            //            if (res) {
            //                learun.deleteForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_EquipmentPartsInto/DeleteForm', { keyValue: keyValue}, function () {
            //                    refreshGirdData();
            //                });
            //            }
            //        });
            //    }
            //});
            //// 打印
            //$('#lr_print').on('click', function () {
            //    $('#gridtable').jqprintTable();
            //});
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/AssetManager/DC_ASSETS_EquipmentPartsInto/GetPageList',
                headData: [
                    { label: "入库单号", name: "F_IntoNumber", width: 200, align: "center" },
                    {
                        label: "使用单位", name: "F_UseDepartmentId", width: 200, align: "center",
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
                        label: "入库类型", name: "F_IntoType", width: 100, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'AssetPartIntoType',
                                callback: function (_data) {
                                    callback(_data.text);
                                }
                            });
                        }
                    },
                    {
                        label: "入库时间", name: "F_IntoDatetime", width: 100, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                            if (value.length <= 10) {
                                callback(value);
                            } else {
                                callback(value.substring(0, 10));
                            }
                        }
                    },
                  
                    { label: "备注", name: "F_Remarks", width: 300, align: "center" },
                ],
                mainId: 'F_EPInId',
                isPage: true,
                dblclick: function (rowdata) {
                    $('#gridtable_detail').jfGridSet('reload', { keyValue: rowdata.F_EPInId });
                }
            });
            page.search();

            $('#gridtable_detail').jfGrid({
                url: top.$.rootUrl + '/AssetManager/DC_ASSETS_EquipmentPartsInto/GetDetail',
                headData: [
                    { label: "配件名称", name: "name", width: 200, align: "center" },
                    { label: "配件编号", name: "code", width: 200, align: "center" },
                    { label: "规格", name: "type", width: 100, align: "center" },
                    { label: "入库数量", name: "num", width: 100, align: "center" },
                    { label: "期初库存", name: "initNum", width: 100, align: "center" },
                    { label: "期末库存", name: "currentNum", width: 100, align: "center" },
                ],
                isPage: false,

            })
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
