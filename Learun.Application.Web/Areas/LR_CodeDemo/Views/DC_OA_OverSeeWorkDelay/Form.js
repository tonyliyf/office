/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-03-02 16:37
 * 描  述：DC_OA_OverSeeWorkDelay
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
            $('#F_OSWId').lrDataSourceSelect({
                code: 'OSTaskUncompleteData', value: 'f_oswid', text: 'f_oswcontent', select: function (rowData) {
                    if (rowData && parent.location.search.indexOf('type=create') >= 0) {
                        learun.loading(true, '正在获取数据')
                        $.post(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkDelay/GetInitData',
                            { keyValue: rowData.f_oswid },
                            function (res) {
                                learun.loading(false)
                                if (res.code == 200) {
                                    $('#DC_OA_OverSeeWorkDelayDetailed').jfGridSet('refreshdata', res.data.DC_OA_OverSeeWorkDelayDetailed);
                                    delete res.data.DC_OA_OverSeeWorkDelay.F_OSWId
                                    $('[data-table="DC_OA_OverSeeWorkDelay"]').lrSetFormData(res.data.DC_OA_OverSeeWorkDelay);
                                } else {
                                    learun.alert.error(res.info)
                                }
                            },
                            'json'
                        )
                    }
                }
            });
            $('#F_Attachments').lrUploader();
            $('#F_DepartmentId').lrselect({
                type: 'tree',
                allowSearch: true,
                url: top.$.rootUrl + '/LR_OrganizationModule/Department/GetTree',
                param: {}
            });
            $('#F_LeaderUserId').lrformselect({
                layerUrl: false,
                layerUrlW: 400,
                layerUrlH: 300,
                dataUrl: top.$.rootUrl + '/LR_OrganizationModule/User/GetListByUserIds'
            });
            $('#F_OverSeeUserId').lrformselect({
                layerUrl: false,
                layerUrlW: 400,
                layerUrlH: 300,
                dataUrl: top.$.rootUrl + '/LR_OrganizationModule/User/GetListByUserIds'
            });
            $('#F_HighLeaderId').lrformselect({
                layerUrl: false,
                layerUrlW: 400,
                layerUrlH: 300,
                dataUrl: top.$.rootUrl + '/LR_OrganizationModule/User/GetListByUserIds'
            });
            $('#F_OSWType').lrDataItemSelect({ code: 'OverSeeType' });
            $('#DC_OA_OverSeeWorkDelayDetailed').jfGrid({
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
                        label: '起始时间', name: 'F_TaskNodeDateFirst', width: 100, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                            if (value.length <= 10) {
                                callback(value);
                            } else {
                                callback(value.substring(0, 10));
                            }
                        }
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
                        label: '关键节点', name: 'F_TaskNode', width: 100, align: "center"
                    },
                    {
                        label: '主办单位', name: 'F_OneDepartment', width: 100, align: "center"
                    },
                    {
                        label: '主办人', name: 'F_OneUser', width: 100, align: "center"
                    },
                    {
                        label: '主办领导', name: 'F_OneLeader', width: 100, align: "center"

                    },
                    {
                        label: '协办单位', name: 'F_TwoDepartment', width: 100, align: "center"
                    },
                    {
                        label: '协办人', name: 'F_TwoUser', width: 100, align: "center"
                    },
                    {
                        label: '执行情况', name: 'F_ExecuteContent', width: 100, align: "center"
                    },
                    {
                        label: '任务状态', name: 'F_State', width: 100, align: "center"
                    },
                ],
                isEdit: true,
                height: 400
            });
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkDelay/GetFormData?keyValue=' + keyValue, function (data) {
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
            $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkDelay/GetFormDataByProcessId?processId=' + processId, function (data) {
                for (var id in data) {
                    if (!!data[id] && data[id].length > 0) {
                        $('#' + id).jfGridSet('refreshdata', data[id]);
                    }
                    else {
                        if (id == 'DC_OA_OverSeeWorkDelay' && data[id]) {
                            keyValue = data[id].F_OSWDId;
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
        var formData = $('[data-table="DC_OA_OverSeeWorkDelay"]').lrGetFormData();
        if (!!processId) {
            formData.F_OSWDId = processId;
        }
        postData.strEntity = JSON.stringify(formData);
        postData.strdC_OA_OverSeeWorkDelayDetailedList = JSON.stringify($('#DC_OA_OverSeeWorkDelayDetailed').jfGridGet('rowdatas'));
        $.lrSaveForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkDelay/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack(res, i);
            }
        });
    };
    page.init();
}
