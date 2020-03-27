/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-04-23 10:20
 * 描  述：DC_ASSETS_BusStopBillboardsRentIncome
 */
var acceptClick;
var keyValue = request('keyValue');
var F_BSBRDId = request('F_BSBRDId');
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
            $('#F_CreateDepartmentId')[0].lrvalue = learun.clientdata.get(['userinfo']).departmentId;
            learun.clientdata.getAsync('department', {
                key: learun.clientdata.get(['userinfo']).departmentId,
                callback: function (_data) {
                    $('#F_CreateDepartmentId').val(_data.name);
                }
            });
            $('#F_CreateUserid')[0].lrvalue = learun.clientdata.get(['userinfo']).userId;
            $('#F_CreateUserid').val(learun.clientdata.get(['userinfo']).realName);
            $('#F_CreateDatetime').val(learun.formatDate(new Date(), 'yyyy-MM-dd'));
            $("#fre1").hide();
            $("#fre2").hide();
            $("#fre3").hide();

            var myDate = new Date;
            var year = myDate.getFullYear();
            $("#F_Year").val(year);
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_BusStopBillboardsRentIncome/GetFormData?keyValue=' + keyValue, function (data) {
                    for (var id in data) {
                        if (!!data[id].length && data[id].length > 0) {
                            $('#' + id ).jfGridSet('refreshdata', data[id]);
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
        var postData = {
            strEntity: JSON.stringify($('body').lrGetFormData()),
            F_BSBRDId
        };

        $.lrSaveForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_BusStopBillboardsRentIncome/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
