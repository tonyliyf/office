/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-04-25 17:27
 * 描  述：DC_EngineProject_ConstructionRecordMonth
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
            $('#F_PIId').lrDataSourceSelect({ code: 'DC_EngineProject_ProjectInfo',value: 'f_piid',text: 'f_projectname' });
            $('#F_Month').lrDataSourceSelect({ code: 'GetMonth', value: 'itemvalue', text: 'text' });
            
            $('#F_ContractKeys').lrDataItemSelect({ code: '' });
            $('#F_ContractPerformanceEvaluation').lrDataItemSelect({ code: 'ContractPerformanceEvaluation' });
            $('#F_Attachments').lrUploader();
            $('#F_CreateDepartmentId')[0].lrvalue = learun.clientdata.get(['userinfo']).departmentId;
            learun.clientdata.getAsync('department', {
                key: learun.clientdata.get(['userinfo']).departmentId,
                callback: function (_data) {
                    $('#F_CreateDepartmentId').val(_data.name);
                }
            });
            $('#F_CreateUserid')[0].lrvalue = learun.clientdata.get(['userinfo']).userId;
            $('#F_CreateUserid').val(learun.clientdata.get(['userinfo']).realName);
            $('#F_CreateDatetime').val(learun.formatDate(new Date(), 'yyyy-MM-dd'));
            $("#num1").hide();
            $("#num2").hide();
            $("#num3").hide();
            $.post(top.$.rootUrl + '/ProjectManager/DC_EngineProject_ConstructionRecordMonth/GetData?', function (res) {
                $('#F_ContractKeys').lrselect({
                    data: res.data.userdata,
                    value: 'value',
                    text: 'text',
                    type: 'multiple',
                    allowSearch: true,
                    select: function () {

                        var num = $("#F_ContractKeys").text();
                        if (num != "==请选择==") {
                            alert(num);
                            document.getElementById("F_ContractName").value = $("#F_ContractKeys").text();
                        }
                        else {
                            document.getElementById("F_ContractName").value = "";
                        }
                      
                    }
                })
            }, 'json')
           
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/ProjectManager/DC_EngineProject_ConstructionRecordMonth/GetFormData?keyValue=' + keyValue, function (data) {
                    for (var id in data) {
                        if (!!data[id].length && data[id].length > 0) {
                            $('#' + id ).jfGridSet('refreshdata', data[id]);
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
        var postData = {
            strEntity: JSON.stringify($('body').lrGetFormData())
        };
        $.lrSaveForm(top.$.rootUrl + '/ProjectManager/DC_EngineProject_ConstructionRecordMonth/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
