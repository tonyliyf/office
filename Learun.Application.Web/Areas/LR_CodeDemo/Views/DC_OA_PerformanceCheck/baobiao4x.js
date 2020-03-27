/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn) 
 * Copyright (c) 2013-2018 上海力软信息技术有限公司 
 * 创建人：超级管理员 
 * 日  期：2019-04-11 12:25 
 * 描  述：DC_OA_PerformanceCheck 
 */
var refreshGirdData;
var bootstrap = function ($, learun) {
    var startTime;
    var endTime;
    var page = {
        init: function () {
            page.initGird();
            page.bind();
        },
        bind: function () {
            //// 初始化左侧树形数据 
            //$('#dataTree').lrtree({
            //    url: top.$.rootUrl + '/LR_CodeDemo/WfTree/GetDeptTree',
            //    nodeClick: function (item) {
            //        page.search({ F_OA_AttenceDeptId: item.value });
            //    }
            //});
            // 初始化左侧树形数据
            $('#dataTree').lrtree({
                url: top.$.rootUrl + '/LR_CodeDemo/WfTree/GetDeptTree',
                nodeClick: function (item) {
                    page.search({ F_OA_AttenceDeptId: item.id });

                }
            });
             //时间搜索框 
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
            // 编辑 
            $('#lr_edit').on('click', function () {
              
                var keyValue = $('#gridtable').jfGridValue('F_EmpolyeeCheckId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceCheck/baobiao4xForm?keyValue=' + keyValue,
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
                var keyValue = $('#gridtable').jfGridValue('F_EmpolyeeCheckId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceCheck/DeleteForm', { keyValue: keyValue }, function () {
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
                url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceCheck/GetPageList4',
                headData: [
                  
                    {
                        label: "员工", name: "F_CheckUserid", width: 150, align: "left",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('user', {
                                key: value,
                                callback: function (_data) {
                                    callback(_data.name);
                                }
                            });
                        }
                    },
                    { label: "考核类别", name: "F_TimeType", width: 100, align: "left" },
                    { label: "基准分", name: "F_BaseNumber", width: 100, align: "left" },
                    { label: "绩效小组扣分", name: "F_JixaoNumber", width: 100, align: "left" },
                    { label: "上级领导扣分", name: "F_CheckNumber", width: 100, align: "left" },
                    { label: "扣分合计", name: "F_KofenNum", width: 100, align: "left" },
                    { label: "加分", name: "F_AddNumber", width: 100, align: "left" },
                    { label: "最终得分", name: "F_JiafenNum", width: 100, align: "left" },
                    { label: "扣分说明", name: "F_RecNumberComments", width: 100, align: "left" },
                    { label: "加分说明", name: "F_AddNumberComments", width: 100, align: "left" },
                ],
                mainId: 'F_EmpolyeeCheckId',
                isPage: true
            });
            page.search();

        },
        search: function (param) {
            param = param || {};
            param.StartTime = startTime;
            param.EndTime = endTime;
            $('#gridtable').jfGridSet('reload', { queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
} 
