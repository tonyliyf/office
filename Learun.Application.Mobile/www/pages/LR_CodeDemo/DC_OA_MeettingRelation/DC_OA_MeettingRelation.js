/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-04-29 11:22
 * 描  述：会议通知回执
 */
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
            page.grid = $page.find('#lr_LR_CodeDemoDC_OA_MeettingRelation_list').lrpagination({
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
                btns: page.rowBtns            });
            // 多条件查询
            var $multiple = $page.find('.lr_multiple_search').multiplequery({
                callback: function (data) {
                    begin = '';
                    end = '';
                    multipleData = data || {};
                    page.grid.reload();
                }
            });
            $multiple.find('#MeettingType').lrpickerex({
                type: 'dataItem',
                code: 'MeetingType'
            });
          
        },
        lclass: 'lr-list',
        loadData: function (param, callback, $page) {// 列表加载后台数据
            var _postParam = {
                pagination: {
                    rows: param.rows,
                    page: param.page,
                    sidx: 'MeettingId',
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
            learun.httpget(config.webapi + 'learun/adms/LR_CodeDemo/DC_OA_MeettingRelation/pagelist', _postParam, (data) => {
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
            _$item.append($('<p class="lr-ellipsis"><span>会议主题:</span></p>').dataFormatter({ value: _item.F_Title            }));
            _$item.append($('<p class="lr-ellipsis"><span>会议类型:</span></p>').dataFormatter({ value: _item.MeettingType,
                type: 'dataItem',
                code: 'MeetingType'
            }));
            _$item.append($('<p class="lr-ellipsis"><span>会议时间:</span></p>').dataFormatter({ value: _item.F_StartDate,
                type: 'datetime',
                dateformat: 'yyyy-MM-dd'
            }));
            _$item.append($('<p class="lr-ellipsis"><span>是否参加:</span></p>').dataFormatter({ value: _item.IsJoin,
                type: 'dataItem',
                code: 'YesOrNo'
            }));
            _$item.append($('<p class="lr-ellipsis"><span>不参加原因:</span></p>').dataFormatter({ value: _item.F_Reason            }));
            return '';
        },
        rowClick: function (item, $item, $page) {// 列表行点击触发方法
            learun.nav.go({ path: 'LR_CodeDemo/DC_OA_MeettingRelation/form', title: '详情', type: 'right', param: { keyValue: item.MeettingId } });
        },
        btnClick: function (item, $item, $page) {// 左滑按钮点击事件
            learun.layer.confirm('确定要删除该笔数据吗？', function (_index) {
                if (_index === '1') {
                    learun.layer.loading(true, '正在删除该笔数据');
                    learun.httppost(config.webapi + 'learun/adms/LR_CodeDemo/DC_OA_MeettingRelation/delete', item.MeettingId , (data) => {
                        if (data) {// 删除数据成功
                            page.grid.reload();
                        }
                        learun.layer.loading(false);
                    });
                }
            }, '提示', ['取消', '确定']);
        },
        rowBtns: ['<a class="lr-btn-danger">删除</a>'] // 列表行左滑按钮
    };
    return page;
})();
