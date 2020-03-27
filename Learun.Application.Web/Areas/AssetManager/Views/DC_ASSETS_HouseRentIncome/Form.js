/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-16 17:45
 * 描  述：DC_ASSETS_HouseRentIncome
 */
var acceptClick;
var keyValue = request('keyValue');
var DID = request('DID')
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            $('.lr-form-wrap').lrscroll();
            page.bind();
            page.initData();
        },
        bind: function () {
            $('#F_CalculationFormula').lrDataItemSelect({ code: 'HouseRentCalcFunc' });
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentIncome/GetFormData?keyValue=' + keyValue, function (data) {
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
        if (!/^[0-9]{4}$/.test($('#F_YearNumber').val())) {
            learun.alert.warning('年度格式错误 请添加20XX格式')
            return false
        }
        var entity = $('body').lrGetFormData()
        entity.F_HRDId = DID
        var postData = {
            strEntity: JSON.stringify(entity)
        };
        $.lrSaveForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentIncome/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
