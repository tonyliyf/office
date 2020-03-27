/*页面js模板,必须有init方法*/
(function () {
    var companyMap;
    var departmentMap;
    var userMap;

    var getHeadImg = function (user) {
        var url = '';
        switch (user.img) {
            case '0':
                url += 'images/on-girl.jpg';
                break;
            case '1':
                url += 'images/on-boy.jpg';
                break;
            default:
                url += config.webapi + 'learun/adms/user/img?data=' + user.id;
                break;
        }
        return url;
    };

    var page = {
        isScroll: true,
        init: function ($page) {
        	var drc=document.body.clientHeight;
        	var vc=drc-44;
        	$(".mac").css("height",vc)
        	var map = new BMap.Map("mapDiv");
			var point = new BMap.Point(111.754821, 30.431865);
			map.centerAndZoom(point, 15); // 编写自定义函数，创建标注   
			map.enableScrollWheelZoom(true);
			
        	learun.httpget(config.webapi + 'learun/adms/ProjectManager/Dc_EngineProject_info/GetProjectInfo', {}, function(data) {
//				console.log(data)
				
				$.each(data, function (index, item) {
					var zb=item.F_CenterpointCoordinates;
					
					var poi=zb.substring(1,zb.length-1).split(',');
					  for(var i in poi){
					 	 poi[i]
					  }
					console.log(poi)
                    var icon = new BMap.Icon('images/gc.png', new BMap.Size(35, 35), {
						
					});
					var mkr = new BMap.Marker(new BMap.Point(poi[0], poi[1]), {
						icon: icon
					});
					map.addOverlay(mkr);
					mkr.addEventListener("click", function(){
						
//						 var opts = {    
//						    width : "50",     // 信息窗口宽度    
//						    height: "20",     // 信息窗口高度    
//						    title : "Hello"  // 信息窗口标题   
//						}    
//						var infoWindow = new BMap.InfoWindow("World", opts);  // 创建信息窗口对象    
//						map.openInfoWindow(infoWindow, map.getCenter());     
						
						
						var points=new BMap.Point(poi[0], poi[1]);
						setInfoWindow(2, "43efsf", 111, points);
						function setInfoWindow(bus_route, car_liscence_number, pay, points) {
							var content = '<div class="xxct" style="width:100%;"><div class="tit">'+item.F_JRYCompany+'</div><p>'+item.F_ProjectBuildType+'</p></div>';
						 
							var infoWindow = new BMap.InfoWindow(content, {
								offset: new BMap.Size(0, -20)
							}); //创建信息窗口对象
							map.openInfoWindow(infoWindow, points);
							var pid=item.F_PIId;
							htxx(pid)
						}
						
						
					}); 
                })
			});
			
			
			function htxx(pid){  //合同信息
				learun.httpget(config.webapi + 'learun/adms/ProjectManager/Dc_EngineProject_info/GetProjectContractInfo', {projectid:pid}, function(data) {
					console.log(data)
				});
			}
			$(".tct_rig").click(function(){
				$(".tcbj").hide()
			})
            companyMap = {};
            departmentMap = {};
            userMap = {};

            // 公司列表数据初始化
            learun.clientdata.getAll('company', {
                callback: function (data) {
                    $.each(data, function (_id, _item) {
                        companyMap[_item.parentId] = companyMap[_item.parentId] || [];
                        _item.id = _id;
                        companyMap[_item.parentId].push(_item);
                    });
                    var $list = $page.find('#lr_contact_companylist');
                    $.each(companyMap["0"], function (_index, _item) {
                        var _html = '\
                        <div class="lr-list-item" >\
                            <a class="lr-nav-left company" data-value="'+ _item.id + '" >' + _item.name + '</a>\
                        </div>';
                        $list.append(_html);
                    });

                    // 部门列表数据初始化
                    learun.clientdata.getAll('department', {
                        callback: function (data) {
                            $.each(data, function (_id, _item) {
                                _item.id = _id;
                                if (_item.parentId === "0") {
                                    departmentMap[_item.companyId] = departmentMap[_item.companyId] || [];
                                    departmentMap[_item.companyId].push(_item);
                                }
                                else {
                                    departmentMap[_item.parentId] = departmentMap[_item.parentId] || [];
                                    departmentMap[_item.parentId].push(_item);
                                }
                            });
                            // 人员列表数据初始化
                            learun.clientdata.getAll('user', {
                                callback: function (data) {
                                    $.each(data, function (_id, _item) {
                                        _item.id = _id;
                                        if (_item.departmentId) {
                                            userMap[_item.departmentId] = userMap[_item.departmentId] || [];
                                            userMap[_item.departmentId].push(_item);
                                        }
                                        else if (_item.companyId) {
                                            userMap[_item.companyId] = userMap[_item.companyId] || [];
                                            userMap[_item.companyId].push(_item);
                                        }
                                    });
                                }
                            });
                        }
                    });
                }
            });

            // 注册点击事件
            $('#lr_contact_companylist').on('tap', function (e) {
                e = e || window.event;
                var et = e.target || e.srcElement;
                var $et = $(et);
                if (et.tagName === 'IMG' || et.tagName === 'SPAN') {
                    $et = $et.parent();
                }

                var $list = $('<div class="lr-user-list" ></div>');
                var flag = false;
                var id = $et.attr('data-value');

                if ($et.hasClass('company')) {
                    if ($et.hasClass('bottom')) {
                        $et.removeClass('bottom');
                        $et.parent().find('.lr-user-list').remove();
                    }
                    else {                        
                        $list.css({ 'padding-left': '10px' });
                        // 加载人员
                        $.each(userMap[id] || [], function (_index, _item) {
                            var _html = '\
                            <div class="lr-list-item user"  data-value="'+ _item.id + '"  >\
                                <img src="'+ getHeadImg(_item) + '"  >\
                                <span >' + _item.name + '</span>\
                            </div>';

                            $list.append(_html);
                            flag = true;
                        });
                        // 加载部门
                        $.each(departmentMap[id] || [], function (_index, _item) {
                            var _html = '\
                            <div class="lr-list-item" >\
                                <a class="lr-nav-left department" data-value="'+ _item.id + '" >' + _item.name + '</a>\
                            </div>';

                            $list.append(_html);
                            flag = true;
                        });
                        // 加载公司
                        $.each(companyMap[id] || [], function (_index, _item) {
                            var _html = '\
                            <div class="lr-list-item" >\
                                <a class="lr-nav-left company" data-value="'+ _item.id + '" >' + _item.name + '</a>\
                            </div>';

                            $list.append(_html);
                            flag = true;
                        });

                        if (flag) {
                            $et.parent().append($list);
                        }
                        $et.addClass('bottom');
                    }
                    $list = null;
                    return false;
                }
                else if ($et.hasClass('department')) {
                    if ($et.hasClass('bottom')) {
                        $et.removeClass('bottom');
                        $et.parent().find('.lr-user-list').remove();
                    }
                    else {
                        $list.css({ 'padding-left': '10px' });
                        // 加载人员
                        $.each(userMap[id] || [], function (_index, _item) {
                            var _html = '\
                            <div class="lr-list-item user"  data-value="'+ _item.id + '"  >\
                                <img src="'+ getHeadImg(_item) + '"  >\
                                <span >' + _item.name + '</span>\
                            </div>';

                            $list.append(_html);
                            flag = true;
                        });
                        // 加载部门
                        $.each(departmentMap[id] || [], function (_index, _item) {
                            var _html = '\
                            <div class="lr-list-item" >\
                                <a class="lr-nav-left department" data-value="'+ _item.id + '" >' + _item.name + '</a>\
                            </div>';

                            $list.append(_html);
                            flag = true;
                        });

                        if (flag) {
                            $et.parent().append($list);
                        }
                        $et.addClass('bottom');
                    }
                    $list = null;
                    return false;
                }
                else if ($et.hasClass('user')){
                    var userName = $et.find('span').text();
                    learun.nav.go({ path: 'chat', title: userName, isBack: true, isHead: true, param: { hasHistory: true, userId: id }, type: 'right' });
                    $list = null;
                    return false;
                }

            });

            // 点击搜索框
            $page.find('.searchBox').on('tap', function () {
                learun.nav.go({ path: 'contacts/search', title: '', isBack: true, isHead: true });
            });
        },
        destroy: function (pageinfo) {
            companyMap = null;
            departmentMap = null;
            userMap = null;
        }
    };
    return page;
})();
