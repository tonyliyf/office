var acceptClick;
var keyValue = request('keyValue');
var type = request('type')
var role = request('role')
var year = ''
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            page.bind();
            page.initData();
        },
        bind: function () {
            $('#edittable').EditTable({ role: role })
            var now = new Date()
            year = now.getFullYear()
            $('#i1').val(now.getMonth() + 1)
            $('#i2').val(now.getMonth() + 1)
            $('#i3').val(1)
            $('#i4').val(now.getMonth() + 1)
            var lastDay = new Date(now.getFullYear(), now.getMonth() + 1, 0);
            $('#i5').val(lastDay.getDate())
            $('body').click(function () {
                var tscore = 0
                $('.score').each(function () {
                    var tmpscore = parseInt($(this).text())
                    if (!isNaN(tmpscore)) {
                        tscore += tmpscore
                    }
                    $('#t78').text(tscore)
                })
            })
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceCheck/GetFormData?keyValue=' + keyValue, function (data) {
                    for (var id in data) {
                        $('#edittable').EditTable('SetData', JSON.parse(data[id].F_Content))
                    }
                });
            }
        }
    };
    // 保存数据
    acceptClick = function (callBack) {
        var addZero = function (num) { return num > 9 ? num : '0' + num }
        var tableData = $('#edittable').EditTable('GetData')
        tableData.inputData.i1 = $('#i1').val()
        //debugger
        var nYear = parseInt(year);
        var nMonth = parseInt(tableData.inputData.i2);
        var nDay = parseInt(tableData.inputData.i3);
        var _nMonth = parseInt(tableData.inputData.i4);
        var _nDay = parseInt(tableData.inputData.i5);
        if (isNaN(nYear) == true || isNaN(nMonth) == true || isNaN(nDay) == true || isNaN(_nMonth) == true || isNaN(_nDay) == true) {
            learun.alert.warning('请填写正确的日期格式')
            return false;
        }
        var dtDate = new Date(nYear, nMonth - 1, nDay);
        if (nYear != dtDate.getFullYear() || (nMonth - 1) != dtDate.getMonth() || nDay != dtDate.getDate()) {
            learun.alert.warning('请填写正确的日期格式')
            return false;
        }
        dtDate = new Date(nYear, _nMonth - 1, _nDay);
        if (nYear != dtDate.getFullYear() || (_nMonth - 1) != dtDate.getMonth() || _nDay != dtDate.getDate()) {
            learun.alert.warning('请填写正确的日期格式')
            return false;
        }

        var postData = {
            strEntity: JSON.stringify({
                F_Content: JSON.stringify(tableData),
                F_CheckStartTime: nYear + '-' + addZero(nMonth) + '-' + addZero(nDay),
                F_CheckEndTime: nYear + '-' + addZero(_nMonth) + '-' + addZero(_nDay),
                F_DateLabel: nYear,
                F_TimeType: (type == 1 ? '年度' : '月度'),
                F_CheckResult: (role == 2 ? '通过' : ''),
                F_CheckNumber: (role == 2 ? +$('#t78').text() : 0)
            })
        };
        $.lrSaveForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceCheck/' + (role == 1 ? 'SaveForm' : 'SaveFormEx') + '?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
