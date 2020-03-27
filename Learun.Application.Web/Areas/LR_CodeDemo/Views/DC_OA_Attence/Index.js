/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-25 16:49
 * 描  述：DC_OA_Attence
 */
var refreshGirdData;
var query;
var isPower = request('isPower');
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
                    page.search({ F_OA_AttenceDeptId: item.id });
              
                }
            });
            $('#multiple_condition_query').lrMultipleQuery(function (queryJson) {
                page.search(queryJson);
            }, 220, 400);

            $('#DC_OA_AttenceMonth').lrDataSourceSelect({ code: 'GetMonth', value: 'itemvalue', text: 'text' });
            $('#F_OA_AttenceUserId').lrUserSelect(0); 
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 打印
            $('#lr_print').on('click', function () {
                $('#gridtable').jqprintTable();
            });
            //导出
            $('#lr-export').on('click', function () {
                learun.download({
                    method: "POST",
                    url: '/LR_CodeDemo/DC_OA_Attence/ExportExcel',
                    param: {
                        fileName: "月考勤表",
                        columnJson: JSON.stringify($('#gridtable').jfGridGet('settingInfo').headData),
                        dataJson: JSON.stringify($('#gridtable').jfGridGet('settingInfo').rowdatas),
                        queryJson: JSON.stringify(query)
                    }
                });
            });

            // 修改状态
            $('#lr_create').on('click', function () {
               
                    learun.layerConfirm('是否生成上个月考勤台账！', function (res) {
                        if (res) {
                            learun.postForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_Attence/Create',  function () {
                                refreshGirdData();
                            });
                           // refreshGirdData();
                        }
                    });
               });
         
        },

        
        //按姓名，部门，岗位 工作天数，出勤天数，出差天数，请假天数，加班天数，缺卡次数，补卡次数，说明
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_Attence/GetPageList?isPower=' + isPower,
                headData: [
                    { label: "姓名", name: "F_OA_AttenceUserName", width: 100, align: "left" },
                    { label: "部门", name: "F_DeptName", width: 150, align: "left" },
                    { label: "岗位名称", name: "PostName", width: 200, align: "left" },
                    { label: "考勤月份", name: "DC_OA_AttenceMonth", width: 120, align: "left" },
                    { label: "出勤天数", name: "F_SumDays", width: 100, align: "left" },
                    { label: "正常天数", name: "F_ComonDays", width: 100, align: "left" },
                    { label: "请假天数", name: "F_LeaveDays", width: 100, align: "left" },
                    { label: "出差天数", name: "F_OutDays", width: 100, align: "left" },
                    { label: "上班缺卡", name: "F_ForgetNums", width: 100, align: "left" },
                    { label: "补卡次数", name: "F_RepairNums", width: 100, align: "left" },
                    { label: "迟到早退次数", name: "F_laterNums", width: 100, align: "left" },
                    { label: "下班缺卡", name: "F_OutForgetNums", width: 100, align: "left" },
                    { label: "旷工天数", name: "F_NotWorkDays", width: 100, align: "left"},
                    { label: "事假天数", name: "F_thingDays", width: 100, align: "left"},
                    { label: "休假天数", name: "F_xiujiaDays", width: 100, align: "left"},
                    { label: "报备天数", name: "F_PersonBackDays", width: 100, align: "left"},
                    { label: "病假天数", name: "F_SickLeaveDays", width: 100, align: "left"},
                    { label: "调休天数", name: "F_TiaoDays", width: 100, align: "left"},
                    { label: "工作时长", name: "F_WorkHours", width: 100, align: "left" },
                    { label: "1号", name: "day1", width: 80, align: "left" },
                    { label: "2号", name: "day2", width: 80, align: "left" },
                    { label: "3号", name: "day3", width: 80, align: "left" },
                    { label: "4号", name: "day4", width: 80, align: "left" },
                    { label: "5号", name: "day5", width: 80, align: "left" },
                    { label: "6号", name: "day6", width: 80, align: "left" },
                    { label: "7号", name: "day7", width: 80, align: "left" },
                    { label: "8号", name: "day8", width: 80, align: "left" },
                    { label: "9号", name: "day9", width: 80, align: "left" },
                    { label: "10号", name: "day10", width: 80, align: "left" },
                    { label: "11号", name: "day11", width: 80, align: "left" },
                    { label: "12号", name: "day12", width: 80, align: "left" },
                    { label: "13号", name: "day13", width: 80, align: "left" },
                    { label: "14号", name: "day14", width: 80, align: "left" },
                    { label: "15号", name: "day15", width: 80, align: "left" },
                    { label: "16号", name: "day16", width: 80, align: "left" },
                    { label: "17号", name: "day17", width: 80, align: "left" },
                    { label: "18号", name: "day18", width: 80, align: "left" },
                    { label: "19号", name: "day19", width: 80, align: "left" },
                    { label: "20号", name: "day20", width: 80, align: "left" },
                    { label: "21号", name: "day21", width: 80, align: "left" },
                    { label: "22号", name: "day22", width: 80, align: "left" },
                    { label: "23号", name: "day23", width: 80, align: "left" },
                    { label: "24号", name: "day24", width: 80, align: "left" },
                    { label: "25号", name: "day25", width: 80, align: "left" },
                    { label: "26号", name: "day26", width: 80, align: "left" },
                    { label: "27号", name: "day27", width: 80, align: "left" },
                    { label: "28号", name: "day28", width: 80, align: "left" },
                    { label: "29号", name: "day29", width: 80, align: "left" },
                    { label: "30号", name: "day30", width: 80, align: "left" },
                    { label: "31号", name: "day31", width: 80, align: "left" },
             
                ],
                mainId:'DC_OA_AttenceId',
                isPage: true
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            query = param;
            $('#gridtable').jfGridSet('reload',{ queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
