/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-03-15 15:20
 * 描  述：DC_EngineProject_ProjectInfoContract
 */
var acceptClick;
var keyValue = request('keyValue');
var F_PIId = request('F_PIId');
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            $('.lr-form-wrap').lrscroll();
            page.bind();
          
            page.initData();
        },
        bind: function () {
            $('#F_PIId').lrDataSourceSelect({ code: 'ProjectInfo', value: 'f_piid', text: 'f_projectname' }).lrselectSet(F_PIId)
            //$('#F_PartyBUnit').lrselect({
            //    type: 'tree',
            //    allowSearch: true,
            //    url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfoApprovalData/GetUnitTree',
            //    param: {}
            //});
          //  $('#F_ProjectStage').lrselectSet("1");
            $('#F_ContractType').lrDataItemSelect({ code: 'EngineeringContractType' });
            $('#F_ContractType').lrselectSet("建设工程施工合同");
            $('#F_SettlementMethod').lrDataItemSelect({ code: 'SettlementMethod' });
            $('#F_PayMethod').lrDataItemSelect({ code: 'PayMethod' });
            $('#F_ContractAppendices').lrUploader();
        },
        initData: function () {
            if (!!keyValue) {
                
                $.lrSetForm(top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfoContract/GetFormData?keyValue=' + keyValue, function (data) {
                    for (var id in data) {
                        if (!!data[id].length && data[id].length > 0) {
                            $('#' + id ).jfGridSet('refreshdata', data[id]);
                        }
                        else {
                            if (data[id].F_SigningTime && data[id].F_SigningTime.length > 10) {
                                data[id].F_SigningTime = data[id].F_SigningTime.substr(0, 10)
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
        var postData = {
            strEntity: null
        };
        $.lrSaveForm(top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfoContract/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
