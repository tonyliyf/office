/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-13 17:40
 * 描  述：DC_ASSETS_HouseInfo
 */
var acceptClick;
var keyValue = request('keyValue');
var BID = request('BID')
var F_BoundaryCoordinates = "[]"
var F_CenterpointCoordinates = "[]"

var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            $('.lr-form-wrap').lrscroll();
            page.bind();
            page.initData();

            $('#btn_area').click(function () {
                learun.layerForm({
                    id: 'areaform',
                    title: '选择区域',
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_LandBaseInfofood/MapForm?keyValue=' + $('#F_LBIId').lrselectGet(),
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
        bind: function () {
            $('#lr_form_tabs').lrFormTab();
            $('#lr_form_tabs ul li').eq(0).trigger('click');
            $('#F_Assignee').lrDataItemSelect({ code: 'oldManager' });
            $('#F_area').lrAreaSelect();
            $('#F_LandUseNature').lrDataItemSelect({ code: 'LandUseBy' });
            $('#F_LandUseRight').lrDataItemSelect({ code: 'LandUseRight' });
            $('#F_PictureAccessories').lrUploader();
            $('#F_PictureAccessories_HouseInfo').lrUploader();
            $('#F_UseCategories').lrDataItemSelect({ code: 'HouseUsedBy' });
            $('#F_BuildingClass').lrDataItemSelect({ code: 'BuildingClass' });
            $('#F_ProvinceId').lrselectSet(420000)
            $('#F_CityId').lrselectSet(420500)
            $('#F_CountyId').lrselectSet(420583)
            $('#F_LBIId').lrDataSourceSelect({
                code: 'GetLandfoodinfo', value: 'f_lbiid', text: 'landname',

                select: function (rowData) {
                    if (rowData) {
                        //$.get(top.$.rootUrl + '/AssetManager/DC_ASSETS_LandBaseInfo/GetFormData?keyValue=' + rowData.f_lbiid, function (res) {
                        //    if (res.code == 200) {
                        //        $('#DC_ASSETS_LandBaseInfo').lrSetFormData(res.data.DC_ASSETS_LandBaseInfo);
                        //        //$('#DC_ASSETS_LandBaseInfo').jfGridSet('refreshdata', res.data.DC_ASSETS_LandBaseInfo);
                        //    } else {
                        //        learun.alert.error(res.info)
                        //    }
                        //}, 'json')

                        $.lrSetForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_LandBaseInfofood/GetFormData?keyValue=' + rowData.f_lbiid, function (data) {
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



            })

            $('#F_RoomUsage').lrDataItemSelect({ code: 'F_RoomUsage' });
            $('#F_PropertyOwnerCertificateType').lrDataItemSelect({ code: 'CertificateType' });
            $('#F_UseStatus').lrDataItemSelect({ code: 'YesOrNo' });
            $('#F_RentPurpose').lrDataItemSelect({ code: 'RentPurpose' });
            $('#F_ContractAccessories').lrUploader();
            $('#F_SalesConfirmation').lrUploader();
            $('#F_NoteAccessories').lrUploader();
            $('#F_OtherAccessories').lrUploader();



        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_LandBaseInfofood/GetTotalHouseInfo?keyValue=' + keyValue, function (data) {
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

        var postData = {};

        var strLandEntityss = $('[data-table="DC_ASSETS_LandBaseInfofood"]').lrGetFormData();
        strLandEntityss.F_BoundaryCoordinates = F_BoundaryCoordinates;
        strLandEntityss.F_CenterpointCoordinates = F_CenterpointCoordinates;
        postData.strLandEntity = JSON.stringify(strLandEntityss);
        postData.strBuildingEntity = JSON.stringify($('[data-table="DC_ASSETS_BuildingBaseInfofood"]').lrGetFormData());
        postData.strHouseEntity = JSON.stringify($('[data-table="DC_ASSETS_HouseInfofood"]').lrGetFormData());




        $.lrSaveForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_LandBaseInfofood/SaveTotalForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
