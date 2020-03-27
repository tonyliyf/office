


(function () {

    var page = {
        isScroll: true,
        init: function ($page) {

//          xtxiaoxi()  //系统消息
            function xtxiaoxi() {

                learun.httpget(config.webapi + '/learun/adms/LR_CodeDemo/DC_OA_Message/GetOAMessage', {}, function (data) {
                    console.log(data);
                    if (data) {
                        if (data.rows.length > 0) {
                            var bcd = 0
                            $(".xt_home").empty();
                            $.each(data.rows, function (index, item) {
                                
                                var html = "<div class='xt_list' id='" + item.f_strategycode+"'><div class='xt_left'><img src='images/xxx.png'/></div>" +
                                    "<div class='xt_right'><div class='xr_title'><div class='xr_left'>" + item.f_strategyname + "</div>" +
                                    "<div class='xr_right'></div></div><div class='xr_list'></div></div><div class='xt_numb'>"+item.count+"</div></div>"
                                $(".xt_home").append(html);
                                if (item.count < 0 || item.count == null) {
                                    $(".xt_numb").eq(bcd).hide()
                                }
                                bcd++
                            })

                        }

                    } else {
                        console.log("error");
                    }
                });

            }
            $('body').delegate('.xt_list', 'tap', function () {
               
                learun.nav.go({ path: 'DC_OA_Message/form', title: $(this).find(".xr_left").text(), type: 'right', param: { processId: $(this).attr("id") } });
            })

        }
    };
    return page;
})();