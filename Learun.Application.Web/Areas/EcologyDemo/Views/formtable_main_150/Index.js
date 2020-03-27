/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-12-04 14:52
 * 描  述：formtable_main_150
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
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('id');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/EcologyDemo/formtable_main_150/Form?keyValue=' + keyValue,
                        width: 600,
                        height: 400,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/EcologyDemo/formtable_main_150/GetPageList',
                headData: [
                    { label: "项目名称", name: "xmmc", width: 100, align: "left"},
                    { label: "部门", name: "bm", width: 100, align: "left"},
                    { label: "月度", name: "yd", width: 100, align: "left"},
                    { label: "进度（%）", name: "jd", width: 100, align: "left"},
                    { label: "填写时间", name: "txsj", width: 100, align: "left"},
                    { label: "汇报内容", name: "hbnr", width: 100, align: "left"},
                    { label: "下月计划", name: "xyjh", width: 100, align: "left"},
                    { label: "备注", name: "bz", width: 100, align: "left"},
                ],
                mainId:'id',
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
