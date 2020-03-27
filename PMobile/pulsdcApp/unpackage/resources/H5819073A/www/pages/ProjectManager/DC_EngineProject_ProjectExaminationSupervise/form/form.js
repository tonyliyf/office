(function () {
    var keyValue = '';
    var $header = null;
    var titleText = '';
    var page = {
        isScroll: true,
        init: function ($page, param) {
            keyValue = param.keyValue;
            // 添加头部按钮列表
            var _html = '\
                <div class="lr-form-header-cancel" >取消</div>\
                <div class="lr-form-header-btnlist" >\
                    <div class="lr-form-header-more" ><i class="iconfont icon-more" ></i></div>\
                    <div class="lr-form-header-edit" ><i class="iconfont icon-edit" ></i></div>\
                </div>\
                <div class="lr-form-header-submit" >提交</div>';
            $header = $page.parents('.f-page').find('.f-page-header');
            $header.append(_html);
            // 取消
            $header.find('.lr-form-header-cancel').on('tap', function () {
                learun.layer.confirm('确定要退出当前编辑？', function (_index) {
                    if (_index === '1') {
                        if (keyValue) {// 如果是编辑状态
                            learun.formblur();
                            $header.find('.lr-form-header-cancel').hide();
                            $header.find('.lr-form-header-submit').hide();
                            $header.find('.lr-form-header-btnlist').show();
                            $header.find('.f-page-title').text(titleText);
                            $page.find('.lr-form-container').setFormRead();
                        }
                        else {// 如果是新增状态 关闭当前页面
                            learun.nav.closeCurrent();
                        }
                    }
                }, '系统提示', ['取消', '确定']);
            });
            // 编辑
            $header.find('.lr-form-header-edit').on('tap', function () {
                $header.find('.lr-form-header-btnlist').hide();
                $header.find('.lr-form-header-cancel').show();
                $header.find('.lr-form-header-submit').show();
                titleText = $header.find('.f-page-title').text();
                $header.find('.f-page-title').text('编辑');
                $page.find('.lr-form-container').setFormWrite();
            });
            // 更多
            $header.find('.lr-form-header-more').on('tap', function () {
                learun.actionsheet({
                    id: 'more',
                    data: [
                        {
                            text: '删除',
                            mark: true,
                            event: function () {// 删除当前条信息
                                learun.layer.confirm('确定要删除该笔数据吗？', function (_index) {
                                    if (_index === '1') {
                                        learun.layer.loading(true, '正在删除该笔数据');
                                        learun.httppost(config.webapi + 'learun/adms/ProjectManager/DC_EngineProject_ProjectExaminationSupervise/delete', keyValue, (data) => {
                                            learun.layer.loading(false);
                                            if (data) {// 删除数据成功
                                                learun.nav.closeCurrent();
                                                var prepage = learun.nav.getpage('ProjectManager/DC_EngineProject_ProjectExaminationSupervise');
                                                prepage.grid.reload();
                                            }
                                        });
                                    }
                                }, '系统提示', ['取消', '确定']);
                            }
                        }
                    ],
                    cancel: function () {
                    }
                });
            });
            // 提交
            $header.find('.lr-form-header-submit').on('tap', function () {
                // 获取表单数据
                if (!$page.find('.lr-form-container').lrformValid()) {
                    return false;
                }
                var _postData = {}
                _postData.keyValue = keyValue;
                _postData.strEntity = JSON.stringify($page.find('.lr-form-container').lrformGet());
                learun.layer.loading(true, '正在提交数据');
                learun.httppost(config.webapi + 'learun/adms/ProjectManager/DC_EngineProject_ProjectExaminationSupervise/save', _postData, (data) => {
                    learun.layer.loading(false);
                    if (data) {// 表单数据保存成功
                        if (keyValue) {
                            learun.layer.toast('保存数据成功!');
                            learun.formblur();
                            $header.find('.lr-form-header-cancel').hide();
                            $header.find('.lr-form-header-submit').hide();
                            $header.find('.lr-form-header-btnlist').show();
                            $header.find('.f-page-title').text(titleText);
                            $page.find('.lr-form-container').setFormRead();
                        }
                        else {// 如果是
                            learun.nav.closeCurrent();
                        }
                        var prepage = learun.nav.getpage('ProjectManager/DC_EngineProject_ProjectExaminationSupervise');
                        prepage.grid.reload();
                    }
                });
            });
            page.bind($page, param);
            if (keyValue) {
                // 添加编辑按钮
                $page.find('.lr-form-container').setFormRead();
                $header.find('.lr-form-header-btnlist').show();
                // 获取表单数据
                learun.layer.loading(true, '获取表单数据');
                learun.httpget(config.webapi + 'learun/adms/ProjectManager/DC_EngineProject_ProjectExaminationSupervise/form', keyValue, (data) => {
                    if (data) {
                        for (var id in data) {
                            if (data[id].length) {
                                $page.find('#' + id ).lrgridSet(data[id]);
                            }
                            else {
                                $page.find('[data-table="' + id + '"]').lrformSet(data[id]);
                            }
                        }
                    }
                    learun.layer.loading(false);
                });
            }
            else {
                $header.find('.lr-form-header-cancel').show();
                $header.find('.lr-form-header-submit').show();
            }
        },
        bind: function ($page, param) {
            $page.find('#F_PIId').lrpickerex({
                type: 'sourceData',
                code: 'DC_EngineProject_ProjectInfo',
                ivalue: 'f_piid',
                itext: 'f_projectname'
            });
            $page.find('#F_InspectionSupervisionType').lrpickerex({
            code: 'InspectionSupervision',
            type: 'dataItem'            });
            if (!keyValue) {
                learun.getRuleCode('DC_EngineProject_ProjectInfo', function (data) {
                    $page.find('#F_PESCode').val(data);
                });
            }
            $page.find('#F_EaminationDate').lrdate({
                type: 'date'
            });
            $page.find('#F_ExaminationDepartment').lrselect({
                type: 'department',
                needPre:false
            });
            $page.find('#F_ExaminationUser').lrselect({
                type: 'user',
                needPre:true
            });
            $page.find('#F_ExaminationDepartment').on('change', function () {
                var value = $(this).lrselectGet();
                $page.find('#F_ExaminationUser').lrselectUpdate({
                    companyId: value,
                    needPre: value === '' ? true : false
                });
            });
            $page.find('#F_ScenePictures').imagepicker();
            $page.find('#F_Attachment').imagepicker();
            $page.find('#F_IfCorrective').lrpickerex({
            code: 'YesOrNo',
            type: 'dataItem'            });
            $page.find('#F_DesignateDate').lrdate({
                type: 'date'
            });
            $page.find('#F_SupervisionStatus').lrpickerex({
            code: 'SupervisionStatus',
            type: 'dataItem'            });
        },        destroy: function (pageinfo) {
            $header = null;
            keyValue = '';
        }
    };
    return page;
})();
