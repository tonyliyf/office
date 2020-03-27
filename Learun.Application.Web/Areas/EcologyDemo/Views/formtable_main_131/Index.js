/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-09-16 16:28
 * 描  述：formtable_main_131
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
            //查看
            $('#lr_add').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('id');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '查看',
                        url: top.$.rootUrl + '/EcologyDemo/formtable_main_131/Form?keyValue=' + keyValue,
                        width: 600,
                        height: 600,
                        btn: null
                    });
                }
            });
            //// 新增
            //$('#lr_add').on('click', function () {
            //    learun.layerForm({
            //        id: 'form',
            //        title: '新增',
            //        url: top.$.rootUrl + '/EcologyDemo/formtable_main_131/Form',
            //        width: 600,
            //        height: 400,
            //        callBack: function (id) {
            //            return top[id].acceptClick(refreshGirdData);
            //        }
            //    });
            //});
            //// 编辑
            //$('#lr_edit').on('click', function () {
            //    var keyValue = $('#gridtable').jfGridValue('id');
            //    if (learun.checkrow(keyValue)) {
            //        learun.layerForm({
            //            id: 'form',
            //            title: '编辑',
            //            url: top.$.rootUrl + '/EcologyDemo/formtable_main_131/Form?keyValue=' + keyValue,
            //            width: 600,
            //            height: 400,
            //            callBack: function (id) {
            //                return top[id].acceptClick(refreshGirdData);
            //            }
            //        });
            //    }
            //});
            //// 删除
            //$('#lr_delete').on('click', function () {
            //    var keyValue = $('#gridtable').jfGridValue('id');
            //    if (learun.checkrow(keyValue)) {
            //        learun.layerConfirm('是否确认删除该项！', function (res) {
            //            if (res) {
            //                learun.deleteForm(top.$.rootUrl + '/EcologyDemo/formtable_main_131/DeleteForm', { keyValue: keyValue}, function () {
            //                    refreshGirdData();
            //                });
            //            }
            //        });
            //    }
            //});
            //// 打印
            //$('#lr_print').on('click', function () {
            //    $('#gridtable').jqprintTable();
            //});
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/EcologyDemo/formtable_main_131/GetPageList',
                headData: [
                    { label: "设备名称", name: "F_EquipmentName", width: 120, align: "left"},
                    { label: "申请用户", name: "lastname", width: 100, align: "left" },
                    { label: "维修金额", name: "yjwxje", width: 100, align: "left" },
                    { label: "申请维修日期", name: "wxrq", width: 100, align: "left"},
                    { label: "故障描述", name: "gzms", width: 300, align: "left"},
                    { label: "维修地点", name: "wxdd", width: 200, align: "left"},
                ],
                mainId:'id',
                isPage: true,
                dblclick: function (rowdata) {
                    learun.layerForm({
                        id: 'form',
                        title: '查看',
                        url: top.$.rootUrl + '/EcologyDemo/formtable_main_131/Form?keyValue=' + rowdata.mainId,
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
            $('#gridtable').jfGridSet('reload',{ queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
