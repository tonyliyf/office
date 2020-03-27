﻿(function () {
    var processId = '';
    var taskId = '';

    var $header = null;
    var headText = '';

    var fieldMap = {};
    var formMap = {};
    var formDataes;
    var formAllData;
    var formreq;

    // 流程信息
    var info;
    var schemeObj;
    var currentNode;
    var nodeMap = {};

    var getFormData = function ($page) {
        formDataes = $page.find('#auditcontainer').custmerformGet();
        if (formDataes == null) {
            return false;
        }
        formreq = [];
        formAllData = {};
        for (var id in formDataes) {
            if (!fieldMap[id]) {
                learun.layer.warning('未设置流程表单关联字段！', function () { }, '力软提示', '关闭');
                return false;
            }
            $.extend(formAllData, formDataes[id]);
            if (!formMap[id]) {
                formDataes[id][fieldMap[id]] = processId;
            }
            var point = {
                schemeInfoId: id,
                processIdName: fieldMap[id],
                formData: JSON.stringify(formDataes[id])
            }

            if (formMap[id]) {
                point.keyValue = processId;
            }
            formreq.push(point);
        }

        return true;
    };

    var page = {
        init: function ($page, param) {
            var _html = '<div class="lr-form-header-submit" style="display:block;" >审核</div>';
            $header = $page.parents('.f-page').find('.f-page-header');
            $header.append(_html);
            headText = $header.find('.f-page-title').text();

            $page.find('.lr-naudit-page').toptab(['表单信息', '流程信息']).each(function (index) {
                var $this = $(this);
                switch (index) {
                    case 0:
                        $this.html('<div class="container" id="nauditcontainer"></div>');
                        break;
                    case 1:
                        $this.html('<div class="container" id="nauditcontainer2"></div>');
                        break;
                }
                $this = null;
            });
            processId = param.processId;
            taskId = param.taskId;
            taskinfo(param);

            // 审核
            $header.find('.lr-form-header-submit').on('tap', function () {
                var actionsheetData = [];
                $.each(currentNode.btnList, function (_index, _item) {
                    if (_item.isHide != '1') {
                        var point = {
                            text: _item.name,
                            group: '1',
                            event: function () {
                                // 获取表单数据
                                if (!getFormData($page)) {
                                    return false;
                                }
                                learun.nav.go({ path: 'nworkflow/audit/verify', title: headText + '【' + _item.name + '】', type: 'right', param: { processId: processId, taskId: taskId, verify: _item.code, name: _item.name, node: currentNode } });
                            }
                        }

                        if (_item.code == 'disagree') {
                            point.mark = true;
                        }
                        actionsheetData.push(point);
                    }
                });
                if (currentNode.isSign == "1") {
                    actionsheetData.push({
                        text: '加签',
                        group: '2',
                        event: function () {// 删除当前条信息
                            // 获取表单数据
                            if (!getFormData($page)) {
                                return false;
                            }
                            learun.nav.go({ path: 'nworkflow/audit/sign', title: headText + "【加签】", type: 'right' });
                        }
                    });
                }
                if (actionsheetData.length == 0) {
                    learun.layer.toast('没有审核按钮');
                    return;
                }
                learun.actionsheet({
                    id: 'audit',
                    data: actionsheetData,
                    cancel: function () {
                    }
                });
            });
        },
        sign: function (info, auditers) {// info加签信息
            var flowreq = {
                processId: processId,
                taskId: taskId,
                userId: info.auditorId,
                des: info.description,
                formreq: JSON.stringify(formreq)
            };
            learun.layer.loading(true, "加签流程,请等待！");
            learun.httppost(config.webapi + "learun/adms/newwf/sign", flowreq, function (data) {
                learun.layer.loading(false);
                var prepage = learun.nav.getpage('nworkflow/myflow');
                prepage.grid[1].reload();
                learun.nav.closeCurrent();
            });
        },
        verify: function (info, auditers) {// info审核信息
            var flowreq = {
                operationCode: info.verify,
                operationName: info.name,
                processId: processId,
                taskId: taskId,
                des: info.description,
                auditors: JSON.stringify(auditers),
                formreq: JSON.stringify(formreq)
            };
            learun.layer.loading(true, "审核流程,请等待！");
            learun.httppost(config.webapi + "learun/adms/newwf/audit", flowreq, function (data) {
                learun.layer.loading(false);
                var prepage = learun.nav.getpage('nworkflow/myflow');
                prepage.grid[1].reload();
                learun.nav.closeCurrent();
            });
        },
        destroy: function (pageinfo) {
            $header = null;
        }
    };
    // 流程发起初始化
    function taskinfo(_param) {
        fieldMap = {};
        var req = {
            processId: _param.processId,
            taskId: _param.taskId
        };
        learun.layer.loading(true, "获取流程信息");
        learun.httpget(config.webapi + "learun/adms/newwf/processinfo", req, function (data) {
            learun.layer.loading(false);
            if (data) {
                var schemeIds = [];
                var authorizeFields = [];
                var formreq = [];
                info = data.info;
                schemeObj = JSON.parse(info.Scheme);
                // 获取当前节点
                $.each(schemeObj.nodes, function (_index, _item) {
                    if (_item.id == info.CurrentNodeId) {
                        currentNode = _item;
                    }

                    nodeMap[_item.id] = _item;
                });

                $.each(currentNode.wfForms, function (_index, _item) {
                    if (_item.formId) {
                        schemeIds.push(_item.formId);
                        var point = {
                            schemeInfoId: _item.formId,
                            processIdName: _item.field,
                            keyValue: _param.processId,
                        }
                        formreq.push(point);

                        $.each(_item.authorize, function (_jindex, _jitem) {
                            _jitem.fieldId = _jindex;
                            authorizeFields.push(_jitem);
                        });
                    }
                });
                learun.custmerform.loadScheme(schemeIds, function (scheme) {
                    $('#nauditcontainer').custmerform(scheme);
                    // 设置表单的可查看权限
                    $.each(authorizeFields, function (_index, _item) {
                        if (_item.isLook === 0) {
                            $('#nauditcontainer').find('#' + _item.fieldId).parents('.lr-form-row').remove();
                        }
                        else if (_item.isEdit === 0) {
                            $('#nauditcontainer').find('#' + _item.fieldId).parents('.lr-form-row').attr('readonly', 'readonly');
                        }
                    });
                });

                formMap = {};
                // 获取下自定义表单数据
                learun.httpget(config.webapi + "learun/adms/form/data", formreq, function (data) {
                    if (data) {
                        // 设置自定义表单数据
                        $.each(data, function (_id, _item) {
                            $.each(_item, function (_j, _jitem) {
                                if (_jitem.length > 0) {
                                    formMap[_id] = true;
                                }
                            });
                        });
                        $('#nauditcontainer').custmerformSet(data);
                    }
                });
                // 加载流程信息
                initTimeLine(info.TaskLogList);
            }
            console.log(data);
        });
    }
    function initTimeLine(flowHistory) {
        var nodelist = [];
        learun.clientdata.getAll('department', {
            callback: function (departmentMap) {
                learun.clientdata.getAll('user', {
                    callback: function (userMap) {
                        for (var i = 0, l = flowHistory.length; i < l; i++) {
                            var item = flowHistory[i];
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
                            if (item.F_NodeId && nodeMap[item.F_NodeId]) {
                                nodeName = nodeMap[item.F_NodeId].name;
                            }

                            var point = {
                                title: item.F_NodeName || nodeName,
                                people: name,
                                content: content,
                                time: item.F_CreateDate
                            };

                            nodelist.push(point);
                        }
                        $('#nauditcontainer2').ftimeline(nodelist);
                    }
                });
            }
        });
    }
    return page;
})();