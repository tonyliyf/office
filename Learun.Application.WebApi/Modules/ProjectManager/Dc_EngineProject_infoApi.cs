using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Nancy;
using Learun.Util;
using Learun.Application.TwoDevelopment.ProjectManager;
using Learun.Application.Base.SystemModule;
using System.Collections;
using System.Data;
using Learun.Application.TwoDevelopment.EcologyDemo;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Text;

namespace Learun.Application.WebApi.Modules.ProjectManager
{
    public class Dc_EngineProject_infoApi : BaseApi
    {
        private DC_EngineProject_ProjectInfoIBLL dC_EngineProject_BuilderDiaryMainIBLL = new DC_EngineProject_ProjectInfoBLL();
        private DataItemIBLL dataItemIBLL = new DataItemBLL();
        private DC_EngineProject_ProjectInfoApprovalDataIBLL dC_EngineProject_ProjectInfoApprovalDataIBLL = new DC_EngineProject_ProjectInfoApprovalDataBLL();
        private ProjectAttenceRecordIBLL projectAttenceRecordIBLL = new ProjectAttenceRecordBLL();
        private DC_EngineProject_BuilderDiaryMainIBLL BuilderDiaryMainIBLL = new DC_EngineProject_BuilderDiaryMainBLL();
        private DC_EngineProject_ProjectProgressBLL ProjectProgressIBLL = new DC_EngineProject_ProjectProgressBLL();
        private formtable_main_150IBLL formtable_main_150IBLL = new formtable_main_150BLL();
        private DC_EngineProject_MeetingRecordIBLL MeetingRecordIBLL = new DC_EngineProject_MeetingRecordBLL();
        private DC_EngineProject_ProjectInfoContractIBLL ProjectInfoContractIBLL = new DC_EngineProject_ProjectInfoContractBLL();
        private UrlRepalceUtil urlRelpace = new UrlRepalceUtil();
        /// <summary> 
        /// 注册接口 
        /// <summary> 
        public Dc_EngineProject_infoApi()
            : base("/learun/adms/ProjectManager/Dc_EngineProject_info")
        {
            Get["/pagelist"] = GetPageList;

            Get["/GetProjectInfo"] = GetProjectInfo;

            Post["/GetProjectContractInfo"] = GetProjectContractInfo;

            Post["/GetBeforeProjectInfo"] = GetBeforeProjectInfoss;

            Post["/GetBeforeProjectInfoss"] = GetBeforeProjectInfossinfo;

            Post["/GetProjectAttenced"] = GetProjectAttenced;

            Post["/GetMainRecord"] = GetMainRecord;

            Post["/GetProjectProgress"] = GetProjectProgress;

            Get["/Getformtable_main_150List"] = Getformtable_main_150List;

            Get["/GetMeetingRecordData"] = GetMeetingRecordData;

            Get["/GetProjectContractType"] = GetProjectContractType;

            Get["/GetMainRecordNew"] = GetMainRecordNew;
        }
        #region 获取数据 

        /// <summary> 
        /// 获取页面显示列表分页数据 
        /// <summary> 
        /// <param name="_"></param> 
        /// <returns></returns> 
        public Response GetPageList(dynamic _)
        {
            ReqPageParam parameter = this.GetReqData<ReqPageParam>();
            Pagination pagination = new Pagination();
            pagination.rows = 5000;
            string queryJson =@"{ 'StartTime':'1753-01-01','EndTime':'3000-01-01'}";
            //parameter.pagination.rows = 5000;
            var data = dC_EngineProject_BuilderDiaryMainIBLL.GetPageList(pagination, queryJson);
            var jsonData = new
            {
                rows = data,
                total = pagination.total,
                page =pagination.page,
                records = pagination.records
            };
            return Success(jsonData);
        }

        public Response GetProjectInfo(dynamic _)
        {
            var data = dC_EngineProject_BuilderDiaryMainIBLL.GetProjectInfo1();
            var data1 = dC_EngineProject_BuilderDiaryMainIBLL.GetProjectOS_F_State();
          //  LogUtil.WriteTextLog("ProjectInfo", data.Count().ToString(), DateTime.Now);
            var jsondata = new
            {
                data = data,
                State = data1

            };
            return Success(jsondata);

        }
        /// <summary>
        /// 获取项目进度信息
        /// <summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetProjectProgress(dynamic _)
        {
            string temp = this.GetReqData();
            //LogUtil.WriteTextLog("temp", temp, DateTime.Now);

            var queryParam = temp.ToJObject();
            // 虚拟参数

            if (!queryParam["projectid"].IsEmpty())
            {
                var data = ProjectProgressIBLL.GetProjectProgress(queryParam["projectid"].ToString());
                return Success(data);
            }

            else
            {

                return null;
            }
        }
        
        /// <summary>
        /// 获取项目进度信息
        /// <summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response Getformtable_main_150List(dynamic _)
        {
            string temp = this.GetReqData();
            //LogUtil.WriteTextLog("temp", temp, DateTime.Now);

            var queryParam = temp.ToJObject();
            // 虚拟参数

            if (!queryParam["F_PIId"].IsEmpty())
            {
                var data = formtable_main_150IBLL.Getformtable_main_150List(queryParam["F_PIId"].ToString());
                return Success(data);
            }

            else
            {

                return null;
            }
        }
        /// <summary>
        /// 获取合同信息
        /// <summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetProjectContractInfo(dynamic _)
        {


            try
            {

               // LogUtil.WriteTextLog("GetProjectContractInfo", "test", DateTime.Now);
                string temp = this.GetReqData();
                // LogUtil.WriteTextLog("temp", temp, DateTime.Now);

                var queryParam = temp.ToJObject();
                // 虚拟参数



             //   LogUtil.WriteTextLog("projectidContract", queryParam["projectid"].ToString(), DateTime.Now);

             //   LogUtil.WriteTextLog("F_ItemValueContrace", queryParam["F_ItemValue"].ToString(), DateTime.Now);
                // LogUtil.WriteTextLog("queryParam[projectid]", queryParam["projectid"].ToString(), DateTime.Now);
                var data = dC_EngineProject_BuilderDiaryMainIBLL.GetProjectContract(queryParam["projectid"].ToString(), queryParam["F_ItemValue"].ToString(), queryParam["F_PICId"].ToString());
                  

                    // string systemUrl = Config.GetValue("systemUrl");
                    //  string ServerUrl = Config.GetValue("ServerUrl");
                    for (int a = 0; a < data.Rows.Count; a++)
                    {

                        if (data.Rows[a]["F_FolderId"].ToString() != "")
                        {
                            // data.Rows[a]["F_ContractAppendices"] = systemUrl + ":" + data.Columns["F_ContractAppendices"].ToString().Split(':')[1];
                            //data.Rows[a]["F_ContractAppendices"] = UrlRepalceUtil.ReplaceUrl(data.Rows[a]["F_ContractAppendices"].ToString());
                            // data.Rows[a]["F_ContractAppendices"] = data.Rows[a]["F_ContractAppendices"].ToString().Replace(ServerUrl, systemUrl);

                            // Regex.Replace(item.F_FilePath, temp, Request.ApplicationPath, RegexOptions.IgnoreCase);
                            data.Rows[a]["F_ContractAppendices"] = urlRelpace.GetUrl(data.Rows[a]["F_FolderId"].ToString());

                            LogUtil.WriteTextLog("files", data.Rows[a]["F_ContractAppendices"].ToString(), DateTime.Now);
                        }

                    }

                    var jsondata = new
                    {
                        data = data
                    };

                    return Success(jsondata);
               
               
            }
            catch(Exception ex)
            {

                LogUtil.WriteTextLog("合同信息", ex.Message, DateTime.Now);
                return null;


            }  
        }
        /// <summary>
        /// 获取合同类型信息
        /// <summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetProjectContractType(dynamic _)
        {


            try
            {         
                    var data1 = ProjectInfoContractIBLL.GetProjectContractType();

                    var jsondata = new
                    {
                        ContractType = data1

                    };

                    return Success(jsondata);
              
            }
            catch (Exception ex)
            {

                LogUtil.WriteTextLog("合同类型信息", ex.Message, DateTime.Now);
                return null;


            }
        }

        public Response GetBeforeProjectInfoss(dynamic _)
        {

            string temp = this.GetReqData();
            var queryParam = temp.ToJObject();
            var dt = dC_EngineProject_ProjectInfoApprovalDataIBLL.GetBeforeProjectInfoss(queryParam["projectid"].ToString());
            var data = dC_EngineProject_ProjectInfoApprovalDataIBLL.GetBeforeInfoTree();
            DataTable dtNew = new DataTable();
            DataRow dtNewRow = dtNew.NewRow();
            dtNew.Columns.Add(new DataColumn("text"));
            dtNew.Columns.Add(new DataColumn("F_ProjectStage"));
            foreach (var item in data)
            {

                //LogUtil.WriteTextLog("F_ProjectStage", "eeee", DateTime.Now);

                DataRow[] dtTemp = dt.Select("F_ProjectStage ='" + item.id + "'");

                if (dtTemp != null && dtTemp.Length > 0)
                {

                    dtNewRow = dtNew.NewRow();
                    dtNewRow["text"] = item.text;
                    dtNewRow["F_ProjectStage"] = item.id;

                    dtNew.Rows.Add(dtNewRow);

                }

            }

            
            dtNew.AcceptChanges();

           // LogUtil.WriteTextLog("F_ProjectStage", dtNew.Rows.Count.ToString(), DateTime.Now);
            return Success(dtNew);

        }

        public Response GetBeforeProjectInfossinfo(dynamic _)
        {

            string temp = this.GetReqData();
            var queryParam = temp.ToJObject();

           // LogUtil.WriteTextLog("queryParam[projectid]", queryParam["projectid"].ToString(), DateTime.Now);
            var dt = dC_EngineProject_ProjectInfoApprovalDataIBLL.GetBeforeProjectInfoss(queryParam["projectid"].ToString());
         
            DataTable dtNew = new DataTable();
            DataRow dtNewRow = dtNew.NewRow();

            LogUtil.WriteTextLog("queryParam[F_ProjectStage]", queryParam["F_ProjectStage"].ToString(), DateTime.Now);

            dtNew.Columns.Add(new DataColumn("F_DataCode"));
            dtNew.Columns.Add(new DataColumn("F_DataName"));
            dtNew.Columns.Add(new DataColumn("F_PlannedStartDate"));
            dtNew.Columns.Add(new DataColumn("F_ActualEndDate"));
            dtNew.Columns.Add(new DataColumn("F_DataPhoto"));
            dtNew.Columns.Add(new DataColumn("F_Attachment"));

            DataRow[] dtTemp = dt.Select("F_ProjectStage ='" + queryParam["F_ProjectStage"].ToString() + "'");

                if (dtTemp != null && dtTemp.Length > 0)
                {
                  
                    dtNewRow["F_DataCode"] = dtTemp[0]["F_DataCode"];

                   
                    dtNewRow["F_DataName"] = dtTemp[0]["F_DataName"];

                   
                    dtNewRow["F_PlannedStartDate"] = dtTemp[0]["F_PlannedStartDate"];

                   
                    dtNewRow["F_ActualEndDate"] = dtTemp[0]["F_ActualEndDate"];
                    


                    if (!dtTemp[0]["F_DataPhoto"].IsEmpty())
                    {

                        dtNewRow["F_DataPhoto"] = urlRelpace.GetUrl(dtTemp[0]["F_DataPhoto"].ToString());
                    }

                    if (!dtTemp[0]["F_Attachment"].IsEmpty())
                    {

                        dtNewRow["F_Attachment"] = urlRelpace.GetUrl(dtTemp[0]["F_Attachment"].ToString());
                    }

                }
          


            dtNew.Rows.Add(dtNewRow);
            dtNew.AcceptChanges();
            return Success(dtNew);

        }

        /// <summary>
        /// 获取项目前期数据
        /// <summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetBeforeProjectInfo(dynamic _)
        {

            try
            {

                string temp = this.GetReqData();
                // LogUtil.WriteTextLog("temp", temp, DateTime.Now);

                var queryParam = temp.ToJObject();
                var data = dC_EngineProject_ProjectInfoApprovalDataIBLL.GetBeforeSqlTree();
                var dt = dC_EngineProject_ProjectInfoApprovalDataIBLL.GetBeforeProjectInfoss(queryParam["projectid"].ToString());

                // var dt = dC_EngineProject_ProjectInfoApprovalDataIBLL.GetProjectInfo(keyword);
                Hashtable ht = new Hashtable();

                DataTable dtNew = new DataTable();
                //  dtNew.Columns.Add(new DataColumn("项目程序名称"));
                //  string projectname = string.Empty;

                DataRow dtNewRow = dtNew.NewRow();
                DataRow dtSecondRow = dtNew.NewRow();
                DataRow dtOtherRow = dtNew.NewRow();

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

                            // dtNewRow[key] = dtTemp[0]["F_DataName"];
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

                            if (!dtTemp[0]["F_DataPhoto"].IsEmpty())
                            {

                                dtSecondRow[key] = urlRelpace.GetUrl(dtTemp[0]["F_DataPhoto"].ToString());
                            }

                            if (!dtTemp[0]["F_Attachment"].IsEmpty())
                            {

                                dtOtherRow[key] = urlRelpace.GetUrl(dtTemp[0]["F_Attachment"].ToString());
                            }



                        }
                        else
                        {
                            dtNewRow[key] = string.Empty;

                        }




                    }

                }

                dtNew.Rows.Add(dtNewRow);
                dtNew.Rows.Add(dtSecondRow);
                dtNew.Rows.Add(dtOtherRow);

                dtNew.AcceptChanges();

                return Success(dtNew);
            }
            catch (Exception ex)
            {

                LogUtil.WriteTextLog("前期信息", ex.Message, DateTime.Now);

                return null;
            }
        }


        /// <summary>
        /// 获取考勤信息
        /// <summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetProjectAttenced(dynamic _)
        {
            string temp = this.GetReqData();

         //    LogUtil.WriteTextLog("temp", temp, DateTime.Now);

            var queryParam = temp.ToJObject();
            string time = "";

            string Month = DateTime.Now.Month.ToString();

            if (Convert.ToInt32(Month) < 10)
            {
                time = DateTime.Now.Year.ToString() + "-0" + DateTime.Now.Month.ToString();
            }
            else
            {
                time = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString();
            }
            return Success(projectAttenceRecordIBLL.GetRecord(queryParam["projectid"].ToString(), time, queryParam["code"].ToString()));


        }


        /// <summary>
        /// 获取施工记录信息
        /// <summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetMainRecord(dynamic _)
        {
            string temp = this.GetReqData();

           // LogUtil.WriteTextLog("tempwww", temp, DateTime.Now);
            //   LogUtil.WriteTextLog("temp", temp, DateTime.Now);

            var queryParam = temp.ToJObject();
            // string projectid = this.GetReqData();


            LogUtil.WriteTextLog("projectid", queryParam["projectid"].ToString(), DateTime.Now);
            LogUtil.WriteTextLog("code", queryParam["code"].ToString(), DateTime.Now);
            return Success(BuilderDiaryMainIBLL.GetMainRecord(queryParam["projectid"].ToString(), queryParam["code"].ToString()));


        }
        /// <summary>
        /// 获取施工记录信息月份
        /// <summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetMainRecordNew(dynamic _)
        {
            try
            {
                string temp = this.GetReqData();
             //   LogUtil.WriteTextLog("temp", temp.ToJObject().ToString(), DateTime.Now);
                var queryParam = temp.ToJObject();
                string tempx = string.Empty;
                //最大日期，最小日期
                var Time = BuilderDiaryMainIBLL.MaxTime(queryParam["projectid"].ToString());
                StringBuilder buf = new StringBuilder();

                if (!string.IsNullOrEmpty(Time.Rows[0]["maxtxsj"].ToString()))
                {
                    string Max = Time.Rows[0]["maxtxsj"].ToString();
                    string Min = Time.Rows[0]["mintxsj"].ToString();
                    DateTime MaxTime = DateTime.Parse(Max);
                    DateTime MinTime = DateTime.Parse(Min);

                    DateTime time1 = new DateTime(MaxTime.Year, MaxTime.Month, 1);
                    DateTime time2 = new DateTime(MinTime.Year, MinTime.Month, 1);

                    while (time2 <= time1)
                    {
                        buf.Append(time2.ToString("yyyyMM"));
                        buf.Append(",");
                        time2 = time2.AddMonths(1);
                    }
                }
                if (!string.IsNullOrEmpty(buf.ToString()))
                {
                    tempx = buf.ToString().Substring(0, buf.ToString().Length - 1);
                }
                //创建表
                DataTable data = new DataTable();
                //添加列
                data.Columns.Add("years", typeof(string));
                //创建行对象
                DataRow row = data.NewRow();
                //赋值
                row["years"] = tempx;
                //添加行数据
                data.Rows.Add(row);
                return Success(data);
            }
            catch {

                return null;

            }
        }
        /// <summary>
        /// 获取获取会议记录
        /// <summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetMeetingRecordData(dynamic _)
        {

            var data = MeetingRecordIBLL.GetMeetingRecordData();

            for (int a = 0; a < data.Rows.Count; a++)
            {

                if (data.Rows[a]["Attachments_FolderId"].ToString() != "")
                {

                   data.Rows[a]["F_Attachments"] = urlRelpace.GetUrl(data.Rows[a]["Attachments_FolderId"].ToString());

                   // LogUtil.WriteTextLog("files", data.Rows[a]["F_Attachments"].ToString(), DateTime.Now);
                }


                if (data.Rows[a]["ScenePictures_F_FolderId"].ToString() != "")
                {

                    data.Rows[a]["F_ScenePictures"] = urlRelpace.GetUrl(data.Rows[a]["ScenePictures_F_FolderId"].ToString());

                   
                }

            }

            return Success(data);
        }

        #endregion
    }
}