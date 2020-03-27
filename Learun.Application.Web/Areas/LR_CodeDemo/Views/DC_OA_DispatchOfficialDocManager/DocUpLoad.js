





/*
 * 版 本 Learun-ADMS V7.0.3 敏捷开 发 框架(http://www.learun.cn)
 * Copyright (c) 2013-2018  信息技术有限公司
 * 创建人：-前端开发组
 * 日 期：2017.05.24
 * 描 述：lr-uploader 表单附件选择插件
 */
(function ($, learun) {
    "use strict";
    $.DocUploader = {
        init: function ($self) {
            var dfop = $self[0]._lrUploader.dfop;
            $.DocUploader.initRender($self, dfop);
        },
        initRender: function ($self, dfop) {
            $self.attr('type', 'lr-Uploader').addClass('lrUploader-wrap');
            var $wrap = $('<div class="lrUploader-input" ></div>');

            var $btnGroup = $('<div class="lrUploader-btn-group"></div>');
            var $uploadBtn = $('<a id="lrUploader_uploadBtn_' + dfop.id + '" class="btn btn-success lrUploader-input-btn">上传</a>');
            var $editBtn = $('<a id="lrUploader_editBtn_' + dfop.id + '" class="btn btn-primary lrUploader-input-btn">在线编辑</a>');
            var $downBtn = $('<a id="lrUploader_downBtn_' + dfop.id + '" class="btn btn-danger lrUploader-input-btn">下载</a>');
            var $infoBtn = $('<a id="lrUploader_infoBtn_' + dfop.id + '" class="btn btn-primary lrUploader-input-btn">在线查看</a>');
            $self.append($wrap);
            if (dfop.editOnline) {
                $btnGroup.append($editBtn);
            }
            if (dfop.upLoad) {
                $btnGroup.append($uploadBtn);
            }
            if (dfop.downLoad) {
                $btnGroup.append($downBtn);
            }
            if (dfop.info) {
                $btnGroup.append($infoBtn);
            }
            if (dfop.defaultUpload) {
                $uploadBtn.on('click', $.DocUploader.openUploadFormDefault);
            } else {
                $uploadBtn.on('click', $.DocUploader.openUploadForm);
            }


            $self.append($btnGroup);

            $editBtn.on('click', $.DocUploader.openeditForm);
            $downBtn.on('click', $.DocUploader.openDownForm);
            $infoBtn.on('click', $.DocUploader.openInfoForm);

        },
        openUploadForm: function () {
            var $btn = $(this);
            var $self = $btn.parents('.lrUploader-wrap');
            var dfop = $self[0]._lrUploader.dfop;
            learun.layerForm({
                id: dfop.id,
                title: dfop.placeholder,
                url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_DispatchOfficialDocManager/UploadForm?keyVaule=' + dfop.value + "&extensions=" + dfop.extensions,
                width: 600,
                height: 400,
                maxmin: true,
                btn: null,
                end: function () {
                    learun.httpAsyncGet(top.$.rootUrl + '/LR_SystemModule/Annexes/GetFileNames?folderId=' + dfop.value, function (res) {
                        if (res.code == learun.httpCode.success) {
                            $('#' + dfop.id).find('.lrUploader-input').text(res.info);
                        }
                    });
                }
            });
        },
        openUploadFormDefault: function () {
            var $btn = $(this);
            var $self = $btn.parents('.lrUploader-wrap');
            var dfop = $self[0]._lrUploader.dfop;
            learun.layerForm({
                id: dfop.id,
                title: dfop.placeholder,
                url: top.$.rootUrl + '/LR_SystemModule/Annexes/UploadForm?keyVaule=' + dfop.value + "&extensions=" + dfop.extensions,
                width: 600,
                height: 400,
                maxmin: true,
                btn: null,
                end: function () {
                    learun.httpAsyncGet(top.$.rootUrl + '/LR_SystemModule/Annexes/GetFileNames?folderId=' + dfop.value, function (res) {
                        if (res.code == learun.httpCode.success) {
                            $('#' + dfop.id).find('.lrUploader-input').text(res.info);
                        }
                    });
                }
            });
        },
        openeditForm: function () {
            var $btn = $(this);
            var $self = $btn.parents('.lrUploader-wrap');
            var dfop = $self[0]._lrUploader.dfop;
            $.get(top.$.rootUrl + '/LR_SystemModule/Annexes/GetAnnexesFileList?folderId=' + dfop.value, function (data) {
                if (data.data && data.data.length > 0) {
                    var loginInfo = learun.clientdata.get(['userinfo']);
                    var strRoot = window.location.protocol + "//" + window.location.host
                    var vb = $.DocUploader.getBrowser()
                    var url = (vb ? 'WebOffice://|Officectrl|' : '') + strRoot + '/LR_CodeDemo/WebOffice/Index?fileId=' + data.data[0].F_Id + '&t=' +loginInfo.realName + '&type=edit'
                    window.open(url, vb ? '_self' : '_blank')
                } else {
                    learun.alert.error('您还没有上传文档！')
                }
            }, 'json')
        },
        openInfoForm: function () {
            var $btn = $(this);
            var $self = $btn.parents('.lrUploader-wrap');
            var dfop = $self[0]._lrUploader.dfop;
            $.get(top.$.rootUrl + '/LR_SystemModule/Annexes/GetAnnexesFileList?folderId=' + dfop.value, function (data) {
                if (data.data && data.data.length > 0) {
                    var loginInfo = learun.clientdata.get(['userinfo']);
                    var strRoot = window.location.protocol + "//" + window.location.host
                    var vb = $.DocUploader.getBrowser()
                    var url = (vb ? 'WebOffice://|Officectrl|' : '') + strRoot + '/LR_CodeDemo/WebOffice/PrintDoc?keyValue=' + data.data[0].F_Id + '&t=' + loginInfo.realName + '&type=wfinfo'
                    window.open(url, vb ? '_self' : '_blank')
                } else {
                    learun.alert.error('您还没有上传文档！')
                }
            }, 'json')
        },
        openDownForm: function () {
            var $btn = $(this);
            var $self = $btn.parents('.lrUploader-wrap');
            var dfop = $self[0]._lrUploader.dfop;
            learun.layerForm({
                id: dfop.id,
                title: dfop.placeholder,
                url: top.$.rootUrl + '/LR_SystemModule/Annexes/DownForm?keyVaule=' + dfop.value,
                width: 600,
                height: 400,
                maxmin: true,
                btn: null
            });
        },
        getBrowser: function () {
            var Sys = {};
            var ua = navigator.userAgent.toLowerCase();
            var s;
            var ver;
            (s = ua.match(/edge\/([\d.]+)/)) ? Sys.edge = s[1] :
                (s = ua.match(/rv:([\d.]+)\) like gecko/)) ? Sys.ie = s[1] :
                    (s = ua.match(/msie ([\d.]+)/)) ? Sys.ie = s[1] :
                        (s = ua.match(/firefox\/([\d.]+)/)) ? Sys.firefox = s[1] :
                            (s = ua.match(/chrome\/([\d.]+)/)) ? Sys.chrome = s[1] :
                                (s = ua.match(/opera.([\d.]+)/)) ? Sys.opera = s[1] :
                                    (s = ua.match(/version\/([\d.]+).*safari/)) ? Sys.safari = s[1] : 0;
            if (Sys.edge) return 1;
            if (Sys.ie) return 0;
            if (Sys.firefox) return 1;
            if (Sys.chrome) { ver = Sys.chrome; ver.toLowerCase(); var arr = ver.split('.'); if (parseInt(arr[0]) > 43) { return 1; } else { return 0; } }
            if (Sys.opera) return 1;
            if (Sys.safari) return 1;
            return 1;
        }
    };

    $.fn.DocUploader = function (op) {
        var $this = $(this);
        if (!!$this[0]._lrUploader) {
            return $this;
        }
        var dfop = {
            placeholder: '上传文档',
            isUpload: true,
            extensions: 'doc,docx',
            editOnline: false,
            upLoad: false
        }

        $.extend(dfop, op || {});
        dfop.id = $this.attr('id');
        dfop.value = learun.newGuid();

        $this[0]._lrUploader = { dfop: dfop };
        $.DocUploader.init($this);
    };

    $.fn.lrUploaderSet = function (value) {
        var $self = $(this);
        var dfop = $self[0]._lrUploader.dfop;
        dfop.value = value;
        learun.httpAsyncGet(top.$.rootUrl + '/LR_SystemModule/Annexes/GetFileNames?folderId=' + dfop.value, function (res) {
            if (res.code == learun.httpCode.success) {
                $('#' + dfop.id).find('.lrUploader-input').text(res.info);
            }
        });
    }

    $.fn.lrUploaderGet = function () {
        var $this = $(this);
        var dfop = $this[0]._lrUploader.dfop;
        return dfop.value;
    }
})(jQuery, top.learun);
