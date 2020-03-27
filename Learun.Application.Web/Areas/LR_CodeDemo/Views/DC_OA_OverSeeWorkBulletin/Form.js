/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-03-01 15:48
 * 描  述：DC_OA_OverSeeWorkBulletin
 */
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
            $('#F_Attachments').lrUploader();
            $('#sel_ids').lrDataSourceSelect({
                code: 'OSTaskData',
                value: 'id',
                text: 'name',
                type: 'multiple',
                select: function (data) {
                    if (data && parent.location.search.indexOf('type=create') >= 0) {
                        learun.loading(true, '正在获取数据')
                        $.post(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkBulletin/StatisticsWorkByWorkIds',
                            { workIds: $('#sel_ids').lrselectGet() },
                            function (res) {
                                learun.loading(false)
                                if (res.code == 200) {
                                    $('#DC_OA_OverSeeWorkBulletinDetailed').jfGridSet('refreshdata', res.data);
                                } else {
                                    learun.alert.error(res.info)
                                }
                            },
                            'json'
                        )
                    }
                }
            });
            $('#DC_OA_OverSeeWorkBulletinDetailed').jfGrid({
                headData: [
                    {
                        label: '序号', name: 'F_code', width: 100, align: "center"
                    },
                    {
                        label: '任务名称', name: 'F_TaskName', width: 100, align: "center"
                    },
                    {
                        label: '任务描述', name: 'F_TaskContent', width: 100, align: "center"
                    },
                    {
                        label: '关键节点', name: 'F_TaskNode', width: 100, align: "center"
                    },
                    {
                        label: '节点时间', name: 'F_TaskNodeDate', width: 100, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                            if (value.length <= 10) {
                                callback(value);
                            } else {
                                callback(value.substring(0, 10));
                            }
                        }
                    },
                    {
                        label: '主办单位', name: 'F_OneDepartment', width: 100, align: "center", align: "center",
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
                        label: '主办人', name: 'F_OneUser', width: 100, align: "center", align: "center",
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
                        label: '主办领导', name: 'F_OneLeader', width: 100, align: "center", align: "center",
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
                        label: '协办单位', name: 'F_TwoDepartment', width: 300, align: "center"
                    },
                    {
                        label: '协办人', name: 'F_TwoUser', width: 300, align: "center"
                    },
                    {
                        label: '执行情况', name: 'F_ExecuteContent', width: 500, align: "center"
                    },
                    {
                        label: '状态', name: 'F_State', width: 100, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'OS_F_State',
                                callback: function (_data) {
                                    var text;
                                    switch (_data.text) {
                                        case '执行':
                                            text = '<span class="label label-info">执行</span>'
                                            break;
                                        case '暂停':
                                            text = '<span class="label label-warning">暂停</span>'
                                            break;
                                        case '终止':
                                            text = '<span class="label label-danger">终止</span>'
                                            break;
                                        case '完成':
                                            text = '<span class="label label-success">完成</span>'
                                            break;
                                        default:
                                            text = _data.text
                                            break;
                                    }
                                    callback(text);
                                }
                            });
                        }
                    },
                ],
                height: 400
            });
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkBulletin/GetFormData?keyValue=' + keyValue, function (data) {
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
        }
    };
    // 设置表单数据
    setFormData = function (processId) {
        if (!!processId) {
            $('#div_create').hide()
            $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkBulletin/GetFormDataByProcessId?processId=' + processId, function (data) {
                for (var id in data) {
                    if (!!data[id] && data[id].length > 0) {
                        $('#' + id).jfGridSet('refreshdata', data[id]);
                    }
                    else {
                        if (id == 'DC_OA_OverSeeWorkBulletin' && data[id]) {
                            keyValue = data[id].F_DOBId;
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
        var postData = {};
        var formData = $('[data-table="DC_OA_OverSeeWorkBulletin"]').lrGetFormData();
        if (!!processId) {
            formData.F_DOBId = processId;
        }
        postData.strEntity = JSON.stringify(formData);
        postData.workIds = $('#sel_ids').lrselectGet()
        $.lrSaveForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkBulletin/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack(res, i);
            }
        });
    };
    page.init();
}
