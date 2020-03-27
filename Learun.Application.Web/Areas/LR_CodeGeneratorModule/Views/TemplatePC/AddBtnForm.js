/*
 * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：-前端开发组
 * 日 期：2018.05.11
 * 描 述：添加扩展按钮	
 */
var acceptClick;
var bootstrap = function ($, learun) {
    "use strict";

    // 保存数据
    acceptClick = function (callBack) {
        if (!$('#form').lrValidform()) {
            return false;
        }
        var formData = $('#form').lrGetFormData();
        if (!!callBack) {
            callBack(formData);
        }

        return true;
    };
}