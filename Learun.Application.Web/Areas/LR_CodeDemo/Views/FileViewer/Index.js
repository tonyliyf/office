/* * 版 本 Learun-ADMS V7.0.0 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-07 11:19
 * 描  述：DC_OA_OverSeeWork
 */
var refreshGirdData;
var FIDS = request('FIDS')
var _open
var _download
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            page.initGird();
            page.bind();
        },
        bind: function () {
            // 初始化左侧树形数据
            $('#dataTree').lrtree({
                data: [
                    {
                        "id": "0", "text": "所有", "title": null, "value": "2", "icon": null, "showcheck": false,
                        "checkstate": 0, "hasChildren": false, "isexpand": true, "complete": true, "ChildNodes": [], "parentId": "1"
                    }, {
                        "id": "1", "text": "文档", "title": null, "value": "2", "icon": null, "showcheck": false,
                        "checkstate": 0, "hasChildren": false, "isexpand": true, "complete": true, "ChildNodes": [], "parentId": "1"
                    },
                    {
                        "id": "2", "text": "图片", "title": null, "value": "2", "icon": null, "showcheck": false,
                        "checkstate": 0, "hasChildren": false, "isexpand": true, "complete": true, "ChildNodes": [], "parentId": "1"
                    }, {
                        "id": "3", "text": "其他", "title": null, "value": "2", "icon": null, "showcheck": false,
                        "checkstate": 0, "hasChildren": false, "isexpand": true, "complete": true, "ChildNodes": [], "parentId": "1"
                    }],
                nodeClick: function (item) {
                    if (item.parentId != 0) {
                        page.search({ type: item.id });
                    }
                }
            });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });


            $('#lr_brower').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '查看图片',
                    url: top.$.rootUrl + '/LR_CodeDemo/FileViewer/FileViewer?fid=' + words[0],
                    width: 800,
                    height: 1000,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
        },
        // 初始化列表
        initGird: function () {
            _download = function (fileid) {
                learun.download({ url: top.$.rootUrl + '/LR_SystemModule/Annexes/DownAnnexesFile', param: { fileId: fileid, __RequestVerificationToken: $.lrToken }, method: 'POST' })
            }
            _open = function (fileid) {

                var words = fileid.split(',')
                var aa = words[1];
                if (aa == 'png' || aa == 'gif' || aa == 'jpg' || aa == 'bmp' || aa == 'jpeg') {

                    learun.layerForm({
                        id: 'form',
                        title: '查看图片',
                        url: top.$.rootUrl + '/LR_CodeDemo/FileViewer/FileViewer?fid='+ words[0],
                        width: 800,
                        height:1000,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });

                }
                else {
                    learun.layerForm({
                        id: 'form',
                        title: '查看附件',
                        url: top.$.rootUrl + '/LR_CodeDemo/FileViewer/FileViewerWnd?fid=' + words[0],
                        width: 1080,
                        height: 850,
                        btn: null
                    });
                }
            }
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/LR_CodeDemo/FileViewer/GetList?folderIdList=' + FIDS,
                headData: [
                    {
                        label: "名称", name: "F_FileName", width: 300, align: "center",
                        formatter: function (cellvalue, options, rowObject) {
                            if (options.length != 0) {
                                return "<div style='cursor:pointer;'><div style='float: left;'><img src='" + top.$.rootUrl + "/Content/images/filetype/" + options.F_FileType + ".png' style='width:30px;height:30px;padding:5px;margin-left:-5px;margin-right:5px;' /></div><div style='float: left;line-height:35px;'>" + options.F_FileName + "</div></div>";
                            }

                        }
                    },
                    {
                        label: "大小", name: "F_FileSize", width: 300, align: "center",
                        formatter: function (cellvalue, options, rowObject) {
                            return page.CountFileSize(cellvalue);
                        }
                    },
                    {
                        label: "上传时间", name: "F_CreateDate", width: 100, align: "center", formatter: function (value) {
                            if (value && value.length > 10) {
                                return value.substr(0, 10)
                            }
                            return value
                        }
                    },
                    {
                        label: "下载", name: "", width: 100, align: "center", formatter: function (value, row) {
                            return '<button class="btn btn-success btn-xs" onclick = "_download(\'' + row.F_Id + '\')">下载</button>'

                        }
                    },
                    {
                        label: "预览", name: "F_Id", width: 100, align: "center", formatter: function (cellvalue, options, rowObject) {
                            return ('<button class="btn btn-success btn-xs" onclick = "_open(\'' + cellvalue + ',' +options.F_FileType+'\' )">预览</button>')
                        }
                    },
                ],
                mainId: 'time',
                isPage: false
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            $('#gridtable').jfGridSet('reload', { queryJson: JSON.stringify(param) });
        },
        CountFileSize: function (Size) {
            var m_strSize = "";
            var FactSize = 0;
            FactSize = Size;
            if (FactSize < 1024.00)
                m_strSize = page.ToDecimal(FactSize) + " 字节";
            else if (FactSize >= 1024.00 && FactSize < 1048576)
                m_strSize = page.ToDecimal(FactSize / 1024.00) + " KB";
            else if (FactSize >= 1048576 && FactSize < 1073741824)
                m_strSize = page.ToDecimal(FactSize / 1024.00 / 1024.00) + " MB";
            else if (FactSize >= 1073741824)
                m_strSize = page.ToDecimal(FactSize / 1024.00 / 1024.00 / 1024.00) + " GB";
            return m_strSize;
        },
        ToDecimal: function (x) {
            var f = parseFloat(x);
            if (isNaN(f)) {
                return 0;
            }
            f = Math.round(x * 100) / 100;
            return f;
        },
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
