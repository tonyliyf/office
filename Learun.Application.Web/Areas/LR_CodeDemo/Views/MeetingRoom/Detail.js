var acceptClick;
var keyValue = request('keyValue');
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            $.get(top.$.rootUrl + '/LR_CodeDemo/MeetingRoom/GetMeettingData?keyValue=' + keyValue, function (data) {
                $('#calendar').fullCalendar({
                    header: {
                        left: 'prev,next today',
                        right: 'title'
                    },
                    defaultDate: new Date(),
                    navLinks: true, // can click day/week names to navigate views
                    editable: false,
                    eventLimit: true, // allow "more" link when too many events
                    events:data.data
                });
            },'json')      
        },
        bind: function () {
        },
        initData: function () {
        }
    };
    // 保存数据
    acceptClick = function (callBack) {
        learun.layerClose(window.name)
    };
    page.init();
}