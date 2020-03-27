    /* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-03-09 13:57
 * 描  述：DC_EngineProject_ProjectInfo
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
            //learun.httpAsync('GET', top.$.rootUrl + '/LR_SystemModule/CodeRule/GetEnCode', { code: 'DC_EngineProject_ProjectInfo' }, function (data) {
            //    if (!$('#F_ProjectItemNumber').val()) {
            //        $('#F_ProjectItemNumber').val(data);
            //    }
            //});

            //F_CenterpointCoordinates
            $('#F_ProjectBuildType').lrDataItemSelect({ code: 'EngineeringProjectBuildType' });
            $('#F_ProjectBuildType').lrselectSet("子公司承建项目");
            $('#F_ProjectState').lrDataItemSelect({ code: 'OS_F_State' });
            $('#F_ProjectState').lrselectSet("0");
            
            $('#F_JRYCompany').lrDataSourceSelect({ code: 'company', value: 'f_companyid', text: 'f_fullname' });
            $('#F_CreateDatetime').val(learun.formatDate(new Date(), 'yyyy-MM-dd hh:mm:ss'));
            $('#F_area').lrAreaSelect();
            $('#F_ProvinceId').lrselectSet(420000)
            $('#F_CityId').lrselectSet(420500)
            $('#F_CountyId').lrselectSet(420583)
            $('#btn_area').click(function () {
                learun.layerForm({
                    id: 'areaform',
                    title: '选择区域',
                    url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfo/MapForm?keyValue=' + keyValue,
                    width: 600,
                    height: 400,
                    callBack: function (id) {
                        return top[id].acceptClick(function (points, center) {
                            F_CenterpointCoordinates = JSON.stringify(points);
                            F_BoundaryCoordinates = JSON.stringify(center);
                        });
                    }
                });
            })
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfo/GetFormData?keyValue=' + keyValue, function (data) {
                    for (var id in data) {
                        if (!!data[id].length && data[id].length > 0) {
                            $('#' + id ).jfGridSet('refreshdata', data[id]);
                        }
                        else {
                            if (data[id].F_ProjectApprovalDate && data[id].F_ProjectApprovalDate.length > 10) {
                                data[id].F_ProjectApprovalDate = data[id].F_ProjectApprovalDate.substr(0, 10)
                            }
                            if (data[id].F_PlannedStartDate && data[id].F_PlannedStartDate.length > 10) {
                                data[id].F_PlannedStartDate = data[id].F_PlannedStartDate.substr(0, 10)
                            }
                            if (data[id].F_PlannedEndDate && data[id].F_PlannedEndDate.length > 10) {
                                data[id].F_PlannedEndDate = data[id].F_PlannedEndDate.substr(0, 10)
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
     
        var Entity = $('body').lrGetFormData()
        Entity.F_CenterpointCoordinates = F_BoundaryCoordinates
        Entity.F_BoundaryCoordinates = F_CenterpointCoordinates

        var postData = {
            strEntity: null
        };
        $.lrSaveForm(top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfo/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
