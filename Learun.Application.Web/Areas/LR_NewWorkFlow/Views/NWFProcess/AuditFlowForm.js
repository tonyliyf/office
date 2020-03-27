/*
 * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：-前端开发组
 * 日 期：2017.04.18
 * 描 述：审核流程	
 */
var acceptClick;
var bootstrap = function ($, learun) {

    
    "use strict";
    var processId = request('processId');      // 流程进程主键
    var taskId = request('taskId');            // 流程任务主键
    var next = request('next');                // 下一节点是否允许指定审核人 1不允许 2允许
    var operationCode = request('operationCode');        
    var currentNode = learun.frameTab.currentIframe().nwflow.currentNode;
    var nodeList = learun.frameTab.currentIframe().nwflow.schemeObj.nodes;
    var nodeMap = {};
    var bool = false;
    var page = {
        init: function () {
            $('#DC_OA_Sign').lrDataSourceSelect({ code: 'GetSign', value: 'dc_oa_sign', text: 'dc_oa_content' });
            $("#DC_OA_Sign").change(function () {

                if (bool == false) {
                    bool = true;
                }
                else {
                    $("#des").val($("#des").val($(this).text()));
                }
            });
            $(function () {
                $("#save").click(function () {


                    var data = $("#des").val(); 
                    if (data != null || data != "") {
                        //$.post("/LR_CodeDemo/DC_OA_SignContent/SaveForm1", { keyValue: data })
                        $.post(top.$.rootUrl + '/LR_CodeDemo/DC_OA_SignContent/SaveForm1', { keyValue: data }, function (res) {
                            // 保存成功后才回调
                            alert('保存成功！')
                           
                           
                        });

                    }
                });
            })
            if (next == '2') {
                // 获取下一节点数据
                // 节点信息
                $.each(nodeList, function (_index, _item) {
                    nodeMap[_item.id] = _item;
                });
                var param = {
                    processId: processId,
                    taskId: taskId,
                    nodeId: currentNode.id,
                    operationCode: operationCode
                };
                learun.httpAsync('GET', top.$.rootUrl + '/LR_NewWorkFlow/NWFProcess/GetNextAuditors', param, function (data) {
                    var $form = $('#form .lr-scroll-box');
                    if (data) {
                        $.each(data, function (_id, _list) {
                            $form.append('<div class="col-xs-12 lr-form-item"><div class="lr-form-item-title" >'
                                + nodeMap[_id].name.replace('<br/>【多人审核:并行】', '').replace('<br/>【多人审核:串行】', '') + '</div><div id="'
                                + _id + '" class="nodeId" style="width:80%" ></div><button id="_' + _id + '" class="btn btn-primary" style="position: absolute;right: 0px;top: 5px;bottom: 5px;line-height:5px"><i class="fa fa-search"></i></button></div >');
                            $('#' + _id).lrselect({
                                type: 'multiple',
                                data: _list,
                                value: 'Id',
                                maxHeight: 100,
                                allowSearch: true,
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
                                            $('#' + _id).lrselectSet(data)
                                        });
                                    }
                                });
                            });
                        });
                    }
                });
            }
           

        }
    };
    // 保存数据
    acceptClick = function (callBack) {
        var formData = $('#form').lrGetFormData();
        //liyf 加入 不同意，要求填写意见和建议  20190410
        if (operationCode == 'disagree' && formData.des=='')
        {
            alert('请填写不同意的意见和建议！')
            return false
        }
        // 获取审核人员
        var auditers = {};
        $('#form').find('.nodeId').each(function () {
            var $this = $(this);
            var id = $this.attr('id');
            if (formData[id]) {
                auditers[id] = formData[id];
            }
        });
        callBack(formData.des, auditers);
        return true;
    };
    page.init();
}