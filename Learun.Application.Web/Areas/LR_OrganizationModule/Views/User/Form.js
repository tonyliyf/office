﻿/*
 * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：-前端开发组
 * 日 期：2017.04.18
 * 描 述：账号添加	
 */
var companyId = request('companyId');


var acceptClick;
var keyValue = '';
var bootstrap = function ($, learun) {
    "use strict";
    var selectedRow = learun.frameTab.currentIframe().selectedRow;
    var page = {
        init: function () {
            page.bind();
            page.initData();
        },
        bind: function () {
            // 部门
            $('#F_DepartmentId').lrDepartmentSelect({ companyId: companyId});
            // 性别
            $('#F_Gender').lrselect();
            /*检测重复项*/
            $('#F_Account').on('blur', function () {
                $.lrExistField(keyValue, 'F_Account', top.$.rootUrl + '/LR_OrganizationModule/User/ExistAccount');
            });
        },
        initData: function () {
            if (!!selectedRow) {
                keyValue = selectedRow.F_UserId;
                selectedRow.F_Password = "******";
                $('#form').lrSetFormData(selectedRow);
                //账号，系统管理员可以修改 liyf,2019-01-22
                $('#F_Password').attr('readonly', 'readonly');
               // $('#F_Account').attr('readonly', 'readonly');

                $('#F_Password').attr('unselectable', 'on');
               // $('#F_Account').attr('unselectable', 'on');
            }
            else {
                $('#F_CompanyId').val(companyId);
            }
        }
    };
    // 保存数据
    acceptClick = function (callBack) {
        if (!$('#form').lrValidform()) {
            return false;
        }
        var postData = $('#form').lrGetFormData(keyValue);
        if (!keyValue) {
            postData.F_Password = $.md5(postData.F_Password);
        }
        $.lrSaveForm(top.$.rootUrl + '/LR_OrganizationModule/User/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}