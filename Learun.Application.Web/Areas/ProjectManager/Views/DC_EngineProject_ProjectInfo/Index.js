/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-03-09 13:57
 * 描  述：DC_EngineProject_ProjectInfo
 */
var refreshGirdData;
var query;
var bootstrap = function ($, learun) {
    "use strict";
    var startTime="1753-01-01";
    var endTime="3000-01-01";
    var page = {
        init: function () {
            page.initGird();
            page.bind();
        },
        bind: function () {
            // 初始化左侧树形数据
            $('#dataTree').lrtree({
                url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfo/GetTree',
                nodeClick: function (item) {
                    page.search({ F_JRYCompany: item.value });
                }
            });
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
            $('#multiple_condition_query').lrMultipleQuery(function (queryJson) {
                page.search(queryJson);
            }, 220, 400);
            $('#F_JRYCompany').lrDataSourceSelect({ code: 'company',value: 'f_companyid',text: 'f_shortname' });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfo/Form',
                    width: 600,
                    height: 570,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
       
            // 编辑
            $('#lr_edit').on('click', function () {
                
                var keyValue = $('#gridtable').jfGridValue('F_PIId');
                var F_ProjectState = $('#gridtable').jfGridValue('F_ProjectState');
                if (F_ProjectState != "5" || F_ProjectState != 5) {
                    if (learun.checkrow(keyValue)) {
                        learun.layerForm({
                            id: 'form',
                            title: '编辑',
                            url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfo/Form?keyValue=' + keyValue,
                            width: 600,
                            height: 570,
                            callBack: function (id) {
                                return top[id].acceptClick(refreshGirdData);
                            }
                        });
                    }
                }
                else {

                    return null;

                }
               
               
            });
          
            // 办结
            $('#lr_edit1').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_PIId');
                if (learun.checkrow(keyValue)) {

                    learun.layerConfirm('是否确认办结该项目！', function (res) {
                        if (res) {
                            //$.lrSaveForm(top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfo/UpdeteEntity', { keyValue: keyValue }, function (res) {
                            //    refreshGirdData();
                            //});
                            learun.deleteForm(top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfo/UpdeteEntity', { keyValue: keyValue }, function () {
                                refreshGirdData();
                            });
                        }
                       

                    });
                }
            });


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
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_PIId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfo/DeleteForm', { keyValue: keyValue}, function () {
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
                    url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfo/ExportExcel',
                    param: {
                        fileName: "信息表",
                        columnJson: JSON.stringify($('#gridtable').jfGridGet('settingInfo').headData),
                        queryJson: JSON.stringify(query)
                    }
                });
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfo/GetPageList',
                headData: [
                    { label: "项目名称", name: "F_ProjectName", width: 100, align: "left" },
                    { label: "项目编号", name: "F_ProjectItemNumber", width: 100, align: "left"},
                    { label: "项目所属公司", name: "F_JRYCompany", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op,$cell) {
                             learun.clientdata.getAsync('custmerData', {
                                 url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'company',
                                 key: value,
                                 keyId: 'f_companyid',
                                 callback: function (_data) {
                                     callback(_data['f_shortname']);
                                 }
                             });
                        }},
                    { label: "项目建设类型", name: "F_ProjectBuildType", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op,$cell) {
                             learun.clientdata.getAsync('dataItem', {
                                 key: value,
                                 code: 'EngineeringProjectBuildType',
                                 callback: function (_data) {
                                     callback(_data.text);
                                 }
                             });
                        }},
                    { label: "项目投资金额", name: "F_EngineeringCost", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op,$cell) {
                             learun.clientdata.getAsync('dataItem', {
                                 key: value,
                                 code: 'EngineeringProjectScale',
                                 callback: function (_data) {
                                     callback(_data.text);
                                 }
                             });
                        }},
                    { label: "项目状态", name: "F_ProjectState", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op,$cell) {
                             learun.clientdata.getAsync('dataItem', {
                                 key: value,
                                 code: 'OS_F_State',
                                 callback: function (_data) {
                                     callback(_data.text);
                                 }
                             });
                        }},
                    { label: "立项编号", name: "F_ProjectYear", width: 100, align: "left"},
                 
                    { label: "项目地址", name: "F_ProjectAddress", width: 100, align: "left" },
                    {
                        label: "立项日期", name: "F_ProjectApprovalDate", width: 100, align: "center", formatter: function (value) {
                            if (value && value.length > 10) {
                                return value.substr(0, 10)
                            } else {
                                return value
                            }
                        }
                    },
                    {
                        label: "计划开工时间", name: "F_PlannedStartDate", width: 100, align: "center", formatter: function (value) {
                            if (value && value.length > 10) {
                                return value.substr(0, 10)
                            } else {
                                return value
                            }
                        }
                    },
                    {
                        label: "计划完工时间", name: "F_PlannedEndDate", width: 100, align: "center", formatter: function (value) {
                            if (value && value.length > 10) {
                                return value.substr(0, 10)
                            } else {
                                return value
                            }
                        }
                    },
                ],
                mainId:'F_PIId',
                isPage: true,
                dblclick: function (rowdata) {
                    learun.layerForm({
                        id: 'form',
                        title: '查看',
                        url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfo/Form1?keyValue=' + rowdata.F_PIId,
                        width: 600,
                        height: 570,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                  
                }
               
                
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
}
