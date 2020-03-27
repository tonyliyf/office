/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-26 16:28
 * 描  述：DC_OA_OfficeWoodsReply
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
            learun.httpAsync('GET', top.$.rootUrl + '/LR_SystemModule/CodeRule/GetEnCode', { code: 'officewoodMonthReply' }, function (data) {
                if (!$('#F_ReplyIdNo').val()) {
                    $('#F_ReplyIdNo').val(data);
                }
            });
            $('#F_ReplyMonth').lrDataSourceSelect({ code: 'GetMonth', value: 'itemvalue', text: 'text' });
            //$('#F_CurrentCompanyId').lrCompanySelect({});
            //$('#F_CurrentDeptId').lrselect({
            //    type: 'tree',
            //    allowSearch: true
            //});
            //$('#F_CurrentCompanyId').on('change', function () {
            //    var value = $(this).lrselectGet();
            //    $('#F_CurrentDeptId').lrselectRefresh({
            //        url: top.$.rootUrl + '/LR_OrganizationModule/Department/GetTree',
            //        param: { companyId: value }
            //    });
            //});
            //$('#F_CurrentUserId').lrselect({
            //    value: 'F_UserId',
            //    text: 'F_RealName',
            //    title: 'F_RealName',
            //    allowSearch: true
            //});
            //$('#F_CurrentDeptId').on('change', function () {
            //    var value = $(this).lrselectGet();
            //    if (value == '') {
            //        $('#F_CurrentUserId').lrselectRefresh({
            //            url: '',
            //            data: []
            //        });
            //    }
            //    else {
            //        $('#F_CurrentUserId').lrselectRefresh({
            //            url: top.$.rootUrl + '/LR_OrganizationModule/User/GetList',
            //            param: { departmentId: value }
            //        });
            //    }
            //})
            $('#F_CurrentCompanyId')[0].lrvalue = learun.clientdata.get(['userinfo']).companyId;
            learun.clientdata.getAsync('company', {
                key: learun.clientdata.get(['userinfo']).companyId,
                callback: function (_data) {
                    $('#F_CurrentCompanyId').val(_data.name);
                }
            });
            $('#F_CurrentDeptId')[0].lrvalue = learun.clientdata.get(['userinfo']).departmentId;
            learun.clientdata.getAsync('department', {
                key: learun.clientdata.get(['userinfo']).departmentId,
                callback: function (_data) {
                    $('#F_CurrentDeptId').val(_data.name);
                }
            });
            $('#F_CurrentUserId')[0].lrvalue = learun.clientdata.get(['userinfo']).userId;
            $('#F_CurrentUserId').val(learun.clientdata.get(['userinfo']).realName);
            $('#F_File').lrUploader();
            $("#F_File1").hide();
            $('#DC_OA_OfficeWoodsReplyDetail').jfGrid({
                headData: [
                    {
                        label: '物品名称', name: 'F_WoodName', width: 100, align: "center"
                        , edit: {
                            type: 'layer',
                            change: function (data, rownum, selectData) {
                                data.F_WoodId = selectData.dc_oa_woodsid;
                                data.F_WoodName = selectData.dc_oa_woodsname;
                                $('#DC_OA_OfficeWoodsReplyDetail').jfGridSet('updateRow', rownum);
                            },
                            op: {
                                width: 600,
                                height: 400,
                                colData: [
                                    { label: "物品名称", name: "dc_oa_woodsname", width: 100, align: "left" },
                                    { label: "物品编号", name: "dc_oa_woodsno", width: 100, align: "left" },
                                    { label: "物品类型", name: "dc_oa_woodstype", width: 100, align: "left" },
                                    { label: "单位", name: "dc_unit", width: 100, align: "left" },
                                    { label: "单价", name: "dc_price", width: 100, align: "left" },
                                ],
                                url: top.$.rootUrl + '/LR_SystemModule/DataSource/GetDataTable',
                                param: {
                                    code: '获取商品信息'
                                }
                            }
                        }
                    },
                    //{
                    //    label: '物品主键', name: 'F_WoodId', width: 100, align: "center"
                    //},
                    {
                        label: '物品规格型号', name: 'F_WoodSpec', width: 100, align: "center"
                        , edit: {
                            type: 'input'
                        }
                    },
                    {
                        label: '数量', name: 'F_Nums', width: 100, align: "center"
                        , edit: {
                            type: 'input'
                        }
                    },
                    {
                        label: '备注', name: 'F_WoodUnit', width: 100, align: "center"
                        , edit: {
                            type: 'input'
                        }
                    },
                ],
                isEdit: true,
                height: 350
            });
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OfficeWoodsReply/GetFormData?keyValue=' + keyValue, function (data) {
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
            $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OfficeWoodsReply/GetFormDataByProcessId?processId=' + processId, function (data) {
                for (var id in data) {
                    if (!!data[id] && data[id].length > 0) {
                        $('#' + id).jfGridSet('refreshdata', data[id]);
                    }
                    else {
                        if (id == 'DC_OA_OfficeWoodsReply' && data[id]) {
                            keyValue = data[id].F_OfficeWoodsReplyId;
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
        var tabledata = $('#DC_OA_OfficeWoodsReplyDetail').jfGridGet('rowdatas')
        for (var i = 0; i < tabledata.length; i++) {
            if (tabledata[i].F_Nums && !/^\d+(\.\d+)?$/.test(tabledata[i].F_Nums)) {
                learun.alert.warning('请填写正确的数量!')
                return false
            }
        }
        return true;
    };
    // 保存数据
    save = function (processId, callBack, i) {
        var postData = {};
        var formData = $('[data-table="DC_OA_OfficeWoodsReply"]').lrGetFormData();
        formData.F_type = 1
        if (!!processId) {
            formData.F_OfficeWoodsReplyId = processId;
        }
        postData.strEntity = JSON.stringify(formData);
        postData.strdC_OA_OfficeWoodsReplyDetailList = JSON.stringify($('#DC_OA_OfficeWoodsReplyDetail').jfGridGet('rowdatas'));
        $.lrSaveForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OfficeWoodsReply/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack(res, i);
            }
        });
    };
    page.init();
}
