
/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn) 
 * Copyright (c) 2013-2018 上海力软信息技术有限公司 
 * 创建人：超级管理员 
 * 日  期：2019-04-04 10:50 
 * 描  述：DC_OA_PerformanceCheck 
 */
var refreshGirdData;
var F_CheckUserDeptId;
var query;
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
                url: top.$.rootUrl + '/LR_CodeDemo/WfTree/GetDeptTree',
                nodeClick: function (item) {
                  
                    F_CheckUserDeptId = item.id;
                  
                    page.search();
                }
            });
            $('#multiple_condition_query').lrMultipleQuery(function (queryJson) {
                page.search(queryJson);
            }, 220, 400);

            $('#F_CheckUserid').lrUserSelect(0);
            // 刷新 
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 删除 
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_EmpolyeeCheckId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceCheck/DeleteForm', { keyValue: keyValue }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            // 打印 
            $('#lr_print').on('click', function () {
                $('#gridtable').jqprintTable();
            });
            //导出
            $('#lr-export').on('click', function () {
                learun.download({
                    method: "POST",
                    url: '/LR_CodeDemo/DC_OA_PerformanceCheck/ExportExcel',
                    param: {
                        fileName: "员工月度绩效考核表",
                        columnJson: JSON.stringify($('#gridtable').jfGridGet('settingInfo').headData),
                        dataJson: JSON.stringify($('#gridtable').jfGridGet('settingInfo').rowdatas),
                        queryJson: JSON.stringify(query)
                    }
                });
            });
        },
        // 初始化列表 
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceCheck/GetPageList1',
                headData: [
                    {
                        label: "被考核员工", name: "F_CheckUserid", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('user', {
                                key: value,
                                callback: function (_data) {
                                    callback(_data.name);
                                }
                            });
                        }
                    },
                    { label: "考核类别", name: "F_TimeType", width: 100, align: "left" },
                    { label: "基准分", name: "F_BaseNumber", width: 100, align: "left" }, 
                    { label: "绩效小组扣分", name: "F_JixaoNumber", width: 100, align: "left" },
                    { label: "上级领导扣分", name: "F_CheckNumber", width: 100, align: "left" },
                    { label: "扣分合计", name: "F_KofenNum", width: 100, align: "left" }, 
                    { label: "扣分说明", name: "F_RecNumberComments", width: 240, align: "left" },
                    { label: "加分", name: "F_AddNumber", width: 100, align: "left" },
                    { label: "加分说明", name: "F_AddNumberComments", width: 240, align: "left" },
                    { label: "最终得分", name: "F_JiafenNum", width: 100, align: "left" },
                ], 
                mainId: 'F_EmpolyeeCheckId',
                isPage: true
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            query = param;
            param.F_CheckUserDeptId = F_CheckUserDeptId;
            $('#gridtable').jfGridSet('reload', { queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
} 
