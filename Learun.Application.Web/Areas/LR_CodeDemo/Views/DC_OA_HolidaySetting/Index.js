function fix0(num) {
    return num >= 10 ? num : "0" + num;
}
function format(time) {
    return time.getFullYear() + "-" + fix0((time.getMonth() + 1)) + "-" + fix0(time.getDate());
}
var currentTime = format(new Date())
var ResetCalendar = function (time) {
    $.get(top.$.rootUrl + '/LR_CodeDemo/DC_OA_HolidaySetting/GetHolidayDataByMonth?time=' + time, function (data) {
        $('#calendar').fullCalendar('removeEvents')
        var events = data.data.map(function (item) {
            var isWork = item.DC_OA_IsWork == 0
            var time = new Date(item.DC_OA_Date)
            return {
                start: format(time),
                title: item.DC_OA_Remarks,
                textColor: 'white',
                color: isWork ? '' : 'green'
            }
        })
        $('#calendar').fullCalendar('addEventSource', events)
    }, 'json')
}

var init = function (learun) {
    var now = new Date()
    $.get(top.$.rootUrl + '/LR_CodeDemo/DC_OA_HolidaySetting/GetHolidayDataByMonth?time=' +
        format(now)
        , function (data) {
            $('#calendar').fullCalendar('removeEvents')
            var events = data.data.map(function (item) {
                var isWork = item.DC_OA_IsWork == 0
                var time = new Date(item.DC_OA_Date)
                currentTime = format(time)
                return {
                    start: currentTime,
                    title: item.DC_OA_Remarks,
                    textColor: 'white',
                    color: isWork ? '' : 'green'
                }
            })
            $('#calendar').fullCalendar({
                customButtons: {
                    myPrev: {
                        text: '上月',
                        click: function () {
                            $('#calendar').fullCalendar('prev')
                            var moment = $('#calendar').fullCalendar('getDate')
                            currentTime = moment.format()
                            ResetCalendar(currentTime)
                        }
                    },
                    myNext: {
                        text: '下月',
                        click: function () {
                            $('#calendar').fullCalendar('next')
                            var moment = $('#calendar').fullCalendar('getDate')
                            currentTime = moment.format()
                            ResetCalendar(currentTime)
                        }
                    }
                },
                header: {
                    right: 'myPrev,myNext',
                    left: 'title'
                },
                height: $(window).height(),
                defaultDate: new Date(),
                navLinks: true, // can click day/week names to navigate views
                editable: false,
                eventLimit: true, // allow "more" link when too many events,
                dayClick: function (date, jsEvent, view) {
                    var keyValue = format(date._d)
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_HolidaySetting/Form?keyValue=' + keyValue,
                        width: 600,
                        height: 300,
                        callBack: function (id) {
                            return top[id].acceptClick(function () {
                                ResetCalendar(currentTime)
                            });
                        }
                    })

                },
                events: events
            });
        }, 'json')

}



var acceptClick;
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init:init,
        bind: function () {
        },
        initData: function () {
        }
    };
    // 保存数据
    acceptClick = function (callBack) {
        learun.layerClose(window.name)
    };
    page.init(learun);
}