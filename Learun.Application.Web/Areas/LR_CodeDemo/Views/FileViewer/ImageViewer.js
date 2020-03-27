/* * 版 本 Learun-ADMS V7.0.0 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2018-12-31 21:17
 * 描  述：车辆信息管理
 */
var acceptClick;
var keyValue = request('fid');
var folderIdList = request('FIDS');
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {

     tpxs()
//   fgg()
    
    window.setTimeout(function(){$('#dowebok').viewer();}, 1000);
     
		function tpxs(){
			top.learun.httpAsync('GET', top.$.rootUrl + '/LR_CodeDemo/FileViewer/GetImageList', {folderIdList:folderIdList}, function (data) {
		        if (data) {
		        	console.log(data);
		        	$("#dowebok").empty();
		            if (data.length > 0) {
		                $.each(data, function (index, item) {
	                		var html="<li><img class='img_fld' src='"+item.F_FilePath+"' alt='"+item.F_FileName+"'></li>"
	                   		$("#dowebok").append(html);
		                })
		                var viewer = new Viewer(document.getElementById('dowebok'), {
					        toolbar: true,  //显示工具条
					        viewed() {
					            viewer.zoomTo(0.75);   // 图片显示比例 75%
					        },
					        show: function (){        // 动态加载图片后，更新实例
					            viewer.update();
					        }
				        });
		            }
		
		        } else {
		            console.log("error");
		        }
		    })
		}
		
		$("body").delegate(".img_fld", "click", function () {
//			$(".viewer-transition").find("li")
		})
		
		
        },
        bind: function () {
           
        },
        initData: function () {
            
        }
    };
    // 保存数据

    page.init();
}
