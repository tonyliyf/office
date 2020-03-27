/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-11-14 15:07
 * 描  述：formtable_main_140_dt1
 */
var refreshGirdData;
var keyValue1 = request('keyValue');

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
            //// 新增
            //$('#lr_add').on('click', function () {
            //    learun.layerForm({
            //        id: 'form',
            //        title: '新增',
            //        url: top.$.rootUrl + '/EcologyDemo/formtable_main_140_dt1/Form?keyValue=' + keyValue1,
            //        width: 600,
            //        height: 400,
            //        callBack: function (id) {
            //            return top[id].acceptClick(refreshGirdData);
            //        }
            //    });
            //});
            //// 编辑
            //$('#lr_edit').on('click', function () {
            //    var keyValue = keyValue1;
            //    if (learun.checkrow(keyValue)) {
            //        learun.layerForm({
            //            id: 'form',
            //            title: '编辑',
            //            url: top.$.rootUrl + '/EcologyDemo/formtable_main_140_dt1/Form?keyValue=' + keyValue,
            //            width: 600,
            //            height: 400,
            //            callBack: function (id) {
            //                return top[id].acceptClick(refreshGirdData);
            //            }
            //        });
            //    }
            //});
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/EcologyDemo/formtable_main_140_dt1/GetPageList',
                headData: [
                    { label: "广告名称", name: "ggmc", width: 100, align: "left"},
                    { label: "产权人", name: "cqr", width: 100, align: "left"},
                    { label: "招租日期", name: "zzksrq", width: 100, align: "left"},
                    { label: "招租年限", name: "zznx", width: 100, align: "left"},
                    { label: "招租底价", name: "zzdj", width: 100, align: "left"},
                    { label: "招租价格", name: "zzjg", width: 100, align: "left"},
                    { label: "招租数量", name: "zzsl", width: 100, align: "left"},
                ],
                mainId:'id',
                isPage: true
            });
            page.search({ keyValue1: keyValue1 });
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
