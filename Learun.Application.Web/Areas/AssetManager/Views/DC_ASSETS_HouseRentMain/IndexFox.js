/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-16 13:45
 * 描  述：DC_ASSETS_HouseRentMain
 */
var refreshGirdData;
var openDownFileWnd
var query;
var F_HRMId = '';
var openMapWnd;
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            page.initGird();
          
            page.bind();

        },
        bind: function () {

            // 初始化左侧树形数据
            $('#dataTree').lrtree({
                url: top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentDetail/GetTree',
                nodeClick: function (item) {
                    if (item.value != 0) {
                        F_HRMId = item.value;
                        page.search({ F_HRMId: item.value });
                    }
                }
            });
          
            $('#multiple_condition_query').lrMultipleQuery(function (queryJson) {
               // queryJosn.F_HRMId = F_HRMId;
                page.search(queryJson);
            }, 220, 400);


            $('#F_Assignee').lrDataItemSelect({ code: 'oldManager' });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentMain/FormInfo',
                    width: 1200,
                    height: 600,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
     

            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_HRDId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentMain/FormInfo?keyValue=' + keyValue,
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
                var keyValue = $('#gridtable').jfGridValue('F_HRDId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentDetail/DeleteForm', { keyValue: keyValue }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });

            // 新增
            $('#lr_Addcategory').on('click', function () {
                   learun.layerForm({
                    id: 'form',
                    title: '新增招租计划',
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentMain/FormFox',
                    width: 1200,
                    height: 600,
                    maxmin: true,
                    btn: null,
                    callBack: function () {

                       // return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_Editcategory').on('click', function () {
                var keyValue = F_HRMId;
                if (keyValue == 0 || keyValue == '' || keyValue.length<20) {
                    alert('请选择左侧租赁计划进行编辑!');

                }
                else {

                    learun.layerForm({
                        id: 'form',
                        title: '编辑招租计划',
                        url: top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentMain/Form2?keyValue='+ keyValue,
                        width: 1200,
                        height: 560,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
               
            });

            openMapWnd = function (keyValue) {
                var words = keyValue.split(',')
                
                if (words[1] == 1)
                {
                    alert('房屋待租，没有租金信息！')
                    return false;
                }


                learun.layerForm({
                    id: 'form',
                    title: '租金信息',
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentMain/FormRent?keyValue=' + words[0],
                    width: 1000,
                    height: 800,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                  
                });
            }

            // 删除
            $('#lr_deletecategory').on('click', function () {
                var keyValue = F_HRMId;
              
                if (keyValue == 0 || keyValue == '' || keyValue.length < 20) {
                    alert('请选择左侧租赁计划进行删除!');

                }
                else {

                    learun.layerConfirm('是否确认删除招租计划！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentMain/DeleteForm', { keyValue: keyValue }, function () {
                                location.reload();
                            });
                        }
                    });
                }
              
            });

            //查看附件
            $('#lr_file').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_HRDId')
                if (learun.checkrow(keyValue)) {
                    var FIDS = $('#gridtable').jfGridValue('F_DetailFiles')
                 
                    top.learun.frameTab.open({
                        F_ModuleId: FIDS, F_Icon: '',
                        F_FullName: '附件信息查看', F_UrlAddress: '/LR_CodeDemo/FileViewer/Index?FIDS=' + FIDS
                    });
                }
            })
  


            // 新增
            $('#lr_import').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '导入',
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentMain/ExcelImport',
                    width: 600,
                    height: 250,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });



            // 新增
            $('#lr_importplan').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '导入',
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentMain/ExcelImportPlan',
                    width: 600,
                    height: 250,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });


                 // 新增
            $('#lr_importImage').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '导入',
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentMain/ImageImport',
                    width: 600,
                    height: 250,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });

        
            //导出
            $('#lr_export').on('click', function () {
              
                learun.download({
                    method: "POST",
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentDetail/ExportExcel',
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
                url: top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentDetail/GetRentPageList',
                headData: [
                    { label: "招租名称", name: "F_RentName", width: 100, align: "center" },
                    { label: "所有权人", name: "F_FormerUnit", width: 150, align: "center" },
                    { label: "原单位", name: "F_Transferor", width: 150, align: "center" },
                    { label: "产权证号", name: "F_CertificateNo", width: 150, align: "center" },
                    { label: "建筑面积", name: "F_RentArea", width: 100, align: "center" },
                    { label: "招租底价", name: "F_RentReservePrice", width: 100, align: "center" },
                    { label: "竞租保证金", name: "F_RentDeposit", width: 120, align: "center" },
                    { label: "坐落位置", name: "F_Location", width: 200, align: "center" },
                                 
                    { label: "租赁合同", name: "F_RentContractNo", width: 150, align: "center" },
                    {
                        label: '招租状态', name: 'F_LeaseState', width: 100, align: "center"
                        , formatter: function (cellvalue) {
                            switch (cellvalue) {
                                case "1":
                                    return '<span class=\"label label-danger\">待租</span>';
                                    break;
                              
                                case "2":
                                    return '<span class=\"label label-success\">已租</span>';
                                    break;

                                case "3":
                                    return '<span class=\"label label-warning\">失败</span>';
                                    break;
                               
                                default:
                                    return '< span class=\"label label-danger\">待租</span>';
                                    break;
                            }
                        }
                    },
                    {
                        label: "租金信息", name: "F_BoundaryCoordinates", width: 100, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                           
                            callback('<button class="btn btn-success btn-xs" onclick ="openMapWnd(\'' + row.F_HRDId + "," + row.F_LeaseState+ '\')">查看租金</button>');
                        }
                    },
                    
                ],
                mainId: 'F_HRDId',
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
      //  location.reload();
       // $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
