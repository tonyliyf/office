/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-03-25 10:59
 * 描  述：DC_EngineProject_BuilderDiaryMain
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
            //$('#F_CreateDepartmentId').lrDepartmentSelect();
            //$('#F_CreateUserid').lrUserSelect(0);
            // 编辑
            $('#lr_edit').on('click', function () {

                var keyValue = $('#gridtable').jfGridValue('F_PIId');
                var F_ProjectState = $('#gridtable').jfGridValue('F_ProjectState');
                    if (learun.checkrow(keyValue)) {
                        learun.layerForm({
                            id: 'form',
                            title: '编辑',
                            url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_BuilderDiaryMain/Form?keyValue=' + keyValue,
                            width: 600,
                            height: 570,
                            callBack: function (id) {
                                return top[id].acceptClick(refreshGirdData);
                            }
                        });
                    }
            });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
         
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_BuilderDiaryMain/GetPageList',
                headData: [
                    {
                        label: "项目名称", name: "F_PIId", width: 250, align: "left",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('custmerData', {
                                url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'ProjectInfo',
                                key: value,
                                keyId: 'f_piid',
                                callback: function (_data) {
                                    callback(_data['f_projectname']);
                                }
                            });
                        }
                    },
                    { label: "日志编号", name: "rzbh", width: 120, align: "center" },
                    { label: "填写人", name: "lastname", width: 120, align: "center" },
                    { label: "天气情况", name: "tqqk", width: 120, align: "center" },
                    { label: "施工人数", name: "sgrs", width: 120, align: "center" },
                    { label: "施工机械", name: "sgjx", width: 120, align: "center" },
                    {
                        label: "填写时间", name: "txsj", width: 100, align: "center", formatter: function (value) {
                            if (value && value.length > 10) {
                                return value.substr(0, 10)
                            } else {
                                return value
                            }
                        }
                    },
                    { label: "施工进度情况", name: "sgjzqk", width: 500, align: "center"},
                    { label: "明日计划安排", name: "mrjhap", width: 500, align: "center" },
                   
                ],
                mainId:'id',
                isPage: true,
                dblclick: function (rowdata) {
                    var keyValue = $('#gridtable').jfGridValue('id');
                    if (learun.checkrow(keyValue)) {

                        learun.layerForm({
                            id: 'form',
                            title: '查看',
                            url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_BuilderDiaryMain/Form?keyValue=' + keyValue,
                            width: 600,
                            height: 570,
                            callBack: function (id) {
                                return top[id].acceptClick(refreshGirdData);
                            }
                        });

                    }
                   

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
