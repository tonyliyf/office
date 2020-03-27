(function () {
    var page = {
        isScroll: true,
        init: function ($page,param) {
            keyValue = param.processId;
            typ = param.picc;
            htxxx()
			function htxxx(){  //合同信息
				learun.httppost(config.webapi + 'learun/adms/ProjectManager/Dc_EngineProject_info/GetProjectContractInfo', {projectid:"",F_ItemValue:"",F_PICId:typ}, function(data) {
					console.log(data)
					$(".tcct_top").show()
					$(".tcsp").text("合同信息")
					$(".box_list").hide()
					$(".nr").eq(1).find(".xm_list").remove()
					
					$.each(data.data, function (index, item) {
			        		var qdsj=item.f_signingtime.substring(0,10)
							var htlx="<div class='nr_list'><div class='nr_left'>合同类型：</div>"+
							"<div class='nr_rig'>"+item.f_contracttype+"</div></div>";
							var xmbh="<div class='nr_list'><div class='nr_left'>合同编号：</div>"+
							"<div class='nr_rig'>"+item.f_contractcode+"</div></div>";
							var type=item.f_contractappendices
							if(type==null){
								type=""
								var htmc="<div class='nr_list'><div class='nr_left'>合同名称：</div>"+
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
							$(".heet").append("<div class='bus_list'>"+htmc+xmbh+htje+jsfs+fkss+qdsj+"</div>")
						
						
					})
					
					
//					var hei=$(".nr").eq(1).outerHeight();
//					$(".tcbj").css("height",hei-vc)
					$(".tcbj").show()
					$(".nr").hide().eq(1).show()
					
				});
			}
			
        }
    };
    return page;
})();