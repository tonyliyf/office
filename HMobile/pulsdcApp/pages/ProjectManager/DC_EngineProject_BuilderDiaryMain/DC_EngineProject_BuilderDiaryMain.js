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
            page.grid = $page.find('#lr_ProjectManagerDC_EngineProject_BuilderDiaryMain_list').lrpagination({
                lclass: page.lclass,
                rows: 10,                            // 每页行数 
                getData: function (param, callback) {// 获取数据 param 分页参数,callback 异步回调 
                    param.begin = begin;
                    param.end = end;
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
            // 时间搜索 
            $page.find('.lr_time_search').searchdate({
                callback: function (_begin, _end) {
                    begin = _begin;
                    end = _end;
                    multipleData = null;
                    page.grid.reload();
                }
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
                code: 'ProjectInfo',
                ivalue: 'f_piid',
                itext: 'f_projectname'
            });
            $multiple.find('#F_CreateDepartmentId').lrselect({
                type: 'department'
            });
            $multiple.find('#F_CreateUserid').lrselect({
                type: 'user'
            });
            $page.find('#lr_ProjectManagerDC_EngineProject_BuilderDiaryMain_btn').on('tap', function () {
                learun.nav.go({ path: 'ProjectManager/DC_EngineProject_BuilderDiaryMain/form', title: '新增', type: 'right' });
            });
        },
        lclass: 'lr-list',
        loadData: function (param, callback, $page) {// 列表加载后台数据 
            var _postParam = {
                pagination: {
                    rows: param.rows,
                    page: param.page,
                    sidx: 'F_BDMId',
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
            learun.httpget(config.webapi + 'learun/adms/ProjectManager/DC_EngineProject_BuilderDiaryMain/pagelist', _postParam, (data) => {
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
            _$item.append($('<p class="lr-ellipsis"><span>项目名称:</span></p>').dataFormatter({
                value: _item.F_PIId,
                type: 'dataSource',
                code: 'ProjectInfo',
                keyId: 'f_piid',
                text: 'f_projectname'
            }));
            _$item.append($('<p class="lr-ellipsis"><span>日志编号:</span></p>').dataFormatter({ value: _item.F_BDNum }));
            _$item.append($('<p class="lr-ellipsis"><span>填写部门:</span></p>').dataFormatter({
                value: _item.F_CreateDepartmentId,
                type: 'organize',
                dataType: 'department'
            }));
            _$item.append($('<p class="lr-ellipsis"><span>填写人:</span></p>').dataFormatter({
                value: _item.F_CreateUserid,
                type: 'organize',
                dataType: 'user'
            }));
            _$item.append($('<p class="lr-ellipsis"><span>填写日期:</span></p>').dataFormatter({
                value: _item.F_CreateDatetime,
                type: 'datetime',
                dateformat: 'yyyy-MM-dd'
            }));
            _$item.append($('<p class="lr-ellipsis"><span>施工进展情况:</span></p>').dataFormatter({ value: _item.F_BuildProgress }));
            _$item.append($('<p class="lr-ellipsis"><span>施工主要工作:</span></p>').dataFormatter({ value: _item.F_BuildMainWork }));
            return '';
        },
        rowClick: function (item, $item, $page) {// 列表行点击触发方法 
            learun.nav.go({ path: 'ProjectManager/DC_EngineProject_BuilderDiaryMain/form', title: '详情', type: 'right', param: { keyValue: item.F_BDMId } });
        },
        btnClick: function (item, $item, $page) {// 左滑按钮点击事件 
            learun.layer.confirm('确定要删除该笔数据吗？', function (_index) {
                if (_index === '1') {
                    learun.layer.loading(true, '正在删除该笔数据');
                    learun.httppost(config.webapi + 'learun/adms/ProjectManager/DC_EngineProject_BuilderDiaryMain/delete', item.F_BDMId, (data) => {
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