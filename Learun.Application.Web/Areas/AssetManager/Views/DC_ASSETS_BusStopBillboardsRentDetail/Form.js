/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-03-07 15:15
 * 描  述：DC_ASSETS_BusStopBillboardsRentDetail
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
            var addZero = function (str) {
                return (str + "").length < 2 ? ("0" + str) : str
            }
            $('#F_LeaseState').lrDataItemSelect({ code: 'HouseRentState1' });
            $('#F_LeaseState').lrselectSet("1");
            $('#F_TenderType').lrDataItemSelect({ code: 'ProjectTendering' });
            $('#F_TenderType').lrselectSet("施工招标");

            $('#F_RentStartTime').change(function (e) {
                var date = new Date($("#F_RentStartTime").val());

                var y = $("#F_RentAge").val();

                if (y && /^\d+(\.\d+)?$/.test(y)) {
                    date.setFullYear(date.getFullYear() + +y)
                    $("#F_RentEndTime").val(date.getFullYear() + "-" + addZero(date.getMonth() + 1) + "-" + addZero(date.getDate()));
                }
            });
            $('#F_RentReminder').change(function () {
                var y = $(this).val()
              
                if (y && /^\d+(\.\d+)?$/.test(y) && $('#F_RentEndTime').val()) {
                    var date = new Date($('#F_RentEndTime').val())
                    date.setDate(date.getDate() - +y)
                    $('#F_RentReminderDate').val(date.getFullYear() + "-" + addZero(date.getMonth() + 1) + "-" + addZero(date.getDate()))
                }
            });
            $('#F_ExpireReminder').change(function () {
                var y = $(this).val()
           
                if (y && /^\d+(\.\d+)?$/.test(y) && $('#F_RentEndTime').val()) {
                    var date = new Date($('#F_RentEndTime').val())
                    date.setDate(date.getDate() - +y)
                    $('#F_ExpireReminderDate').val(date.getFullYear() + "-" + addZero(date.getMonth() + 1) + "-" + addZero(date.getDate()))
                }
            });
         
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_BusStopBillboardsRentDetail/GetFormData?keyValue=' + keyValue, function (data) {
                    for (var id in data) {
                        if (!!data[id].length && data[id].length > 0) {
                            $('#' + id).jfGridSet('refreshdata', data[id]);

                        }
                        else {
                            if (data[id].F_RentStartTime && data[id].F_RentStartTime.length > 10) {
                                data[id].F_RentStartTime = data[id].F_RentStartTime.substr(0, 10)
                            }
                            if (data[id].F_RentEndTime && data[id].F_RentEndTime.length > 10) {
                                data[id].F_RentEndTime = data[id].F_RentEndTime.substr(0, 10)
                            }
                            if (data[id].F_RentReminderDate && data[id].F_RentReminderDate.length > 10) {
                                data[id].F_RentReminderDate = data[id].F_RentReminderDate.substr(0, 10)
                            }
                            if (data[id].F_ExpireReminderDate && data[id].F_ExpireReminderDate.length > 10) {
                                data[id].F_ExpireReminderDate = data[id].F_ExpireReminderDate.substr(0, 10)
                            }
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
        postData.strEntity = JSON.stringify($('[data-table="DC_ASSETS_BusStopBillboardsRentMain"]').lrGetFormData());
        postData.strdC_ASSETS_BusStopBillboardsRentDetailEntity = JSON.stringify($('[data-table="DC_ASSETS_BusStopBillboardsRentDetail"]').lrGetFormData());
        $.lrSaveForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_BusStopBillboardsRentDetail/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
