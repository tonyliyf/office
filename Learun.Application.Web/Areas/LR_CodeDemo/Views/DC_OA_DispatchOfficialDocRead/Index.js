/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-17 10:24
 * 描  述：DC_OA_DispatchOfficialDocRead
 */
var refreshGirdData;
var bootstrap = function ($, learun) {
    "use strict";
    var startTime;
    var endTime;
    var page = {
        init: function () {
            page.initGird();
            page.bind();
        },
        bind: function () {
            // 时间搜索框
            $('#datesearch').lrdate({
                dfdata: [
                    { name: '今天', begin: function () { return learun.getDate('yyyy-MM-dd 00:00:00') }, end: function () { return learun.getDate('yyyy-MM-dd 23:59:59') } },
                    { name: '近7天', begin: function () { return learun.getDate('yyyy-MM-dd 00:00:00', 'd', -6) }, end: function () { return learun.getDate('yyyy-MM-dd 23:59:59') } },
                    { name: '近1个月', begin: function () { return learun.getDate('yyyy-MM-dd 00:00:00', 'm', -1) }, end: function () { return learun.getDate('yyyy-MM-dd 23:59:59') } },
                    { name: '近3个月', begin: function () { return learun.getDate('yyyy-MM-dd 00:00:00', 'm', -3) }, end: function () { return learun.getDate('yyyy-MM-dd 23:59:59') } }
                ],
                // 月
                mShow: false,
                premShow: false,
                // 季度
                jShow: false,
                prejShow: false,
                // 年
                ysShow: false,
                yxShow: false,
                preyShow: false,
                yShow: false,
                // 默认
                dfvalue: '-1',
                selectfn: function (begin, end) {
                    startTime = begin;
                    endTime = end;
                    page.search();
                }
            });
            $('#multiple_condition_query').lrMultipleQuery(function (queryJson) {
                page.search(queryJson);
            }, 220, 400);
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            //  查看
            $('#btn_info').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_DODId');
                var fid = $('#gridtable').jfGridValue('F_FileContent_ENew')
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'sendform',
                        title: '封发',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_DispatchOfficialDocManager/DealTable?keyValue=' + keyValue,
                        width: 800,
                        height: 900,
                        btn: ['查看正文', '关闭'],
                        callBack: function (id) {//查看正文
                            //debugger
                            //var url = top.$.rootUrl + '/LR_CodeDemo/WebOffice/DownAnnexesFileByFolder?folderid=' + fid+"&file=1.pdf";
                            //var $form = $('<form action="' + url + '" method="POST"></form>');
                            //$form.appendTo('body').submit().remove();
                            $.post(top.$.rootUrl + '/LR_CodeDemo/WebOffice/GetFileIdByFolderId', {
                                folderid: fid
                            }, function (data) {
                                if (data.result) {
                                    learun.layerForm({
                                        id: 'PreviewForm',
                                        title: '文件预览',
                                        url: top.$.rootUrl + '/LR_CodeDemo/WebOffice/PreviewFile?fileId=' + data.fileid,
                                        width: 1080,
                                        height: 850,
                                        btn: null,
                                        callBack: function (id) {
                                            return top[id].acceptClick(function () { });
                                        }
                                    });
                                } else {
                                    learun.alert.error('未找到文档');
                                }

                            }, 'json')
                        }
                    });
                }
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_DispatchOfficialDocRead/GetPageList',
                headData: [
                    { label: "编号", name: "F_FileCode", width: 241, align: "center" },
                    {
                        label: "密级", name: "F_DenseGrade", width: 133, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'SecretLevel',
                                callback: function (_data) {
                                    var text;
                                    switch (_data.text) {
                                        case "一般":
                                            text = '<span class="label label-success">一般</span>'
                                            break;
                                        case "秘密":
                                            text = '<span class="label label-primary">秘密</span>'
                                            break;
                                        case "机密":
                                            text = '<span class="label label-warning">机密</span>'
                                            break;
                                        case "绝密":
                                            text = '<span class="label label-danger">绝密</span>'
                                            break;
                                        default:
                                            text = _data.text
                                            break
                                    }
                                    callback(text);
                                }
                            });
                        }
                    },
                    {
                        label: "紧急程度", name: "F_EmergencyLevel", width: 99, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'Degree',
                                callback: function (_data) {
                                    var text;
                                    switch (_data.text) {
                                        case "正常":
                                            text = '<span class="label label-success">正常</span>'
                                            break;
                                        case "重要":
                                            text = '<span class="label label-warning">重要</span>'
                                            break;
                                        case "紧急":
                                            text = '<span class="label label-danger">紧急</span>'
                                            break;
                                        default:
                                            text = _data.text
                                            break
                                    }
                                    callback(text);
                                }
                            });
                        }
                    },
                    { label: "标题", name: "F_Title", width: 400, align: "center" },
                    {
                        label: "拟稿部门", name: "F_DepartmentId", width: 303, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('department', {
                                key: value,
                                callback: function (_data) {
                                    callback(_data.name);
                                }
                            });
                        }
                    },
                    {
                        label: "拟稿人", name: "F_CreateUserId", width: 100, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('user', {
                                key: value,
                                callback: function (_data) {
                                    callback(_data.name);
                                }
                            });
                        }
                    },
                    {
                        label: "拟稿日期", name: "F_CreateDate", width: 100, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                            if (value.length <= 10) {
                                callback(value);
                            } else {
                                callback(value.substring(0, 10));
                            }
                        }
                    },
                ],
                mainId: 'F_DODId',
                isPage: true
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            param.StartTime = startTime;
            param.EndTime = endTime;
            $('#gridtable').jfGridSet('reload', { queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
