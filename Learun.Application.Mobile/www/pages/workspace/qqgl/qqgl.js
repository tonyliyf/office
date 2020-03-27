(function () {
    var page = {
        isScroll: true,
        init: function ($page,param) {
            keyValue = param.processId;
            typ = param.picc;
            qqglt()
			
			function qqglt(){  //前期管理
				learun.httppost(config.webapi + 'learun/adms/ProjectManager/Dc_EngineProject_info/GetBeforeProjectInfoss', {projectid:typ,F_ProjectStage:keyValue}, function(data) {
					console.log(data)
					var zlbh="<div class='nr_list'><div class='nr_left'>资料编号：</div><div class='nr_rig'>"+data[0].F_DataCode+"</div></div>"
					var zlmc="<div class='nr_list'><div class='nr_left'>资料名称：</div><div class='nr_rig'>"+data[0].F_DataName+"</div></div>"
					
					var ks=data[0].F_PlannedStartDate
					if(ks==null||ks==""){ks=""}
					var jhwg="<div class='nr_list'><div class='nr_left'>计划开始时间：</div><div class='nr_rig'>"+ks+"</div></div>"
					
					var js=data[0].F_ActualEndDate
					if(js==null||js==""){js=""}
					var sjwg="<div class='nr_list'><div class='nr_left'>实际完成时间：</div><div class='nr_rig'>"+js+"</div></div>"
					
					if(data[0].F_Attachment||null&&data[0].F_Attachment==""){
						var fj="<div class='nr_list'><div class='nr_left '>附件：</div><div class='nr_rig'><div class='nr_an'><div id='"+data[0].F_Attachment +"' class='xm_xz qqfj'>附件下载</div></div></div></div>"
					} else{
						var fj="<div class='nr_list'><div class='nr_left'>附件：</div><div class='nr_rig'></div></div>"
					}
					
					if(data[0].F_DataPhoto||null&&data[0].F_DataPhoto==""){
						var tp="<div class='nr_list'><div class='nr_left'>图片：</div><div class='nr_rig'><div class='nr_an' id='"+data[0].F_DataPhoto+"'><div class='xm_yl'>图片预览</div></div></div></div>"
					} else {
												var tp="<div class='nr_list'><div class='nr_left'>图片：</div><div class='nr_rig'></div></div>"
					}
					$(".qqgl").append(zlbh+zlmc+jhwg+sjwg+fj+tp)
					
				});
				$(".tcbj").show()
				$(".tcct_top").show()
				
				$(".nr").hide().eq(2).show()
				$(".tcsp").text("前期信息")
				
			}
					
			$("body").delegate(".nrth .xm_xz", "tap", function () {
				var idc=$(this).attr("id")
				downFile(idc)
			})
			
			
				
			
        }
    };
    return page;
})();