/* * 版 本 Learun-ADMS V7.0.0 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-07 11:19
 * 描  述：DC_OA_OverSeeWork
 */
var refreshGirdData;
var _open
var _print
var _download
var _upload
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
            // 初始化左侧树形数据
            $('#dataTree').lrtree({
                url: top.$.rootUrl + '/LR_CodeDemo/MyDocument/GetTree',
                nodeClick: function (item) {
                    if (item.parentId != 0) {
                        page.search({ id: item.id });
                    }
                }
            });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
        },
        // 初始化列表
        initGird: function () {
            _open = function (key) {
                learun.DocLayerForm({
                    id: key,
                    title: '查看',
                    url: top.$.rootUrl + '/LR_CodeDemo/MyDocument/NWFContainerForm?tabIframeId=' + learun.newGuid() + '&type=look&taskId=&processId=' + key,
                    width: 600,
                    height: 800,
                    btn: null
                });
            }
            _print = function (key) {
                $.post(top.$.rootUrl + '/LR_CodeDemo/WfPrint/GetColumeCount', { taskId: '', processId: key }, function (res) {
                    learun.DocLayerForm({
                        id: '_printform',
                        title: '打印',
                        url: top.$.rootUrl + '/LR_CodeDemo/WfPrint/Index?taskId=' + '' + '&processId=' + key,
                        width: +res.count * 100,
                        height: 900,
                        btn: ['打印', '关闭'],
                        callBack: function (id) {
                            return top[id].printClick(function () { });
                        },
                        callBack1: function (id) {
                            return top[id].acceptClick1(function () { });
                        }
                    });
                }, 'json')
            }
            _download = function (folderid) {
                learun.layerForm({
                    id: '_download_'+folderid,
                    title: '下载文件',
                    url: top.$.rootUrl + '/LR_SystemModule/Annexes/DownForm?keyVaule=' + folderid,
                    width: 600,
                    height: 400,
                    maxmin: true,
                    btn: null
                });
            }
            _upload = function (folderid) {
                learun.layerForm({
                    id: '_upload_'+folderid,
                    title: '上传云盘',
                    url: top.$.rootUrl + '/LR_CodeDemo/MyDocument/DownForm?keyVaule=' + folderid,
                    width: 600,
                    height: 400,
                    maxmin: true,
                    btn: null
                });
            }
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/LR_CodeDemo/MyDocument/GetPageList1',
                headData: [
                    {
                        label: "时间", name: "time", width: 100, align: "center", formatter: function (value) {
                            if (value && value.length > 10) {
                                return value.substr(0, 10)
                            }
                            return value
                        }
                    },
                    {
                        label: "类别", name: "type", width: 300, align: "center",
                    },
                    {
                        label: "名称", name: "name", width: 300, align: "center",
                    },
                    {
                        label: "表单", name: "key", width: 200, align: "center", formatter: function (value) {
                            return ('<button class="btn btn-success btn-xs" onclick = "_open(\'' + value + '\')">查看</button>' +
                                '<button class="btn btn-success btn-xs" style="margin-left:5px" onclick = "_print(\'' + value + '\')">打印</button>'
                            );
                        }
                    },
                    {
                        label: "附件", name: "", width: 100, align: "center", formatter: function (value,row) {
                            return '<button class="btn btn-success btn-xs" onclick = "_download(\'' + row.file + '\')">下载</button>'
                            
                        }
                    },
                    {
                        label: "上传云盘", name: "file", width: 100, align: "center", formatter: function (value) {
                            return ('<button class="btn btn-success btn-xs" onclick = "_upload(\'' + value + '\')">上传</button>')
                        }
                    },
                ],
                mainId: 'time',
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
