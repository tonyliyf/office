﻿/*页面js模板,必须有init方法*/
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
        	
        	tdxx() //占用土地信息（饼图）
        	function tdxx(){
        		learun.httpget(config.webapi + 'learun/adms/AssetManager/AssetManagerInfoApi/LandInfo', {}, function(data) {
					console.log(data)
//					option.legend.data = data.categoryList
					var names=[];//定义两个数组
			        var nums=[];
					$.each(data, function (index, item) {
			            var obj = new Object();
			            obj.name = item.f_assignee;
			            obj.value = item.number;
			            nums.push(obj);
					})
					
					option = {
					
					series: [{
							name: '访问来源',
							type: 'pie',
							radius: '55%',
							center: ['50%', '40%'],
							data: nums,
							
							itemStyle: {
								emphasis: {
									shadowBlur: 10,
									shadowOffsetX: 0,
									shadowColor: 'rgba(0, 0, 0, 0.5)'
								}
							},
							label:{            //饼图图形上的文本标签
			                    normal:{
			                        show:true,
			                        position:'inner', //标签的位置
			                        textStyle : {
			                            fontWeight : 300 ,
			                            fontSize : 13    //文字的字体大小
			                        },
			                        formatter:'{b}:{d}%'
			                    }
			                }
						},
				
					]
				};
					
	            myChart.setOption(option)
				});
			}
        	
        	zpg() //招拍挂土地信息（饼图）
        	function zpg(){
        		learun.httpget(config.webapi + 'learun/adms/AssetManager/AssetManagerInfoApi/LandUpInfo', {}, function(data) {
					console.log(data)
//					option.legend.data = data.categoryList
					var names=[];//定义两个数组
			        var nums=[];
					$.each(data, function (index, item) {
			            var obj = new Object();
			            obj.name = item.f_managerdept;
			            obj.value = item.number;
			            nums.push(obj);
					})
					
					option1 = {
						
						series: [{
								name: '访问来源',
								type: 'pie',
								radius: '55%',
								center: ['50%', '40%'],
								data: nums,
								itemStyle: {
									emphasis: {
										shadowBlur: 10,
										shadowOffsetX: 0,
										shadowColor: 'rgba(0, 0, 0, 0.5)'
									}
								},
								label:{            //饼图图形上的文本标签
				                    normal:{
				                        show:true,
				                        position:'inner', //标签的位置
				                        textStyle : {
				                            fontWeight : 300 ,
				                            fontSize : 13    //文字的字体大小
				                        },
				                        formatter:'{b}:{d}%'
				
				                        
				                    }
				                }
							},
					
						]
					
					};
					myChartt.setOption(option1)
				});
			}
        	
        	
        	ggtj() //广告统计信息（饼图）
        	function ggtj(){
        		learun.httpget(config.webapi + 'learun/adms/AssetManager/AssetManagerInfoApi/boardsInfo', {}, function(data) {
					console.log(data)
//					option.legend.data = data.categoryList
					var names=[];//定义两个数组
			        var nums=[];
					$.each(data, function (index, item) {
			            var obj = new Object();
			            obj.name = item.f_billboardscategory;
			            obj.value = item.number;
			            nums.push(obj);
					})
					
					option3 = {
						
						series: [{
								name: '访问来源',
								type: 'pie',
								radius: '55%',
								center: ['50%', '40%'],
								data: nums,
								
								itemStyle: {
									emphasis: {
										shadowBlur: 10,
										shadowOffsetX: 0,
										shadowColor: 'rgba(0, 0, 0, 0.5)'
									}
								},
								label:{            //饼图图形上的文本标签
				                    normal:{
				                        show:true,
				                        position:'inner', //标签的位置
				                        textStyle : {
				                            fontWeight : 300 ,
				                            fontSize : 13    //文字的字体大小
				                        },
				                        formatter:'{b}:{d}%'
				
				                        
				                    }
				                }
							},
					
						]
					
					};
					myCharfor.setOption(option3)
				});
			}
        	
        	
        	
			
			$(".bt_box,.tu_list").hide() //隐藏图表
			$("body").delegate(".box_li", "tap", function () {
				var ths=$(this).attr("type")
				$(".xmgk").hide()
				$(".tu_list").show()
				$(".bt_box").eq(ths).show()
			})
			$("body").delegate(".box_fh", "tap", function () {
				$(".xmgk").show()
				$(".tu_list").hide()
				$(".bt_box").hide()
			})
			myCharthr.setOption(option2)
			
			var ducd;
    		myChart.on('click', function (params) {  //土地统计图
    			$(".nr_type").show()
				var nam=params.name
				ducd=nam
				var drc=document.body.clientHeight;
				$(".tcct_top").show()
				$(".tcbj").show()
				$(".nr").eq(0).show()
				var vc=drc-88;
				$("#mapDiv").css("min-height",vc)
//	        	$(".mac").css("height",vc)
	    		var hei=$(".nr").eq(0).outerHeight();
				$(".tcbj").css("height",hei-vc)
				$(".sxzz").val(1)
				var vd=""
				duf(vd)
			});
			
			myChartt.on('click', function (params) { //招拍挂统计图点击
				$(".nr_one .td_tc").show()
				$(".tpo").hide()
				var nam=params.name
				ducd=nam
				var drc=document.body.clientHeight;
				$(".tcct_top").show()
				$(".tcbj").show()
				$(".nr").eq(0).show()
				var vc=drc-88;
//	        	$(".mac").css("height",vc)
	    		var hei=$(".nr").eq(0).outerHeight();
				$(".tcbj").css("height",hei-vc)
				$(".sxzz").val(2)
				$(".f-scroll",window.parent.document).css("transform","translate3d(0px, 0px, 0px) translateZ(0px)")
				zxqxx(nam) //招拍挂
			});
			myCharthr.on('click', function (params) { //房屋统计点击
				$(".nr_type").show()
				var nam=params.name
				ducd=nam
				var drc=document.body.clientHeight;
				$(".tcct_top").show()
				$(".tcbj").show()
				$(".nr").eq(1).show()
				var vc=drc-88;
				$("#mapDiv").css("min-height",vc)
//	        	$(".mac").css("height",vc)
	    		var hei=$(".nr").eq(0).outerHeight();
				$(".tcbj").css("height",hei-vc)
				var fw=""
				$(".f-scroll",window.parent.document).css("transform","translate3d(0px, 0px, 0px) translateZ(0px)")
				fwtj(fw)//房屋统计
			});
			myCharfor.on('click', function (params) {  //广告统计点击
				$(".nr_type").show()
				var nam=params.name
				ducd=nam
				var drc=document.body.clientHeight;
				$(".tcct_top").show()
				$(".tcbj").show()
				$(".nr").eq(2).show()
				var vc=drc-88;
				$("#mapDiv").css("min-height",vc)
//	        	$(".mac").css("height",vc)
	    		var hei=$(".nr").eq(0).outerHeight();
				$(".tcbj").css("height",hei-vc)
				$(".f-scroll",window.parent.document).css("transform","translate3d(0px, 0px, 0px) translateZ(0px)")
				ggtjxx() //广告统计
			});
//			myCharfive.on('click', function (params) {  //广告招租统计接口
//				$(".nr_type").show()
//				var nam=params.name
//				ducd=nam
//				var drc=document.body.clientHeight;
//				$(".tcct_top").show()
//				$(".tcbj").show()
//				$(".nr").eq(3).show()
//				$(".f-scroll",window.parent.document).css("transform","translate3d(0px, 0px, 0px) translateZ(0px)")
//				var vc=drc-88;
//				$("#mapDiv").css("min-height",vc)
////	        	$(".mac").css("height",vc)
//	    		var hei=$(".nr").eq(0).outerHeight();
//				$(".tcbj").css("height",hei-vc)
//				$(".tcct_top").remove()
//			    var hdc="<div class='tcct_top'><div class='tct_left'>"+
//				"<span class='tcsp' style='position: absolute;z-index: 100;margin-left: 5px;'>"+ducd+"</span>"+
//				"<div class='xlcd'></div></div><div class='tct_rig'><div class='box_rg' style='float: right;'><img class='rg_im' src='images/fanh.png'><span>返回上一页</span></div></div></div>";
//			    $(".f-page-header").prepend(hdc)
//				
//			});
	$("body").delegate(".tct_rig", "tap", function () {		 //关闭信息
		
		var tz=$(".sxzz").val()
		if(tz==2){
			if($(".nr_one").is(':visible')){  //土地/招拍挂关闭信息
				if($(".nr_one .td_tc").is(':visible')){
					$(".tcbj").hide()
					$(".nr").hide()
					$(".tcct_top").hide() //头部
					$(".xlcd").hide()
				}
			}
			$(".sxzz").val(1)
			$(".f-scroll",window.parent.document).css("transform","translate3d(0px, 0px, 0px) translateZ(0px)")
			return false;
		} else if(tz==1){
			
		}
		if($(".nr_one").is(':visible')){  //土地/招拍挂关闭信息
			if($(".nr_one .tpo").is(':visible')){
				$(".tcbj").hide()
				$(".nr").hide()
				$(".tcct_top").hide() //头部
				$(".xlcd").hide()
			} else if($(".nr_one .fw_tc").is(':visible')){
				$(".nr_one .fw_tc").hide()
				$(".nr_one .td_tc").show();
			} else if($(".nr_one .td_tc").is(':visible')){
				$(".nr_one .td_tc").hide()
				$(".tpo ,.fhlb").show();
			} else {
				$(".tcbj").hide()
				$(".nr").hide()
				$(".tcct_top").hide() //头部
				$(".xlcd").hide()
			} 
		}
		
//		if($(".nr_two").is(':visible')){  //房屋统计关闭信息
//			if($(".nr_two .two").is(':visible')){
//				$(".tcbj").hide()
//				$(".nr").hide()
//				$(".tcct_top").hide() //头部
//				$(".xlcd").hide()
//				alert(1)
//			}else if($(".nr_two .fw_tc").is(':visible')){
//				$(".nr_two .fw_tc").hide()
//				$(".nr_two .td_tc").show();
//				alert(2)
//			} else if($(".nr_two .td_tc").is(':visible')){
//				$(".nr_two .td_tc").hide()
//				$(".two,.fhlb").show();
//				alert(3)
//			} else {
//				$(".tcbj").hide()
//				$(".nr").hide()
//				$(".tcct_top").hide()
//				$(".xlcd").hide()
//				alert(4)
//			} 
//		}
		
		if($(".nr_two").is(':visible')){  //房屋统计关闭信息
			if($(".nr_two .two").is(':visible')){
				$(".tcbj").hide()
				$(".nr").hide()
				$(".tcct_top").hide() //头部
				$(".xlcd").hide()
			} else if($(".nr_two .td_tc").is(':visible')){
				$(".nr_two .td_tc").hide()
				$(".two,.fhlb").show();
			} else {
				$(".tcbj").hide()
				$(".nr").hide()
				$(".tcct_top").hide()
				$(".xlcd").hide()
			} 
		}
		
		
		if($(".nr_thr").is(':visible')){  //广告牌信息
			if($(".nr_thr .thr").is(':visible')){
				$(".tcbj").hide()
				$(".nr").hide()
				$(".tcct_top").hide() //头部
				$(".xlcd").hide()
			} else if($(".nr_thr .fw_tc").is(':visible')){
				$(".nr_thr .fw_tc").hide()
				$(".nr_thr .td_tc").show();
			} else if($(".nr_thr .td_tc").is(':visible')){
				$(".nr_thr .td_tc").hide()
				$(".thr ,.fhlb").show();
			} else {
				$(".nr_thr .td_tc").hide()
				$(".thr ,.fhlb").show();
			} 
		}
		
		if($(".nr_for").is(':visible')){  //
			if($(".nr_for .for").is(':visible')){
				$(".tcbj").hide()
				$(".nr").hide()
				$(".tcct_top").hide() //头部
				$(".xlcd").hide()
			} else if($(".nr_for .fw_tc").is(':visible')){
				$(".nr_for .fw_tc").hide()
				$(".nr_for .td_tc").show();
			} else if($(".nr_for .td_tc").is(':visible')){
				$(".nr_for .td_tc").hide()
				$(".thr ,.fhlb").show();
			} else {
				$(".tcbj").hide()
				$(".nr").hide()
				$(".tcct_top").hide()
				$(".xlcd").hide()
			} 
		}
		$(".f-scroll",window.parent.document).css("transform","translate3d(0px, 0px, 0px) translateZ(0px)")
		 window.setTimeout(function(){fy();}, 1000);
	})
	function duf(sou){  //土地统计
		$(".f-scroll",window.parent.document).css("transform","translate3d(0px, 0px, 0px) translateZ(0px)")
		$(".tcct_top").remove()
		$(".nr_type_list ,.nr_type_listt").remove()
	    var hdc="<div class='tcct_top'><div class='tct_left'>"+
		"<span class='tcsp' style='position: absolute;z-index: 100;margin-left: 5px;'>"+ducd+"</span>"+
		"<div class='xlcd'></div></div><div class='tct_rig'><div class='box_rg' style='float: right;'><img class='rg_im' src='images/fanh.png'><span>返回上一页</span></div></div></div>";
	    $(".f-page-header").prepend(hdc)
	    learun.httpget(config.webapi + 'learun/adms/AssetManager/AssetManagerInfoApi/LandAssigneeList', {F_Assignee:ducd,SearchValue:sou}, function(data) {
	    	console.log(data)
	    	$(".tpo .nr_type_list").remove()
	    	$.each(data, function (index, item) {
	    		var html="<div class='nr_type_list'><span>"+item.f_transferor+"</span><img src='images/yjt.png'></div>"
	    		$(".tpo .bz_tpo").append(html)
	    	})
	    })
	    window.setTimeout(function(){fy();}, 500);
	}
	
	
	
	function zpgxx(){ //招拍挂统计
		$(".f-scroll",window.parent.document).css("transform","translate3d(0px, 0px, 0px) translateZ(0px)")
		$(".tcct_top").remove()
		$(".nr_type_list ,.nr_type_listt").remove()
	    var hdc="<div class='tcct_top'><div class='tct_left'>"+
		"<span class='tcsp' style='position: absolute;z-index: 100;margin-left: 5px;'>"+ducd+"</span>"+
		"<div class='xlcd'></div></div><div class='tct_rig'><div class='box_rg' style='float: right;'><img class='rg_im' src='images/fanh.png'><span>返回上一页</span></div></div></div>";
	    $(".f-page-header").prepend(hdc)
	    learun.httpget(config.webapi + 'learun/adms/AssetManager/AssetManagerInfoApi/LandHandlist', {F_ManagerDept:ducd}, function(data) {
	    	console.log(data)
	    	$(".tpo .nr_type_listt").remove()
	    	$.each(data, function (index, item) {
	    		var html="<div class='nr_type_listt'><span>"+item.number+"</span><img src='images/yjt.png'></div>"
	    		$(".tpo").append(html)
	    	})
	    })
	    window.setTimeout(function(){fy();}, 500);
	}
	
	
	
	
	
	function fwtj(sou){ //房屋统计基础列表
		$(".f-scroll",window.parent.document).css("transform","translate3d(0px, 0px, 0px) translateZ(0px)")
		$(".tcct_top").remove()
		$(".nr_type_list ,.nr_type_listt").remove()
	    var hdc="<div class='tcct_top'><div class='tct_left'>"+
		"<span class='tcsp' style='position: absolute;z-index: 100;margin-left: 5px;'>"+ducd+"</span>"+
		"<div class='xlcd'></div></div><div class='tct_rig'><div class='box_rg' style='float: right;'><img class='rg_im' src='images/fanh.png'><span>返回上一页</span></div></div></div>";
	    $(".f-page-header").prepend(hdc)
	    learun.httpget(config.webapi + 'learun/adms/AssetManager/AssetManagerInfoApi/HouseAssigneeListt', {F_FormerUnit:ducd,SearchValue:sou}, function(data) {
	    	console.log(data)
	    	$(".two .nr_type_list").remove()
	    	$.each(data, function (index, item) {
	    		var html="<div class='nr_type_list'><span>"+item.f_oldunit+"</span><img src='images/yjt.png'></div>"
	    		$(".two").append(html)
	    	})
	    })
	    window.setTimeout(function(){fy();}, 1000);
	}
	
	function ggtjxx(){  //土地统计
		$(".f-scroll",window.parent.document).css("transform","translate3d(0px, 0px, 0px) translateZ(0px)")
		$(".tcct_top").remove()
		$(".nr_type_list ,.nr_type_listt").remove()
	    var hdc="<div class='tcct_top'><div class='tct_left'>"+
		"<span class='tcsp' style='position: absolute;z-index: 100;margin-left: 5px;'>广告牌类型</span>"+
		"<div class='xlcd'></div></div><div class='tct_rig'><div class='box_rg' style='float: right;'><img class='rg_im' src='images/fanh.png'><span>返回上一页</span></div></div></div>";
	    $(".f-page-header").prepend(hdc)
	    learun.httpget(config.webapi + 'learun/adms/AssetManager/AssetManagerInfoApi/HouseboardsList', {}, function(data) {
	    	console.log(data)
	    	$(".thr .nr_type_list").remove()
	    	$.each(data, function (index, item) {
	    		var html="<div class='nr_type_list'><span>"+item.f_billboardscategory+"</span><img src='images/yjt.png'></div>"
	    		$(".thr").append(html)
	    	})
	    })
	    window.setTimeout(function(){fy();}, 500);
	}
	
	
	
	
	
	$("body").delegate(".xm_xz", "tap", function () {
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
    $('body').delegate('.xm_yl', 'tap', function () {
	 	var idc=$(this).parents(".nr_an").attr("id")
//	 	$(".tcct_top").hide()
        learun.nav.go({ path: 'workspace2/imglist', title: "图片预览", type: 'right', param: { processId: idc } });
    })
    
    
    $("body").delegate(".tpo .nr_type_list", "tap", function () {   //土地统计搜索
    	$(".nr_one .td_tc").show();
		$(".nr_one .nr_type").hide()
		var th=$(this).find("span").text()
		$(".ydw").val(th)
		var so=$(".sou").val()
		$(".nr_one .nr_sou").show();
		learun.httpget(config.webapi + 'learun/adms/AssetManager/AssetManagerInfoApi/LandAssigneeSearch', {F_Assignee:ducd,SearchValue:th}, function(data) {
	    	console.log(data)
	    	$(".nr_one .td_tc .nr_box").remove()
	    	$.each(data, function (index, item) {
	    		var fw=item.f_houseid
	    		if(fw==null){fw="无"} else if(fw="点击查看")
	    		var bz=item.f_remarks
	    		if(bz==null){bz=""}
	    		var jz=item.f_transferamount
	    		if(jz==null){jz=""}
	    		
	    		if(item.f_pictureaccessories==null||item.f_pictureaccessories==""){
	    			var chsc="<div class='nr_list'><div class='nr_left'>图片附件：</div>"+
				    "<div class='nr_rig'></div></div>";
	    		} else {
		    		var chsc="<div class='nr_list'><div class='nr_left'>图片附件：</div>"+
				    "<div class='nr_rig'><div class='nr_an' id='"+item.f_pictureaccessories+"'><div class='xm_yl'>图片预览</div></div></div></div>";
	    		}
	    		
	    		if(item.f_contractaccessories==null||item.f_contractaccessories==""){
	    			var wdfj="<div class='nr_list'><div class='nr_left'>文档附件：</div>"+
				    "<div class='nr_rig'></div></div>";
	    		} else {
		    		var wdfj="<div class='nr_list'><div class='nr_left'>文档附件：</div>"+
				    "<div class='nr_rig'><div class='nr_an'><div id='"+item.f_contractaccessories+"' class='xm_xz'>附件下载</div></div></div></div>";
	    		}
	    		
	    		var html="<div class='nr_box'><div class='nr_list'><div class='nr_left'>原单位</div>"+
				"<div class='nr_rig'>"+item.f_transferor+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>土地名称</div>"+
				"<div class='nr_rig'>"+item.f_landname+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>土地坐落</div>"+
				"<div class='nr_rig'>"+item.f_parceladdress+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>受让人</div>"+
				"<div class='nr_rig'>"+item.f_assignee+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>权属证号</div>"+
				"<div class='nr_rig'>"+item.f_landcertificate+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>面积（m²）</div>"+
				"<div class='nr_rig'>"+item.f_area+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>账面价值（元）</div>"+
				"<div class='nr_rig'>"+jz+"</div></div>"+chsc+wdfj+"<div class='nr_list'>"+
				"<div class='nr_left'>备注</div>"+
				"<div class='nr_rig'>"+bz+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>房屋信息</div>"+
				"<div class='nr_rig fwck' id='"+item.f_houseid+"'>"+fw+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>坐落位置</div>"+
				"<div class='nr_rig djdt' sj='1' type='0' id='"+item.f_centerpointcoordinates+"'>点击查看</div></div></div>";
	    		$(".nr_one .td_tc").append(html)
	    	})
	    })
		
		window.setTimeout(function(){fy();}, 500);
	})
    sd()
    function sd(){
	    learun.httpget(config.webapi + 'learun/adms/AssetManager/AssetManagerInfoApi/GetHouseHistroyRentInfo', {F_Assignee:ducd}, function(data) {
			console.log(data)
	    	$(".nd").remove()
	    	$.each(data, function (index, item) {
	    		if(item.F_RentYear==2017){
	    			
	    			var html="<div class='nr_sg_listct nd' id='"+item.F_HRMId+"'><img src='images/wjj.png'><br><span>"+item.F_RentName+"</span></div>"
	    			$(".sg_nr .bt_list .nd_list").eq(0).append(html)
	    		} else if(item.F_RentYear==2018){
	    			var html="<div class='nr_sg_listct nd' id='"+item.F_HRMId+"'><img src='images/wjj.png'><br><span>"+item.F_RentName+"</span></div>"
	    			$(".sg_nr .bt_list .nd_list").eq(1).append(html)
	    		} else if(item.F_RentYear==2019){
	    			var html="<div class='nr_sg_listct nd' id='"+item.F_HRMId+"'><img src='images/wjj.png'><br><span>"+item.F_RentName+"</span></div>"
	    			$(".sg_nr .bt_list .nd_list").eq(2).append(html)
	    		}
	    	})
	    	
	   		window.setTimeout(function(){fy();}, 500);
		})
    }
    $('body').delegate('.nd', 'tap', function () {  //招租详细信息
    	var ducd=$(this).find("span").text()
    	var pid=$(this).attr("id")
    	$(".tcct_top").remove()
    	learun.httpget(config.webapi + 'learun/adms/AssetManager/AssetManagerInfoApi/GetHouseHistroyRentDetailInfo', {keyValue:pid,SearchValue:""}, function(data) {
			console.log(data)
	    	$(".sg_bot .nr_box").remove()
	    	$(".sg_nr").hide()
	    	$(".fhlb").hide()
	    	var hdc="<div class='tcct_top'><div class='tct_left'>"+
			"<span class='tcsp' style='position: absolute;z-index: 100;margin-left: 5px;'>"+ducd+"</span>"+
			"<div class='xlcd'></div></div><div class='tct_rigc'><div class='box_rg' style='float: right;'><img class='rg_im' src='images/fanh.png'><span>返回上一页</span></div></div></div>";
		    $(".f-page-header").prepend(hdc)
	    	$.each(data, function (index, item) {
	    		if(item.F_LeaseState==2){
	    			var zt="成功"
	    		} else {
	    			var zt="失败"
	    		}
	    		
	    		if(item.F_RentContractNo==null){ var zlht=""}else{ var zlht=item.F_RentContractNo}
	    		if(item.F_RenterPhone==null){ var zldh=""}else{ var zldh=item.F_RenterPhone}
	    		if(item.F_Location==null){var zwz=""}else{var zwz=item.F_Location}
	    		
	    		if(item.F_DetailFiles==null||item.F_DetailFiles==""){
	    			var htfj="<div class='nr_list'><div class='nr_left'>合同附件</div>"+
					"<div class='nr_rig'></div></div>";
	    		} else {
		    		var htfj="<div class='nr_list'><div class='nr_left'>合同附件</div>"+
					"<div class='nr_rig'><div class='nr_an'><div id='"+item.f_contractaccessories+"' class='xm_xz'>附件下载</div></div></div></div>";
	    		}
	    		var html="<div class='nr_box'><div class='nr_list'><div class='nr_left'>所有权人</div>"+
				"<div class='nr_rig'>"+item.F_FormerUnit+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>招租名称</div>"+
				"<div class='nr_rig'>"+item.F_RentName+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>原单位</div>"+
				"<div class='nr_rig'>"+item.F_Transferor+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>建筑面积</div>"+
				"<div class='nr_rig'>"+item.F_RentArea+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>招租底价</div>"+
				"<div class='nr_rig'>"+item.F_RentReservePrice+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>竞租保证金</div>"+
				"<div class='nr_rig'>"+item.F_RentDeposit+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>坐落位置</div>"+
				"<div class='nr_rig'>"+zwz+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>租赁合同</div>"+
				"<div class='nr_rig'>"+zlht+"</div></div>"+htfj+"<div class='nr_list'>"+
				"<div class='nr_list'><div class='nr_left'>租赁人</div>"+
				"<div class='nr_rig'>"+item.F_Renter+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>租赁人电话</div>"+
				"<div class='nr_rig'>"+zldh+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>租赁状态</div>"+
				"<div class='nr_rig'>"+zt+"</div></div></div>";
	    		$(".sg_bot").append(html)
	    	})
	    	
	   		window.setTimeout(function(){fy();}, 500);
		})
    })
    
    $("body").delegate(".fw_list", "tap", function () {  //房屋租赁
		$(".f-scroll",window.parent.document).css("transform","translate3d(0px, 0px, 0px) translateZ(0px)")
		$(".tcct_top").remove()
		$(".fwzl .nr_sg_listct").remove()
		$(".fwzl").show()
		$(".fwzl_zh,.fwzl_zj").hide()
	    learun.httpget(config.webapi + 'learun/adms/AssetManager/AssetManagerInfoApi/GetMainList', {}, function(data) {
	    	console.log(data)
	    	$.each(data, function (index, item) {
	    		var html="<div class='nr_sg_listct' id='"+item.F_HRMId+"'><img src='images/wjj.png'><br><span>"+item.F_RentName+"</span></div>"
	    		$(".fwzl").append(html)
	    	})
	    })
	    window.setTimeout(function(){fy();}, 1000);
	})
    
     $("body").delegate(".fwzl .nr_sg_listct", "tap", function () {  //房屋租赁详细
     	$(".f-scroll",window.parent.document).css("transform","translate3d(0px, 0px, 0px) translateZ(0px)")
     	var d="";
     	var hdc="<div class='tcct_top'><div class='tct_left'>"+
			"<span class='tcsp' style='position: absolute;z-index: 100;margin-left: 5px;'>房屋租赁</span>"+
			"<div class='xlcd'></div></div><div class='tct_rigc' type='3'><div class='box_rg' style='float: right;'><img class='rg_im' src='images/fanh.png'><span>返回上一页</span></div></div></div>";
	    $(".f-page-header").prepend(hdc)
	    $(".fwzlxx").val($(this).attr("id"))
     	fwzlxx(d)
	})
     
     function fwzlxx(d){ //房屋租赁详细
     	var idc=$(".fwzlxx").val()
     	$(".fhlb").hide()
     	$(".fwzl").hide()
     	$(".fwzl_list").show()
     	$(".fwzl_list .nr_box").remove()
     	learun.httpget(config.webapi + 'learun/adms/AssetManager/AssetManagerInfoApi/GetHouseRentDetailInfo', {keyValue:idc,SearchValue:d}, function(data) {
	    	console.log(data)
	    	$.each(data, function (index, item) {
	    		if(item.F_LeaseState==2){
	    			var zt="成功"
	    		} else {
	    			var zt="失败"
	    		}
	    		if(item.F_RentArea==null){var ear=""}else{var ear=item.F_RentArea}
	    		if(item.F_Renter==null){var ren=""}else{var ren=item.F_Renter}
	    		
	    		if(item.F_RentContractNo==null){ var zlht=""}else{ var zlht=item.F_RentContractNo}
	    		if(item.F_RenterPhone==null){ var zldh=""}else{ var zldh=item.F_RenterPhone}
	    		
	    		if(item.F_DetailFiles==null||item.F_DetailFiles==""){
	    			var htfj="<div class='nr_list'><div class='nr_left'>合同附件</div>"+
					"<div class='nr_rig'></div></div>";
	    		} else {
		    		var htfj="<div class='nr_list'><div class='nr_left'>合同附件</div>"+
					"<div class='nr_rig'><div class='nr_an'><div id='"+item.F_DetailFiles+"' class='xm_xz'>附件下载</div></div></div></div>";
	    		}
	    		var html="<div class='nr_box' id='"+item.F_HRDId+"'><div class='nr_list'><div class='nr_left'>所有权人</div>"+
				"<div class='nr_rig'>"+item.F_FormerUnit+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>招租名称</div>"+
				"<div class='nr_rig'>"+item.F_RentName+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>原单位</div>"+
				"<div class='nr_rig'>"+item.F_Transferor+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>建筑面积</div>"+
				"<div class='nr_rig'>"+ear+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>招租底价(元)</div>"+
				"<div class='nr_rig'>"+item.F_RentReservePrice+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>竞租保证金</div>"+
				"<div class='nr_rig'>"+item.F_RentDeposit+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>坐落位置</div>"+
				"<div class='nr_rig'>"+item.F_Location+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>租赁合同</div>"+
				"<div class='nr_rig'>"+zlht+"</div></div>"+htfj+"<div class='nr_list'>"+
				"<div class='nr_list'><div class='nr_left'>租赁人</div>"+
				"<div class='nr_rig'>"+ren+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>租赁人电话</div>"+
				"<div class='nr_rig'>"+zldh+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>租赁状态</div>"+
				"<div class='nr_rig'>"+zt+"</div></div>"+
				"<div class='nr_list zhxx'><div class='nr_left'>租户信息 </div>"+
				"<div class='nr_rig'>点击查看</div></div>"+
				"<div class='nr_list zjmx'><div class='nr_left'>租金信息</div>"+
				"<div class='nr_rig'>点击查看</div></div></div>";
				$(".fwzl_list").append(html)
	    	})
	    })
	    window.setTimeout(function(){fy();}, 1000);
     }
    
    $("body").delegate(".zhxx", "tap", function () {  //房屋租赁租户信息  
    	$(".f-scroll",window.parent.document).css("transform","translate3d(0px, 0px, 0px) translateZ(0px)")
    	$(".fwzl_list,.fwzl_zj").hide()
    	$(".fwzl_xc,.fwzl_zh").show()
    	var idc=$(this).parents(".nr_box").attr("id")
    	$(".fwzl_zh .nr_box").remove()
     	learun.httpget(config.webapi + 'learun/adms/AssetManager/AssetManagerInfoApi/GetHouseRenterInfo', {keyValue:idc}, function(data) {
	    	console.log(data)
	    	$.each(data, function (index, item) {
	    		
	    		
	    		if(item.F_RenterIDNo==null){var sfz=""}else{var sfz=item.F_RenterIDNo}
	    		if(item.F_Manager==null){var fzr=""}else{var fzr=item.F_Manager}
	    		if(item.F_Remarks==null){var bz=""}else{var bz=item.F_Remarks}
	    		
	    		var html="<div class='nr_box'><div class='nr_list'><div class='nr_left'>租赁人</div>"+
				"<div class='nr_rig'>"+item.F_Renter+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>身份证号</div>"+
				"<div class='nr_rig'>"+sfz+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>联系方式</div>"+
				"<div class='nr_rig'>"+item.F_RenterPhone+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>合同编号</div>"+
				"<div class='nr_rig'>"+item.F_ContractNo+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>租赁价格（元/年）</div>"+
				"<div class='nr_rig'>"+item.F_ActualPrice+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>押金（元/年）</div>"+
				"<div class='nr_rig'>"+item.F_RentDeposit+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>出租面积</div>"+
				"<div class='nr_rig'>"+item.F_RentArea+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>出租年限</div>"+
				"<div class='nr_rig'>"+item.F_RentAge+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>从事业务</div>"+
				"<div class='nr_rig'>"+item.F_DoThings+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>租赁起始日</div>"+
				"<div class='nr_rig'>"+item.F_RentStartTime.substring(0,10)+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>租赁结束日</div>"+
				"<div class='nr_rig'>"+item.F_RentEndTime.substring(0,10)+"</div></div>"+
				"<div class='nr_list zhxx'><div class='nr_left'>押金状态 </div>"+
				"<div class='nr_rig'>"+item.F_RentDepositState+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>负责人 </div>"+
				"<div class='nr_rig'>"+fzr+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>备注</div>"+
				"<div class='nr_rig'>"+bz+"</div></div></div>";
				$(".fwzl_zh").append(html)
	    	})
	    })
	    window.setTimeout(function(){fy();}, 1000);
	})
    
    $("body").delegate(".zjmx", "tap", function () {  //房屋租赁租金信息  
    	$(".fwzl_list,.fwzl_zh").hide()
    	$(".fwzl_xc,.fwzl_zj").show()
    	$(".fwzl_zj .nr_box").remove()
    	var idc=$(this).parents(".nr_box").attr("id")
     	learun.httpget(config.webapi + 'learun/adms/AssetManager/AssetManagerInfoApi/GetHouseRenterIncome', {keyValue:idc}, function(data) {
	    	console.log(data)
	    	$.each(data, function (index, item) {
	    		
	    		if(item.F_Remarks==null){var bz=""}else{var bz=item.F_Remarks}
	    		if(item.F_PlanPayDate==null){var dq=""}else{var dq=item.F_PlanPayDate.substring(0,10)}
	    		if(item.F_PaymentDate==null){var jf=""}else{var jf=item.F_PaymentDate.substring(0,10)}
	    		
	    		var html="<div class='nr_box'><div class='nr_list'><div class='nr_left'>租赁人</div>"+
				"<div class='nr_rig'>"+item.F_Renter+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>合同编号</div>"+
				"<div class='nr_rig'>"+item.F_ContractNumber+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>应缴金额</div>"+
				"<div class='nr_rig'>"+item.F_PlanPrice+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>到期时间</div>"+
				"<div class='nr_rig'>"+dq+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>实缴金额</div>"+
				"<div class='nr_rig'>"+item.F_ActualPrice+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>缴费日期</div>"+
				"<div class='nr_rig'>"+jf+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>备注</div>"+
				"<div class='nr_rig'>"+bz+"</div></div></div>";
				$(".fwzl_zj").append(html)
	    	})
	    })
	    window.setTimeout(function(){fy();}, 1000);
	})
    
     $('body').delegate('.tdcl', 'tap', function () { //粮食土地点击
     	var d="";
     	var hdc="<div class='tcct_top'><div class='tct_left'>"+
			"<span class='tcsp' style='position: absolute;z-index: 100;margin-left: 5px;'>粮食土地</span>"+
			"<div class='xlcd'></div></div><div class='tct_rigc' type='1'><div class='box_rg' style='float: right;'><img class='rg_im' src='images/fanh.png'><span>返回上一页</span></div></div></div>";
	    $(".f-page-header").prepend(hdc)
     	lstd(d)
     })
     
     
     
	 function lstd(bnr){
	 	$(".fhlb").hide()
	 	learun.httpget(config.webapi + 'learun/adms/AssetManager/AssetManagerInfoApi/GetLandfoodList', {SearchValue:bnr}, function(data) {
			console.log(data)
	    	$(".lstd .nr_type_list").remove()
	    	$.each(data, function (index, item) {
	    		var html="<div class='nr_type_list'><span>"+item.f_transferor+"</span><img src='images/yjt.png'></div>"
	    		$(".lstd").append(html)
	    	})
	   		window.setTimeout(function(){fy();}, 500);
		})
	 }
    
    $("body").delegate(".lstd .nr_type_list", "tap", function () {
    	var tit=$(this).find("span").text()
    	learun.httpget(config.webapi + 'learun/adms/AssetManager/AssetManagerInfoApi/GetLandfoodInfo', {F_Transferor:tit}, function(data) {
			console.log(data)
			$(".lstd").hide()
	    	$(".lstd_list .nr_box").remove()
	    	$.each(data, function (index, item) {
	    		
	    		if(item.F_PictureAccessories==null||item.F_PictureAccessories==""){
		    		var htfj="<div class='nr_list'><div class='nr_left'>图片附件</div>"+
				    "<div class='nr_rig'></div></div>";
	    		} else {
	    			var htfj="<div class='nr_list'><div class='nr_left'>图片附件</div>"+
				    "<div class='nr_rig'><div class='nr_an' id='"+item.f_pictureaccessories+"'><div class='xm_yl'>图片预览</div></div></div></div>";
	    		}
	    		
	    		if(item.F_Remarks==null){var bz=""} else{var bz=item.F_Remarks}
	    		var html="<div class='nr_box'><div class='nr_list'><div class='nr_left'>所有权人</div>"+
				"<div class='nr_rig'>"+item.F_Assignee+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>原单位</div>"+
				"<div class='nr_rig'>"+item.F_Transferor+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>土地名称</div>"+
				"<div class='nr_rig'>"+item.F_LandName+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>土地坐落</div>"+
				"<div class='nr_rig'>"+item.F_ParcelAddress+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>权属证号</div>"+
				"<div class='nr_rig'>"+item.F_LandCertificate+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>使用面积</div>"+
				"<div class='nr_rig'>"+item.F_Area+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>账面价值（元）</div>"+
				"<div class='nr_rig'>"+item.F_TransferAmount+"</div></div>"+htfj+"<div class='nr_list'>"+
				"<div class='nr_list'><div class='nr_left'>备注</div>"+
				"<div class='nr_rig'>"+bz+"</div></div></div>";
	    		$(".lstd_list").append(html)
	    	})
	   		window.setTimeout(function(){fy();}, 500);
		})
    })
    
    
    $("body").delegate(".fwwx", "tap", function () {  //房屋维修
    	var d="";
     	var hdc="<div class='tcct_top'><div class='tct_left'>"+
			"<span class='tcsp' style='position: absolute;z-index: 100;margin-left: 5px;'>房屋维修</span>"+
			"<div class='xlcd'></div></div><div class='tct_rigc' type='2'><div class='box_rg' style='float: right;'><img class='rg_im' src='images/fanh.png'><span>返回上一页</span></div></div></div>";
	    $(".f-page-header").prepend(hdc)
    	fwwx(d)
    })
    
    function fwwx(bnr){
    	$(".fhlb").hide()
    	learun.httpget(config.webapi + 'learun/adms/AssetManager/AssetManagerInfoApi/GetRepairList', {SearchValue:bnr}, function(data) {
			console.log(data)
	    	$(".wxjl .nr_box").remove()
	    	$.each(data, function (index, item) {
	    		var html="<div class='nr_box'><div class='nr_list'><div class='nr_left'>设备名称</div>"+
				"<div class='nr_rig'>"+item.F_EquipmentName+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>申请用户</div>"+
				"<div class='nr_rig'>"+item.lastname+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>维修金额（元）</div>"+
				"<div class='nr_rig'>"+item.yjwxje+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>申请维修日期</div>"+
				"<div class='nr_rig'>"+item.wxrq+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>故障描述</div>"+
				"<div class='nr_rig'>"+item.gzms+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>维修地点</div>"+
				"<div class='nr_rig'>"+item.wxdd+"</div></div></div>";
	    		$(".wxjl").append(html)
	    	})
	   		window.setTimeout(function(){fy();}, 500);
		})
    }
    
    ggzztj() //广告招租
	function ggzztj(){
		learun.httpget(config.webapi + 'learun/adms/AssetManager/AssetManagerInfoApi/GetBoardMainList', {}, function(data) {
			console.log(data)
			$.each(data, function (index, item) {
	           var html="<div class='nr_sg_listct' id='"+item.F_BSBRMId+"'><img src='images/wjj.png'><br><span>"+item.F_RentName+"</span></div>"
	           $(".ggzz").append(html)
			})
			
		});
	}
    
    $('body').delegate('.ggzz .nr_sg_listct', 'tap', function () { //广告招租点击
     	var d="";
     	var hdc="<div class='tcct_top'><div class='tct_left'>"+
			"<span class='tcsp' style='position: absolute;z-index: 100;margin-left: 5px;'>广告招租</span>"+
			"<div class='xlcd'></div></div><div class='tct_rigc' type='4'><div class='box_rg' style='float: right;'><img class='rg_im' src='images/fanh.png'><span>返回上一页</span></div></div></div>";
	    $(".f-page-header").prepend(hdc)
	    $(".ggzzid").val($(this).attr("id"))
	    $(".ggzz_list").show()
     	ggzzxx(d)
 	})
    
    function ggzzxx(bnr){  //广告招租详细
    	$(".fhlb").hide()
    	var pid=$(".ggzzid").val()
    	learun.httpget(config.webapi + 'learun/adms/AssetManager/AssetManagerInfoApi/GetBoardDetailList', {keyValue:pid,SearchValue:bnr}, function(data) {
			console.log(data)
	    	$(".ggzz_list .nr_box").remove()
	    	$(".ggzz,.fhlb").hide()
	    	$(".ggzz_list").show()
	    	$.each(data, function (index, item) {
	    		
	    		if(item.F_LeaseState==2){var zt="成功"}else{var zt="失败"}
	    		
	    		var html="<div class='nr_box'><div class='nr_list'><div class='nr_left'>广告牌名称</div>"+
				"<div class='nr_rig'>"+item.F_BillboardsName+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>坐落地址</div>"+
				"<div class='nr_rig'>"+item.F_InstallationLocation	+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>租赁人姓名</div>"+
				"<div class='nr_rig'>"+item.F_Renter+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>联系电话</div>"+
				"<div class='nr_rig'>"+item.F_RenterPhone+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>身份证号</div>"+
				"<div class='nr_rig'>"+item.F_RenterIDNo+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>招租底价</div>"+
				"<div class='nr_rig'>"+item.F_RentReservePrice+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>出租年限</div>"+
				"<div class='nr_rig'>"+item.F_RentAge+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>实际价格</div>"+
				"<div class='nr_rig'>"+item.F_ActualPrice+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>租赁状态</div>"+
				"<div class='nr_rig'>"+zt+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>起始日期</div>"+
				"<div class='nr_rig'>"+item.F_RentStartTime.substring(0,10)+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>结束日期</div>"+
				"<div class='nr_rig'>"+item.F_RentStartTime.substring(0,10)+"</div></div></div>";
	    		$(".ggzz_list").append(html)
	    	})
	   		window.setTimeout(function(){fy();}, 500);
		})
    }
    
    $("body").delegate(".tct_rigc", "tap", function () {
    	var tp=$(this).attr("type")
    	if(tp==1){
    		if($(".lstd").is(':hidden')){　　
		    	$(".lstd").show()
			    $(".lstd_list .nr_box").remove()
			}else{
			　 　$(".bt_box").eq(6).hide()
	    		$(".xmgk").show()
	    		$(".tcct_top").remove()
		    	$(".sg_bot .nr_box").remove()
		    	$(".sg_nr").show()
			    $(".fhlb").show()
			}
    		
    	} else if(tp==2){
    		$(".tcct_top").remove()
			$(".bt_box").eq(7).hide()
			$(".xmgk").show()
			$(".fhlb").hide()
    	} else if(tp==3){
    		if($(".fwzl_list").is(':hidden')){
    			$(".fwzl_list").show()
    			$(".fwzl_xc").hide()
    		} else {
    			$(".tcct_top").remove()
    			$(".fwzl_list").hide()
    			$(".fwzl").show()
    			$(".fhlb").show()
    		}
    	} else if(tp==4){
    		if($(".ggzz").is(':hidden')){
    			$(".ggzz").show()
    			$(".ggzz_list").hide()
    			$(".tcct_top").remove()
    			$(".fhlb").show()
    		}
    	} else {
	    	$(".tcct_top").remove()
	    	$(".sg_bot .nr_box").remove()
	    	$(".sg_nr").show()
		    $(".fhlb").show()
    	}
	    $(".f-scroll",window.parent.document).css("transform","translate3d(0px, 0px, 0px) translateZ(0px)")
	     window.setTimeout(function(){fy();}, 1000);
    })
    
    $('body').delegate('.nr_sg_list', 'tap', function () {  //房屋历史招租信息  
    	learun.httpget(config.webapi + 'learun/adms/AssetManager/AssetManagerInfoApi/GetHouseHistroyRentInfo', {F_Assignee:ducd}, function(data) {
    		console.log(data)
	    	$(".thr .nr_type_list").remove()
	    	$.each(data, function (index, item) {
	    		var html="<div class='nr_type_list' id='"+item.F_HRMId+"'><span>"+item.F_RentName+"</span><img src='images/yjt.png'></div>"
	    		$(".bt_list").append(html)
	    	})
	   		window.setTimeout(function(){fy();}, 500);
    	})
    })
    
    
    $("body").delegate(".nr_type_listt", "tap", function () {   //招拍挂搜索
    	$(".nr_one .td_tc").show();
		$(".nr_one .nr_type").hide()
		$(".soutyp").val(2)
		var th=$(this).find("span").text()
		$(".dbtitle").text(th)
		zxqxx()
	})
    
    function zxqxx(nam){   //招拍挂信息
    	$(".f-scroll",window.parent.document).css("transform","translate3d(0px, 0px, 0px) translateZ(0px)")
		$(".tcct_top").remove()
		$(".nr_type_list ,.nr_type_listt").remove()
	    var hdc="<div class='tcct_top'><div class='tct_left'>"+
		"<span class='tcsp' style='position: absolute;z-index: 100;margin-left: 5px;'>"+ducd+"</span>"+
		"<div class='xlcd'></div></div><div class='tct_rig'><div class='box_rg' style='float: right;'><img class='rg_im' src='images/fanh.png'><span>返回上一页</span></div></div></div>";
	    $(".f-page-header").prepend(hdc)
    	
    	var tit=$(".dbtitle").text()
    	var so=$(".sou").val()
		$(".nr_one .nr_sou").show();
		learun.httpget(config.webapi + 'learun/adms/AssetManager/AssetManagerInfoApi/LandHandSearch', {F_Assignee:nam,SearchValue:so}, function(data) {
	    	console.log(data)
	    	$(".nr_one .td_tc .nr_box").remove()
	    	$.each(data, function (index, item) {
	    		var bz=item.f_remarks
	    		if(bz==null){bz==""}
	    		var syq=item.f_landuseright
	    		if(syq==1){syq="出让"}else if(syq==2){syq="划拨"}else if(syq==3){syq="转让"}else if(syq==null){syq=""}
	    		var zpgzt=item.f_state
	    		if(zpgzt==1){zpgzt="需解除合同"} else if(zpgzt==2){zpgzt="已解除合同"}else if(zpgzt==3){zpgzt="已开工和竣工"}else if(zpgzt==4){zpgzt="存量土地"}else if(zpgzt==5){zpgzt="新约定开工时间"}else if(zpgzt==6){zpgzt="抵押"}
	    		var html="<div class='nr_box'><div class='nr_list'><div class='nr_left'>土地证号</div>"+
				"<div class='nr_rig'>"+item.f_landno+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>合同编号</div>"+
				"<div class='nr_rig'>"+item.f_contractno+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>宗地坐落</div>"+
				"<div class='nr_rig'>"+item.f_address+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>土地招拍挂状态</div>"+
				"<div class='nr_rig'>"+zpgzt+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>面积(m²)</div>"+
				"<div class='nr_rig'>"+item.f_area+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>出让金（万元）</div>"+
				"<div class='nr_rig'>"+item.f_totalmoney+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>摘牌单位</div>"+
				"<div class='nr_rig'>"+item.f_managerdept+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>约定开工时间</div>"+
				"<div class='nr_rig'>"+item.f_startdate.substring(0,10)+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>开工到期时间</div>"+
				"<div class='nr_rig'>"+item.f_startenddate.substring(0,10)+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>竣工时间</div>"+
				"<div class='nr_rig'>"+item.f_enddate.substring(0,10)+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>备注</div>"+
				"<div class='nr_rig'>"+bz+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>使用权类型</div>"+
				"<div class='nr_rig'>"+syq+"</div></div></div>";
	    		$(".nr_one .td_tc").append(html)
	    	})
	    })
		window.setTimeout(function(){fy();}, 500);
    }
    
    
    
    $("body").delegate(".two .nr_type_list", "tap", function () {   //点击跳入房屋搜索
    	$(".nr_two .td_tc").show();
		$(".nr_two .nr_type").hide()
		var th=$(this).find("span").text()
		$(".dbtitle").text(th)
		var ths=$(this).find("span").text()
		$(".djcz").val(ths)
		var so=""
		fwss(so)
	})
    
    function fwss(so){   //房屋搜索
    	$(".f-scroll",window.parent.document).css("transform","translate3d(0px, 0px, 0px) translateZ(0px)")
    	var tit=$(".dbtitle").text()
//  	var so=$(".sou").val()
//  	if(so==""){
//  		so=$(".djcz").val()
//  	}
		$(".nr_two .nr_sou").show();
		learun.httpget(config.webapi + 'learun/adms/AssetManager/AssetManagerInfoApi/HouseAssigneeSearch', {F_FormerUnit:tit,SearchValue:so}, function(data) {
	    	console.log(data)
	    	$(".nr_two .td_tc .nr_box").remove()
	    	$.each(data, function (index, item) {
	    		
	    		var bz=item.f_remarks
	    		if(bz==null){bz=""}
	    		
	    		if(item.f_pictureaccessories==null||item.f_pictureaccessories==""){
	    			var chsc="<div class='nr_list'><div class='nr_left'>图片附件：</div>"+
				    "<div class='nr_rig'></div></div>";
	    		} else {
		    		var chsc="<div class='nr_list'><div class='nr_left'>图片附件：</div>"+
				    "<div class='nr_rig'><div class='nr_an' id='"+item.f_pictureaccessories+"'><div class='xm_yl'>图片预览</div></div></div></div>";
	    		}
	    		
	    		if(item.f_floornumber==null){var lcxx=""}else{var lcxx=item.f_floornumber}
	    		
	    		
	    		var html="<div class='nr_box'><div class='nr_list'><div class='nr_left'>原单位</div>"+
				"<div class='nr_rig'>"+item.f_oldunit+"</div></div>"+
//				"<div class='nr_list'><div class='nr_left'>总楼层数</div>"+
//				"<div class='nr_rig'>"+item.f_housefloorcount+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>房屋坐落</div>"+
				"<div class='nr_rig'>"+item.f_address+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>经营性质</div>"+
				"<div class='nr_rig'>"+item.f_buildingclass+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>原管联系人</div>"+
				"<div class='nr_rig'>"+item.f_formerunitcontacts+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>联系人电话</div>"+
				"<div class='nr_rig'>"+item.f_contactsphone+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>房屋名称</div>"+
				"<div class='nr_rig'>"+item.f_housename	+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>所在楼层</div>"+
				"<div class='nr_rig'>"+lcxx+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>房产证号</div>"+
				"<div class='nr_rig'>"+item.f_certificateno+"</div></div>"+chsc+"<div class='nr_list'>"+
				"<div class='nr_left'>资产价值</div>"+
				"<div class='nr_rig'>"+item.f_buildingvalue+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>建筑面积</div>"+
				"<div class='nr_rig'>"+item.f_housearea+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>备注</div>"+
				"<div class='nr_rig'>"+bz+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>坐落位置</div>"+
				"<div class='nr_rig djdt' sj='2' type='1' id='"+item.f_centerpointcoordinates+"'>点击查看</div></div>";
	    		$(".nr_two .td_tc").append(html)
	    	})
	    })
		window.setTimeout(function(){fy();}, 1000);
		$(".sou").val("")
    }
    
    
    
    $("body").delegate(".thr .nr_type_list", "tap", function () {   //点击跳入广告搜索
    	$(".nr_thr .td_tc").show();
		$(".nr_thr .nr_type").hide()
		var th=$(this).find("span").text()
		$(".dbtitle").text(th)
		var ths=$(this).find("span").text()
		$(".djcz").val(ths)
		$(".ggxsz").val(ths)
		var so=""
		ggss(so)
	})
    
    function ggss(so){   //广告搜索
    	var lb=$(".ggxsz").val()
    	$(".f-scroll",window.parent.document).css("transform","translate3d(0px, 0px, 0px) translateZ(0px)")
    	var tit=$(".dbtitle").text()
		$(".nr_thr .nr_sou").show();
		learun.httpget(config.webapi + 'learun/adms/AssetManager/AssetManagerInfoApi/boardsAssigneeSearch', {F_BillboardsCategory:lb,SearchValue:so}, function(data) {
	    	console.log(data)
	    	$(".nr_thr .td_tc .nr_box").remove()
	    	$.each(data, function (index, item) {
	    		var wz=item.F_centerpointcoordinates
	    		if(wz==null){wz="无"}
	    		
	    		var html="<div class='nr_box'><div class='nr_list'><div class='nr_left'>资产编号</div>"+
				"<div class='nr_rig'>"+item.f_billboardsnumber+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>广告牌名称</div>"+
				"<div class='nr_rig'>"+item.f_billboardsname+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>面积（㎡）</div>"+
				"<div class='nr_rig'>"+item.f_specificationtype+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>广告牌类别</div>"+
				"<div class='nr_rig'>"+item.f_billboardscategory+"</div></div>"+
//				"<div class='nr_list'><div class='nr_left'>发布类型和形式</div>"+
//				"<div class='nr_rig'>"+item.f_billboardsidentification+"</div></div>"+
//				"<div class='nr_list'><div class='nr_left'>发布时间</div>"+
//				"<div class='nr_rig'>"+item.f_installationtime+"</div></div>"+
				"<div class='nr_list'><div class='nr_left' id=>位置</div>"+
				"<div class='nr_rig'>"+item.f_installationlocation+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>坐落位置</div>"+
				"<div class='nr_rig djdt' sj='3' type='2' id='"+item.f_centerpointcoordinates+"'>点击查看</div></div></div>";
	    		$(".nr_thr .td_tc").append(html)
	    	})
	    })
		window.setTimeout(function(){fy();}, 500);
		$(".sou").val("")
    }
    
    $("body").delegate(".for .nr_type_listd", "tap", function () {   //点击跳入广告招租搜索
    	$(".nr_for .td_tc").show();
		$(".nr_for .nr_type").hide()
		var th=$(this).find("span").text()
		$(".dbtitle").text(th)
		var ths=$(this).find("span").text()
		$(".djcz").val(ths)
		$(".ggxsz").val(ths)
		boardstj()
	})
    
    function boardstj(){   //广告搜索
    	var lb=$(".ggxsz").val()
    	if(lb=="招租未成功"){lb=0} else if(lb=="招租已成功"){lb=1}
    	$(".f-scroll",window.parent.document).css("transform","translate3d(0px, 0px, 0px) translateZ(0px)")
    	var tit=$(".dbtitle").text()
    	
    	var so=$(".sou").val()
    	if(so==""){
    		so=$(".djcz").val()
    	}
		$(".nr_for .nr_sou").show();
		learun.httpget(config.webapi + 'learun/adms/AssetManager/AssetManagerInfoApi/boardsAssigneeDetail', {State:lb,SearchValue:so}, function(data) {
	    	console.log(data)
	    	$(".nr_for .td_tc .nr_box").remove()
	    	$.each(data, function (index, item) {
	    		var wz=item.f_centerpointcoordinates
	    		if(wz==null){wz="无"}
	    		
	    		var html="<div class='nr_box'><div class='nr_list'><div class='nr_left'>资产编号</div>"+
				"<div class='nr_rig'>"+item.F_BillboardsNumber+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>广告牌名称</div>"+
				"<div class='nr_rig'>"+item.F_BillboardsName+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>面积（㎡）</div>"+
				"<div class='nr_rig'>"+item.F_SpecificationType+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>广告牌类别</div>"+
				"<div class='nr_rig'>"+item.F_BillboardsCategory+"</div></div>"+
//				"<div class='nr_list'><div class='nr_left'>发布类型和形式</div>"+
//				"<div class='nr_rig'>"+item.F_BillboardsIdentification+"</div></div>"+
//				"<div class='nr_list'><div class='nr_left'>发布时间</div>"+
//				"<div class='nr_rig'>"+item.F_InstallationTime+"</div></div>"+
				"<div class='nr_list'><div class='nr_left' id=>位置</div>"+
				"<div class='nr_rig'>"+item.F_InstallationLocation+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>坐落位置</div>"+
				"<div class='nr_rig' id='"+wz+"'>"+wz+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>投放优势</div>"+
				"<div class='nr_rig djdt' type='3'>"+item.F_Remarks+"</div></div></div>";
	    		$(".nr_for .td_tc").append(html)
	    	})
	    })
		window.setTimeout(function(){fy();}, 500);
		$(".sou").val("")
    }
    
    
    function fy(){
    	$(".nr").each(function(){
    		if($(this).is(':hidden')){
    			
    		} else {
    			var dq=$(document.body).height()
		    	var gd=$(this).height()
		    	if(gd>dq){
		    		$(".f-scroll").css("height",gd+250)
		    	} else {
		    		$(".f-scroll").css("min-height",dq)
		    	}
		    	
    		}
    	})
    	var ggd=$(".f-scroll").height()
    	$(".jlcd").val(ggd)
    }
    
    $("body").delegate(".nr_sou_right", "tap", function () {  //点击搜索
    	var ths=$(this).attr("type")
    	var so=$(".soutyp").val()
    	if(ths==1){
    		if(so==2){
	    		var sou=$(this).prev().find(".nr_inp").val()
	    		$(".sou").val(sou)
	    		zxqxx()
	    	} else {
	    		var sou=$(this).prev().find(".nr_inp").val()
	    		if(sou!=""){
	    			tdss(sou)
	    		} else {
	    			var ydw=$("ywd").val()
	    			tdss(ydw)
	    		}
	    	}
    	} else if(ths==2){
    		var sou=$(this).prev().find(".nr_inp").val()
    		if(sou!=""){
    			fwss(sou)
    		} else {
    			var ydw=$("ywd").val()
    			fwss(ydw)
    		}
    	} else if(ths==3){
    		var sou=$(this).prev().find(".nr_inp").val()
    		if(sou!=""){
    			ggss(sou)
    		} else {
    			var ydw=$("ywd").val()
    			ggss(sou)
    		}
    	} else if(ths==4){ //土地1级界面
    		var sou=$(this).prev().find(".nr_inp").val()
    		if(sou!=""){
    			duf(sou)
    		} else {
    			var ydw=$("ywd").val()
    			duf(sou)
    		}
    	} else if(ths==5){ //房屋统计
    		var sou=$(this).prev().find(".nr_inp").val()
    		if(sou!=""){
    			fwtj(sou)
    		} else {
    			var ydw=$("ywd").val()
    			fwtj(sou)
    		}
    	} else if(ths==6){ //土地1级界面
    		var sou=$(this).prev().find(".nr_inp").val()
    		if(sou!=""){
    			lstd(sou)
    		} else {
    			var ydw=$("ywd").val()
    			lstd(sou)
    		}
    	} else if(ths==7){ //土地1级界面
    		var sou=$(this).prev().find(".nr_inp").val()
    		if(sou!=""){
    			fwwx(sou)
    		} else {
    			var ydw=$("ywd").val()
    			fwwx(sou)
    		}
    	} else if(ths==8){
    		var sou=$(this).prev().find(".nr_inp").val()
			fwzlxx(sou)
    	} else if(ths==9){
    		var sou=$(this).prev().find(".nr_inp").val()
			ggzzxx(sou)
    	}
    	
    })
    
    
    $("body").delegate(".fwck", "tap", function () {  //房屋信息
    	
    	var id=$(this).attr("id")
    	var idc=$(this).text()
    	if(idc=="无"){
    		return false;
    	} else if(id!="") {
    		$(".f-scroll",window.parent.document).css("transform","translate3d(0px, 0px, 0px) translateZ(0px)")
	    	$(".td_tc").hide()
	    	$(".fw_tc").show()
	    	learun.httpget(config.webapi + 'learun/adms/AssetManager/AssetManagerInfoApi/DC_ASSETS_HouseInfo', {F_HouseID:id}, function(data) {
		    	console.log(data)
		    	$(".nr_one .fw_tc .nr_box").remove()
		    		var bz=data.F_Remarks
		    		if(bz==null){bz=""}
		    		if(data.F_ConstructionName==null){var jzmc=""}else{var jzmc=data.F_ConstructionName}
		    		if(data.F_HouseFloorCount==null){var zlcs=""}else{var zlcs=data.F_HouseFloorCount}
		    		if(data.F_ConstructionName==null){var jzmc=""}else{var jzmc=data.F_ConstructionName}
		    		
		    		if(data.F_FormerUnit==null){var ssdw=""}else{var ssdw=data.F_FormerUnit}
		    		if(data.F_Oldunit==null){var ydw=""}else{var ydw=data.F_Oldunit}
		    		if(data.F_Address==null){var fwzl=""}else{var fwzl=data.F_Address}
		    		if(data.F_BuildingValue==null){var zcjz=""}else{var zcjz=data.F_BuildingValue}
		    		
		    		if(data.F_ConstructionName==null){var jzmc=""}else{var jzmc=data.F_ConstructionName}
		    		if(data.F_PictureAccessories==null||data.F_PictureAccessories==""){
		    			var chsc="<div class='nr_list'><div class='nr_left'>图片附件：</div>"+
					    "<div class='nr_rig'></div></div>";
		    		} else {
			    		var chsc="<div class='nr_list'><div class='nr_left'>图片附件：</div>"+
					    "<div class='nr_rig'><div class='nr_an' id='"+data.F_PictureAccessories+"'><div class='xm_yl'>图片预览</div></div></div></div>";
		    		}
		    		
		    		
		    		
		    		var html="<div class='nr_box'><div class='nr_list'><div class='nr_left'>建筑名称</div>"+
					"<div class='nr_rig'>"+jzmc+"</div></div>"+
					"<div class='nr_list'><div class='nr_left'>总楼层数</div>"+
					"<div class='nr_rig'>"+zlcs+"</div></div>"+
					"<div class='nr_list'><div class='nr_left'>所属单位</div>"+
					"<div class='nr_rig'>"+ssdw+"</div></div>"+
					"<div class='nr_list'><div class='nr_left'>原单位</div>"+
					"<div class='nr_rig'>"+ydw+"</div></div>"+
					"<div class='nr_list'><div class='nr_left'>房屋坐落</div>"+
					"<div class='nr_rig'>"+fwzl+"</div></div>"+
//					"<div class='nr_list'><div class='nr_left'>房屋坐标</div>"+
//					"<div class='nr_rig'>"+data.btn_area+"</div></div>"+
					"<div class='nr_list'><div class='nr_left'>原管理单位</div>"+
					"<div class='nr_rig'>"+data.F_FormerUnitContacts+"</div></div>"+
					"<div class='nr_list'><div class='nr_left'>联系人电话</div>"+
					"<div class='nr_rig'>"+data.F_ContactsPhone+"</div></div>"+
					"<div class='nr_list'><div class='nr_left'>房屋名称</div>"+
					"<div class='nr_rig'>"+data.F_HouseName+"</div></div>"+
					"<div class='nr_list'><div class='nr_left'>所在楼层数</div>"+
					"<div class='nr_rig'>"+data.F_FloorNumber+"</div></div>"+
					"<div class='nr_list'><div class='nr_left'>房产证号</div>"+
					"<div class='nr_rig'>"+data.F_CertificateNo+"</div></div>"+chsc+"<div class='nr_list'>"+
					"<div class='nr_left'>资产价值</div>"+
					"<div class='nr_rig'>"+zcjz+"</div></div>"+
					"<div class='nr_list'><div class='nr_left'>建筑面积</div>"+
					"<div class='nr_rig'>"+data.F_HouseArea+"</div></div>"+
					"<div class='nr_list'><div class='nr_left'>备注</div>"+
					"<div class='nr_rig'>"+bz+"</div></div></div>";
		    		
		    		$(".nr_one .fw_tc").append(html)
		    })
    	}
    })
    
    function tdss(sou){ //搜索
    	learun.httpget(config.webapi + 'learun/adms/AssetManager/AssetManagerInfoApi/LandAssigneeSearch', {F_Assignee:ducd,SearchValue:sou}, function(data) {
    		console.log(data)
    		$(".nr_one .nr_box").remove()
    		$.each(data, function (index, item) {
    			var fw=item.f_houseid
	    		if(fw==null){fw="无"} else if(fw="点击查看")
	    		var bz=item.f_remarks
	    		if(bz==null){bz=""}
	    		var html="<div class='nr_box'><div class='nr_list'><div class='nr_left'>原单位</div>"+
				"<div class='nr_rig'>"+item.f_transferor+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>土地名称</div>"+
				"<div class='nr_rig'>"+item.f_landname+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>土地坐落</div>"+
				"<div class='nr_rig'>"+item.f_parceladdress+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>受让人</div>"+
				"<div class='nr_rig'>"+item.f_assignee+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>权属证号</div>"+
				"<div class='nr_rig'>"+item.f_landcertificate+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>面积（m²）</div>"+
				"<div class='nr_rig'>"+item.f_area+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>账面价值（元）</div>"+
				"<div class='nr_rig'>"+item.f_transferamount+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>备注</div>"+
				"<div class='nr_rig'>"+bz+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>房屋信息</div>"+
				"<div class='nr_rig fwck' id='"+item.f_houseid+"'>"+fw+"</div></div>"+
				"<div class='nr_list'><div class='nr_left'>坐落位置</div>"+
				"<div class='nr_rig djdt' type='0' id='"+item.f_centerpointcoordinates+"'>点击查看</div></div></div>";
	    		
	    		$(".nr_one .td_tc").append(html)
    		})
    	})
    	$(".soutyp").val(1)
    }
    
    
    $("body").delegate(".zjxx", "tap", function () {  //租金查看
		$(".nr").hide().eq(4).show()
		$(".tcct_top").hide()
		var typ=$(this).attr("type")
    	$(".typc").val(typ)
		var hdc="<div class='tcct_topc'><div class='tct_left'>"+
		"<span class='tcsp' style='position: absolute;z-index: 100;margin-left: 5px;'>租金查看</span>"+
		"<div class='xlcd'></div></div><div class='tct_rigg'><div class='box_rg' style='float: right;'><img class='rg_im' src='images/fanh.png'><span>返回上一页</span></div></div></div>";
	    $(".f-page-header").prepend(hdc)
	})
    
    $("body").delegate(".tct_rigg", "tap", function () {
    	var typc=$(".typc").val()
    	$(".tcct_topc").remove()
    	$(".nr").hide().eq(typc).show()
    	$(".tcct_top").show()
    	$(".f-scroll",window.parent.document).css("transform","translate3d(0px, 0px, 0px) translateZ(0px)")
    	 window.setTimeout(function(){fy();}, 1000);
    })
    
 	$("body").delegate(".mape_gb", "tap", function () {
    	var typc=$(".typc").val()
		$(".tcbj").show()
		$(".nr").eq(typc).show()
		$(".tcct_top").show()
//		$(".xlcd").show()
		$(".tu_list").show()
		$("#mapDiv").hide()
		var cs=$(".jlcd").val()
		$(".f-scroll").css("height",cs)
		$(".mape_gb").remove()
	})
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
                case 1: return "images/tudi.png"
                case 2: return "images/dl.png"
                case 3: return "images/ggp.png"
                default: return ""
            }
        }
        
        $("body").delegate(".djdt", "tap", function () {  //跳转地图
	    	var typ=$(this).attr("type")
	    	$(".typc").val(typ)
			$(".tcbj").hide()
			$(".tcct_top").hide()
			$(".xlcd").hide()
			$(".nr").hide()
			$(".tu_list").hide()
			$("#mapDiv").show()
			$("body").prepend("<div class='mape_gb'>点击关闭</div>")
			$(".mape_gb").show()
			var th=$(this).attr("id")
			var bd=th.substring(1,th.length-1)
			var arr=bd.split(',')
			map.setZoomAndCenter(14, arr);
			console.log(arr)
			$(".mpaa").val(arr)
			$(".f-scroll").css("height","auto")
			var sj=$(this).attr("sj")
			$(".f-scroll",window.parent.document).css("transform","translate3d(0px, 0px, 0px) translateZ(0px)")
			remo()
			window.setTimeout(function(){mpa(th,sj);}, 500);
		})
		function mpa(cd,dz){
//			map.remove(markers);
        	learun.httpget(config.webapi + 'learun/adms/ProjectManager/Dc_EngineProject_info/GetProjectInfo', {}, function(data) {
//	        	console.log(data)
	            $.each(data.data, function (i, v) {
	            	var sj;
	            	if(dz==1){sj=1}else if(dz==2){sj=2}else if(dz==3){sj=3}
	                var icon = new AMap.Icon({
	                    size: new AMap.Size(50, 50),
	                    // 图标的取图地址
	                    image: GetIcon(sj),
	                    imageSize: new AMap.Size(50, 50)
	                });
				
	                console.log(cd)
	                var marker = new AMap.Marker({
                	    map: map,
                	    zIndex: 9999999,
                	    position: JSON.parse(cd),
                	    icon: icon,
                	});
	                AMap.event.addListener(marker, 'tap', function () {
						var infoWindow = new SimpleInfoWindow({
						   infoTitle: '<strong>'+cd+'</strong>',
	                        infoBody: '<p class="my-desc">'+$(".mpaa").val()+'</p>',
	                        //基点指向marker的头部位置
	                        offset: new AMap.Pixel(0, -31)
						});
	                    infoWindow.open(map, marker.getPosition());
	                   
	                });
	                 markers.push(marker);
	                 return false;
	                
	            })
	        }, 'json')
		}
    });
        	
        	
        

        	
        	
        	
        	
//
        
        	
        	
        	
        	
//      	var map = new BMap.Map("mapDiv");
//			var point = new BMap.Point(111.754821, 30.431865);
//			map.centerAndZoom(point, 15); // 编写自定义函数，创建标注   
//			map.enableScrollWheelZoom(true);
			
        	
			
			$(".tcsp").on("tap",function(){
				event.stopPropagation();
				$(".xlcd").show()
				
			})
			
//			$(".xl_li").on("tap",function(){
//				$(".xlcd").hide()
//				var nr=$(this).text();
//				$(".tct_left span").text(nr)
//				var typ=$(this).attr("type");
//				$(".nr").hide().eq(typ).show();
//				var hei=$(".nr").eq(typ).outerHeight();
//				$(".tcbj").css("height",hei-vc)
//			})
			
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
