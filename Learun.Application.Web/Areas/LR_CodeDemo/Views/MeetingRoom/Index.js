/* * 版 本 Learun-ADMS V7.0.0 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-03 17:44
 * 描  述：会议室管理
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
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/LR_CodeDemo/MeetingRoom/Form',
                    width: 600,
                    height: 400,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('Dc_OA_MeetingRoomId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/LR_CodeDemo/MeetingRoom/Form?keyValue=' + keyValue,
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
                var keyValue = $('#gridtable').jfGridValue('Dc_OA_MeetingRoomId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/LR_CodeDemo/MeetingRoom/DeleteForm', { keyValue: keyValue }, function () {
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
            $('#lr_detail').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('Dc_OA_MeetingRoomId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '会议室日程',
                        url: top.$.rootUrl + '/LR_CodeDemo/MeetingRoom/Detail?keyValue=' + keyValue,
                        width: 1100,
                        height: 900,
                        callBack: function (id) {
                            return top[id].acceptClick(function () { });
                        }
                    });
                }
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/LR_CodeDemo/MeetingRoom/GetPageList',
                headData: [
                    { label: "会议室名称", name: "DC_OA_MeetingRoomName", width: 335, align: "center" },
                    { label: "会议室编号", name: "F_RoomNo", width: 120, align: "center" },
                    { label: "可容纳人数", name: "F_Container", width: 120, align: "center" },
                    { label: "会议室地点", name: "DC_OA_MeetingRoomPlace", width: 400, align: "center" },
                    { label: "使用状态", name: "DC_OA_MeetingRoomState", width: 100, align: "center" },
                ],
                mainId: 'Dc_OA_MeetingRoomId',
                isPage: true
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
