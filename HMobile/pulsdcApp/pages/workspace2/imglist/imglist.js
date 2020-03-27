(function () {
    var page = {
        isScroll: true,
        init: function ($page,param) {
            keyValue = param.processId;
            var strs= new Array(); //定义一数组 
			strs=keyValue.split(","); //字符分割 
			$(".imgbox").remove()
			
			if(keyValue==null){
				
			} else {
				for (i=0;i<strs.length ;i++ ){
					var html="<div class='imgbox' type='"+i+"'><img class='img_tp' src='"+strs[i]+"' /></div>"
					$(".imglist").append(html)
				}
				$(".maxleng").val(strs.length)
//				window.setTimeout(function(){$('#dowebok').viewer();}, 1000);	
			}
			$('body').delegate('.imglist .imgbox', 'tap', function () {
				var vx=$(this).attr("type")
				tpyl(vx)
			})
			
			function tpyl(type){
				$(".imglist .imgbox").each(function(){
					var sr=$(this).find("img").attr("src")
					var tp=$(this).attr("type")
					if(tp==type){
						if($(".tp_fd").length>0){
							return false;
						} else {
							var htmlc="<div class='tp_fd'><img class='tp_gb' src='images/tpgb.png' /><div class='img_ctp'><img type='"+type+"' src='"+sr+"'/></div><div class='img_cbt'><div class='db_yl'><div class='db_bg'><div class='db_list tp_im per'></div></div><div class='db_bg'><div class='db_list tp_im rexz'></div></div><div class='db_bg'><div class='db_list tp_im next'></div></div></div></div></div>"
							$("body").append(htmlc)
						}
						return false;
					}
				})
			}
			
			$('body').delegate('.next', 'tap', function () {
				if($(".imgtype").val()==1){
					return false;
				} else{
					yyy()
				}
			})
			function yyy(){
				var leng=$(".maxleng").val()
				var tpc=$(".img_ctp img").attr("type")
				var bb=tpc*1+1
				if(leng-1==tpc){
					return false;
				} else{
					var scc=$(".imgbox").eq(bb).find("img").attr("src")
					$(".img_ctp img").attr("src",scc)
					$(".img_ctp img").attr("type",bb)
					$(".imgtype").val(1)
					window.setTimeout(function(){$(".imgtype").val(0)}, 500);	
					$(".img_ctp img").css('transform', 'rotate(0deg)');
				}
				
			}
			
			
			$('body').delegate('.per', 'tap', function () {
				if($(".imgtype").val()==1){
					return false;
				} else{
					syy()
				}
			})
			function syy(){
				var leng=$(".maxleng").val()
				var tpc=$(".img_ctp img").attr("type")
				var bb=tpc*1-1
				if(0==tpc){
					return false;
				} else {
					var scc=$(".imgbox").eq(bb).find("img").attr("src")
					$(".img_ctp img").attr("src",scc)
					$(".img_ctp img").attr("type",bb)
					$(".imgtype").val(1)
					window.setTimeout(function(){$(".imgtype").val(0)}, 500);	
//					$(".imgbox").each(function(){
//						var sr=$(this).find("img").attr("src")
//						var tp=$(this).attr("type")
//						var bb=tpc*1-1
//						if(tp==bb){
//							$(".img_ctp img").attr("src",sr)
//							$(".img_ctp img").attr("type",bb)
//							return false;
//						}
//					})
					$(".img_ctp img").css('transform', 'rotate(0deg)');
				}
			}
			
			var r=0
			$('body').delegate('.rexz', 'tap', function () {
				r += 90;
				$(".img_ctp img").css('transform', 'rotate(' + r + 'deg)');
			})
			$('body').delegate('.tp_gb', 'tap', function () {
				$(".tp_fd").remove()
			})
        }
    };
    return page;
})();