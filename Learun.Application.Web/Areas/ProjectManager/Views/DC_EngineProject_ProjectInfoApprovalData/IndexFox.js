/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-03-25 15:19
 * 描  述：DC_EngineProject_ProjectInfoApprovalData
 */
var refreshGirdData;
//var F_PIId = '';
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
                url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfoApprovalData/GetPorjectTree',
                nodeClick: function (item) {
                    page.search({ F_PIId: item.id });
                }
            });


            //查看附件
            $('#lr_file').on('click', function () {
              
                    var FIDS = $('#gridtable').jfGridValue('F_Attachment')
                    var FIDS1 = $('#gridtable').jfGridValue('F_DataPhoto')
                    
                    top.learun.frameTab.open({
                        F_ModuleId: FIDS, F_Icon: '',
                        F_FullName: '附件信息查看', F_UrlAddress: '/LR_CodeDemo/FileViewer/Index?FIDS=' + FIDS + ',' + FIDS1 
                    });
               
            })



            //查看所有图片
            $('#lr_file1').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_HouseID')
                if (learun.checkrow(keyValue)) {
                    var FIDS = $('#gridtable').jfGridValue('F_ContractAccessories')
                    var FIDS1 = $('#gridtable').jfGridValue('F_SalesConfirmation')
                    var FIDS2 = $('#gridtable').jfGridValue('F_NoteAccessories')
                    var FIDS3 = $('#gridtable').jfGridValue('F_PictureAccessories')
                    var FIDS4 = $('#gridtable').jfGridValue('F_OtherAccessories')
                    var FIDS5 = $('#gridtable').jfGridValue('F_PictureAccessories_HouseInfo')
                    top.learun.frameTab.open({
                        F_ModuleId: FIDS, F_Icon: '',
                        F_FullName: '图片查看', F_UrlAddress: '/LR_CodeDemo/FileViewer/ImageViewer?FIDS=' + FIDS + ',' + FIDS1 + ',' + FIDS2 + ',' + FIDS3 + ',' + FIDS4 + ',' + FIDS5
                    });
                }
            })
         
            $('#multiple_condition_query').lrMultipleQuery(function (queryJson) {
                page.search(queryJson);
            }, 220, 400);
            $('#F_PIId').lrDataSourceSelect({ code: 'ProjectInfo',value: 'f_piid',text: 'f_projectname' });
             // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfoApprovalData/Form?F_PIId=' + F_PIId,
                    width: 600,
                    height: 400,
                    callBack: function (id) {
                        alert(id);
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_PICADId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfoApprovalData/Form?F_PIId=' + F_PIId + '&keyValue=' + keyValue,
                        width: 600,
                        height: 400,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_PICADId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfoApprovalData/DeleteForm', { keyValue: keyValue}, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            //导出
            $('#lr-export1').on('click', function () {
                learun.download({
                    method: "POST",
                    url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfoApprovalData/ExportExcel',
                    param: {
                        fileName: "信息表",
                        columnJson: JSON.stringify($('#gridtable').jfGridGet('settingInfo').headData),
                        queryJson: JSON.stringify(query)
                    }
                });
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfoApprovalData/GetPageInfoList',
                headData: [
                   
                    {
                        label: "项目阶段", name: "F_ItemName", width: 200, align: "left"
                      },
                    { label: "资料编号", name: "F_DataCode", width: 150, align: "left"},
                    { label: "资料名称", name: "F_DataName", width: 150, align: "left"},
                  
                ],

                mainId: 'F_ItemId',
                parentId: 'F_ParentId',
                isTree: true,
                dblclick: function (rowdata) {
                   
                    var FIDS = $('#gridtable').jfGridValue('F_DataPhoto')
                  
                    top.learun.frameTab.open({
                        F_ModuleId: FIDS, F_Icon: '',
                        F_FullName: '图片查看', F_UrlAddress: '/LR_CodeDemo/FileViewer/ImageViewer?FIDS=' + FIDS 
                    });
                   
                }
               
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
          //  param.F_PIId = F_PIId;
            query = param;
            $('#gridtable').jfGridSet('reload', { queryJson: JSON.stringify(param) });

        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
