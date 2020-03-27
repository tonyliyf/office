/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-05-23 12:01
 * 描  述：DC_ASSETS_LandHandUpInfo
 */
var acceptClick;
var keyValue = request('keyValue');
var F_BoundaryCoordinates = "[]"
var F_CenterpointCoordinates = "[]"
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            $('.lr-form-wrap').lrscroll();
            page.bind();
            page.initData();
        },
        bind: function () {
            $('#lr_form_tabs').lrFormTab();
            $('#lr_form_tabs ul li').eq(0).trigger('click'); 
            $('#F_State').lrDataItemSelect({ code: 'LandHandUpInfoState' });
            $('#F_ManagerDept').lrDataItemSelect({ code: 'oldManager' });
            $('#F_LandUseRight').lrDataItemSelect({ code: 'landhandType' });
           
            $('#F_ContractAccessories').lrUploader();
            $('#F_SalesConfirmation').lrUploader();
            $('#F_NoteAccessories').lrUploader();
            $('#F_OtherAccessories').lrUploader();
            $('#btn_area').click(function () {
                learun.layerForm({
                    id: 'areaform',
                    title: '选择区域',
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_LandHandUpInfo/MapForm?keyValue=' + keyValue,
                    width: 600,
                    height: 400,
                    callBack: function (id) {
                        return top[id].acceptClick(function (points, center) {
                            F_BoundaryCoordinates = JSON.stringify(points)
                            F_CenterpointCoordinates = JSON.stringify(center)
                        });
                    }
                });
            })
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_LandHandUpInfo/GetFormData?keyValue=' + keyValue, function (data) {
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
        var Entity = $('body').lrGetFormData()
        Entity.F_BoundaryCoordinates = F_BoundaryCoordinates
        Entity.F_CenterpointCoordinates = F_CenterpointCoordinates
        var postData = {
            strEntity: JSON.stringify(Entity)
        };
        $.lrSaveForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_LandHandUpInfo/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
