(function () {
    var keyValue = '';
    var page = {
        isScroll: true,
        init: function ($page, param) {

            keyValue = param.processId;

            mlist()

            $("body").delegate(".type_list", "click", function () {

                $(".type_list").removeClass("type_style");
                $(this).addClass("type_style");
                mlist()
            })

            function mlist() {
                var yd;
                if ($(".type_style").text().trim() == "全部") {
                    yd = ""
                } else {
                    yd = 1;
                }

                var _postParam = JSON.stringify({
                    pagination: {
                        rows: 50,
                        page: 1,
                        sidx: 'F_CreateDate desc',
                        sord: 'DESC'
                    },
                      code: keyValue,
                        isRead: yd
                  
                });
                

                learun.httpget(config.webapi + '/learun/adms/LR_CodeDemo/DC_OA_Message/GetMessageList', _postParam, (data) => {
                    console.log(_postParam)
                    console.log(data)
                    $(".tx_home").empty();

                    if (data) {
                        if (data.rows.length > 0) {

                            $.each(data.rows, function (index, item) {
                                var dd = item.F_StrategyName;
                                var dq;
                                var src = "quanbu.png";

                                if (yd == 1) {
                                    dq = "已读"
                                } else {
                                    dq = "未读"
                                }
                                var html = " <div class='tx_list' id='" + item.F_MessageId + "'><div class='tx_time'>" + item.F_CreateDate + "</div><div class='tx_bot'>" +
                                    "<div class='tx_bot_title'><div class='tx_bot_left'> " + item.FromUserName + "</div><div class='tx_bot_right'>" + item.F_CreateDate + "</div> </div>" +
                                    "<div class='tx_bot_cen'>" + item.SendContent + "</div>" +
                                    "<div class='tx_butt'> <span>"+dq+"</span>  <img src='images/right_arr.png' /></div> </div></div>"
                                $(".tx_home").append(html);

                            })
                        }

                    } else {
                        console.log("error");
                    }
                })
            }

            $("body").delegate(".tx_list", "click", function () {
                var cid = $(this).attr("id")

                qryd(cid)
            })

            function qryd(cid) {
                
                if ($(".type_style").text().trim() == "全部") {
                    learun.httppost(config.webapi + '/learun/adms/LR_CodeDemo/DC_OA_Message/EnterMessage',  cid , (data) => {
                        mlist()
                      
                    })
                }
            }

        }
    };
    return page;
})();