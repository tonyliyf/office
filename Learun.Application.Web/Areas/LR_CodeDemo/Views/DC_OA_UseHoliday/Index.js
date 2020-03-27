/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-19 15:47
 * 描  述：DC_OA_UseHoliday
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
            // 初始化左侧树形数据
            $('#dataTree').lrtree({
                url: top.$.rootUrl + '/LR_CodeDemo/WfTree/GetDeptTree',
                nodeClick: function (item) {
                    page.search({ F_DepartmentId: item.id });
                }
            });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_UserId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_UseHoliday/Form?keyValue=' + keyValue,
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
                learun.layerConfirm('是否清空年假记录！', function (res) {
                    if (res) {
                        learun.deleteForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_UseHoliday/DeleteForm', {}, function () {
                            refreshGirdData();
                        });
                    }
                });

            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_UseHoliday/GetPageList',
                headData: [
                    { label: "姓名", name: "F_RealName", width: 100, align: "center" },
                    {
                        label: "部门", name: "F_DepartmentId", width: 150, align: "center", formatterAsync: function (callback, value, row) {
                            learun.clientdata.getAsync('department', {
                                key: value,
                                callback: function (item) {
                                    callback(item.name);
                                }
                            });
                        }
                    },
                    {
                        label: "公司", name: "F_CompanyId", width: 150, align: "center", formatterAsync: function (callback, value, row) {
                            learun.clientdata.getAsync('company', {
                                key: value,
                                callback: function (item) {
                                    callback(item.name);
                                }
                            });
                        }
                    },
                    {
                        label: "入职时间", name: "F_JoinDate", width: 100, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                            if (value.length <= 10) {
                                callback(value);
                            } else {
                                callback(value.substring(0, 10));
                            }
                        }
                    },
                    {
                        label: "参加工作时间", name: "F_StartWorkDate", width: 100, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                            if (value.length <= 10) {
                                callback(value);
                            } else {
                                callback(value.substring(0, 10));
                            }
                        }
                    },
                    { label: "年假天数", name: "F_Account", width: 100, align: "center" },
                    { label: "已休年假天数", name: "F_Password", width: 100, align: "center" },
                ],
                mainId: 'F_UserId',
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
