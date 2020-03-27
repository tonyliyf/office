/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-17 22:13
 * 描  述：党员会议通知
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
            $('#F_PartyBranchGUID').lrDataSourceSelect({ code: '11111111111512546156',value: 'f_partybranchguid',text: 'f_partybranchname' });
            $('#F_Attachments').lrUploader();
            $('#F_MeetingPlaceId').lrDataSourceSelect({ code: 'OA_MeettingRoom',value: 'dc_oa_meetingroomid',text: 'dc_oa_meetingroomname' });
            $('#F_MeetingCompereCode').lrDataSourceSelect({ code: 'GetPartyMembers', value: 'f_partymemberguid', text: 'f_realname' });
            $('#F_MeetingConventionerId').lrRadioCheckbox({
                type: 'checkbox',
                dataType: 'dataSource',
                code: 'GetPartyMembers',
                value: 'f_partymemberguid',
                text: 'f_realname',
            }); 
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PartyBranchMeeting/GetFormData?keyValue=' + keyValue, function (data) {
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
        $.lrSaveForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PartyBranchMeeting/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
