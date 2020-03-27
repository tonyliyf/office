/*
 * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：-前端开发组
 * 日 期：2017.04.18
 * 描 述：成员添加
 */
var tid = request('tid');

var bootstrap = function ($, learun) {
    "use strict";

    var page = {
        init: function () {
            page.bind();
            page.initData();
        },
        bind: function () {
            // 滚动条
            $('#user_list_warp').lrscroll();
        },
        initData: function () {
            $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceAppraisal/GetPostIdList?tid=' + tid, function (data) {
                if (data.userIds == "") {
                    return false;
                }
                var $warp = $('#user_list');
                var userlistselectedobj = {};
                $.each(data.userInfoList, function (id, item) {
                    if (item) {
                        userlistselectedobj[item.F_PostId] = item;
                    }
                });
                var userList = data.userIds.split(',');
                for (var i = 0, l = userList.length; i < l; i++) {
                    var userId = userList[i];
                    var item = userlistselectedobj[userId];
                    if (!!item) {
                        var imgName = "UserCard02.png";
                        //if (item.F_Gender == 0) {
                        //    imgName = "UserCard01.png";
                        //}
                        var _cardbox = "";
                        _cardbox += '<div class="card-box active " data-value="' + item.F_PostId + '" >';
                        _cardbox += '    <div class="card-box-img">';
                        _cardbox += '        <img src="' + top.$.rootUrl + '/Content/images/' + imgName + '" />';
                        _cardbox += '    </div>';
                        _cardbox += '    <div class="card-box-content">';
                        _cardbox += '        <p class="a">名称：' + item.F_Name + '</p>';
                        _cardbox += '        <p>创建人：' + item.F_CreateUserName + '</p>';
                        _cardbox += '    </div>';
                        _cardbox += '</div>';
                        $warp.append(_cardbox);
                        learun.clientdata.getAsync('department', {
                            key: item.F_DepartmentId,
                            callback: function (_data, op) {
                                $warp.find('[data-id="' + op.key + '"]').text(_data.name);
                            }
                        });
                    }
                }
            });
        }
    };
    page.init();
}