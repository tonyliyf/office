/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-16 13:45
 * 描  述：DC_ASSETS_HouseRentMain
 */
var acceptClick;
var keyValue = request('keyValue');
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            $('.lr-form-wrap').lrscroll();
            page.bind();
            page.initData();
        },
        bind: function () {
           // $('#F_RentState').lrDataItemSelect({ code: 'HouseRentState' });
            $('#F_Accessories').lrUploader();

            $('#F_RentState').lrDataItemSelect({ code: 'HouseRentState1' });
            $('#F_RentState').lrselectSet("1"); 
          
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentMain/GetFormData?keyValue=' + keyValue, function (data) {
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
    // 保存数据
    acceptClick = function (callBack) {
        if (!$('body').lrValidform()) {
            return false;
        }
        if (!/^[0-9]{4}$/.test($('#F_RentYear').val())) {
            learun.alert.warning('年度格式错误 请添加20XX格式')
            return false
        }
        var postData = {};
            
    
        postData.strEntity = JSON.stringify($('[data-table="DC_ASSETS_HouseRentMain"]').lrGetFormData());
       // postData.strdC_ASSETS_HouseRentDetailList = JSON.stringify(entity);
        $.lrSaveForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentMain/SaveForm2?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
           
        },false);
    };
    page.init();
}
