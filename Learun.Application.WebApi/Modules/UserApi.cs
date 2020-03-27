using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using Learun.Application.Base.SystemModule;
using Learun.Application.Organization;
using Learun.Util;
using Learun.Util.Operat;
using Nancy;

namespace Learun.Application.WebApi
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创建人：力软-框架开发组
    /// 日 期：2017.05.12
    /// 描 述：用户信息
    /// </summary>
    public class UserApi : BaseApi
    {
        private AnnexesFileIBLL annexesFileIBLL = new AnnexesFileBLL();
        /// <summary>
        /// 注册接口
        /// </summary>
        public UserApi()
            : base("/learun/adms/user")
        {
            Post["/login"] = Login;
            Post["/facelogin"] = FaceLogin;
            Post["/UploadFile"] = UploadFile;
            Post["/modifypw"] = ModifyPassword;

            Get["/info"] = Info;
            Get["/map"] = GetMap;
            Get["/img"] = GetImg;
        }
        private UserIBLL userIBLL = new UserBLL();
        private PostIBLL postIBLL = new PostBLL();
        private RoleIBLL roleIBLL = new RoleBLL();



        private Response FaceLogin(dynamic _)
        {
            LogEntity logEntity = new LogEntity();
            logEntity.F_CategoryId = 1;
            logEntity.F_OperateTypeId = ((int)OperationType.Login).ToString();
            logEntity.F_OperateType = EnumAttribute.GetDescription(OperationType.Login);
            logEntity.F_OperateTime = DateTime.Now;
            logEntity.F_Description = "mobile0";
            logEntity.WriteLog();

            var files = (List<HttpFile>)this.Context.Request.Files;
            //var folderId = this.GetReqData();
           // return Success(files.Count.ToString());

            string filePath = Config.GetValue("fileHeadImgTemp");
            string uploadDate = DateTime.Now.ToString("yyyyMMdd");
           // return Success(files[0].Name);
            string FileEextension = Path.GetExtension(files[0].Name);
            string fileGuid = Guid.NewGuid().ToString();

            string virtualPath = string.Format("{0}/{1}/{2}{3}", filePath, uploadDate, fileGuid, ".png");

            //创建文件夹
            string path = Path.GetDirectoryName(virtualPath);
            Directory.CreateDirectory(path);
                      
                byte[] bytes = new byte[files[0].Value.Length];
                files[0].Value.Read(bytes, 0, bytes.Length);
                FileInfo file = new FileInfo(virtualPath);
                FileStream fs = file.Create();
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
            // var facefileid = this.GetReqData();
            //var facefile = annexesFileIBLL.GetEntity(facefileid);
            // LoginModel loginModel = this.GetReqData<LoginModel>();
            //return Success(virtualPath);

            #region 内部账户验证
            //  UserEntity userEntity = userIBLL.CheckLogin(loginModel.username, loginModel.password);
            UserEntity userEntity = userIBLL.FaceLogin(virtualPath);

            //  return Success("bb"+ virtualPath);

            #region 写入日志
            // logEntity = new LogEntity();
            // logEntity.F_CategoryId = 1;
            // logEntity.F_OperateTypeId = ((int)OperationType.Login).ToString();
            // logEntity.F_OperateType = EnumAttribute.GetDescription(OperationType.Login);
            //// logEntity.F_OperateAccount = loginModel.username + "(" + userEntity.F_RealName + ")";
            // logEntity.F_OperateUserId =string.Empty;
            // logEntity.F_OperateTime = DateTime.Now;
            // logEntity.F_Description = "mobile1";
            // logEntity.F_Module = Config.GetValue("SoftName");
            #endregion

          //  File.Delete(virtualPath);
            if (!userEntity.LoginOk)//登录失败
            {
                ////写入日志
                //logEntity.F_ExecuteResult = 0;
                //logEntity.F_ExecuteResultJson = "登录失败:" + userEntity.LoginMsg;
                //logEntity.F_Description = "mobile2";
                //logEntity.WriteLog();
                return Fail(userEntity.LoginMsg);
            }
            else
            {
                //return Success(userEntity.F_Account);
                
                string token = OperatorHelper.Instance.AddLoginUser(userEntity.F_Account, "Learun_ADMS_6.1_App", this.loginMark, false);//写入缓存信息
                //写入日志
                //logEntity.F_ExecuteResult = 1;
                //logEntity.F_ExecuteResultJson = "登录成功";
                //logEntity.F_Description = "mobile3";
                //logEntity.WriteLog();

                OperatorResult res = OperatorHelper.Instance.IsOnLine(token, this.loginMark);
                res.userInfo.password = null;
                res.userInfo.secretkey = null;
                //logEntity = new LogEntity();
                //logEntity.F_CategoryId = 1;
                //logEntity.F_OperateTypeId = ((int)OperationType.Login).ToString();
                //logEntity.F_OperateType = EnumAttribute.GetDescription(OperationType.Login);
                //logEntity.F_OperateAccount = userEntity.F_RealName;
                //logEntity.F_OperateUserId = userEntity.F_UserId;
                //logEntity.F_OperateTime = DateTime.Now;

                var jsonData = new
                {
                    baseinfo = res.userInfo,
                    post = postIBLL.GetListByPostIds(res.userInfo.postIds),
                    role = roleIBLL.GetListByRoleIds(res.userInfo.roleIds)
                };
                //logEntity.F_Description = "mobile4";
                //logEntity.WriteLog();
                return Success(jsonData);
            }
            #endregion


        }

        public Response UploadFile(dynamic _)
        {
            HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            //没有文件上传，直接返回
            if (files[0].ContentLength == 0 || string.IsNullOrEmpty(files[0].FileName))
            {
                return Fail("人脸采集图像失败，请重新采集！");
            }

            string FileEextension = Path.GetExtension(files[0].FileName);
            string fileHeadImg = Config.GetValue("fileHeadImg");
            string fullFileName = string.Format("{0}/{1}{2}", fileHeadImg, userInfo.userId, FileEextension);
            //创建文件夹，保存文件
            string path = Path.GetDirectoryName(fullFileName);
            Directory.CreateDirectory(path);
            files[0].SaveAs(fullFileName);

            UserEntity userEntity = new UserEntity();
            userEntity.F_UserId = userInfo.userId;
            userEntity.F_Account = userInfo.account;
            userEntity.F_HeadIcon = FileEextension;
            userIBLL.SaveEntity(userEntity.F_UserId, userEntity);
            return Success("人脸采集成功。");
        }



        /// <summary>
        /// 登录接口
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response Login(dynamic _)
        {
            try
            {
            LogEntity logEntity = new LogEntity();
            logEntity.F_CategoryId = 1;
            logEntity.F_OperateTypeId = ((int)OperationType.Login).ToString();
            logEntity.F_OperateType = EnumAttribute.GetDescription(OperationType.Login);
            logEntity.F_OperateTime = DateTime.Now;
            logEntity.F_Description = "mobile0";
            logEntity.WriteLog();


            LoginModel loginModel = this.GetReqData<LoginModel>();

            LogUtil.WriteTextLog("login", "loginModel.username:" + loginModel.username + "--- loginModel.password" + loginModel.password, DateTime.Now);
            #region 内部账户验证
            UserEntity userEntity = userIBLL.CheckLogin(loginModel.username, loginModel.password);

                #region 写入日志
                //logEntity = new LogEntity();
                //logEntity.F_CategoryId = 1;
                //logEntity.F_OperateTypeId = ((int)OperationType.Login).ToString();
                //logEntity.F_OperateType = EnumAttribute.GetDescription(OperationType.Login);
                //logEntity.F_OperateAccount = loginModel.username + "(" + userEntity.F_RealName + ")";
                //logEntity.F_OperateUserId = !string.IsNullOrEmpty(userEntity.F_UserId) ? userEntity.F_UserId : loginModel.username;
                //logEntity.F_OperateTime = DateTime.Now;
                //logEntity.F_Description = "mobile1";
                //logEntity.F_Module = Config.GetValue("SoftName");
                #endregion

                if (!userEntity.LoginOk)//登录失败
                {
                    //写入日志
                    //logEntity.F_ExecuteResult = 0;
                    //logEntity.F_ExecuteResultJson = "登录失败:" + userEntity.LoginMsg;
                    //logEntity.F_Description = "mobile2";
                    //logEntity.WriteLog();
                    return Fail(userEntity.LoginMsg);
                }
                else
                {
                    string token = OperatorHelper.Instance.AddLoginUser(userEntity.F_Account, "Learun_ADMS_6.1_App", this.loginMark, false);//写入缓存信息
                                                                                                                                            ////写入日志
                                                                                                                                            //logEntity.F_ExecuteResult = 1;
                                                                                                                                            //logEntity.F_ExecuteResultJson = "登录成功";
                                                                                                                                            //logEntity.F_Description = "mobile3";
                                                                                                                                            //logEntity.WriteLog();

                    OperatorResult res = OperatorHelper.Instance.IsOnLine(token, this.loginMark);
                    //res.userInfo.password = null;
                    //res.userInfo.secretkey = null;
                    //logEntity = new LogEntity();
                    //logEntity.F_CategoryId = 1;
                    //logEntity.F_OperateTypeId = ((int)OperationType.Login).ToString();
                    //logEntity.F_OperateType = EnumAttribute.GetDescription(OperationType.Login);
                    //logEntity.F_OperateAccount = loginModel.username + "(" + userEntity.F_RealName + ")";
                    //logEntity.F_OperateUserId = !string.IsNullOrEmpty(userEntity.F_UserId) ? userEntity.F_UserId : loginModel.username;
                    //logEntity.F_OperateTime = DateTime.Now;

                    var jsonData = new
                    {
                        baseinfo = res.userInfo,
                        post = postIBLL.GetListByPostIds(res.userInfo.postIds),
                        role = roleIBLL.GetListByRoleIds(res.userInfo.roleIds)
                    };
                    //logEntity.F_Description = "mobile4";
                    // logEntity.WriteLog();
                    return Success(jsonData);
                }
                
            }
            catch(Exception ex)
            {
                LogUtil.WriteTextLog("login", ex.Message, DateTime.Now);
                return null;

            }
            #endregion
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns> 
        private Response Info(dynamic _)
        {
            var data = userInfo;
            data.password = null;
            data.secretkey = null;

            var jsonData = new
            {
                baseinfo = data,
                post = postIBLL.GetListByPostIds(data.postIds),
                role = roleIBLL.GetListByRoleIds(data.roleIds)
            };

            return Success(jsonData);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response ModifyPassword(dynamic _)
        {
            ModifyModel modifyModel = this.GetReqData<ModifyModel>();
            if (userInfo.isSystem)
            {
                return Fail("当前账户不能修改密码");
            }
            else
            {
                bool res = userIBLL.RevisePassword(modifyModel.newpassword, modifyModel.oldpassword);
                if (!res)
                {
                    return Fail("原密码错误，请重新输入");
                }
                else
                {
                    return Success("密码修改成功");
                }
            }
        }


        /// <summary>
        /// 获取所有员工账号列表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response GetList(dynamic _)
        {
            var data = userInfo;
            data.password = null;
            data.secretkey = null;
            var jsonData = new
            {
                baseinfo = data,
                post = postIBLL.GetListByPostIds(data.postIds),
                role = roleIBLL.GetListByRoleIds(data.roleIds)
            };
            return Success(jsonData);
        }
        /// <summary>
        /// 获取用户映射表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetMap(dynamic _)
        {
            string ver = this.GetReqData();// 获取模板请求数据
            var data = userIBLL.GetModelMap();
            string md5 = Md5Helper.Encrypt(data.ToJson(), 32);
            if (md5 == ver)
            {
                return Success("no update");
            }
            else
            {
                var jsondata = new
                {
                    data = data,
                    ver = md5
                };
                return Success(jsondata);
            }
        }
        /// <summary>
        /// 获取人员头像图标
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetImg(dynamic _)
        {
            string userId = this.GetReqData();// 获取模板请求数据
            userIBLL.GetImg(userId);
            return Success("获取成功");
        }
    }

    /// <summary>
    /// 登录信息
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string username { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string password { get; set; }
    }
    /// <summary>
    /// 修改密码
    /// </summary>
    public class ModifyModel
    {
        /// <summary>
        /// 新密码
        /// </summary>
        public string newpassword { get; set; }
        /// <summary>
        /// 旧密码
        /// </summary>
        public string oldpassword { get; set; }
    }
}