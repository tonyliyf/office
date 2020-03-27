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
        },
        bind: function () {
          
            $('#F_FormerUnit').lrDataItemSelect({ code: 'oldManager' });
            $('#F_area').lrAreaSelect();
            $('#F_BBIId').lrDataSourceSelect({
                code: 'buildingInfo', value: 'f_bbiid', text: 'f_constructionname',
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

                        $.lrSetForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_BuildingBaseInfo/GetFormData?keyValue=' + rowData.f_bbiid, function (data) {
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
                  
            $('#F_PictureAccessories').lrUploader();
            $('#F_BuildingClass').lrDataItemSelect({ code: 'BuildingClass' });
            $('#F_UseCategories').lrDataItemSelect({ code: 'BuildingUsedBy' });

            $('#btn_area').click(function () {
                learun.layerForm({
                    id: 'areaform',
                    title: '选择区域',
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_BuildingBaseInfo/MapForm?keyValue=' + $('#F_BBIId').lrselectGet(),
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
                $.lrSetForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseInfo/GetTotalHouseNoLandInfo?keyValue=' + keyValue, function (data) {
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
        var strLandEntityss = $('[data-table="DC_ASSETS_BuildingBaseInfo"]').lrGetFormData();
        strLandEntityss.F_BoundaryCoordinates = F_BoundaryCoordinates;
        strLandEntityss.F_CenterpointCoordinates = F_CenterpointCoordinates;
        postData.strBuildingEntity = JSON.stringify(strLandEntityss);
     
           //  postData.strBuildingEntity = JSON.stringify($('[data-table="DC_ASSETS_BuildingBaseInfo"]').lrGetFormData());
        postData.strHouseEntity = JSON.stringify($('[data-table="DC_ASSETS_HouseInfo"]').lrGetFormData());

     
        $.lrSaveForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseInfo/SaveTotalFormNoLand?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
