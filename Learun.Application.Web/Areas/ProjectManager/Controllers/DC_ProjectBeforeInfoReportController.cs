using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.ProjectManager;
using System.Web.Mvc;
using System.Collections.Generic;
using Learun.Application.Base.SystemModule;
using System.Collections;

namespace Learun.Application.Web.Areas.ProjectManager.Controllers
{
    public class DC_ProjectBeforeInfoReportController : MvcControllerBase
    {
        private DataItemIBLL dataItemIBLL = new DataItemBLL();
        private DC_EngineProject_ProjectInfoApprovalDataIBLL dC_EngineProject_ProjectInfoApprovalDataIBLL = new DC_EngineProject_ProjectInfoApprovalDataBLL();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetProjectColumnInfo(string keyword)
        {
            //父级节点
            var data = dC_EngineProject_ProjectInfoApprovalDataIBLL.GetBeforeSqlTree();

            var dt = dC_EngineProject_ProjectInfoApprovalDataIBLL.GetProjectInfo(keyword);
            Hashtable ht = new Hashtable();

            DataTable dtNew = new DataTable();
            dtNew.Columns.Add(new DataColumn("项目程序名称"));
            string projectname = string.Empty;

            foreach (DataRow dr in data.Rows)
            {
                if (dr["f_itemcode"].ToString() == "ProjectBegin")
                {
                    DataRow[] drrows = data.Select("f_parentid ='" + dr["f_itemid"].ToString() + "'", "F_sortCode ");

                    foreach (DataRow dr1 in drrows)
                    {

                        DataRow[] drrows2 = data.Select("f_parentid ='" + dr1["f_itemid"].ToString() + "'", "F_sortCode ");

                        if (drrows2 != null && drrows2.Length > 0)
                        {

                            foreach (DataRow dr3 in drrows2)
                            {
                                var dataitem = dataItemIBLL.GetDetailList(dr3["F_ItemCode"].ToString());
                                foreach (var item in dataitem)
                                {

                                    dtNew.Columns.Add(new DataColumn(item.F_ItemName));
                                    ht.Add(item.F_ItemName, item.F_ItemDetailId);

                                }
                            }

                        }
                        else
                        {
                            var dataitem = dataItemIBLL.GetDetailList(dr1["F_ItemCode"].ToString());
                            foreach (var item in dataitem)
                            {

                                dtNew.Columns.Add(new DataColumn(item.F_ItemName));
                                ht.Add(item.F_ItemName, item.F_ItemDetailId);

                            }

                        }

                    }

                }

            }
            dtNew.AcceptChanges();
            foreach (DataRow dtrow in dt.Rows)
            {

                if (projectname != dtrow["F_ProjectName"].ToString())
                {
                    DataRow dtNewRow = dtNew.NewRow();
                    projectname = dtrow["F_ProjectName"].ToString();
                    dtNewRow["项目程序名称"] = projectname;
                    foreach (string key in ht.Keys)
                    {
                        DataRow[] dtTemp = dt.Select("F_ProjectName ='" + dtrow["F_ProjectName"].ToString() + "' and F_ProjectStage ='" + ht[key].ToString() + "'");
                        if (dtTemp != null && dtTemp.Length > 0)
                        {



                            if (dtTemp[0]["F_ActualEndDate"].IsEmpty())
                            {
                                if (!dtTemp[0]["F_PlannedEndDate"].IsEmpty())
                                {

                                    dtNewRow[key] = dtTemp[0]["F_PlannedEndDate"].ToString().Substring(0, 10);

                                }
                                else
                                {
                                    dtNewRow[key] = dtTemp[0]["F_DataCode"];

                                }

                            }
                            else
                            {
                                dtNewRow[key] = dtTemp[0]["F_ActualEndDate"].ToString().Substring(0, 10);

                            }
                            //dtNewRow[key] = dtTemp[0]["F_DataName"];
                            //if (dtTemp[0]["F_ActualEndDate"].IsEmpty())
                            //{
                            //    if (!dtTemp[0]["F_PlannedEndDate"].IsEmpty())
                            //    {

                            //        dtNewRow[key] = dtTemp[0]["F_PlannedEndDate"].ToString().Substring(0, 10);

                            //    }

                            //}
                            //else
                            //{
                            //    dtNewRow[key] = "√";

                            //}


                        }


                    }
                    dtNew.Rows.Add(dtNewRow);
                }
            }

            dtNew.AcceptChanges();
            return Success(dtNew);


        }


        public ActionResult GetBeforeProjectInfo(string projectid)
        {
            //父级节点
            var data = dC_EngineProject_ProjectInfoApprovalDataIBLL.GetBeforeSqlTree();
            var dt = dC_EngineProject_ProjectInfoApprovalDataIBLL.GetBeforeProjectInfoss(projectid);

            // var dt = dC_EngineProject_ProjectInfoApprovalDataIBLL.GetProjectInfo(keyword);
            Hashtable ht = new Hashtable();

            DataTable dtNew = new DataTable();
            //  dtNew.Columns.Add(new DataColumn("项目程序名称"));
            //  string projectname = string.Empty;

            DataRow dtNewRow = dtNew.NewRow();

            foreach (DataRow dr in data.Rows)
            {
                if (dr["f_itemcode"].ToString() == "ProjectBegin")
                {
                    DataRow[] drrows = data.Select("f_parentid ='" + dr["f_itemid"].ToString() + "'", "F_sortCode ");

                    foreach (DataRow dr1 in drrows)
                    {

                        DataRow[] drrows2 = data.Select("f_parentid ='" + dr1["f_itemid"].ToString() + "'", "F_sortCode ");

                        if (drrows2 != null && drrows2.Length > 0)
                        {

                            foreach (DataRow dr3 in drrows2)
                            {
                                var dataitem = dataItemIBLL.GetDetailList(dr3["F_ItemCode"].ToString());
                                foreach (var item in dataitem)
                                {

                                    dtNew.Columns.Add(new DataColumn(item.F_ItemName));
                                    dtNewRow[item.F_ItemName] = item.F_ItemName;
                                    ht.Add(item.F_ItemName, item.F_ItemDetailId);

                                }
                            }

                        }
                        else
                        {
                            var dataitem = dataItemIBLL.GetDetailList(dr1["F_ItemCode"].ToString());
                            foreach (var item in dataitem)
                            {

                                dtNew.Columns.Add(new DataColumn(item.F_ItemName));
                                dtNewRow[item.F_ItemName] = item.F_ItemName;
                                ht.Add(item.F_ItemName, item.F_ItemDetailId);

                            }

                        }

                    }

                }

            }
            dtNew.Rows.Add(dtNewRow);
            //  dtNew.AcceptChanges();

            dtNewRow = dtNew.NewRow();

            foreach (DataRow dtrow in dt.Rows)
            {
                foreach (string key in ht.Keys)
                {
                    DataRow[] dtTemp = dt.Select("F_ProjectStage ='" + ht[key].ToString() + "'");

                    if (dtTemp != null && dtTemp.Length > 0)
                    {
                        //  dtNewRow[key] = dtTemp[0]["F_DataName"];
                        //if (dtTemp[0]["F_ActualEndDate"].IsEmpty())
                        //{
                        //    if (!dtTemp[0]["F_PlannedEndDate"].IsEmpty())
                        //    {

                        //        dtNewRow[key] = dtTemp[0]["F_PlannedEndDate"].ToString().Substring(0, 10);

                        //    }

                        //}
                        //else
                        //{
                        //    dtNewRow[key] = "√";

                        //}

                        if (dtTemp[0]["F_ActualEndDate"].IsEmpty())
                        {
                            if (!dtTemp[0]["F_PlannedEndDate"].IsEmpty())
                            {

                                dtNewRow[key] = dtTemp[0]["F_PlannedEndDate"].ToString().Substring(0, 10);

                            }
                            else
                            {
                                dtNewRow[key] = dtTemp[0]["F_DataCode"];

                            }

                        }
                        else
                        {
                            dtNewRow[key] = dtTemp[0]["F_ActualEndDate"].ToString().Substring(0, 10);

                        }


                    }
                    else
                    {
                        dtNewRow[key] = string.Empty;

                    }




                }

            }

            dtNew.Rows.Add(dtNewRow);

            dtNew.AcceptChanges();

            return Success(dtNew);


        }
    }
}