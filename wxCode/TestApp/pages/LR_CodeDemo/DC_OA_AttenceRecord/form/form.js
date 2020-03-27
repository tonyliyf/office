/* * 版 本 DC-FW V1.0.1 东雅图敏捷开发框架(http://www.dongyatu.com)
 * Copyright (c) 2018-2019 东雅图信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-26 16:32
 * 描  述：打卡记录
 */
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
                                        learun.httppost(config.webapi + 'learun/adms/LR_CodeDemo/DC_OA_AttenceRecord/delete', keyValue, (data) => {
                                            learun.layer.loading(false);
                                            if (data) {// 删除数据成功
                                                learun.nav.closeCurrent();
                                                var prepage = learun.nav.getpage('LR_CodeDemo/DC_OA_AttenceRecord');
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
                learun.httppost(config.webapi + 'learun/adms/LR_CodeDemo/DC_OA_AttenceRecord/save', _postData, (data) => {
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
                        var prepage = learun.nav.getpage('LR_CodeDemo/DC_OA_AttenceRecord');
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
                learun.httpget(config.webapi + 'learun/adms/LR_CodeDemo/DC_OA_AttenceRecord/form', keyValue, (data) => {
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
        },        destroy: function (pageinfo) {
            $header = null;
            keyValue = '';
        }
    };
    return page;
})();
