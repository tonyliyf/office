/* * 版 本 DC-FW V1.0.1 东雅图敏捷开发框架(http://www.dongyatu.com)
 * Copyright (c) 2018-2019 东雅图信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-26 16:32
 * 描  述：打卡记录
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

            //alert("xxxxxx");
            var map = new BMap.Map("allmap");
            var gc = new BMap.Geolocation();
            gc.enableSDKLocation();
            var top_right_navigation = new BMap.NavigationControl({ anchor: BMAP_ANCHOR_TOP_RIGHT, type: BMAP_NAVIGATION_CONTROL_SMALL }); //右上角，仅包含平移和缩放按钮
            map.addControl(top_right_navigation);
            map.enableScrollWheelZoom(true);     
            map.centerAndZoom("枝江", 17);  // 初始化地图,设置中心点坐标和地图级别

            g_latitude = 0.0;
            g_longitude = 0.0;

            var onSuccess = function (position) {
                /*
                alert('纬度: ' + position.coords.latitude + '\n' +
                      '经度: ' + position.coords.longitude + '\n' +
                      '海拔: ' + position.coords.altitude + '\n' +
                      '水平精度: ' + position.coords.accuracy + '\n' +
                      '垂直精度: ' + position.coords.altitudeAccuracy + '\n' +
                      '方向: ' + position.coords.heading + '\n' +
                      '速度: ' + position.coords.speed + '\n' +
                      '时间戳: ' + position.timestamp + '\n');
                //*/
                g_latitude = position.coords.latitude;
                g_longitude = position.coords.longitude;
                var point = new BMap.Point(position.coords.longitude, position.coords.latitude);//纬度,经度
                var marker = new BMap.Marker(point);  // 创建标注
                map.addOverlay(marker);              // 将标注添加到地图中
                map.panTo(point);
                //map.panTo(new BMap.Point(113.262232, 23.154345));
                //var circle = new BMap.Circle(point, 150, { fillColor: "blue", strokeWeight: 1, fillOpacity: 0.3, strokeOpacity: 0.3 });
                //map.addOverlay(circle);

                /*
                var circle = new BMap.Circle(point, 1500, { fillColor: "blue", strokeWeight: 1, fillOpacity: 0.3, strokeOpacity: 0.3 });
                map.addOverlay(circle);
                var local = new BMap.LocalSearch(map, { renderOptions: { map: map, autoViewport: false } });
                local.searchNearby('餐馆', point, 1500);
                //alert("aaa");
                //var point1 = new BMap.Point(position.coords.longitude + 0.001, position.coords.latitude + 0.001);//纬度,经度
                //var marker1 = new BMap.Marker(point1);  // 创建标注
                //map.addOverlay(marker1);              // 将标注添加到地图中
                //*/
            }
            function onError(error) {
                alert('code: ' + error.code + '\n' +
                    'message: ' + error.message + '\n');
            }
            //setTimeout(function () {
                //gc.getCurrentPosition(onSuccess, onError);
                gc.getCurrentPosition(function (r) {
                    if (this.getStatus() == BMAP_STATUS_SUCCESS) {
                        var mk = new BMap.Marker(r.point);
                        g_latitude = r.point.lat;
                        g_longitude = r.point.lng;
                        map.addOverlay(mk);
                        map.panTo(r.point);
                        //alert('您的位置：' + r.point.lng + ',' + r.point.lat);
                    }
                    else {
                        alert('failed' + this.getStatus());
                    }
                });
            //}, 200);

            $page.find('#btn_card').on('tap', function () {
                //learun.nav.go({ path: 'LR_CodeDemo/DC_OA_AttenceRecord/form', title: '新增', type: 'right' });
                var _postParam = {
                    longitude: g_longitude,
                    latitude: g_latitude
                };
                /*
                learun.httppost(config.webapi + 'learun/adms/LR_CodeDemo/DC_OA_AttenceRecord/save', _postParam, (data) => {
                    if (data) {
                        console.log(data.info);
                        learun.layer.toast(data.info);
                    } else {
                        learun.layer.toast('打卡失败');
                        //alert('yyyyyy');
                    }
                });
                //*/
                var param = {};
                var logininfo = learun.storage.get('logininfo');
                if (!logininfo) {
                    callback(null);
                    return false;
                }
                param.token = logininfo.token;
                param.loginMark = learun.deviceId();
                var type = learun.type(_postParam);
                if (type === 'object' || type === 'array') {
                    param.data = JSON.stringify(_postParam);
                }
                else if (type === 'string') {
                    param.data = _postParam;
                }

                learun.http.post(config.webapi + 'learun/adms/LR_CodeDemo/DC_OA_AttenceRecord/save', param, function (res) {
                    if (res === null) {
                        learun.layer.toast('无法连接服务器,请检测网络！');
                    }
                    else if (res.code === 410) {
                        if (!learun.isOutLogin) {
                            learun.isOutLogin = true;
                            learun.layer.toast('登录过期,请重新登录!');
                            learun.storage.set('logininfo', null);
                            learun.nav.go({ path: 'login', isBack: false, isHead: false });
                        }
                    } else {
                        if (res.data.info == null) {
                            learun.layer.toast('不在打卡设置范围，打卡无效！');
                        } else {
                            learun.layer.toast(res.data.info);
                        }
                    }
                });
            });
        },
        lclass: 'lr-list',
        loadData: function (param, callback, $page) {// 列表加载后台数据
            /*
            var _postParam = {
                pagination: {
                    rows: param.rows,
                    page: param.page,
                    sidx: 'DC_OA_AttenceRecordId',
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
            learun.httpget(config.webapi + 'learun/adms/LR_CodeDemo/DC_OA_AttenceRecord/pagelist', _postParam, (data) => {
                $page.find('.lr-badge').text('0');
                if (data) {
                    $page.find('.lr-badge').text(data.records);
                    callback(data.rows, parseInt(data.records));
                }
                else {
                    callback([], 0);
                }
            });
            //*/
        },
        rowRender: function (_index, _item, _$item, $page) {// 渲染列表行数据
            _$item.addClass('lr-list-item lr-list-item-multi');
            _$item.append($('<p class="lr-ellipsis"><span>文本框:</span></p>').dataFormatter({ value: _item.F_Description            }));
            return '';
        },
        rowClick: function (item, $item, $page) {// 列表行点击触发方法
            learun.nav.go({ path: 'LR_CodeDemo/DC_OA_AttenceRecord/form', title: '详情', type: 'right', param: { keyValue: item.DC_OA_AttenceRecordId } });
        },
        btnClick: function (item, $item, $page) {// 左滑按钮点击事件
            learun.layer.confirm('确定要删除该笔数据吗？', function (_index) {
                if (_index === '1') {
                    learun.layer.loading(true, '正在删除该笔数据');
                    learun.httppost(config.webapi + 'learun/adms/LR_CodeDemo/DC_OA_AttenceRecord/delete', item.DC_OA_AttenceRecordId , (data) => {
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
