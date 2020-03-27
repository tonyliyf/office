/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-16 14:32
 * 描  述：DC_ASSETS_HouseRentDetail
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
            $('#lr_form_tabs').lrFormTab();
            $('#DC_ASSETS_HouseRentIncome').hide();
            $('#lr_form_tabs ul li').eq(0).trigger('click'); 
            var addZero = function (str) {
                return (str + "").length < 2 ? ("0" + str) : str
            }

            $('#F_HRMId').lrDataSourceSelect({ code: 'HouseRentInfoList', value: 'f_hrmid', text: 'f_rentname' })

            $('#F_HouseID').lrDataSourceSelect({ code: 'HouseRentBaseInfoList', value: 'f_houseid', text: 'f_housename' })
            $('#F_DetailFiles').lrUploader();
            $('#F_LeaseState').lrDataItemSelect({ code: 'HouseRentState1' });
            $('#F_LeaseState').lrselectSet("2"); 
            $('#F_RentStartTime').change(function (e) {
                var date = new Date($(this).val())
                var y = $('#F_RentAge').val()
                if (y && /^\d+(\.\d+)?$/.test(y)) {
                    date.setFullYear(date.getFullYear() + +y)
                    $('#F_RentEndTime').val(date.getFullYear() + "-" + addZero(date.getMonth() + 1) + "-" + addZero(date.getDate()))
                }
            })
            $('#F_RentReminder').change(function () {
                var y = $(this).val()
                if (y && /^\d+(\.\d+)?$/.test(y) && $('#F_RentEndTime').val()) {
                    var date = new Date($('#F_RentEndTime').val())
                    date.setDate(date.getDate() - +y)
                    $('#F_RentReminderDate').val(date.getFullYear() + "-" + addZero(date.getMonth() + 1) + "-" + addZero(date.getDate()))
                }
            })


            $('#F_ExpireReminder').change(function () {
                var y = $(this).val()
                if (y && /^\d+(\.\d+)?$/.test(y) && $('#F_RentEndTime').val()) {
                    var date = new Date($('#F_RentEndTime').val())
                    date.setDate(date.getDate() - +y)
                    $('#F_ExpireReminderDate').val(date.getFullYear() + "-" + addZero(date.getMonth() + 1) + "-" + addZero(date.getDate()))
                }
            })
            $('#DC_ASSETS_HouseRentDetail_Info').jfGrid({
                headData: [

                    {
                        label: '租赁人', name: 'F_Renter', width: 100, align: "center"
                        , edit: {
                            type: 'input'
                        }
                    },

                    {
                        label: '身份证号', name: 'F_RenterIDNo', width: 120, align: "center"
                        , edit: {
                            type: 'input'
                        }
                    },
                    {
                        label: '联系方式', name: 'F_RenterPhone', width: 120, align: "center"
                        , edit: {
                            type: 'input'
                        }
                    },
                    {
                        label: '合同编号', name: 'F_ContractNo', width: 120, align: "center"
                        , edit: {
                            type: 'input'
                        }
                    },

                    {
                        label: '租赁价格（元/年）', name: 'F_ActualPrice', width: 120, align: "center"
                        , edit: {
                            type: 'input'
                        }
                    },


                    {
                        label: '押金（元/年）', name: 'F_RentDeposit', width: 120, align: "center"
                        , edit: {
                            type: 'input'
                        }
                    },

                    {
                        label: '出租面积', name: 'F_RentArea', width: 100, align: "center"
                        , edit: {
                            type: 'input'
                        }
                    },
                    {
                        label: '出租年限', name: 'F_RentAge', width: 100, align: "center"
                        , edit: {
                            type: 'input'
                        }
                    },
                  
                    {
                        label: '从事业务', name: 'F_DoThings', width: 150, align: "center"
                        , edit: {
                            type: 'input'
                        }
                    },
                    {
                        label: '租赁起始日', name: 'F_RentStartTime', width: 100, align: "center"
                       ,edit:{
                        type: 'datatime',
                        dateformat: '0'
                    }
                    },

                    {
                        label: '租赁结束日', name: 'F_RentEndTime', width: 100, align: "center"
                        , edit: {
                            type: 'datatime',
                            dateformat: '0'
                        }
                    },

                    {
                        label: '押金状态', name: 'F_RentDepositState', width: 100, align: "center"
                        , edit: {
                            type: 'select',
                            datatype: 'dataItem',
                            code: 'RentDepositState'
                        }
                    },
                    {
                        label: '负责人', name: 'F_Manager', width: 100, align: "center"
                        , edit: {
                            type: 'input'
                        }
                    },
                    {
                        label: '备注', name: 'F_Remarks', width: 120, align: "center"
                        , edit: {
                            type: 'input'
                           
                        }
                    },

                    
                ],
                isEdit: true,
                height: 400
            });

           
        },


        initData: function () {
         
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentDetail/GetFormData?keyValue=' + keyValue, function (data) {
                    for (var id in data) {
                        if (!!data[id].length && data[id].length > 0) {
                            $('#' + id).jfGridSet('refreshdata', data[id]);
                        }
                        else {
                            if (data[id].F_RentStartTime&&data[id].F_RentStartTime.length>10) {
                                data[id].F_RentStartTime = data[id].F_RentStartTime.substr(0,10)
                            }
                            if (data[id].F_RentEndTime && data[id].F_RentEndTime.length > 10) {
                                data[id].F_RentEndTime = data[id].F_RentEndTime.substr(0, 10)
                            }
                            $('[data-table="' + id + '"]').lrSetFormData(data[id]);
                            $.lrSetForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentDetail/GetFormData?keyValue=' + keyValue, function (data) {
                                data = data.DC_ASSETS_HouseRentDetail
                                $.lrSetForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseInfo/GetFormData?keyValue=' + data.F_HouseID, function (data) {
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
                            })
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
        var entity = $('#DC_ASSETS_HouseRentDetail_Info').jfGridGet('rowdatas')
        postData.strEntity = JSON.stringify($('[data-table="DC_ASSETS_HouseRentDetail"]').lrGetFormData());
        postData.strdC_ASSETS_HouseRentDetailInfoList = JSON.stringify(entity);
        $.lrSaveForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentDetail/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
