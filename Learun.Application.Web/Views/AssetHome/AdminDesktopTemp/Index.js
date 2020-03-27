$(function () {
	
	var dc=$(".fs_li_style").attr("type")
	var bbb=17.5;
	if(dc==3){
		bbb=12
	} else {
		bbb=17.5
	}
	
    var map = new AMap.Map('mapDiv', {
        resizeEnable: true, //是否监控地图容器尺寸变化
        zoom: 12, //初始化地图层级
//      mapStyle: "amap://styles/dark",  //地图风格样式
//      features: ['bg', 'road', 'building'], //地图现实要素
        center: [111.754821, 30.431865], //初始化地图中心点
	    rotateEnable:false,
	    pitchEnable:false,
//	    pitch:65,
//	    rotation:45,
//	    viewMode:'3D',//开启3D视图,默认为关闭
	    expandZoomRange:true
    });
	var markers = [];
	function remo(){
		map.remove(markers)
	}
	function closeInfoWindow() {
	    map.clearInfoWindow();
	}
	
    AMapUI.loadUI(['overlay/SimpleInfoWindow'], function (SimpleInfoWindow) {
        function GetIcon(type) {
            switch (type) {
                case 1: return "/Resource/Img/tudi.png"
                case 2: return "/Resource/Img/tudi2.png"
                case 3: return "/Resource/Img/tudi3.png"
                case 5: return "/Resource/Img/dalo2.png"
                case 6: return "/Resource/Img/dalo3.png"
                case 7: return "/Resource/Img/dalo.png"
                case 9: return "/Resource/Img/ggp.png"
                case 10: return "/Resource/Img/ggp2.png"
                case 11: return "/Resource/Img/ggp3.png"
                default: return ""
            }
        }
        
        var typ;
		$(".lisd").click(function(){
			remo()
//			initMap()
			typ=$(this).attr("type");
        	$(".fs_li").removeClass("fs_li_style")
        	$(this).addClass("fs_li_style")
        	$(".code").val(1);
//      	var position = [116, 39]; 
//      	map.setCenter(position); 
//      	var position = new AMap.LngLat(116, 39);  // 标准写法
			// 简写 var position = [116, 39]; 
//			map.setCenter(position); 
			// 获取地图中心点
//			var currentCenter = map.getCenter(); 
        	if($(".fs_li_style").attr("type")==3){
        		$(".titsp").eq(0).find("span").text("LED户外广告显示屏")
        		$(".titsp").eq(1).find("span").text("港湾式公交站台")
        		$(".titsp").eq(2).find("span").text("小丝公交站台改造")
        		map.setZoomAndCenter(14, [111.754821, 30.431865]);
        	} else {
        		$(".titsp").eq(0).find("span").text("金源")
        		$(".titsp").eq(1).find("span").text("金润源")
        		$(".titsp").eq(2).find("span").text("国资中心")
        		map.setZoomAndCenter(17.5, [111.754821, 30.431865]);
        	}
//      	AMap.moveCamera(CameraUpdateFactory.zoomTo(5))
//      	mpa()
        	closeInfoWindow()
        	$(".sx_inp").val("")
        	ym=1
        	sou()
		})
		
		$("body").delegate(".sou_list", "click", function () {
			var idc=$(this).text().trim()
			$(".sud").val(idc)
			$(".code").val(0)
			
			$(".sou_list").removeClass("sou_active")
			$(this).addClass("sou_active")
			remo()
			mpa()
		})
//      mpa()
        
		function mpa(){
			var tye;
			var typcc=$(".fs_li_style").attr("type")
		    if(typcc==1){
				tye='/LeaderHome/GetHouseList1'
			} else if (typcc==2){
				tye='/LeaderHome/GetLandList1'
			} else if (typcc==3){
				tye='/LeaderHome/BoardList'
			}
			var arr=$(".sud").val()
			var code=$(".code").val()
			typ=$(".fs_li_style").attr("type")
//	        $.post(top.$.rootUrl + '/AssetHome/GetMapMarkers', {type:typ},function (data) {
        	$.post(top.$.rootUrl + tye, {code:code,address:arr},function (data) {//index
	        	console.log(data)
	            $.each(data.data, function (i, v) {
	                var ff = v.colour;
	                if (ff == 4 || ff == 8) {
	                    
	                } else {
	                    ff = ff * 1
	                    var icon = new AMap.Icon({
	                        size: new AMap.Size(50, 50),
	                        // 图标的取图地址
	                        image: GetIcon(ff),
	                        imageSize: new AMap.Size(50, 50)
	                    });
	                    var marker = new AMap.Marker({
	                        map: map,
	                        zIndex: 9999999,
	                        //	                    position: JSON.parse(v.position),
	                        position: JSON.parse(v.point),
	                        icon: icon
	                    });



	                    AMap.event.addListener(marker, 'click', function () {
	                        var df;
	                        if (typ < 3) {
	                            df = v.code
	                        } else {
	                            df = v.name
	                        }
	                        var infoWindow = new SimpleInfoWindow({
	                            infoTitle: '<strong>' + df + '</strong>',
	                            infoBody: '<p id='+v.f_bbiid+' class="my-desc">' + v.address + '</p>',
	                            //基点指向marker的头部位置
	                            offset: new AMap.Pixel(0, -31)
	                        });
	                        infoWindow.open(map, marker.getPosition());
	                        if(typcc==3){
	                        	return false;
	                        }
	                        $(".sud").val(v.point)
	                        
	                        if(typcc==1){
								$(".fidc").val(v.f_bbiid);
							} else if (typcc==2){
								$(".fidc").val(v.f_lbiid);
							}
	                        
	                        var cod=1
	                        $(".tab_left").removeClass("tab_style").eq(0).addClass("tab_style");
	                        fangwu()
//	                        shuju(cod)
	                    });
	                    markers.push(marker);
	                }
	            })
	        }, 'json')
		}
    });
});

$(".tab_title img").click(function(){
	$(".tab_list").hide()
})

$(".tab_left").click(function(){
	$(".tab_left").removeClass("tab_style")
	$(this).addClass("tab_style");
	fangwu()
})

function fangwu(){
	$(".tab_list").show()
	var fidc;
	var typ;
	var typcc=$(".tab_style").attr("type")
    if(typcc==1){
		typ='/LeaderHome/BuildingBase'
		fidc=$(".fidc").val()
	} else if (typcc==2){
		typ='/LeaderHome/Houselist'
		fidc=$(".fwxx").val()
	}
	var nam=$(".sud").val()
    $.ajax({
        url: top.$.rootUrl + typ,
        data: {code:fidc},
        type: "post",
        dataType: "json",
        success: function (data) {
        	console.log(data)
        	if(typcc==1){
        		$(".tab_hlist").remove()
        		$(".tab_one").show()
        		$(".tab_two").hide()
        	} else if(typcc==2){
        		$(".tab_ltwo").remove()
        		$(".tab_one").hide()
        		$(".tab_two").show()
        	}
        	
        	$.each(data.data, function(index, item) {
        		$(".fwxx").val(item.f_bbiid);
        		if(typcc==1){
        			if(item.f_address==null){
        				var dz="<div class='tab_hlist'>地址：</div>"
        			} else {
        				var dz="<div class='tab_hlist'>地址："+item.f_address+"</div>"
        			}
        			if(item.f_constructionname==null){
        				var jzmc="<div class='tab_hlist'>建筑名称：</div>"
        			} else {
        				var jzmc="<div class='tab_hlist'>建筑名称："+item.f_constructionname+"</div>"
        			}
        			if(item.f_constructionarea==null){
        				var jzmj="<div class='tab_hlist'>建筑面积：</div>"
        			} else {
        				var jzmj="<div class='tab_hlist'>建筑面积："+item.f_constructionarea+"</div>"
        			}
        			if(item.f_availableyears==null){
        				var synx="<div class='tab_hlist'>使用年限：</div>"
        			} else {
        				var synx="<div class='tab_hlist'>使用年限："+item.f_availableyears+"</div>"
        			}
        			if(item.f_usagearea==null){
        				var symj="<div class='tab_hlist'>使用面积：</div>"
        			} else {
        				var symj="<div class='tab_hlist'>使用面积："+item.f_usagearea+"</div>"
        			}
        			if(item.f_coverarea==null){
        				var zdmj="<div class='tab_hlist'>占地面积：</div>"
        			} else {
        				var zdmj="<div class='tab_hlist'>占地面积："+item.f_coverarea+"</div>"
        			}
        			if(item.f_formerunit==null){
        				var gldw="<div class='tab_hlist'>原管理单位：</div>"
        			} else {
        				var gldw="<div class='tab_hlist'>原管理单位："+item.f_formerunit+"</div>"
        			}
        			if(item.f_buildingvalue==null){
        				var rzjz="<div class='tab_hlist'>入账价值：</div>"
        			} else {
        				var rzjz="<div class='tab_hlist'>入账价值："+item.f_buildingvalue+"</div>"
        			}
        			var html=dz+jzmc+jzmj+synx+symj+zdmj+gldw+rzjz;
        			$(".tab_one").append(html)
        		} else {
        			var html="<div class='tab_ltwo' id='"+item.f_houseid+"'>"+item.f_housename+"</div>"
        			$(".tab_two_left").append(html)
        		}
            })
        }
    });
}

$("body").delegate(".tab_ltwo", "click", function () {
	var idcd=$(this).attr("id")
	fwxx(idcd)
})

function fwxx(idcd){
	$.ajax({
//      url: top.$.rootUrl + '/LeaderHome/HouseRentIncome',
        url: top.$.rootUrl + '/LeaderHome/House',
        data: {code:idcd},
        type: "post",
        dataType: "json",
        
        success: function (data) {
        	console.log(data)
        	$(".tab_two_right .tab_ltwo").remove()
        	$.each(data.data, function(index, item) {
        		
        		if(item.f_certificateno==null){
        			var dz="<div class='tab_ltwo'>房产证号：</div>"
        		} else {
        			var dz="<div class='tab_ltwo'>房产证号："+item.f_certificateno+"</div>"
        		}
        		if(item.f_powerowner==null){
        			var jzmc="<div class='tab_ltwo'>房屋用途：</div>"
        		} else {
        			var jzmc="<div class='tab_ltwo'>房屋用途："+item.f_powerowner+"</div>"
        		}
    			if(item.f_powerowner==null){
    				var jzmj="<div class='tab_ltwo'>权力人：</div>"
    			} else {
    				var jzmj="<div class='tab_ltwo'>权力人："+item.f_powerowner+"</div>"
    			}
    			if(item.f_situation==null){
    				var synx="<div class='tab_ltwo'>共有情况：</div>"
    			} else {
    				var synx="<div class='tab_ltwo'>共有情况："+item.f_situation+"</div>"
    			}
    			if(item.f_address==null){
    				var symj="<div class='tab_ltwo'>坐落地址：</div>"
    			} else {
    				var symj="<div class='tab_ltwo'>坐落地址："+item.f_address+"</div>"
    			}
    			if(item.f_powenervous==null){
    				var zdmj="<div class='tab_ltwo'>权力性质：</div>"
    			} else {
    				var zdmj="<div class='tab_ltwo'>权力性质："+item.f_powenervous+"</div>"
    			}
    			if(item.f_utilizeage==null){
    				var gldw="<div class='tab_ltwo'>使用年限：</div>"
    			} else {
    				var gldw="<div class='tab_ltwo'>使用年限："+item.f_utilizeage+"</div>"
    			}
    			
    			var html=dz+jzmc+jzmj+synx+symj+zdmj+gldw;
    			$(".tab_two_right").append(html)
            })
        }
    });
}

sou()


	var ym=1
	$(".xs_sou img").click(function(){
		ym=1
		sou()
	})
//	$(".esd").click(function(){
//		var src=$(this).find("embed").attr("src")
//		var html="<embed class='ebcd' align='center' src='"+src+"'  type='application/x-shockwave-flash' wmode='transparent' quality='high' ;> </embed>"
//	    $(".xsp").append(html)
//	})
	function sou(){
		var sx_inp=$(".sx_inp").val()
		var typ;
		var typcc=$(".fs_li_style").attr("type")
	    if(typcc==1){
			typ='/LeaderHome/GetHouseList'
		} else if (typcc==2){
			typ='/LeaderHome/GetLandList'
		} else if (typcc==3){
			typ='/LeaderHome/GetAdBoardList'
		}
		if(ym==0){
			ym=1
		}
		$.ajax({
	        url: top.$.rootUrl + typ,
	        data: {
	        	type:1,
	        	index:ym,
	        	name:sx_inp
	        },
	        type: "post",
	        dataType: "json",
	        success: function (data) {
	        	if(data.data.length==0){
	            	ym--
	            } else {
		        	$(".sou_list").remove()
		        	$(".kz").val(0)
		        	console.log(data)
		        	var bc=0
		            $.each(data.data, function(index, item) {
		            	var point=data.data[bc].point;
		            	if(typcc==1){
		            	    var name = data.data[bc].f_transferor; //名字
		            	}
		            	if(typcc==2){
		            		var name=data.data[bc].address; //名字
		            	}
		            	if(typcc==3){
		            		var name=data.data[bc].name; //名字
		            	}  
	            		var html="<div class='sou_list' id="+point+">"+name+"</div>"
	            		$(".xsp_nr").append(html)
		            	bc++
		            })
	           }
	           $(".sxp_ym").text(ym)
	        }
	    });
	}





	$(".shaye").click(function(){
		var kz=$(".kz").val();
		if(ym!=0){
			ym--
			sou()
		}
	})
	$(".xiaye").click(function(){
		var kz=$(".kz").val();
		ym++
		sou()
	})
	
	

function shuju(cod){
	var typ;
	var typcc=$(".fs_li_style").attr("type")
    if(typcc==1){
		typ='/LeaderHome/GetHouseList'
	} else if (typcc==2){
		typ='/LeaderHome/GetLandList'
	} else if (typcc==3){
		typ='/LeaderHome/GetAdBoardList'
	}
	var nam=$(".sud").val()
    $.ajax({
        url: top.$.rootUrl + typ,
        data: {code:cod,
        	   
        },
        type: "post",
        dataType: "json",
        success: function (data) {
        	console.log(data)
			var bc=0;
            $.each(data.data, function(index, item) {
            	var address=data.data[bc].address; //地名
            	var name=data.data[bc].areaname;  // 名称
            	var position=data.data[bc].point;  //坐标
            	var code=data.data[bc].code;  //资产编号
            	var cz="<p>资产编号："+code+"</p>";
    			var qy="<p>行政区划："+name+"</p>";
    			var dz="<p>地址："+address+"</p>";
            	if(nam==position){
            		$(".xs_list").find("p").remove()
            		if(typcc==1){
            			var rentage=data.data[bc].rentage;  //出让年限
            			var area=data.data[bc].area;  //面积
            			var useby=data.data[bc].useby;  //使用权类型
            			var price=data.data[bc].price;  //出让金额
            			var state=data.data[bc].state;  //状态
            			var syq="<p>使用权类型："+useby+"</p>";
            			var cr="<p>出让年限："+rentage+"</p>";
            			var mj="<p>面积："+area+"</p>";
            			var je="<p>出让金额："+price+"</p>";
            			var state="<p>状态："+state+"</p>";
            			$(".xs_list").append(cz+qy+dz+syq+cr+mj+je+state)
            		}
            		if(typcc==2){
            			var useright=data.data[bc].useright;  //房屋用途分类
            			var transferage=data.data[bc].transferage;  //招租年限
            			var area=data.data[bc].area;  //面积
            			var state=data.data[bc].state;  //租赁状态
            			var transferamount=data.data[bc].transferamount;  //当前租金
            			var useright="<p>房屋用途分类："+useright+"</p>";
            			var transferage="<p>招租年限："+transferage+"</p>";
            			var area="<p>面积："+area+"</p>";
            			var state="<p>租赁状态："+state+"</p>";
            			var transferamount="<p>当前租金："+transferamount+"</p>";
            			$(".xs_list").append(cz+qy+dz+useright+transferage+area+state+transferamount)
            		}
            		if(typcc==3){
            			var name=data.data[bc].name;  //广告牌名
            			var price=data.data[bc].price;  //当前租金
            			var rentstate=data.data[bc].rentstate;  //租赁状态
            			var usestate=data.data[bc].usestate;  //使用状态
            			var name="<p>广告牌名："+name+"</p>";
            			var price="<p>当前租金："+price+"</p>";
            			var rentstate="<p>租赁状态："+rentstate+"</p>";
            			var usestate="<p>使用状态："+usestate+"</p>";
            			$(".xs_list").append(cz+qy+dz+name+price+rentstate+usestate)
            		}
            	}
            	bc++
            })
        }
    });
}


//默认选择一条信息
dcud()
function dcud(){
	$.ajax({
        url: top.$.rootUrl + '/LeaderHome/GetHouseList',
        data: {},
        type: "post",
        dataType: "json",
        success: function (data) {
			var bc=0;
            $.each(data.data, function(index, item) {
            	var address=data.data[bc].address; //地名
            	var name=data.data[bc].areaname;  // 名称
            	var position=data.data[bc].point;  //坐标
            	var code=data.data[bc].code;  //资产编号
            	var sub=position.substring(1,position.length-1);
            	var sdc=sub+","+200;
            	var cz="<p>资产编号："+code+"</p>";
    			var qy="<p>行政区划："+name+"</p>";
    			var dz="<p>地址："+address+"</p>";
    			var rentage=data.data[bc].rentage;  //出让年限
    			var area=data.data[bc].area;  //面积
    			var useby=data.data[bc].useby;  //使用权类型
    			var price=data.data[bc].price;  //出让金额
    			var state=data.data[bc].state;  //状态
    			var syq="<p>使用权类型："+useby+"</p>";
    			var cr="<p>出让年限："+rentage+"</p>";
    			var mj="<p>面积："+area+"</p>";
    			var je="<p>出让金额："+price+"</p>";
    			var state="<p>状态："+state+"</p>";
    			$(".xs_list").append(cz+qy+dz+syq+cr+mj+je+state)
        		return false;
            	bc++
            })
        }
    });
}


//待办任务
var Pagination =
{
    rows: 5, page: 1, sidx: "F_CreateDate DESC", sord: "Asc", records: 0, total: 0
};

var param = {
    pagination: JSON.stringify(Pagination),
    categoryId: "1"
};


//待办任务显示
function Dealshow() {
    top.learun.httpAsync('GET', top.$.rootUrl + '/LR_NewWorkFlow/NWFProcess/GetTaskPageList', param, function (data) {
        if (data) {
            if (data.rows.length > 0) {
                console.log(data);
                $("#TaskList").empty();
                $.each(data.rows, function (index, item) {
                    $("#TaskList").append("<div class='lr-msg-line'> <a style='text-decoration: none;'>" + item.F_Title + "</a> <label>" + item.F_CreateDate.substring(0, 10) + "</label></div>");
                })
            }
        } else {

            console.log("error");

        }
    });
}


//新闻部分
var Pagination1 =
    { rows: 5, page: 1, sidx: "", sord: "", records: 0, total: 0 };

var param1 = {
    pagination: JSON.stringify(Pagination),

};

//新闻查看
function ShowNewDetail(key) {

    top.learun.layerForm({
        id: 'Form',
        title: '新闻查看',
        url: top.$.rootUrl + '/LR_OAModule/News/ShowDetail?key=' + key,
        width: 700,
        height: 800,
        btn: null,
        callBack: function (id) {
            return false;
        }
    });


}


//新闻任务显示
function Newshow() {
    $.post(top.$.rootUrl + '/LR_OAModule/News/GetPageListByCategory', { typeid: 1 }, function (data) {
        var dom = $('#NewList')
        var len = dom.tabs('tabs').length
        if (len) {
            for (var i = 0; i < len; i++) {
                dom.tabs('close', 0)
            }
        }
        for (cate in data) {
            var _html = ''
            for (var i = 0; i < data[cate].length; i++) {
                var item = data[cate][i]
                _html += "<section  fid='" + item.F_NewsId + "' class='lr-msg-line' onclick='ShowNewDetail(\"" + item.F_NewsId + "\")' > <a style='text-decoration: none;'>" + item.F_FullHead + "</a> <label>" + item.F_Category.substring(0, 10) + "</label></section>"
            }

            dom.tabs('add', {
                id: item.F_NewsId,
                title: cate,
                selected: false,
                content: _html
            }).tabs('select', 0)
        }

    }, 'json')
}

function renderFirstChart() {
    $.get(top.$.rootUrl + '/AssetManager/DC_ASSETS_LandBaseInfo/StatisticsLandInfo', function (res) {
        if (res.code == 200) {
            var myChart = echarts.init(document.getElementById('firstChart'));

            // 指定图表的配置项和数据
            var option = {
                title: {
                    text: '土地分类统计',
                    x: 'center'
                },
                tooltip: {
                    trigger: 'item',
                    formatter: "{a} <br/>{b} : {c} ({d}%)"
                },
                legend: {
                    orient: 'vertical',
                    left: 'left',
                    data: res.data.map(function (x) { return x.name })
                },
                series: [
                    {
                        name: '使用性质',
                        type: 'pie',
                        radius: '55%',
                        center: ['50%', '60%'],
                        data: res.data,
                        itemStyle: {
                            emphasis: {
                                shadowBlur: 10,
                                shadowOffsetX: 0,
                                shadowColor: 'rgba(0, 0, 0, 0.5)'
                            }
                        }
                    }
                ]
            };


            // 使用刚指定的配置项和数据显示图表。
            myChart.setOption(option);
        } else {
            learun.alert.warning(res.info)
        }
    }, 'json')
}
function renderSecondChart() {

    $.get(top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentMain/StatisticsRentInfo', function (res) {
        if (res.code == 200) {
            var myChart = echarts.init(document.getElementById('secondChart'));

            // 指定图表的配置项和数据
            var option = {
                title: {
                    text: '房屋租赁统计',
                    x: 'center'
                },
                color: ['#3398DB'],
                tooltip: {
                    trigger: 'axis',
                    axisPointer: {            // 坐标轴指示器，坐标轴触发有效
                        type: 'shadow'        // 默认为直线，可选为：'line' | 'shadow'
                    }
                },
                grid: {
                    left: '3%',
                    right: '4%',
                    bottom: '3%',
                    containLabel: true
                },
                xAxis: [
                    {
                        type: 'category',
                        data: res.data.map(function (x) { return x.name }),
                        axisTick: {
                            alignWithLabel: true
                        }
                    }
                ],
                yAxis: [
                    {
                        type: 'value'
                    }
                ],
                series: [
                    {
                        name: '租赁次数',
                        type: 'bar',
                        barWidth: '60%',
                        data: res.data
                    }
                ]
            };



            // 使用刚指定的配置项和数据显示图表。
            myChart.setOption(option);
        } else {
            learun.alert.warning(res.info)
        }
    }, 'json')
}

//公告显示
function Noticeshow() {
    //top.learun.httpAsync('GET', top.$.rootUrl + '/LR_OAModule/Notice/GetPageList', param1, function (data) {
    //    if (data) {

    //        if (data.rows.length > 0) {
    //            $("#NoticeList").empty();
    //            $.each(data.rows, function (index, item) {
    //                $("#NoticeList").append("<div class='lr-msg-line' onclick='ShowNewDetail(\"" + item.F_NewsId + "\")'> <a style='text-decoration: none;'>" + item.F_FullHead + "</a> <label>" + item.F_ReleaseTime.substring(0, 10) + "</label></div>");
    //            })
    //        }

    //    } else {

    //        console.log("error");

    //    }
    //})
    $.post(top.$.rootUrl + '/LR_OAModule/News/GetPageListByCategory', { typeid: 2 }, function (data) {
        var dom = $('#NoticeList')
        var len = dom.tabs('tabs').length
        if (len) {
            for (var i = 0; i < len; i++) {
                dom.tabs('close', 0)
            }
        }
        for (cate in data) {
            var _html = ''
            for (var i = 0; i < data[cate].length; i++) {
                var item = data[cate][i]
                _html += "<section  fid='" + item.F_NewsId + "' class='lr-msg-line' onclick='ShowNewDetail(\"" + item.F_NewsId + "\")' > <a style='text-decoration: none;'>" + item.F_FullHead + "</a> <label>" + item.F_Category.substring(0, 10) + "</label></section>"
            }

            dom.tabs('add', {
                id: item.F_NewsId,
                title: cate,
                selected: false,
                content: _html
            }).tabs('select', 0)
        }

    }, 'json')
}





