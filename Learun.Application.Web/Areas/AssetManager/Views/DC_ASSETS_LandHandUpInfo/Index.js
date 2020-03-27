/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-05-23 12:01
 * 描  述：DC_ASSETS_LandHandUpInfo
 */
var refreshGirdData;
var query;
var openMapWnd;
var bootstrap = function ($, learun) {
    "use strict";
    var startTime = "1753-01-01";
    var endTime = "3000-01-01";
    var page = {
        init: function () {
            page.initGird();
            page.bind();
        },
        bind: function () {
            $('#multiple_condition_query').lrMultipleQuery(function (queryJson) {
                page.search(queryJson);
            }, 220, 400);
            $('#F_ManagerDept').lrDataItemSelect({ code: 'oldManager' });
            $('#F_State').lrDataItemSelect({ code: 'LandHandUpInfoState' });
            // 时间搜索框
            $('#datesearch').lrdate({
                dfdata: [
                    { name: '今天', begin: function () { return learun.getDate('yyyy-MM-dd 00:00:00') }, end: function () { return learun.getDate('yyyy-MM-dd 23:59:59') } },
                    { name: '近7天', begin: function () { return learun.getDate('yyyy-MM-dd 00:00:00', 'd', -6) }, end: function () { return learun.getDate('yyyy-MM-dd 23:59:59') } },
                    { name: '近1个月', begin: function () { return learun.getDate('yyyy-MM-dd 00:00:00', 'm', -1) }, end: function () { return learun.getDate('yyyy-MM-dd 23:59:59') } },
                    { name: '近3个月', begin: function () { return learun.getDate('yyyy-MM-dd 00:00:00', 'm', -3) }, end: function () { return learun.getDate('yyyy-MM-dd 23:59:59') } }
                ],
                // 月
                mShow: false,
                premShow: false,
                // 季度
                jShow: false,
                prejShow: false,
                // 年
                ysShow: false,
                yxShow: false,
                preyShow: false,
                yShow: false,
                // 默认
                dfvalue: '-1',
                selectfn: function (begin, end) {
                    startTime = begin;
                    endTime = end;
                    page.search();
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
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_LandHandUpInfo/Form',
                    width: 600,
                    height: 550,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            openMapWnd = function (keyValue) {
                learun.layerForm({
                    id: 'areaform',
                    title: '查看区域',
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_LandHandUpInfo/MapForm?look=1&keyValue=' + keyValue,
                    width: 600,
                    height: 400,
                    maxmin: true,
                    btn: null
                });
            }
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_LandHandUpid');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/AssetManager/DC_ASSETS_LandHandUpInfo/Form?keyValue=' + keyValue,
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
                var keyValue = $('#gridtable').jfGridValue('F_LandHandUpid');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_LandHandUpInfo/DeleteForm', { keyValue: keyValue}, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            // 新增
            $('#lr_export').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '导入',
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_LandHandUpInfo/ExcelImport',
                    width: 600,
                    height: 250,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            //查看附件
            $('#lr_file').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_LandHandUpid')
                if (learun.checkrow(keyValue)) {
                    var FIDS = $('#gridtable').jfGridValue('F_ContractAccessories')
                    var FIDS1 = $('#gridtable').jfGridValue('F_SalesConfirmation')
                    var FIDS2 = $('#gridtable').jfGridValue('F_NoteAccessories')
                    var FIDS3 = $('#gridtable').jfGridValue('F_OtherAccessories')
                    top.learun.frameTab.open({
                        F_ModuleId: FIDS, F_Icon: '',
                        F_FullName: '附件信息查看', F_UrlAddress: '/LR_CodeDemo/FileViewer/Index?FIDS=' + FIDS + ',' + FIDS1 + ',' + FIDS2 + ',' + FIDS3
                    });
                }
            })
            //查看所有图片
            $('#lr_file1').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_LandHandUpid')
                if (learun.checkrow(keyValue)) {
                    var FIDS = $('#gridtable').jfGridValue('F_ContractAccessories')
                    var FIDS1 = $('#gridtable').jfGridValue('F_SalesConfirmation')
                    var FIDS2 = $('#gridtable').jfGridValue('F_NoteAccessories')
                    var FIDS3 = $('#gridtable').jfGridValue('F_OtherAccessories')
                    top.learun.frameTab.open({
                        F_ModuleId: FIDS, F_Icon: '',
                        F_FullName: '图片查看', F_UrlAddress: '/LR_CodeDemo/FileViewer/ImageViewer?FIDS=' + FIDS + ',' + FIDS1 + ',' + FIDS2 + ',' + FIDS3
                    });
                }
            })
            //导出
            $('#lr-export1').on('click', function () {
                learun.download({
                    method: "POST",
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_LandHandUpInfo/ExportExcel',
                    param: {
                        fileName: "土地招拍挂信息表",
                        columnJson: JSON.stringify($('#gridtable').jfGridGet('settingInfo').headData),
                        queryJson: JSON.stringify(query)
                    }
                });
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/AssetManager/DC_ASSETS_LandHandUpInfo/GetPageList',
                headData: [

                    { label: "摘牌单位", name: "F_ManagerDept", width: 130, align: "center" },
                    {
                        label: "招拍挂状态", name: "F_State", width: 120, align: "left",
                        //formatterAsync: function (callback, value, row, op, $cell) {
                        //    learun.clientdata.getAsync('dataItem', {
                        //        key: value,
                        //        code: 'LandHandUpInfoState',
                        //        callback: function (_data) {
                        //            callback(_data.text);
                        //            //if (_data.value ="1")
                        //            //{
                        //            //    callback("<span class=\"label label-success\">" + _data.text +"</span >");
                        //            //}
                        //            //else
                        //            //{
                        //            //    callback(_data.text)
                        //            //}
                        //        }
                        //    });
                        //}
                        formatter: function (cellvalue) {
                            switch (cellvalue) {
                                case "1":
                                    return '<span class=\"label label-danger\">需解除合同</span>';
                                    break;
                                case "2":
                                    return '<span class=\"label label-warning\">已解除合同</span>';
                                    break;
                                case "3":
                                    return '<span class=\"label label-success\">已开工和竣工</span>';
                                    break;
                                case "4":
                                    return '<span class=\"label label-primary\">存量土地</span>';
                                    break;
                                   
                                case "5":
                                    return '<span class=\"label label-primary\">新约定开工时间</span>';
                                    break;
                                case "6":
                                    return '<span class=\"label label-primary\">抵押</span>';
                                    break;
                                 
                                default:
                                    return '<span class=\"label label-success\">已开工和竣工</span>';
                                    break;
                            }
                        }
                    },
                    { label: "土地证号", name: "F_LandNo", width: 150, align: "left"},
                    { label: "合同编号", name: "F_ContractNo", width: 150, align: "left" },
                                     
                    { label: "面积(m2)", name: "F_Area", width: 100, align: "left"},
                    { label: "出让金（万元）", name: "F_TotalMoney", width: 100, align: "left" },
                     {
                         label: "地类", name: "F_LandUseRight", width: 80, align: "center",
                         formatterAsync: function (callback, value, row, op, $cell) {
                             learun.clientdata.getAsync('dataItem', {
                                 key: value,
                                 code: 'landhandType',
                                 callback: function (_data) {
                                     callback(_data.text);
                                 }
                             });
                         }
                     },
                                         
                  {
                      label: "约定开工时间", name: "F_StartDate", width: 120, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                          if (value.length <= 10) {
                              callback(value);
                          } else {
                              callback(value.substring(0, 10));
                          }
                      }
                  },
                  {
                      label: "开工到期时间", name: "F_StartEndDate", width: 120, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                          if (value.length <= 10) {
                              callback(value);
                          } else {
                              callback(value.substring(0, 10));
                          }
                      }
                  },
                  {
                         label: "竣工时间", name: "F_EndDate", width: 120, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                             if (value.length <= 10) {
                                 callback(value);
                             } else {
                                 callback(value.substring(0, 10));
                             }
                         }
                  },
                 { label: "宗地坐落", name: "F_Address", width: 160, align: "left" },
                  {
                      label: "地理位置", name: "F_BoundaryCoordinates", width: 100, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                          callback('<button class="btn btn-success btn-xs" onclick = "openMapWnd(\'' + row.F_LandHandUpid + '\')">查看地址</button>');
                      }
                  },
                ],
                mainId:'F_LandHandUpid',
                isPage: true
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            param.StartTime = startTime;
            param.EndTime = endTime;
            query = param;
            $('#gridtable').jfGridSet('reload',{ queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
    page.search();
}
