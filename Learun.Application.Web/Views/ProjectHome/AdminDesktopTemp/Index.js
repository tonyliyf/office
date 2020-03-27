$(function () {
    var map = new AMap.Map('mapDiv', {
        resizeEnable: true, //是否监控地图容器尺寸变化
        zoom: 12, //初始化地图层级
        center: [111.754821, 30.431865] //初始化地图中心点
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
                case 4: return "/Resource/Img/gc_xz.png"
                default: return ""
            }
        }
        
        $("body").delegate(".xms_box", "click", function () {
        	var idc=$(this).attr("id")
        	var ddc=idc.substring(1,idc.length-1)
        	var arr = ddc.split(',');
	    	map.setZoomAndCenter(11,arr);
	    	remo()
	    	$(".addr").val($(this).text())
	    	mpa()
	    })
        
        var typ;
		$(".lisd").click(function(){
			remo()
			typ=$(this).attr("type");
        	$(".fs_li").removeClass("fs_li_style")
        	$(this).addClass("fs_li_style")
        	mpa()
		})
			
        
//      mpa()
        
		function mpa(){
			var ld=$(".addr").val()
//	        $.post(top.$.rootUrl + '/AssetHome/GetMapMarkers', {type:typ},function (data) {
        	top.learun.httpAsync('GET', top.$.rootUrl + '/ProjectHome/GetProjectInfo', {F_ProjectAddress:ld}, function (data) {
	        	console.log(data)
	            $.each(data, function (i, v) {
	            	var qq=$(".qq").val()
	            	if(qq==v.F_PIId){
	            		var icon = new AMap.Icon({
	            		    size: new AMap.Size(50, 50),
	            		    // 图标的取图地址
	            		    image: GetIcon(4),
	            		    imageSize: new AMap.Size(50, 50)
	            		});
	            	} else {
	            		var icon = new AMap.Icon({
	            		    size: new AMap.Size(50, 50),
	            		    // 图标的取图地址
	            		    image: GetIcon(1),
	            		    imageSize: new AMap.Size(50, 50)
	            		});
	            	}
	                if(v.F_CenterpointCoordinates==""){
	                	
	                } else {
	                	var marker = new AMap.Marker({
	                	    map: map,
	                	    zIndex: 9999999,
	                	    position: JSON.parse(v.F_CenterpointCoordinates),
	                	    icon: icon,
	                	});
	                }
	                AMap.event.addListener(marker, 'click', function () {
	                    var infoWindow = new SimpleInfoWindow({
	                        infoTitle: '<strong>'+v.F_ProjectName+'</strong>',
	                        infoBody: '<p class="my-desc">'+v.F_ProjectBuildType+'</p>',
	                        //基点指向marker的头部位置
	                        offset: new AMap.Pixel(0, -31)
	                    });
	                    infoWindow.open(map, marker.getPosition());
	                    $(".sud").val(v.F_PIId)
	                    $(".qq").val(v.F_PIId)
	                    mpa()
	                    shuju()
	                    xmqq()
	                    het()
	                    kqdk()
	                    xmsg()
	                    xmjd()
	                });
	                 markers.push(marker);
	                
	            })
	        }, 'json')
		}
    });
});
	var ym=1
	$(".xs_sou img").click(function(){
		ym=1
		sou()
	})
	sou()
	function sou(){ //搜索
		var sx_inp=$(".sx_inp").val()
		$.ajax({
	        url: top.$.rootUrl + '/LeaderHome/GetProjectList',
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
		            	var name=data.data[bc].name; //名字
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
	
	$("body").delegate(".sou_list", "click", function () {
    	var idc=$(this).attr("id");
    	$(".sud").val(idc)
        shuju()
    })
	
	

function shuju(){
	var nam=$(".sud").val()
    top.learun.httpAsync('GET', top.$.rootUrl + '/ProjectHome/GetProjectInfo', {}, function (data) {
        if (data) {
        	console.log(data);
            if (data.length > 0) {
            	$.each(data, function (index, item) {
            		if(nam==item.F_PIId){
            			$(".xms_tc").show()
            			$("#F_ProjectName").text(item.F_ProjectName)
            			$("#F_ProjectItemNumber").text(item.F_ProjectItemNumber)
            			$("#F_ProjectYear").text(item.F_ProjectYear)
            			$("#F_ProjectBuildType").text(item.F_ProjectBuildType)
            			$("#F_EngineeringCost").text(item.F_EngineeringCost)
            			$("#F_area").text(item.F_area)
            			var jhkg=item.F_ProjectApprovalDate.substring(0,10)
            			$("#F_ProjectApprovalDate").text(jhkg)
            			var kgsj=item.F_PlannedStartDate.substring(0,10)
            			$("#F_PlannedStartDate").text(kgsj)
            			var jhwg=item.F_PlannedEndDate.substring(0,10)
            			$("#F_PlannedEndDate").text(jhwg)
            			$("#F_JRYCompany").text(item.F_JRYCompany)
            			$("#F_ProjectAddress").text(item.F_ProjectAddress)
            			var beiz=item.F_Remarks
	        			if(beiz==null){beiz=""}
            			$("#F_Remarks").text(beiz)
            			var jlsj=item.F_CreateDatetime
	        			if(jlsj==null){jlsj=""}else{jlsj=jlsj.substring(0,10)}
            			$("#F_CreateDatetime").text(jlsj)
            			
            		}
            		
                })
            }

        } else {
            console.log("error");
        }
    })
}




function het(){ //合同管理
	var nam=$(".sud").val()
    top.learun.httpAsync('GET', top.$.rootUrl + '/ProjectHome/GetProjectContractInfo', {projectid:nam}, function (data) {
        if (data) {
        	console.log(data);
        	$(".htgl").find(".trd").remove()
            if (data.length > 0) {
            	$.each(data, function (index, item) {
            		var qdsj=item.f_signingtime.substring(0,10)
            		if(qdsj==""){
            			qdsj="";
            		}
            		var html="<tr class='xb_tr trd'>"+
					"<th class='xb_thb'>"+item.f_contracttype+"</th><th class='xb_thb'>"+item.f_contractcode+"</th>"+
					"<th class='xb_thb'>"+item.f_contractname+"</th><th class='xb_thb'>"+item.f_contractmoney+"</th>"+
					"<th class='xb_thb'>"+item.f_settlementmethod+"</th><th class='xb_thb'>"+item.f_paymethod+"</th>"+
					"<th class='xb_thb'>"+qdsj+"</th></tr>";
            		$(".htgl").append(html)
                })
            }
        } else {
            console.log("error");
        }
    })
}

function xmqq(){
	var nam=$(".sud").val()
    top.learun.httpAsync('GET', top.$.rootUrl + '/DC_ProjectBeforeInfoReport/GetBeforeProjectInfo', {projectid:nam}, function (data) {
        if (data) {
        	console.log(data);
            if (data.length > 0) {
	        	$.each(data, function (index, item) {
	        		var xmqd=data[index].项目启动会议纪要
	        		if(xmqd==null){xmqd=""}
	        		var xmqs=data[index].项目请示批复
	        		if(xmqs==null){xmqs=""}
	        		var jys=data[index].项目建议书审批
	        		if(jys==null){jys=""}
	        		var kxx=data[index].可行性研究报告审批
	        		if(kxx==null){kxx=""}
	        		var gcgh=data[index]['《建设工程规划许可证》']
	        		if(gcgh==null){gcgh=""}
	        		var ydsh=data[index].用地预审
	        		if(ydsh==null){ydsh=""}
	        		var jsyd=data[index]['《建设用地规划许可证》']
	        		if(jsyd==null){jsyd=""}
	        		var bld=data[index].办理用地审批手续
	        		if(bld==null){bld=""}
	        		var sjfa=data[index].设计方案招标
	        		if(sjfa==null){sjfa=""}
	        		var ghfa=data[index].规划设计方案审批
	        		if(ghfa==null){ghfa=""}
	        		var sjdw=data[index].设计单位招标
	        		if(sjdw==null){sjdw=""}
	        		var sgt=data[index].施工图设计
	        		if(sgt==null){sgt=""}
	        		var xzbm=data[index].行政部门审批
	        		if(xzbm==null){xzbm=""}
	        		var sjyj=data[index]['《建设项目选址意见书》']
	        		if(sjyj==null){sjyj=""}
	        		var sgtsh=data[index].用地预审
	        		if(sgtsh==null){sgtsh=""}
	        		var sgtys=data[index].施工图预算
	        		if(sgtys==null){sgtys=""}
	        		var czps=data[index].财政评审
	        		if(czps==null){czps=""}
					$(".xmqq").find(".xb_tr").eq(0).find(".xb_th").eq(index).text(kxx)
					$(".xmqq").find(".xb_tr").eq(1).find(".xb_th").eq(index).text(sgtsh)
					$(".xmqq").find(".xb_tr").eq(2).find(".xb_th").eq(index).text(gcgh)
					$(".xmqq").find(".xb_tr").eq(3).find(".xb_th").eq(index).text(sjyj)
					$(".xmqq").find(".xb_tr").eq(4).find(".xb_th").eq(index).text(ydsh)
					$(".xmqq").find(".xb_tr").eq(5).find(".xb_th").eq(index).text(ghfa)
					
					$(".xmqqto").find(".xb_tr").eq(0).find(".xb_th").eq(index).text(jys)
					$(".xmqqto").find(".xb_tr").eq(1).find(".xb_th").eq(index).text(xmqd)
					$(".xmqqto").find(".xb_tr").eq(2).find(".xb_th").eq(index).text(xmqs)
				
		    			
                })
            }
        } else {
            console.log("error");
        }
    })
}

function xmsg(){ //项目施工信息
	var nam=$(".sud").val()
    top.learun.httpAsync('GET', top.$.rootUrl + '/DC_EngineProject_BuilderDiaryMain/GetProjectAttenced', {projectid:nam}, function (data) {
        if (data) {
        	console.log(data);
        	$(".xmsg").find(".trd").remove()
            if (data.length > 0) {
            	$.each(data, function (index, item) {
            		var txsj=item.txsj
            		if(txsj==null){txsj==""} else {txsj=item.txsj.substring(0,10)}
            		var rzbh=item.rzbh
            		if(rzbh==null){rzbh==""}
            		var txr=item.txr
            		if(txr==null){txr==""}
            		var tqqk=item.tqqk
            		if(tqqk==null){tqqk==""}
            		var sgjd=item.sgjzqk
            		if(sgjd==null){sgjd==""}
            		var html="<tr class='xb_tr trd'>"+
					"<th class='xb_thb'>"+rzbh+"</th><th class='xb_thb'>"+txr+"</th>"+
					"<th class='xb_thb'>"+tqqk+"</th><th class='xb_thb'>"+txsj+"</th>"+
					"<th class='xb_thb'>"+sgjd+"</th></tr>";
            		$(".xmsg").append(html)
                })
            }
        } else {
            console.log("error");
        }
    })
}

function kqdk(){ //考勤管理
	var nam=$(".sud").val()
    top.learun.httpAsync('GET', top.$.rootUrl + '/ProjectAttenceRecord/GetProjectAttenced', {projectid:nam}, function (data) {
        if (data) {
   //  	console.log(data);
        	$(".kqdk").find(".trd").remove()
            if (data.length > 0) {
            	$.each(data, function (index, item) {
            		var kssj=item.f_firstattencedatetime
            		var jssj=item.f_secondattencedatetime
            		if(kssj==null){
            			kssj="";
            		} else {
            			kssj=item.f_firstattencedatetime.substring(0,10)
            		}
            		if(jssj==null){
            			jssj="";
            		} else {
            			jssj=item.f_secondattencedatetime.substring(0,10)
            		}
            		var html="<tr class='xb_tr trd'>"+
					"<th class='xb_thb'>"+item.f_createusername+"</th>"+
					"<th class='xb_thb'>"+item.f_titile+"</th><th class='xb_thb'>"+item.f_class+"</th>"+
					"<th class='xb_thb'>"+kssj+"</th><th class='xb_thb'>"+jssj+"</th>"+
					"<th class='xb_thb'>"+item.f_description+"</th></tr>";
            		$(".kqdk").append(html)
                })
            }
        } else {
            console.log("error");
        }
    })
}

function xmjd(){ //项目进度
    var nam = $(".sud").val()
    top.learun.httpAsync('GET', top.$.rootUrl + '/DC_EngineProject_ProjectProgress/GetProjectProgress', { projectid: nam }, function (data) {
    	console.log(data);
        if (data) {
        	$(".xmjd").find(".trc").remove()
            if (data.length > 0) {
            	$.each(data, function (index, item) {
            		var atiem=item.f_time
            		if(atiem==null){
            			atiem="";
            		} else {
            			atiem=item.f_time.substring(0,10)
            		}
            		var html="<tr class='xb_tr trc'>"+
					"<th class='xb_thb' style='width: 25%;'>"+item.f_piid+"</th>"+
					"<th class='xb_thb'>"+item.f_month+"</th><th class='xb_thb'>"+item.f_createuser+"</th>"+
					"<th class='xb_thb'>"+item.f_proceedings+"</th><th class='xb_thb'>"+atiem+"</th>"+
					"<th class='xb_thb'>"+item.f_summarize+"</th><th class='xb_thb'>"+item.f_plan+"</th>"+
					"<th class='xb_thb'>"+item.f_remark+"</th>"+
					"<th class='xb_thb' style='width: 25%;'>"+item.f_department+"</th></tr>";
            		$(".xmjd").append(html)
                })
            }
        } else {
            console.log("error");
        }
    })
}

//默认选择一条信息
dcud()
function dcud(){
	$.ajax({
        url: top.$.rootUrl + '/LeaderHome/GetProjectList',
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
            	var cz="<p>资产编号："+code+"</p>";
    			var qy="<p>行政区划："+name+"</p>";
    			var dz="<p>地址："+address+"</p>";
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





