(function () {
    var begin = '';
    var end = '';
    var multipleData = null;
    var page = {
        grid: null,
        init: function ($page) {
            begin = '';
            end = '';
            multipleData = null;
            page.grid = $page.find('#lr_ProjectManagerDC_EngineProject_ProjectExaminationSupervise_list').lrpagination({
                lclass: page.lclass,
                rows: 10,                            // 每页行数
                getData: function (param, callback) {// 获取数据 param 分页参数,callback 异步回调
                    param.multipleData = multipleData;
                    page.loadData(param, callback, $page);
                },
                renderData: function (_index, _item, _$item) {// 渲染数据模板
                    return page.rowRender(_index, _item, _$item, $page);
                },
                click: function (item, $item, $et) {// 列表行点击事件
                    if ($et.hasClass('lr-btn-danger')) {
                        page.btnClick(item, $item, $page);
                    }
                    else {
                        page.rowClick(item, $item, $page);
                    }
                },
                btns: page.rowBtns
            });
            // 多条件查询
            var $multiple = $page.find('.lr_multiple_search').multiplequery({
                callback: function (data) {
                    begin = '';
                    end = '';
                    multipleData = data || {};
                    page.grid.reload();
                }
            });
            $multiple.find('#F_PIId').lrpickerex({
                type: 'sourceData',
                code: 'DC_EngineProject_ProjectInfo',
                ivalue: 'f_piid',
                itext: 'f_projectname'
            });
            $multiple.find('#F_ExaminationDepartment').lrselect({
                type: 'department'
            });
            $multiple.find('#F_SupervisionStatus').lrpickerex({
                type: 'dataItem',
                code: 'SupervisionStatus'
            });
            $page.find('#lr_ProjectManagerDC_EngineProject_ProjectExaminationSupervise_btn').on('tap', function () {
                learun.nav.go({ path: 'ProjectManager/DC_EngineProject_ProjectExaminationSupervise/form', title: '新增', type: 'right' });
            });
        },
        lclass: 'lr-list',
        loadData: function (param, callback, $page) {// 列表加载后台数据
            var _postParam = {
                pagination: {
                    rows: param.rows,
                    page: param.page,
                    sidx: 'F_PESId',
                    sord: 'DESC'
                },
                queryJson: '{}'
            };
            if (param.multipleData) {
                _postParam.queryJson = JSON.stringify(multipleData);
            }
            if (param.begin && param.end) {
                _postParam.queryJson = JSON.stringify({ StartTime: param.begin, EndTime: param.end });
            }
            learun.httpget(config.webapi + 'learun/adms/ProjectManager/DC_EngineProject_ProjectExaminationSupervise/pagelist', _postParam, (data) => {
                $page.find('.lr-badge').text('0');
                if (data) {
                    $page.find('.lr-badge').text(data.records);
                    callback(data.rows, parseInt(data.records));
                }
                else {
                    callback([], 0);
                }
            });
        },
        rowRender: function (_index, _item, _$item, $page) {// 渲染列表行数据
            _$item.addClass('lr-list-item lr-list-item-multi');
            _$item.append($('<p class="lr-ellipsis"><span>编 码:</span></p>').dataFormatter({ value: _item.F_PESCode }));
            _$item.append($('<p class="lr-ellipsis"><span>项目名称:</span></p>').dataFormatter({
                value: _item.F_PIId,
                type: 'dataSource',
                code: 'DC_EngineProject_ProjectInfo',
                keyId: 'f_piid',
                text: 'f_projectname'
            }));
            _$item.append($('<p class="lr-ellipsis"><span>检查督办类型:</span></p>').dataFormatter({
                value: _item.F_InspectionSupervisionType,
                type: 'dataItem',
                code: 'InspectionSupervision'
            }));
            _$item.append($('<p class="lr-ellipsis"><span>检查部门:</span></p>').dataFormatter({
                value: _item.F_ExaminationDepartment,
                type: 'organize',
                dataType: 'department'
            }));
            _$item.append($('<p class="lr-ellipsis"><span>检查人员:</span></p>').dataFormatter({
                value: _item.F_ExaminationUser,
                type: 'organize',
                dataType: 'user'
            }));
            _$item.append($('<p class="lr-ellipsis"><span>检查时间:</span></p>').dataFormatter({
                value: _item.F_EaminationDate,
                type: 'datetime',
                dateformat: 'yyyy-MM-dd'
            }));
            _$item.append($('<p class="lr-ellipsis"><span>检查部位:</span></p>').dataFormatter({ value: _item.F_ExaminationPosition }));
            _$item.append($('<p class="lr-ellipsis"><span>检查结果:</span></p>').dataFormatter({ value: _item.F_ExaminationResult }));
            _$item.append($('<p class="lr-ellipsis"><span>督办意见:</span></p>').dataFormatter({ value: _item.F_SupervisionOpinion }));
            _$item.append($('<p class="lr-ellipsis"><span>检查督办状态:</span></p>').dataFormatter({
                value: _item.F_SupervisionStatus,
                type: 'dataItem',
                code: 'SupervisionStatus'
            }));
            _$item.append($('<p class="lr-ellipsis"><span>是否整改:</span></p>').dataFormatter({
                value: _item.F_IfCorrective,
                type: 'dataItem',
                code: 'YesOrNo'
            }));
            _$item.append($('<p class="lr-ellipsis"><span>整改时间:</span></p>').dataFormatter({
                value: _item.F_DesignateDate,
                type: 'datetime',
                dateformat: 'yyyy-MM-dd'
            }));
            _$item.append($('<p class="lr-ellipsis"><span>指派单位:</span></p>').dataFormatter({ value: _item.F_DesignateUnit }));
            _$item.append($('<p class="lr-ellipsis"><span>指派人员:</span></p>').dataFormatter({ value: _item.F_DesignateUser }));
            _$item.append($('<p class="lr-ellipsis"><span>整改结果反馈:</span></p>').dataFormatter({ value: _item.F_ResultFeedback }));
            return '';
        },
        rowClick: function (item, $item, $page) {// 列表行点击触发方法
            learun.nav.go({ path: 'ProjectManager/DC_EngineProject_ProjectExaminationSupervise/form', title: '详情', type: 'right', param: { keyValue: item.F_PESId } });
        },
        btnClick: function (item, $item, $page) {// 左滑按钮点击事件
            learun.layer.confirm('确定要删除该笔数据吗？', function (_index) {
                if (_index === '1') {
                    learun.layer.loading(true, '正在删除该笔数据');
                    learun.httppost(config.webapi + 'learun/adms/ProjectManager/DC_EngineProject_ProjectExaminationSupervise/delete', item.F_PESId, (data) => {
                        if (data) {// 删除数据成功
                            page.grid.reload();
                        }
                        learun.layer.loading(false);
                    });
                }
            }, '系统提示', ['取消', '确定']);
        },
        rowBtns: ['<a class="lr-btn-danger">删除</a>'] // 列表行左滑按钮
    };
    return page;
})(); 