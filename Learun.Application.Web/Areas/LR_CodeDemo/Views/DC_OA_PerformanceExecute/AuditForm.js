var acceptClick;
var acceptClick1
var keyValue = request('keyValue');
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            $('.lr-form-wrap').lrscroll();
            page.bind();
            page.initData();
        },
        bind: function () {
        },
        initData: function () {
        }
    };
    // 保存数据
    acceptClick = function (cb) {
        $.post(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceExecute/Evaluate4', {
            wid: keyValue,
            text: $('#txt_Advice').val(),
            agree: 1,
            incScore: $('#F_AwardAddScore').val(),
            decScore: $('#F_DutyReduceScore').val(),
            resultScore: $('#F_PerformanceScore').val(),
        },
            function (res) {
                if (res.code == 200) {
                    learun.alert.success(res.info)
                } else {
                    learun.alert.error(res.info)
                }
                cb()
                learun.layerClose(window.name)
            }, 'json')
    };
    acceptClick1 = function (cb) {
        $.post(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceExecute/Evaluate4', {
            wid: keyValue,
            text: $('#txt_Advice').val(),
            agree: 2,
            incScore: $('#F_AwardAddScore').val(),
            decScore: $('#F_DutyReduceScore').val(),
            resultScore: $('#F_PerformanceScore').val(),
        },
            function (res) {
                if (res.code == 200) {
                    learun.alert.success(res.info)
                } else {
                    learun.alert.error(res.info)
                }
                cb()
                learun.layerClose(window.name)
            }, 'json')
    };
    page.init();
}
