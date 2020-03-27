/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-16 17:45
 * 描  述：DC_ASSETS_HouseRentIncome
 */
var acceptClick;
var keyValue = request('keyValue');
var DID = request('DID')
var keyword =''
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            $('.lr-form-wrap').lrscroll();
            page.bind();
            page.initData();
        },
        bind: function () {
            $('#DC_ASSETS_HouseRentIncome').jfGrid({
                headData: [

                    {
                        label: '租赁人', name: 'F_Renter', width: 100, align: "center"
                        , edit: {
                            type: 'input'
                        }
                    },
                    {
                        label: '合同编号', name: 'F_ContractNumber', width: 120, align: "center"
                        , edit: {
                            type: 'input'
                        }
                    },
                    {
                        label: 'CPI指标', name: 'F_CPI', width: 120, align: "center"
                        , edit: {
                            type: 'input'
                        }
                    },
                    {
                        label: '应缴金额', name: 'F_PlanPrice', width: 120, align: "center"
                        , edit: {
                            type: 'input'
                        }
                    },
                    {
                        label: '到期时间', name: 'F_PlanPayDate', width: 100, align: "center"
                        , edit: {
                            type: 'datatime',
                            dateformat: '0'
                        }
                    },
                    {
                        label: '实缴金额', name: 'F_ActualPrice', width: 120, align: "center"
                        , edit: {
                            type: 'input'
                        }
                    },
              
                             
                    {
                        label: '缴费日期', name: 'F_PaymentDate', width: 100, align: "center"
                        , edit: {
                            type: 'datatime',
                            dateformat: '0'
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
                height: 700
            });

            $('#btn_Search').on('click', function () {
                 keyword = $('#txt_Keyword').val();
                //alert('bb')
                page.initData();
            });
            $('#txt_Keyword').on("keypress", function (e) {
                if (event.keyCode == "13") {
                     keyword = $('#txt_Keyword').val();
                    // alert('aa')
                    page.initData();
                }
            });
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentIncome/GetFormData?keyValue=' + keyValue + '&keyword='+ keyword, function (data) {
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
        var entity = $('#DC_ASSETS_HouseRentIncome').jfGridGet('rowdatas')
        postData.strEntity = JSON.stringify(entity);
     
        $.lrSaveForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentIncome/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
