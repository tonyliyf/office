using Learun.Application.WorkFlow;
using Learun.Util;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System.Data;

namespace Learun.Application.Web.Areas.LR_NewWorkFlow.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 敏捷开发框架
    /// Copyright (c) 2013-2018 信息技术有限公司
    /// 创建人：-框架开发组
    /// 日 期：2018.12.09
    /// 描 述：流程进程
    /// </summary>
    public class NWFProcessController : MvcControllerBase
    {
        private NWFProcessIBLL nWFProcessIBLL = new NWFProcessBLL();

        private NWFSchemeIBLL nWFSchemeIBLL = new NWFSchemeBLL();
        private NWFTaskIBLL nWFTaskIBLL = new NWFTaskBLL();

        #region 视图功能
        /// <summary>
        /// 视图功能
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 发起流程
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ReleaseForm()
        {
            return View();
        }
        /// <summary>
        /// 流程容器
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult NWFContainerForm(string processId, string tabIframeId, string type)
        {
            return View();
        }
        /// <summary>
        /// 查看节点审核信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult LookNodeForm()
        {
            return View();
        }

        /// <summary>
        /// 创建流程
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateForm()
        {
            return View();
        }
        /// <summary>
        /// 审核流程
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AuditFlowForm()
        {
            return View();
        }
        /// <summary>
        /// 加签审核流程
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SignAuditFlowForm()
        {
            return View();
        }
        /// <summary>
        /// 加签审核
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SignFlowForm()
        {
            return View();
        }

        /// <summary>
        /// 流程进度查看（父子流程）
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult LookFlowForm()
        {
            return View();
        }

        /// <summary>
        /// 监控页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult MonitorIndex()
        {
            return View();
        }
        /// <summary>
        /// 监控详情页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult MonitorDetailsIndex()
        {
            return View();
        }
        /// <summary>
        /// 查看各个节点表单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult MonitorForm()
        {
            return View();
        }
        /// <summary>
        /// 指定审核人
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AppointForm()
        {
            return View();
        }
        /// <summary>
        /// 批量审核页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult BatchAuditIndex()
        {
            return View();
        }

        #endregion

        #region 获取数据
        /// <summary>
        /// 获取我的流程信息列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询条件</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetPorcessList(string pagination, string queryJson)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            var list = nWFProcessIBLL.GetPageList(paginationobj, queryJson);
            var jsonData = new
            {
                rows = list,
                total = paginationobj.total,
                page = paginationobj.page,
                records = paginationobj.records,
            };
            return Success(jsonData);
        }
        /// <summary>
        /// 获取我的流程信息列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询条件</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetTaskPageList(string pagination, string queryJson, string categoryId)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            IEnumerable<NWFProcessEntity> list = new List<NWFProcessEntity>();

            UserInfo userInfo = LoginUserInfo.Get();
            switch (categoryId)
            {
                case "1":
                    list = nWFProcessIBLL.GetMyPageList(userInfo.userId, paginationobj, queryJson);
                    break;
                case "2":
                    list = nWFProcessIBLL.GetMyTaskPageList(userInfo, paginationobj, queryJson);
                    break;
                case "3":
                    list = nWFProcessIBLL.GetMyFinishTaskPageList(userInfo, paginationobj, queryJson);
                    break;
            }

            var jsonData = new
            {
                rows = list,
                total = paginationobj.total,
                page = paginationobj.page,
                records = paginationobj.records,
            };
            return Success(jsonData);
        }



        /// <summary>
        /// 获取我的流程信息列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询条件</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetTaskPortalPageList(string pagination, string queryJson, string type)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            IEnumerable<NWFProcessEntity> list = new List<NWFProcessEntity>();

            //<li data-value="2" class="lrlg active">待办任务</li>
            //        <li data-value="3" class="lrlg">已办任务</li>
            //        <li class="lrlg" data-value="1">我的流程</li>
            //待办,已办,传阅,发起
            UserInfo userInfo = LoginUserInfo.Get();
            switch (type)
            {
                //待办
                case "1":
                    list = nWFProcessIBLL.GetHeaderMyTaskPageList(userInfo, paginationobj, 1);
                    break;
                case "2":
                    list = nWFProcessIBLL.GetMyFinishTaskPageList(userInfo, paginationobj, queryJson);
                    break;
                case "3":
                    list = nWFProcessIBLL.GetHeaderMyTaskPageList(userInfo, paginationobj, 2);
                    break;
                case "4":
                    list = nWFProcessIBLL.GetMyPageList(userInfo.userId, paginationobj, queryJson);
                    break;
            }

            if (type == "4")
            {
                foreach (var item in list)
                {
                    if (item.F_TaskType == 4 || item.F_TaskType == 6)
                    {
                        item.F_URl = string.Format("/LR_NewWorkFlow/NWFProcess/NWFContainerForm?tabIframeId={0}{1}&type=childlook&processId={0}&taskId={1}", item.F_Id, item.F_TaskId);
                    }

                    else
                    {
                        item.F_URl = string.Format("/LR_NewWorkFlow/NWFProcess/NWFContainerForm?tabIframeId={0}{1}&type=look&processId={0}&taskId={1}", item.F_Id, item.F_TaskId);
                    }

                }

            }

            var jsonData = new
            {
                rows = list,
                total = paginationobj.total,
                page = paginationobj.page,
                records = paginationobj.records,
            };
            return Success(jsonData);
        }

        public ActionResult GetTaskPortalPageListCount()
        {
            Pagination paginationobj = new Pagination();
            string queryJson = "{ 'StartTime':'','EndTime':''}";
            paginationobj.rows = 10000000;
            paginationobj.sidx = "F_CreateDate DESC";
            paginationobj.sord = "ASC";
            paginationobj.page = 1;
            UserInfo userInfo = LoginUserInfo.Get();
            var list1 = nWFProcessIBLL.GetHeaderMyTaskPageList(userInfo, paginationobj, 1); 
            var list2 = nWFProcessIBLL.GetMyFinishTaskPageList(userInfo, paginationobj, queryJson);
            var list3 = nWFProcessIBLL.GetHeaderMyTaskPageList(userInfo, paginationobj, 2);
            var list4 = nWFProcessIBLL.GetMyPageList(userInfo.userId, paginationobj, queryJson);
            DataTable dtData = new DataTable();
            dtData.Columns.Add("a1");
            dtData.Columns.Add("b1");
            dtData.Columns.Add("c1");
            dtData.Columns.Add("d1");
            DataRow dr = dtData.NewRow();
            dr["a1"] = 0;
            dr["b1"] = 0;
            dr["c1"] = 0;
            dr["d1"] = 0;
            if(list1!=null)
            {
                dr["a1"] = list1.Count();
            }
            if (list2 != null)
            {
                dr["b1"] = list2.Count();
            }
            if (list3 != null)
            {
                dr["c1"] = list3.Count();
            }
            if (list4 != null)
            {
                dr["d1"] = list4.Count();
            }
            dtData.Rows.Add(dr);
            dtData.AcceptChanges();
            return Success(dtData);

        }
        /// <summary>
        /// 获取批量审核任务清单
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询条件</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetBatchTaskPageList(string pagination, string queryJson)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            UserInfo userInfo = LoginUserInfo.Get();
            var data = nWFProcessIBLL.GetMyTaskPageList(userInfo, paginationobj, queryJson, true);
            var jsonData = new
            {
                rows = data,
                total = paginationobj.total,
                page = paginationobj.page,
                records = paginationobj.records,
            };
            return Success(jsonData);
        }
        #endregion

        #region 保存更新删除
        /// <summary>
        /// 删除流程进程实体
        /// </summary>
        /// <param name="processId">流程进程主键</param>
        [HttpPost]
        [AjaxOnly]
        public ActionResult DeleteEntity(string processId)
        {
            nWFProcessIBLL.DeleteEntity(processId);
            return Success("删除成功");
        }
        #endregion

        #region 流程API
        /// <summary>
        /// 获取流程模板
        /// </summary>
        /// <param name="code">流程编码</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetSchemeByCode(string code)
        {
            var schemeInfo = nWFSchemeIBLL.GetInfoEntityByCode(code);
            if (schemeInfo != null)
            {
                var data = nWFSchemeIBLL.GetSchemeEntity(schemeInfo.F_SchemeId);
                return Success(data);
            }
            return Fail("找不到该流程模板");
        }
        /// <summary>
        /// 根据流程进程主键获取流程模板
        /// </summary>
        /// <param name="processId">流程进程主键</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetSchemeByProcessId(string processId)
        {
            var processEntity = nWFProcessIBLL.GetEntity(processId);
            if (processEntity != null)
            {
                if (string.IsNullOrEmpty(processEntity.F_SchemeId))
                {
                    var schemeInfo = nWFSchemeIBLL.GetInfoEntityByCode(processEntity.F_SchemeCode);
                    if (schemeInfo != null)
                    {
                        var data = nWFSchemeIBLL.GetSchemeEntity(schemeInfo.F_SchemeId);
                        return Success(data);
                    }
                }
                else
                {
                    var data = nWFSchemeIBLL.GetSchemeEntity(processEntity.F_SchemeId);
                    return Success(data);
                }
            }
            return Fail("找不到该流程模板");
        }

        /// <summary>
        /// 获取流程下一节点审核
        /// </summary>
        /// <param name="code">流程编码</param>
        /// <param name="processId">流程进程主键</param>
        /// <param name="taskId">任务主键</param>
        /// <param name="nodeId">节点ID</param>
        /// <param name="operationCode">操作编码</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetNextAuditors(string code, string processId, string taskId, string nodeId, string operationCode)
        {
            UserInfo userInfo = LoginUserInfo.Get();
            ///liyf 修改 去掉审核人的限制 2019-02-21
            // var data = nWFProcessIBLL.GetNextAuditors(code, processId, taskId, nodeId, operationCode, userInfo);
            var data = nWFProcessIBLL.GetNextAuditorsNoLimit(code, processId, taskId, nodeId, operationCode, userInfo);
            return Success(data);
        }

        /// <summary>
        /// 获取流程进程信息
        /// </summary>
        /// <param name="processId">进程主键</param>
        /// <param name="taskId">任务主键</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetProcessDetails(string processId, string taskId)
        {
            UserInfo userInfo = LoginUserInfo.Get();
            var data = nWFProcessIBLL.GetProcessDetails(processId, taskId, userInfo);
            if (!string.IsNullOrEmpty(data.childProcessId))
            {
                processId = data.childProcessId;
            }

            var taskNode = nWFProcessIBLL.GetTaskUserList(processId);

            var jsonData = new
            {
                info = data,
                task = taskNode
            };

            return Success(jsonData);
        }

        /// <summary>
        /// 获取子流程详细信息
        /// </summary>
        /// <param name="processId">父流程进程主键</param>
        /// <param name="taskId">父流程子流程发起主键</param>
        /// <param name="schemeCode">子流程流程模板编码</param>
        /// <param name="nodeId">父流程发起子流程节点Id</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetChildProcessDetails(string processId, string taskId, string schemeCode, string nodeId)
        {
            UserInfo userInfo = LoginUserInfo.Get();
            var data = nWFProcessIBLL.GetChildProcessDetails(processId, taskId, schemeCode, nodeId, userInfo);
            var taskNode = nWFProcessIBLL.GetTaskUserList(data.childProcessId);
            var jsonData = new
            {
                info = data,
                task = taskNode
            };

            return Success(jsonData);
        }
        /// <summary>
        /// 保存草稿
        /// </summary>
        /// <param name="processId">流程进程主键</param>
        /// <param name="schemeCode">流程模板编码</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult SaveDraft(string processId, string schemeCode)
        {
            UserInfo userInfo = LoginUserInfo.Get();
            nWFProcessIBLL.SaveDraft(processId, schemeCode, userInfo);
            return Success("流程草稿保存成功");
        }
        /// <summary>
        /// 删除草稿
        /// </summary>
        /// <param name="processId">流程进程主键</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult DeleteDraft(string processId)
        {
            UserInfo userInfo = LoginUserInfo.Get();
            nWFProcessIBLL.DeleteDraft(processId, userInfo);
            return Success("流程草稿删除成功");
        }


        /// <summary>
        /// 创建流程
        /// </summary>
        /// <param name="schemeCode">流程模板编码</param>
        /// <param name="processId">流程进程主键</param>
        /// <param name="title">流程进程自定义标题</param>
        /// <param name="level">流程进程等级</param>
        /// <param name="auditors">下一节点审核人</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult CreateFlow(string schemeCode, string processId, string title, int level, string auditors)
        {
            UserInfo userInfo = LoginUserInfo.Get();
            nWFProcessIBLL.CreateFlow(schemeCode, processId, title, level, auditors, userInfo);
            return Success("流程创建成功");
        }

        /// <summary>
        /// 创建流程(子流程)
        /// </summary>
        /// <param name="schemeCode">流程模板编码</param>
        /// <param name="processId">流程进程主键</param>
        /// <param name="parentProcessId">父流程进程主键</param>
        /// <param name="parentTaskId">父流程任务主键</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult CreateChildFlow(string schemeCode, string processId, string parentProcessId, string parentTaskId)
        {
            UserInfo userInfo = LoginUserInfo.Get();
            nWFProcessIBLL.CreateChildFlow(schemeCode, processId, parentProcessId, parentTaskId, userInfo);
            return Success("流程创建成功");
        }

        /// <summary>
        /// 重新创建流程
        /// </summary>
        /// <param name="processId">流程进程主键</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult AgainCreateFlow(string processId)
        {
            UserInfo userInfo = LoginUserInfo.Get();
            nWFProcessIBLL.AgainCreateFlow(processId, userInfo);
            return Success("流程重新创建成功");
        }
        /// <summary>
        /// 审批流程
        /// </summary>
        /// <param name="operationCode">流程审批操作码agree 同意 disagree 不同意 lrtimeout 超时</param>
        /// <param name="operationName">流程审批操名称</param>
        /// <param name="processId">流程进程主键</param>
        /// <param name="taskId">流程任务主键</param>
        /// <param name="des">审批意见</param>
        /// <param name="auditors">下一节点指定审核人</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult AuditFlow(string operationCode, string operationName, string processId, string taskId, string des, string auditors)
        {
            UserInfo userInfo = LoginUserInfo.Get();
            nWFProcessIBLL.AuditFlow(operationCode, operationName, processId, taskId, des, auditors, userInfo);
            return Success("流程审批成功");
        }
        /// <summary>
        /// 审批流程
        /// </summary>
        /// <param name="operationCode">流程审批操作码agree 同意 disagree 不同意</param>
        /// <param name="taskIds">任务串</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult AuditFlows(string operationCode, string taskIds)
        {
            UserInfo userInfo = LoginUserInfo.Get();
            nWFProcessIBLL.AuditFlows(operationCode, taskIds, userInfo);
            return Success("流程批量审批成功");
        }
        /// <summary>
        /// 流程加签
        /// </summary>
        /// <param name="processId">流程进程主键</param>
        /// <param name="taskId">流程任务主键</param>
        /// <param name="userId">加签人员</param>
        /// <param name="des">加签说明</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult SignFlow(string processId, string taskId, string userId, string des)
        {
            UserInfo userInfo = LoginUserInfo.Get();
            nWFProcessIBLL.SignFlow(processId, taskId, userId, des, userInfo);
            return Success("流程加签成功");
        }
        /// <summary>
        /// 流程加签审核
        /// </summary>
        /// <param name="operationCode">审核操作码</param>
        /// <param name="processId">流程进程主键</param>
        /// <param name="taskId">流程任务主键</param>
        /// <param name="des">加签说明</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult SignAuditFlow(string operationCode, string processId, string taskId, string des)
        {
            UserInfo userInfo = LoginUserInfo.Get();
            nWFProcessIBLL.SignAuditFlow(operationCode, processId, taskId, des, userInfo);
            return Success("加签审批成功");
        }

        /// <summary>
        /// 确认阅读
        /// </summary>
        /// <param name="processId">流程进程主键</param>
        /// <param name="taskId">流程任务主键</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult ReferFlow(string processId, string taskId)
        {
            UserInfo userInfo = LoginUserInfo.Get();
            nWFProcessIBLL.ReferFlow(processId, taskId, userInfo);
            return Success("保存成功");
        }

        /// <summary>
        /// 催办流程
        /// </summary>
        /// <param name="processId">流程进程主键</param>
        /// <param name="userInfo">当前操作人信息</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult UrgeFlow(string processId)
        {
            UserInfo userInfo = LoginUserInfo.Get();
            nWFProcessIBLL.UrgeFlow(processId, userInfo);
            return Success("催办成功");
        }
        /// <summary>
        /// 撤销流程（只有在该流程未被处理的情况下）
        /// </summary>
        /// <param name="processId">流程进程主键</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult RevokeFlow(string processId)
        {
            UserInfo userInfo = LoginUserInfo.Get();
            nWFProcessIBLL.RevokeFlow(processId, userInfo);
            return Success("撤销成功");
        }

        /// <summary>
        /// 获取流程当前任务需要处理的人
        /// </summary>
        /// <param name="processId">流程进程主键</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetTaskUserList(string processId)
        {
            var data = nWFProcessIBLL.GetTaskUserList(processId);
            return Success(data);
        }
        /// <summary>
        /// 指派流程审核人
        /// </summary>
        /// <param name="strList">任务列表</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult AppointUser(string strList)
        {
            IEnumerable<NWFTaskEntity> list = strList.ToObject<IEnumerable<NWFTaskEntity>>();
            UserInfo userInfo = LoginUserInfo.Get();
            nWFProcessIBLL.AppointUser(list, userInfo);
            return Success("指派成功");
        }
        /// <summary>
        /// 作废流程
        /// </summary>
        /// <param name="processId">流程进程主键</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult DeleteFlow(string processId)
        {
            UserInfo userInfo = LoginUserInfo.Get();
            nWFProcessIBLL.DeleteFlow(processId, userInfo);
            return Success("作废成功");
        }
        #endregion
    }
}