/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-03-21 10:45
 * 描  述：DC_EngineProject_ProjectCompanyRiskControl
 */
var refreshGirdData;
var query;
var keyValue;
var HouseId;
var F_BoundaryCoordinates = "[]";
var F_CenterpointCoordinates = "[]";
var look = 1
var marker = null;
var map;
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            page.bind();
            map = new AMap.Map('container', {
                zoom: 14,
                center: [111.754821, 30.431865]
            });
            if (look != 1) {
                AMap.event.addListener(map, "click", function (e) {
                    if (marker) {
                        marker.setMap(null);
                    }
                    marker = new AMap.Marker({
                        position: e.lnglat,
                        map: map
                    });
                });

            }
        },
        bind: function () {
            // 初始化左侧树形数据
            $('#dataTree1').lrtree({
                url: top.$.rootUrl + '/AssetManager/DC_ASSETS_BuildingBaseInfo/GetTreeLandbase',
                nodeClick: function (item) {
                    keyValue = item.value;
                    page.initData();
                    // 获取房屋左侧树形数据
                    $('#dataTree2').lrtree({
                        url: top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseInfo/GetTree?keyValue=' + keyValue,
                        nodeClick: function (item) {
                            HouseId = item.value;
                            //房屋信息
                            if (!!HouseId) {
                                $.lrSetForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseInfo/GetFormData?keyValue=' + HouseId, function (data) {

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
                            //房屋租赁明细信息
                            if(!!HouseId){
                                $.lrSetForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentDetail/GetHouseRentDetail?keyValue=' + HouseId, function (data) {
                                        for (var id in data) {
                                            if (!!data[id].length && data[id].length > 0) {
                                                $('#' + id).jfGridSet('refreshdata', data[id]);
                                            }
                                            else {
                                                if (data[id].F_RentReminderDate && data[id].F_RentReminderDate.length > 10) {
                                                    data[id].F_RentReminderDate = data[id].F_RentReminderDate.substr(0, 10)
                                                }
                                                if (data[id].F_ExpireReminderDate && data[id].F_ExpireReminderDate.length > 10) {
                                                    data[id].F_ExpireReminderDate = data[id].F_ExpireReminderDate.substr(0, 10)
                                                }
                                                if (data[id].F_RentStartTime && data[id].F_RentStartTime.length > 10) {
                                                    data[id].F_RentStartTime = data[id].F_RentStartTime.substr(0, 10)
                                                }
                                                if (data[id].F_RentEndTime && data[id].F_RentEndTime.length > 10) {
                                                    data[id].F_RentEndTime = data[id].F_RentEndTime.substr(0, 10)
                                                }
                                                $('[data-table="' + id + '"]').lrSetFormData(data[id]);

                                                //获取房屋字段信息
                                                GetHouse();                                      
                                            }
                                        }
                                    });
                            }
                        }
                    });
                }
            });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });



            // 刷新
            $('#btnSearch').on('click', function () {
               
                    $('#dataTree1').lrtree({
                        url: top.$.rootUrl + '/AssetManager/DC_ASSETS_BuildingBaseInfo/GetTreeLandbase?unit=' + $("#unitSearch").val(),
                        nodeClick: function (item) {
                            keyValue = item.value;
                            page.initData();
                            // 获取房屋左侧树形数据
                            $('#dataTree2').lrtree({
                                url: top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseInfo/GetTree?keyValue=' + keyValue,
                                nodeClick: function (item) {
                                    HouseId = item.value;
                                    //房屋信息
                                    if (!!HouseId) {
                                        $.lrSetForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseInfo/GetFormData?keyValue=' + HouseId, function (data) {

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
                                    //房屋租赁明细信息
                                    if (!!HouseId) {
                                        $.lrSetForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentDetail/GetHouseRentDetail?keyValue=' + HouseId, function (data) {
                                            for (var id in data) {
                                                if (!!data[id].length && data[id].length > 0) {
                                                    $('#' + id).jfGridSet('refreshdata', data[id]);
                                                }
                                                else {
                                                    if (data[id].F_RentReminderDate && data[id].F_RentReminderDate.length > 10) {
                                                        data[id].F_RentReminderDate = data[id].F_RentReminderDate.substr(0, 10)
                                                    }
                                                    if (data[id].F_ExpireReminderDate && data[id].F_ExpireReminderDate.length > 10) {
                                                        data[id].F_ExpireReminderDate = data[id].F_ExpireReminderDate.substr(0, 10)
                                                    }
                                                    if (data[id].F_RentStartTime && data[id].F_RentStartTime.length > 10) {
                                                        data[id].F_RentStartTime = data[id].F_RentStartTime.substr(0, 10)
                                                    }
                                                    if (data[id].F_RentEndTime && data[id].F_RentEndTime.length > 10) {
                                                        data[id].F_RentEndTime = data[id].F_RentEndTime.substr(0, 10)
                                                    }
                                                    $('[data-table="' + id + '"]').lrSetFormData(data[id]);

                                                    //获取房屋字段信息
                                                    GetHouse();
                                                }
                                            }
                                        });
                                    }
                                }
                            });
                        }

                    });
               

            });
            //建筑信息
            learun.httpAsync('GET', top.$.rootUrl + '/LR_SystemModule/CodeRule/GetEnCode', { code: '10012' }, function (data) {
                if (!$('#F_ConstructionCode').val()) {
                    $('#F_ConstructionCode').val(data);
                }
            });

            $('#F_LBIId').lrDataSourceSelect({ code: 'LandData', value: 'id', text: 'name' });
            //$('#F_LBIId').lrselectSet(LBIId);

            $('#F_UseCategories').lrDataItemSelect({ code: 'BuildingUsedBy' });
            $('#F_StructureClassification').lrDataItemSelect({ code: 'BuildingClassification' });
            $('#F_FireRating').lrDataItemSelect({ code: 'FireRating' });
            $('#F_IfUse').lrDataItemSelect({ code: 'YesOrNo' });
            $('#F_FormerUnit').lrDataItemSelect({ code: 'oldManager' });
            $('#F_BuildingClass').lrDataItemSelect({ code: 'BuildingClass' });

            $('#F_PictureAccessories').lrUploader();
            $('#F_OtherAccessories').lrUploader();
            $('#F_area').lrAreaSelect();
            $('#F_ProvinceId').lrselectSet(420000)
            $('#F_CityId').lrselectSet(420500)
            $('#F_CountyId').lrselectSet(420583)
      


            //房屋信息
            learun.httpAsync('GET', top.$.rootUrl + '/LR_SystemModule/CodeRule/GetEnCode', { code: '10013' }, function (data) {
                if (!$('#F_AssetsNumber').val()) {
                    $('#F_AssetsNumber').val(data);
                }
            });
          
            $('#F_PictureAccessories_build').lrUploader();
            $('#F_UseCategories_build').lrDataItemSelect({ code: 'HouseUsedBy' });
            $('#F_RoomUsage_build').lrDataItemSelect({ code: 'F_RoomUsage' });
            $('#F_PropertyOwner_build').lrDataItemSelect({ code: 'oldManager' });
            $('#F_PropertyOwnerCertificateType_build').lrDataItemSelect({ code: 'CertificateType' });
            $('#F_UseStatus_build').lrDataItemSelect({ code: 'YesOrNo' });
            $('#F_RentPurpose_build').lrDataItemSelect({ code: 'RentPurpose' });
            $('#F_IfUse_build').lrDataItemSelect({ code: 'YesOrNo' });
            $('#F_RentCertificateNo_build').lrDataItemSelect({ code: 'RentCertificateNo' });
          
        },
        initData: function () {
            //获取建筑信息
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_BuildingBaseInfo/GetFormData?keyValue=' + keyValue, function (data) {
                    for (var id in data) {

                        if (!!data[id].length && data[id].length > 0) {

                            $('#' + id).jfGridSet('refreshdata', data[id]);
                        }
                        else {
                       
                            $('[data-table="' + id + '"]').lrSetFormData(data[id]);
                        }
                    }

                    if (marker) {
                        marker.setMap(null);
                    }
            
                  
                    if (data.DC_ASSETS_BuildingBaseInfo.F_CenterpointCoordinates != '' && data.DC_ASSETS_BuildingBaseInfo.F_CenterpointCoordinates != '[]') {
                        var center = JSON.parse(data.DC_ASSETS_BuildingBaseInfo.F_CenterpointCoordinates)
                        marker = new AMap.Marker({
                            position: center,
                            map: map
                        });
                        map.setCenter(center);
                    }
                    else {
                        marker.setMap(null);
                        marker = null;
                    }
                });
            }
        }
    };


    var GetHouse = function () {

        $.lrSetForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseInfo/GetFormData?keyValue=' + HouseId, function (data) {
            data = data.DC_ASSETS_HouseInfo
            $('#name').val(data.F_HouseName)
            $('#area').val(data.F_HouseArea)
            $('#num').val(data.F_AssetsNumber)
            $('#address').val(data.F_BuildingAddress)
            $('#seePicture').click(function () {
                learun.layerForm({
                    id: "fileDownloadWnd",
                    title: "下载附件",
                    url: top.$.rootUrl + '/LR_SystemModule/Annexes/DownForm?keyVaule=' + data.F_PictureAccessories,
                    width: 600,
                    height: 400,
                    maxmin: true,
                    btn: null
                });
            })
            $.lrSetForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_BuildingBaseInfo/GetFormData?keyValue=' + data.F_BBIId, function (data) {
                data = data.DC_ASSETS_BuildingBaseInfo
                $('#unit').val(data.F_FormerUnit)
            })
        })
    };
    page.init();
}
