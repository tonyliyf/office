using Learun.Application.Organization;
using Learun.DataBase.Repository;
using Learun.Util;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace Learun.Application.Web.Areas.LR_OrganizationModule.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 敏捷开发框架
    /// Copyright (c) 2013-2018 信息技术有限公司
    /// 创建人：-框架开发组
    /// 日 期：2017.03.09
    /// 描 述：用户管理控制器
    /// </summary>
    public class UserController : MvcControllerBase
    {
        private UserIBLL userIBLL = new UserBLL();
        private DepartmentIBLL departmentIBLL = new DepartmentBLL();

        #region 获取视图
        /// <summary>
        /// 用户管理主页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 用户管理表单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }

        /// <summary>
        /// 人员选择
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SelectForm()
        {
            return View();
        }
        /// <summary>
        /// 人员选择
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SelectOnlyForm()
        {
            return View();
        }


        #endregion

        #region 获取数据
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="keyword">关键字</param>
        /// <param name="companyId">公司主键</param>
        /// <param name="departmentId">部门主键</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetPageList(string pagination, string keyword, string companyId, string departmentId)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            var data = userIBLL.GetPageList(companyId, departmentId, paginationobj, keyword);
            var jsonData = new
            {
                rows = data,
                total = paginationobj.total,
                page = paginationobj.page,
                records = paginationobj.records,
            };
            return Success(jsonData);
        }
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="companyId">公司主键</param>
        /// <param name="departmentId">部门主键</param>
        /// <param name="keyword">查询关键词</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetList(string companyId, string departmentId, string keyword)
        {
            if (string.IsNullOrEmpty(companyId))
            {
                var department = departmentIBLL.GetEntity(departmentId);
                if (department != null)
                {
                    var data = userIBLL.GetList(department.F_CompanyId, departmentId, keyword);
                    return Success(data);
                }
                else
                {
                    return Success(new List<string>());
                }
            }
            else
            {
                var data = userIBLL.GetList(companyId, departmentId, keyword);
                return Success(data);
            }
        }
        /// <summary>
        /// 获取本部门的人员
        /// </summary>
        /// <param name="companyId">公司主键</param>
        /// <param name="departmentId">部门主键</param>
        /// <param name="keyword">查询关键词</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetMyDepartmentList()
        {
            UserInfo userinfo = LoginUserInfo.Get();
            var data = userIBLL.GetList(userinfo.companyId, userinfo.departmentId, "");
            return Success(data);
        }
        /// <summary>
        /// 获取用户信息列表
        /// </summary>
        /// <param name="userIds">用户主键串</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetListByUserIds(string keyValue)
        {
            var list = userIBLL.GetListByUserIds(keyValue);
            string text = "";
            foreach (var item in list)
            {
                if (!string.IsNullOrEmpty(text))
                {
                    text += ",";
                }
                text += item.F_RealName;
            }
            return SuccessString(text);
        }
        /// <summary>
        /// 获取用户信息列表
        /// </summary>
        /// <param name="userIds">用户主键串</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetEntityListByUserIds(string keyValue)
        {
            var list = userIBLL.GetListByUserIds(keyValue);
            return Success(list);
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userIds">用户主键</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetUserEntity(string userId)
        {
            var data = userIBLL.GetEntityByUserId(userId);
            return Success(data);
        }

        /// <summary>
        /// 获取映射数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetMap(string ver)
        {
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
        /// 获取头像
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetImg(string userId)
        {
            userIBLL.GetImg(userId);
            return Success("获取成功。");
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存表单数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, UserEntity entity)
        {
            userIBLL.SaveEntity(keyValue, entity);
            return Success("保存成功！");
        }
        /// <summary>
        /// 删除表单数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult DeleteForm(string keyValue)
        {
            userIBLL.VirtualDelete(keyValue);
            return Success("删除成功！");
        }
        /// <summary>
        /// 启用禁用账号
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult UpdateState(string keyValue, int state)
        {
            userIBLL.UpdateState(keyValue, state);
            return Success("操作成功！");
        }
        /// <summary>
        /// 重置用户账号密码
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult ResetPassword(string keyValue)
        {
            userIBLL.ResetPassword(keyValue);
            return Success("操作成功！");
        }


        public void InitPasswordForAllUser()
        {
            var factory = new RepositoryFactory();
            var table = factory.BaseRepository().FindTable(@"select 
                    (select top 1 f_fullname from lr_base_company where f_companyid =t.f_companyid) as company,
                    (select top 1 f_fullname from lr_base_department where f_departmentid = t.f_departmentid) as department,
                    t.f_userid as id,t.f_realname as name ,t.f_account as account ,
                    '' as password 
                    from lr_base_user t where f_account != 'System'  order by company,department");
            foreach (DataRow row in table.Rows)
            {
                var secretKey = Md5Helper.Encrypt(CommonHelper.CreateNo(), 16).ToLower();
                var newPassword = Md5Helper.Encrypt(CommonHelper.CreateNo(), 16).ToLower().Substring(0, 6);
                var encryptPassword = Md5Helper.Encrypt(DESEncrypt.Encrypt(Md5Helper.Encrypt(newPassword,32).ToLower(), secretKey).ToLower(), 32).ToLower();
                row["password"] = newPassword;
                factory.BaseRepository().ExecuteBySql("  update lr_base_user set f_password = @password, f_secretkey = @key where f_userid=@userid"
                    , new { password = encryptPassword, key = secretKey, userid = row["id"].ToString() });
            }
            //table.Columns.Remove("id");
            //table.Columns["name"].ColumnName = "姓名";
            //table.Columns["account"].ColumnName = "账户";
            //table.Columns["password"].ColumnName = "密码";
            string fileName = "用户初始化";
            //设置导出格式
            ExcelConfig excelconfig = new ExcelConfig();
            excelconfig.Title = Server.UrlDecode(fileName);
            excelconfig.TitleFont = "微软雅黑";
            excelconfig.TitlePoint = 15;
            excelconfig.FileName = Server.UrlDecode(fileName) + ".xls";
            excelconfig.IsAllSizeColumn = true;
            excelconfig.ColumnEntity = new List<ColumnModel>();
            //写入Excel表头
            excelconfig.ColumnEntity.Add(new ColumnModel()
            {
                Column = "company",
                ExcelColumn = "公司",
                Alignment = "center",
            });
            excelconfig.ColumnEntity.Add(new ColumnModel()
            {
                Column = "department",
                ExcelColumn = "部门",
                Alignment = "center",
            });
            excelconfig.ColumnEntity.Add(new ColumnModel()
            {
                Column = "name",
                ExcelColumn = "姓名",
                Alignment = "center",
            });
            excelconfig.ColumnEntity.Add(new ColumnModel()
            {
                Column = "account",
                ExcelColumn = "账户",
                Alignment = "center",
            });
            excelconfig.ColumnEntity.Add(new ColumnModel()
            {
                Column = "password",
                ExcelColumn = "密码",
                Alignment = "center",
            });
            ExcelHelper.ExcelDownload(table, excelconfig);
        }
        #endregion

        #region 数据导出
        /// <summary>
        /// 导出用户列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ExportUserList()
        {
            userIBLL.GetExportList();
            return Success("导出成功。");
        }
        #endregion

        #region 验证数据
        /// <summary>
        /// 账号不能重复
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="F_Account">账号</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult ExistAccount(string keyValue, string F_Account)
        {
            bool res = userIBLL.ExistAccount(F_Account, keyValue);
            return Success(res);
        }
        #endregion
    }
}