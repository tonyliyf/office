/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-12 15:16
 * 描  述：发文管理
 */
var refreshGirdData;
var bootstrap = function ($, learun) {
    "use strict";
    var processId = '';
    var page = {
        init: function () {
            page.initGird();
            page.bind();
        },
        bind: function () {
            $('#multiple_condition_query').lrMultipleQuery(function (queryJson) {
                page.search(queryJson);
            }, 220, 400);
            $('#F_CreateUserId').lrUserSelect(0);
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            //上传正文
            $('#lr_upload').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_DODId');
                if (learun.checkrow(keyValue)) {
                    var guid;
                    $.post(top.$.rootUrl + '/LR_CodeDemo/DC_OA_DispatchOfficialDocManager/getnewfile', { keyValue: keyValue }, function (data) {
                        if (data.file && data.file.length > 0) {
                            guid = data.file
                        } else {
                            guid = learun.newGuid()
                        }
                        learun.layerForm({
                            id: 'asdasdasd',
                            title: '上传正文',
                            url: top.$.rootUrl + '/LR_SystemModule/Annexes/UploadForm?keyVaule=' + guid + "&extensions=*",
                            width: 600,
                            height: 400,
                            maxmin: true,
                            btn: null,
                            end: function () {
                                learun.httpAsyncGet(top.$.rootUrl + '/LR_SystemModule/Annexes/GetFileNames?folderId=' + guid, function (res) {
                                    if (res.code == learun.httpCode.success) {
                                        $.post(top.$.rootUrl + '/LR_CodeDemo/DC_OA_DispatchOfficialDocManager/savenewfile', { keyValue: keyValue, guid: guid }, function (data) {

                                        })
                                    }
                                });
                            }
                        });
                    }, 'json')
                }
            })
            //设置处理单模板
            $('#lr_setTemplate').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_DODId');
                if (learun.checkrow(keyValue)) {
                    if (learun.checkrow(keyValue)) {
                        learun.layerForm({
                            id: 'form',
                            title: '设置模板',
                            url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_DispatchOfficialDocManager/SettingForm?keyValue=' + keyValue,
                            width: 600,
                            height: 400,
                            callBack: function (id) {
                                return top[id].acceptClick(function () { });
                            }
                        });
                    }
                }
            })
            // 办结
            $('#lr_complete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_DODId');
                if ($('#gridtable').jfGridValue('F_IfCompletion') == '1') {
                    learun.alert.warning('此记录已经归档!')
                    return
                }
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: '_________form',
                        title: '归档',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_DispatchOfficialDocManager/DoCompleteForm?keyValue=' + keyValue,
                        width: 600,
                        height: 550,
                        callBack: function (id) {
                            return top[id].acceptClick(page.search);
                        }
                    });
                }
            });
            //封发
            $('#lr_send').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_DODId');
                if (learun.checkrow(keyValue)) {
                    $.get(top.$.rootUrl + '/LR_CodeDemo/DC_OA_DispatchOfficialDocManager/IsSettingTemplate?keyValue=' + keyValue, function (data) {
                        if (data.data.result) {
                            learun.DocLayerForm({
                                id: 'sendform',
                                title: '封发',
                                url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_DispatchOfficialDocManager/DealTable?keyValue=' + keyValue + '&type=send',
                                width: 800,
                                height: 900,
                                btn: ['保存', '套红签章', '关闭'],
                                callBack: function (id) {
                                    return top[id].acceptClick(function () { });
                                },
                                callBack1: function (id) {//查看正文
                                    //debugger
                                    var strRoot = window.location.protocol + "//" + window.location.host
                                    var getBrowser = function () {
                                        var Sys = {};
                                        var ua = navigator.userAgent.toLowerCase();
                                        var s;
                                        var ver;
                                        (s = ua.match(/edge\/([\d.]+)/)) ? Sys.edge = s[1] :
                                            (s = ua.match(/rv:([\d.]+)\) like gecko/)) ? Sys.ie = s[1] :
                                                (s = ua.match(/msie ([\d.]+)/)) ? Sys.ie = s[1] :
                                                    (s = ua.match(/firefox\/([\d.]+)/)) ? Sys.firefox = s[1] :
                                                        (s = ua.match(/chrome\/([\d.]+)/)) ? Sys.chrome = s[1] :
                                                            (s = ua.match(/opera.([\d.]+)/)) ? Sys.opera = s[1] :
                                                                (s = ua.match(/version\/([\d.]+).*safari/)) ? Sys.safari = s[1] : 0;
                                        if (Sys.edge) return 1;
                                        if (Sys.ie) return 0;
                                        if (Sys.firefox) return 1;
                                        if (Sys.chrome) { ver = Sys.chrome; ver.toLowerCase(); var arr = ver.split('.'); if (parseInt(arr[0]) > 43) { return 1; } else { return 0; } }
                                        if (Sys.opera) return 1;
                                        if (Sys.safari) return 1;
                                        return 1;
                                    }
                                    var vb = getBrowser()
                                    $.post(top.$.rootUrl + '/LR_CodeDemo/WebOffice/GetFileIdByFolderId', {
                                        folderid: $('#gridtable').jfGridValue('F_FileContent_New')
                                    }, function (data) {
                                        if (data.result) {
                                            var url = (vb ? 'WebOffice://|Officectrl|' : '') + strRoot + '/LR_CodeDemo/WebOffice/PrintDoc?keyValue=' + data.fileid + '&DID=' + keyValue + '&type=send'
                                            window.open(url, vb ? '_self' : '_blank')
                                        } else {
                                            learun.alert.error('未找到文档');
                                        }
                                    }, 'json')
                                }
                            });
                        } else {
                            learun.alert.error('请先填写处理单标题');
                        }
                    }, 'json')
                }
            });
            // 打印处理单
            $('#lr_printForm').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_DODId');
                if (learun.checkrow(keyValue)) {
                    $.get(top.$.rootUrl + '/LR_CodeDemo/DC_OA_DispatchOfficialDocManager/IsSettingTemplate?keyValue=' + keyValue, function (data) {
                        if (data.data.result) {
                            learun.DocLayerForm({
                                id: 'printform',
                                title: '打印',
                                url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_DispatchOfficialDocManager/DealTable?keyValue=' + keyValue,
                                width: 800,
                                height: 900,
                                btn: ['打印', '关闭'],
                                callBack: function (id) {
                                    return top[id].printClick(function () {

                                    });
                                },
                                callBack1: function (id) {
                                    return top[id].acceptClick1(function () {

                                    });
                                }
                            });
                        } else {
                            learun.alert.error('请先填写套红模板和处理单标题');
                        }
                    }, 'json')
                }
            });
            // 打印正文
            $('#lr_printFile').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_DODId');
                if (learun.checkrow(keyValue)) {
                    $.post(top.$.rootUrl + '/LR_CodeDemo/WebOffice/GetFileIdByFolderId', {
                        folderid: $('#gridtable').jfGridValue('F_FileContent_New')
                    }, function (data) {
                        if (data.result) {
                            //learun.layerForm({
                            //    id: 'PreviewForm',
                            //    title: '文件预览',
                            //    url: top.$.rootUrl + '/LR_CodeDemo/WebOffice/PreviewFile?fileId=' + data.fileid,
                            //    width: 1080,
                            //    height: 850,
                            //    btn: null,
                            //    callBack: function (id) {
                            //        return top[id].acceptClick(function () { });
                            //    }
                            //});
                            var strRoot = window.location.protocol + "//" + window.location.host
                            var getBrowser = function () {
                                var Sys = {};
                                var ua = navigator.userAgent.toLowerCase();
                                var s;
                                var ver;
                                (s = ua.match(/edge\/([\d.]+)/)) ? Sys.edge = s[1] :
                                    (s = ua.match(/rv:([\d.]+)\) like gecko/)) ? Sys.ie = s[1] :
                                        (s = ua.match(/msie ([\d.]+)/)) ? Sys.ie = s[1] :
                                            (s = ua.match(/firefox\/([\d.]+)/)) ? Sys.firefox = s[1] :
                                                (s = ua.match(/chrome\/([\d.]+)/)) ? Sys.chrome = s[1] :
                                                    (s = ua.match(/opera.([\d.]+)/)) ? Sys.opera = s[1] :
                                                        (s = ua.match(/version\/([\d.]+).*safari/)) ? Sys.safari = s[1] : 0;
                                if (Sys.edge) return 1;
                                if (Sys.ie) return 0;
                                if (Sys.firefox) return 1;
                                if (Sys.chrome) { ver = Sys.chrome; ver.toLowerCase(); var arr = ver.split('.'); if (parseInt(arr[0]) > 43) { return 1; } else { return 0; } }
                                if (Sys.opera) return 1;
                                if (Sys.safari) return 1;
                                return 1;
                            }
                            var vb = getBrowser()
                            var url = (vb ? 'WebOffice://|Officectrl|' : '') + strRoot + '/LR_CodeDemo/WebOffice/PrintDoc?keyValue=' + data.fileid + '&type=info'
                            window.open(url, vb ? '_self' : '_blank')
                        } else {
                            learun.alert.error('未找到文档');
                        }
                    }, 'json')
                }
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_DispatchOfficialDocManager/GetPageList',
                headData: [
                    { label: "编号", name: "F_FileCode", width: 204, align: "center" },
                    {
                        label: "密级", name: "F_DenseGrade", width: 94, align: "center",
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
                    { label: "标题", name: "F_Title", width: 419, align: "center" },
                    {
                        label: "拟稿部门", name: "F_DepartmentId", width: 116, align: "center",
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
                        label: "拟稿人", name: "F_CreateUserName", width: 224, align: "center"
                    },
                    {
                        label: "拟稿时间", name: "F_CreateDate", width: 207, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                            if (value.length <= 10) {
                                callback(value);
                            } else {
                                callback(value.substring(0, 10));
                            }
                        }
                    },
                    {
                        label: "是否归档", name: "F_IfCompletion", width: 100, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'YesOrNo',
                                callback: function (_data) {
                                    var text;
                                    switch (_data.text) {
                                        case "是":
                                            text = '<span class="label label-success">是</span>'
                                            break;
                                        case "否":
                                            text = '<span class="label label-warning">否</span>'
                                            break;
                                        default:
                                            text = '<span class="label label-warning">否</span>'
                                            break
                                    }
                                    callback(text);
                                }
                            });
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
            $('#gridtable').jfGridSet('reload', { queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function (res, postData) {
        if (res.code == 200) {
            page.search();
        }
    };
    page.init();
}
