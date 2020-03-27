/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-13 11:36
 * 描  述：DC_ASSETS_LandBaseInfo
 */
var acceptClick;
var map;
var keyValue = request('keyValue');
var look = request('look');
var marker = null;
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            page.bind();
            page.initData();
        },
        bind: function () {

        },
        initData: function () {
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
                $('#btn_clear').show().click(function () {
                    marker.setMap(null);
                    marker = null;
                })
            }

            if (keyValue) {
                $.lrSetForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_LandBaseInfofood/GetFormData?keyValue=' + keyValue, function (data) {
                    var center = JSON.parse(data.DC_ASSETS_LandBaseInfofood.F_CenterpointCoordinates)
                    marker = new AMap.Marker({
                        position: center,
                        map: map
                    });
                });
                map.setCenter(center)
            }
        }
    };
    // 保存数据
    acceptClick = function (cb) {
        var center = []
        if (marker) {
            center = [marker.D.position.lng, marker.D.position.lat]
        }
        learun.layerClose(window.name)
        cb([], center)
    };
    page.init();
}
