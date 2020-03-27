(function () {

    var custmerform = {};
    var $scroll = '';

    var page = {
        init: function ($page) {
            var _html = '';
            _html += '<div class="scanner">';
            _html += '<i class="iconfont icon-scan"></i>';
            _html += '</div>';

            _html += '\
                <div class="searchBox">\
                    <i class="iconfont icon-search"></i>\
                    <div class="search" >搜索应用</div>\
                </div>';


            _html += '<div class="message">';
            _html += '<i class="iconfont icon-mail"></i>';
            _html += '<span class="red"></span>';
            _html += '</div>';
            $page.parent().find('.f-page-header').addClass('lr-workspace-header').html(_html);
            // 点击搜索框
            $page.parent().find('.searchBox').on('tap', function () {
                learun.nav.go({ path: 'workspace/search', title: '', isBack: true, isHead: true });
            });
            // 点击消息图标
            $page.parent().find('.message').on('tap', function () {
                learun.nav.go({ path: 'message', title: '消息', isBack: true, isHead: true,type:'right' });
            });
            // 注册扫描
            $page.parent().find('.scanner').on('tap', function () {
                learun.code.scan(function (res) {
                    if (res.status === 'success') {
                        learun.layer.toast(res.msg);
                    }
                    else {
                        learun.layer.toast('扫描失败:' + res.msg);
                    }
                });
            });
            // 图片加载
            $page.find('.banner').slider({ data: ['images/banner.png'], indicator: true, interval: 10000 });
          
              // 基础数据初始化
            learun.clientdata.init();

            // 加载功能列表
            learun.clientdata.get('module', {
                callback: function (data) {
                    var map = {};
                    var TypeMap = {};
                    $.each(data, function (_index, _item) {
                        map[_item.F_Id] = _item;
                        TypeMap[_item.F_Type] = TypeMap[_item.F_Type] || [];
                        TypeMap[_item.F_Type].push(_item);
                    });
                    // 加载我的应用
                    learun.myModule.get(data, function (myModules) {
                        var $appbox = $page.find('#lr_modulelist_mymodule');
                        $.each(myModules, function (_index, _id) {
                            var item = map[_id];
                            if (item) {
                                var _html = '\
                                        <div class="appitem" data-value="'+ item.F_Id + '">\
                                            <div><i class="'+ item.F_Icon + '"></i></div>\
                                            <span>'+ item.F_Name + '</span>\
                                        </div>';
                                var _$html = $(_html);
                                _$html[0].item = item;
                                $appbox.append(_$html);
                            }
                        });
                      

                    });
                   

                   
                    // 加载全部应用
                    var $app = $page.find('.lr-modulelist-page');
                    $.each(TypeMap, function (_type, _modules) {
                        var _html = '\
                        <div class="lr-app-panel" data-app="'+ _type + '">\
                            <div class="title" ></div>\
                            <div class="content"></div>\
                        </div>';
                        $app.append(_html);
                        var $content = $app.find('[data-app="' + _type + '"] .content');
                        learun.clientdata.get('dataItem', {
                            code: 'function',
                            key: _type,
                            callback: function (data, op) {
                                $app.find('[data-app="' + op.key + '"] .title').text(data.text);
                            }
                        });
                        $.each(_modules, function (_index, _item) {
                            var __html = '\
                            <div class="appitem" data-value="'+ _item.F_Id + '">\
                                <div><i class="'+ _item.F_Icon + '"></i></div>\
                                <span>'+ _item.F_Name + '</span>\
                            </div>';
                            //alert(_item.F_Name);
                            var __$html = $(__html);
                            __$html[0].item = _item;
                            $content.append(__$html);
                        });
                    });

                    $app.scroll()
                }
            });
            var duc = '<div class="appitem dvc" onclick="bcud()" data-value=""><div><i class="iconfont icon-remind"></i></div><span>视频会议</span> </div>';
            $(".content").eq(0).append(duc)
            $('body').on('click', '.appitem', function () {
               
            })

         
            // 注册编辑我的应用
            $page.find('#lr_edit_myapp').on('tap', function () {
                learun.nav.go({ path: 'workspace/modulelist/edit', title: "我的应用编辑" });
            });
            // 点击功能按钮
            $page.delegate('.appitem', 'tap', function () {
                var $this = $(this);
                var item = $this[0].item;
                if (item.F_IsSystem === 1) {// 代码开发功能
                    learun.nav.go({ path: item.F_Url, title: item.F_Name, isBack: true, isHead: true, type: 'right' });
                }
                else {// 自定义表单开发功能
                    if (item.F_IsSystem === 3) {
                        learun.nav.go({ path: 'nworkflow/createflow', title: '创建【' + item.F_Name + '】', type: 'right', param: { schemeCode: item.F_CodeId } });                  
                    } else {
                        learun.nav.go({ path: 'custmerform', title: item.F_Name, param: { formSchemeId: item.F_FormId, girdScheme: item.F_Scheme }, isBack: true, isHead: true, type: 'right' });
                    }
                 
                }
                return false;
            });
            
        },
        reload: function ($page, pageinfo) {
            if (learun.isOutLogin) {// 如果是重新登录的情况刷新下桌面数据
                learun.isOutLogin = false;
                learun.clientdata.clear('module');
                learun.myModule.states = -1;
            }
            // 加载功能列表
            learun.clientdata.get('module', {
                callback: function (data) {
                    var map = {};
                    $.each(data, function (_index, _item) {
                        map[_item.F_Id] = _item;
                    });
                    // 加载我的应用
                    learun.myModule.get(data, function (myModules) {
                        var $appbox = $page.find('#lr_modulelist_mymodule');
                        $appbox.html("");
                        $.each(myModules, function (_index, _id) {
                            var item = map[_id];
                            if (item) {
                                var _html = '\
                                        <div class="appitem" data-value="'+ item.F_Id + '">\
                                            <div><i class="'+ item.F_Icon + '"></i></div>\
                                            <span>'+ item.F_Name + '</span>\
                                        </div>';
                                var _$html = $(_html);
                                _$html[0].item = item;
                                $appbox.append(_$html);
                            }
                        });
                    });
                }
            });

        }
    };
    return page;
})();