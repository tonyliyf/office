// 有关“空白”模板的简介，请参阅以下文档:
// http://go.microsoft.com/fwlink/?LinkID=397704
// 若要在 cordova-simulate 或 Android 设备/仿真器上在页面加载时调试代码: 启动应用，设置断点，
// 然后在 JavaScript 控制台中运行 "window.location.reload()"。
//document.addEventListener('deviceready', () => {
//    let chcp = window.chcp;

//    // 检测更新
//    chcp.fetchUpdate((error, data) => {

//        if (!error) {
//            //alert("有更新");
//            chcp.installUpdate(function (error) {
//                //alert("更新完成");
//            })
//        } else if (error) {
//            console.log('--更新版本异常，或其他错误--', error.code, error.description);
//            if (error.code === -2) {
//                var dialogMessage = '有新的版本是否下载';
//                //调用升级提示框 点击确认会跳转对应商店升级
//                chcp.requestApplicationUpdate(dialogMessage, null, null);
//            }
//        }
//        // 服务器版本信息
//        // console.log('--更新的版本信息--', data.config);
//        // 版本信息
//        chcp.getVersionInfo((err, data) => {

//            console.log('服务器应用时间版本: ' + data.readyToInstallWebVersion);

//            console.log('当前应用时间版本： ' + data.currentWebVersion);

//            console.log('当前应用version name: ' + data.appVersion);

//        });

//    });
//});

(function ($, learun) {
    "use strict";
    // 初始化页面
    var tabdata = [
        {
            page: 'workspace',
            text: '领导驾驶舱',
            img: 'images/tab10.png',
            fillimg: 'images/tab11.png'
        },
        
        {
            page: 'my',
            text: '我的',
            img: 'images/tab40.png',
            fillimg: 'images/tab41.png'
        }
    ]; 
    
    learun.httpget(config.webapi + '/learun/adms/apputil/info', {}, function (data) {
    	
        if (data) {
        	$(".bbh").val(data.data.version)
        	$(".url").val(data.data.Url)

        } else {
            console.log("error");
        }
    });

    learun.init(function () {
        /*
        //获取通知权限
        Notification.requestPermission().then(function (permission) {
            if (permission === 'granted') {
                console.log('用户允许通知');
            } else if (permission === 'denied') {
                console.log('用户拒绝通知');
            }
        });
        */
        // 处理 Cordova 暂停并恢复事件
        document.addEventListener('pause', onPause.bind(this), false);
        document.addEventListener('resume', onResume.bind(this), false);
        learun.tab.init(tabdata);

        var logininfo = learun.storage.get('logininfo');
        if (logininfo) {// 有登录的token
            //    //监测后台服务链接是否正常（暂时用这个）
            //    learun.clientdata.get('user', {
            //        key: logininfo.account,
            //        callback: function (data) {
//          learun.tab.go('workspace');
            learun.tab.go('workspace');
            //        }
            //    });
        }
        else {
            learun.nav.go({ path: 'login', isBack: false, isHead: false });
        }
        learun.splashscreen.hide();
    });

    function onPause() {
        // TODO: 此应用程序已挂起。在此处保存应用程序状态。
    }

    function onResume() {
        // TODO: 此应用程序已重新激活。在此处还原应用程序状态。
    }

})(window.jQuery, window.lrmui);
(function ($, learun) {
//  var getContacts = function () {
//      learun.httpget(config.webapi + "/learun/adms/LR_CodeDemo/DC_OA_Message/GetOAMessage", {}, (data) => {
//          if (data) {
//              if (data.rows && data.rows.length > 0) {
//                  $('body>div.lr-tabbar>.lr-tab-button[data-value="DC_OA_Message"]>span.point').show()
//              }
//          }
//          timeOutId = setTimeout(function () {
//              getContacts();
//          }, 30000);// 30s钟遍历一次在当前界面的情况下
//      });
//  };
//  getContacts()
})(window.jQuery, window.lrmui)