/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-14 10:05
 * 描  述：DC_ASSETS_BusStopBillboards
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
            learun.httpAsync('GET', top.$.rootUrl + '/LR_SystemModule/CodeRule/GetEnCode', { code: '10014' }, function (data) {
                if (!$('#F_BillboardsNumber').val()) {
                    $('#F_BillboardsNumber').val(data);
                }
            });
            $('#F_BillboardsCategory').lrDataItemSelect({ code: 'BuildingBaseFL' });
        //    $('#F_Manufacturer').lrDataSourceSelect({ code: 'ProductUnit', value: 'f_cuid', text: 'f_unitname' });
         //   $('#F_ServiceProvider').lrDataSourceSelect({ code: 'ServiceUnit', value: 'f_cuid', text: 'f_unitname' });
            $('#F_BillboardsIdentification').lrDataItemSelect({ code: 'BoardContent' });
            $('#F_PictureAccessories').lrUploader();
            $('#F_UseDepartmentId').lrselect({
                type: 'tree',
                allowSearch: true,
                url: top.$.rootUrl + '/LR_OrganizationModule/Department/GetTree',
                param: {}
            });
            $('#F_LeaderId').lrformselect({
                layerUrl: top.$.rootUrl + '/LR_OrganizationModule/User/SelectOnlyForm',
                layerUrlW: 400,
                layerUrlH: 300,
                dataUrl: top.$.rootUrl + '/LR_OrganizationModule/User/GetListByUserIds'
            });
            $('#F_ManagerId').lrformselect({
                layerUrl: top.$.rootUrl + '/LR_OrganizationModule/User/SelectOnlyForm',
                layerUrlW: 400,
                layerUrlH: 300,
                dataUrl: top.$.rootUrl + '/LR_OrganizationModule/User/GetListByUserIds'
            });
            $('#F_UseState').lrDataItemSelect({ code: 'AdBoardUseState' });
            $('#btn_area').click(function () {
                learun.layerForm({
                    id: 'areaform',
                    title: '选择区域',
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_BusStopBillboards/MapForm?keyValue=' + keyValue,
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
                $.lrSetForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_BusStopBillboards/GetFormData?keyValue=' + keyValue, function (data) {
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
        var Entity = $('body').lrGetFormData()
        Entity.F_BoundaryCoordinates = F_BoundaryCoordinates
        Entity.F_CenterpointCoordinates = F_CenterpointCoordinates
        var postData = {
            strEntity: JSON.stringify(Entity)
        };
        $.lrSaveForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_BusStopBillboards/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
