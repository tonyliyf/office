/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-11-01 16:53
 * 描  述：DC_EngineProject_ProjectProgress
 */
var refreshGirdData;
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
            $('#F_PIId').lrDataSourceSelect({ code: 'DC_EngineProject_ProjectInfo',value: 'f_piid',text: 'f_projectname' });
            $('#F_Department').lrDataSourceSelect({ code: 'OA_Department',value: 'f_departmentid',text: 'f_fullname' });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectProgress/Form',
                    width: 600,
                    height: 560,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_id');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectProgress/Form?keyValue=' + keyValue,
                        width: 600,
                        height: 560,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_id');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectProgress/DeleteForm', { keyValue: keyValue}, function () {
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
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectProgress/GetPageList',
                headData: [
                    { label: "项目名称", name: "F_PIId", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op,$cell) {
                             learun.clientdata.getAsync('custmerData', {
                                 url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'DC_EngineProject_ProjectInfo',
                                 key: value,
                                 keyId: 'f_piid',
                                 callback: function (_data) {
                                     callback(_data['f_projectname']);
                                 }
                             });
                        }},
                    { label: "部门", name: "F_Department", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op,$cell) {
                             learun.clientdata.getAsync('custmerData', {
                                 url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'OA_Department',
                                 key: value,
                                 keyId: 'f_departmentid',
                                 callback: function (_data) {
                                     callback(_data['f_fullname']);
                                 }
                             });
                        }},
                    { label: "月度", name: "F_month", width: 100, align: "left"},
                    { label: "进度", name: "F_proceedings", width: 100, align: "left"},
                    { label: "填写时间", name: "F_time", width: 150, align: "left"},
                    { label: "汇报内容", name: "F_summarize", width: 100, align: "left"},
                    { label: "下月计划", name: "F_plan", width: 100, align: "left"},
                    { label: "备注", name: "F_remark", width: 100, align: "left"},
                ],
                mainId:'F_id',
                isPage: true
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            $('#gridtable').jfGridSet('reload',{ queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
