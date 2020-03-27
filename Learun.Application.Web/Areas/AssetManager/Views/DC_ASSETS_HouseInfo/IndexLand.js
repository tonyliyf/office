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
var openMapNewdata;
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
            $('#F_BuildingClass').lrDataItemSelect({ code: 'BuildingClass' });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseInfo/FormLand' + '?BID=' + BID,
                    width: 600,
                    height: 590,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            openMapWnd = function (keyValue) {
              //  alert(keyValue);
                learun.layerForm({
                    id: 'areaform',
                    title: '查看区域',
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseInfo/MapForm?look=1&keyValue=' + keyValue,
                    width: 600,
                    height: 400,
                    maxmin: true,
                    btn: null
                });
            }
            
            openMapNewdata = function (keyValue) {
                //  alert(keyValue);
                learun.layerForm({
                    id: 'areaform',
                    title: '查看区域',
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseInfo/FormInfo?keyValue=' + keyValue,
                    width: 600,
                    height: 700,
                    maxmin: true,
                    btn: null
                });
            }
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
            //查看所有图片
            $('#lr_file1').on('click', function () {
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
                        F_FullName: '图片查看', F_UrlAddress: '/LR_CodeDemo/FileViewer/ImageViewer?FIDS=' + FIDS + ',' + FIDS1 + ',' + FIDS2 + ',' + FIDS3 + ',' + FIDS4 + ',' + FIDS5
                    });
                }
            })

         
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_HouseID');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseInfo/FormLand?keyValue=' + keyValue + '&BID=' + BID,
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
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseInfo/ExportLandHouseExcel',
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
                url: top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseInfo/GetTotalPageList',
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
                        label: "总楼层", name: "F_HouseFloorCount", width: 100, align: "center",
                       
                    },
                    {
                        label: "所在楼层", name: "F_FloorNumber", width: 100, align: "center",

                    },
                    { label: "原管联系人", name: "F_FormerUnitContacts", width: 100, align: "center" },
                    { label: "联系人电话", name: "F_ContactsPhone", width: 90, align: "center" },        
                    
                    { label: "备注", name: "F_Remarks", width: 120, align: "center" },
                     {
                         label: "地理位置", name: "F_BoundaryCoordinates", width: 100, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                             callback('<button class="btn btn-success btn-xs" onclick = "openMapWnd(\'' + row.F_HouseID + '\')">查看地址</button>');
                         }
                     },
                      {
                          label: "租金信息", name: "F_BoundaryCoordinates", width: 100, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                              callback('<button class="btn btn-success btn-xs" onclick = "openMapNewdata(\'' + row.F_HouseID + '\')">查看租金</button>');
                          }
                      },
                ],
                mainId: 'F_HouseID',
                isPage: true,

                gridComplete: function () {
                    alert(aa)
                    //在gridComplete调用合并方法
                    var gridName = "gridTable";
                    //动态合并纵行
                
                    //写死合并横行（因为横行一般是我们定义的固定数，
                    //所以你可以根据我下面的例子自己加条件，合并哪些横行，我这里就写死了，哈哈）
                   // MergerColspan(gridName, 8, 'id', 'userName');
                }

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

   
    function MergerRowspan(gridName, CellName) {
        //得到显示到界面的id集合
        var mya = $("#" + gridName + "").getDataIDs();
        //当前显示多少条
        var length = mya.length;
        for (var i = 0; i < length; i++) {
            //从上到下获取一条信息
            var before = $("#" + gridName + "").jqGrid('getRowData', mya[i]);
            //定义合并行数
            var rowSpanTaxCount = 1;
            for (j = i + 1; j <= length; j++) {
                //和上边的信息对比 如果值一样就合并行数+1 然后设置rowspan 让当前单元格隐藏
                var end = $("#" + gridName + "").jqGrid('getRowData', mya[j]);
                if (before[CellName] == end[CellName]) {
                    rowSpanTaxCount++;
                    $("#" + gridName + "").setCell(mya[j], CellName, '', { display: 'none' });
                } else {
                    rowSpanTaxCount = 1;
                    break;
                }
                $("#" + CellName + "" + mya[i] + "").attr("rowspan", rowSpanTaxCount);
            }
        }
    };
 
    page.init();
}
