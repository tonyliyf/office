﻿/*
 * 版 本 Learun-ADMS V7.0.3 敏 捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：-前端 开发组
 * 日 期：2017.03.16
 * 描 述：tab窗口操作方法
 */
(function ($, learun) {
    "use strict";
    //初始化菜单和tab页的属性Id
    var iframeIdList = {};

    learun.frameTab = {
        iframeId: '',
        init: function () {
            learun.frameTab.bind();
        },
        bind: function () {
            $(".lr-frame-tabs-wrap").lrscroll();
        },
        setCurrentIframeId: function (iframeId) {
            learun.iframeId = iframeId;
        },
        open: function (module, notAllowClosed) {
            var $tabsUl = $('#lr_frame_tabs_ul');
            var $frameMain = $('#lr_frame_main');

            if (iframeIdList[module.F_ModuleId] == undefined || iframeIdList[module.F_ModuleId] == null) {
                // 隐藏之前的tab和窗口
                if (learun.frameTab.iframeId != '') {
                    $tabsUl.find('#lr_tab_' + learun.frameTab.iframeId).removeClass('active');
                    $frameMain.find('#lr_iframe_' + learun.frameTab.iframeId).removeClass('active');
                    iframeIdList[learun.frameTab.iframeId] = 0;
                }
                var parentId = learun.frameTab.iframeId;
                learun.frameTab.iframeId = module.F_ModuleId;
                iframeIdList[learun.frameTab.iframeId] = 1;

                // 打开一个功能模块tab_iframe页面
                var $tabItem = $('<li class="lr-frame-tabItem active" id="lr_tab_' + module.F_ModuleId + '" parent-id="' + parentId + '"  ><span>' + module.F_FullName + '</span></li>');
                // 翻译
                learun.language.get(module.F_FullName, function (text) {
                    $tabItem.find('span').text(text);
                    if (!notAllowClosed) {
                        $tabItem.append('<span class="reomve" title="关闭窗口"></span>');
                    }
                });

                
                var $iframe = $('<iframe class="lr-frame-iframe active" id="lr_iframe_' + module.F_ModuleId + '" frameborder="0" src="' + $.rootUrl + module.F_UrlAddress + '"></iframe>');
                $tabsUl.append($tabItem);
                $frameMain.append($iframe);

                var w = 0;
                var width = $tabsUl.children().each(function () {
                    w += $(this).outerWidth();
                });
                $tabsUl.css({ 'width': w });
                $tabsUl.parent().css({ 'width': w });


                $(".lr-frame-tabs-wrap").lrscrollSet('moveRight');

             

                //绑定一个点击事件
                $tabItem.on('click', function () {
                    var id = $(this).attr('id').replace('lr_tab_', '');
                    learun.frameTab.focus(id);
                });
                $tabItem.find('.reomve').on('click', function () {
                    var id = $(this).parent().attr('id').replace('lr_tab_', '');
                    learun.frameTab.close(id);
                    return false;
                });

                if (!!learun.frameTab.opencallback) {
                    learun.frameTab.opencallback();
                }
                if (!notAllowClosed) {
                    var loginInfo = learun.clientdata.get(['userinfo']);
                    var account = '';
                    if (loginInfo) {
                        account = loginInfo.account;
                    }

                    $.ajax({
                        url: top.$.rootUrl + "/Home/VisitModule",
                        headers: { account: account },
                        data: { moduleName: module.F_FullName, moduleUrl: module.F_UrlAddress },
                        type: "post",
                        dataType: "json",
                        success: function (res) {
                            if (res.code == learun.httpCode.nologin) {
                                var _topUrl = top.$.rootUrl + '/Login/Index';
                                switch (res.info) {
                                    case 'nologin':
                                        break;
                                    case 'noip':
                                        _topUrl += '?error=ip';
                                        break;
                                    case 'notime':
                                        _topUrl += '?error=time';
                                        break;
                                    case 'other':
                                        _topUrl += '?error=other';
                                        break;
                                }
                                top.window.location.href = _topUrl;
                                return;
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            top.window.location.href = top.$.rootUrl + '/Login/Index';
                        },
                        beforeSend: function () {
                        },
                        complete: function () {
                        }
                    });
                }
            }
            else {
                learun.frameTab.focus(module.F_ModuleId);
            }
        },
        focus: function (moduleId) {
            if (iframeIdList[moduleId] == 0) {
                //if (moduleId == 0) {
                //    top.frames['lr_iframe_0'].contentWindow.location.reload()
                //}
                // 定位焦点tab页
                $('#lr_tab_' + learun.frameTab.iframeId).removeClass('active');
                $('#lr_iframe_' + learun.frameTab.iframeId).removeClass('active');
                iframeIdList[learun.frameTab.iframeId] = 0;

                $('#lr_tab_' + moduleId).addClass('active');
                $('#lr_iframe_' + moduleId).addClass('active');
                learun.frameTab.iframeId = moduleId;
                iframeIdList[moduleId] = 1;

                if (!!learun.frameTab.opencallback) {
                    learun.frameTab.opencallback();
                }
            }
        },
        leaveFocus: function () {
            $('#lr_tab_' + learun.frameTab.iframeId).removeClass('active');
            $('#lr_iframe_' + learun.frameTab.iframeId).removeClass('active');
            iframeIdList[learun.frameTab.iframeId] = 0;
            learun.frameTab.iframeId = '';
        },
        close: function (moduleId) {
            delete iframeIdList[moduleId];

            var $this = $('#lr_tab_' + moduleId);
            var $prev = $this.prev();// 获取它的上一个节点数据;
            if ($prev.length < 1) {
                $prev = $this.next();
            }
            $this.remove();
            $('#lr_iframe_' + moduleId).remove();
            if (moduleId == learun.frameTab.iframeId && $prev.length > 0) {
                var prevId = $prev.attr('id').replace('lr_tab_', '');

                $prev.addClass('active');
                $('#lr_iframe_' + prevId).addClass('active');
                learun.frameTab.iframeId = prevId;
                iframeIdList[prevId] = 1;
            }
            else {
                if ($prev.length < 1) {
                    learun.frameTab.iframeId = "";
                }
            }

            var $tabsUl = $('#lr_frame_tabs_ul');
            var w = 0;
            var width = $tabsUl.children().each(function () {
                w += $(this).outerWidth();
            });
            $tabsUl.css({ 'width': w });
            $tabsUl.parent().css({ 'width': w });

            if (!!learun.frameTab.closecallback) {
                learun.frameTab.closecallback();
            }
        }
        // 获取当前窗口
        ,currentIframe: function () {
            var ifameId = 'lr_iframe_' + learun.frameTab.iframeId;
            if (top.frames[ifameId].contentWindow != undefined) {
                return top.frames[ifameId].contentWindow;
            }
            else {
                return top.frames[ifameId];
            }
        }
        ,parentIframe: function () {
            var ifameId = 'lr_iframe_' + top.$('#lr_tab_'+learun.frameTab.iframeId).attr('parent-id');
            if (top.frames[ifameId].contentWindow != undefined) {
                return top.frames[ifameId].contentWindow;
            }
            else {
                return top.frames[ifameId];
            }
        }
        , wfFormIframe: function () { 
            var currentIframe = learun.frameTab.currentIframe();
            var iframeId = currentIframe.$('#form_list_iframes .form-list-iframe.active').attr('id');
            return learun.iframe(iframeId, currentIframe.frames);
        }
        , closeByParam: function (name, value) {
            $('#lr_frame_tabs_ul li').each(function () {
                var id = $(this).attr('id').replace('lr_tab_', '');
                
                var frameObj = top.frames[ 'lr_iframe_' + id];
                if (frameObj.contentWindow != undefined) {
                    frameObj = frameObj.contentWindow;
                }
                if (frameObj[name] == value) {
                    learun.frameTab.close(id);
                    return false;
                }
            });
        }
        , opencallback: false
        , closecallback: false
    };

    learun.frameTab.init();
})(window.jQuery, top.learun);