using Learun.Application.TwoDevelopment.LR_CodeDemo;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Learun.Application.Web.Areas.LR_CodeDemo.Controllers
{
    public class DC_OA_UserSignatureController : MvcControllerBase
    {
        private DC_OA_UserSignatureIBLL dC_OA_UserSignatureIBLL = new DC_OA_UserSignatureBLL();
        [HttpPost]
        [AjaxOnly]
        public ActionResult Save(string password, string base64str)
        {
            UserInfo userInfo = LoginUserInfo.Get();
            string fileHeadImg = Config.GetValue("fileSignatureImg");
            string fullFileName = string.Format("{0}/{1}{2}", fileHeadImg, userInfo.userId, ".png");
            string path = Path.GetDirectoryName(fullFileName);
            Directory.CreateDirectory(path);
            string[] arr = base64str.Split(',');
            if (arr.Length > 1)
            {
                Base64ToFileAndSave(arr[1], fullFileName);
            }
            else
            {
                Base64ToFileAndSave(base64str, fullFileName);
            }
            dC_OA_UserSignatureIBLL.UpdateEntity(password, "");
            return Success("保存成功！");
        }

        [HttpGet]
        [AjaxOnly]
        public ActionResult Delete()
        {
            UserInfo userInfo = LoginUserInfo.Get();
            string fileHeadImg = Config.GetValue("fileSignatureImg");
            string fullFileName = string.Format("{0}/{1}{2}", fileHeadImg, userInfo.userId, ".png");
            if (System.IO.File.Exists(fullFileName))
            {
                System.IO.File.Delete(fullFileName);
            }
            return Success("删除成功！");
        }

        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFromData()
        {
            UserInfo userInfo = LoginUserInfo.Get();
            if (dC_OA_UserSignatureIBLL.ExistUser())
            {
                string fileHeadImg = Config.GetValue("fileSignatureImg");
                string fullFileName = string.Format("{0}/{1}{2}", fileHeadImg, userInfo.userId, ".png");
                string base64str = "";
                if (System.IO.File.Exists(fullFileName))
                {
                    base64str = FileToBase64(fullFileName);
                }
                string password = dC_OA_UserSignatureIBLL.GetEntity().F_Password;
                return Success(new { base64str = base64str, password = password });
            }
            else
            {
                return Fail("无用户数据");
            }

        }
        private String FileToBase64(string fileName)
        {
            string strRet = null;

            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Open);
                byte[] bt = new byte[fs.Length];
                fs.Read(bt, 0, bt.Length);
                strRet = Convert.ToBase64String(bt);
                fs.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return strRet;
        }


        private bool Base64ToFileAndSave(string strInput, string fileName)
        {
            bool bTrue = false;
            try
            {
                byte[] buffer = Convert.FromBase64String(strInput);
                FileStream fs = new FileStream(fileName, FileMode.Create);
                fs.Write(buffer, 0, buffer.Length);
                fs.Close();
                bTrue = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return bTrue;

        }
    }
}