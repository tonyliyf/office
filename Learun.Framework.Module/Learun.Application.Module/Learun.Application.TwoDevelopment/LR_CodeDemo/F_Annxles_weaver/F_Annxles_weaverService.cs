using Dapper;
using Learun.Application.TwoDevelopment.EcologyDemo;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-12-16 10:45
    /// 描 述：F_Annxles_weaver
    /// </summary>
    public class F_Annxles_weaverService : RepositoryFactory
    {
        #region 构造函数和属性

        private string fieldSql;
        public F_Annxles_weaverService()
        {
            fieldSql=@"
                t.F_Id,
                t.F_FileName,
                t.F_FilePath,
                t.F_weaverid,
                t.F_Weaverdocid,
                t.F_WeaverImageId,
                t.F_commets,
                t.F_enabled,
                t.F_Weavertable
            ";
        }
        #endregion

        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<F_Annxles_weaverEntity> GetList( string queryJson )
        {
            try
            {
                //参考写法
                //var queryParam = queryJson.ToJObject();
                // 虚拟参数
                //var dp = new DynamicParameters(new { });
                //dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM F_Annxles_weaver t ");
                return this.BaseRepository().FindList<F_Annxles_weaverEntity>(strSql.ToString());
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        /// <summary>
        /// 获取列表分页数据
        /// <param name="pagination">分页参数</param>
        /// <summary>
        /// <returns></returns>
        public IEnumerable<F_Annxles_weaverEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM F_Annxles_weaver t ");
                return this.BaseRepository().FindList<F_Annxles_weaverEntity>(strSql.ToString(), pagination);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }


        public bool MoveMainRecord()
        {
            var strSql = new StringBuilder();
            string filePath = Config.GetValue("WeaverAnnexesFile");
            string FloderPath = string.Empty;
            strSql.Append(@" select t.* from ecology.dbo.formtable_main_134  t  ");
            var list = this.BaseRepository().FindList<formtable_main_134Entity>(strSql.ToString());
            bool bcreate = true;

            foreach(var item in list)
            {

                if(!string.IsNullOrEmpty(item.fj))
                {
                    FloderPath = string.Format("{0}/{1}/{2}/", filePath, "formtable_main_134", item.id);
                    SimpleLogUtil.WriteTextLog("formtable_main_134", filePath.ToString(), DateTime.Now);
                    if (Directory.Exists(FloderPath))
                    {
                        SimpleLogUtil.WriteTextLog("formtable_main_134Exists", FloderPath.ToString(), DateTime.Now);
                        continue;
                    }

                    bcreate = MoveWeaverFile((int)item.id, "formtable_main_134", item.fj);
                    if (!bcreate)
                        return false;



                }


            }
            return true;

        }


        public string GetWeaverFileUrl(int weaverid,string tablename,bool isImage)
        {
            Utils util = new Utils();
            string temp = string.Empty;
            int i = 0;
            var strSql = new StringBuilder();
            strSql.Append(@"select * from  F_Annxles_weaver  d
where 1=1  ");
            strSql.Append(string.Format(" AND d.F_weaverid={0} And d.F_Weavertable ='{1}'", weaverid,tablename));

            var list = this.BaseRepository().FindList<F_Annxles_weaverEntity>(strSql.ToString());

      
            foreach(var item in list)
            {
                bool isPicture = util.IsPicture(item.F_FilePath);
                if ((isImage && isPicture)||(!isImage&&!isPicture))
                {
                    temp += ReplaceUrl(item.F_FilePath);
                    temp += ",";
                    i++;
                }

            }

            if (i > 0)
            {
                return temp.Substring(0, temp.Length - 1);
            }
            else
            {
                return temp;
            }

        }


        //替换路径 
        public string ReplaceUrl(string Url)
        {
            string systemUrl = Config.GetValue("systemUrl");
            string ServerUrl = Config.GetValue("ServerUrl");

            return Url.Replace(ServerUrl, systemUrl);

        }
        public bool MoveWeaverFile(int  weaverid,string tablename,string annfileids)
        {
            try
            {

                F_Annxles_weaverEntity entity = null;
                string filePath = Config.GetValue("WeaverAnnexesFile");
                string FloderPath = string.Empty;
                string fileinfo = string.Empty;
                var strSql = new StringBuilder();
                strSql.Append(@"select * from  ecology.dbo.imagefile i join  ecology.dbo.docimagefile d  on  d.imagefileid = i.imagefileid 
where 1=1  ");
                strSql.Append(string.Format("AND d.docid in ( {0})", annfileids));
               // d.docid in (4976, 4977, 4978, 4979, -1)
                //var dp = new DynamicParameters(new { });
                //if (!annfileids.IsEmpty())
                //{
                //    dp.Add("docid", annfileids, DbType.String);
                //    strSql.Append(" AND d.docid in ( @docid ) ");
                //}
                var list = this.BaseRepository().FindList<ImageFileEntity>(strSql.ToString());

                SimpleLogUtil.WriteTextLog("formtable_main_134sql", strSql.ToString(), DateTime.Now);

                foreach (var item in list)
                {
                    FloderPath = string.Format("{0}/{1}/{2}/", filePath,tablename,weaverid);
                    if (!Directory.Exists(FloderPath))
                    {
                        Directory.CreateDirectory(FloderPath);
                    }

                    string filename = System.IO.Path.GetFileName(item.filerealpath);//文件名  “Default.aspx”
                    string extension = System.IO.Path.GetExtension(item.filerealpath);//扩展名 “.aspx”
                    string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(item.filerealpath);
                   
                     fileinfo = string.Format("{0}{1}", FloderPath, item.imagefilename);

                    ZipHelper.UnGzipFile(item.filerealpath, FloderPath);
                    SimpleLogUtil.WriteTextLog("formtable_main_134UNGIzip", item.filerealpath, DateTime.Now);
                    SimpleLogUtil.WriteTextLog("formtable_main_134UNGIzip", fileinfo, DateTime.Now);
                   
                     FileInfo fi = new FileInfo(string.Format("{0}{1}",FloderPath, fileNameWithoutExtension));
                    SimpleLogUtil.WriteTextLog("formtable_main_134UNGIzip", FloderPath+ fileNameWithoutExtension, DateTime.Now);
                    fi.MoveTo(fileinfo);
                    entity = new F_Annxles_weaverEntity();
                    entity.F_FileName = item.imagefilename;
                    entity.F_FilePath = fileinfo;
                    entity.F_weaverid = weaverid;
                    entity.F_Weavertable = tablename;
                   // entity.F_Weaverdocid = tablename;
                    //entity.F_Weaverdocid =item.
                    entity.F_WeaverImageId = item.imagefileid;
                    entity.Create();
                    this.BaseRepository().Insert(entity);

                }

                return true;
               
            }
            catch (Exception ex)
            {
                SimpleLogUtil.WriteTextLog("formtable_main_134Exception", ex.Message, DateTime.Now);
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }



        }

        /// <summary>
        /// 获取实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public F_Annxles_weaverEntity GetEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<F_Annxles_weaverEntity>(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        #endregion

        #region 提交数据

        /// <summary>
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void DeleteEntity(string keyValue)
        {
            try
            {
                this.BaseRepository().Delete<F_Annxles_weaverEntity>(t=>t.F_Id == keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void SaveEntity(string keyValue, F_Annxles_weaverEntity entity)
        {
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.Modify(keyValue);
                    this.BaseRepository().Update(entity);
                }
                else
                {
                    entity.Create();
                    this.BaseRepository().Insert(entity);
                }
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        #endregion

    }
}
