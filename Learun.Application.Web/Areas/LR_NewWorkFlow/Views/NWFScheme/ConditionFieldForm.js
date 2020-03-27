﻿/*
 * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：-前端开发组
 * 日 期：2017.04.18
 * 描 述：表单权限添加	
 */
var id = request('id');
var acceptClick;
var bootstrap = function ($, learun) {
    "use strict";
    var dbId = '';
    var page = {
        init: function () {
            page.bind();
            page.initData();
        },
        bind: function () {
            $('#compareType').lrselect({//比较类型1.等于2.不等于3.大于4.大于等于5.小于6.小于等于7.包含8.不包含9.包含于10.不包含于
                maxHeight:95,
                placeholder: false,
                data: [{ id: '1', text: '等于' }, { id: '2', text: '不等于' }, { id: '3', text: '大于' }, { id: '4', text: '大于等于' }, { id: '5', text: '小于' }, { id: '6', text: '小于等于' }, { id: '7', text: '包含' }, { id: '8', text: '不包含' }, { id: '9', text: '包含于' }, { id: '10', text: '不包含于' }]
            }).lrselectSet('1');

            $('#field2').lrselect({
                value: 'f_column',
                text: 'f_column',
                title: 'f_remark',
                allowSearch: true
            });
            $('#field1').lrselect({
                value: 'f_column',
                text: 'f_column',
                title: 'f_remark',
                allowSearch: true
            });
            $('#table').lrselect({
                value: 'name',
                text: 'name',
                title: 'tdescription',
                allowSearch: true,
                select: function (item) {
                    if (item) {
                        learun.httpAsync('GET', top.$.rootUrl + '/LR_SystemModule/DatabaseTable/GetFieldList', { databaseLinkId: dbId, tableName: item.name }, function (data) {
                            if (data) {
                                $('#field1').lrselectRefresh({
                                    url: false,
                                    data: data
                                });
                                $('#field2').lrselectRefresh({
                                    url: false,
                                    data: data
                                });
                            }
                        });
                    }
                    else {
                        $('#field1').lrselectRefresh({
                            data:[]
                        });
                        $('#field2').lrselectRefresh({
                            data: []
                        });
                    }
                }
            });
            $('#dbId').lrselect({
                url: top.$.rootUrl + '/LR_SystemModule/DatabaseLink/GetTreeList',
                type: 'tree',
                placeholder: '请选择数据库',
                allowSearch: true,
                select: function (item) {
                    if (item && !item.hasChildren) {
                        dbId = item.id;
                        $('#table').lrselectRefresh({
                            url: top.$.rootUrl + '/LR_SystemModule/DatabaseTable/GetList',
                            param: { databaseLinkId: item.id }
                        });
                    }
                    else {
                        dbId = '';
                        $('#table').lrselectRefresh({
                            url: false,
                            data: [],
                            param: {}
                        });
                    }
                }
            });
        },
        initData: function () {
            if (!!id) {
                var conditions = top.layer_NodeForm.conditions;
                for (var i = 0, l = conditions.length; i < l; i++) {
                    if (conditions[i].id == id) {
                        $('#form').lrSetFormData(conditions[i]);
                        break;
                    }
                }
            }
        }
    };
    // 保存数据
    acceptClick = function (callBack) {
        if (!$('#form').lrValidform()) {
            return false;
        }
        var formData = $('#form').lrGetFormData();
        formData.id = id || learun.newGuid();
        callBack(formData);
        return true;
    };
    page.init();
}