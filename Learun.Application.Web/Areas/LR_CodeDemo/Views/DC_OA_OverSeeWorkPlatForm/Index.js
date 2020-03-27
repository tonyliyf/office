var myChart = echarts.init(document.getElementById('each_one'));
var myChartwo = echarts.init(document.getElementById('each_two'));
var option = {

    tooltip: {
        trigger: 'axis'
    },
    legend: {
        data: ['日常工作督办', '重点建设项目', '集团投资项目', '政府工作报告', '总经理办公室']
    },

    calculable: true,
    xAxis: [
        {
            type: 'category',
            data: ['1月', '2月', '3月', '4月', '5月', '6月', '7月', '8月', '9月', '10月', '11月', '12月']
        }
    ],
    yAxis: [
        {
            type: 'value'
        }
    ],
    series: [
        {
            name: '日常工作督办',
            type: 'bar',
            data: [2.0, 4.9, 7.0, 23.2, 25.6, 76.7, 135.6, 162.2, 32.6, 20.0, 6.4, 3.3],

        },
        {
            name: '重点建设项目',
            type: 'bar',
            data: [2.6, 5.9, 9.0, 26.4, 28.7, 70.7, 175.6, 182.2, 48.7, 18.8, 6.0, 2.3],

        },
        {
            name: '集团投资项目',
            type: 'bar',
            data: [2.6, 5.9, 9.0, 26.4, 28.7, 70.7, 175.6, 182.2, 48.7, 18.8, 6.0, 2.3],

        },
        {
            name: '政府工作报告',
            type: 'bar',
            data: [2.6, 5.9, 9.0, 26.4, 28.7, 70.7, 175.6, 182.2, 48.7, 18.8, 6.0, 2.3],

        },
        {
            name: '总经理办公室',
            type: 'bar',
            data: [2.6, 5.9, 9.0, 26.4, 28.7, 70.7, 175.6, 182.2, 48.7, 18.8, 6.0, 2.3],

        }
    ]
};

var option1 = {

    tooltip: {
        trigger: 'item',
        formatter: "{a} <br/>{b} : {c} ({d}%)"
    },
    legend: {
        orient: 'vertical',
        left: 'left',
        data: ['日常工作督办', '重点建设项目', '集团投资项目', '政府工作报告', '总经理办公室']
    },
    series: [
        {
            name: '访问来源',
            type: 'pie',
            radius: '55%',
            center: ['50%', '60%'],
            data: [
                { value: 335, name: '日常工作督办' },
                { value: 310, name: '重点建设项目' },
                { value: 234, name: '集团投资项目' },
                { value: 135, name: '政府工作报告' },
                { value: 1548, name: '总经理办公室' }
            ],
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






//督办任务列表
function RenderOverseeList(data) {
    var _html = ''
    $.each(data, function (i, v) {
        _html += '<li class="zs_li" data-id="' + v.id + '">\
                <div class="zs_li_left" >\
                    '+ v.name + '\
                            </div >\
                <div class="zs_li_right">\
                    '+ (v.date.length > 10 ? v.date.substr(0, 10) : v.date) + '\
                            </div>\
                        </li >'
    })
    $('#osList').html(_html)
}

//会议列表
function RenderMeettingList(data) {
    var _html = ''
    $.each(data, function (i, v) {
        _html += '<li class="zs_li" data-id="' + v.id + '">\
                <div class="zs_li_left" >\
                    '+ v.name + '-' + v.room + '\
                            </div>\
                <div class="zs_li_right">\
                  '+ (v.date.length > 10 ? v.date.substr(0, 10) : v.date) + '\
                            </div>\
                        </li >'
    })
    $('#meettingList').html(_html)
}

function RenderLineChart(data) {
    var series = []
    var legendData=[]
    for (var cate in data) {
        legendData.push(cate)
        series.push({
            name: cate,
            type: 'bar',
            data: data[cate],
        })
    }
    option.series = series
    option.legend = {data:legendData}
    myChart.setOption(option)
}

function RenderPieChart(data) {
    var legendData = []
    $.each(data, function (i, v) {
        legendData.push(v.name)
    })
    option1.legend.data = legendData
    option1.series[0].data=data
    myChartwo.setOption(option1)
}

//获取督办列表
function BindClickEvent() {
    $('.title_box').click(function () {
        $.post(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWork/GetPlatformListByState', { state: $(this).attr('state') }, function (res) {
            if (res.code == 200) {
                RenderOverseeList(res.data)
            } else {
                learun.alert.warning(res.info)
            }
        }, 'json');
    })
}
function InitData() {
    $.post(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWork/GetPlatformListByState', { state: '执行中' }, function (res) {
        if (res.code == 200) {
            RenderOverseeList(res.data)
        } else {
            top.learun.alert.warning(res.info)
        }
    }, 'json');

    $.post(top.$.rootUrl + '/LR_CodeDemo/DC_OA_Meeting/GetMeetingList', { }, function (res) {
        if (res.code == 200) {
            RenderMeettingList(res.data)
        } else {
            top.learun.alert.warning(res.info)
        }
    }, 'json');

    $.post(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWork/GetTaskByTypeAndMonth', {}, function (res) {
        if (res.code == 200) {
            RenderLineChart(res.data)
        } else {
            top.learun.alert.warning(res.info)
        }
    }, 'json');

    $.post(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWork/GetTaskPercentByCategory', {}, function (res) {
        if (res.code == 200) {
            RenderPieChart(res.data)
        } else {
            top.learun.alert.warning(res.info)
        }
    }, 'json');
}

BindClickEvent()
InitData()