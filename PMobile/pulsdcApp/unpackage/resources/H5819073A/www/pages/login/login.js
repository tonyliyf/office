(function () {
    var page = {
        headColor: '#ffffff',
        init: function ($page) {
            $page.find('#loginBtn').on('tap', function () {
                var account = $('#account').val();
                var password = $('#password').val();

                if (account === "") {
                    learun.layer.warning('用户名不能为空！', function () { }, '系统提示', '关闭');
                } else if (password === "") {
                    learun.layer.warning('密码不能为空！', function () { }, '系统提示', '关闭');
                } else {
                    var data = {
                        username: account,
                        password: $.md5(password)
                    };
                    var postdata = {
                        token: '',
                        loginMark: learun.deviceId(),// 正式请换用设备号
                        data: JSON.stringify(data)
                    };
                    var path = config.webapi;
                    learun.layer.loading(true, "正在登录，请稍后");
                    learun.http.post(path + "learun/adms/user/login", postdata, (res) => {
                        learun.layer.loading(false);
                        if (res === null) {
                            learun.layer.warning('无法连接服务器,请检测网络！', function () { }, '系统提示', '关闭');
                            return;
                        }

                        if (res.code === 200) {
                            var logininfo = {
                                account: account,
                                token: res.data.baseinfo.token,
                                date: learun.date.format(new Date(), 'yyyy-MM-dd hh:mm:ss')
                            };
                            learun.storage.set('logininfo', logininfo);
                            learun.storage.set('userinfo', res.data);
                            $('#account').val('');
                            $('#password').val('');
                            learun.tab.go('workspace');
                        } else {
                            learun.layer.warning(res.info, function () { }, '系统提示', '关闭');
                        }
                    });
                }
            });
            var cameraOpened = false
            var initCamera = function (cb) {
                var windowWidth = $('body').width()
                var options = {
                    x: windowWidth / 4,
                    y: 20,
                    width: windowWidth / 2,
                    height: windowWidth / 2,
                    camera: CameraPreview.CAMERA_DIRECTION.FRONT,
                    toBack: false,
                    tapPhoto: false,
                    tapFocus: false,
                    previewDrag: false,
                    storeToFile: false,
                    disableExifHeaderStripping: false
                };

                CameraPreview.startCamera(options, cb);
            }
            $page.find('#faceLoginBtn').on('tap', function () {
                if (!cameraOpened) {
                    cameraOpened = true
                    initCamera(function () {
                        function checkFace() {
                            if (cameraOpened) {
                                CameraPreview.takeSnapshot({ quality: 100 }, function (base64PictureData) {
                                    var img = document.getElementById('hideimg');
                                    $('#hideimg').attr('src', 'data:image/jpeg;base64,' + base64PictureData)
                                    var tracker = new tracking.ObjectTracker('face');
                                    tracker.setStepSize(1.7);
                                    tracking.track('#hideimg', tracker);
                                    tracker.on('track', function (event) {
                                        if (event.data.length > 0) {
                                            CameraPreview.stopCamera()
                                            var bytes = window.atob(base64PictureData);
                                            var ab = new ArrayBuffer(bytes.length);
                                            var ia = new Uint8Array(ab);
                                            for (var i = 0; i < bytes.length; i++) {
                                                ia[i] = bytes.charCodeAt(i);
                                            }
                                            var file = new Blob([ab], { type: 'image/png' });
                                            var formData = new FormData();
                                            formData.append("file", file);
                                            var path = config.webapi;
                                            learun.layer.loading(true, "正在登录，请稍后");
                                            $.ajax({
                                                url: path + "learun/adms/user/facelogin?loginMark=" + learun.deviceId(),
                                                type: 'POST',
                                                data: formData,
                                                processData: false,
                                                contentType: false,
                                                success: function (responseStr) {
                                                    learun.layer.loading(false);
                                                    var res = responseStr
                                                    if (res.code === 200) {
                                                        var logininfo = {
                                                            account: account,
                                                            token: res.data.baseinfo.token,
                                                            date: learun.date.format(new Date(), 'yyyy-MM-dd hh:mm:ss')
                                                        };
                                                        learun.storage.set('logininfo', logininfo);
                                                        learun.storage.set('userinfo', res.data);
                                                        $('#account').val('');
                                                        $('#password').val('');
                                                        learun.tab.go('workspace');
                                                    } else {
                                                        learun.layer.warning(res.info, function () { }, '系统提示', '关闭');
                                                    }
                                                },
                                                error: function (responseStr) {
                                                    learun.layer.loading(false);
                                                    alert(JSON.stringify(responseStr))
                                                }
                                            });
                                        } else {
                                            checkFace()
                                        }
                                    });
                                });
                            }
                        }
                        checkFace()
                    })
                } else {
                    cameraOpened = false
                    CameraPreview.stopCamera()
                }
            })
        }
    };
    return page;
})();
