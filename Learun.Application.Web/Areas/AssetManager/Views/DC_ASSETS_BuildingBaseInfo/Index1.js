/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-13 15:11
 * 描  述：DC_ASSETS_BuildingBaseInfo
 */
var refreshGirdData;
var openDownFileWnd
var LBIId = request('LBIId');
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
            }, 260, 400);

            $('#F_FormerUnit').lrDataItemSelect({ code: 'oldManager' });
            $('#F_BuildingClass').lrDataItemSelect({ code: 'BuildingClass' });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_BuildingBaseInfo/Form?LBIId='+ LBIId,
                    width: 600,
                    height: 550,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });

            // 新增
            $('#lr_export').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '导入',
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_BuildingBaseInfo/ExcelImport',
                    width: 600,
                    height: 250,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_BBIId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/AssetManager/DC_ASSETS_BuildingBaseInfo/Form?keyValue=' + keyValue + '&LBIId ='+ LBIId,
                        width: 600,
                        height: 550,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_BBIId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_BuildingBaseInfo/DeleteForm', { keyValue: keyValue }, function () {
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
            //查看附件
            $('#lr_file').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_BBIId')
                if (learun.checkrow(keyValue)) {
                    var FIDS = $('#gridtable').jfGridValue('F_PictureAccessories')
                    var FIDS1 = $('#gridtable').jfGridValue('F_OtherAccessories')
                    top.learun.frameTab.open({
                        F_ModuleId: FIDS, F_Icon: '',
                        F_FullName: '附件信息查看', F_UrlAddress: '/LR_CodeDemo/FileViewer/Index?FIDS=' + FIDS + ',' + FIDS1
                    });
                }
            })
 
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/AssetManager/DC_ASSETS_BuildingBaseInfo/GetPageList',
                headData: [
                    { label: "建筑名称", name: "F_ConstructionName", width: 100, align: "center" },
                    { label: "资产编号", name: "F_ConstructionCode", width: 120, align: "center" },
                    //{ label: "地址编码", name: "F_AddressCode", width: 80, align: "center" },
                    { label: "建筑层数", name: "F_ConstructionFloorCount", width: 70, align: "center" },
                    { label: "单元数", name: "F_UnitCount", width: 70, align: "center" },
                    { label: "建筑面积", name: "F_ConstructionArea", width: 80, align: "center" },
                    //{ label: "使用面积", name: "F_UsageArea", width: 80, align: "center" },
                    //{ label: "占地面积", name: "F_CoverArea", width: 80, align: "center" },
                  
                    { label: "入账价值(万元)", name: "F_BuildingValue", width: 80, align: "center" },
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
                    {
                        label: "经营性质", name: "F_BuildingClass", width: 80, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'BuildingClass',
                                callback: function (_data) {
                                    callback(_data.text);
                                }
                            });
                        }
                    },
                    //{
                    //    label: "建筑结构", name: "F_StructureClassification", width: 80, align: "center",
                    //    formatterAsync: function (callback, value, row, op, $cell) {
                    //        learun.clientdata.getAsync('dataItem', {
                    //            key: value,
                    //            code: 'BuildingClassification',
                    //            callback: function (_data) {
                    //                callback(_data.text);
                    //            }
                    //        });
                    //    }
                    //},
                    //{ label: "使用年限", name: "F_AvailableYears", width: 80, align: "center" },
                    { label: "使用状况", name: "F_UseSituation", width: 80, align: "center" },
                    //{
                    //    label: "竣工时间", name: "F_CompletionTime", width: 80, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                    //        if (value.length <= 10) {
                    //            callback(value);
                    //        } else {
                    //            callback(value.substring(0, 10));
                    //        }
                    //    }
                    //},
                    { label: "原单位", name: "F_Oldunit", width: 120, align: "center" },
                    { label: "所属单位", name: "F_FormerUnit", width: 120, align: "center" },
                    { label: "原管联系人", name: "F_FormerUnitContacts", width: 100, align: "center" },
                    { label: "联系人电话", name: "F_ContactsPhone", width: 90, align: "center" },
                    { label: "地址", name: "F_Address", width: 130, align: "center" },
                ],
                mainId: 'F_BBIId',
                isPage: true
               
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            param.LBIId = LBIId;
            $('#gridtable').jfGridSet('reload', { queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
