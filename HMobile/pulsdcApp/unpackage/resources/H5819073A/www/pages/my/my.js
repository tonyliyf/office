(function () {
    var userinfo = null;
    let chcp = window.chcp;

    var page = {
        isScroll: true,
        init: function ($page) {
            // 获取登录者信息
            userinfo = learun.storage.get('userinfo');
            $page.find('.name').text(userinfo.baseinfo.realName);
            $page.find('img').attr('src', config.webapi + 'learun/adms/user/img?data=' + userinfo.baseinfo.userId);

            // 人员列表数据初始化
            learun.clientdata.get('department', {
                key: userinfo.baseinfo.departmentId,
                callback: function (data) {
                    $page.find('.subname').text(data.name || '总集团公司');
                }
            });

            $page.find('#outloginbtn').on('tap', function () {
                learun.layer.confirm('确定要退出账号?', function (_index) {
                    if (_index === '1') {
                        learun.isOutLogin = true;
                        learun.storage.set('logininfo', null);
                        learun.nav.go({ path: 'login', isBack: false, isHead: false });
                    }

                }, '', ['取消', '退出']);
            });

            //检查更新
            $page.find('#updatebtn').on('tap', function () {
                chcp.fetchUpdate(function (error, data) {
                    if (!error) {
                        //alert('需要更新')
                        learun.layer.toast('需要更新！');
                        chcp.installUpdate(function (error) {
                            learun.layer.toast('更新完成！');
                            //alert("更新完成")
                        })
                    } else {
                        learun.layer.toast('当前是最新版本！');
                        //alert("你当前是最新版本")
                    }
                })
            });

            $page.find('.lr-list-item-icon').on('tap', function () {
                var path ='my/' + $(this).attr('data-value');
                var title = $(this).text();
                learun.nav.go({ path: path, title: title, type: 'right' });
            });

            $page.find('.userinfo').on('tap', function () {
                learun.nav.go({ path: 'my/userInfo', title: '个人信息', type: 'right' });
            });

        },
        reload: function ($page, pageinfo) {
            // 获取登录者信息
            var newUserinfo = learun.storage.get('userinfo');

            if (userinfo.baseinfo.userId != newUserinfo.baseinfo.userId) {
                userinfo = newUserinfo;
                $page.find('.name').text(userinfo.baseinfo.realName);
                $page.find('img').attr('src', config.webapi + 'learun/adms/user/img?data=' + userinfo.baseinfo.userId);

                // 人员列表数据初始化
                learun.clientdata.get('department', {
                    key: userinfo.baseinfo.departmentId,
                    callback: function (data) {
                        $page.find('.subname').text(data.name || '总集团公司');
                    }
                });
            }
        }
    };
    return page;
})();