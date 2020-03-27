/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-08-16 10:22
 * 描  述：DC_ASSETS_HouseInfofood
 */
var selectedRow;
var refreshGirdData;
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            page.initGird();
            page.bind();
        },
        bind: function () {
            // 查询
            $('#btn_Search').on('click', function () {
                var keyword = $('#txt_Keyword').val();
                page.search({ keyword: keyword });
            });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                selectedRow = null;
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseInfofood/Form',
                    width: 700,
                    height: 400,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_HouseID');
                selectedRow = $('#gridtable').jfGridGet('rowdata');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseInfofood/Form?keyValue=' + keyValue,
                        width: 700,
                        height: 400,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_HouseID');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseInfofood/DeleteForm', { keyValue: keyValue}, function () {
                            });
                        }
                    });
                }
            });
        },
        initGird: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseInfofood/GetPageList',
                headData: [
                        { label: '主键', name: 'F_HouseID', width: 200, align: "left" },
                        { label: '建筑基本信息表主键', name: 'F_BBIId', width: 200, align: "left" },
                        { label: '单元编码，楼栋编号+单元编号', name: 'F_UnitCode', width: 200, align: "left" },
                        { label: '资产编号，取系统资产编号编码', name: 'F_AssetsNumber', width: 200, align: "left" },
                        { label: '单元编码，楼栋编号+单元编号+楼层编号+房屋编号', name: 'F_HouseCode', width: 200, align: "left" },
                        { label: '房屋名称', name: 'F_HouseName', width: 200, align: "left" },
                        { label: '单元号', name: 'F_UnitNumber', width: 200, align: "left" },
                        { label: '楼层号', name: 'F_FloorNumber', width: 200, align: "left" },
                        { label: '房间号', name: 'F_RoomNumber', width: 200, align: "left" },
                        { label: '房间用途分类，取值于数据字典，如成套住宅、非成套住宅、集体宿舍、商业服务、办公、经营、公共设施等', name: 'F_UseCategories', width: 200, align: "left" },
                        { label: '房屋使用性质，取值于数据字典，如自住房、出租房、商用房屋等', name: 'F_RoomUsage', width: 200, align: "left" },
                        { label: '房产地址', name: 'F_BuildingAddress', width: 200, align: "left" },
                        { label: '房产证发证机关', name: 'F_ProofUnit', width: 200, align: "left" },
                        { label: '房产证号', name: 'F_CertificateNo', width: 200, align: "left" },
                        { label: '房产证发放日期', name: 'F_ProofDate', width: 200, align: "left" },
                        { label: '产权人姓名', name: 'F_PropertyOwner', width: 200, align: "left" },
                        { label: '产权人联系电话', name: 'F_PropertyOwnerPhone', width: 200, align: "left" },
                        { label: '产权人证件类型，取值于数据字典，如身份证、居住证、签证、护照、户口本、军人证、团员证、党员证、港澳通行证等', name: 'F_PropertyOwnerCertificateType', width: 200, align: "left" },
                        { label: '产权人证件号', name: 'F_PropertyOwnerCerfificateNo', width: 200, align: "left" },
                        { label: '购置日期', name: 'F_PurchaseDate', width: 200, align: "left" },
                        { label: '使用状态', name: 'F_UseStatus', width: 200, align: "left" },
                        { label: '房屋面积', name: 'F_HouseArea', width: 200, align: "left" },
                        { label: '房屋出租用途，取值于数据字典，如门店、个人居住、单位办公、商用、生产、商住两用、其他', name: 'F_RentPurpose', width: 200, align: "left" },
                        { label: '招租年限', name: 'F_RentAge', width: 200, align: "left" },
                        { label: '图片附件', name: 'F_PictureAccessories', width: 200, align: "left" },
                        { label: '有效状态, 0:有效；1：无效；默认0', name: 'F_IfUse', width: 200, align: "left" },
                        { label: '备注', name: 'F_Remarks', width: 200, align: "left" },
                        { label: '房屋租赁备案证', name: 'F_Fwzlbaz', width: 200, align: "left" },
                        { label: '危房等级，取值于数据字典，如A级、B级、C级', name: 'F_RentCertificateNo', width: 200, align: "left" },
                        { label: '录入部门主键', name: 'F_CreateDepartmentId', width: 200, align: "left" },
                        { label: '录入部门', name: 'F_CreateDepartment', width: 200, align: "left" },
                        { label: '录入人主键', name: 'F_CreateUserid', width: 200, align: "left" },
                        { label: '录入人', name: 'F_CreateUser', width: 200, align: "left" },
                        { label: '录入时间', name: 'F_CreateDatetime', width: 200, align: "left" },
                        { label: '土地证号', name: 'F_LandCertificateNo', width: 200, align: "left" },
                        { label: '账面价值', name: 'F_BuildingValue', width: 200, align: "left" },
                        { label: '土地面积', name: 'F_LandArea', width: 200, align: "left" },
                        { label: '权力人', name: 'F_PowerOwner', width: 200, align: "left" },
                        { label: '共有情况', name: 'F_Situation', width: 200, align: "left" },
                        { label: '坐落地址', name: 'F_Address', width: 200, align: "left" },
                        { label: '权力性质', name: 'F_PoweNervous', width: 200, align: "left" },
                        { label: '使用年限', name: 'F_UtilizeAge', width: 200, align: "left" },
                ],
                mainId:'F_HouseID',
                isPage: true
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            $('#gridtable').jfGridSet('reload', { queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
