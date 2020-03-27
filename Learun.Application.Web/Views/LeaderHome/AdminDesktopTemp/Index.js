$(function () {
    var map = new AMap.Map('mapDiv', {
        resizeEnable: true, //是否监控地图容器尺寸变化
        zoom: 13, //初始化地图层级
        center: [111.754821, 30.431865], //初始化地图中心点
        mapStyle: "amap://styles/darkblue"
    });

	
	var markers = [];
	function remo(){
		map.remove(markers)
	}
    AMapUI.loadUI(['overlay/SimpleInfoWindow'], function (SimpleInfoWindow) {
        function GetIcon(type) {
            switch (type) {
                case 1: return "/Resource/Img/gc.png"
                case 2: return "/Resource/Img/dalo.png"
                case 3: return "/Resource/Img/ggp.png"
                case 4: return "/Resource/Img/gc.png"
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
		})
			
        
        mpa()
        
		function mpa(){
			var tye;
			var typcc=$(".fs_li_style").attr("type")
		    if(typcc==1){
				tye='/LeaderHome/GetHouseList'
			} else if (typcc==2){
				tye='/LeaderHome/GetLandList'
			} else if (typcc==3){
				tye='/LeaderHome/GetAdBoardList'
			} else if (typcc==4){
				tye='/LeaderHome/GetProjectList'
			}
			typ=$(".fs_li_style").attr("type")
//	        $.post(top.$.rootUrl + '/AssetHome/GetMapMarkers', {type:typ},function (data) {
        	$.post(top.$.rootUrl + tye, {},function (data) {
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
	            	if(typcc==4){
	            		ff=4
	            	}
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
	                    icon: icon,
	                });
	                AMap.event.addListener(marker, 'click', function () {
	                	var df;
	                	if(typ<3){
	                		df=v.code
	                	} else {
	                		df=v.name
	                	}
	                    var infoWindow = new SimpleInfoWindow({
	                        infoTitle: '<strong>'+df+'</strong>',
	                        infoBody: '<p class="my-desc">'+v.address+'</p>',
	                        //基点指向marker的头部位置
	                        offset: new AMap.Pixel(0, -31)
	                    });
	                    infoWindow.open(map, marker.getPosition());
	                    
	                    $(".sud").val(v.point)
	                    shuju()
	                });
	                 markers.push(marker);
	                
	            })
	        }, 'json')
		}
    });
});

function shuju(){
	var typ;
	var typcc=$(".fs_li_style").attr("type")
    if(typcc==1){
		typ='/LeaderHome/GetHouseList'
	} else if (typcc==2){
		typ='/LeaderHome/GetLandList'
	} else if (typcc==3){
		typ='/LeaderHome/GetAdBoardList'
	} else if (typcc==4){
		typ='/LeaderHome/GetProjectList'
	}
	var nam=$(".sud").val()
    $.ajax({
        url: top.$.rootUrl + typ,
        data: {},
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
            		if(typcc==4){
            			var name=data.data[bc].name;  //项目名称
            			var enddate=data.data[bc].enddate;  //计划完成时间
            			var progress=data.data[bc].progress;  //项目进度
            			var startdate=data.data[bc].startdate;  //计划开工时间
            			var state=data.data[bc].state;  //项目状态
            			var type=data.data[bc].type;  //项目建设类型
            			var xm="<p>项目编号："+code+"</p>";
            			var lx="<p>项目建设类型："+type+"</p>";
            			var xmc="<p>项目名称："+name+"</p>";
            			var kg="<p>计划开工时间："+startdate+"</p>";
            			var wc="<p>计划完成时间："+enddate+"</p>";
            			var xz="<p>项目状态："+state+"</p>";
            			var jd="<p>项目进度："+progress+"</p>";
            			$(".xs_list").append(xm+lx+xmc+qy+dz+kg+wc+xz+jd)
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





