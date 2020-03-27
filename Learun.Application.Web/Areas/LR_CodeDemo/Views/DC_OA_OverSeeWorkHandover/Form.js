/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-28 12:11
 * 描  述：DC_OA_OverSeeWorkHandover
 */
var refreshGirdData;
var acceptClick;
var keyValue = request('keyValue');
// 设置权限
var setAuthorize;
// 设置表单数据
var setFormData;
// 验证数据是否填写完整
var validForm;
// 保存数据
var save;
var OSID
var bootstrap = function ($, learun) {
    "use strict";
    // 设置权限
    setAuthorize = function (data) {
    };
    var page = {
        init: function () {
            $('.lr-form-wrap').lrscroll();
            page.bind();
            page.initData();
        },
        bind: function () {
            //表格
            // 新增
            if (parent.location.search.indexOf('type=create') >= 0) {
                $('#F_Attachments').DocUploader({ upLoad: true })
                OSID = learun.newGuid()
                $('#lr_add').on('click', function () {
                    learun.layerForm({
                        id: 'form',
                        title: '新增',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkHandoverDetail/Form?OSID=' + OSID,
                        width: 600,
                        height: 600,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                });
                // 编辑
                $('#lr_edit').on('click', function () {
                    var keyValue = $('#gridtable').jfGridValue('F_OWHDId');
                    if (learun.checkrow(keyValue)) {
                        learun.layerForm({
                            id: 'form',
                            title: '编辑',
                            url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkHandoverDetail/Form?OSID=' + OSID + '&keyValue=' + keyValue,
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
                    var keyValue = $('#gridtable').jfGridValue('F_OWHDId');
                    if (learun.checkrow(keyValue)) {
                        learun.layerConfirm('是否确认删除该项！', function (res) {
                            if (res) {
                                learun.deleteForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkHandoverDetail/DeleteForm', { keyValue: keyValue }, function () {
                                    refreshGirdData();
                                });
                            }
                        });
                    }
                });
                $('#lr_info').hide()
            } else {
                $('#F_Attachments').DocUploader({ downLoad: true })
                $('#lr_add,#lr_edit,#lr_delete').hide()
                $('#lr_info').on('click', function () {
                    var keyValue = $('#gridtable').jfGridValue('F_OWHDId');
                    if (learun.checkrow(keyValue)) {
                        learun.layerForm({
                            id: '______form',
                            title: '查看',
                            url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkHandoverDetail/Form?OSID=' + OSID + '&keyValue=' + keyValue,
                            width: 600,
                            height: 600,
                            btn: null
                        });
                    }
                });
                OSID = parent.processId
            }

        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkHandover/GetFormData?keyValue=' + keyValue, function (data) {
                    for (var id in data) {
                        if (!!data[id].length && data[id].length > 0) {
                            $('#' + id).jfGridSet('refreshdata', data[id]);
                        }
                        else {
                            $('[data-table="' + id + '"]').lrSetFormData(data[id]);
                        }
                    }
                });
            }
            //表格
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkHandoverDetail/GetPageList',
                headData: [
                    { label: "编 码", name: "F_OSWCode", width: 100, align: "center" },
                    {
                        label: "牵头部门", name: "F_DepartmentId", width: 100, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('department', {
                                key: value,
                                callback: function (_data) {
                                    callback(_data.name);
                                }
                            });
                        }
                    },
                    {
                        label: "负责人", name: "F_LeaderUser", width: 100, align: "center"
                    },
                    {
                        label: "责任领导", name: "F_HighLeaderId", width: 100, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('user', {
                                key: value,
                                callback: function (_data) {
                                    callback(_data.name);
                                }
                            });
                        }
                    },
                    {
                        label: "督办人", name: "F_OverSeeUserId", width: 100, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('user', {
                                key: value,
                                callback: function (_data) {
                                    callback(_data.name);
                                }
                            });
                        }
                    },
                    {
                        label: "督办分类", name: "F_OSWType", width: 100, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'OverSeeType',
                                callback: function (_data) {
                                    callback(_data.text);
                                }
                            });
                        }
                    },
                    {
                        label: "开始时间", name: "F_BeginDate", width: 100, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                            if (value.length <= 10) {
                                callback(value);
                            } else {
                                callback(value.substring(0, 10));
                            }
                        }
                    },
                    {
                        label: "结束时间", name: "F_EndDate", width: 100, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                            if (value.length <= 10) {
                                callback(value);
                            } else {
                                callback(value.substring(0, 10));
                            }
                        }
                    },
                    { label: "工作事项", name: "F_OSWContent", width: 300, align: "center" },
                    { label: "备注", name: "F_Marks", width: 100, align: "center" },
                ],
                mainId: 'F_OWHDId',
                isPage: true
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            param.F_DOHId = OSID
            $('#gridtable').jfGridSet('reload', { queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    // 设置表单数据
    setFormData = function (processId) {
        if (!!processId) {
            $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkHandover/GetFormDataByProcessId?processId=' + processId, function (data) {
                for (var id in data) {
                    if (!!data[id] && data[id].length > 0) {
                        $('#' + id).jfGridSet('refreshdata', data[id]);
                    }
                    else {
                        if (id == 'DC_OA_OverSeeWorkHandover' && data[id]) {
                            keyValue = data[id].F_DOHId;
                        }
                        $('[data-table="' + id + '"]').lrSetFormData(data[id]);
                    }
                }
            });
        }
    }
    // 验证数据是否填写完整
    validForm = function () {
        if (!$('body').lrValidform()) {
            return false;
        }
        return true;
    };
    // 保存数据
    save = function (processId, callBack, i) {
        var formData = $('body').lrGetFormData();
        if (!!processId) {
            formData.F_DOHId = processId;
        }
        var postData = {
            strEntity: JSON.stringify(formData),
            oldId: OSID
        };
        $.lrSaveForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkHandover/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack(res, i);
            }
        });
    };
    page.init();
}
