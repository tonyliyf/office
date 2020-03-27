/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-12 15:16
 * 描  述：发文管理
 */
var printClick
var acceptClick1
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

        },
        bind: function () {

        },
        initData: function () {

        }
    };
    printClick = function (callBack) {
        window.print()
    }
    acceptClick1 = function (callBack) {
        learun.layerClose(window.name)
        callBack()
    };
    page.init();
}
