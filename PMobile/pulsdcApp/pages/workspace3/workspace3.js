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
        
        
        $("body").delegate(".box_lit", "tap", function () {
        	var ths=$(this).attr("type")
        	$(".xm_box").remove()
        	if(ths==0){
        		$(".rw_home").show()
        		$(".mac").hide()
        		var hdc="<div class='tcct_top'><div class='tct_left'>"+
				"<span class='tcsp' style='position: absolute;z-index: 100;margin-left: 5px;'>我的任务</span>"+
				"<div class='xlcd'></div></div><div class='tct_rig'><div class='box_rg' style='float: right;'><img class='rg_im' src='images/fanh.png'><span>返回上一页</span></div></div></div>";
			    $(".f-page-header").prepend(hdc)
        	} else {
        		$(".rw_home").hide()
	        	$(".dc_home ,.dc_list").show()
//	        	$(".tcct_top").remove()
        		rwlb(ths)
        	}
        	
        })
        
        function rwlb(id){
        	learun.httpget(config.webapi + 'learun/adms/SuperviseManager/SuperviseInfoApi/GetMaxTaskInfo', {userid:web.userid,type:id}, function(data) {
				console.log(data)
				$(".dc_list .xm_boxc").remove()
				$.each(data, function (index, item) {
					if(item.rwzt==null){var jd=""}else{var jd=item.rwzt}
					if(jd==0){jd="执行中"}else if(jd==1){jd="完成"}else if(jd==2){jd="暂缓"}else if(jd==3){jd="延期"}else if(jd==4){jd="终止"}else if(jd==5){jd="分解"}else if(jd==6){jd="签收"}else if(jd==7){jd="拟办"}
					var html="<div class='xm_boxc' id='"+item.id+"'><div class='xm_box_left'><img src='images/tix.png'/></div>"+
				    "<div class='xm_box_right'><div class='xbox_top'><div class='xbox_tit'>"+item.rwmc+"</div>"+
				    "<div class='xobx_time'>"+item.yqbjrq+"</div></div>"+
				    "<div class='xbox_bottom'><span style='float: left;'>"+item.zbbm+"</span><span class='jd' style='float: right;'>"+jd+"</span></div></div></div>";
					$(".dc_list").append(html)
				})
				$(".jd").each(function(){
		    		var tx=$(this).text()
		    		if(tx=="执行中"){$(this).addClass("lv")}else if(tx=="完成"){$(this).addClass("lan")}else if(tx=="暂缓"){$(this).addClass("zi")}else if(tx=="延期"){$(this).addClass("hong")}else if(tx=="终止"){$(this).addClass("hui")}else if(tx=="分解"){$(this).addClass("sh")}else if(tx=="签收"){$(this).addClass("lvt")}else if(tx=="拟办"){$(this).addClass("fen")}
		    	})
			})
        }
        $page.find('#F_StartDate').lrdate({
                type: 'date'
        });
        
         $page.find('#F_StartDatec').lrdate({
                type: 'date'
        });

        var wdrwid;
        $("body").delegate(".xm_boxc", "tap", function () { //任务状态
        	var ths=$(this).attr("id")
        	$(".dc_list").hide()
        	$(".dc_wdrw").show()
    		wdrw(ths)
    		wdrwid=ths
        })
        
        function wdrw(id){ //我的任务详情
	        learun.httpget(config.webapi + 'learun/adms/SuperviseManager/SuperviseInfoApi/GetSubTaskDetailInfo', {id:id}, function(data) {
		    	console.log(data)
		    	$(".dc_rw .nr_box").remove()
		    	$.each(data, function (index, item) {
		    		if(item.jd==null){var wcjd=0}else{var wcjd=item.jd}
		    		var bfb=item.rwjd+"%"
		    		if(item.xzbmDepart==null){var xbdw=""}else{var xbdw=item.xzbmDepart}
		    		if(item.xzrnew==null){var xbr=""}else{var xbr=item.xzrnew}
		    		if(item.rwzt==null){var jd=""}else{var jd=item.rwzt}
		    		if(jd==0){jd="执行中"}else if(jd==1){jd="完成"}else if(jd==2){jd="暂缓"}else if(jd==3){jd="延期"}else if(jd==4){jd="终止"}else if(jd==5){jd="分解"}else if(jd==6){jd="签收"}else if(jd==7){jd="拟办"}
		    		var html="<div class='nr_box'><div class='nr_list'><div class='nr_left'>任务名称</div><div class='nr_rig'>"+item.rwmc+"</div></div>"+
		    		"<div class='nr_list'><div class='nr_left'>主办部门</div><div class='nr_rig'>"+item.zbbmDepart+"</div></div>"+
		    		"<div class='nr_list'><div class='nr_left'>主办人</div><div class='nr_rig'>"+item.zbrHrm+"</div></div>"+
		    		"<div class='nr_list'><div class='nr_left'>执行人</div><div class='nr_rig'>"+item.zxrHrm+"</div></div>"+
		    		"<div class='nr_list'><div class='nr_left'>所属科室</div><div class='nr_rig'>"+item.ssksDepart+"</div></div>"+
		    		"<div class='nr_list'><div class='nr_left'>任务内容</div><div class='nr_rig'>"+item.rwlx+"</div></div>"+
//		    		"<div class='nr_list'><div class='nr_left'>交办日期</div><div class='nr_rig'>"+item.jbrq+"</div></div>"+
//		    		"<div class='nr_list'><div class='nr_left'>要求办结时间</div><div class='nr_rig'>"+item.yqbjrq+"</div></div>"+
		    		"<div class='nr_list'><div class='nr_left'>任务状态</div><div class='nr_rig rwzt' type='"+item.rwzt+"'>"+jd+"</div></div>"+
		    		"<div class='nr_list'><div class='nr_left'>完成进度(%)</div><div class='nr_rig'><input class='wcjd_inp' type='text' value='"+wcjd+"' /></div></div>"+
		    		"<div class='nr_list'><div class='nr_left'>创建人</div><div class='nr_rig'>"+item.modedatacreaterHrm+"</div></div></div>";
					$(".dc_wdrw .dc_rw").prepend(html)
					
					$("#F_StartDate").find(".text").text(item.jbrq)
					$("#F_StartDatec").find(".text").text(item.yqbjrq)
		    	})
		    })
        }
        
        $("body").delegate(".rwzt", "tap", function () {  //生成任务状态
        	var html="<div class='hdbj'><div class='zt_home'><div class='hd_xz_ov' type='0'>"+
			"<div class='ov_left'><img src='images/wxz.png'/></div><div class='ov_left'>执行中</div></div>"+
			"<div class='hd_xz_ov' type='1'><div class='ov_left'><img src='images/wxz.png'/></div>"+
			"<div class='ov_left'>完成</div></div><div class='hd_xz_ov' type='2'>"+
			"<div class='ov_left'><img src='images/wxz.png'/></div><div class='ov_left'>暂缓</div></div>"+
		    "<div class='hd_xz_ov' type='3'><div class='ov_left'><img src='images/wxz.png'/></div>"+
			"<div class='ov_left'>延期</div></div><div class='hd_xz_ov' type='4'>"+
			"<div class='ov_left'><img src='images/wxz.png'/></div><div class='ov_left'>终止</div></div>"+
		    "<div class='hd_xz_ov' type='5'><div class='ov_left'><img src='images/wxz.png'/></div>"+
			"<div class='ov_left'>分解</div></div><div class='hd_xz_ov' type='6'><div class='ov_left'>"+
			"<img src='images/wxz.png'/></div><div class='ov_left'>签收</div></div>"+
		    "<div class='hd_xz_ov' type='7'><div class='ov_left'><img src='images/wxz.png'/></div>"+
			"<div class='ov_left'>拟办</div></div></div></div>";
			$("body").append(html)
        })
        
        $("body").delegate(".hd_xz_ov", "tap", function () {  //选择任务状态
        	$(".hd_xz_ov").find(".ov_left img").attr("src","images/wxz.png")
        	$(this).find(".ov_left img").attr("src","images/xz.png")
        	$(".hdbj").remove()
        	$(".rwzt").text($(this).find(".ov_left").text())
        	$(".rwzt").attr("type",$(this).attr("type"))
        })
        
        
        $("body").delegate(".wcjd_inp", "keyup", function () {  //完成进度控制
        	var nr=$(this).val()
        	var bc=parseInt(nr)
        	if(!isNaN(nr)){
        		if(nr>100){
        			$(this).val(100)
        		} else {
        			if(!isNaN(bc)){
        				$(this).val(bc)
        			}
        		}
        	} else {
        		$(this).val("")
        	}
        })
        
        
        $("body").delegate(".rwwc", "tap", function () {
        	var jbrq=$("#F_StartDate").find(".text").text()
			var yqbjrq=$("#F_StartDatec").find(".text").text()
			
        	var _postData = {}
        	var ddd={
        		rwzt:$(".rwzt").attr("type"),
				jbrq:jbrq,
				yqbjrq:yqbjrq,
				jd:$(".wcjd_inp").val()
        	}
        	_postData.strEntity = JSON.stringify(ddd)
        	_postData.keyValue=wdrwid
        	console.log(ddd)
        	learun.httppost(config.webapi + 'learun/adms/SuperviseManager/SuperviseInfoApi/UpdateTasklist', _postData, (data) =>{
        		console.log(data)
        		xxk("保存成功")
	    	})
        })
        
        $("body").delegate(".rwbj", "tap", function () { //办结
        	learun.httpget(config.webapi + 'learun/adms/SuperviseManager/SuperviseInfoApi/SaveTasklist',{keyValue:wdrwid}, function(data) {
        		console.log(data)
        		xxk("办结成功")
        		numb()
        		$(".dc_wdrw,.dc_list").hide()
				$(".rw_home").show()
	    	})
        })
        
        window.setTimeout(function(){
	    	numb()
	    }, 500);
        
        function numb(){
        	learun.httpget(config.webapi + 'learun/adms/SuperviseManager/SuperviseInfoApi/GetMaxTaskNum', {userid:web.userid}, function(data) {
				console.log(data)
				var zrw=data.MaxTaskNum[0].num
				var xbrw=data.MaxAssistNum[0].num
				var bjrw=data.MaxEndNum[0].num
				$(".rw_home .box_lit").eq(0).find("span").text("主办任务("+zrw+")")
				$(".rw_home .box_lit").eq(1).find("span").text("协办任务("+xbrw+")")
				$(".rw_home .box_lit").eq(2).find("span").text("已完结任务("+bjrw+")")
			})
        }
        
        $("body").delegate(".xm_title", "tap", function () {  //点击收缩弹出框
        	var hei=$(this).parents(".xc_list").outerHeight();
        	if(hei>56){
				$(this).parents(".xc_list").css("height","56px")
			} else {
				$(".xc_list").css("height","56px")
				$(this).parents(".xc_list").css("height","auto")
			}
        })
        var maxzrwid;
        $("body").delegate(".box_li", "tap", function () {  //点击跳入详细
        	var th=$(this).attr("type")
        	var txt=$(this).find("span").text()
        	$(".mac").hide()
        	$(".dc_home ,.dc_list").show()
        	$(".tcct_top,.xm_boxc").remove()
        	var hdc="<div class='tcct_top'><div class='tct_left'>"+
			"<span class='tcsp' style='position: absolute;z-index: 100;margin-left: 5px;'>"+txt+"</span>"+
			"<div class='xlcd'></div></div><div class='tct_rigc'><div class='box_rg' style='float: right;'><img class='rg_im' src='images/fanh.png'><span>返回上一页</span></div></div></div>";
		    $(".f-page-header").prepend(hdc)
		    window.setTimeout(function(){
		    	xxlb(th)
		    }, 500);
        	
        })
        
        df()  //获取userid
        function df(){
			learun.httpget(config.webapi + 'learun/adms/SuperviseManager/SuperviseInfoApi/GetUserid', {cookieid:cppo}, function(data) {
				console.log(data)
				$.each(data, function (index, item) {
					$(".userid").val(item.f_weaverid)
				})
			})
        }
        
//       $("body").delegate(".fff", "tap", function () {
//       	alert(cppo)
//       })
        
        $("body").delegate(".tct_rigc", "tap", function () {  //返回上一页
        	if($(".dc_zym").is(":visible")){
		    	$(".dc_zym").hide()
		    	$(".dc_tra").show()
			} else if($(".dc_tra").is(":visible")){
				$(".dc_tra").hide()
				$(".dc_list").show()
			} else if($(".dc_list").is(":visible")){
				$(".mac").show()
				$(".dc_home").hide()
				$(".tcct_top").remove()
			}
        })
        
        $("body").delegate(".tct_rig", "tap", function () {  //返回上一页
        	if($(".rw_home").is(":visible")){
		    	$(".rw_home,.dc_wdrw").hide()
		    	$(".mac").show()
		    	$(".tcct_top").remove()
			} else if($(".dc_list").is(":visible")){
				$(".dc_wdrw,.dc_list").hide()
				$(".rw_home").show()
			} else if($(".dc_wdrw").is(":visible")){
				$(".dc_wdrw").hide()
				$(".dc_list").show()
			}
        })
        
        function xxlb(th){ //
	        learun.httpget(config.webapi + 'learun/adms/SuperviseManager/SuperviseInfoApi/GetTaskInfo', {type:th}, function(data) {
		    	console.log(data)
		    	$(".dc_list .xm_box").remove()
		    	$.each(data, function (index, item) {
		    		if(item.rwzt==null){var jd=""}else{var jd=item.rwzt}
		    		if(jd==0){jd="执行中"}else if(jd==1){jd="完成"}else if(jd==2){jd="暂缓"}else if(jd==3){jd="延期"}else if(jd==4){jd="终止"}else if(jd==5){jd="分解"}else if(jd==6){jd="签收"}else if(jd==7){jd="拟办"}
		    		var html="<div class='xm_box' id='"+item.id+"' type='"+item.lxmxid+"'><div class='xm_box_left'><img src='images/tix.png'/></div>"+
				    "<div class='xm_box_right'><div class='xbox_top'><div class='xbox_tit'>"+item.rwmc+"</div>"+
				    "<div class='xobx_time'>"+item.yqbjrq+"</div></div>"+
				    "<div class='xbox_bottom'><span style='float: left;'>"+item.qtbmDepart+"</span><span class='jd' style='float: right;'>"+jd+"</span></div></div></div>";
		    		$(".dc_list").append(html)
		    	})
		    	$(".jd").each(function(){
		    		var tx=$(this).text()
		    		if(tx=="执行中"){$(this).addClass("lv")}else if(tx=="完成"){$(this).addClass("lan")}else if(tx=="暂缓"){$(this).addClass("zi")}else if(tx=="延期"){$(this).addClass("hong")}else if(tx=="终止"){$(this).addClass("hui")}else if(tx=="分解"){$(this).addClass("sh")}else if(tx=="签收"){$(this).addClass("lvt")}else if(tx=="拟办"){$(this).addClass("fen")}
		    	})
		    })
        }
        
        $("body").delegate(".xm_box", "tap", function () {  //点击跳入子任务,任务详情
        	var id=$(this).attr("id")
        	var txt=$(this).find(".xbox_tit").text()
        	var typ=$(this).attr("type")
        	$(".dc_list").hide()
        	$(".dc_tra").show()
        	$(".tcct_top").remove()
        	var hdc="<div class='tcct_top'><div class='tct_left'>"+
			"<span class='tcsp' style='position: absolute;z-index: 100;margin-left: 5px;'>"+txt+"</span>"+
			"<div class='xlcd'></div></div><div class='tct_rigc'><div class='box_rg' style='float: right;'><img class='rg_im' src='images/fanh.png'><span>返回上一页</span></div></div></div>";
		    $(".f-page-header").prepend(hdc)
		    window.setTimeout(function(){
		    	zrw(typ) //子任务列表
	        	zrxq(id)  //任务详情 
	        	rwpl(id)  //主任务评论
		    }, 500);
        	maxzrwid=id
        })
        
        function zrxq(id){ //任务详情
	        learun.httpget(config.webapi + 'learun/adms/SuperviseManager/SuperviseInfoApi/GetTaskDetailInfo', {id:id}, function(data) {
		    	console.log(data)
		    	$(".dc_xx .nr_box").remove()
		    	$.each(data, function (index, item) {
		    		var bfb=item.rwjd+"%"
		    		if(item.xzbmDepart==null){var xbdw=""}else{var xbdw=item.xzbmDepart}
		    		if(item.xzrnew==null){var xbr=""}else{var xbr=item.xzrnew}
		    		if(item.rwzt==null){var jd=""}else{var jd=item.rwzt}
		    		if(jd==0){jd="执行中"}else if(jd==1){jd="完成"}else if(jd==2){jd="暂缓"}else if(jd==3){jd="延期"}else if(jd==4){jd="终止"}else if(jd==5){jd="分解"}else if(jd==6){jd="签收"}else if(jd==7){jd="拟办"}
		    		var html="<div class='nr_box'><div class='nr_list'><div class='nr_left'>任务名称</div><div class='nr_rig'>"+item.rwmc+"</div></div>"+
		    		"<div class='nr_list'><div class='nr_left'>任务开始时间</div><div class='nr_rig'>"+item.jbrq+"</div></div>"+
		    		"<div class='nr_list'><div class='nr_left'>任务主办单位</div><div class='nr_rig'>"+item.qtbmDepart+"</div></div>"+
		    		"<div class='nr_list'><div class='nr_left'>主办人</div><div class='nr_rig'>"+item.zbrHrm+"</div></div>"+
		    		"<div class='nr_list'><div class='nr_left'>协办单位</div><div class='nr_rig'>"+xbdw+"</div></div>"+
		    		"<div class='nr_list'><div class='nr_left'>协办人</div><div class='nr_rig'>"+xbr+"</div></div>"+
		    		"<div class='nr_list'><div class='nr_left'>完成时间</div><div class='nr_rig'>"+item.yqbjrq+"</div></div></div>";
					$(".dc_tra .dc_xx").prepend(html)
		    	})
		    })
        }
        
        function zrw(id){  //子任务列表
	        learun.httpget(config.webapi + 'learun/adms/SuperviseManager/SuperviseInfoApi/GetSubTaskInfo', {taskid:id}, function(data) {
		    	console.log(data)
		    	$(".dc_tra .zrw_list").remove()
		    	$.each(data, function (index, item) {
//		    		var bfb=item.jd+"%"
		    		if(item.jd==null){var rwjd=0}else{var rwjd=item.jd}
		    		if(item.rwzt==null){var jd=""}else{var jd=item.rwzt}
		    		if(jd==0){jd="执行中"}else if(jd==1){jd="完成"}else if(jd==2){jd="暂缓"}else if(jd==3){jd="延期"}else if(jd==4){jd="终止"}else if(jd==5){jd="分解"}else if(jd==6){jd="签收"}else if(jd==7){jd="拟办"}
		    		var html="<div class='zrw_list' type='"+item.lxmxid+"' id='"+item.id+"'><div class='zrw_title'>"+item.rwmc+"</div>"+
					"<div class='zrw_bottom'><div class='zrw_left'>"+
					"<span style='margin-right: 10px;'>"+jd+"</span><span>主办人："+item.zbrHrm+"</span></div>"+
					"<div class='zrw_right'><div class='zrw_jd' style='width:"+rwjd+"%'></div><div class='jd_tit' >百分之"+rwjd+"%</div></div></div></div>";
					$(".dc_tra .dc_zrw").prepend(html)
					
		    	})
		    })
        }
        
        $("body").delegate(".zrw_list", "tap", function () {  //子任务点击跳转子任务详情
        	var id=$(this).attr("id")
        	var type=$(this).attr("type")
        	var txt=$(this).find(".zrw_title").text()
        	$(".dc_zym").show()
        	$(".dc_tra").hide()
        	$(".tcct_top").remove()
        	var hdc="<div class='tcct_top'><div class='tct_left'>"+
			"<span class='tcsp' style='position: absolute;z-index: 100;margin-left: 5px;'>"+txt+"</span>"+
			"<div class='xlcd'></div></div><div class='tct_rigc'><div class='box_rg' style='float: right;'><img class='rg_im' src='images/fanh.png'><span>返回上一页</span></div></div></div>";
		    $(".f-page-header").prepend(hdc)
		    window.setTimeout(function(){
		    	zrwxq(id)//子任务列表
		    	zrwpl(id)//子任务评论
		    }, 500);
		    $(".dc_zym .box_button").attr("id",id)
        	$(".dc_zym .box_button").attr("type",type)
        })
        
        function zrwxq(id){ //子任务详情
	        learun.httpget(config.webapi + 'learun/adms/SuperviseManager/SuperviseInfoApi/GetSubTaskDetailInfo', {id:id}, function(data) {
		    	console.log(data)
		    	$(".dc_xx .nr_box").remove()
		    	$.each(data, function (index, item) {
		    		var bfb=item.rwjd+"%"
		    		if(item.rwzt==null){var jd=""}else{var jd=item.rwzt}
		    		if(jd==0){jd="执行中"}else if(jd==1){jd="完成"}else if(jd==2){jd="暂缓"}else if(jd==3){jd="延期"}else if(jd==4){jd="终止"}else if(jd==5){jd="分解"}else if(jd==6){jd="签收"}else if(jd==7){jd="拟办"}
		    		var html="<div class='nr_box'><div class='nr_list'><div class='nr_left'>任务名称</div><div class='nr_rig'>"+item.rwmc+"</div></div>"+
		    		"<div class='nr_list'><div class='nr_left'>主办部门</div><div class='nr_rig'>"+item.zbbmDepart+"</div></div>"+
		    		"<div class='nr_list'><div class='nr_left'>主办人</div><div class='nr_rig'>"+item.zbrHrm+"</div></div>"+
		    		"<div class='nr_list'><div class='nr_left'>执行人</div><div class='nr_rig'>"+item.zxrHrm+"</div></div>"+
		    		"<div class='nr_list'><div class='nr_left'>所属科室</div><div class='nr_rig'>"+item.ssksDepart+"</div></div>"+
		    		"<div class='nr_list'><div class='nr_left'>任务内容</div><div class='nr_rig'>"+item.rwlx+"</div></div>"+
		    		"<div class='nr_list'><div class='nr_left'>交办日期</div><div class='nr_rig'>"+item.jbrq+"</div></div>"+
		    		"<div class='nr_list'><div class='nr_left'>要求办结时间</div><div class='nr_rig'>"+item.yqbjrq+"</div></div>"+
		    		"<div class='nr_list'><div class='nr_left'>任务状态</div><div class='nr_rig'>"+jd+"</div></div>"+
		    		"<div class='nr_list'><div class='nr_left'>完成进度</div><div class='nr_rig'>"+item.jd+"</div></div>"+
		    		"<div class='nr_list'><div class='nr_left'>创建日期</div><div class='nr_rig'>"+item.modedatacreatedate+"</div></div>"+
		    		"<div class='nr_list'><div class='nr_left'>创建人</div><div class='nr_rig'>"+item.modedatacreaterHrm+"</div></div></div>";
					$(".dc_zym .dc_xx").prepend(html)
					
		    	})
		    })
        }
        
        
        
        function rwpl(id){  //主任务评论
        	learun.httpget(config.webapi + 'learun/adms/SuperviseManager/SuperviseInfoApi/GetTaskPl', {id:id}, function(data) {
		    	console.log(data)
		    	$(".dc_tra .dc_pl .str_ov").remove()
		    	$.each(data.dt1, function (index, item) {
		    		var html="<div class='str_ov' id='"+item.id+"'><div class='plxq'><div class='jou_left'><img src='images/on-boy.jpg'></div>"+
					"<div class='jou_right'><div class='jou_title'> <span class='left'>["+item.plbmDepart+"]"+item.plrHrm+"</span></div>"+
					"<div class='hide_span'>"+item.pllr+"</div><div class='hide_bottom'>"+
					"<div class='ping_left'>"+item.plsj+"</div><div class='ping_right'>"+
					"<div class='hide_ui pinglun'><img src='images/pinglun-hui.png'></div></div></div></div></div></div>";
					$(".dc_tra .dc_pl").append(html)
		    	})
		    	$.each(data.dt2, function (index, item) {
		    		var idc=item.replyid
		    		$(".dc_tra .str_ov").each(function(){
			    		var iid=$(this).attr("id")
			    		if(iid==idc){
			    			var htc="<div class='jou_ping'><div class='juo_zan_left'>"+
							"<img src='images/pinglun-zan.png'></div>"+
							"<div class='jou_zan_right'><div class='zan_rig_list'>"+
							"<div class='rig_list_img'><img src='images/on-boy.jpg'></div>"+
							"<div class='rig_list_span'><div class='rig_list_top'>"+
							"<span>["+item.plbmDepart+"]"+item.plrHrm+"</span></div>"+
							"<p>"+item.pllr+"</p><span class='rig_top_span'>"+item.plsj+"</span></div></div></div></div>";
			    			$(this).append(htc)
			    		}
			    	})
		    	})
		    })
        }
        
        
     	$("body").delegate(".ping_right", "tap", function () {  //回复主任务评论\
     		var id=$(this).parents(".str_ov").attr("id")
     		$(".ducy").remove()
         	var html="<div class='dyn_bot_box ducy' style='margin-top: 5px;'>"+
			"<textarea class='dyn_text' placeholder='回复评论'></textarea>"+
			"<div class='box_buttonc' type='"+id+"'>确认回复</div></div>";
        	$(this).parents(".str_ov").append(html)
        })
     	
     	$("body").delegate(".dc_tra .box_buttonc", "tap", function () {  //主任务回复评论
     		
        	var pl=$(this).prev().val()
        	var typ=$(this).attr("type")
        	var _postData = {}
        	var ddd={
        		plr:web.userid,
				pllr:pl,
				maxzrwid:maxzrwid,
				replyid:typ
        	}
            _postData.strEntity = JSON.stringify(ddd)
    		console.log(_postData.strEntity)
	    	learun.httppost(config.webapi + 'learun/adms/SuperviseManager/SuperviseInfoApi/SavePl', _postData, (data) => {
	    		console.log(data)
	    		window.setTimeout(function(){
			    	rwpl(maxzrwid)
			    }, 500);
	    		$(".dyn_text").val("")
	    		$(".ducy").remove()
	    		xxk("回复成功")
//	    		$(".f-scroll",window.parent.document).css("transform","translate3d(0px, 0px, 0px) translateZ(0px)")
	    	})
        })
        
        
        function zrwpl(idc){  //子任务评论
        	learun.httpget(config.webapi + 'learun/adms/SuperviseManager/SuperviseInfoApi/GetSubTaskPl', {id:maxzrwid,subid:idc}, function(data) {
		    	console.log(data)
		    	$(".dc_zym .dc_pl .str_ov").remove()
		    	$.each(data.dt1, function (index, item) {
		    		var html="<div class='str_ov' id='"+item.id+"'><div class='plxq'><div class='jou_left'><img src='images/on-boy.jpg'></div>"+
					"<div class='jou_right'><div class='jou_title'> <span class='left'>["+item.plbmDepart+"]"+item.plrHrm+"</span></div>"+
					"<div class='hide_span'>"+item.pllr+"</div><div class='hide_bottom'>"+
					"<div class='ping_left'>"+item.plsj+"</div><div class='ping_right'>"+
					"<div class='hide_ui pinglun'><img src='images/pinglun-hui.png'></div></div></div></div></div></div>";
					$(".dc_zym .dc_pl").append(html)
		    	})
		    	
		    	$.each(data.dt2, function (index, item) {
		    		var idc=item.replyid
		    		$(".dc_zym .str_ov").each(function(){
			    		var iid=$(this).attr("id")
			    		if(iid==idc){
			    			var htc="<div class='jou_ping'><div class='juo_zan_left'>"+
							"<img src='images/pinglun-zan.png'></div>"+
							"<div class='jou_zan_right'><div class='zan_rig_list'>"+
							"<div class='rig_list_img'><img src='images/on-boy.jpg'></div>"+
							"<div class='rig_list_span'><div class='rig_list_top'>"+
							"<span>["+item.plbmDepart+"]"+item.plrHrm+"</span></div>"+
							"<p>"+item.pllr+"</p><span class='rig_top_span'>"+item.plsj+"</span></div></div></div></div>";
			    			$(this).append(htc)
			    		}
			    	})
		    	})
		    })
        }
        
       
        $(".dc_home div").on("tap",function(){
        	$("textarea").blur()
        })
        
        $("body").delegate(".dc_tra .box_button", "tap", function () {  //主任务发表评论
        	var pl=$(".dc_tra .dyn_text").val()
        	var _postData = {}
        	var ddd={
        		plr:web.userid,
				pllr:pl,
				maxzrwid:maxzrwid
        	}
            _postData.strEntity = JSON.stringify(ddd)
    		console.log(_postData.strEntity)
	    	learun.httppost(config.webapi + 'learun/adms/SuperviseManager/SuperviseInfoApi/SavePl', _postData, (data) => {
	    		window.setTimeout(function(){
			    	rwpl(maxzrwid)
			    }, 500);
	    		$(".dyn_text").val("")
	    		xxk("发表成功")
	    		$(".f-scroll",window.parent.document).css("transform","translate3d(0px, 0px, 0px) translateZ(0px)")
	    	})
        })
        
        $("body").delegate(".dc_zym .box_button", "tap", function () {  //子任务发表评论
        	var pl=$(".dc_zym .dyn_text").val()
        	var _postData = {}
        	var ddd={
        		plr:web.userid,
				pllr:pl,
				maxzrwid:maxzrwid,
				minzrwid:$(this).attr("id")
        	}
        	var idc=$(this).attr("id")
            _postData.strEntity = JSON.stringify(ddd)
    		console.log(_postData.strEntity)
	    	learun.httppost(config.webapi + 'learun/adms/SuperviseManager/SuperviseInfoApi/SavePl', _postData, (data) => {
	    	 	window.setTimeout(function(){
			    	zrwpl(idc)
			    }, 500);
			    $(".dyn_text").val("")
			    xxk("发表成功")
			    $(".f-scroll",window.parent.document).css("transform","translate3d(0px, 0px, 0px) translateZ(0px)")
	    	})
        })
        
        
        $("body").delegate(".dc_zym .box_buttonc", "tap", function () {  //子任务回复评论
        	var pl=$(".dc_zym .dyn_text").val()
        	var typ=$(this).attr("type")
        	var idc=$(".dc_zym .box_button").attr("id")
        	var _postData = {}
        	var ddd={
        		plr:web.userid,
				pllr:pl,
				minzrwid:idc,
				maxzrwid:maxzrwid,
				replyid:typ
        	}
        	
            _postData.strEntity = JSON.stringify(ddd)
    		console.log(_postData.strEntity)
	    	learun.httppost(config.webapi + 'learun/adms/SuperviseManager/SuperviseInfoApi/SavePl', _postData, (data) => {
	    	 	window.setTimeout(function(){
			    	zrwpl(idc)
			    }, 500);
			    $(".dyn_text").val("")
			    $(".ducy").remove()
			    xxk("发表成功")
			    $(".f-scroll",window.parent.document).css("transform","translate3d(0px, 0px, 0px) translateZ(0px)")
	    	})
        })
        function xxk(nr){
        	var html="<div class='xxk'><div class='mui-popup mui-popup-in'><div class='mui-popup-inner'>"+
			"<div class='mui-popup-text'>"+nr+"</div></div><div class='mui-popup-buttons'>"+
			"<span class='mui-popup-button mui-popup-button-bold'>确定</span></div></div></div>";
			$("body").append(html)
        }

		$("body").delegate(".mui-popup-button", "tap", function () {
			$(".xxk").remove()
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
