﻿/* * 版 本 Learun-ADMS V7.0.0 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-07 17:47
 * 描  述：DC_OA_OverSeeWorkTaskExecute
 */
var acceptClick;
var keyValue = request('keyValue');
var TID = request('TID')
var PID = request('PID')
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            $('.lr-form-wrap').lrscroll();
            page.bind();
            page.initData();
        },
        bind: function () {
            $('#F_TwoDepartmentId').lrRadioCheckbox({
                type: 'checkbox',
                dataType: 'dataSource',
                code: 'OA_Department',
                value: 'f_departmentid',
                text: 'f_fullname',
            });
            $('#F_TwoUserId').lrformselect({
                layerUrl: top.$.rootUrl + '/LR_OrganizationModule/User/SelectForm',
                layerUrlW: 800,
                layerUrlH: 520,
                dataUrl: top.$.rootUrl + '/LR_OrganizationModule/User/GetListByUserIds'
            });
            $('#F_State').lrDataItemSelect({ code: 'OS_F_State' }).lrselectSet(0);
            $('#DC_OA_OverSeeWorkTaskExecute').jfGrid({
                headData: [
                    {
                        label: '执行情况', name: 'F_ExecuteContent', width: 300, align: 'center'
                        , edit: {
                            type: 'input'
                        }
                    },
                    {
                        label: '执行时间', name: 'F_ExecuteDate', width: 100, align: 'center'
                        , edit: {
                            type: 'datatime',
                            dateformat: '0'
                        }
                    },
                ],
                isEdit: true,
                height: 400
            });
        },
        initData: function () {
            if (!!keyValue) {//编辑
                $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkTaskExecute/GetFormData?keyValue=' + keyValue, function (data) {
                    for (var id in data) {
                        if (!!data[id].length && data[id].length > 0) {
                            $('#' + id).jfGridSet('refreshdata', data[id]);
                        }
                        else {
                            $('[data-table="' + id + '"]').lrSetFormData(data[id]);
                        }
                    }
                });
            } else if (!!PID) {//新增
                $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkTaskExecute/GetFormData?keyValue=' + PID, function (data) {
                    for (var id in data) {
                        if (!!data[id].length && data[id].length > 0) {
                            $('#' + id).jfGridSet('refreshdata', data[id]);
                        }
                        else {
                            delete data[id].F_code
                            delete data[id].F_TaskName
                            delete data[id].F_TaskContent
                            delete data[id].F_State
                            $('[data-table="' + id + '"]').lrSetFormData(data[id]);
                        }
                    }
                });
            }
        }
    };
    // 保存数据
    acceptClick = function (callBack) {
        if (!$('body').lrValidform()) {
            return false;
        }
        var postData = {};
        postData.strEntity = JSON.stringify($('[data-table="DC_OA_OverSeeWorkTaskSplit"]').lrGetFormData());
        postData.strdC_OA_OverSeeWorkTaskExecuteList = JSON.stringify($('#DC_OA_OverSeeWorkTaskExecute').jfGridGet('rowdatas'));
        if (!!keyValue) {//编辑
            $.lrSaveForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkTaskExecute/SaveForm?keyValue=' + keyValue, postData, function (res) {
                // 保存成功后才回调
                if (!!callBack) {
                    callBack();
                }
            });
        } else if (!!PID) {
            $.lrSaveForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkTaskExecute/SaveForm?PID=' + PID, postData, function (res) {
                // 保存成功后才回调
                if (!!callBack) {
                    callBack();
                }
            });
        }
    };
    page.init();
}