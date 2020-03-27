/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-03-21 10:45
 * 描  述：DC_EngineProject_ProjectCompanyRiskControl
 */
var refreshGirdData;
var query;
var map;
var LandBaseValue;
var BuildingBaseValue;
var HouseValue;
var F_BoundaryCoordinates = "[]"
var F_CenterpointCoordinates = "[]"
var look = 1
var marker = null;
var F_PictureAccessories;
var F_ContractAccessories;
var F_SalesConfirmation;
var F_NoteAccessories;
var F_OtherAccessories;
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
            // 初始化左侧土地树形数据
            $('#dataTree').lrtree({
                url: top.$.rootUrl + '/AssetManager/DC_ASSETS_LandBaseInfo/GetTree',
                nodeClick: function (item) {
                    LandBaseValue = item.value;
                 
                    LandBase(LandBaseValue);
                    page.initData();
                }
            });
            //查看附件
            $('#lr_file').on('click', function () {
                var FIDS = F_PictureAccessories + ',' + F_ContractAccessories + ',' + F_SalesConfirmation + ',' + F_NoteAccessories + ',' + F_OtherAccessories;
                    top.learun.frameTab.open({
                        F_ModuleId: FIDS, F_Icon: '',
                        F_FullName: '附件信息查看', F_UrlAddress: '/LR_CodeDemo/FileViewer/Index?FIDS=' + FIDS
                    });
                
            })
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });

            // 刷新
            $('#btnSearch').on('click', function () {
               

                    $('#dataTree').lrtree({
                        url: top.$.rootUrl + '/AssetManager/DC_ASSETS_LandBaseInfo/GetTree?unit=' + $("#unitSearch").val(),
                        nodeClick: function (item) {
                            LandBaseValue = item.value;

                            LandBase(LandBaseValue);
                            page.initData();
                        }

                    });
              
               
            });


            learun.httpAsync('GET', top.$.rootUrl + '/LR_SystemModule/CodeRule/GetEnCode', { code: '10011' }, function (data) {
                if (!$('#F_AssetsNumber').val()) {
                    $('#F_AssetsNumber').val(data);
                }
            });
            $('#F_LandUseNature').lrDataItemSelect({ code: 'LandUseBy' });
            $('#F_LandUseRight').lrDataItemSelect({ code: 'LandUseRight' });
            $('#F_PictureAccessories').lrUploader();
            $('#F_Assignee').lrDataItemSelect({ code: 'oldManager' });
            //$('#F_ContractAccessories').lrUploader();
            //$('#F_SalesConfirmation').lrUploader();
            $('#F_NoteAccessories').lrUploader();
            $('#F_OtherAccessories').lrUploader();
            $('#F_area').lrAreaSelect();
            $('#F_ProvinceId').lrselectSet(420000)
            $('#F_CityId').lrselectSet(420500)
            $('#F_CountyId').lrselectSet(420583)
            $('#F_UseCategories').lrDataItemSelect({ code: 'BuildingUsedBy' });
            $('#F_StructureClassification').lrDataItemSelect({ code: 'BuildingClassification' });
            $('#F_BuildingClass').lrDataItemSelect({ code: 'BuildingClass' });
            $('#F_FireRating').lrDataItemSelect({ code: 'FireRating' });
            $('#F_PictureAccessories_building').lrUploader();
            $('#F_OtherAccessories_building').lrUploader();
            $('#F_FormerUnit').lrDataItemSelect({ code: 'oldManager' });

            $('#F_PictureAccessories_build').lrUploader();
            $('#F_UseCategories_build').lrDataItemSelect({ code: 'HouseUsedBy' });
            $('#F_RoomUsage_build').lrDataItemSelect({ code: 'F_RoomUsage' });
            $('#F_PropertyOwner_build').lrDataItemSelect({ code: 'oldManager' });
            $('#F_PropertyOwnerCertificateType_build').lrDataItemSelect({ code: 'CertificateType' });
            $('#F_UseStatus_build').lrDataItemSelect({ code: 'YesOrNo' });
            $('#F_RentPurpose_build').lrDataItemSelect({ code: 'RentPurpose' });
            $('#F_IfUse_build').lrDataItemSelect({ code: 'YesOrNo' });
            $('#F_PictureAccessories_build').lrUploader();
            $('#F_RentCertificateNo_build').lrDataItemSelect({ code: 'RentCertificateNo' });
            $('#F_CalculationFormula').lrDataItemSelect({ code: 'HouseRentCalcFunc' });
            $('#F_CalculationFormula1').lrDataItemSelect({ code: 'HouseRentCalcFunc' });
            $('#F_CalculationFormula2').lrDataItemSelect({ code: 'HouseRentCalcFunc' });

        },
        initData: function () {

            
            // 获取建筑信息树形
            $('#dataTree1').lrtree({
                url: top.$.rootUrl + '/AssetManager/DC_ASSETS_BuildingBaseInfo/GetTree?keyValue=' + LandBaseValue,
                nodeClick: function (item) {
                    BuildingBaseValue = item.value;
                   
                    building(LandBaseValue);
                    
                    // 获取房屋信息树形
                    $('#dataTree2').lrtree({
                        url: top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseInfo/GetTree?keyValue=' + BuildingBaseValue,
                        nodeClick: function (item1) {
                            HouseValue = item1.value;
                           
                            
                            //默认查询查询第一条房屋信息
                            if (!!HouseValue) {
                                $.lrSetForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseInfo/GetFormData?keyValue=' + HouseValue, function (data) {
                                
                                   
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

                            //最近三年的租金
                            if (!!HouseValue) {
                                $.lrSetForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentDetail/GetFormDataByHouseId?keyValue=' + HouseValue, function (data) {
                                    console.log(data);

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

                    });


                }
            });

           
        }
    };
    var LandBase = function (LandBaseValue) {
        //获取土地信息
        if (!!LandBaseValue) {
            $.lrSetForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_LandBaseInfo/GetFormData?keyValue=' + LandBaseValue, function (data) {

               
                 F_PictureAccessories  = data.DC_ASSETS_LandBaseInfo.F_PictureAccessories;
                 F_ContractAccessories = data.DC_ASSETS_LandBaseInfo.F_ContractAccessories;
                 F_SalesConfirmation   = data.DC_ASSETS_LandBaseInfo.F_SalesConfirmation;
                 F_NoteAccessories     = data.DC_ASSETS_LandBaseInfo.F_NoteAccessories;
                 F_OtherAccessories    = data.DC_ASSETS_LandBaseInfo.F_OtherAccessories;
               
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

    };

    var building = function (BuildingBaseValue) {
   
        //获取建筑信息
        if (!!BuildingBaseValue) {
            $.lrSetForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_BuildingBaseInfo/GetFormDataForm?keyValue=' + BuildingBaseValue, function (data) {

              
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
                else
                {
                    marker.setMap(null);
                    marker = null;
                }
            });
        }
    };
    page.init();
}
