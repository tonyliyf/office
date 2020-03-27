﻿/*
 * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：-前端开发组
 * 日 期：2018.11.8
 * 描 述：印章操作
 */

var acceptClick;
var keyValue = request('keyValue');
var bootstrap = function ($, learun) {
    "use strict";
    var selectedRow = learun.frameTab.currentIframe().selectedRow;

    function uploadImg() {
        try {
            var f = document.getElementById("uploadFile").files[0];//获取文件
            var src = window.URL.createObjectURL(f);
            document.getElementById('uploadPreview').src = src;
        }
        catch (e) {
            console.log(e);
        }
       
    };
    var page = {
        init: function () {
            page.bind();
            page.initData();
        },
        bind: function () {
            // 印章分类
            $('#F_StampType').lrDataItemSelect({ code: 'StampType' });
            //图片显示
            $('#uploadFile').on('change', uploadImg);
            $('.fileEx').prepend('<img id="uploadPreview"  src="' + top.$.rootUrl + '/LR_OAModule/LR_StampInfo/GetImg?keyValue=' + keyValue + '" >');
        },
        initData: function () {
            if (!!selectedRow) {
                selectedRow.F_Password = '*****';
                $('#form').lrSetFormData(selectedRow);
                
            }
        }
    };
    // 保存数据
    acceptClick = function (callBack) {
        if (!$('#form').lrValidform()) {
            return false;
        }
        var postData = $('#form').lrGetFormData(keyValue);
        if (postData.F_Password != '*****' || !keyValue) {
            if (! /^[A-Za-z0-9]{6,20}$/.test(postData.F_Password)) {
                learun.alert.warning('请输出6位以上密码，包含数字与字母!')
                return false;
            }
            postData.F_Password = $.md5(postData.F_Password);
        }
        else {
            delete postData.F_Password;
        }
        if (!keyValue && !postData.uploadFile) {
            learun.alert.error("请选择图片");
            return false;
        }

        var f = document.getElementById('uploadFile').files[0];
        //是否上传图片
        if (!!f) {
            learun.loading(true, '正在保存...');
            $.ajaxFileUpload({
                data: postData,
                url: top.$.rootUrl + "/LR_OAModule/LR_StampInfo/UploadFile?keyValue=" + keyValue,
                secureuri: false,
                fileElementId: 'uploadFile',
                dataType: 'json',
                success: function (data) {
                    if (!!callBack) {
                        callBack();
                    }
                    learun.loading(false);
                    learun.layerClose(window.name);
                }
            });
        }
        else {
            $.lrSaveForm(top.$.rootUrl + '/LR_OAModule/LR_StampInfo/SaveForm?keyValue=' + keyValue, postData, function (res) {
                // 保存成功后才回调 
                if (!!callBack) {
                    callBack();
                }
            });
        }
    };
    page.init();
}