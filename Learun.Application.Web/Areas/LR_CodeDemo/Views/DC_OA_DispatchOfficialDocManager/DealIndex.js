/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-14 12:10
 * 描  述：收文管理
 */
var refreshGirdData;
var bootstrap = function ($, learun) {
    "use strict";
    var processId = '';
    var startTime
    var endTime
    var page = {
        init: function () {
            page.initGird();
            page.bind();
        },
        bind: function () {
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
            $('#processState').lrselect({
                url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_DispatchOfficialDocManager/GetProcessStep',
                value: 'key',
                text: 'value'
            })
            $('#F_DepartmentId').lrDepartmentSelect();
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 打印
            $('#lr_print').on('click', function () {
                $('#gridtable').jqprintTable();
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_DispatchOfficialDocManager/GetDealIndexPageList',
                headData: [
                    {
                        label: "来文单位", name: "department", width: 200, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('department', {
                                key: value,
                                callback: function (_data) {
                                    callback(_data.name);
                                }
                            });
                        }
                    },
                    { label: "文件字号", name: "filecode", width: 200, align: "center" },
                    {
                        label: "收文时间", name: "date", width: 100, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                            if (value.length <= 10) {
                                callback(value);
                            } else {
                                callback(value.substring(0, 10));
                            }
                        }
                    },
                    {
                        label: "文件标题", name: "title", width: 300, align: "center"
                    },
                    {
                        label: "拟办意见", name: "advice", width: 300, align: "center"
                    },
                    {
                        label: "传递进度", name: "step", width: 300, align: "center"
                    },
                    {
                        label: "办理结果", name: "result", width: 100, align: "center"
                    },
                ],
                mainId: 'F_RODId',
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
    refreshGirdData = function (res, postData) {
        if (res.code == 200) {
            learun.workflowapi.create({
                isNew: true,
                schemeCode: 'JRYReceiveFile',// 填写流程对应模板编号
                processId: processId,
                processName: '系统表单流程',// 对应流程名称
                processLevel: '1',
                description: '',
                formData: JSON.stringify(postData),
                callback: function (res, data) {
                    alert('222')
                }
            });
            page.search();
        }
    };
    page.init();
}
