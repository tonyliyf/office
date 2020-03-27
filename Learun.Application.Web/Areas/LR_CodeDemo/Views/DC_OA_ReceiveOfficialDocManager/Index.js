/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-14 12:10
 * 描  述：收文管理
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
            $('#F_DenseGrade').lrDataItemSelect({ code: 'SecretLevel' });
            $('#F_SenderDepartment').lrDepartmentSelect();
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 办结
            $('#lr_complete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_RODId');
                if ($('#gridtable').jfGridValue('F_IfCompletion') == '1') {
                    learun.alert.warning('此记录已经归档!')
                    return
                }
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: '_________form',
                        title: '归档',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_ReceiveOfficialDocManager/DoCompleteForm?keyValue=' + keyValue,
                        width: 600,
                        height: 550,
                        callBack: function (id) {
                            return top[id].acceptClick(page.search);
                        }
                    });
                }
            });
            // 打印处理单
            $('#lr_print').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_RODId');
                if (learun.checkrow(keyValue)) {
                    learun.DocLayerForm({
                        id: 'printform',
                        title: '打印',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_ReceiveOfficialDocManager/DealTable?keyValue=' + keyValue,
                        width: 800,
                        height: 900,
                        btn: ['打印', '关闭'],
                        callBack: function (id) {
                            return top[id].printClick(function () { });
                        },
                        callBack1: function (id) {
                            return top[id].acceptClick1(function () { });
                        }
                    });
                }
            });

            // 查看正文
            $('#lr_info').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_Attachments');
                if (learun.checkrow(keyValue)) {
                    //var strRoot = window.location.protocol + "//" + window.location.host
                    //var getBrowser = function () {
                    //    var Sys = {};
                    //    var ua = navigator.userAgent.toLowerCase();
                    //    var s;
                    //    var ver;
                    //    (s = ua.match(/edge\/([\d.]+)/)) ? Sys.edge = s[1] :
                    //        (s = ua.match(/rv:([\d.]+)\) like gecko/)) ? Sys.ie = s[1] :
                    //            (s = ua.match(/msie ([\d.]+)/)) ? Sys.ie = s[1] :
                    //                (s = ua.match(/firefox\/([\d.]+)/)) ? Sys.firefox = s[1] :
                    //                    (s = ua.match(/chrome\/([\d.]+)/)) ? Sys.chrome = s[1] :
                    //                        (s = ua.match(/opera.([\d.]+)/)) ? Sys.opera = s[1] :
                    //                            (s = ua.match(/version\/([\d.]+).*safari/)) ? Sys.safari = s[1] : 0;
                    //    if (Sys.edge) return 1;
                    //    if (Sys.ie) return 0;
                    //    if (Sys.firefox) return 1;
                    //    if (Sys.chrome) { ver = Sys.chrome; ver.toLowerCase(); var arr = ver.split('.'); if (parseInt(arr[0]) > 43) { return 1; } else { return 0; } }
                    //    if (Sys.opera) return 1;
                    //    if (Sys.safari) return 1;
                    //    return 1;
                    //}
                    //var vb = getBrowser()
                    //var url = (vb ? 'WebOffice://|Officectrl|' : '') + strRoot + '/LR_CodeDemo/WebOffice/PrintDoc?keyValue=' + keyValue + '&type=info'
                    //window.open(url, vb ? '_self' : '_blank')
                    //var url = top.$.rootUrl + '/LR_CodeDemo/WebOffice/DownAnnexesFileByFolder?folderid=' + keyValue
                    //var $form = $('<form action="' + url + '" method="POST"></form>');
                    //$form.appendTo('body').submit().remove();
                    $.post(top.$.rootUrl + '/LR_CodeDemo/WebOffice/GetFileIdByFolderId', {
                        folderid: keyValue
                    }, function (data) {
                        if (data.result) {
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
                url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_ReceiveOfficialDocManager/GetPageList',
                headData: [
                    { label: "文件字号", name: "F_FileCode", width: 100, align: "center" },
                    {
                        label: "来文部室", name: "F_SenderDepartment", width: 254, align: "center"
                    },
                    {
                        label: "密级", name: "F_DenseGrade", width: 100, align: "center",
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
                    { label: "文件标题", name: "F_Title", width: 386, align: "center" },
                    { label: "收文号", name: "F_ReceiveCode", width: 125, align: "center" },
                    {
                        label: "登记人员", name: "F_CreateUserId", width: 100, align: "center",
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
                        label: "接收时间", name: "F_ReceiveDate", width: 208, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
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
                mainId: 'F_RODId',
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
            learun.workflowapi.create({
                isNew: true,
                schemeCode: 'JRYReceiveFile',// 填写流程对应模板编号
                processId: processId,
                processName: '系统表单流程',// 对应流程名称
                processLevel: '1',
                description: '',
                formData: JSON.stringify(postData),
                callback: function (res, data) {
                    //alert('222')
                }
            });
            page.search();
        }
    };
    page.init();
}
