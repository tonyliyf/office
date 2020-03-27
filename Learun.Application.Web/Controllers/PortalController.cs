using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Learun.Application.Message;
using Learun.Application.Organization;
using Learun.Application.TwoDevelopment.LR_CodeDemo;
using Learun.Util;


namespace Learun.Application.Web.Controllers
{
    public class PortalController : MvcControllerBase
    {
        private RoleIBLL roleBLL = new RoleBLL();
        private RoleEntity role = new RoleEntity();
        private UserIBLL userBll = new UserBLL();
        private DC_OA_MessageIBLL messageservice = new DC_OA_MessageBLL();

        private DC_OA_AttenceIBLL attenceBll = new DC_OA_AttenceBLL();
        private Learun.Application.TwoDevelopment.LR_CodeDemo.Portal.PortalService portalservice = new Learun.Application.TwoDevelopment.LR_CodeDemo.Portal.PortalService();
        // GET: Portal
        public ActionResult Index()
        {
           
            UserInfo user = LoginUserInfo.Get();
            
             switch (user.F_Level)
            {
                case 1:
                    return View("AdminDefault");      // 经典版本
                case 2:
                    return View("LeaderDefault");    // 手风琴版本  部室领导
                case 3:
                    return View("LeaderDefault");    // 手风琴版本  子公司领导
                case 4:
                    return View("HighLeader");       // Windos版本   分管领导
                case 5:
                    return View("MaxLeader");          // 顶部菜单版本 高层领导
                default:
                    return View("AdminDefault");      // 经典版本
            }


        }

        /// <summary>
        /// 首页桌面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AdminDesktop()
        {
            return View("AdminDesktopTemp");
        }
        /// <summary>
        /// 首页模板
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AdminDesktopTemp()
        {
            return View();
        }


        /// <summary>
        /// 首页桌面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AdminDesktop1()
        {
            return View("AdminDesktopTemp1");
        }
        /// <summary>
        /// 首页模板
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AdminDesktopTemp1()
        {
            return View();
        }


        /// <summary>
        /// 首页桌面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AdminDesktop2()
        {
            return View("AdminDesktopTemp2");
        }
        /// <summary>
        /// 首页模板
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AdminDesktopTemp2()
        {
            return View();
        }

        /// <summary>
        /// 首页桌面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AdminDesktop3()
        {
            return View("AdminDesktopTemp3");
        }
        /// <summary>
        /// 首页模板
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AdminDesktopTemp3()
        {
            return View();
        }

        public ActionResult AttenceRecord()
        {
            return null;

        }

        public ActionResult GetDeptUser()
        {
            UserInfo user = LoginUserInfo.Get();

            List<UserInfos> usersinfo = new List<UserInfos>();
            UserInfos u = null;
             var userlist = userBll.GetAllList().Where(i => i.F_DepartmentId == user.departmentId);
            foreach(var item in userlist)
            {
                u = new UserInfos();
                u.isLogin = 0;
                u.F_UserId = item.F_UserId;
                u.F_RealName = item.F_RealName;
                if(item.F_UserId ==user.userId)
                {
                    u.isLogin = 1;
                }

                usersinfo.Add(u);

            }
             
             return Success(usersinfo);
      }


        public ActionResult GetMessage()
        {

            DataTable dt = portalservice.GetMessage();
            return Success(dt);

        }

        public ActionResult EnterMessage(string Messageid)
        {
            bool bEnter = portalservice.EnterMessage(Messageid);
            if(bEnter)
            {
                return Success("确认成功");
            }
            else
            {

                return Fail("确认失败");
            }


        }

        public ActionResult GetDeptUserTree()
        {
            UserInfo user = LoginUserInfo.Get();

            var userlist = userBll.GetAllList().Where(i => i.F_DepartmentId == user.departmentId);
            List<TreeModel> treeList = new List<TreeModel>();
            foreach (var item in userlist)
            {
                TreeModel node = new TreeModel
                {
                    id = item.F_UserId,
                    text = item.F_RealName,
                    value = item.F_UserId,
                    showcheck = false,
                    checkstate = 0,
                    isexpand = true,
                    parentId = "0"
                };
                treeList.Add(node);
            }
            return Success(treeList.ToTree());

        }

        /// <summary>
        /// 获得采购数量
        /// </summary>
        /// <returns></returns>
        public ActionResult GetPurchase()
        {
            var tableinfo = portalservice.GetPurchase();
            return Success(tableinfo);

        }
        public ActionResult GetMaintain()
        {
            var tableinfo = portalservice.GetMaintain();
            return Success(tableinfo);

        }
        public ActionResult GetOverSeeList(string type)
        {
            return Success(new Learun.Application.TwoDevelopment.LR_CodeDemo.Portal.PortalService().GetOverSeeList(type));
        }

        public ActionResult GetOverSeeListCount(string type)
        {
            return Success(new Learun.Application.TwoDevelopment.LR_CodeDemo.Portal.PortalService().GetOverSeeListCount());
        }
        public ActionResult GetMaintainRecordCount()
        {
            return Success(new Learun.Application.TwoDevelopment.LR_CodeDemo.Portal.PortalService().GetMaintainRecordCount());
        }
        public ActionResult GetMeettingDetail()
        {
            return Success(new Learun.Application.TwoDevelopment.LR_CodeDemo.Portal.PortalService().GetMeettingDetail());
        }
        public ActionResult SignForMeetting(string id,string F_Reason)
        {
            new Learun.Application.TwoDevelopment.LR_CodeDemo.Portal.PortalService().SignForMeetting(id, F_Reason);
            return Success("操作成功");
        }

        public ActionResult GetMyDocumentList()
        {
            return Success(new Learun.Application.TwoDevelopment.LR_CodeDemo.Portal.PortalService().GetMyDocumentList());
        }


        public ActionResult GetOAMessage()
        {

            DataTable dt = messageservice.GetMsgCount();
            int count = 0;
            for(int i=0;i<dt.Rows.Count;i++)
            {
                if(!dt.Rows[i]["count"].IsEmpty())
                {

                    count += int.Parse(dt.Rows[i]["count"].ToString());
                }
            }
            
            var jsonData = new
            {
                rows = dt,
                total = count
             
            };
            return Success(jsonData);
        }

        public ActionResult GetMessageList(string pagination,string code="",string content="",string isRead="")
        {
            Pagination paginationobj = null;

            if (!pagination.IsEmpty())
            {
                 paginationobj = pagination.ToObject<Pagination>();
            }
            else
            {
                paginationobj = new Pagination();
                
            }
            var data = messageservice.GetMessageList(paginationobj, code,content,isRead);
            var jsonData = new
            {
                rows = data,
                total = paginationobj.total,
                page = paginationobj.page,
                records = paginationobj.records
            };
            return Success(jsonData);

        }

        public ActionResult GetMessageEntity(string messageid)
        {
            var data = messageservice.GetEntity(messageid);

            return Success(data);
        }
      


    }

    public  class UserInfos:UserEntity
    {
        public int isLogin { get; set; }
    }
}