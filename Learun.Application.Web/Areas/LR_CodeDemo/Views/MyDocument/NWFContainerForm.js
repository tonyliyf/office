﻿/*
 * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：-前端开发组
 * 日 期：2018.12.11
 * 描 述：工作流操作界面 （会向系统表单页面传递create,againCreate,agree,disagree,sign,signAudit,自定义按钮编码）
 */
var nwflow;
var tabIframeId = request('tabIframeId');  // 当前窗口ID
var shcemeCode = request('shcemeCode');    // 流程模板编号
var type = request('type');                // 操作类型 look流程进度查看;create创建;draftCreate草稿创建;audit审批 againCreate重新创建 refer确认阅读 chlid子流程 
var processId = request('processId');      // 流程实例主键
var taskId = request('taskId');            // 任务主键
var showLevel = request('showLevel'); 

var wfFormParam = request('wfFormParam');  // 流程表单传递参数

var bootstrap = function ($, learun) {
    "use strict";
    // 表单页面对象集合
    var formIframesMap = {};
    var formIframes = [];
    var formIframesHave = {};

    // 流程
    nwflow = {
        schemeObj: null,
        nodeMap: {},
        currentNode: null,
        history: [],
        currentIds: [],
        taskInfo: [],

        processId: '',
        taskId: '',

        // 初始化
        init: function () {
            switch (type) {
                case 'look':   // 流程信息查看
                    nwflow.initLook();
                    break;
                case 'create': // 创建流程（第一次创建）
                    nwflow.initCreate();
                    break;
                case 'draftCreate': // 创建流程（草稿创建）
                    nwflow.initDraftCreate();
                    break;
                case 'againCreate': // 重新创建流程（被驳回后）
                    nwflow.initAgainCreate();
                    break;
                case 'audit':// 审批
                    nwflow.initAudit();
                    break;
                case 'signAudit':// 加签审批
                    nwflow.initSignAudit();
                    break;
                case 'refer': // 查阅
                    nwflow.initRefer();
                    break;
                case 'chlid': // 子流程创建
                    nwflow.initChlid();
                    break;
                case 'childlook':
                    nwflow.initChildlook();
                    break;
                case 'againChild':
                    nwflow.initAgainChild();
                    break;
            }
        },
        initLook: function () {
            nwflow.processId = processId;
            nwflow.taskId = taskId;
            nwflow.getProcessInfo(processId, taskId, function (data) {
                if (data) {
                    var info = data.info;
                    nwflow.taskInfo = data.task;
                    nwflow.schemeObj = JSON.parse(info.Scheme);
                    // 获取当前节点
                    $.each(nwflow.schemeObj.nodes, function (_index, _item) {
                        if (_item.id == info.CurrentNodeId) {
                            nwflow.currentNode = _item;
                            return false;
                        }
                    });
                    nwflow.loadForm(nwflow.currentNode.wfForms, true, true);

                    // 优化表单选项卡滚动条
                    $('#form_list_tabs_warp').lrscroll();
                    nwflow.history = info.TaskLogList;
                    nwflow.currentIds = info.CurrentNodeIds;

                    nwflow.loadFlowInfo();
                    nwflow.loadTimeLine();

                    if (info.parentProcessId) {
                        nwflow.pProcessId = info.parentProcessId;
                        $('#eye').show();
                    }
                }
            });
        },
        initCreate: function () {
            nwflow.processId = learun.newGuid();
            // 获取流程的模板
            nwflow.getSchemeByCode(shcemeCode, function (data) {
                if (data) {
                    nwflow.schemeObj = JSON.parse(data.F_Content);
                    // 获取开始节点
                    $.each(nwflow.schemeObj.nodes, function (_index, _item) {
                        if (_item.type == 'startround') {
                            nwflow.currentNode = _item;
                            return false;
                        }
                    });
                    nwflow.loadForm(nwflow.currentNode.wfForms);

                    // 优化表单选项卡滚动条
                    $('#form_list_tabs_warp').lrscroll();

                    nwflow.loadFlowInfo();
                    nwflow.loadTimeLine();

                    $('#release').show();
                    $('#release').on('click', function () {
                        // 验证表单数据完整性
                        if (!custmerForm.validForm('create'))// create创建流程
                        {
                            return false;
                        }
                        // 创建流程
                        learun.layerForm({
                            id: 'CreateForm',
                            title: '提交',
                            url: top.$.rootUrl + '/LR_NewWorkFlow/NWFProcess/CreateForm?shcemeCode=' + shcemeCode + '&showLevel=' + showLevel,
                            width: 500,
                            height: 400,
                            callBack: function (id) {
                                return top[id].acceptClick(function (formData, auditers) {
                                    // 保存表单数据
                                    custmerForm.save(nwflow.processId, nwflow.currentNode.wfForms, function () {
                                        // 创建流程
                                        learun.loading(true, '创建流程...');
                                        var postData = {
                                            schemeCode: shcemeCode,
                                            processId: nwflow.processId,
                                            title: formData.title,
                                            level: formData.level,
                                            auditors: JSON.stringify(auditers)
                                        };
                                        learun.httpAsync('Post', top.$.rootUrl + '/LR_NewWorkFlow/NWFProcess/CreateFlow', postData, function (data) {
                                            learun.loading(false);
                                            if (data) {
                                                learun.frameTab.parentIframe().refreshGirdData();
                                                learun.frameTab.close(tabIframeId);
                                            }
                                        });
                                    });
                                });
                            }
                        });
                    });
                    $('#savedraft').show();
                    $('#savedraft').on('click', function () {
                        // 保存表单数据
                        custmerForm.save(nwflow.processId, nwflow.currentNode.wfForms, function () {
                            // 创建流程
                            learun.loading(true, '保存流程草稿...');
                            var postData = {
                                schemeCode: shcemeCode,
                                processId: nwflow.processId
                            };
                            learun.httpAsync('Post', top.$.rootUrl + '/LR_NewWorkFlow/NWFProcess/SaveDraft', postData, function (data) {
                                learun.loading(false);
                                if (data) {
                                    learun.frameTab.parentIframe().refreshGirdData();
                                    learun.frameTab.close(tabIframeId);
                                }
                            });
                        });
                    });
                }
            });
        },
        initDraftCreate: function () {
            nwflow.processId = processId;
            nwflow.getSchemeByProcessId(processId, function (data) {
                if (data) {
                    nwflow.schemeObj = JSON.parse(data.F_Content);
                    // 获取开始节点
                    $.each(nwflow.schemeObj.nodes, function (_index, _item) {
                        if (_item.type == 'startround') {
                            nwflow.currentNode = _item;
                            return false;
                        }
                    });
                    nwflow.loadForm(nwflow.currentNode.wfForms, true);

                    // 优化表单选项卡滚动条
                    $('#form_list_tabs_warp').lrscroll();

                    nwflow.loadFlowInfo();
                    nwflow.loadTimeLine();

                    $('#release').show();
                    $('#release').on('click', function () {
                        // 验证表单数据完整性
                        if (!custmerForm.validForm('create'))// create创建流程
                        {
                            return false;
                        }
                        // 创建流程
                        learun.layerForm({
                            id: 'CreateForm',
                            title: '创建流程',
                            url: top.$.rootUrl + '/LR_NewWorkFlow/NWFProcess/CreateForm?processId=' + nwflow.processId + '&showLevel=' + showLevel,
                            width: 400,
                            height: 340,
                            callBack: function (id) {
                                return top[id].acceptClick(function (formData, auditers) {
                                    // 保存表单数据
                                    custmerForm.save(nwflow.processId, nwflow.currentNode.wfForms, function () {
                                        // 创建流程
                                        learun.loading(true, '创建流程...');
                                        var postData = {
                                            processId: nwflow.processId,
                                            title: formData.title,
                                            level: formData.level,
                                            auditors: JSON.stringify(auditers)
                                        };
                                        learun.httpAsync('Post', top.$.rootUrl + '/LR_NewWorkFlow/NWFProcess/CreateFlow', postData, function (data) {
                                            learun.loading(false);
                                            if (data) {
                                                learun.frameTab.parentIframe().refreshGirdData();
                                                learun.frameTab.close(tabIframeId);
                                            }
                                        });
                                    });
                                });
                            }
                        });
                    });
                    $('#savedraft').show();
                    $('#savedraft').on('click', function () {
                        // 保存表单数据
                        custmerForm.save(nwflow.processId, nwflow.currentNode.wfForms, function () {
                            // 创建流程
                            learun.loading(true, '保存流程草稿...');
                            var postData = {
                                schemeCode: shcemeCode,
                                processId: nwflow.processId
                            };
                            learun.httpAsync('Post', top.$.rootUrl + '/LR_NewWorkFlow/NWFProcess/SaveDraft', postData, function (data) {
                                learun.loading(false);
                                if (data) {
                                    learun.frameTab.parentIframe().refreshGirdData();
                                    learun.frameTab.close(tabIframeId);
                                }
                            });
                        });
                    });
                }
            });
        },
        initAgainCreate: function () {
            nwflow.processId = processId;
            nwflow.getProcessInfo(processId, '', function (data) {
                if (data) {
                    var info = data.info;
                    nwflow.taskInfo = data.task;

                    nwflow.schemeObj = JSON.parse(info.Scheme);
                    // 获取当前节点
                    $.each(nwflow.schemeObj.nodes, function (_index, _item) {
                        if (_item.id == info.CurrentNodeId) {
                            nwflow.currentNode = _item;
                            return false;
                        }
                    });
                    nwflow.loadForm(nwflow.currentNode.wfForms, true);
                    // 优化表单选项卡滚动条
                    $('#form_list_tabs_warp').lrscroll();
                    nwflow.history = info.TaskLogList;
                    nwflow.currentIds = info.CurrentNodeIds;

                    nwflow.loadFlowInfo();
                    nwflow.loadTimeLine();

                    // 加载审批按钮

                    $('#release').show();
                    $('#release').text('重新发起');
                    $('#release').on('click', function () {
                        // 验证表单数据完整性
                        if (!custmerForm.validForm('againCreate'))// againCreate重新创建创建流程
                        {
                            return false;
                        }
                        learun.layerConfirm('是否重新发起流程！', function (res, index) {
                            if (res) {
                                custmerForm.save(nwflow.processId, nwflow.currentNode.wfForms, function () {
                                    // 创建流程
                                    learun.loading(true, '重新发起流程...');
                                    var postData = {
                                        processId: nwflow.processId
                                    };
                                    learun.httpAsync('Post', top.$.rootUrl + '/LR_NewWorkFlow/NWFProcess/AgainCreateFlow', postData, function (_data) {
                                        learun.loading(false);
                                        if (_data) {
                                            learun.frameTab.parentIframe().refreshGirdData();
                                            learun.frameTab.close(tabIframeId);
                                        }
                                    });
                                });
                                top.layer.close(index);
                            }
                        });
                    });
                }
            });
        },

        initAudit: function () {
            nwflow.processId = processId;
            nwflow.taskId = taskId;
            nwflow.getProcessInfo(processId, taskId, function (data) {
                if (data) {
                    var info = data.info;
                    nwflow.taskInfo = data.task;

                    nwflow.schemeObj = JSON.parse(info.Scheme);
                    // 获取当前节点
                    $.each(nwflow.schemeObj.nodes, function (_index, _item) {
                        if (_item.id == info.CurrentNodeId) {
                            nwflow.currentNode = _item;
                            return false;
                        }
                    });
                    nwflow.loadForm(nwflow.currentNode.wfForms, true);
                    // 优化表单选项卡滚动条
                    $('#form_list_tabs_warp').lrscroll();
                    nwflow.history = info.TaskLogList;
                    nwflow.currentIds = info.CurrentNodeIds;

                    nwflow.loadFlowInfo();
                    nwflow.loadTimeLine();

                    // 加载审批按钮
                    var $signBtn = $('#sign');
                    $.each(nwflow.currentNode.btnList, function (_index, _item) {
                        if (_item.isHide != '1') {
                            var _class = ' btn-warning';
                            if (_item.code == 'agree') {
                                _class = ' btn-success';
                            }
                            else if (_item.code == 'disagree') {
                                _class = ' btn-danger';
                            }

                            var $btn = $('<a class="verifybtn btn ' + _class + '"  >' + _item.name + '</a>');
                            $btn[0].lrbtn = _item;
                            $signBtn.after($btn);
                        }
                    });
                    $('.verifybtn').show();
                    $('.verifybtn').on('click', function () {
                        var btnData = $(this)[0].lrbtn;
                        // 验证表单数据完整性
                        if (!custmerForm.validForm(btnData.code))// create创建流程
                        {
                            return false;
                        }
                        // 创建审批
                        learun.layerForm({
                            id: 'AuditFlowForm',
                            title: "【审批】" + btnData.name,
                            url: top.$.rootUrl + '/LR_NewWorkFlow/NWFProcess/AuditFlowForm?processId=' + nwflow.processId + "&taskId=" + nwflow.taskId + "&next=" + btnData.next + "&operationCode=" + btnData.code,
                            width: 500,
                            height: 400,
                            callBack: function (id) {
                                return top[id].acceptClick(function (des, auditers) {
                                    // 保存表单数据
                                    custmerForm.save(nwflow.processId, nwflow.currentNode.wfForms, function () {
                                        // 审批流程
                                        learun.loading(true, '审批流程...');
                                        var postData = {
                                            operationCode: btnData.code,
                                            operationName: btnData.name,
                                            processId: nwflow.processId,
                                            taskId: nwflow.taskId,
                                            des: des,
                                            auditors: JSON.stringify(auditers)
                                        };
                                        learun.httpAsync('Post', top.$.rootUrl + '/LR_NewWorkFlow/NWFProcess/AuditFlow', postData, function (_data) {
                                            learun.loading(false);
                                            if (_data) {
                                                learun.frameTab.parentIframe().refreshGirdData();
                                                learun.frameTab.close(tabIframeId);
                                            }
                                        });
                                    });
                                });
                            }
                        });
                    });
                    if (nwflow.currentNode.isSign == "1") {
                        $('#sign').show();
                        $('#sign').on('click', function () {
                            // 验证表单数据完整性
                            if (!custmerForm.validForm("sign"))// create创建流程
                            {
                                return false;
                            }
                            // 创建审批
                            learun.layerForm({
                                id: 'SignFlowForm',
                                title: "加签",
                                url: top.$.rootUrl + '/LR_NewWorkFlow/NWFProcess/SignFlowForm',
                                width: 500,
                                height: 400,
                                callBack: function (id) {
                                    return top[id].acceptClick(function (formdata) {
                                        // 保存表单数据
                                        custmerForm.save(nwflow.processId, nwflow.currentNode.wfForms, function () {
                                            // 审批流程
                                            learun.loading(true, '流程加签...');
                                            var postData = {
                                                des: formdata.des,
                                                userId: formdata.auditorId,
                                                processId: nwflow.processId,
                                                taskId: nwflow.taskId
                                            };
                                            learun.httpAsync('Post', top.$.rootUrl + '/LR_NewWorkFlow/NWFProcess/SignFlow', postData, function (data) {
                                                learun.loading(false);
                                                if (data) {
                                                    learun.frameTab.parentIframe().refreshGirdData();
                                                    learun.frameTab.close(tabIframeId);
                                                }
                                            });
                                        });
                                    });
                                }
                            });

                        });
                    }

                    if (data.parentProcessId) {
                        nwflow.pProcessId = data.parentProcessId;
                        $('#eye').show();
                    }
                }
            });
        },
        initSignAudit: function () {
            nwflow.processId = processId;
            nwflow.taskId = taskId;
            nwflow.getProcessInfo(processId, taskId, function (data) {
                if (data) {
                    var info = data.info;
                    nwflow.taskInfo = data.task;

                    nwflow.schemeObj = JSON.parse(info.Scheme);
                    // 获取当前节点
                    $.each(nwflow.schemeObj.nodes, function (_index, _item) {
                        if (_item.id == info.CurrentNodeId) {
                            nwflow.currentNode = _item;
                            return false;
                        }
                    });
                    nwflow.loadForm(nwflow.currentNode.wfForms, true);
                    // 优化表单选项卡滚动条
                    $('#form_list_tabs_warp').lrscroll();
                    nwflow.history = info.TaskLogList;
                    nwflow.currentIds = info.CurrentNodeIds;

                    nwflow.loadFlowInfo();
                    nwflow.loadTimeLine();

                    // 加载审批按钮
                    var $signBtn = $('#sign');
                    var $btn1 = $('<a class="verifybtn btn btn-success"  >同意</a>');
                    $btn1[0].lrbtn = { code: 'agree', name: '同意' };
                    $signBtn.after($btn1);
                    var $btn2 = $('<a class="verifybtn btn btn-danger"  >不同意</a>');
                    $btn2[0].lrbtn = { code: 'disagree', name: '不同意' };
                    $signBtn.after($btn2);
                    $('.verifybtn').show();
                    $('.verifybtn').on('click', function () {
                        var btnData = $(this)[0].lrbtn;
                        // 验证表单数据完整性
                        if (!custmerForm.validForm(btnData.code))// create创建流程
                        {
                            return false;
                        }
                        // 创建审批
                        learun.layerForm({
                            id: 'AuditFlowForm',
                            title: "【加签审批】" + btnData.name,
                            url: top.$.rootUrl + '/LR_NewWorkFlow/NWFProcess/AuditFlowForm?operationCode=' + btnData.code,
                            width: 500,
                            height: 400,
                            callBack: function (id) {
                                return top[id].acceptClick(function (des, auditers) {
                                    // 保存表单数据
                                    custmerForm.save(nwflow.processId, nwflow.currentNode.wfForms, function () {
                                        // 审批流程
                                        learun.loading(true, '加签审批流程...');
                                        var postData = {
                                            operationCode: btnData.code,
                                            processId: nwflow.processId,
                                            taskId: nwflow.taskId,
                                            des: des
                                        };
                                        learun.httpAsync('Post', top.$.rootUrl + '/LR_NewWorkFlow/NWFProcess/SignAuditFlow', postData, function (_data) {
                                            learun.loading(false);
                                            if (_data) {
                                                learun.frameTab.parentIframe().refreshGirdData();
                                                learun.frameTab.close(tabIframeId);
                                            }
                                        });
                                    });
                                });
                            }
                        });
                    });

                    $signBtn.show();
                    $signBtn.on('click', function () {
                        // 验证表单数据完整性
                        if (!custmerForm.validForm("sign"))// create创建流程
                        {
                            return false;
                        }
                        // 创建审批
                        learun.layerForm({
                            id: 'SignFlowForm',
                            title: "加签",
                            url: top.$.rootUrl + '/LR_NewWorkFlow/NWFProcess/SignFlowForm',
                            width: 500,
                            height: 400,
                            callBack: function (id) {
                                return top[id].acceptClick(function (formdata) {
                                    // 保存表单数据
                                    custmerForm.save(nwflow.processId, nwflow.currentNode.wfForms, function () {
                                        // 审批流程
                                        learun.loading(true, '流程加签...');
                                        var postData = {
                                            des: formdata.des,
                                            userId: formdata.auditorId,
                                            processId: nwflow.processId,
                                            taskId: nwflow.taskId
                                        };
                                        learun.httpAsync('Post', top.$.rootUrl + '/LR_NewWorkFlow/NWFProcess/SignFlow', postData, function (data) {
                                            learun.loading(false);
                                            if (data) {
                                                learun.frameTab.parentIframe().refreshGirdData();
                                                learun.frameTab.close(tabIframeId);
                                            }
                                        });
                                    });
                                });
                            }
                        });

                    });
                }
            });
        },
        initRefer: function () {
            nwflow.processId = processId;
            nwflow.taskId = taskId;
            nwflow.getProcessInfo(processId, taskId, function (data) {
                if (data) {
                    var info = data.info;
                    nwflow.taskInfo = data.task;

                    nwflow.schemeObj = JSON.parse(info.Scheme);
                    // 获取当前节点
                    $.each(nwflow.schemeObj.nodes, function (_index, _item) {
                        if (_item.id == info.CurrentNodeId) {
                            nwflow.currentNode = _item;
                            return false;
                        }
                    });
                    nwflow.loadForm(nwflow.currentNode.wfForms, true);
                    // 优化表单选项卡滚动条
                    $('#form_list_tabs_warp').lrscroll();
                    nwflow.history = info.TaskLogList;
                    nwflow.currentIds = info.CurrentNodeIds;

                    nwflow.loadFlowInfo();
                    nwflow.loadTimeLine();

                    $('#confirm').show().on('click', function () {
                        learun.layerConfirm('是否确认阅读！', function (res, index) {
                            if (res) {
                                // 更新任务状态
                                learun.loading(true, '保存数据...');
                                var postData = {
                                    processId: nwflow.processId,
                                    taskId: nwflow.taskId
                                };
                                learun.httpAsync('Post', top.$.rootUrl + '/LR_NewWorkFlow/NWFProcess/ReferFlow', postData, function (_data) {
                                    learun.loading(false);
                                    if (_data) {
                                        learun.frameTab.parentIframe().refreshGirdData();
                                        learun.frameTab.close(tabIframeId);
                                    }
                                });
                                top.layer.close(index);
                            }
                        });
                    });
                }
            });
        },

        initChlid: function () {
            nwflow.taskId = taskId;
            nwflow.getProcessInfo(processId, taskId, function (data) {
                if (data) {
                    var info = data.info;
                    nwflow.taskInfo = data.task;

                    nwflow.schemeObj = JSON.parse(info.Scheme);
                    // 获取当前节点
                    $.each(nwflow.schemeObj.nodes, function (_index, _item) {
                        if (_item.id == info.CurrentNodeId) {
                            nwflow.currentNode = _item;
                            return false;
                        }
                    });
                    // 加载子流程
                    nwflow.processId = info.childProcessId;
                    nwflow.chlidProcessId = info.childProcessId;
                    // 获取流程的模板
                    nwflow.getSchemeByCode(nwflow.currentNode.childFlow, function (cdata) {
                        if (cdata) {
                            nwflow.schemeObj = JSON.parse(cdata.F_Content);
                            // 获取开始节点
                            $.each(nwflow.schemeObj.nodes, function (_index, _item) {
                                if (_item.type == 'startround') {
                                    nwflow.chlidCurrentNode = _item;
                                    return false;
                                }
                            });
                            nwflow.loadForm(nwflow.chlidCurrentNode.wfForms, true);

                            // 优化表单选项卡滚动条
                            $('#form_list_tabs_warp').lrscroll();
                            nwflow.history = cdata.TaskLogList || [];
                            nwflow.currentIds = cdata.CurrentNodeIds || '';
                            nwflow.loadFlowInfo();
                            nwflow.loadTimeLine();

                            $('#release').show();
                            $('#release').on('click', function () {
                                // 验证表单数据完整性
                                if (!custmerForm.validForm('create'))// create创建流程
                                {
                                    return false;
                                }


                                // 保存表单数据
                                custmerForm.save(nwflow.chlidProcessId, nwflow.chlidCurrentNode.wfForms, function () {
                                    // 创建流程
                                    learun.loading(true, '创建流程...');
                                    var postData = {
                                        schemeCode: nwflow.currentNode.childFlow,
                                        processId: nwflow.chlidProcessId,
                                        parentProcessId: nwflow.pProcessId,
                                        parentTaskId: nwflow.pTaskId
                                    };
                                    learun.httpAsync('Post', top.$.rootUrl + '/LR_NewWorkFlow/NWFProcess/CreateChildFlow', postData, function (_data) {
                                        learun.loading(false);
                                        if (_data) {
                                            learun.frameTab.parentIframe().refreshGirdData();
                                            learun.frameTab.close(tabIframeId);
                                        }
                                    });
                                });
                            });
                            $('#savedraft').show();
                            $('#savedraft').on('click', function () {
                                // 保存表单数据
                                custmerForm.save(nwflow.chlidProcessId, nwflow.chlidCurrentNode.wfForms, function () {
                                    learun.frameTab.close(tabIframeId);
                                });
                            });
                        }
                    });

                    nwflow.pTaskId = nwflow.taskId;
                    nwflow.pProcessId = processId;
                    $('#eye').show();
                }
            });
        },
        initChildlook: function () {
            nwflow.taskId = taskId;
            nwflow.getProcessInfo(processId, taskId, function (data) {
                if (data) {
                    var info = data.info;
                    nwflow.taskInfo = data.task;

                    nwflow.schemeObj = JSON.parse(info.Scheme);
                    // 获取当前节点
                    $.each(nwflow.schemeObj.nodes, function (_index, _item) {
                        if (_item.id == info.CurrentNodeId) {
                            nwflow.currentNode = _item;
                            return false;
                        }
                    });

                    // 加载子流程
                    nwflow.processId = info.childProcessId;
                    nwflow.chlidProcessId = info.childProcessId;
                    // 获取流程的模板
                    nwflow.getSchemeByCode(nwflow.currentNode.childFlow, function (cdata) {
                        if (cdata) {
                            nwflow.schemeObj = JSON.parse(cdata.F_Content);
                            // 获取开始节点
                            $.each(nwflow.schemeObj.nodes, function (_index, _item) {
                                if (_item.type == 'startround') {
                                    nwflow.chlidCurrentNode = _item;
                                    return false;
                                }
                            });
                            nwflow.loadForm(nwflow.chlidCurrentNode.wfForms, true, true);

                            // 优化表单选项卡滚动条
                            $('#form_list_tabs_warp').lrscroll();
                            nwflow.history = info.TaskLogList || [];
                            nwflow.currentIds = info.CurrentNodeIds || '';
                            nwflow.loadFlowInfo();
                            nwflow.loadTimeLine();
                        }
                    });

                    nwflow.pTaskId = nwflow.taskId;
                    nwflow.pProcessId = processId;
                    $('#eye').show();
                }
            });
        },
        initAgainChild: function () {
            nwflow.taskId = taskId;
            nwflow.getProcessInfo(processId, taskId, function (data) {
                if (data) {
                    var info = data.info;
                    nwflow.taskInfo = data.task;

                    nwflow.schemeObj = JSON.parse(info.Scheme);
                    // 获取当前节点
                    $.each(nwflow.schemeObj.nodes, function (_index, _item) {
                        if (_item.id == info.CurrentNodeId) {
                            nwflow.currentNode = _item;
                            return false;
                        }
                    });

                    // 加载子流程
                    nwflow.processId = info.childProcessId;
                    nwflow.chlidProcessId = info.childProcessId;
                    // 获取流程的模板
                    nwflow.getSchemeByCode(nwflow.currentNode.childFlow, function (cdata) {
                        if (cdata) {
                            nwflow.schemeObj = JSON.parse(cdata.F_Content);
                            // 获取开始节点
                            $.each(nwflow.schemeObj.nodes, function (_index, _item) {
                                if (_item.type == 'startround') {
                                    nwflow.chlidCurrentNode = _item;
                                    return false;
                                }
                            });
                            nwflow.loadForm(nwflow.chlidCurrentNode.wfForms, true);

                            // 优化表单选项卡滚动条
                            $('#form_list_tabs_warp').lrscroll();
                            nwflow.history = info.TaskLogList || [];
                            nwflow.currentIds = info.CurrentNodeIds || '';
                            nwflow.loadFlowInfo();
                            nwflow.loadTimeLine();

                            $('#release').show();
                            $('#release').on('click', function () {
                                // 验证表单数据完整性
                                if (!custmerForm.validForm('create'))// create创建流程
                                {
                                    return false;
                                }
                                // 保存表单数据
                                custmerForm.save(nwflow.chlidProcessId, nwflow.chlidCurrentNode.wfForms, function () {
                                    // 创建流程
                                    learun.loading(true, '创建流程...');
                                    var postData = {
                                        schemeCode: nwflow.currentNode.childFlow,
                                        processId: nwflow.chlidProcessId,
                                        parentProcessId: nwflow.pProcessId,
                                        parentTaskId: nwflow.pTaskId
                                    };
                                    learun.httpAsync('Post', top.$.rootUrl + '/LR_NewWorkFlow/NWFProcess/CreateChildFlow', postData, function (_data) {
                                        learun.loading(false);
                                        if (_data) {
                                            learun.frameTab.parentIframe().refreshGirdData();
                                            learun.frameTab.close(tabIframeId);
                                        }
                                    });
                                });
                            });
                            $('#savedraft').show();
                            $('#savedraft').on('click', function () {
                                // 保存表单数据
                                custmerForm.save(nwflow.chlidProcessId, nwflow.chlidCurrentNode.wfForms, function () {
                                    learun.frameTab.close(tabIframeId);
                                });
                            });
                        }
                    });

                    nwflow.pTaskId = nwflow.taskId;
                    nwflow.pProcessId = processId;
                    $('#eye').show();
                }
            });
        },

        // 加载表单  此处修改过滤 F_showType=1的表单
        loadForm: function (formList, isLoadData, isLook) {
            for (var i = 0; i < formList.length; i++) {
                if (formList[i].F_ShowType == '1') {
                    formList.splice(i, 1)
                }
            }
            var $ul = $('#form_list_tabs');
            var $iframes = $('#form_list_iframes');
            $.each(formList, function (_index, _item) {
                $ul.append('<li><a data-value="' + _index + '" >' + _item.name + '</a></li>');
                if (_item.type == '1') {// 自定义表单
                    $iframes.append('<div id="wfFormContainer' + _index + '" class="form-list-container" data-value="' + _index + '" ></div>');
                    _item._index = _index;
                    custmerForm.init(_item, $iframes.find('#wfFormContainer' + _index), isLoadData, isLook);

                }
                else {// 系统表单
                    $iframes.append('<iframe id="wfFormIframe' + _index + '" class="form-list-iframe" data-value="' + _index + '" frameborder="0" ></iframe>');
                    page.iframeLoad("wfFormIframe" + _index, _item.url, function (iframeObj, formData) {
                        // 设置字段权限
                        iframeObj.setAuthorize && iframeObj.setAuthorize(formData.authorize, isLook);
                        iframeObj.setFormData && iframeObj.setFormData(processId, wfFormParam, function () {
                            $('.lr-layout-panel-btn').show();
                        });

                        if (!iframeObj.setFormData) {
                            $('.lr-layout-panel-btn').show();
                        }

                    }, _item);
                }
                if (_index == 0) {
                    $ul.find('a').trigger('click');
                }
            });

            if (formList.length == 0) {
                $('.lr-layout-panel-btn').show();
            }
        },
        loadFlowInfo: function () {
            learun.clientdata.getAllAsync('department', {
                callback: function (departmentMap) {
                    learun.clientdata.getAllAsync('user', {
                        callback: function (userMap) {
                            var nodeInfoes = {};
                            // 当前节点处理人信息
                            $.each(nwflow.taskInfo, function (_index, _item) {
                                var nameList = [];
                                $.each(_item.nWFUserInfoList, function (_jindex, _jitem) {
                                    if (userMap[_jitem.Id]) {
                                        var name = userMap[_jitem.Id].name;
                                        var _department = departmentMap[userMap[_jitem.Id].departmentId];
                                        if (_department) {
                                            name = '【' + _department.name + '】' + name;
                                        }

                                        nameList.push(name);
                                    }
                                });
                                var point = {
                                    namelist: String(nameList)
                                }
                                nodeInfoes[_item.F_NodeId] = nodeInfoes[_item.F_NodeId] || [];
                                nodeInfoes[_item.F_NodeId].push(point);
                            });
                            // 初始化工作流节点历史处理信息
                            $.each(nwflow.history, function (id, item) {
                                nodeInfoes[item.F_NodeId] = nodeInfoes[item.F_NodeId] || [];
                                console.log(item);
                                nodeInfoes[item.F_NodeId].push(item);
                            });

                            var strcurrentIds = String(nwflow.currentIds);
                            $.each(nwflow.schemeObj.nodes, function (_index, _item) {//0正在处理 1 已处理同意 2 已处理不同意 3 未处理 
                                _item.state = '3';
                                if (nodeInfoes[_item.id]) {
                                    _item.history = nodeInfoes[_item.id];
                                    _item.state = '1';
                                }
                                if (strcurrentIds.indexOf(_item.id) > -1) {
                                    _item.state = '0';
                                }
                                if (_item.isAllAuditor == "2") {
                                    _item.name += '<br/>【多人审核:';

                                    if (_item.auditorType == "1") {
                                        _item.name += '并行】';
                                    }
                                    else {
                                        _item.name += '串行】';
                                    }
                                }
                                nwflow.nodeMap[_item.id] = _item;
                            });

                            $('#flow').lrworkflowSet('set', { data: nwflow.schemeObj });
                        }
                    });
                }
            });


        },
        loadTimeLine: function () {
            var nodelist = [];
            learun.clientdata.getAllAsync('department', {
                callback: function (departmentMap) {
                    learun.clientdata.getAllAsync('user', {
                        callback: function (userMap) {
                            for (var i = 0, l = nwflow.history.length; i < l; i++) {
                                var item = nwflow.history[i];
                                var name = (item.F_CreateUserName || '系统处理') + '：';
                                if (item.F_CreateUserId && userMap[item.F_CreateUserId]) {
                                    var _department = departmentMap[userMap[item.F_CreateUserId].departmentId];
                                    if (_department) {
                                        name = '【' + _department.name + '】' + name;
                                    }
                                }
                                var content = item.F_OperationName;
                                if (item.F_Des) {
                                    content += '【审批意见】' + item.F_Des;
                                }
                                var nodeName = '';
                                if (item.F_NodeId && nwflow.nodeMap[item.F_NodeId]) {
                                    nodeName = nwflow.nodeMap[item.F_NodeId].name;
                                }

                                var point = {
                                    title: item.F_NodeName || nodeName,
                                    people: name,
                                    content: content,
                                    time: item.F_CreateDate
                                };

                                if (item.F_OperationCode == 'createChild' || item.F_OperationCode == 'againCreateChild') {
                                    point.content = content + '<span class="lr-event" >查看</span>';
                                    point.nodeId = item.F_NodeId;
                                    point.processId = item.F_ProcessId;
                                    point.callback = function (data) {
                                        learun.layerForm({
                                            id: 'LookFlowForm',
                                            title: '子流程查看',
                                            url: top.$.rootUrl + '/LR_NewWorkFlow/NWFProcess/LookFlowForm?nodeId=' + data.nodeId + '&processId=' + data.processId + '&type=lookChlid',
                                            width: 1000,
                                            height: 900,
                                            maxmin: true,
                                            btn: null
                                        });
                                    }
                                }

                                nodelist.push(point);
                            }
                            $('#auditinfo').lrtimeline(nodelist);
                        }
                    });
                }
            });
        },

        // 获取数据
        getSchemeByCode: function (code, callback) {// 根据流程模板获取表单
            learun.httpAsync('GET', top.$.rootUrl + '/LR_NewWorkFlow/NWFProcess/GetSchemeByCode', { code: code }, function (data) {
                callback && callback(data);
            });
        },
        getSchemeByProcessId: function (processId, callback) {
            learun.httpAsync('GET', top.$.rootUrl + '/LR_NewWorkFlow/NWFProcess/GetSchemeByProcessId', { processId: processId }, function (data) {
                callback && callback(data);
            });
        },
        getProcessInfo: function (processId, taskId, callback) {
            learun.httpAsync('GET', top.$.rootUrl + '/LR_NewWorkFlow/NWFProcess/GetProcessDetails', { processId: processId, taskId: taskId }, function (data) {
                callback && callback(data);
            });
        }
    };

    // 自定义表单
    var custmerForm = {
        init: function (formInfo, $container, isLoadData, isLook) {
            custmerForm.getScheme(formInfo.formId, function (data) {
                if (data) {
                    var formScheme = JSON.parse(data.schemeEntity.F_Scheme);
                    formInfo.formScheme = formScheme;

                    // 编辑表格权限
                    var girdMap = {};
                    var _flag = false;
                    $.each(formInfo.authorize || [], function (_field, _item) {
                        var _ids = _field.split('|');
                        if (_ids.length > 1) {
                            if (_item.isLook != 1 || _item.isEdit != 1) {
                                girdMap[_ids[0]] = girdMap[_ids[0]] || {};
                                girdMap[_ids[0]][_ids[1]] = _item;
                                _flag = true;
                            }
                        }
                    });
                    if (_flag) {
                        $.each(formScheme.data, function (_i, _item) {
                            $.each(_item.componts, function (_j, _jitem) {
                                if ((_jitem.type == 'girdtable' || _jitem.type == 'gridtable') && !!girdMap[_jitem.id]) {
                                    var _gird = girdMap[_jitem.id];
                                    var _fieldsData = [];
                                    var _hideData = [];
                                    $.each(_jitem.fieldsData, function (_m, _mitem) {
                                        if (!_gird[_mitem.id] || _gird[_mitem.id].isLook == 1) {
                                            _fieldsData.push(_mitem);
                                            if (_gird[_mitem.id] && _gird[_mitem.id].isEdit != 1) {
                                                _mitem._isEdit = 1;
                                            }
                                        } else {
                                            _hideData.push(_mitem)
                                        }
                                    });
                                    _jitem.fieldsData = _fieldsData;
                                    _jitem.hideData = _hideData
                                }
                            });
                        });
                    }
                    formInfo.girdCompontMap = $container.lrCustmerFormRender(formScheme.data);

                    // 表单组件权限
                    $.each(formInfo.authorize || [], function (_field, _item) {
                        var _ids = _field.split('|');
                        if (_ids.length == 1) {
                            if (_item.isLook != 1) {// 如果没有查看权限就直接移除
                                $('#' + _ids[0]).parent().remove();
                                $('[name="' + _ids[0] + '"]').parents('.lr-form-item').attr('disabled', 'disabled');
                            }
                            else {
                                if (_item.isEdit != 1) {
                                    $('#' + _ids[0]).attr('disabled', 'disabled');
                                    if ($('#' + _ids[0]).hasClass('lrUploader-wrap')) {
                                        $('#' + _ids[0]).css({ 'padding-right': '58px' });
                                        $('#' + _ids[0]).find('.btn-success').remove();
                                    }
                                }
                            }
                        }
                    });

                    if (isLook) {// 当前是查看状态
                        $('.lrUploader-wrap').css({ 'padding-right': '58px' }).find('.btn-success').remove();
                    }

                    // 获取表单数据
                    if (isLoadData) {
                        custmerForm.getFormData(formInfo, nwflow.processId, formInfo.field, function (formData, _formInfo) {
                            $.each(formData, function (id, item) {
                                if (_formInfo.girdCompontMap[id]) {
                                    var fieldMap = {};
                                    $.each(_formInfo.girdCompontMap[id].fieldsData, function (id, girdFiled) {
                                        if (girdFiled.field) {
                                            fieldMap[girdFiled.field.toLowerCase()] = girdFiled.field;
                                        }
                                    });
                                    if (_formInfo.girdCompontMap[id].hideData) {
                                        $.each(_formInfo.girdCompontMap[id].hideData, function (id, girdFiled) {
                                            if (girdFiled.field) {
                                                fieldMap[girdFiled.field.toLowerCase()] = girdFiled.field;
                                            }
                                        });
                                    }
                                    var rowDatas = [];
                                    for (var i = 0, l = item.length; i < l; i++) {
                                        var _point = {};
                                        for (var _field in item[i]) {
                                            _point[fieldMap[_field]] = item[i][_field];
                                        }
                                        rowDatas.push(_point);
                                    }
                                    if (rowDatas.length > 0) {
                                        _formInfo.isUpdate = true;
                                    }
                                    $('#' + _formInfo.girdCompontMap[id].id).jfGridSet('refreshdata', { rowdatas: rowDatas });
                                }
                                else {
                                    if (item[0]) {
                                        _formInfo.isUpdate = true;
                                        $('#wfFormContainer' + _formInfo._index).lrSetCustmerformData(item[0], id);
                                    }
                                }

                            });

                            $.each(_formInfo.authorize || [], function (_field, _item) {
                                if (_item.isLook == 1 && _item.isEdit != 1) {// 如果没有查看权限就直接移除
                                    $('[name="' + _field + '"]').attr('disabled', 'disabled');
                                }
                            });
                            $('.lr-layout-panel-btn').show();


                        });
                    }
                    else {
                        $('.lr-layout-panel-btn').show();
                    }

                }
            });
        },

        // 获取数据
        getScheme: function (formId, callback) {
            learun.httpAsync('GET', top.$.rootUrl + '/LR_FormModule/Custmerform/GetFormData', { keyValue: formId }, function (data) {
                callback && callback(data);
            });
        },
        getFormData: function (formInfo, processId, processIdName, callback) {
            learun.httpAsync('GET', top.$.rootUrl + '/LR_FormModule/Custmerform/GetInstanceForm', { schemeInfoId: formInfo.formId, keyValue: processId, processIdName: processIdName }, function (data) {
                callback && callback(data, formInfo);
            });
        },

        // 验证表单数据完整性
        validForm: function (code) {// 操作码 create创建
            // 验证表单数据完整性
            if (!$.lrValidCustmerform()) {// 自定义表单
                return false;
            }
            for (var i = 0, l = formIframes.length; i < l; i++) {// 系统表单
                if (formIframes[i].validForm && !formIframes[i].validForm(code)) {
                    return false;
                }
            }
            return true;
        },

        // 保存数据
        save: function (processId, nwfForms, callback) {
            for (var i = 0, l = formIframes.length; i < l; i++) {
                formIframesHave[i] = null;
                if (formIframesHave[i] != 1) {
                    formIframes[i].save(processId, function (res, _index) { // 系统表单保存成功后需要将状态设置为更新状态（草稿并不会关闭页面）
                        if (res.code == 200) {
                            formIframes[_index].isUpdate = true;
                            formIframesHave[_index] = 1;
                        }
                        else {
                            formIframesHave[_index] = 0;
                        }
                    }, i);
                }
            }
            var formDataList = [];

            $.each(nwfForms, function (_index, _item) {
                if (_item.type == '1') {// 自定义表单
                    var point = {
                        schemeInfoId: _item.formId,
                        processIdName: _item.field
                    };
                    var formData = $('#wfFormContainer' + _index).lrGetCustmerformData();
                    if (_item.isUpdate) {
                        point.keyValue = processId;
                    }
                    formData[_item.field] = processId;
                    point.formData = JSON.stringify(formData);
                    formDataList.push(point);

                    _item.isUpdate = true;
                }
            });

            console.log(formDataList);


            if (formDataList.length > 0) {
                $.lrSaveForm(top.$.rootUrl + '/LR_FormModule/Custmerform/SaveInstanceForms', { data: JSON.stringify(formDataList) }, function (res) {
                    if (res.code == 200) {
                        monitorSave();
                    }
                    else {
                        learun.alert.error('表单数据保存失败');
                    }
                });
            }
            else {
                monitorSave();
            }

            function monitorSave() {
                var num = 0;
                var flag = true;
                for (var i = 0, l = formIframes.length; i < l; i++) {
                    if (formIframesHave[i] == 0) {
                        num++;
                        flag = false;
                    }
                    else if (formIframesHave[i] == 1) {
                        num++;
                    }
                }
                if (num == formIframes.length) {
                    if (flag) {
                        callback();
                    }
                    else {
                        learun.alert.error('表单数据保存失败');
                    }
                }
                else {
                    setTimeout(function () {
                        monitorSave();
                    }, 100);
                }
            }
        }
    };

    var page = {
        init: function () {
            page.bind();
            nwflow.init();
        },
        bind: function () {
            // 显示信息选项卡
            $('#tablist').lrFormTabEx(function (id) {
                if (id == 'workflowshcemeinfo' || id == 'auditinfo') {
                    $('#print').hide();
                }
                else {
                    $('#print').show();
                }
            });

            // 表单选项卡点击事件
            $('#form_list_tabs').on('click', 'a', function () {
                var $this = $(this);
                if (!$this.hasClass('active')) {
                    $this.parents('ul').find('.active').removeClass('active');
                    $this.parent().addClass('active');

                    var value = $this.attr('data-value');
                    var $iframes = $('#form_list_iframes');
                    $iframes.find('.active').removeClass('active');
                    $iframes.find('[data-value="' + value + '"]').addClass('active');
                }
            });

            $('#flow').lrworkflow({
                isPreview: true,
                openNode: function (node) {
                    top.wflookNode = node;

                    if (node.type == 'childwfnode') {
                        learun.layerForm({
                            id: 'LookFlowForm',
                            title: '子流程查看',
                            url: top.$.rootUrl + '/LR_NewWorkFlow/NWFProcess/LookFlowForm?schemeCode=' + node.childFlow + '&nodeId=' + node.id + '&processId=' + nwflow.processId + '&type=lookChlid',
                            width: 1000,
                            height: 900,
                            maxmin: true,
                            btn: null
                        });

                        return;
                    }

                    if (node.history) {
                        learun.layerForm({
                            id: 'LookNodeForm',
                            title: '审批记录查看【' + node.name + '】',
                            url: top.$.rootUrl + '/LR_NewWorkFlow/NWFProcess/LookNodeForm',
                            width: 600,
                            height: 400,
                            btn: null
                        });
                    }
                }
            });

            // 打印表单
            $('#print').on('click', function () {
                $.post(top.$.rootUrl + '/LR_CodeDemo/WfPrint/GetColumeCount', { taskId: taskId, processId: processId }, function (res) {
                    learun.DocLayerForm({
                        id: '_printform',
                        title: '打印',
                        url: top.$.rootUrl + '/LR_CodeDemo/WfPrint/Index?taskId=' + taskId + '&processId=' + processId,
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
                //var $iframes = $('#form_list_iframes');
                //var iframeId = $iframes.find('.form-list-iframe.active').attr('id');
                //if (iframeId) {
                //    var $iframe = learun.iframe(iframeId, frames);
                //    $iframe.$('.lr-form-wrap:visible').jqprint();
                //}
                //else {
                //    $iframes.find('.form-list-container.active').find('.lr-form-wrap:visible').jqprint();
                //}
            });
            $('#print').show();

            // 查看父流程
            $('#eye').on('click', function () {
                learun.layerForm({
                    id: 'LookFlowForm',
                    title: '父流程进度查看',
                    url: top.$.rootUrl + '/LR_NewWorkFlow/NWFProcess/LookFlowForm?processId=' + nwflow.pProcessId + '&taskId=' + nwflow.pTaskId + '&type=lookParent',
                    width: 1000,
                    height: 900,
                    maxmin: true,
                    btn: null
                });
            });

        },
        // iframe 加载
        iframeLoad: function (iframeId, url, callback, formData) {
            var _iframe = document.getElementById(iframeId);
            var _iframeLoaded = function () {
                var iframeObj = learun.iframe(iframeId, frames);

                if (formIframesMap[iframeId] != undefined) {
                    formIframes[formIframesMap[iframeId]] = iframeObj;
                }
                else {
                    formIframesMap[iframeId] = formIframes.length;
                    formIframes.push(iframeObj);
                }

                if (!!iframeObj.$) {
                    callback(iframeObj, formData);
                }
            };

            if (_iframe.attachEvent) {
                _iframe.attachEvent("onload", _iframeLoaded);
            } else {
                _iframe.onload = _iframeLoaded;
            }
            $('#' + iframeId).attr('src', top.$.rootUrl + url);
        }
    };

    page.init();
}