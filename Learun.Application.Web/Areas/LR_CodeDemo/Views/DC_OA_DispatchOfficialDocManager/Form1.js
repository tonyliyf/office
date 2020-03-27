/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-12 15:16
 * 描  述：发文管理
 */
var acceptClick;
var keyValue = request('keyValue');
var isSend = request('isSend')
// 设置权限
var setAuthorize;
// 设置表单数据
var setFormData;
// 验证数据是否填写完整
var validForm;
// 保存数据
var bootstrap = function ($, learun) {
    "use strict";
    // 设置权限
    setAuthorize = function (data) {
    };
    var page = {
        init: function () {
            $('.lr-form-wrap').lrscroll();
            $.post(top.$.rootUrl + '/LR_CodeDemo/DC_OA_DispatchOfficialDocManager/GetTreeData', { keyValue: keyValue, isSend: isSend }, function (data) {
                $('#organizationTree').tree({
                    data: data,
                    checkbox: true
                })
            }, 'json')
            page.bind();
            page.initData();
        },
        bind: function () {

        },
        initData: function () {
            setFormData(keyValue)
        }
    };
    var renderStr = function (dom, node, obj) {
        var children = node.children
        if (children && children.length > 0) {
            $.each(children, function (i, v) {
                if (v.checked) {
                    if (!v.attributes.isFolder) {
                        obj.names += v.text + ','
                    } else {
                        obj.names += v.attributes.parentName + '各' + v.text + ','
                    }
                } else {
                    renderStr(dom, v, obj)
                }
            })
        }
    }
    // 设置表单数据
    setFormData = function (processId) {
        if (!!processId) {
            $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_DispatchOfficialDocManager/GetFormDataByProcessId?processId=' + processId, function (data) {
                if (isSend == 1) {
                    $('#txt_send').val(data['DC_OA_DispatchOfficialDoc'].F_SendTo)
                } else {
                    $('#txt_send').val(data['DC_OA_DispatchOfficialDoc'].F_CopyTo)
                }
            });
        }
    }

    // 保存数据
    acceptClick = function (callBack) {
        var dom = $('#organizationTree')
        var obj = new Object()
        obj.ids = ''
        obj.names = ''
        var checkednodes = dom.tree('getChecked')
        $.each(checkednodes, function (i, v) {
            obj.ids += v.id + ','
        })
        if (obj.ids.length > 0) {
            obj.ids = obj.ids.substr(0, obj.ids.length - 1)
        }
        var root = dom.tree('getRoots')
        if (root[0].checked) {
            obj.names = root[0].text + ','
        } else {
            renderStr(dom, root[0], obj)
        }
        if (obj.names.length > 0) {
            obj.names = obj.names.substr(0, obj.names.length - 1)
        }
        var text = $('#txt_send').val()
        if (text && text.length > 0) {
            obj.names = $('#txt_send').val() + ';' + obj.names
        }
        callBack(obj);
        learun.layerClose(window.name)
    };
    page.init();
}
