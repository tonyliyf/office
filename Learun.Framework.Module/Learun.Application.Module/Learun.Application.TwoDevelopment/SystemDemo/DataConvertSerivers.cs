using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Learun.Application.Base.SystemModule;
using Learun.Application.TwoDevelopment.EcologyDemo;

namespace Learun.Application.TwoDevelopment.SystemDemo
{
    public class DataConvertSerivers
    {
        private DataItemIBLL dataitembll = new DataItemBLL();
        private HrmResourceIBLL resourceBll = new HrmResourceBLL();
        private HrmSubCompanyIBLL companyBll = new HrmSubCompanyBLL();
        private HrmDepartmentIBLL departBll = new HrmDepartmentBLL();
        public void ConvertDataByDataItem(DataTable dt, Dictionary<string, string> dic)
        {

            Dictionary<string, List<DataItemDetailEntity>> dicItem = new Dictionary<string, List<DataItemDetailEntity>>();
            foreach (KeyValuePair<string, string> pair in dic)
            {
                var list = dataitembll.GetDetailList(pair.Value);
                dicItem.Add(pair.Key.ToLower(), list);

            }
            foreach (DataRow dr in dt.Rows)
            {

                foreach (KeyValuePair<string, string> pair in dic)
                {
                    var DataItem = (List<DataItemDetailEntity>)dicItem[pair.Key.ToLower()];

                    foreach (var item in DataItem)
                    {
                        if (dr[pair.Key.ToLower()].ToString() == item.F_ItemValue)
                        {
                            dr[pair.Key.ToLower()] = item.F_ItemName;

                        }
                    }
                }
                dr.AcceptChanges();

            }
            dt.AcceptChanges();

        }

        /// <summary>
        /// 泛微人员转换 ，id转为名字
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="FieldNames"></param>
        public void ConvertDataByWeaveHrmResouce(DataTable dt, string[] FieldNames)
        {
            int id = 0;
            foreach(var FieldName in FieldNames)
            {

                dt.Columns.Add(FieldName + "Hrm");
            }

            foreach (DataRow dr in dt.Rows)
            {
                foreach (var FieldName in FieldNames)
                {
                    if (!string.IsNullOrEmpty(dr[FieldName].ToString()))
                    {
                        string num = dr[FieldName].ToString();

                        if (!num.Contains(',')) {
                            id = int.Parse(dr[FieldName].ToString());
                            var item = resourceBll.GetEntity(id);
                            if (null != item)
                            {
                                dr[FieldName + "Hrm"] = item.lastname;
                            }

                        }
                        else
                        {
                            string[] sArray = Regex.Split(num, ",", RegexOptions.IgnoreCase);

                            string fieldName = "";

                            foreach (string i in sArray)
                            {
                                var item1 = resourceBll.GetEntity(Convert.ToInt32(i));
                                int code = 0;
                                if (null != item1)
                                {
                                    if (code == 0)
                                    {
                                        fieldName = item1.lastname;
                                        code++;
                                    }
                                    else
                                    {

                                        fieldName += "," + item1.lastname;
                                    }

                                }
                            }
                            dr[FieldName + "Hrm"] = fieldName;

                        }
                            

                    }
                }

               dr.AcceptChanges();

            }
            dt.AcceptChanges();

        }


        /// <summary>
        /// 泛微子公司转换 id转为名字
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="FieldNames"></param>
        public void ConvertDataByWeaveHrmCompany(DataTable dt, string[] FieldNames)
        {
            int id = 0;

            foreach (var FieldName in FieldNames)
            {

                dt.Columns.Add(FieldName + "ComPany");
            }

            foreach (DataRow dr in dt.Rows)
            {
                foreach (var FieldName in FieldNames)
                {
                    if (!string.IsNullOrEmpty(dr[FieldName].ToString()))
                    {
                        string num = dr[FieldName].ToString();
                        if (!num.Contains(','))
                        {
                            id = int.Parse(dr[FieldName].ToString());
                            var item = companyBll.GetEntity(id);
                            if (null != item)
                            {
                                dr[FieldName + "ComPany"] = item.subcompanyname;
                            }
                        }
                        else {
                            string[] sArray = Regex.Split(num, ",", RegexOptions.IgnoreCase);

                            string fieldName = "";

                            foreach (string i in sArray)
                            {
                                var item1 = companyBll.GetEntity(Convert.ToInt32(i));
                                int code = 0;
                                if (null != item1)
                                {
                                    if (code == 0)
                                    {
                                        fieldName = item1.subcompanyname;
                                        code++;
                                    }
                                    else
                                    {

                                        fieldName += "," + item1.subcompanyname;
                                    }

                                }
                            }
                            dr[FieldName + "ComPany"] = fieldName;

                        }
                       
                    }
                }

                dr.AcceptChanges();

            }
            dt.AcceptChanges();

        }


        /// <summary>
        /// 部门转换 id转为名字
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="FieldNames"></param>
        public void ConvertDataByWeaveDepartment(DataTable dt, string[] FieldNames)
        {
            int id = 0;

            foreach (var FieldName in FieldNames)
            {

                dt.Columns.Add(FieldName + "Depart");
            }

            foreach (DataRow dr in dt.Rows)
            {
                foreach (var FieldName in FieldNames)
                {
                    if (!string.IsNullOrEmpty(dr[FieldName].ToString()))
                    {
                        string num = dr[FieldName].ToString();
                        if (!num.Contains(','))
                        {
                            id = int.Parse(dr[FieldName].ToString());
                            var item = departBll.GetEntity(id);
                            if (null != item)
                            {
                                dr[FieldName + "Depart"] = item.departmentname;
                            }
                        }
                        else {
                            string[] sArray = Regex.Split(num, ",", RegexOptions.IgnoreCase);

                            string fieldName = "";

                            foreach (string i in sArray)
                            {
                                var item = departBll.GetEntity(Convert.ToInt32(i));
                                int code = 0;
                                if (null != item) {
                                    if (code == 0)
                                    {
                                        fieldName = item.departmentname;
                                        code++;
                                    }
                                    else {

                                        fieldName +=","+ item.departmentname;
                                    }
                                    
                                }
                            }
                            dr[FieldName + "Depart"] = fieldName;
                        }
 
                    }
                }

                dr.AcceptChanges();

            }
            dt.AcceptChanges();

        }

    }
}
