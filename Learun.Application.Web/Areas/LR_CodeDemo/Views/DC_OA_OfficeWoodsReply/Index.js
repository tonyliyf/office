/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-26 16:28
 * 描  述：DC_OA_OfficeWoodsReply
 */
var refreshGirdData;
var bootstrap = function ($, learun) {
    "use strict";
    var processId = '';
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
                    url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_OfficeWoodsReply/Form',
                    width: 600,
                    height: 400,
                    callBack: function (id) {
                        var res = false;
                        // 验证数据
                        res = top[id].validForm();
                        // 保存数据
                        if (res) {
                            processId = learun.newGuid();
                            res = top[id].save(processId, refreshGirdData);
                        }
                        return res;
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_OfficeWoodsReplyId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_OfficeWoodsReply/Form?keyValue=' + keyValue,
                        width: 600,
                        height: 400,
                        callBack: function (id) {
                            var res = false;
                            // 验证数据
                            res = top[id].validForm();
                            // 保存数据
                            if (res) {
                                res = top[id].save('', function () {
                                    page.search();
                                });
                            }
                            return res;
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_OfficeWoodsReplyId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OfficeWoodsReply/DeleteForm', { keyValue: keyValue}, function () {
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
                url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_OfficeWoodsReply/GetPageList',
                headData: [
                    { label: "申请单号", name: "F_ReplyIdNo", width: 100, align: "left"},
                    { label: "申请月度", name: "F_ReplyMonth", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op,$cell) {
                             learun.clientdata.getAsync('custmerData', {
                                 url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'GetMonth',
                                 key: value,
                                 keyId: 'itemvalue',
                                 callback: function (_data) {
                                     callback(_data['text']);
                                 }
                             });
                        }},
                    { label: "申请公司", name: "F_CurrentCompanyId", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op,$cell) {
                             learun.clientdata.getAsync('company', {
                                 key: value,
                                 callback: function (_data) {
                                     callback(_data.name);
                                 }
                             });
                        }},
                    { label: "申请部门", name: "F_CurrentDeptId", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op,$cell) {
                             learun.clientdata.getAsync('department', {
                                 key: value,
                                 callback: function (_data) {
                                     callback(_data.name);
                                 }
                             });
                        }},
                    { label: "申请人", name: "F_CreateUserId", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op,$cell) {
                             learun.clientdata.getAsync('user', {
                                 key: value,
                                 callback: function (_data) {
                                     callback(_data.name);
                                 }
                             });
                        }},
                    { label: "申请日期", name: "F_CreateDate", width: 100, align: "left"},
                    { label: "附件", name: "F_File", width: 100, align: "left"},
                    { label: "备注", name: "F_Description", width: 100, align: "left"},
                ],
                mainId:'F_OfficeWoodsReplyId',
                isPage: true
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            $('#gridtable').jfGridSet('reload',{ queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function (res, postData) {
        if (res.code == 200)
        {
            // 发起流程
            learun.workflowapi.create({
                isNew: true,
                schemeCode: 'DC_OA_OfficeWoodsReplyPart',// 填写流程对应模板编号
                processId: processId,
                processName: '系统表单流程',// 对应流程名称
                processLevel: '1',
                description: '',
                formData: JSON.stringify(postData),
                callback: function (res, data) {
                }
            });
            page.search();
        }
    };
    page.init();
}
