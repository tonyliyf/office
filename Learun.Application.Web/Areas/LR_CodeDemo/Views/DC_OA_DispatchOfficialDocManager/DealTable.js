/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-12 15:16
 * 描  述：发文管理
 */
var acceptClick;
var acceptClick1;
var printClick
var keyValue = request('keyValue');
var sendtoid
var copytoid
var sendto
var copyto
var ReviewUserName
var ReviewUserId
var ProofreadUserName
var ProofreadUserId
var PrintNum
var type = request('type')
// 设置权限
var setAuthorize;
// 设置表单数据
var setFormData;
// 验证数据是否填写完整
var validForm;
// 保存数据
var save;
var bootstrap = function ($, learun) {
    "use strict";
    // 设置权限
    setAuthorize = function (data) {
    };
    var page = {
        init: function () {
            if (type == 'send') {
                $('#div_copyto').click(function () {
                    learun.layerForm({
                        id: 'treeform',
                        title: '选择抄送部门',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_DispatchOfficialDocManager/Form1?keyValue=' + keyValue + '&isSend=0',
                        width: 750,
                        height: 450,
                        callBack: function (id, res) {
                            return top[id].acceptClick(function (data) {
                                copytoid = data.ids
                                copyto = data.names
                                $('#sp_copyto').html(data.names)
                            });
                        }
                    });
                })
                $('#div_sendto').click(function () {
                    learun.layerForm({
                        id: 'treeform',
                        title: '选择发送部门',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_DispatchOfficialDocManager/Form1?keyValue=' + keyValue + '&isSend=1',
                        width: 750,
                        height: 450,
                        callBack: function (id, res) {
                            return top[id].acceptClick(function (data) {
                                sendtoid = data.ids
                                sendto = data.names
                                $('#sp_sendto').html(data.names)
                            });
                        }
                    });
                })
                $('#td_ReviewUser').click(function () {
                    learun.layerForm({
                        id: 'revirwuserform',
                        title: '请选择',
                        url: top.$.rootUrl + '/LR_OrganizationModule/User/SelectOnlyForm',
                        width: 400,
                        height: 300,
                        maxmin: true,
                        callBack: function (id) {
                            return top[id].acceptClick(function (item, id) {
                                ReviewUserName = item.text
                                ReviewUserId = item.value
                                $('#sp_ReviewUser').html(item.text)
                            });
                        }
                    });
                })
                $('#td_ProofreadUser').click(function () {
                    learun.layerForm({
                        id: 'revirwuserform',
                        title: '请选择',
                        url: top.$.rootUrl + '/LR_OrganizationModule/User/SelectOnlyForm',
                        width: 400,
                        height: 300,
                        maxmin: true,
                        callBack: function (id) {
                            return top[id].acceptClick(function (item, id) {
                                ProofreadUserName = item.text
                                ProofreadUserId = item.value
                                $('#sp_ProofreadUser').html(item.text)
                            });
                        }
                    });
                })
                $('#td_PrintNum').click(function () {
                    learun.layerForm({
                        id: 'printnumform',
                        title: '请选择',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_DispatchOfficialDocManager/Form3',
                        width: 400,
                        height: 200,
                        maxmin: true,
                        callBack: function (id) {
                            return top[id].acceptClick(function (num) {
                                $('#sp_PrintNum').html(num)
                                PrintNum = num
                            });
                        }
                    });
                })
            }
            sendtoid = $('#sendtoid').val()
            copytoid = $('#copytoid').val()
            sendto = $('#sp_sendto').html()
            copyto = $('#sp_copyto').html()
            ReviewUserName = $('#reviewname').val()
            ReviewUserId = $('#reviewid').val()
            ProofreadUserName = $('#checkname').val()
            ProofreadUserId = $('#checkid').val()
            PrintNum = $('#sp_PrintNum').html()
        },
        bind: function () {

        },
        initData: function () {

        }
    };
    acceptClick = function (callBack) {
        // debugger
        //if (sendtoid.length <= 0 || copytoid.length <= 0) {
        //    learun.alert.error('需要填写发送部门和抄送部门')
        //    return
        //}
        $.post(top.$.rootUrl + '/LR_CodeDemo/DC_OA_DispatchOfficialDocManager/SendTo', {
            keyValue: keyValue,
            sendto: sendto,
            sendtoid: sendtoid,
            copyto: copyto,
            copytoid: copytoid,
            ReviewUserName: ReviewUserName,
            ReviewUserId: ReviewUserId,
            ProofreadUserName: ProofreadUserName,
            ProofreadUserId: ProofreadUserId,
            PrintNum: PrintNum
        }, function (data) {
            if (data.code == 200) {
                learun.alert.success(data.info)
                learun.layerClose(window.name)
            } else {
                learun.alert.error(data.info)
            }
        }, 'json')
    };
    acceptClick1 = function (callBack) {
        learun.layerClose(window.name)
        callBack()
    };
    printClick = function (callBack) {
        window.print()
    }
    page.init();
}
