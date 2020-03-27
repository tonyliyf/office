/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-03-15 15:59
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
            page.grid = $page.find('#lr_LR_CodeDemo2135_list').lrpagination({
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
        },
        lclass: 'lr-list',
        loadData: function (param, callback, $page) {// 列表加载后台数据
            var _postParam = {
                pagination: {
                    rows: param.rows,
                    page: param.page,
                    sidx: 'DC_OA_AttenceDateTime',
                    sord: 'DESC'
                },
                queryJson: '{}'
            };
            if (param.multipleData) {
                _postParam.queryJson = JSON.stringify(multipleData);
            }
            learun.httpget(config.webapi + '/learun/adms/LR_CodeDemo/DC_OA_AttenceRecord/attencerecordlist', _postParam, (data) => {
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
            _$item.append($('<p class="lr-ellipsis"><span>打卡姓名:</span></p>').dataFormatter({ value: _item.F_CreateUserName }));
            _$item.append($('<p class="lr-ellipsis"><span>考勤日期:</span></p>').dataFormatter({
                value: (_item.DC_OA_AttenceDate && _item.DC_OA_AttenceDate.length > 10) ? _item.DC_OA_AttenceDate.substr(0, 10) : _item.DC_OA_AttenceDate

            }));
            _$item.append($('<p class="lr-ellipsis"><span>考勤时间:</span></p>').dataFormatter({
                value: _item.DC_OA_AttenceDateTime
            }));
            _$item.append($('<p class="lr-ellipsis"><span>打卡方式:</span></p>').dataFormatter({ value: _item.F_OA_RepairType }));
            _$item.append($('<p class="lr-ellipsis"><span>备 注:</span></p>').dataFormatter({ value: _item.F_Description }));
            return '';
        }
    };
    return page;
})(); 