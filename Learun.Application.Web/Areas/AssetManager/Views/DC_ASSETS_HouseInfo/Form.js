/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-13 17:40
 * 描  述：DC_ASSETS_HouseInfo
 */
var acceptClick;
var keyValue = request('keyValue');
var BID = request('BID')
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            $('.lr-form-wrap').lrscroll();
            page.bind();
            page.initData();
        },
        bind: function () {
            learun.httpAsync('GET', top.$.rootUrl + '/LR_SystemModule/CodeRule/GetEnCode', { code: '10013' }, function (data) {
                if (!$('#F_AssetsNumber').val()) {
                    $('#F_AssetsNumber').val(data);
                }
            });
            $('#F_BBIId').lrDataSourceSelect({ code: 'buildingInfo', value: 'f_bbiid', text: 'f_constructionname' }).lrselectSet(BID)
            $('#F_UseCategories').lrDataItemSelect({ code: 'HouseUsedBy' });
            $('#F_RoomUsage').lrDataItemSelect({ code: 'F_RoomUsage' });
            $('#F_PropertyOwnerCertificateType').lrDataItemSelect({ code: 'CertificateType' });
            $('#F_UseStatus').lrDataItemSelect({ code: 'YesOrNo' });
            $('#F_RentPurpose').lrDataItemSelect({ code: 'RentPurpose' });
            $('#F_IfUse').lrDataItemSelect({ code: 'YesOrNo' });
            $('#F_PictureAccessories').lrUploader();
            $('#F_PropertyOwner').lrDataItemSelect({ code: 'oldManager' });
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseInfo/GetHouseInfo?keyValue=' + keyValue, function (data) {
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
        var postData = {
            strEntity: JSON.stringify($('body').lrGetFormData())
        };
        $.lrSaveForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseInfo/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
