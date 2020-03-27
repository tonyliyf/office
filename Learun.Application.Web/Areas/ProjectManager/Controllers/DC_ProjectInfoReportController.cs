using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.ProjectManager;
using System.Web.Mvc;
using System.Collections.Generic;
using Learun.Application.Base.SystemModule;
using System.Collections;

namespace Learun.Application.Web.Areas.ProjectManager.Controllers
{
    public class DC_ProjectInfoReportController : MvcControllerBase
    {
        private DataItemIBLL dataItemIBLL = new DataItemBLL();
        private DC_EngineProject_ProjectInfoApprovalDataIBLL dC_EngineProject_ProjectInfoApprovalDataIBLL = new DC_EngineProject_ProjectInfoApprovalDataBLL();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetProjectColumnInfo(string queryJosn)
        {
            var data = dC_EngineProject_ProjectInfoApprovalDataIBLL.GetSqlTree();
            var dt = dC_EngineProject_ProjectInfoApprovalDataIBLL.GetProjectInfo(queryJosn);
            Hashtable ht = new Hashtable();

            DataTable dtNew = new DataTable();
            dtNew.Columns.Add(new DataColumn("项目程序名称"));
           
            foreach(DataRow dr in data.Rows)
            {
               if(dr["f_itemcode"].ToString()== "EngineeringProjectStage")
                {
                    DataRow[] drrows = data.Select("f_parentid ='" + dr["f_itemid"].ToString() + "'", "F_sortCode ");

                    foreach(DataRow dr1 in drrows)
                    {

                        DataRow[] drrows2 = data.Select("f_parentid ='" + dr1["f_itemid"].ToString() + "'", "F_sortCode ");

                        if(drrows2!=null&&drrows2.Length>0)
                        {

                            foreach(DataRow dr3 in drrows2)
                            {
                                var dataitem = dataItemIBLL.GetDetailList(dr3["F_ItemCode"].ToString());
                                foreach(var item in dataitem)
                                {

                                    dtNew.Columns.Add(new DataColumn(item.F_ItemName));

                                }
                   
                            }

                        }
                        else
                        {
                            var dataitem = dataItemIBLL.GetDetailList(dr1["F_ItemCode"].ToString());
                            foreach (var item in dataitem)
                            {

                                dtNew.Columns.Add(new DataColumn(item.F_ItemName));

                            }

                        }

                    }

                }

            }
           dtNew.AcceptChanges();
           foreach (DataRow dtrow in dt.Rows)
            {
                
                DataRow dtNewRow = dtNew.NewRow();
                dtNewRow["项目程序名称"] = dtrow["F_ProjectName"];

                dtNew.Rows.Add(dtNewRow);


            }

            dtNew.AcceptChanges();
            return Success(dtNew);


        }
    }
}