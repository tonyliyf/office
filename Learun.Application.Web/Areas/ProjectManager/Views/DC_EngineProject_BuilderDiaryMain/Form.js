/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-03-25 10:59
 * 描  述：DC_EngineProject_BuilderDiaryMain
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
            //$('#F_PIId').lrDataSourceSelect({ code: 'ProjectInfo', value: 'F_PIId', text: 'f_projectname' });
            $('#fj').lrUploader();
            $('#DC_EngineProject_BuilderDiaryDetail').jfGrid({
                headData: [
                     {
                         label: '项目名称', name: 'F_PIId', width: 100, align: 'left'
                        , edit: {
                            type: 'input'
                        }
                     },
                    {
                        label: '日志编号', name: 'rzbh', width: 100, align: 'left'
                        ,edit:{
                            type:'input'
                        }
                    },
                    {
                        label: '填写人', name: 'lastname', width: 100, align: 'left'
                        ,edit:{
                            type:'input'
                        }
                    },
                    {
                        label: '填写时间', name: 'txsj', width: 300, align: 'left'
                        ,edit:{
                            type:'input'
                        }
                    },
                    {
                        label: '天气情况', name: 'tqqk', width: 300, align: 'left'
                        , edit: {
                            type: 'input'
                        }
                    },
                    {
                        label: '施工人数', name: 'sgrs', width: 300, align: 'left'
                        , edit: {
                            type: 'input'
                        }
                    },
                    {
                        label: '施工机械', name: 'sgjx', width: 300, align: 'left'
                        , edit: {
                            type: 'input'
                        }
                    },
                    {
                        label: '施工进度情况', name: 'sgjzqk', width: 300, align: 'left'
                        , edit: {
                            type: 'input'
                        }
                    },
                     {
                         label: '明日计划安排', name: 'mrjhap', width: 300, align: 'left'
                        , edit: {
                            type: 'input'
                        }
                     },
                ],
                isEdit: true,
                height: 120
            });
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/ProjectManager/DC_EngineProject_BuilderDiaryMain/GetFormData?keyValue=' + keyValue, function (data) {
                  
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
        var postData = {
            strEntity: null
        };
        $.lrSaveForm(top.$.rootUrl + '/ProjectManager/DC_EngineProject_BuilderDiaryMain/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };

    page.init();
}
