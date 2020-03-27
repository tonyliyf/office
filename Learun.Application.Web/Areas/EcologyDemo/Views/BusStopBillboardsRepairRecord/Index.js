/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-09-06 11:15
 * 描  述：广告牌维修记录
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
            //// 新增
            //$('#lr_add').on('click', function () {
            //    learun.layerForm({
            //        id: 'form',
            //        title: '新增',
            //        url: top.$.rootUrl + '/EcologyDemo/BusStopBillboardsRepairRecord/Form',
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
            //            url: top.$.rootUrl + '/EcologyDemo/BusStopBillboardsRepairRecord/Form?keyValue=' + keyValue,
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
            //                learun.deleteForm(top.$.rootUrl + '/EcologyDemo/BusStopBillboardsRepairRecord/DeleteForm', { keyValue: keyValue}, function () {
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
            //查看
            $('#lr_add').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('id');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '查看',
                        url: top.$.rootUrl + '/EcologyDemo/BusStopBillboardsRepairRecord/Form?keyValue=' + keyValue,
                        width: 600,
                        height: 600,
                        btn: null
                    });
                }
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/EcologyDemo/BusStopBillboardsRepairRecord/GetPageList',
                headData: [
                    { label: "广告牌名称", name: "F_BillboardsName", width: 150, align: "left" },
                    { label: "地址", name: "F_InstallationLocation", width: 200, align: "left" },
                    { label: "申请人", name: "lastname", width: 120, align: "left" },
                    { label: "维修金额", name: "yjwxje", width: 100, align: "left" },
                    { label: "申请日期", name: "rq", width: 100, align: "left" },
                   
                    { label: "故障描述", name: "gzms", width: 300, align: "left" },
                   
                 
                   
                ],
                mainId:'id',
                isPage: true,
                dblclick: function (rowdata) {
                    learun.layerForm({
                        id: 'form',
                        title: '查看',
                        url: top.$.rootUrl + '/EcologyDemo/BusStopBillboardsRepairRecord/Form?keyValue=' + rowdata.mainId,
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
