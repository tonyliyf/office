/*
 * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：-前端开发组
 * 日 期：2018.05.10
 * 描 述：客户端语言包加载
 */
(function ($, learun) {
    "use strict";

    learun.language = {
        getMainCode: function () {
            return mainType;
        },
        get: function (text, callback) {
            callback(text);
        },
        getSyn: function (text) {
            return text;
        }
    };
   
})(window.jQuery, top.learun);