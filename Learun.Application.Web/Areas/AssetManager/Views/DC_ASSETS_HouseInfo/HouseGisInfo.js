$(function () {
    var map = new AMap.Map('mapDiv', {
        resizeEnable: true, //是否监控地图容器尺寸变化
        zoom: 17.5, //初始化地图层级
//      mapStyle: "amap://styles/dark",  //地图风格样式
//      features: ['bg', 'road', 'building'], //地图现实要素
        center: [111.754821, 30.431865], //初始化地图中心点
        resizeEnable: true,
	    rotateEnable:false,
	    pitchEnable:false,
	    pitch:65,
	    rotation:45,
	    viewMode:'3D',//开启3D视图,默认为关闭
	    expandZoomRange:true
    });
	var roadNetLayer =  new AMap.TileLayer.RoadNet();
	map.add(roadNetLayer);
	var markers = [];
	function remo(){
		map.remove(markers)
	}
    AMapUI.loadUI(['overlay/SimpleInfoWindow'], function (SimpleInfoWindow) {
        function GetIcon(type) {
            switch (type) {
                case 1: return "/Resource/Img/tudi.png"
                case 2: return "/Resource/Img/dalo.png"
                case 3: return "/Resource/Img/ggp.png"
                default: return ""
            }
        }
        
        var typ;
		$(".lisd").click(function(){
			remo()
			typ=$(this).attr("type");
        	$(".fs_li").removeClass("fs_li_style")
        	$(this).addClass("fs_li_style")
        	mpa()
//      	closeInfoWindow()
		})
			
        
        mpd()
        
        function mpd(){
        	
        	$.get(top.$.rootUrl + '/AssetManager/DC_ASSETS_BuildingBaseInfo/GetStreet', {},function (data) {
        		var data = JSON.parse(data);
        		console.log(data)
        		$(".xsp_dl").empty()
        		$.each(data.data, function (i, item) {
        			var html="<div class='dl_list'>"+item.f_street+"</div>"
        			$(".xsp_dl").append(html)
        		})
        	})
        }
        
        $("body").delegate(".dl_list", "click", function () {
        	 $(".daol").val($(this).text().trim())
        	 remo()
        	 mpa()
        });
        
		function mpa(){
			var tye;
			var typcc=$(".fs_li_style").attr("type")
			var dao=$(".daol").val()
		    if(typcc==1){
				tye='/LeaderHome/GetHouseList'
			} else if (typcc==2){
				tye='/LeaderHome/GetLandList'
			} else if (typcc==3){
				tye='/LeaderHome/GetAdBoardList'
			}
			typ=$(".fs_li_style").attr("type")
//	        $.post(top.$.rootUrl + '/AssetHome/GetMapMarkers', {type:typ},function (data) {
        	$.get(top.$.rootUrl + '/AssetManager/DC_ASSETS_BuildingBaseInfo/GetMapList', {Typecode:typcc,Street:dao},function (data) {
	        	console.log(data)
	            $.each(data.data, function (i, v) {
	            	var ff;
	            	if(typcc==1){
	            		ff=1
	            	}
	            	if(typcc==2){
	            		ff=2
	            	}
	            	if(typcc==3){
	            		ff=3
	            	}
	                var icon = new AMap.Icon({
	                    size: new AMap.Size(50, 50),
	                    // 图标的取图地址
	                    image: GetIcon(ff),
	                    imageSize: new AMap.Size(50, 50)
	                });
	                if(v.f_centerpointcoordinates=="[]"){
	                	
	                } else {
		                var marker = new AMap.Marker({
		                    map: map,
		                    zIndex: 9999999,
		                    position: JSON.parse(v.f_centerpointcoordinates),
		                    icon: icon,
		                    offset: new AMap.Pixel(-13, -30)
		                });
		                
		                var nam,titl;
		                if(typcc==1){
		                	nam=v.f_landcertificate;
		                	titl=v.f_sellingprice
		                } else if(typcc==2) {
		                	nam=v.f_housename;
		                	titl=v.f_createuser
		                } else if(typcc==3){
		                	nam=v.name;
		                	titl=v.price
		                }
		                
		                
		                marker.setMap(map);
		                marker.setLabel({
					        offset: new AMap.Pixel(0, -60),  //设置文本标注偏移量
					        content: "<div class='info'><div class='bt_one'>"+nam+"</div><div class='bt_tu'>"+titl+"</div><img class='xjt' src='/Content/images/xjiantou.png' /></div>", //设置文本标注内容
					        direction: 'right' //设置文本标注方位
						});
		                
		                AMap.event.addListener(marker, 'click', function () {
//		                    var infoWindow = new SimpleInfoWindow({
//		                        infoTitle: '<strong>'+nam+'</strong>',
//		                        infoBody: '<p class="my-desc">'+titl+'</p>',
//		                        //基点指向marker的头部位置
//		                        offset: new AMap.Pixel(0, -31)
//		                    });
//		                    infoWindow.open(map, marker.getPosition());
		                    $(".sud").val(v.f_centerpointcoordinates)
		                    $(".xsp").animate({
			                    width: '260px'
			                }, 100);
		                    shuju()
		                });
		                 markers.push(marker);
	                }
	                
	            })
	        }, 'json')
		}
    });
});

function shuju(){
	var nam=$(".sud").val()
	var typcc=$(".fs_li_style").attr("type")
	var dao=$(".daol").val()
    $.ajax({
        url: top.$.rootUrl + '/AssetManager/DC_ASSETS_BuildingBaseInfo/GetMapList',
        data: {
        	Typecode:typcc,
        	Street:dao
        },
        type: "get",
        dataType: "json",
        success: function (data) {
        	console.log(data)
			var bc=0;
            $.each(data.data, function(index, item) {
            	var address=data.data[bc].address; //地名
            	var name=data.data[bc].areaname;  // 名称
            	var position=data.data[bc].f_centerpointcoordinates;  //坐标
            	var code=data.data[bc].code;  //资产编号
            	var cz="<p>资产编号："+code+"</p>";
    			var qy="<p>行政区划："+name+"</p>";
    			var dz="<p>地址："+address+"</p>";
            	if(nam==position){
            		$(".xs_list").find("p").remove()
            		if(typcc==1){
            			var rentage=data.data[bc].f_assetsnumber;  //资产编号
            			var area=data.data[bc].f_landcertificate;  //土地证号
            			var useby=data.data[bc].f_sellingprice;  //出让单价
            			var price=data.data[bc].f_area;  //面积
            			var state=data.data[bc].f_transferamount;  //出让金额
            			var arrd=data.data[bc].f_parceladdress;  //地址
            			var kgrq=data.data[bc].f_startdate;  //开工日期
            			var jgrq=data.data[bc].f_completiondate;  //竣工日期
            			var zc="<p>资产编号："+rentage+"</p>";
            			var td="<p>土地证号："+area+"</p>";
            			var cr="<p>出让单价："+useby+"</p>";
            			var mj="<p>面积："+price+"</p>";
            			var je="<p>出让金额："+state+"</p>";
            			var dz="<p>地址："+arrd+"</p>";
            			var kg="<p>开工日期："+kgrq+"</p>";
            			var jg="<p>竣工日期："+jgrq+"</p>";
            			$(".xs_list").append(zc+td+cr+mj+je+dz+kg+jg)
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
            			var price=data.data[bc].f_communitycode;  //行政区划
            			var did=data.data[bc].f_installationlocation;  //地址
            			var mc=data.data[bc].f_billboardsname;  //广告牌名称
            			var zuj=data.data[bc].price;  //当前租金
            			var sy=data.data[bc].usestate;  //使用状态
            			var zul=data.data[bc].rentstate;  //租赁状态
            			var name="<p>广告牌名："+name+"</p>";
            			var price="<p>当前租金："+zuj+"</p>";
            			var rentstate="<p>租赁状态："+zul+"</p>";
            			var usestate="<p>使用状态："+sy+"</p>";
            			$(".xs_list").append(cz+qy+dz+name+price+rentstate+usestate)
            		}
            	}
            	bc++
            })
        }
    });
}


//默认选择一条信息
//dcud()
function dcud(){
	$.ajax({
        url: top.$.rootUrl + '/LeaderHome/GetHouseList',
        data: {},
        type: "post",
        dataType: "json",
        success: function (data) {
			var bc=0;
            $.each(data.data, function(index, item) {
            	var rentage=data.data[bc].f_assetsnumber;  //资产编号
    			var area=data.data[bc].f_landcertificate;  //土地证号
    			var useby=data.data[bc].f_sellingprice;  //出让单价
    			var price=data.data[bc].f_area;  //面积
    			var state=data.data[bc].f_transferamount;  //出让金额
    			var arrd=data.data[bc].f_parceladdress;  //地址
    			var kgrq=data.data[bc].f_startdate;  //开工日期
    			var jgrq=data.data[bc].f_completiondate;  //竣工日期
    			var zc="<p>资产编号："+rentage+"</p>";
    			var td="<p>土地证号："+area+"</p>";
    			var cr="<p>出让单价："+useby+"</p>";
    			var mj="<p>面积："+price+"</p>";
    			var je="<p>出让金额："+state+"</p>";
    			var dz="<p>地址："+arrd+"</p>";
    			var kg="<p>开工日期："+kgrq+"</p>";
    			var jg="<p>竣工日期："+jgrq+"</p>";
    			$(".xs_list").append(zc+td+cr+mj+je+dz+kg+jg)
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





