/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-16 13:45
 * 描  述：DC_ASSETS_HouseRentMain
 */
var acceptClick;
var keyValue = request('keyValue');
var query;
var dbAllTable;
var Houselistselected = [];
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            page.bind();
            page.initData();

        },
        bind: function () {

            $('#dbtableGrid1').jfGrid({
                url: top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentMain/GetHouseRentList',
                headData: [
                    { label: "原单位", name: "F_Transferor", width: 150, align: "center" },
                    { label: "坐落位置", name: "F_Address", width: 200, align: "center" },
                    { label: "建筑名称", name: "F_ConstructionName", width: 100, align: "center" },
                    { label: "房屋名称", name: "F_HouseName", width: 120, align: "center" },
                    { label: "建筑面积", name: "F_ConstructionArea", width: 100, align: "center" },
                ],

                onSelectRow: function (row, isCheck) {
                    if (isCheck) {

                        var _row = { F_ConstructionName: row.F_ConstructionName, F_HouseID: row.F_HouseID, F_HouseName: row.F_HouseName, F_ConstructionArea:row.F_ConstructionArea };
                        $('#dbtableGrid2').jfGridSet('addRow', _row);
                       /* if (Houselistselected.indexOf(row.F_HouseID) == -1) {
                            Houselistselected.push(row.F_HouseId);
                            console.log(Houselistselected.length);
                        }*/

                    } else {
                      //  Houselistselected.remove(row.F_HouseId);
                      //  $('#dbtableGrid2').jfGridSet('removeRow', row.F_HouseID);
                       // console.log(Houselistselected.length);
                    }
                },

                mainId: 'F_HouseID',
                isMultiselect: true,
                multiselectfield: 'check',
                isPage: false
            });

            $('#dbtableGrid2').jfGrid({

                headData: [

                    { label: "建筑名称", name: "F_ConstructionName", width: 120, align: "center" },
                    { label: "房屋名称", name: "F_HouseName", width: 120, align: "center" },
                    { label: "建筑面积", name: "F_ConstructionArea", width: 100, align: "center" }
                   

                ],
                mainId: 'F_HouseID',
                isEdit: true,
                isPage: false
            });


            $('#DC_ASSETS_HouseRentDetail').jfGrid({
                headData: [

                   
                   
                    { label: "建筑名称", name: "F_ConstructionName", width: 100, align: "center" },
                    { label: "房屋名称", name: "F_HouseName", width: 120, align: "center" },
                    { label: "建筑面积", name: "F_ConstructionArea", width: 100, align: "center" },
                    {
                        label: '招租底价（年/元）', name: 'F_RentReservePrice', width: 150, align: "center"
                        , edit: {
                            type: 'input'
                        }
                    },
                    {
                        label: '竞租保证金（元/年）', name: 'F_RentDeposit', width: 150, align: "center"
                        , edit: {
                            type: 'input'
                        }
                    }
                ],
                mainId: 'F_HouseID',
                isEdit: true,
              
            });


            $('#wizard').wizard().on('change', function (e, data) {
                var $finish = $("#btn_finish");
                var $next = $("#btn_next");
                if (data.direction == "next") {
                    if (data.step == 1) {
                        page.search($('#txt_Keyword').val());

                    }
                 
                    else if (data.step == 3) {

                        $finish.removeAttr('disabled');
                        $next.attr('disabled', 'disabled');
                        page.bindDetail();
                    } else {
                        $finish.attr('disabled', 'disabled');
                    }
                } else {
                    $finish.attr('disabled', 'disabled');
                    $next.removeAttr('disabled');
                }
            });

            // 保存数据按钮
            $('#btn_Search').on('click', function () {
                var keyword = $('#txt_Keyword').val();
                //alert('bb')
                page.search(keyword);
            });
            $('#txt_Keyword').on("keypress", function (e) {
                if (event.keyCode == "13") {
                    var keyword = $('#txt_Keyword').val();
                   // alert('aa')
                    page.search(keyword);
                }
            });
            $("#btn_finish").on('click', acceptClick);
            $('#F_SendRole').lrselect({
                // 字段
                value: "F_HRMId",
                text: "F_RentName",
                type: 'multiple',
                // 展开最大高度
                maxHeight: 200,
                // 是否允许搜索
                allowSearch: true,
                // 访问数据接口地址
                url: top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentMain/GetMainData',
                // 访问数据接口参数
               
            });
            $('#F_RentState').lrDataItemSelect({ code: 'HouseRentState1' });
            $('#F_RentState').lrselectSet("1"); 
            $('#F_Accessories').lrUploader();


        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentMain/GetFormData?keyValue=' + keyValue, function (data) {
                    for (var id in data) {
                        if (!!data[id].length && data[id].length > 0) {
                            $('#' + id).jfGridSet('refreshdata', data[id]);
                        }
                        else {
                            $('[data-table="' + id + '"]').lrSetFormData(data[id]);
                        }
                    }
                });
            }
        },

        search: function (param) {

            learun.httpAsync('GET', top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentMain/GetHouseRentList', { queryJson: param }, function (data) {
                $('#dbtableGrid1').jfGridSet('refreshdata', data);
            });

        },
       bindDetail: function () {
           var ids = $('#F_SendRole').lrselectGet();
           var postData = {};
           var entity = $('#dbtableGrid2').jfGridGet('rowdatas')
           postData.strdC_ASSETS_HouseRentDetailList = JSON.stringify(entity);
           learun.httpAsync('Post', top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentMain/GetHouseRentDetaiList?ids='+ ids, postData, function (data) {
               $('#DC_ASSETS_HouseRentDetail').jfGridSet('refreshdata', data);
            });

        },

            CopyDetail: function () {
                var ids = $('#F_SendRole').lrselectGet();
                $.lrSaveForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentMain/SaveCopyForm?ids=' + ids,  function (res) {
                    // 保存成功后才回调
                    if (!!callBack) {
                        callBack();
                    }
                });

       }
    };
    // 保存数据
    acceptClick = function (callBack) {
        if (!$('body').lrValidform()) {
            return false;
        }
     
        if (!/^[0-9]{4}$/.test($('#F_RentYear').val())) {
            learun.alert.warning('年度格式错误 请添加20XX格式')
            return false
        }

        var entity = $('#DC_ASSETS_HouseRentDetail').jfGridGet('rowdatas');
        for (var i = 0; i < entity.length; i++) {
            var o = entity[i]
            if (!o.F_RentReservePrice || !/^\d+(\.\d+)?$/.test(o.F_RentReservePrice)) {
                learun.alert.warning('请填写正确的招租底价')
                return false
            }
            //if (!o.F_RentDeposit || !/^\d+(\.\d+)?$/.test(o.F_RentDeposit)) {
            //    learun.alert.warning('请填写正确的竞租保证金')
            //    return false
            //}
            //if (!o.F_LeaseState) {
            //    learun.alert.warning('租赁状态不能为空')
            //    return false
            //}
        }
        var postData = {};
      
        postData.strEntity = JSON.stringify($('[data-table="DC_ASSETS_HouseRentMain"]').lrGetFormData());
        postData.strdC_ASSETS_HouseRentDetailList = JSON.stringify(entity);
        $.lrSaveForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentMain/SaveForm?keyValue=' + keyValue, postData, function (res) {
           var ffd=window.parent.$("#lr_frame_main").find(".active").attr("id")
	       var bbd=$("#"+ffd,parent.document.body).attr("src")
	       $("#"+ffd,parent.document.body).attr("src",bbd)
            // 保存成功后才回调
            //if (!!callBack) {
            //    callBack();
            //}
        });
    };
    page.init();
}
