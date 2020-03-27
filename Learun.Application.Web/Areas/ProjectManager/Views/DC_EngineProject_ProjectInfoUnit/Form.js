/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-03-09 15:56
 * 描  述：工程项目单位信息管理
 */
var acceptClick;
var keyValue = request('keyValue');
var F_UnitType = request('F_UnitType');
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            $('.lr-form-wrap').lrscroll();
            page.bind();
            page.initData();
        },
        bind: function () {
            //$('#F_UnitType').lrDataItemSelect({ code: 'EngineeringManageUnitType' });
            //$('#F_PIId').lrDataSourceSelect({ code: 'SellUnit', value: 'f_cuid', text: 'f_unitname' });
            //$('#F_CreateDatetime').val(learun.formatDate(new Date(), 'yyyy-MM-dd hh:mm:ss'));
            $("#num1").hide();
            $('#F_UnitType').lrDataItemSelect({ code: 'EngineeringManageUnitType' });
            $('#F_CreateDepartmentId')[0].lrvalue = learun.clientdata.get(['userinfo']).userId;
            $('#F_CreateDepartmentId').val(learun.clientdata.get(['userinfo']).realName);
            $('#F_CreateUserid')[0].lrvalue = learun.clientdata.get(['userinfo']).userId;
            $('#F_CreateUserid').val(learun.clientdata.get(['userinfo']).realName);
            $("#num2").hide();
            $('#F_File').lrUploader();
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfoUnit/GetFormData?keyValue=' + keyValue, function (data) {
                    for (var id in data) {
                        if (!!data[id].length && data[id].length > 0) {
                            $('#' + id ).jfGridSet('refreshdata', data[id]);
                        }
                        else {
                            if (data[id].F_CreateDatetime && data[id].F_CreateDatetime.length > 10) {
                                data[id].F_CreateDatetime = data[id].F_CreateDatetime.substr(0, 10)
                            }
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
        postData.strEntity = JSON.stringify($('body').lrGetFormData());
    
        $.lrSaveForm(top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfoUnit/SaveForm?keyValue='+ keyValue +'&F_UnitType='+F_UnitType, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
