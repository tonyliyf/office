/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-18 11:10
 * 描  述：DC_ASSETS_EquipmentMaintenanceRecords
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
            $('#F_ApplicationUserId').lrUserSelect(0);
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            $('#btn_complete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_EMRId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认办结！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_EquipmentMaintenanceRecords/DoComplete', { keyValue: keyValue }, function (res) {
                                page.search()
                            });
                        }
                    });
                }
            });
            $('#btn_detail').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_EMRId');
               
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: '__form',
                        title: '维修流程',
                        url: top.$.rootUrl + '/AssetManager/DC_ASSETS_EquipmentMaintenanceRecordsProcess/index?PID=' + keyValue,
                        width: 1200,
                        height: 800,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/AssetManager/DC_ASSETS_EquipmentMaintenanceRecords/GetPageList',
                headData: [
                    { label: "维修单号", name: "F_MaintenanceNumber", width: 200, align: "center" },
                    {
                        label: "维修申请人", name: "F_ApplicationUserId", width: 100, align: "center",
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
                        label: "维修申请日期", name: "F_ApplicationDate", width: 100, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                            if (value.length <= 10) {
                                callback(value);
                            } else {
                                callback(value.substring(0, 10));
                            }
                        }
                    },
                    {
                        label: "设备名称", name: "F_EIId", width: 100, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('custmerData', {
                                url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'DeviceData',
                                key: value,
                                keyId: 'f_eiid',
                                callback: function (_data) {
                                    callback(_data['f_equipmentname']);
                                }
                            });
                        }
                    },
                    { label: "设备编号", name: "F_CreateUser", width: 200, align: "center" },
                    { label: "规格型号", name: "F_CreateDatetime", width: 200, align: "center" },
                    {
                        label: "维修状态", name: "State", width: 100, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            var text = ''
                            switch (value) {
                                case 0:
                                    text = '申请中'
                                    break;
                                case 1:
                                    text = '维修中'
                                    break;
                                case 2:
                                    text = '已完成'
                                    break;
                            }
                            callback(text)
                        }
                    },
                    { label: "故障描述", name: "F_FaultDescription", width: 300, align: "center" },
                ],
                mainId: 'F_EMRId',
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
            // 发起流程
            learun.workflowapi.create({
                isNew: true,
                schemeCode: 'EquipmentMaintenance',// 填写流程对应模板编号
                processId: processId,
                processName: '设备维修申请',// 对应流程名称
                processLevel: '1',
                description: '',
                formData: JSON.stringify(postData),
                callback: function (res, data) {
                }
            });
            page.search();
        }
    };
    page.init();
}
