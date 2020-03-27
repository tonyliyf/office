/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-14 13:32
 * 描  述：DC_ASSETS_EquipmentPartsInfo
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
            learun.httpAsync('GET', top.$.rootUrl + '/LR_SystemModule/CodeRule/GetEnCode', { code: '10016' }, function (data) {
                if (!$('#F_PartsCode').val()) {
                    $('#F_PartsCode').val(data);
                }
            });
            $('#F_PartsType').lrDataItemSelect({ code: 'DevicePartType' });
            $('#F_Manufacturer').lrDataSourceSelect({ code: 'ProductUnit', value: 'f_cuid', text: 'f_unitname' });
            $('#F_Distributor').lrDataSourceSelect({ code: 'SellUnit', value: 'f_cuid', text: 'f_unitname' });
            $('#F_PictureAccessories').lrUploader();
            $('#RelativeDevice').lrRadioCheckbox({ type: 'checkbox', dataType: 'dataSource', code: 'DeviceData', value: 'f_eiid', text: 'f_equipmentname' });
            $('#F_PartsState').lrDataItemSelect({ code: 'DevicePartState' });
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_EquipmentPartsInfo/GetFormData?keyValue=' + keyValue, function (data) {
                    data.DC_ASSETS_EquipmentPartsInfo.RelativeDevice = data.relativeDevice
                    delete data.relativeDevice
                    for (var id in data) {
                        if (!!data[id].length && data[id].length > 0) {
                            $('#' + id).jfGridSet('refreshdata', data[id]);
                        }
                        else {
                            $('[data-table="' + id + '"]').lrSetFormData(data[id]);
                        }
                    }
                    
                    $('#F_PartsState').lrSetForm(data.relativeDevice)
                });
            }
        }
    };
    // 保存数据
    acceptClick = function (callBack) {
        if (!$('body').lrValidform()) {
            return false;
        }
        var entity = $('body').lrGetFormData()
        var RelativeDevice = entity.RelativeDevice
        delete entity.RelativeDevice
        var postData = {
            strEntity: JSON.stringify(entity),
            RelativeDevice: RelativeDevice
        };
        $.lrSaveForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_EquipmentPartsInfo/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
