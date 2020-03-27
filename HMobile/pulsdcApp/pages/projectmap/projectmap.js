(function() {
	var begin = '';
    var end = '';
    var multipleData = null;
	var page = {
		grid: null,
		init: function ($page) {
			var map = new BMap.Map("mapDiv");
			var point = new BMap.Point(111.754821, 30.431865);
			map.centerAndZoom(point, 15); // 编写自定义函数，创建标注   
			map.enableScrollWheelZoom(true);
			var icon = new BMap.Icon('../../images/banner.png', new BMap.Size(25, 25), {
				anchor: new BMap.Size(10, 30)
			});
			var mkr = new BMap.Marker(new BMap.Point(111.754821, 30.431865), {
				icon: icon
			});
			map.addOverlay(mkr);
			learun.http.post(config.webapi + 'learun/adms/ProjectManager/Dc_EngineProject_info/GetProjectInfo', {}, function(res) {
				alert(data[0].F_PIId)
			});
		}

	};
	return page;
})();