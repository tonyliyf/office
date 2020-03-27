(function () {
    var page = {
        list: {},
        processId:'',
        init: function ($page, param) {
            var _this= this
            this.list = $page.find('.lr-form-container')
            debugger
            this.processId = param.processId

            learun.httpget(config.webapi + "learun/adms/newwf/processinfo", {
                processId: this.processId,
                taskId: ''
            }, function (data) {
                var info = data.info;
                var schemeObj = JSON.parse(info.Scheme);
                var currentNode;
                var formreq = [];
                var schemeIds = [];
                var authorizeFields = [];
                // 获取当前节点
                $.each(schemeObj.nodes, function (_index, _item) {
                    var b = false
                    if (_item.wfForms) {
                        $.each(_item.wfForms, function (i, v) {
                            if (v.formId) {
                                currentNode = _item;
                                b = true
                                return false
                            }
                        })
                    }
                    if (b) {
                        return false
                    }
                });
                $.each(currentNode.wfForms, function (_index, _item) {
                    if (_item.formId) {
                        schemeIds.push(_item.formId);
                        var point = {
                            schemeInfoId: _item.formId,
                            processIdName: _item.field,
                            keyValue: _this.processId,
                        }
                        formreq.push(point);

                        if (_item.authorize != null && _item.authorize.length > 0) {
                            $.each(_item.authorize, function (_jindex, _jitem) {
                                _jitem.fieldId = _jindex;
                                authorizeFields.push(_jitem);
                            });
                        }
                    }
                });
                learun.custmerform.loadScheme(schemeIds, function (scheme) {
                    $('#_nmyprocessInfocontainer').custmerform(scheme);
                    $.each(authorizeFields, function (_index, _item) {
                        if (_item.isLook === 0) {
                            $('#_nmyprocessInfocontainer').find('#' + _item.fieldId).parents('.lr-form-row').remove();
                        }
                    });
                    // 设置表单的可查看权限
                    $.each(authorizeFields, function (_index, _item) {
                        if (_item.isLook === 0) {
                            $('#_nmyprocessInfocontainer').find('#' + _item.fieldId).parents('.lr-form-row').remove();
                        }
                    });

                    $('#_nmyprocessInfocontainer').setFormRead();
                });

                // 获取下自定义表单数据
                learun.httpget(config.webapi + "learun/adms/form/data", formreq, function (data) {
                    if (data) {
                        // 设置自定义表单数据
                        $('#_nmyprocessInfocontainer').custmerformSet(data);
                    }
                });
            })
        },
        destroy: function (pageinfo) {
            page.currentPage = 0;
            page.grid = [];
        },
    };
    return page;
})();