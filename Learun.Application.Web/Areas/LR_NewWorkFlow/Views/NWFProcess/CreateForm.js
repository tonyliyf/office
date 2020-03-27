/*
 * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：-前端开发组
 * 日 期：2017.04.18
 * 描 述：创建流程
 */
var acceptClick;
var bootstrap = function ($, learun) {
    "use strict";
    var shcemeCode = request('shcemeCode');    // 流程模板编号
    var processId = request('processId');      // 流程进程主键
    var taskId = request('taskId');            // 流程任务主键
    var showLevel = request('showLevel');
  

    var currentNode = learun.frameTab.currentIframe().nwflow.currentNode;
    var nodeList = learun.frameTab.currentIframe().nwflow.schemeObj.nodes;
    var nodeMap = {};

    var page = {
        init: function () {
            if (currentNode.isTitle != '1') {
                $('#F_Title').parent().remove();
            }
            if (showLevel == '0')
            {
                $('#F_Level').hide();
                $('#F_LevelTitle').hide();
                        
            }

            if (currentNode.isNext == '1') {// 获取下一节点数据
                // 节点信息
                $.each(nodeList, function (_index, _item) {
                    nodeMap[_item.id] = _item;
                });
                var param = {
                    code: shcemeCode,
                    processId: processId,
                    taskId: taskId,
                    nodeId: currentNode.id,
                    operationCode: 'agree'
                };

                learun.httpAsync('GET', top.$.rootUrl + '/LR_NewWorkFlow/NWFProcess/GetNextAuditors', param, function (data) {
                    var $form = $('#form .lr-scroll-box');
                    if (data) {
                        $.each(data, function (_id, _list) {
                            if (_list.length > 1) {
                                $form.append('<div class="col-xs-12 lr-form-item"><div class="lr-form-item-title" >'
                                    + nodeMap[_id].name.replace('<br/>【多人审核:并行】', '').replace('<br/>【多人审核:串行】', '') + '</div><div id="'
                                    + _id + '" class="nodeId" style="width:80%" ></div><button id="_' + _id + '" class="btn btn-primary" style="position: absolute;right: 0px;top: 5px;bottom: 5px;line-height:5px"><i class="fa fa-search"></i></button></div >');
                                $('#' + _id).lrselect({
                                    type: 'multiple',
                                    data: _list,
                                    maxHeight: 100,
                                    allowSearch: true,
                                    value: 'Id',
                                    text: 'Name'
                                });
                                $('#_' + _id).click(function () {
                                    learun.layerForm({
                                        id: 'treeform',
                                        title: '选择部门',
                                        url: top.$.rootUrl + '/LR_CodeDemo/WfTree/TreeView',
                                        width: 400,
                                        height: 300,
                                        callBack: function (id) {
                                            return top[id].acceptClick(function (data) {
                                                    if (data.length == 0) {
                                                    data = ['', '']
                                                }
                                                $('#' + _id).lrselectSet(data)
                                            });
                                        }
                                    });
                                });
                            }
                        });
                    }
                });
            }
        }
    };
    // 保存数据
    acceptClick = function (callBack) {
        if (!$('#form').lrValidform()) {
            return false;
        }
        var formData = $('#form').lrGetFormData();
        // 获取审核人员
        var auditers = {};
        $('#form').find('.nodeId').each(function () {
            var $this = $(this);
            var id = $this.attr('id');
            if (formData[id]) {
                //debugger;
                auditers[id] = formData[id];
            }
        });

        var data = {
            level: formData.F_Level
        };
        if (currentNode.isTitle == '1') {
            data.title = formData.F_Title;
        }
        callBack(data, auditers);
        return true;
    };
    page.init();
}