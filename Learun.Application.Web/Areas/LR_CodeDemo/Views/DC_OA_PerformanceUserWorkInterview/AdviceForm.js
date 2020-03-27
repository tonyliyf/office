var acceptClick;
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
        $.post(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceUserWorkInterview/Execute?', { advice: $('#txt_Advice').val(), cid: keyValue,r:3 }, function (res) {
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
