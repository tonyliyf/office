using Learun.Application.Form;
using Learun.Application.WorkFlow;
using Learun.DataBase.Repository;
using Learun.Util;
using Learun.Workflow.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Learun.Application.Web.Areas.LR_CodeDemo.Controllers
{
    public class WfPrintController : MvcControllerBase
    {
        private RepositoryFactory repository = new RepositoryFactory();
        // GET: LR_CodeDemo/WfPrint
        public ActionResult Index(string processId, string taskId)
        {
            List<string> hideIdList = new List<string>();
            var model = GetModel(processId, taskId, hideIdList);
            ViewBag.content = GetRenderData(model, processId, hideIdList);
            ViewBag.url = "data:image/jpg;base64," + Util.QrCode.QrCodeGenerater.Generate(processId);
            return View();
        }
        public ActionResult GetColumeCount(string processId, string taskId)
        {
            List<string> hideIdList = new List<string>();
            var model = GetModel(processId, taskId, hideIdList);
            var count = 8;
            if (model != null)
            {
                foreach (var item in model.data)
                {
                    foreach (var compont in item.componts)
                    {
                        if (compont.type == "girdtable")
                        {
                            if (compont.fieldsData.Count > 8)
                            {
                                count = compont.fieldsData.Count - hideIdList.Count;
                                goto _out;
                            }
                        }
                    }
                }
            }
            _out:
            return Json(new { count = count });
        }
        public Container1 GetModel(string processId, string taskId, List<string> hideIdList = null)
        {
            UserInfo user = LoginUserInfo.Get();
            var data = new NWFProcessBLL().GetProcessDetails(processId, taskId, user);
            var wfScheme = data.Scheme.ToObject<TempScheme>();
            var formSchemeId = string.Empty;
            foreach (var node in wfScheme.nodes)
            {
                if (node.wfForms != null)
                {
                    foreach (var form in node.wfForms)
                    {
                        if (!string.IsNullOrWhiteSpace(form.formId))
                        {
                            formSchemeId = form.formId;
                            foreach (KeyValuePair<string, TempScheme.TempNode.TempForm.AuthModel> pair in form.authorize)
                            {
                                if (pair.Value.isLook == "0")
                                {
                                    string[] arr = pair.Key.Split('|');
                                    if (arr.Length > 1 && hideIdList != null)
                                    {
                                        hideIdList.Add(arr[1]);
                                    }
                                }
                            }
                            goto _out;
                        }
                    }
                }
            }
            return null;
            _out:
            var formSchemeIBLL = new FormSchemeBLL();
            FormSchemeInfoEntity schemeInfoEntity = formSchemeIBLL.GetSchemeInfoEntity(formSchemeId);
            FormSchemeEntity schemeEntity = formSchemeIBLL.GetSchemeEntity(schemeInfoEntity.F_SchemeId);
            return schemeEntity.F_Scheme.ToObject<Container1>();
        }
        public string GetRenderData(Container1 scheme, string processId, List<string> hideIdList)
        {
            if (scheme == null)
            {
                return string.Empty;
            }
            if (scheme.dbTable.Count > 0)
            {
                var sb = new StringBuilder();
                Dictionary<string, DataTable> tableDic = new Dictionary<string, DataTable>();
                foreach (var item in scheme.dbTable)
                {
                    if (!tableDic.ContainsKey(item.name))
                    {
                        DataTable dt = repository.BaseRepository().FindTable("select * from " + item.name + " where "
                                    + item.field + " = " + "'" + processId + "'");
                        tableDic.Add(item.name, dt);
                    }
                }
                int rowPercent = 0;
                foreach (var item in scheme.data)
                {
                    foreach (var compont in item.componts)
                    {
                        if (compont.type == "label")
                        {
                            sb.Append("<tr><td colspan='18'>" + compont.title + "</td><tr/>");
                            continue;
                        }
                        if (tableDic.ContainsKey(compont.table))
                        {
                            DataTable dt = tableDic[compont.table];
                            if (compont.isHide != "1" && compont.type != "guid" && compont.type != "upload")
                            {
                                if (rowPercent >= 100)
                                {
                                    rowPercent = 0;
                                    sb.Append("</tr>");
                                }
                                if (rowPercent == 0)
                                {
                                    sb.Append("<tr>");
                                }
                                var proportion = compont.proportion;
                                rowPercent += 100 / proportion;
                                sb.Append("<td colspan='" + 3 + "'>");
                                sb.Append(compont.title);
                                sb.Append("</td><td colspan='" + (18 / proportion - 3) + "'>");
                                var obj = string.IsNullOrWhiteSpace(compont.field) ? "" : dt.Rows[0][compont.field];
                                switch (compont.type)
                                {
                                    case "radio":
                                    case "select":
                                        if (compont.dataSource == "0")
                                        {
                                            sb.Append(GetDataItem(obj.ToString(), compont.itemCode));
                                        }
                                        else
                                        {
                                            string[] arr = compont.dataSourceId.Split(',');
                                            if (arr.Length >= 3)
                                            {
                                                sb.Append(GetDataSource(obj.ToString(), arr[0], arr[1], arr[2]));
                                            }
                                        }
                                        break;
                                    case "checkbox":
                                        var strValue = string.Empty;
                                        if (compont.dataSource == "0")
                                        {
                                            foreach (var str in obj.ToString().Split(','))
                                            {
                                                strValue += GetDataItem(str, compont.itemCode) + ",";
                                            }
                                            if (strValue.Length > 0)
                                            {
                                                strValue = strValue.Substring(0, strValue.Length - 1);
                                            }
                                        }
                                        else
                                        {
                                            string[] arr = compont.dataSourceId.Split(',');
                                            if (arr.Length >= 3)
                                            {
                                                foreach (var str in obj.ToString().Split(','))
                                                {
                                                    strValue += GetDataSource(str, arr[0], arr[1], arr[2]) + ",";
                                                }
                                                if (strValue.Length > 0)
                                                {
                                                    strValue = strValue.Substring(0, strValue.Length - 1);
                                                }
                                            }
                                            sb.Append(strValue);
                                        }
                                        break;
                                    case "datetime":
                                        sb.Append(Convert.ToDateTime(obj).ToString("yyyy-MM-dd"));
                                        break;
                                    case "organize":
                                    case "currentInfo":
                                        switch (compont.dataType)
                                        {
                                            case "user":
                                                sb.Append(GetUser(obj.ToString()));
                                                break;
                                            case "department":
                                                sb.Append(GetDepartment(obj.ToString()));
                                                break;
                                            case "company":
                                                sb.Append(GetCompany(obj.ToString()));
                                                break;
                                            default:
                                                break;
                                        }
                                        break;
                                    case "girdtable":
                                        if (dt.Rows.Count > 0)
                                        {
                                            sb.Append("<table>");
                                            sb.Append("<tr>");
                                            foreach (var field in compont.fieldsData)
                                            {
                                                if (!hideIdList.Contains(field.id))
                                                {
                                                    sb.Append("<td>");
                                                    sb.Append(field.name);
                                                    sb.Append("</td>");
                                                }
                                            }
                                            sb.Append("</tr>");
                                            foreach (DataRow row in dt.Rows)
                                            {
                                                sb.Append("<tr>");
                                                foreach (var field in compont.fieldsData)
                                                {
                                                    if (!hideIdList.Contains(field.id))
                                                    {
                                                        sb.Append("<td>");
                                                        if (dt.Columns[field.field].DataType == DateTime.Now.GetType())
                                                        {
                                                            sb.Append((row[field.field] != null ? row[field.field].ToDate().ToString("yyyy-MM-dd") : "").ToString());
                                                        }
                                                        else
                                                        {
                                                            sb.Append((row[field.field] ?? "").ToString());
                                                        }
                                                        sb.Append("</td>");
                                                    }
                                                }
                                                sb.Append("</tr>");
                                            }
                                            sb.Append("</table>");
                                        }
                                        break;
                                    default:
                                        sb.Append(obj.ToString());
                                        break;
                                }
                            }
                            sb.Append("</td>");
                        }
                    }

                    NWFTaskIBLL bll = new NWFTaskBLL();
                    sb.Append("<tr><td colspan='3'>");
                    sb.Append("审批意见");
                    sb.Append("</td><td colspan='15'>");
                    sb.Append(bll.GetTaskLogInfo(processId, 1));
                    sb.Append("</td></tr>");

                    sb.Append("<tr><td colspan='3'>");
                    sb.Append("传阅意见");
                    sb.Append("</td><td colspan='15'>");
                    sb.Append(bll.GetTaskLogInfo(processId, 2));
                    sb.Append("</td></tr>");
                }
                return sb.ToString();
            }
            else
            {
                return null;
            }
        }
        public string GetDataItem(string keyValue, string code)
        {
            return (this.repository.BaseRepository().FindObject("  select top 1 F_ItemName from lr_base_dataitemdetail where f_itemid = (select top 1 f_itemid from lr_base_dataitem where f_itemcode = @code) and f_itemvalue = @value",
                new { code = code, value = keyValue }) ?? "").ToString();
        }
        public string GetDataSource(string keyValue, string code, string fieldName, string fieldId)
        {
            string sql = this.repository.BaseRepository().FindObject("  select top 1 f_sql from lr_base_datasource where f_code = @code", new { code = code }).ToString();
            if (string.IsNullOrWhiteSpace(sql))
            {
                return "";
            }
            return (this.repository.BaseRepository().FindObject("select t." + fieldName + "  from  (" + sql + ") t where t." + fieldId + "  =@param", new { param = keyValue }) ?? "").ToString();
        }
        public string GetCompany(string keyValue)
        {
            return (this.repository.BaseRepository().FindObject("  select top 1 f_fullname from lr_base_company where f_companyid=@id", new { id = keyValue }) ?? "").ToString();
        }
        public string GetUser(string keyValue)
        {
            return (this.repository.BaseRepository().FindObject("  select top 1 f_realname from lr_base_user where f_userid = @id", new { id = keyValue }) ?? "").ToString();
        }
        public string GetDepartment(string keyValue)
        {
            return (this.repository.BaseRepository().FindObject("   select top 1 f_fullname from lr_base_department where f_departmentid = @id", new { id = keyValue }) ?? "").ToString();
        }
    }
    public class TempScheme
    {
        public List<TempNode> nodes { get; set; }
        public class TempNode
        {
            public List<TempForm> wfForms { get; set; }
            public class TempForm
            {
                public string type { get; set; }
                public string formId { get; set; }
                public Dictionary<string, AuthModel> authorize { get; set; }
                public class AuthModel
                {
                    public string isLook { get; set; }
                    public string isEdit { get; set; }
                }
            }
        }
    }

    public class Container1
    {
        public List<Container2> data { get; set; }
        public List<Table1> dbTable { get; set; }
        public class Container2
        {
            public List<Compont> componts { get; set; }
            public class Compont
            {
                public string title { get; set; }
                public string type { get; set; }
                public string table { get; set; }
                public string field { get; set; }
                public int proportion { get; set; }
                public string dataSource { get; set; }
                public string dataSourceId { get; set; }
                public string itemCode { get; set; }
                public string isHide { get; set; }
                public string dataType { get; set; }
                public List<TableField> fieldsData { get; set; }
                public class TableField
                {
                    public string name { get; set; }
                    public string type { get; set; }
                    public string dataSource { get; set; }
                    public string field { get; set; }
                    public string id { get; set; }
                }
            }
        }
        public class Table1
        {
            public string name { get; set; }
            public string field { get; set; }
            public string relationName { get; set; }
            public string relationField { get; set; }
        }
    }
}