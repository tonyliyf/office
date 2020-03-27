using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Learun.Util
{
    public class DataTable_RowToColumn
    {
        /// <summary>
        /// 动态Linq方式实现行转列
        /// </summary>
        /// <param name="list">数据</param>
        /// <param name="DimensionList">维度列</param>
        /// <param name="DynamicColumn">动态列</param>
        /// <returns>行转列后数据</returns>
        private static DataTable RowToColumn(DataTable dt, List<string> DimensionList, string DynamicColumn, out List<string> AllDynamicColumn)
        {
            //获取所有动态列
            AllDynamicColumn = new List<string>();
            foreach (DataRow dr in dt.DefaultView.ToTable(true, DynamicColumn).Rows)
            {
                if (dr[DynamicColumn] != null && !string.IsNullOrEmpty(dr[DynamicColumn].ToString()))
                {
                    AllDynamicColumn.Add(dr[DynamicColumn].ToString());
                }
            }

            //数值列
            Dictionary<string, Type> AllNumberColumn = new Dictionary<string, Type>();
            foreach (DataColumn item in dt.Columns)
            {
                if (item.DataType == typeof(int) || item.DataType == typeof(double) || item.DataType == typeof(float))
                {
                    AllNumberColumn.Add(item.ColumnName, item.DataType);
                }
            }

            //结果DataTable创建
            DataTable dtResult = new DataTable();
            foreach (var item in DimensionList)
            {
                dtResult.Columns.Add(item, typeof(string));
            }
            //动态列
            foreach (var dynamicValue in AllDynamicColumn)
            {
                foreach (var item in AllNumberColumn.Keys)
                {
                    dtResult.Columns.Add(item + dynamicValue, AllNumberColumn[item]);
                }
            }

            //分组-优化性能
            Dictionary<string, List<DataRow>> dict = new Dictionary<string, List<DataRow>>();
            List<DataRow> drList = null;
            string groupKey = "";
            foreach (DataRow dr in dt.Rows)
            {
                groupKey = "";
                foreach (var item in DimensionList)
                {
                    groupKey += dr[item] + "#";
                }
                if (!dict.TryGetValue(groupKey, out drList))
                {
                    drList = new List<DataRow>();
                    dict[groupKey] = drList;
                }
                drList.Add(dr);
            }

            DataRow drReult = null;
            DataTable dtTemp = null;
            Dictionary<object, DataTable> dictTable = null;
            foreach (var kv in dict)
            {
                drReult = dtResult.NewRow();
                var arrKey = kv.Key.Split('#');
                int i = 0;
                foreach (var key in DimensionList)
                {
                    drReult[key] = arrKey[i];
                    i++;
                }
                dictTable = (from p in kv.Value.AsEnumerable()
                             group p by p.Field<object>(DynamicColumn) into g
                             select g).ToDictionary(e => e.Key, e => e.CopyToDataTable());
                foreach (var dynamicValue in AllDynamicColumn)
                {
                    if (dictTable.TryGetValue(dynamicValue, out dtTemp))
                    {
                        foreach (var numColumn in AllNumberColumn.Keys)
                        {
                            drReult[numColumn + dynamicValue] = dtTemp.Compute("sum(" + numColumn + ")", "");
                        }
                    }
                    else
                    {
                        foreach (var numColumn in AllNumberColumn.Keys)
                        {
                            drReult[numColumn + dynamicValue] = 0;
                        }
                    }
                }
                dtResult.Rows.Add(drReult);
            }
            return dtResult;
        }


        private static DataTable InitTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Area", typeof(string));
            dt.Columns.Add("Month", typeof(string));
            dt.Columns.Add("DfMoney", typeof(double));
            dt.Columns.Add("SfMoney", typeof(double));
            dt.Columns.Add("RqfMoney", typeof(double));

            DataRow row = dt.NewRow();
            row["Name"] = "张三";
            row["Month"] = "2016-01";
            row["Area"] = "江夏区";
            row["DfMoney"] = 240.9;
            row["SfMoney"] = 30;
            row["RqfMoney"] = 25;
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Name"] = "张三";
            row["Month"] = "2016-02";
            row["Area"] = "江夏区";
            row["DfMoney"] = 167;
            row["SfMoney"] = 24.5;
            row["RqfMoney"] = 17.9;
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Name"] = "小燕子";
            row["Month"] = "2016-01";
            row["Area"] = "江夏区";
            row["DfMoney"] = 340.9;
            row["SfMoney"] = 20;
            row["RqfMoney"] = 55;
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Name"] = "小燕子";
            row["Month"] = "2016-02";
            row["Area"] = "江夏区";
            row["DfMoney"] = 67;
            row["SfMoney"] = 64.5;
            row["RqfMoney"] = 77.9;
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Name"] = "李四";
            row["Month"] = "2016-01";
            row["Area"] = "洪山区";
            row["DfMoney"] = 56.7;
            row["SfMoney"] = 24.7;
            row["RqfMoney"] = 13.2;
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Name"] = "李四";
            row["Month"] = "2016-02";
            row["Area"] = "洪山区";
            row["DfMoney"] = 65.2;
            row["SfMoney"] = 18.9;
            row["RqfMoney"] = 14.9;
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Name"] = "尔康";
            row["Month"] = "2016-01";
            row["Area"] = "洪山区";
            row["DfMoney"] = 156.7;
            row["SfMoney"] = 124.7;
            row["RqfMoney"] = 33.2;
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Name"] = "尔康";
            row["Month"] = "2016-02";
            row["Area"] = "洪山区";
            row["DfMoney"] = 35.2;
            row["SfMoney"] = 28.9;
            row["RqfMoney"] = 44.9;
            dt.Rows.Add(row);
            return dt;
        }

        static void Main(string[] args)
        {
            DataTable dt = InitTable();
            List<string> DimensionList = new List<string>() { "Area", "Month" };
            string DynamicColumn = "Name";
            List<string> AllDynamicColumn = null;
            DataTable dtResult = RowToColumn(dt, DimensionList, DynamicColumn, out AllDynamicColumn);
            Console.WriteLine(JsonConvert.SerializeObject(dtResult, Formatting.Indented));
            Console.Read();
        }
    }
}
