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
        	var vc=drc-88;
        	$(".mac").css("height",vc)
    var hdc="<div class='tcct_top'><div class='tct_left'>"+
	"<span class='tcsp' style='position: absolute;z-index: 100;margin-left: 5px;'>项目信息</span>"+
	"<div class='xlcd'><ul class='xl_ul'><li class='xl_li' type='0'>项目信息</li>"+
	"<li class='xl_li' type='1'>合同管理</li><li class='xl_li' type='2'>前期管理</li>"+
	"<li class='xl_li' type='3'>项目施工信息</li><li class='xl_li' type='4'>考勤统计</li>"+
	"</ul></div></div><div class='tct_rig'><img src='images/guanb.png'/></div></div>";
    $("body").prepend(hdc)
    
    
    
    
    
    
//  function preventDefault(e) {
//  e.preventDefault();
//}
//	document.removeEventListener('touchmove', preventDefault, false);

	var map = new AMap.Map('mapDiv', {
        resizeEnable: true, //是否监控地图容器尺寸变化
        zoom: 13, //初始化地图层级
        center: [111.754821, 30.431865] //初始化地图中心点
    });

	
	var markers = [];
	function remo(){
		map.remove(markers)
	}
    AMapUI.loadUI(['overlay/SimpleInfoWindow'], function (SimpleInfoWindow) {
        function GetIcon(type) {
            switch (type) {
                case 1: return "images/dl.png"
                case 2: return "/Resource/Img/dalo.png"
                case 3: return "/Resource/Img/ggp.png"
                default: return ""
            }
        }
        
        mpa()
		function mpa(){
        	learun.httpget(config.webapi + 'learun/adms/ProjectManager/Dc_EngineProject_info/GetProjectInfo', {}, function(data) {
	        	console.log(data)
	            $.each(data, function (i, v) {
	                var icon = new AMap.Icon({
	                    size: new AMap.Size(50, 50),
	                    // 图标的取图地址
	                    image: GetIcon(1),
	                    imageSize: new AMap.Size(50, 50)
	                });
	                if(v.F_CenterpointCoordinates=="[]"){
	                	
	                } else {
	                	var marker = new AMap.Marker({
	                	    map: map,
	                	    zIndex: 9999999,
	                	    position: JSON.parse(v.F_CenterpointCoordinates),
	                	    icon: icon,
	                	});
	                }
	        
	        //列表显示
	        var htcc="<div class='xm_box' id='"+v.F_PIId+"'><div class='xm_box_left'><img src='images/tix.png'/></div>"+
			"<div class='xm_box_right'><div class='xbox_top'><div class='xbox_tit'>"+v.F_ProjectName+"</div>"+
			"<div class='xobx_time'>"+v.F_ProjectApprovalDate.substring(0,10)+"</div></div>"+
			"<div class='xbox_bottom'>"+v.F_JRYCompany+"</div></div></div>";
			$(".xm_list").append(htcc)
			var hei=$(".xm_list").outerHeight();
			$(".mac").css("min-height",hei)
	        $(".xm_box").on("tap",function(){
	        	var pid=$(this).attr("id")
				xmxx(pid)   //项目
				qqgl(pid)  //前期
				htxx(pid)   //合同
				sgjl(pid)   //施工
			})
	                
	                marker.on('click', function(ev) {
					  var pid=v.F_PIId;
	                    xmxx(pid)   //项目
	                   
	                    
setTimeout(function () { qqgl(pid)  //前期
 htxx(pid)   //合同
	                      
    sgjl(pid)   //施工

}, 1000)

                        kaoq(pid)
//	                    var ddc=$('.nr').eq(2).css("height","500px");
//						alert(ddc)
	                    
					});
	                AMap.event.addListener(marker, 'tap', function () {

//						var infoWindow = new SimpleInfoWindow({
//						   infoTitle: '<strong>'+v.F_ProjectName+'</strong>',
//	                        infoBody: '<p class="my-desc">'+v.F_ProjectBuildType+'</p>',
//	                        //基点指向marker的头部位置
//	                        offset: new AMap.Pixel(0, -31)
//						});
//	                    infoWindow.open(map, marker.getPosition());
	                   
	                });
	                 markers.push(marker);
	                
	            })
	        }, 'json')
		}
    });
        	
        	
        

        	
        	
        	
        	
//      var b = document.getElementsByTagName("body")[0];
//		b.addEventListener("touchmove", function(e){
//		e.preventDefault();
//		});
//		(function(){
//		var startX,startY,endX,endY,moveLength;
//		var el = document.querySelector(".f-scroll");
//		//获取点击开始的坐标
//		el.addEventListener("touchstart", function (e){
//		startX = e.touches[0].pageX;
//		startY = e.touches[0].pageY;
//		});
//		//获取点击结束后的坐标
//		el.addEventListener("touchend", function(e){
//		endX = e.changedTouches[0].pageX;
//		endY = e.changedTouches[0].pageY;
//		var x = Math.abs(endX - startX);
//		var y = Math.abs(endY - startY);
//		//长方形的斜边长 = 两个直线的平方的和的平方根
//		moveLength = Math.sqrt(Math.pow(x, 2) + Math.pow(y, 2));
////		alert("本次的移动距离为："+moveLength);
//		var dvc=parseInt(moveLength)
////		alert(dvc)
//		$(".yd").val(dvc)
//		})
//		})();
        	
        
        
//      var startx, starty;
//    //获得角度
//    function getAngle(angx, angy) {
//        return Math.atan2(angy, angx) * 180 / Math.PI;
//    };
// 
//    //根据起点终点返回方向 1向上 2向下 3向左 4向右 0未滑动
//    function getDirection(startx, starty, endx, endy) {
//        var angx = endx - startx;
//      var angy = endy - starty;
//       var result = 0;
//
//       //如果滑动距离太短
//       if (Math.abs(angx) < 2 && Math.abs(angy) < 2) {
//           return result;
//       }
//
//       var angle = getAngle(angx, angy);
//       if (angle >= -135 && angle <= -45) {
//          result = 1;
//       } else if (angle > 45 && angle < 135) {
//           result = 2;
//       } else if ((angle >= 135 && angle <= 180) || (angle >= -180 && angle < -135)) {
//           result = 3;
//       } else if (angle >= -45 && angle <= 45) {
//          result = 4;
//       }
//
//      return result;
//   }
      
      
      
     //手指接触屏幕
//  document.addEventListener("touchstart", function(e) {
//      startx = e.touches[0].pageX;
//       starty = e.touches[0].pageY;
//   }, false);
//   //手指离开屏幕
//   document.addEventListener("touchmove", function(e) {
//       var endx, endy;
//      endx = e.changedTouches[0].pageX;
//       endy = e.changedTouches[0].pageY;
//       var direction = getDirection(startx, starty, endx, endy);
//       switch (direction) {
//          case 0:
//               break;
//           case 1:
////              alert("向上！")  //负数
//				if($('.tcbj').is(':hidden')){
//				      //如果隐藏时。。。
//						
//				}else{
//				      //如果显示时。。。
//				}
//               break;
//          case 2:
////              alert("向下！")   //正数
//              if($('.tcbj').is(':hidden')){
//				      //如果隐藏时。。。
//						
//				}else{
//					
//				      //如果显示时。。。
//				}
//              break;
//          case 3:
////               alert("向左！")
//              break;
//           case 4:
////              alert("向右！")
//               break;
//          default:
//      }
// }, false);
        
        	
        	
        	
        	
//      	var map = new BMap.Map("mapDiv");
//			var point = new BMap.Point(111.754821, 30.431865);
//			map.centerAndZoom(point, 15); // 编写自定义函数，创建标注   
//			map.enableScrollWheelZoom(true);
			
        	
			
			$(".tcsp").on("tap",function(){
				event.stopPropagation();
				$(".xlcd").show()
				
			})
			
			$(".xl_li").on("tap",function(){
				$(".xlcd").hide()
				var nr=$(this).text();
				$(".tct_left span").text(nr)
				var typ=$(this).attr("type");
				$(".nr").hide().eq(typ).show();
				var hei=$(".nr").eq(typ).outerHeight();
				$(".tcbj").css("height",hei-vc)
			})
			
//			$("body").on("tap",function(){
//				$(".xlcd").hide()
//			})
			
			function xmxx(pid){  //项目信息
				learun.httpget(config.webapi + 'learun/adms/ProjectManager/Dc_EngineProject_info/GetProjectInfo', {projectid:pid}, function(data) {
					console.log(data)
					$(".nr").eq(0).find(".nr_list").remove()
					$.each(data, function (index, item) {
						var pic=item.F_PIId
						if(pic==pid){
							var xmmc="<div class='nr_list'><div class='nr_left'>项目名称：</div>"+
							"<div class='nr_rig'>"+item.F_ProjectName+"</div></div>";
							var xmbh="<div class='nr_list'><div class='nr_left'>项目编号：</div>"+
							"<div class='nr_rig'>"+item.F_ProjectItemNumber+"</div></div>";
							var lxbh="<div class='nr_list'><div class='nr_left'>立项编号：</div>"+
							"<div class='nr_rig'>"+item.F_ProjectYear+"</div></div>";
							var xmjs="<div class='nr_list'><div class='nr_left'>项目建设类型：</div>"+
							"<div class='nr_rig'>"+item.F_ProjectBuildType+"</div></div>";
							var xmtz="<div class='nr_list'><div class='nr_left'>项目投资金额(万元)：</div>"+
							"<div class='nr_rig'>"+item.F_EngineeringCost+"</div></div>";
		//					var xzqh="<div class='nr_list'><div class='nr_left'>行政区划：</div>"+
		//					"<div class='nr_rig'>"+data[0].F_area+"</div></div>";
							var rq=item.F_ProjectApprovalDate.substring(0,10)
							var lxrq="<div class='nr_list'><div class='nr_left'>立项日期：</div>"+
							"<div class='nr_rig'>"+rq+"</div></div>";
							var kg=item.F_PlannedStartDate.substring(0,10)
							var jhkg="<div class='nr_list'><div class='nr_left'>计划开工时间：</div>"+
							"<div class='nr_rig'>"+kg+"</div></div>";
							var wg=item.F_PlannedEndDate.substring(0,10)
							var jhwg="<div class='nr_list'><div class='nr_left'>计划完工时间：</div>"+
							"<div class='nr_rig'>"+wg+"</div></div>";
							var xmss="<div class='nr_list'><div class='nr_left'>项目所属公司：</div>"+
							"<div class='nr_rig'>"+item.F_JRYCompany+"</div></div>";
							var xmdz="<div class='nr_list'><div class='nr_left'>项目地址：</div>"+
							"<div class='nr_rig'>"+item.F_ProjectAddress+"</div></div>";
							var beiz=item.F_Remarks
		        			if(beiz==null){beiz=""}
							var bz="<div class='nr_list'><div class='nr_left'>备注：</div>"+
							"<div class='nr_rig'>"+beiz+"</div></div>";
							var jl=item.F_CreateDatetime
		        			if(jl==null){jl=""}else{jl=jl.substring(0,10)}
							var jlsj="<div class='nr_list'><div class='nr_left'>记录时间：</div>"+
							"<div class='nr_rig'>"+jl+"</div></div>";
							$(".nr").eq(0).append(xmmc+xmbh+lxbh+xmjs+xmtz+lxrq+jhkg+jhwg+xmss+xmdz+bz+jlsj)
							$(".tcbj").show()
							$(".tcct_top").show()
							$(".nr").hide().eq(0).show()
							$(".tcsp").text("项目信息")
						}
						
					})
					
				});
			}
			
			
			function htxx(pid){  //合同信息
				learun.httppost(config.webapi + 'learun/adms/ProjectManager/Dc_EngineProject_info/GetProjectContractInfo', {projectid:pid}, function(data) {
					console.log(data)
					$(".nr").eq(1).find(".bus_list").remove()
					$.each(data, function (index, item) {
						var qdsj=item.f_signingtime.substring(0,10)
						var htlx="<div class='nr_list'><div class='nr_left'>合同类型：</div>"+
						"<div class='nr_rig'>"+item.f_contracttype+"</div></div>";
						var xmbh="<div class='nr_list'><div class='nr_left'>合同编号：</div>"+
						"<div class='nr_rig'>"+item.f_contractcode+"</div></div>";
						var htmc="<div class='nr_list'><div class='nr_left'>合同名称：</div>"+
						"<div class='nr_rig'>"+item.f_contractname+"</div></div>";
						var htje="<div class='nr_list'><div class='nr_left'>合同金额（万元）：</div>"+
						"<div class='nr_rig'>"+item.f_contractmoney+"</div></div>";
						var jsfs="<div class='nr_list'><div class='nr_left'>结算方式：</div>"+
						"<div class='nr_rig'>"+item.f_settlementmethod+"</div></div>";
						var fkss="<div class='nr_list'><div class='nr_left'>付款方式：</div>"+
						"<div class='nr_rig'>"+item.f_paymethod+"</div></div>";
						var qdsj="<div class='nr_list'><div class='nr_left'>签订时间：</div>"+
						"<div class='nr_rig'>"+qdsj+"</div></div>";
						$(".nr").eq(1).append("<div class='bus_list'>"+htlx+xmbh+htmc+htje+jsfs+fkss+qdsj+"</div>")
					})
					
				});
			}
			
			
			function qqgl(pid){  //前期管理
				
				learun.httppost(config.webapi + 'learun/adms/ProjectManager/Dc_EngineProject_info/GetBeforeProjectInfo', {projectid:pid}, function(data) {
					console.log(data)
					$(".nr").eq(2).find(".nr_list").remove()
					var bl=data[1].办理用地审批手续
					if(bl==null){bl=""}
					var xmmc="<div class='nr_list cuzy'><div class='nr_left'>"+data[0].办理用地审批手续+"：</div>"+
					"<div class='nr_rig'>"+bl+"</div></div>";
					var kx=data[1].可行性研究报告审批
					if(kx==null){kx=""}
					var xmmc="<div class='nr_list cuzy'><div class='nr_left'>"+data[0].可行性研究报告审批+"：</div>"+
					"<div class='nr_rig'>"+kx+"</div></div>";
//					var st=data[1].施工图审核
//					if(st==null){st=""}
//					var sgtsh="<div class='nr_list cuzy'><div class='nr_left'>"+data[0].施工图审核+"：</div>"+
//					"<div class='nr_rig'>"+st+"</div></div>";
//					var ss=data[1].施工图设计
//					if(ss==null){ss=""}
//					var sgtsj="<div class='nr_list cuzy'><div class='nr_left'>"+data[0].施工图设计+"：</div>"+
//					"<div class='nr_rig'>"+ss+"</div></div>";
					var sy=data[1].施工图预算
					if(sy==null){sy=""}
					var jsgh="<div class='nr_list cuzy'><div class='nr_left'>"+data[0].施工图预算+"：</div>"+
					"<div class='nr_rig'>"+sy+"</div></div>";
					var sy=data[1]['《建设工程规划许可证》']
					if(sy==null){sy=""}
					var ydxk="<div class='nr_list cuzy'><div class='nr_left'>"+data[0]["《建设工程规划许可证》"]+"：</div>"+
					"<div class='nr_rig'>"+sy+"</div></div>";
					var gh=data[1]['《建设用地规划许可证》']
					if(gh==null){gh=""}
					var ydgh="<div class='nr_list cuzy'><div class='nr_left'>"+data[0]["《建设用地规划许可证》"]+"：</div>"+
					"<div class='nr_rig'>"+gh+"</div></div>";
					var js=data[1]['《建设项目选址意见书》']
					if(js==null){js=""}
					var yjs="<div class='nr_list cuzy'><div class='nr_left'>"+data[0]["《建设项目选址意见书》"]+"：</div>"+
					"<div class='nr_rig'>"+js+"</div></div>";
					var js=data[1]['《建设项目选址意见书》']
					if(js==null){js=""}
					var yjs="<div class='nr_list cuzy'><div class='nr_left'>"+data[0]["《建设项目选址意见书》"]+"：</div>"+
					"<div class='nr_rig'>"+js+"</div></div>";
					var sh=data[1].用地预审
					if(sh==null){sh=""}
					var ydsh="<div class='nr_list cuzy'><div class='nr_left'>"+data[0].用地预审+"：</div>"+
					"<div class='nr_rig'>"+sh+"</div></div>";
//					var xz=data[1].行政部门审批
//					if(xz==null){xz=""}
//					var xzbm="<div class='nr_list cuzy'><div class='nr_left'>"+data[0].行政部门审批+"：</div>"+
//					"<div class='nr_rig'>"+xz+"</div></div>";
					var gs=data[1].规划设计方案审批
					if(gs==null){gs=""}
					var ghsj="<div class='nr_list cuzy'><div class='nr_left'>"+data[0].规划设计方案审批+"：</div>"+
					"<div class='nr_rig'>"+gs+"</div></div>";
//					var sb=data[1].设计单位招标
//					if(sb==null){sb=""}
//					var sjzb="<div class='nr_list cuzy'><div class='nr_left'>"+data[0].设计单位招标+"：</div>"+
//					"<div class='nr_rig'>"+sb+"</div></div>";
//					var sa=data[1].设计方案招标
//					if(sa==null){sa=""}
//					var sjfa="<div class='nr_list cuzy'><div class='nr_left'>"+data[0].设计方案招标+"：</div>"+
//					"<div class='nr_rig'>"+sa+"</div></div>";
					var cs=data[1].财政评审
					if(cs==null){cs=""}
					var czps="<div class='nr_list cuzy'><div class='nr_left'>"+data[0].财政评审+"：</div>"+
					"<div class='nr_rig'>"+cs+"</div></div>";
					var xy=data[1].项目启动会议纪要
					if(xy==null){xy=""}
					var xmqd="<div class='nr_list cuzy'><div class='nr_left'>"+data[0].项目启动会议纪要+"：</div>"+
					"<div class='nr_rig'>"+xy+"</div></div>";
					var xp=data[1].项目建议书审批
					if(xp==null){xp=""}
					var xmjy="<div class='nr_list cuzy'><div class='nr_left'>"+data[0].项目建议书审批+"：</div>"+
					"<div class='nr_rig'>"+xp+"</div></div>";
					var xs=data[1].项目请示批复
					if(xs==null){xs=""}
					var xmqs="<div class='nr_list cuzy'><div class='nr_left'>"+data[0].项目请示批复+"：</div>"+
					"<div class='nr_rig'>"+xs+"</div></div>";
					$(".nr").eq(2).append(xmmc+jsgh+ydxk+yjs+ydsh+ghsj+xmqd+xmjy+xmqs)
					
				});
				
				
			}
			
			function sgjl(pid){  //项目施工信息
				learun.httppost(config.webapi + 'learun/adms/ProjectManager/Dc_EngineProject_info/GetMainRecord', {projectid:pid}, function(data) {
					console.log(data)
					$(".nr").eq(3).find(".bus_list").remove()
					$.each(data, function (index, item) {
						var bh=data[index].rzbh
            			if(bh==null){bh==""}
						var xmmc="<div class='nr_list'><div class='nr_left'>日志编号：</div>"+
						"<div class='nr_rig'>"+bh+"</div></div>";
						var tx=data[index].txr
            			if(tx==null){tx==""}
						var txmb="<div class='nr_list'><div class='nr_left'>填写人：</div>"+
						"<div class='nr_rig'>"+tx+"</div></div>";
						var tr=data[index].tqqk
            			if(tr==null){tr==""}
						var txr="<div class='nr_list'><div class='nr_left'>天气情况：</div>"+
						"<div class='nr_rig'>"+tr+"</div></div>";
						var sj=data[index].txsj
            			if(sj==null){sj==""} else {sj=data[index].txsj.substring(0,10)}
						var txsj="<div class='nr_list'><div class='nr_left'>填写时间：</div>"+
						"<div class='nr_rig'>"+sj+"</div></div>";
						var sg=data[index].sgjzqk
            			if(sg==null){sg==""}
						var sgjd="<div class='nr_list'><div class='nr_left'>施工进度情况：</div>"+
						"<div class='nr_rig'>"+sg+"</div></div>";
//						var gz=data[index].f_buildmainwork
//          			if(gz==null){gz==""}
//						var sgzy="<div class='nr_list'><div class='nr_left'>施工主要工作：</div>"+
//						"<div class='nr_rig'>"+gz+"</div></div>";
						$(".nr").eq(3).append("<div class='bus_list'>"+xmmc+txmb+txr+txsj+sgjd+"</div>")
					})
				});
			}
			$(".tct_rig").on("tap",function(){
				$(".tcbj").hide()
				$(".tcct_top").hide()
				$(".xlcd").hide()
			})
			
			
			function kaoq(pid){  //考勤统计
				learun.httpget(config.webapi + 'learun/adms/ProjectManager/Dc_EngineProject_info/GetProjectAttenced', {projectid:pid}, function(data) {
					console.log(data)
					$(".nr").eq(4).find(".nr_list").remove()
					$.each(data, function (index, item) {
					})
					
				});
			}
			
			
			
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
