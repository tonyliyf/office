/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-07-30 15:42
 * 描  述：项目考勤记录
 */
var refreshGirdData;
var F_ProjectId;
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
                url: top.$.rootUrl + '/ProjectManager/ProjectAttenceRecord/GetTree',
                nodeClick: function (item) {
                    page.search({ F_ProjectId: item.id });
                }
            });
            $('#multiple_condition_query').lrMultipleQuery(function (queryJson) {
                page.search(queryJson);
            }, 220, 400);
            
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });

            $('#F_Month').lrDataSourceSelect({ code: 'GetMonth', value: 'itemvalue', text: 'text' });

            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/ProjectManager/ProjectAttenceRecord/Form',
                    width: 600,
                    height: 400,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('Project_AttenceRecordId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/ProjectManager/ProjectAttenceRecord/Form?keyValue=' + keyValue,
                        width: 600,
                        height: 400,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('Project_AttenceRecordId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/ProjectManager/ProjectAttenceRecord/DeleteForm', { keyValue: keyValue}, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            // 导入
            $('#lr_export').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '导入',
                    url: top.$.rootUrl + '/ProjectManager/ProjectAttenceRecord/ExcelImport',
                    width: 600,
                    height: 250,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 打印
            $('#lr_print').on('click', function () {
                $('#gridtable').jqprintTable();
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/ProjectManager/ProjectAttenceRecord/GetPageList',
                headData: [
                    {
                        label: "所属项目", name: "F_ProjectId", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('custmerData', {
                                url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'DC_EngineProject_ProjectInfo',
                                key: value,
                                keyId: 'f_piid',
                                callback: function (_data) {
                                    callback(_data['f_projectname']);
                                }
                            });
                        }
                    },
                    { label: "考勤月份", name: "F_Month", width: 100, align: "left" },
                    { label: "打卡人姓名", name: "F_CreateUserName", width: 100, align: "left"},
                    { label: "所在班组", name: "F_Class", width: 100, align: "left" },
                    { label: "机器号", name: "Project_mode", width: 100, align: "left" },
                    { label: "编号", name: "Project_code", width: 100, align: "left" },
                    { label: "监理单位", name: "F_SupervisionCompany", width: 100, align: "left" },
                    { label: "施工单位", name: "F_constructionCompany", width: 100, align: "left" },
                    { label: "考勤天数", name: "Project_Attencedays", width: 100, align: "left" },
                    { label: "考勤号码", name: "Project_Attencednumber", width: 100, align: "left" },
                    { label: "对比方式", name: "Project_compare", width: 100, align: "left" },
                    { label: "上午打卡时间", name: "F_FirstAttenceDateTime", width: 100, align: "left"},
                    { label: "下午打卡时间", name: "F_SecondAttenceDateTime", width: 100, align: "left"},
                    { label: "备注说明", name: "F_Description", width: 100, align: "left"},
                ],
                mainId:'Project_AttenceRecordId',
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
