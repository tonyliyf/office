//$(function () {
//    "use strict";

//    // 基于准备好的dom，初始化echarts实例
//    var pieChart = echarts.init(document.getElementById('piecontainer'));
//    // 指定图表的配置项和数据
//    var pieoption = {
//        tooltip: {
//            trigger: 'item',
//            formatter: "{a} <br/>{b} : {c} ({d}%)"
//        },
//        legend: {
//            bottom: 'bottom',
//            data: ['枢纽楼', 'IDC中心', '端局', '模块局', '营业厅', '办公大楼', 'C网基站']
//        },
//        series: [
//            {
//                name: '用电占比',
//                type: 'pie',
//                radius: '75%',
//                center: ['50%', '50%'],
//                label: {
//                    normal: {
//                        formatter: '{b}:{c}: ({d}%)',
//                        textStyle: {
//                            fontWeight: 'normal',
//                            fontSize: 12,
//                            color: '#333'
//                        }
//                    }
//                },
//                data: [
//                    { value: 10, name: '枢纽楼' },
//                    { value: 10, name: 'IDC中心' },
//                    { value: 10, name: '端局' },
//                    { value: 10, name: '模块局' },
//                    { value: 10, name: '营业厅' },
//                    { value: 10, name: '办公大楼' },
//                    { value: 40, name: 'C网基站' }
//                ],
//                itemStyle: {
//                    emphasis: {
//                        shadowBlur: 10,
//                        shadowOffsetX: 0,
//                        shadowColor: 'rgba(0, 0, 0, 0.5)'
//                    }
//                }
//            }
//        ]
//        ,
//        color: ['#df4d4b', '#304552', '#52bbc8', 'rgb(224,134,105)', '#8dd5b4', '#5eb57d', '#d78d2f']
//    };
//    // 使用刚指定的配置项和数据显示图表。
//    pieChart.setOption(pieoption);


//    window.onresize = function (e) {
//        pieChart.resize(e);
//        //  lineChart.resize(e);
//    }

//    $(".lr-desktop-panel").mCustomScrollbar({ // 优化滚动条
//        theme: "minimal-dark"
//    });
//});

$(".yg_box").eq(2).on('click', function () {
    window.parent.$(".lr-im-body").addClass("open");
})
$(function () {

    // Dealshow();
    Newshow();
    Noticeshow();
    setInterval(Dealshow, 1000 * 60 * 3);
    setInterval(Newshow, 1000 * 60 * 10);
    setInterval(Noticeshow, 1000 * 60 * 10);


});

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
    top.learun.httpAsync('GET', top.$.rootUrl + '/LR_OAModule/News/GetPageList', param1, function (data) {
        if (data) {
        	
            if (data.rows.length > 0) {
                $("#NewList").empty();
                $.each(data.rows, function (index, item) {
                    $("#NewList").append("<div  class='lr-msg-line' onclick='ShowNewDetail(\"" + item.F_NewsId + "\")'><span class='cat_sp'>["+item.F_CategoryId+"]</span> <a style='text-decoration: none;'>" + item.F_FullHead + "</a> <label>" + item.F_ReleaseTime.substring(0, 10) + "</label></div>");
                })
            }

        } else {

            console.log("error");

        }
    })
}



//公告显示
    function Noticeshow() {
        top.learun.httpAsync('GET', top.$.rootUrl + '/LR_OAModule/Notice/GetPageList', param1, function (data) {
            if (data) {

                if (data.rows.length > 0) {
                    $("#NoticeList").empty();
                    $.each(data.rows, function (index, item) {
                        $("#NoticeList").append("<div  class='lr-msg-line' onclick='ShowNewDetail(\"" + item.F_NewsId + "\")'><span class='cat_sp'>["+item.F_CategoryId+"]</span> <a style='text-decoration: none;'>" + item.F_FullHead + "</a> <label>" + item.F_ReleaseTime.substring(0, 10) + "</label></div>");
                    })
                }

            } else {

                console.log("error");

            }
        })
    }





