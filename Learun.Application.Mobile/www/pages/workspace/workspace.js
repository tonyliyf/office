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
	"<span class='tcsp' style='position: absolute;z-index: 100;margin-left: 5px;'>项目概况</span>"+
	"<div class='xlcd'><ul class='xl_ul'><li class='xl_li' type='0'>项目概况</li>"+
	"<li class='xl_li' type='1'>合同管理</li><li class='xl_li' type='2'>前期管理</li>"+
	"<li class='xl_li' type='3'>项目施工信息</li><li class='xl_li' type='4'>考勤统计</li>"+
	"</ul></div></div><div class='tct_rig'><div class='syb' style=><img src='images/fanh.png'><span>返回上一步</span></div></div></div>";
    $(".f-page-body").prepend(hdc)
    
    
    
    
    
    
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
	            $.each(data.data, function (i, v) {
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
	        
	        if(i==0){
	        	for (var d=0;d<data.State.length;d++){
	        		var htc="<div class='xm_list' type='"+data.State[d].f_itemvalue+"'><div class='xm_title'><img class='xm_img' src='images/jxz.png' /><span>"+data.State[d].f_itemname+"<span/></div></div>"
	        		$(".dov").append(htc)
	        	}
	        }
	        
	        
	        
	        //列表显示
	        $(".xm_list").each(function(){
	        	var typc=$(this).attr("type")
	        	if(v.F_ProjectState==typc){
	        		var htcc="<div class='xm_box' id='"+v.F_PIId+"'><div class='xm_box_left'><img src='images/tix.png'/></div>"+
					"<div class='xm_box_right'><div class='xbox_top'><div class='xbox_tit'>"+v.F_ProjectName+"</div>"+
					"<div class='xobx_time'>"+v.F_ProjectApprovalDate.substring(0,10)+"</div></div>"+
					"<div class='xbox_bottom'>"+v.F_JRYCompany+"</div><div class='wcjd'>完成进度："+v.Percent+"%</div></div></div>";
					$(".xm_list").eq(v.F_ProjectState).append(htcc)
	        	}
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
	            
	            $(".xm_box").on("tap",function(){
	            	$(".tcbj").show()
		        	var pid=$(this).attr("id")
		        	$(".jlid").val(pid)
		        	$(".box_list").show()
		        	$(".nr").hide()
//					xmxx(pid)   //项目
//					qqgl(pid)  //前期
//					htxx(pid)   //合同
//					sgjl(pid)   //施工
	//				ydjd(pid)
				})
	            $("body").delegate(".box_fh", "tap", function () {  //返回列表
	             	$(".tcbj").hide()
	            })
	            
	            $("body").delegate(".box_li", "tap", function () {
	             	var typ=$(this).attr("type")
	             	var pid=$(".jlid").val()
	             	$(".box_fh").hide()
	             	if(typ==1){
	             		xmxx(pid)  //项目概况
	             	}  else if(typ==2){
//	             		htxx(pid)  //合同信息
	             		
	             		$(".tcct_top").show()
						$(".tcsp").text("合同信息")
						$(".box_list").hide()
						$(".box_ul_thr .box_li").attr("id",pid)
						$(".nr").hide().eq(1).show()
	             	} else if(typ==3){
	             		qqgl(pid)  //前期
	             	} else if(typ==4){
	             		$(".xmid").val(pid)
	             		sgjl()  //施工信息
	             	} else if(typ==5){
	             		hyjl(pid)  //会议记录
	             	} else if(typ==6){
	             		ydjd(pid)//月度统计
	             	} else if(typ==7){
//	             		kaoq(pid)
						$(".box_list").hide()
	             		$(".tcct_top").show()
	             		$(".tcbj").show()
						$(".tcct_top").show()
						$(".nr").hide().eq(6).show()
						$(".box_ul_for .box_li").attr("type",pid)
						$(".tcsp").text("履职记录")
	             	}
	            })
	            
	            
	            
	            
	            var hei=$(".dov").outerHeight();
	            $(".mac").css("min-height",hei)
	        }, 'json')
		}
    });
        	
//     
        	
        	
        	
//      	var map = new BMap.Map("mapDiv");
//			var point = new BMap.Point(111.754821, 30.431865);
//			map.centerAndZoom(point, 15); // 编写自定义函数，创建标注   
//			map.enableScrollWheelZoom(true);
			
        	
			$("body").delegate(".box_ul_thr .box_li", "tap", function () {
				var pid=$(this).attr("id")
				var pname=$(this).find("span").text()
				$(".tcsp").text("合同信息-"+pname)
             	htxx(pid,pname)
            })
			
			$("body").delegate(".box_ul_for .box_li", "tap", function () {
				var pid=$(this).attr("id")
				var type=$(this).attr("type")
				var pname=$(this).find("span").text()
				$(".tcsp").text("履职记录-"+pname)
             	kaoq(pid,type)
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
			
			function xmxx(pid){  //项目概况
				learun.httpget(config.webapi + 'learun/adms/ProjectManager/Dc_EngineProject_info/GetProjectInfo', {projectid:pid}, function(data) {
					console.log(data)
					$(".box_list").hide()
					$(".nr").eq(0).find(".nr_list").remove()
					$.each(data.data, function (index, item) {
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
							var bz="<div class='nr_list'><div class='nr_left'>项目概况：</div>"+
							"<div class='nr_rig'>"+beiz+"</div></div>";
							var jl=item.F_CreateDatetime
		        			if(jl==null){jl=""}else{jl=jl.substring(0,10)}
							var jlsj="<div class='nr_list'><div class='nr_left'>记录时间：</div>"+
							"<div class='nr_rig'>"+jl+"</div></div>";
							$(".tcct .nr").eq(0).append(xmmc+xmbh+lxbh+xmjs+xmtz+lxrq+jhkg+jhwg+xmss+xmdz+bz+jlsj)
							$(".tcbj").show()
							$(".tcct_top").show()
							$(".nr").hide().eq(0).show()
							$(".tcsp").text("项目概况")
						}
						
					})
					
				});
			}
			
			$page.find('.lr-list-item-icon').on('tap', function () {
                var path ='workspace/' + $(this).attr('data-value');
                var title = $(this).text();
                learun.nav.go({ path: path, title: title, type: 'right' });
            });
			function download2(idc) {
	            var $form = $('<form method="GET"></form>');
	            $form.attr('action', idc);
	            $form.appendTo($('body'));
	            $form.submit();
	        }
			
			function htxx(pid,pname){  //合同信息
				learun.httppost(config.webapi + 'learun/adms/ProjectManager/Dc_EngineProject_info/GetProjectContractInfo', {projectid:pid,F_ItemValue:pname,F_PICId:""}, function(data) {
					console.log(data)
					$(".ht_list").find(".bus_list").remove()
					$(".box_ul_thr").hide()
					$(".tct_rig").attr("type",2)
					$.each(data.data, function (index, item) {
						
		        		var qdsj=item.f_signingtime.substring(0,10)
						var htlx="<div class='nr_list'><div class='nr_left'>合同类型：</div>"+
						"<div class='nr_rig'>"+item.f_contracttype+"</div></div>";
						var xmbh="<div class='nr_list'><div class='nr_left'>合同编号：</div>"+
						"<div class='nr_rig'>"+item.f_contractcode+"</div></div>";
						var type=item.f_contractappendices
						if(type==null){
							type=""
							var htmc="<div class='nr_list'><div  class='nr_left'>合同名称：</div>"+
							"<div class='nr_rig'><span>"+item.f_contractname+"</span></div></div>";
						} else {
							type=item.f_contractappendices.substring(item.f_contractappendices.length-3,item.f_contractappendices.length)
							if(type=="png"||type=="jpg"){
								var htmc="<div class='nr_list'><div class='nr_left'>合同名称：</div>"+
								"<div class='nr_rig'><span>"+item.f_contractname+"</span><div class='nr_an' id='"+item.f_contractappendices+"'><div class='xm_yl' style='margin-top: 9px;'>预览</div></div></div></div>";
							} else if(type=="pdf"){
								var htmc="<div class='nr_list'><div class='nr_left'>合同名称：</div>"+
								"<div class='nr_rig'><span>"+item.f_contractname+"</span><div class='nr_an' id='"+item.f_contractappendices+"'><div class='xm_xz' style='margin-top: 9px;'>下载</div></div></div></div>";
							}
						}
						var htje="<div class='nr_list'><div class='nr_left'>合同金额（万元）：</div>"+
						"<div class='nr_rig'>"+item.f_contractmoney+"</div></div>";
						var jsfs="<div class='nr_list'><div class='nr_left'>结算方式：</div>"+
						"<div class='nr_rig'>"+item.f_settlementmethod+"</div></div>";
						var fkss="<div class='nr_list'><div class='nr_left'>付款方式：</div>"+
						"<div class='nr_rig'>"+item.f_paymethod+"</div></div>";
						var qdsj="<div class='nr_list'><div class='nr_left'>签订时间：</div>"+
						"<div class='nr_rig'>"+qdsj+"</div></div>";
						$(".ht_list").append("<div class='bus_list ht_type' type='"+item.f_picid+"' id='"+pid+"'>"+htmc+xmbh+htje+jsfs+fkss+qdsj+"</div>")
						
						
					})
					
					
					
					
					var hei=$(".nr").eq(1).outerHeight();
					$(".tcbj").css("height",hei-vc)
					$(".tcbj").show()
					
				});
			}
			$("body").delegate(".ht_type", "tap", function () {
				var idc=$(this).attr("id")
				var type=$(this).attr("type")
                learun.nav.go({ path: 'workspace/contract', title: "合同详细", type: 'right', param: { processId: idc,picc:type } });
//				var gd=$(this).outerHeight();
//				if(gd<41){
//					$(".ht_type").css("height","40px")
//					$(this).css("height","auto")
//				} else {
//					$(this).css("height","40px")
//				}
			})
			
			$("body").delegate(".qqal", "tap", function () {
				var idc=$(this).attr("id")
				var type=$(this).attr("type")
                learun.nav.go({ path: 'workspace/qqgl', title: "前期信息详细", type: 'right', param: { processId: idc,picc:type } });
			})
	
			$('body').delegate('.xm_yl', 'tap', function () {
			 	var idc=$(this).parents(".nr_an").attr("id")
                learun.nav.go({ path: 'workspace/imglist', title: "图片预览", type: 'right', param: { processId: idc } });
            })
			
			$("body").delegate(".xm_title", "tap", function () {
				var sl=$(this).parents(".xm_list").find(".xm_box").length
				var hei=$(this).parents(".xm_list").outerHeight();
				if(sl>1){
					if(hei>100){
						$(this).parents(".xm_list").css("height","56px")
					} else {
						$(this).parents(".xm_list").css("height","auto")
					}
				}
				
				var sld=$(this).parents(".xc_list").find(".bus_list").length
				var heid=$(this).parents(".xc_list").outerHeight();
				if(sld=>1){
					if(heid>100){
						$(this).parents(".xc_list").css("height","56px")
					} else {
						$(this).parents(".xc_list").css("height","auto")
					}
				}
			})
			
			
			
			function qqgl(pid){  //前期管理
				learun.httppost(config.webapi + 'learun/adms/ProjectManager/Dc_EngineProject_info/GetBeforeProjectInfo', {projectid:pid}, function(data) {
					console.log(data)
					$(".box_list").hide()
					$(".qqal").remove()
					$.each(data, function (index, item) {
						var html="<div class='bus_lis qqal' type='"+pid+"' id='"+item.F_ProjectStage+"'><div class='nr_list'><div class='nr_left'><img class='htim' src='images/htt.png' /></div><div class='nr_rig'>"+item.text+"</div><img class='yjtim' src='images/right_arr.png'/></div></div>";
						$(".nr").eq(2).append(html)
					})
					
				});
				$(".tcbj").show()
				$(".tcct_top").show()
				window.setTimeout(function(){
					
				var hei=$(".nr").eq(2).outerHeight();
				$(".tcbj").css("height",hei-vc)
				}, 1000);
				
				$(".nr").hide().eq(2).show()
				$(".tcsp").text("前期信息")
				
			}
			
			$("body").delegate(".nrth .xm_xz", "tap", function () {
				var idc=$(this).attr("id")
				downFile(idc)
			})
			
			
			$("body").delegate(".ht .xm_xz", "tap", function () {
				var idc=$(this).parents(".nr_an").attr("id")
				downFile(idc)
			})
					
			$("body").delegate(".qqfj", "tap", function () {
				var idc=$(this).attr("id")
				downFile(idc)
			})	
					
			function downFile(content, filename) {
			    // 创建隐藏的可下载链接
			    var eleLink = document.createElement('a');
			    eleLink.download = filename;
			    eleLink.style.display = 'none';
			    // 字符内容转变成blob地址
			    var blob = new Blob([content]);
			    eleLink.href = content;
			    // 触发点击
			    document.body.appendChild(eleLink);
			    eleLink.click();
			    // 然后移除
			    document.body.removeChild(eleLink);
			};
			
			function sgjl(){  //项目施工信息
				var tim=$(".nr_time").val()
				var pid=$(".xmid").val()
				learun.httpget(config.webapi + 'learun/adms/ProjectManager/Dc_EngineProject_info/GetMainRecordNew', {projectid:pid}, function(data) {
					console.log(data)
					$(".box_list").hide()
					$(".nr_sg").find(".nr_sg_list").remove()
					var sgj=data[0].years;
					var sz=sgj.split(',');
					for(var i=0;i<sz.length;i++){
						var nd=sz[i]
						var htm="<div class='nr_sg_list' id='"+pid+"'><img src='images/wjj.png'><br><span>"+sz[i]+"</span></div>"
						$(".nr_sg").append(htm)
					}
					var year=data[0].years.substring(0,4)
					var month=data[0].years.substring(4,6)
					
//					
					$(".tcbj").show()
					$(".tcct_top").show()
					var hei=$(".nr").eq(3).outerHeight();
					$(".tcbj").css("height",hei-vc)
					$(".nr").hide().eq(3).show()
					$(".tcsp").text("施工记录")
				});
			}
			
			$("body").delegate(".nr_sg_list", "tap", function () {  //返回列表
             	var text=$(this).find("span").text()
             	var idc=$(this).attr("id")
             	sgxq(text,idc)
            })
			
			
			
			function sgxq(text,idc){  //项目施工信息
				learun.httppost(config.webapi + 'learun/adms/ProjectManager/Dc_EngineProject_info/GetMainRecord', {projectid:idc,code:text}, function(data) {
					console.log(data)
					$(".nr_sg").hide()
					$(".sg_list .nr_list").remove()
					$(".tct_rig").attr("type",6)
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
						
//						<div id='"+item.f_attachments+"' class='xm_xz'>附件下载</div>
						if(data[index].fj==null||data[index].fj==""){
							var chsc="<div class='nr_list'><div class='nr_left'>附件：</div>"+
						    "<div class='nr_rig'></div></div>";
						} else {
							var chsc="<div class='nr_list'><div class='nr_left'>附件：</div>"+
						    "<div class='nr_rig'><div class='nr_an' id='"+data[index].fj+"'><div class='xm_yl'>图片预览</div></div></div></div>";
						}
						
//						var gz=data[index].f_buildmainwork
//          			if(gz==null){gz==""}
//						var sgzy="<div class='nr_list'><div class='nr_left'>施工主要工作：</div>"+
//						"<div class='nr_rig'>"+gz+"</div></div>";
						$(".sg_list").append("<div class='bus_list'>"+xmmc+txmb+txr+txsj+sgjd+chsc+"</div>")
					})
					var hei=$(".nr").eq(3).outerHeight();
					$(".tcbj").css("height",hei-vc)
				});
			}
			
			function hyjl(pid){  //会议记录
				learun.httpget(config.webapi + 'learun/adms/ProjectManager/Dc_EngineProject_info/GetMeetingRecordData', {projectid:pid}, function(data) {
					console.log(data)
					$(".box_list").hide()
					$(".nr").eq(4).find(".bus_list").remove()
					$.each(data, function (index, item) {
						var bh=item.f_meetingtheme
            			if(bh==null){bh==""}
						var xmmc="<div class='nr_list'><div class='nr_left'>会议主题：</div>"+
						"<div class='nr_rig'>"+bh+"</div></div>";
						var tx=item.f_mrnum
            			if(tx==null){tx==""}
						var txmb="<div class='nr_list'><div class='nr_left'>会议编号：</div>"+
						"<div class='nr_rig'>"+tx+"</div></div>";
						var tr=item.f_conveningdepartment
            			if(tr==null){tr==""}
						var txr="<div class='nr_list'><div class='nr_left'>召开部门：</div>"+
						"<div class='nr_rig'>"+tr+"</div></div>";
						var sj=item.f_convenor
            			if(sj==null){sj==""}
						var txsj="<div class='nr_list'><div class='nr_left'>召集人：</div>"+
						"<div class='nr_rig'>"+sj+"</div></div>";
						var sg=item.f_meetinghost
            			if(sg==null){sg==""}
						var sgjd="<div class='nr_list'><div class='nr_left'>主持人：</div>"+
						"<div class='nr_rig'>"+sg+"</div></div>";
						var gz=item.f_meetingunits
            			if(gz==null){gz==""}
						var sgzy="<div class='nr_list'><div class='nr_left'>参会单位：</div>"+
						"<div class='nr_rig'>"+gz+"</div></div>";
						var cr=item.f_meetingattendee
            			if(cr==null){cr==""}
						var chr="<div class='nr_list'><div class='nr_left'>参会人：</div>"+
						"<div class='nr_rig'>"+cr+"</div></div>";
						var kssj=item.f_starttime
            			if(kssj==null){kssj==""}
						var ks="<div class='nr_list'><div class='nr_left'>开始时间：</div>"+
						"<div class='nr_rig'>"+kssj+"</div></div>";
						var end=item.f_endtime
            			if(end==null){end==""}
						var jssj="<div class='nr_list'><div class='nr_left'>结束时间：</div>"+
						"<div class='nr_rig'>"+end+"</div></div>";
						var sc=item.f_duration
            			if(sc==null){sc==""}
						var chsc="<div class='nr_list'><div class='nr_left'>时长：</div>"+
						"<div class='nr_rig'>"+sc+"</div></div>";
						
						
						if(item.f_scenepictures==null||item.f_attachments!=null){
							var chsc="<div class='nr_list'><div class='nr_left'>附件：</div>"+
						    "<div class='nr_rig'><div class='nr_an' id='"+item.f_scenepictures+"'><div id='"+item.f_attachments+"' class='xm_xz'>附件下载</div></div></div></div>";
						} else if(item.f_scenepictures!=null||item.f_attachments==null){
							var chsc="<div class='nr_list'><div class='nr_left'>附件：</div>"+
						    "<div class='nr_rig'><div class='nr_an' id='"+item.f_scenepictures+"'><div class='xm_yl'>图片预览</div></div></div></div>";
						} else {
							var chsc="<div class='nr_list'><div class='nr_left'>附件：</div>"+
						    "<div class='nr_rig'><div class='nr_an' id='"+item.f_scenepictures+"'><div class='xm_yl'>图片预览</div><div id='"+item.f_attachments+"' class='xm_xz'>附件下载</div></div></div></div>";
						}
						
						
						
						var yt=item.f_meetingtopics
            			if(yt==null){yt==""}
						var hyyt="<div class='nr_list'><div class='nr_left'>会议议题：</div>"+
						"<div class='nr_rig'>"+yt+"</div></div>";
						var hnr=item.f_meetingcontent
            			if(hnr==null){hnr==""}
						var hynr="<div class='nr_list'><div class='nr_left'>会议内容：</div>"+
						"<div class='nr_rig'>"+hnr+"</div></div>";
						$(".nr").eq(4).append("<div class='bus_list'>"+xmmc+txmb+txr+txsj+sgjd+sgzy+chr+ks+jssj+chsc+hyyt+hynr+"</div>")
					})
					$(".tcbj").show()
					$(".tcct_top").show()
					var hei=$(".nr").eq(4).outerHeight();
					$(".tcbj").css("height",hei-vc)
					$(".nr").hide().eq(4).show()
					$(".tcsp").text("会议记录")
				});
			}
			
			function ydjd(pid){  //项目月度进度填报
				learun.httpget(config.webapi + 'learun/adms/ProjectManager/Dc_EngineProject_info/Getformtable_main_150List', {F_PIId:pid}, function(data) {
					console.log(data)
					$(".box_list").hide()
					$(".nr").eq(5).find(".bus_list").remove()
					$.each(data, function (index, item) {
						var xmmc=data[index].f_projectname
            			if(xmmc==null){xmmc=""}
						var xmmc="<div class='nr_list'><div class='nr_left'>项目名称：</div>"+
						"<div class='nr_rig'>"+xmmc+"</div></div>";
						var dw=data[index].subcompanyname
            			if(dw==null){dw=""}
						var dwzz="<div class='nr_list'><div class='nr_left'>单位组织：</div>"+
						"<div class='nr_rig'>"+dw+"</div></div>";
						var bm=data[index].bm
            			if(bm==null){bm=""}
						var txmb="<div class='nr_list'><div class='nr_left'>部门：</div>"+
						"<div class='nr_rig'>"+bm+"</div></div>";
						var yd=data[index].yd
            			if(yd==null){yd=""}
						var txr="<div class='nr_list'><div class='nr_left'>月度：</div>"+
						"<div class='nr_rig'>"+yd+"</div></div>";
						var jd=data[index].jd
            			if(jd==null){jd=""}
						var txtj="<div class='nr_list'><div class='nr_left'>进度：</div>"+
						"<div class='nr_rig'>"+jd+"</div></div>";
						var txsj=data[index].txsj
            			if(txsj==null){txsj=""}
						var sgjd="<div class='nr_list'><div class='nr_left'>填写时间：</div>"+
						"<div class='nr_rig'>"+txsj+"</div></div>";
						var hbnr=data[index].hbnr
            			if(hbnr==null){hbnr=""}
						var hb="<div class='nr_list'><div class='nr_left'>汇报内容：</div>"+
						"<div class='nr_rig'>"+hbnr+"</div></div>";
						var xyjh=data[index].xyjh
            			if(xyjh==null){txsj=""}
						var jh="<div class='nr_list'><div class='nr_left'>下月计划：</div>"+
						"<div class='nr_rig'>"+xyjh+"</div></div>";
						var bz=data[index].bz
            			if(bz==null){bz=""}
						var tzbz="<div class='nr_list'><div class='nr_left'>备注：</div>"+
						"<div class='nr_rig'>"+txsj+"</div></div>";
						
//						var gz=data[index].f_buildmainwork
//          			if(gz==null){gz==""}
//						var sgzy="<div class='nr_list'><div class='nr_left'>施工主要工作：</div>"+
//						"<div class='nr_rig'>"+gz+"</div></div>";
						$(".nr").eq(5).append("<div class='bus_list'>"+xmmc+dwzz+txmb+txr+txtj+sgjd+hb+jh+tzbz+"</div>")
					})
					$(".tcbj").show()
					$(".tcct_top").show()
					var hei=$(".nr").eq(5).outerHeight();
					$(".tcbj").css("height",hei-vc)
					$(".nr").hide().eq(5).show()
					$(".tcsp").text("月度统计")
				});
			}
			
			
			$(".tct_rig").on("tap",function(){
				if($(this).attr("type")==2){
					$(".box_ul_thr").show()
					$(".ht_list .bus_list").remove()
					$(".tcsp").text("合同信息")
					$(this).attr("type",1)
				} else if($(this).attr("type")==4){
					$(".box_ul_for").show()
					$(".nr").eq(6).find(".bus_list").remove()
					$(".tcsp").text("履职记录")
					$(this).attr("type",1)
				} else if($(this).attr("type")==6){
					$(".nr_sg").show()
					$(".nr").eq(3).find(".bus_list").remove()
					$(".tcsp").text("施工记录")
					$(this).attr("type",1)
				} else{
					$(".nr").hide()
					$(".tcct_top").hide()
					$(".xlcd").hide()
					$(".box_list").show()
					$(".box_fh").show()
					$(".f-scroll").css("transform","translate3d(0px,0px, 0px) translateZ(0px)")
				}
			})
			
			
			function kaoq(pid,type){  //考勤统计
				learun.httppost(config.webapi + 'learun/adms/ProjectManager/Dc_EngineProject_info/GetProjectAttenced', {code:pid,projectid:type}, function(data) {
					console.log(data)
					$(".box_ul_for").hide()
					$(".lz_list .bus_list").remove()
					$(".tct_rig").attr("type",4)
					$.each(data, function (index, item) {
						var xmmc=item.f_createusername
            			if(xmmc==null){xmmc=""}
						var xmmc="<div class='nr_list'><div class='nr_left'>打卡人姓名：</div>"+
						"<div class='nr_rig'>"+xmmc+"</div></div>";
						var bm=item.f_month
            			if(bm==null){bm=""}
						var txmb="<div class='nr_list'><div class='nr_left'>考勤月份：</div>"+
						"<div class='nr_rig'>"+bm+"</div></div>";
						var yd=item.f_firstattencedatetime
            			if(yd==null){yd=""}
						var txr="<div class='nr_list'><div class='nr_left'>上午打卡时间：</div>"+
						"<div class='nr_rig'>"+yd+"</div></div>";
						var jd=item.f_secondattencedatetime
            			if(jd==null){jd=""}
						var xwdk="<div class='nr_list'><div class='nr_left'>下午打卡时间：</div>"+
						"<div class='nr_rig'>"+jd+"</div></div>";
						var txsj=item.f_titile
            			if(txsj==null){txsj=""}
						var sgjd="<div class='nr_list'><div class='nr_left'>打卡人职位：</div>"+
						"<div class='nr_rig'>"+txsj+"</div></div>";
						var hbnr=item.f_class
            			if(hbnr==null){hbnr=""}
						var hb="<div class='nr_list'><div class='nr_left'>打卡人班级：</div>"+
						"<div class='nr_rig'>"+hbnr+"</div></div>";
						var xyjh=item.f_projectname
            			if(xyjh==null){txsj=""}
						var jh="<div class='nr_list'><div class='nr_left'>项目名称：</div>"+
						"<div class='nr_rig'>"+xyjh+"</div></div>";
						var bz=item.project_attencedate
            			if(bz==null){bz=""}
						var tzbz="<div class='nr_list'><div class='nr_left'>考勤日期：</div>"+
						"<div class='nr_rig'>"+txsj+"</div></div>";
						var gz=item.project_attencedatetime
            			if(gz==null){gz=""}
						var sgzy="<div class='nr_list'><div class='nr_left'>考勤时间：</div>"+
						"<div class='nr_rig'>"+gz+"</div></div>";
						var bz=item.f_description
            			if(bz==null){bz=""}
						var kqbz="<div class='nr_list'><div class='nr_left'>备注：</div>"+
						"<div class='nr_rig'>"+bz+"</div></div>";
						$(".lz_list").append("<div class='bus_list' id='"+item.project_attencerecordid+"'>"+xmmc+txmb+txr+xwdk+sgjd+hb+jh+tzbz+sgzy+kqbz+"</div>")
					})
					
					var hei=$(".nr").eq(6).outerHeight();
					$(".tcbj").css("height",hei-vc)
					
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
