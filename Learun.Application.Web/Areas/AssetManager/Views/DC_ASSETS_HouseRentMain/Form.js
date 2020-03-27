/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-16 13:45
 * 描  述：DC_ASSETS_HouseRentMain
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
            $('#F_RentState').lrDataItemSelect({ code: 'HouseRentState' });
            $('#F_Accessories').lrUploader();

            //导出
            $('#btn_Search').on('click', function () {
                alert('111')
            });
            $('#DC_ASSETS_HouseRentDetail').jfGrid({
                headData: [
                  
                    {
                        label: '房屋名称', name: 'name', width: 150, align: "center", edit: {
                            type: 'layer',
                            change: function (data, rownum, selectData) {
                                data.code = selectData.f_assetsnumber;
                                data.name = selectData.f_housename;
                                data.area = selectData.f_housearea;
                                data.unitname = selectData.f_formerunit;
                                data.address = selectData.f_buildingaddress;
                                data.f_houseid = selectData.f_houseid;
                                $('#DC_ASSETS_HouseRentDetail').jfGridSet('updateRow', rownum);
                            },
                            op: {
                                width: 700,
                                height: 400,
                                colData: [
                                    { label: "房屋名称", name: "f_housename", width: 100, align: "center" },
                                    { label: "资产编号", name: "f_assetsnumber", width: 100, align: "center" },
                                    { label: "房屋面积", name: "f_housearea", width: 100, align: "center" },
                                    { label: "原管单位", name: "f_formerunit", width: 100, align: "center" },
                                    { label: "地址", name: "f_buildingaddress", width: 100, align: "center" },
                                ],
                                url: top.$.rootUrl + '/LR_SystemModule/DataSource/GetDataTable',
                                param: {
                                    code: 'HouseInfoList'
                                }
                            }
                        }
                    },
                    {
                        label: '资产编号', name: 'code', width: 150, align: "center"
                    },
                    {
                        label: '原管理单位（产权人）', name: 'unitname', width: 150, align: "center"
                    },
                    {
                        label: '地址', name: 'address', width: 100, align: "center"
                    },
                    {
                        label: '房屋面积', name: 'area', width: 100, align: "center"
                    },
                    {
                        label: '招租底价（年/元）', name: 'F_RentReservePrice', width: 150, align: "center"
                        , edit: {
                            type: 'input'
                        }
                    },
                    {
                        label: '竞租保证金（元/年）', name: 'F_RentDeposit', width: 150, align: "center"
                        , edit: {
                            type: 'input'
                        }
                    },
                    
                ],
                isEdit: true,
                height: 200
            });
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentMain/GetFormData?keyValue=' + keyValue, function (data) {
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
        if (!/^[0-9]{4}$/.test($('#F_RentYear').val())) {
            learun.alert.warning('年度格式错误 请添加20XX格式')
            return false
        }
        var postData = {};
            
        for (var i = 0; i < entity.length; i++) {
            var o = entity[i]
            if (!o.F_RentReservePrice || !/^\d+(\.\d+)?$/.test(o.F_RentReservePrice)) {
                learun.alert.warning('请填写正确的招租底价')
                return false
            }
            if (!o.F_RentDeposit || !/^\d+(\.\d+)?$/.test(o.F_RentDeposit)) {
                learun.alert.warning('请填写正确的竞租保证金')
                return false
            }
         
        }
        postData.strEntity = JSON.stringify($('[data-table="DC_ASSETS_HouseRentMain"]').lrGetFormData());
        postData.strdC_ASSETS_HouseRentDetailList = JSON.stringify(entity);
        $.lrSaveForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentMain/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        },false);
    };
    page.init();
}
