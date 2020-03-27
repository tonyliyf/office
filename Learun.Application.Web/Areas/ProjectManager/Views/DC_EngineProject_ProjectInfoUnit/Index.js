/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-03-09 15:56
 * 描  述： 勘测单位信息管理
 */
var refreshGirdData;
var query;
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
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfoUnit/Form?F_UnitType=1',
                    width: 600,
                    height: 400,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_PIUId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfoUnit/Form?keyValue=' + keyValue,
                        width: 600,
                        height: 400,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });

            //评价查询
            $('#lr_evlaution').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_PIUId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '勘测单位评价查询',
                        url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfoUnit/Form1?keyValue=' + keyValue,
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
                var keyValue = $('#gridtable').jfGridValue('F_PIUId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfoUnit/DeleteForm', { keyValue: keyValue}, function () {
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
                    url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfoUnit/ExportExcel',
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
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfoUnit/GetPageList?F_UnitType=勘测单位',
                headData: [
                    { label: "单位名称", name: "F_UnitName", width: 100, align: "left" },
                    { label: "评价等级", name: "F_Evaluation", width: 100, align: "left" },
                    { label: "资质证书", name: "F_CerticateZizi", width: 100, align: "left" },
                    { label: "公司法人", name: "F_Manager", width: 100, align: "left" },
                    { label: "营业执照号码", name: "F_CertifacateNo", width: 100, align: "left" },
                    { label: "单位联系人", name: "F_UnitContact", width: 100, align: "left"},
                    { label: "联系人电话", name: "F_UnitContactPhone", width: 100, align: "left"},
                    { label: "单位地址", name: "F_UnitAddress", width: 100, align: "left"},
                    { label: "备注", name: "F_Remarks", width: 100, align: "left"},
                ],
                mainId:'F_PIUId',
                isPage: true
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            query = param;
            $('#gridtable').jfGridSet('reload',{ queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
