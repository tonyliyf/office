/*
 * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：
 * 日 期：2018.11.15
 * 描 述：印章列表	
 */
var strRoot = window.location.protocol + "//" + window.location.host
var keyword;
var acceptClick;
var path = '';
var bootstrap = function ($, learun) {
    "use strict";
    // 保存数据
    var page = {
        init: function () {
            page.bind();
            page.initData();
        },
        bind: function () {
            // 订单产品信息
            $('#datagird').jfGrid({
                headData: [
                    { label: '印章名称', name: 'F_StampName', width: 150, align: "center" },
                    { label: '印章分类', name: 'F_StampType', width: 100, align: "center" },
                    {
                        label: '图片', name: 'F_ImgFile', width: 110, align: "center",
                        formatter: function (value, row, op, $cell) {
                            return '<img src="' + strRoot + '/LR_CodeDemo/WebOffice/GetImg?keyValue=' + row.F_StampId + '"  style="position: absolute;height:100px;width:100px;top:5px;left:5px;" >';
                        }
                    },
                    { label: '备注', name: 'F_Description', width: 200, align: "left" }
                ],
                mainId: 'F_StampId',
                rowHeight: 110,
            });
            //查询
            $('#btn_Search').on('click', function () {
                keyword = $('#txt_Keyword').val();
                page.search({ keyword: keyword });
            });
        },
        initData: function () {
            $.lrSetForm(strRoot + '/LR_CodeDemo/WebOffice/GetList?keyword=' + '', function (data) {
                $('.lr-layout-wrap').lrSetFormData(data.data);
                $('#datagird').jfGridSet('refreshdata', data);
            });
        },
        search: function (param) {
            param = param || {};
            $.lrSetForm(strRoot + '/LR_CodeDemo/WebOffice/GetList?keyword=' + keyword, function (data) {
                $('.lr-layout-wrap').lrSetFormData(data.data);
                $('#datagird').jfGridSet('refreshdata', data);

            });
        }
    };
    acceptClick = function (callBack) {
        var keyValue = $("#datagird").jfGridValue("F_StampId");
        learun.layerClose(window.name)
        callBack(keyValue)
    };
    page.init();
}