/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-24 09:40
 * 描  述：DC_OA_PerformanceAppraisal
 */
var refreshGirdData;
var tid
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
                url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceAppraisal/GetTree',
                nodeClick: function (item) {
                    tid = item.value
                    page.search({ F_PATId: item.value });
                }
            });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                if (!tid) {
                    learun.alert.error('请选择模板')
                    return
                }
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceAppraisal/Form?tid=' + tid,
                    width: 600,
                    height: 600,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                if (!tid) {
                    learun.alert.error('请选择模板')
                    return
                }
                var keyValue = $('#gridtable').jfGridValue('F_PAId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceAppraisal/Form?keyValue=' + keyValue + '&tid=' + tid,
                        width: 600,
                        height: 600,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                if (!tid) {
                    learun.alert.error('请选择模板')
                    return
                }
                var keyValue = $('#gridtable').jfGridValue('F_PAId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceAppraisal/DeleteForm', { keyValue: keyValue }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            //编辑模板
            $('#btn_edit').on('click', function () {
                learun.layerForm({
                    id: 't___form',
                    title: '编辑',
                    url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceAppraisalTemplate/index',
                    width: 800,
                    height: 800,
                    btn: null,
                    end: function (id) {
                        location.reload()
                    }
                });
            });
            // 添加岗位
            $('#btn_bind').on('click', function () {
                if (tid) {
                    learun.layerForm({
                        id: 'form',
                        title: '添加岗位',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceAppraisal/SelectForm?tid=' + tid,
                        width: 800,
                        height: 520,
                        callBack: function (id) {
                            return top[id].acceptClick();
                        }
                    });
                } else {
                    learun.alert.error('请选择模板')
                    return
                }
            });
            // 查看岗位
            $('#btn_info').on('click', function () {
                if (!tid) {
                    learun.alert.error('请选择模板')
                    return
                }
                learun.layerForm({
                    id: 'form',
                    title: '查看岗位',
                    url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceAppraisal/LookForm?tid=' + tid,
                    width: 800,
                    height: 520,
                    btn: null
                });

            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceAppraisal/GetList',
                headData: [
                    { label: "排序", name: "F_Sort", width: 100, align: "center" },
                    { label: "指标名称", name: "F_TargetName", width: 200, align: "center" },
                    { label: "指标内容", name: "F_TargetContent", width: 177, align: "center" },
                    //{ label: "考核目标", name: "F_Target", width: 199, align: "center" },
                    //{ label: "评分说明", name: "F_TargetExplain", width: 370, align: "center" },
                    { label: "指标分值", name: "F_TargetScore", width: 100, align: "center" },
                    {
                        label: "是否自填项", name: "F_IfTargetDefine", width: 100, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'YesOrNo',
                                callback: function (_data) {
                                    var text;
                                    if (_data.text == "是") {
                                        text = '<span class="label label-success">自填项</span>'
                                    } else {
                                        text = '<span class="label label-default">非自填项</span>'
                                    }
                                    callback(text);
                                }
                            });
                        }
                    },
                ],
                mainId: 'F_PAId',
                parentId: 'F_ParentId',
                isTree: true
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            $('#gridtable').jfGridSet('reload', { queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
